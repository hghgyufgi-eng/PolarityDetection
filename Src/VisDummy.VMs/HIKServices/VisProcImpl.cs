using DynamicData;
using Itminus.FSharpExtensions;
using Microsoft.FSharp.Core;
using ReactiveUI;
using Splat;
using System.Linq;
using System.Reactive.Linq;
using System.Threading.Tasks;
using VisDummy.Abstractions.Args;
using VisDummy.Abstractions.Calibrations;
using VisDummy.Abstractions.Infra;
using VisDummy.Abstractions.Warp;
using VisDummy.Abstractions.Warp.NgReason;
using VisDummy.Lang;
using VisDummy.Lang.Resources;
using VisDummy.Shared.Utils;
using VisDummy.VMs.Common;
using VisDummy.VMs.ViewModels;
using VM.Core;
using VM.PlatformSDKCS;

namespace VisDummy.VMs.HIKServices
{

    public class VisProcImpl : IVisProc
    {
        #region 标定
        public async Task<FSharpResult<CalibarateNthPointOkWrap, IErr_CalibrateNthPoint>> CalibrateAsync(CalibrateNthPointArgs args)
        {
            VmProcedure proc = await LoadProcAndRenderInRtViewAsync();
            if (proc == null)
            {
                var err = new Err_ProcedureNG() { Msg = $"当前尚未选定标定流程！" };
                return err.ToErrResult<CalibarateNthPointOkWrap, IErr_CalibrateNthPoint>();
            }

            proc.ModuParams.SetInputInt("nth", new int[] { args.Nth });
            proc.ModuParams.SetInputFloat("物理坐标X", new float[] { args.WldX });
            proc.ModuParams.SetInputFloat("物理坐标Y", new float[] { args.WldY });
            proc.ModuParams.SetInputFloat("物理角度A", new float[] { args.WldA });

            proc.Run();

            var mres = proc.ModuResult;
            var outputs =
                from x in mres.GetFloat("图像坐标X")
                from y in mres.GetFloat("图像坐标Y")
                from a in mres.GetFloat("图像坐标A")
                from status in mres.GetInt("标定状态")
                select new CalibarateNthPointOkWrap { ImgA = a, ImgX = x, ImgY = y, 标定状态 = status != 0 };

            var res = outputs
                .SelectError(e => new Err_ProcedureNG() { Msg = e } as IErr_CalibrateNthPoint);
            return res;
        }

        protected virtual Task<VmProcedure> LoadProcAndRenderInRtViewAsync()
        {
            var vm = Locator.Current.GetService<ManualVisCalibrationViewModel>();
            var proc = vm.CurrentProc;
            return Task.FromResult(proc);
        }
        #endregion

        protected virtual async Task<VmProcedure> LoadProcAsync(string procName)
        {
            var rts = Locator.Current.GetServices<IVisionMarker>();

            var rt = rts.FirstOrDefault(i => i.ProcName == procName);
            if (rt is VisRtViewModel vm)
            {
                var proc = vm.CurrentProc;

                // 如果尚未加载，则等待加载完成
                if (proc == null)
                {
                    var obs = Observable.Start(async () =>
                    {
                        var x = await vm.CmdSelectProcedure.Execute();
                        proc = vm.CurrentProc;
                    }, scheduler: RxApp.MainThreadScheduler);
                    await obs;
                }
                return proc;
            }
            throw new System.Exception($"{Language.Msg_流程未注册或未注册成}{typeof(VisRtViewModel)}:{procName}");
        }

        public async Task<FSharpResult<StationOkWrap_Loading, StationErrWrap_Loading>> LoadingProcAsync(StationArgs args)
        {
            VmProcedure proc = await LoadProcAsync(ProcedureLoading2D_Defines.流程名);
            if (proc == null)
            {
                var micerr = new StationErrWrap_Loading() { ErrMsg = $"{Language.Msg_加载流程失败}:{ProcedureLoading2D_Defines.流程名}" };
                return micerr.ToErrResult<StationOkWrap_Loading, StationErrWrap_Loading>();
            }
            proc.ModuParams.SetInputInt(ProcedureLoading2D_Defines.Function, [args.Function]);
            proc.ModuParams.SetInputInt(ProcedureLoading2D_Defines.Position, [args.Position]);
            proc.ModuParams.SetInputString(ProcedureLoading2D_Defines.Batch, [new InputStringData { strValue = args.Batch.ToString() }]);

            proc.Run();

            var mres = proc.ModuResult;

            var s =
                 from ImagePath in mres.GetString(ProcedureLoading2D_Defines.ImagePath)
                 from Direction in mres.GetInt(ProcedureLoading2D_Defines.IncomingDirection)
                 from BarCode in mres.GetString(ProcedureLoading2D_Defines.BarCode)
                 from ErrorCode in mres.GetInt(ProcedureLoading2D_Defines.ErrorCode)
                 select new { ImagePath, Direction, BarCode, ErrorCode };

            if (s.IsError)
            {
                var micerr = new StationErrWrap_Loading() { ErrMsg = s.ErrorValue };
                return micerr.ToErrResult<StationOkWrap_Loading, StationErrWrap_Loading>();
            }
            var outputs = s.ResultValue;
            if (outputs.ErrorCode == 1)
            {
                var ok = new StationOkWrap_Loading
                {
                    ImagePath = outputs.ImagePath,
                    Direction = (ushort)outputs.Direction,
                    BarCode = outputs.BarCode,
                };
                return ok.ToOkResult<StationOkWrap_Loading, StationErrWrap_Loading>();
            }
            var err = new StationErrWrap_Loading()
            {
                ImagePath = outputs.ImagePath,
                ErrorCode = (uint)outputs.ErrorCode,
            };
            return err.ToErrResult<StationOkWrap_Loading, StationErrWrap_Loading>();
        }

        public async Task<FSharpResult<SpotStationOkWarp, SpotStationErrWarp>> SpotProcAsync(SpotStationArgs args)
        {
            VmProcedure proc = await LoadProcAsync(Procedure2DSpot_Defines.流程名);
            if (proc == null)
            {
                var micerr = new SpotStationErrWarp() { ErrMsg = $"{Language.Msg_加载流程失败}:{Procedure2DSpot_Defines.流程名}" };
                return micerr.ToErrResult<SpotStationOkWarp, SpotStationErrWarp>();
            }
            proc.ModuParams.SetInputInt(Procedure2DSpot_Defines.Camera, [args.Camera]);
            proc.ModuParams.SetInputInt(Procedure2DSpot_Defines.Position, [args.Position]);

            proc.Run();

            var mres = proc.ModuResult;

            var s =
                 from ImagePath in mres.GetString(Procedure2DSpot_Defines.ImagePath)
                 from Feature in mres.GetFloat(Procedure2DSpot_Defines.Feature)
                 from Pixel in mres.GetFloat(Procedure2DSpot_Defines.Pixel)
                 from ErrorCode in mres.GetInt(Procedure2DSpot_Defines.ErrorCode)
                 select new { ImagePath, Feature, Pixel, ErrorCode };

            if (s.IsError)
            {
                var micerr = new SpotStationErrWarp() { ErrMsg = s.ErrorValue };
                return micerr.ToErrResult<SpotStationOkWarp, SpotStationErrWarp>();
            }
            var outputs = s.ResultValue;
            if (outputs.ErrorCode == 1)
            {
                var ok = new SpotStationOkWarp
                {
                    ImagePath = outputs.ImagePath,
                    Features = outputs.Feature,
                    Pixels = outputs.Pixel,
                };
                return ok.ToOkResult<SpotStationOkWarp, SpotStationErrWarp>();
            }
            var err = new SpotStationErrWarp()
            {
                ImagePath = outputs.ImagePath,
                ErrorCode = (uint)outputs.ErrorCode,
            };
            return err.ToErrResult<SpotStationOkWarp, SpotStationErrWarp>();
        }

        public async Task<FSharpResult<StationOkWrap_极性检测, StationErrWrap_极性检测>> 极性检测ProcAsync(StationArgs_Polarity args)
        {
            VmProcedure proc = await LoadProcAsync(Procedure极性检测2D_Defines.流程名);
            if (proc == null)
            {
                var micerr = new StationErrWrap_极性检测() { ErrMsg = $"{Language.Msg_加载流程失败}:{Procedure极性检测2D_Defines.流程名}" };
                return micerr.ToErrResult<StationOkWrap_极性检测, StationErrWrap_极性检测>();
            }

            proc.ModuParams.SetInputInt(Procedure极性检测2D_Defines.功能号, [args.Function]);
            proc.ModuParams.SetInputInt(Procedure极性检测2D_Defines.拍照位置, [args.PhotoPosition]);
            proc.ModuParams.SetInputInt(Procedure极性检测2D_Defines.拍照次数, new int[] { args.Phototimes });
            proc.ModuParams.SetInputInt(Procedure极性检测2D_Defines.批次号,[(int)args.Batch]);

            proc.Run();

            var mres = proc.ModuResult;

            var s =
                 from 图像路径 in mres.GetString(Procedure极性检测2D_Defines.图像路径)
                 from 电芯码1 in mres.GetString(Procedure极性检测2D_Defines.电芯码1)
                 from 电芯码2 in mres.GetString(Procedure极性检测2D_Defines.电芯码2)
                 from 电芯1极性 in mres.GetInt(Procedure极性检测2D_Defines.电芯1极性)
                 from 电芯2极性 in mres.GetInt(Procedure极性检测2D_Defines.电芯2极性)
                 from 电芯1种类 in mres.GetInt(Procedure极性检测2D_Defines.电芯1种类)
                 from 电芯2种类 in mres.GetInt(Procedure极性检测2D_Defines.电芯2种类)
                 from 电芯1有无 in mres.GetInt(Procedure极性检测2D_Defines.电芯1有无)
                 from 电芯2有无 in mres.GetInt(Procedure极性检测2D_Defines.电芯2有无)
                 from 输入参数状态 in mres.GetInt(Procedure极性检测2D_Defines.输入参数状态)
                 from 总输出状态 in mres.GetInt(Procedure极性检测2D_Defines.总输出状态)
                 select new
                 {
                     图像路径,
                     电芯码1,
                     电芯码2,
                     电芯1极性,
                     电芯2极性,
                     电芯1种类,
                     电芯2种类,
                     电芯1有无,
                     电芯2有无,
                     输入参数状态,
                     总输出状态
                 };

            if (s.IsError)
            {
                var micerr = new StationErrWrap_极性检测() { ErrMsg = s.ErrorValue };
                return micerr.ToErrResult<StationOkWrap_极性检测, StationErrWrap_极性检测>();
            }
            var outputs = s.ResultValue;

            if (outputs.输入参数状态 != 1)
            {
                var err = new StationErrWrap_极性检测()
                {
                    ImagePath = outputs.图像路径,
                    ErrMsg = Language.Msg_PLC参数错误,
                    ParameterStatus = outputs.输入参数状态
                };
                return err.ToErrResult<StationOkWrap_极性检测, StationErrWrap_极性检测>();
            }

            if (outputs.总输出状态 != 1)
            {
                var err = new StationErrWrap_极性检测()
                {
                    ErrMsg = Language.Msg_总输出状态NG,
                    ImagePath = outputs.图像路径,
                    ParameterStatus = outputs.输入参数状态
                };
                return err.ToErrResult<StationOkWrap_极性检测, StationErrWrap_极性检测>();
            }

            var ok = new StationOkWrap_极性检测
            {
                CellDetai1 = new CellDetail()
                {
                    CellWhether = outputs.电芯1有无,
                    CellCode = outputs.电芯码1,
                    CellPolarity = outputs.电芯1极性,
                    CellVariety = outputs.电芯1种类
                },
                CellDetai2 = new CellDetail()
                {
                    CellWhether = outputs.电芯2有无,
                    CellCode = outputs.电芯码2,
                    CellPolarity = outputs.电芯2极性,
                    CellVariety = outputs.电芯2种类
                },
                ParameterStatus = outputs.输入参数状态
            };
            return ok.ToOkResult<StationOkWrap_极性检测, StationErrWrap_极性检测>();
        }

        public async Task<FSharpResult<StationOkWrap_极性检测, StationErrWrap_极性检测>> 极性检测ProcAsync1(StationArgs_Polarity args)
        {
            VmProcedure proc = await LoadProcAsync(Procedure极性检测2D1_Defines.流程名);
            if (proc == null)
            {
                var micerr = new StationErrWrap_极性检测() { ErrMsg = $"{Language.Msg_加载流程失败}:{Procedure极性检测2D_Defines.流程名}" };
                return micerr.ToErrResult<StationOkWrap_极性检测, StationErrWrap_极性检测>();
            }

            proc.ModuParams.SetInputInt(Procedure极性检测2D_Defines.功能号, [args.Function]);
            proc.ModuParams.SetInputInt(Procedure极性检测2D_Defines.拍照位置, [args.PhotoPosition]);
            proc.ModuParams.SetInputInt(Procedure极性检测2D_Defines.拍照次数, new int[] { args.Phototimes });
            proc.ModuParams.SetInputInt(Procedure极性检测2D_Defines.批次号, [(int)args.Batch]);

            proc.Run();

            var mres = proc.ModuResult;
            
            var s =
                 from 图像路径 in mres.GetString(Procedure极性检测2D_Defines.图像路径)
                 from 电芯码1 in mres.GetString(Procedure极性检测2D_Defines.电芯码1)
                 from 电芯码2 in mres.GetString(Procedure极性检测2D_Defines.电芯码2)
                 from 电芯1极性 in mres.GetInt(Procedure极性检测2D_Defines.电芯1极性)
                 from 电芯2极性 in mres.GetInt(Procedure极性检测2D_Defines.电芯2极性)
                 from 电芯1种类 in mres.GetInt(Procedure极性检测2D_Defines.电芯1种类)
                 from 电芯2种类 in mres.GetInt(Procedure极性检测2D_Defines.电芯2种类)
                 from 电芯1有无 in mres.GetInt(Procedure极性检测2D_Defines.电芯1有无)
                 from 电芯2有无 in mres.GetInt(Procedure极性检测2D_Defines.电芯2有无)
                 from 输入参数状态 in mres.GetInt(Procedure极性检测2D_Defines.输入参数状态)
                 from 总输出状态 in mres.GetInt(Procedure极性检测2D_Defines.总输出状态)
                 select new
                 {
                     图像路径,
                     电芯码1,
                     电芯码2,
                     电芯1极性,
                     电芯2极性,
                     电芯1种类,
                     电芯2种类,
                     电芯1有无,
                     电芯2有无,
                     输入参数状态,
                     总输出状态
                 };

            if (s.IsError)
            {
                var micerr = new StationErrWrap_极性检测() { ErrMsg = s.ErrorValue };
                return micerr.ToErrResult<StationOkWrap_极性检测, StationErrWrap_极性检测>();
            }
            var outputs = s.ResultValue;

            if (outputs.输入参数状态 != 1)
            {
                var err = new StationErrWrap_极性检测()
                {
                    ImagePath = outputs.图像路径,
                    ErrMsg = Language.Msg_PLC参数错误,
                    ParameterStatus = outputs.输入参数状态
                };
                return err.ToErrResult<StationOkWrap_极性检测, StationErrWrap_极性检测>();
            }

            if (outputs.总输出状态 != 1)
            {
                var err = new StationErrWrap_极性检测()
                {
                    ErrMsg = Language.Msg_总输出状态NG,
                    ImagePath = outputs.图像路径,
                    ParameterStatus = outputs.输入参数状态
                };
                return err.ToErrResult<StationOkWrap_极性检测, StationErrWrap_极性检测>();
            }

            var ok = new StationOkWrap_极性检测
            {
                CellDetai1 = new CellDetail()
                {
                    CellWhether = outputs.电芯1有无,
                    CellCode = outputs.电芯码1,
                    CellPolarity = outputs.电芯1极性,
                    CellVariety = outputs.电芯1种类
                },
                CellDetai2 = new CellDetail()
                {
                    CellWhether = outputs.电芯2有无,
                    CellCode = outputs.电芯码2,
                    CellPolarity = outputs.电芯2极性,
                    CellVariety = outputs.电芯2种类
                },
                ParameterStatus = outputs.输入参数状态
            };
            return ok.ToOkResult<StationOkWrap_极性检测, StationErrWrap_极性检测>();
        }

        public async Task<FSharpResult<StationOkWrap_大面贴胶检测, StationErrWrap_大面贴胶检测>> 大面贴胶检测1ProcAsync(StationArgs_Large args)
        {
            VmProcedure proc = await LoadProcAsync(Procedure大面贴胶检测12D_Defines.流程名);
            if (proc == null)
            {
                var micerr = new StationErrWrap_大面贴胶检测() { ErrMsg = $"{Language.Msg_加载流程失败}:{Procedure大面贴胶检测12D_Defines.流程名}" };
                return micerr.ToErrResult<StationOkWrap_大面贴胶检测, StationErrWrap_大面贴胶检测>();
            }

            proc.ModuParams.SetInputInt(Procedure大面贴胶检测12D_Defines.功能号, [args.Function]);
            proc.ModuParams.SetInputInt(Procedure大面贴胶检测12D_Defines.拍照位置, [args.PhotoPosition]);
            proc.ModuParams.SetInputInt(Procedure大面贴胶检测12D_Defines.批次号, [(int)args.Batch]);

            proc.Run();

            var mres = proc.ModuResult;

            var s =
                 from 图像路径 in mres.GetString(Procedure大面贴胶检测12D_Defines.图像路径)

                 from 无左电芯 in mres.GetInt(Procedure大面贴胶检测12D_Defines.无左电芯)
                 from 无右电芯 in mres.GetInt(Procedure大面贴胶检测12D_Defines.无右电芯)
                 from 无左胶料 in mres.GetInt(Procedure大面贴胶检测12D_Defines.无左胶料)
                 from 无右胶料 in mres.GetInt(Procedure大面贴胶检测12D_Defines.无右胶料)
                 from 左未撕纸 in mres.GetInt(Procedure大面贴胶检测12D_Defines.左未撕纸)
                 from 右未撕纸 in mres.GetInt(Procedure大面贴胶检测12D_Defines.右未撕纸)

                 from 输入参数状态 in mres.GetInt(Procedure大面贴胶检测12D_Defines.输入参数状态)
                 from 总输出状态 in mres.GetInt(Procedure大面贴胶检测12D_Defines.总输出状态)


                 select new
                 {
                     图像路径,
                     无左电芯,
                     无右电芯,
                     无左胶料,
                     无右胶料,
                     左未撕纸,
                     右未撕纸,
                     输入参数状态,
                     总输出状态,
                 };

            if (s.IsError)
            {
                var micerr = new StationErrWrap_大面贴胶检测() { ErrMsg = s.ErrorValue };
                return micerr.ToErrResult<StationOkWrap_大面贴胶检测, StationErrWrap_大面贴胶检测>();
            }
            var outputs = s.ResultValue;
            if (outputs.无左电芯 != 1)
            {
                var err = new StationErrWrap_大面贴胶检测()
                {
                    NgReason = StationNgReason_Large.无左电芯,
                    ErrMsg = Language.Msg_PLC参数错误,
                    ImagePath = outputs.图像路径
                };
                return err.ToErrResult<StationOkWrap_大面贴胶检测, StationErrWrap_大面贴胶检测>();
            }

            if (outputs.无右电芯 != 1)
            {
                var err = new StationErrWrap_大面贴胶检测()
                {
                    NgReason = StationNgReason_Large.无右电芯,
                    ErrMsg = Language.Msg_PLC参数错误,
                    ImagePath = outputs.图像路径
                };
                return err.ToErrResult<StationOkWrap_大面贴胶检测, StationErrWrap_大面贴胶检测>();
            }

            if (outputs.无左胶料 != 1)
            {
                var err = new StationErrWrap_大面贴胶检测()
                {
                    NgReason = StationNgReason_Large.无左胶料,
                    ErrMsg = Language.Msg_PLC参数错误,
                    ImagePath = outputs.图像路径
                };
                return err.ToErrResult<StationOkWrap_大面贴胶检测, StationErrWrap_大面贴胶检测>();
            }

            if (outputs.无右胶料 != 1)
            {
                var err = new StationErrWrap_大面贴胶检测()
                {
                    NgReason = StationNgReason_Large.无右胶料,
                    ErrMsg = Language.Msg_PLC参数错误,
                    ImagePath = outputs.图像路径
                };
                return err.ToErrResult<StationOkWrap_大面贴胶检测, StationErrWrap_大面贴胶检测>();
            }

            if (outputs.左未撕纸 != 1)
            {
                var err = new StationErrWrap_大面贴胶检测()
                {
                    NgReason = StationNgReason_Large.左未撕纸,
                    ErrMsg = Language.Msg_PLC参数错误,
                    ImagePath = outputs.图像路径
                };
                return err.ToErrResult<StationOkWrap_大面贴胶检测, StationErrWrap_大面贴胶检测>();
            }

            if (outputs.右未撕纸 != 1)
            {
                var err = new StationErrWrap_大面贴胶检测()
                {
                    NgReason = StationNgReason_Large.右未撕纸,
                    ErrMsg = Language.Msg_PLC参数错误,
                    ImagePath = outputs.图像路径
                };
                return err.ToErrResult<StationOkWrap_大面贴胶检测, StationErrWrap_大面贴胶检测>();
            }

            if (outputs.总输出状态 != 1)
            {
                var err = new StationErrWrap_大面贴胶检测()
                {
                    NgReason = StationNgReason_Large.输入参数状态,
                    ErrMsg = Language.Msg_总输出状态NG,
                    ImagePath = outputs.图像路径
                };
                return err.ToErrResult<StationOkWrap_大面贴胶检测, StationErrWrap_大面贴胶检测>();
            }

            var ok = new StationOkWrap_大面贴胶检测
            {
                ImagePath = outputs.图像路径
            };
            return ok.ToOkResult<StationOkWrap_大面贴胶检测, StationErrWrap_大面贴胶检测>();
        }

        public async Task<FSharpResult<StationOkWrap_大面贴胶检测, StationErrWrap_大面贴胶检测>> 大面贴胶检测2ProcAsync(StationArgs_Large args)
        {
            VmProcedure proc = await LoadProcAsync(Procedure大面贴胶检测22D_Defines.流程名);
            if (proc == null)
            {
                var micerr = new StationErrWrap_大面贴胶检测() { ErrMsg = $"{Language.Msg_加载流程失败}:{Procedure大面贴胶检测22D_Defines.流程名}" };
                return micerr.ToErrResult<StationOkWrap_大面贴胶检测, StationErrWrap_大面贴胶检测>();
            }

            proc.ModuParams.SetInputInt(Procedure大面贴胶检测22D_Defines.功能号, [args.Function]);
            proc.ModuParams.SetInputInt(Procedure大面贴胶检测22D_Defines.拍照位置, [args.PhotoPosition]);
            proc.ModuParams.SetInputInt(Procedure大面贴胶检测22D_Defines.批次号, [(int)args.Batch]);

            proc.Run();

            var mres = proc.ModuResult;

            var s =
                 from 图像路径 in mres.GetString(Procedure大面贴胶检测22D_Defines.图像路径)

                 from 无左电芯 in mres.GetInt(Procedure大面贴胶检测22D_Defines.无左电芯)
                 from 无右电芯 in mres.GetInt(Procedure大面贴胶检测22D_Defines.无右电芯)
                 from 无左胶料 in mres.GetInt(Procedure大面贴胶检测22D_Defines.无左胶料)
                 from 无右胶料 in mres.GetInt(Procedure大面贴胶检测22D_Defines.无右胶料)
                 from 左未撕纸 in mres.GetInt(Procedure大面贴胶检测22D_Defines.左未撕纸)
                 from 右未撕纸 in mres.GetInt(Procedure大面贴胶检测22D_Defines.右未撕纸)

                 from 输入参数状态 in mres.GetInt(Procedure大面贴胶检测22D_Defines.输入参数状态)
                 from 总输出状态 in mres.GetInt(Procedure大面贴胶检测22D_Defines.总输出状态)


                 select new
                 {
                     图像路径,
                     无左电芯,
                     无右电芯,
                     无左胶料,
                     无右胶料,
                     左未撕纸,
                     右未撕纸,
                     输入参数状态,
                     总输出状态,
                 };

            if (s.IsError)
            {
                var micerr = new StationErrWrap_大面贴胶检测() { ErrMsg = s.ErrorValue };
                return micerr.ToErrResult<StationOkWrap_大面贴胶检测, StationErrWrap_大面贴胶检测>();
            }
            var outputs = s.ResultValue;

            if (outputs.输入参数状态 != 1)
            {
                var err = new StationErrWrap_大面贴胶检测()
                {
                    NgReason = StationNgReason_Large.输入参数状态,
                    ErrMsg = Language.Msg_PLC参数错误,
                    ImagePath = outputs.图像路径
                };
                return err.ToErrResult<StationOkWrap_大面贴胶检测, StationErrWrap_大面贴胶检测>();
            }

            if (outputs.无左电芯 != 1)
            {
                var err = new StationErrWrap_大面贴胶检测()
                {
                    NgReason = StationNgReason_Large.无左电芯,
                    ErrMsg = Language.Msg_PLC参数错误,
                    ImagePath = outputs.图像路径
                };
                return err.ToErrResult<StationOkWrap_大面贴胶检测, StationErrWrap_大面贴胶检测>();
            }

            if (outputs.无右电芯 != 1)
            {
                var err = new StationErrWrap_大面贴胶检测()
                {
                    NgReason = StationNgReason_Large.无右电芯,
                    ErrMsg = Language.Msg_PLC参数错误,
                    ImagePath = outputs.图像路径
                };
                return err.ToErrResult<StationOkWrap_大面贴胶检测, StationErrWrap_大面贴胶检测>();
            }

            if (outputs.无左胶料 != 1)
            {
                var err = new StationErrWrap_大面贴胶检测()
                {
                    NgReason = StationNgReason_Large.无左胶料,
                    ErrMsg = Language.Msg_PLC参数错误,
                    ImagePath = outputs.图像路径
                };
                return err.ToErrResult<StationOkWrap_大面贴胶检测, StationErrWrap_大面贴胶检测>();
            }

            if (outputs.无右胶料 != 1)
            {
                var err = new StationErrWrap_大面贴胶检测()
                {
                    NgReason = StationNgReason_Large.无右胶料,
                    ErrMsg = Language.Msg_PLC参数错误,
                    ImagePath = outputs.图像路径
                };
                return err.ToErrResult<StationOkWrap_大面贴胶检测, StationErrWrap_大面贴胶检测>();
            }

            if (outputs.左未撕纸 != 1)
            {
                var err = new StationErrWrap_大面贴胶检测()
                {
                    NgReason = StationNgReason_Large.左未撕纸,
                    ErrMsg = Language.Msg_PLC参数错误,
                    ImagePath = outputs.图像路径
                };
                return err.ToErrResult<StationOkWrap_大面贴胶检测, StationErrWrap_大面贴胶检测>();
            }

            if (outputs.右未撕纸 != 1)
            {
                var err = new StationErrWrap_大面贴胶检测()
                {
                    NgReason = StationNgReason_Large.右未撕纸,
                    ErrMsg = Language.Msg_PLC参数错误,
                    ImagePath = outputs.图像路径
                };
                return err.ToErrResult<StationOkWrap_大面贴胶检测, StationErrWrap_大面贴胶检测>();
            }

            if (outputs.总输出状态 != 1)
            {
                var err = new StationErrWrap_大面贴胶检测()
                {
                    NgReason = StationNgReason_Large.输入参数状态,
                    ErrMsg = Language.Msg_总输出状态NG,
                    ImagePath = outputs.图像路径
                };
                return err.ToErrResult<StationOkWrap_大面贴胶检测, StationErrWrap_大面贴胶检测>();
            }

            var ok = new StationOkWrap_大面贴胶检测
            {
                ImagePath = outputs.图像路径
            };
            return ok.ToOkResult<StationOkWrap_大面贴胶检测, StationErrWrap_大面贴胶检测>();
        }

        public async Task<FSharpResult<StationOkWrap_大面贴胶检测, StationErrWrap_大面贴胶检测>> 大面贴胶检测NG替换ProcAsync(StationArgs_Large args)
        {
            VmProcedure proc = await LoadProcAsync(Procedure大面贴胶检测32D_Defines.流程名);
            if (proc == null)
            {
                var micerr = new StationErrWrap_大面贴胶检测() { ErrMsg = $"{Language.Msg_加载流程失败}:{Procedure大面贴胶检测32D_Defines.流程名}" };
                return micerr.ToErrResult<StationOkWrap_大面贴胶检测, StationErrWrap_大面贴胶检测>();
            }

            proc.ModuParams.SetInputInt(Procedure大面贴胶检测32D_Defines.功能号, [args.Function]);
            proc.ModuParams.SetInputInt(Procedure大面贴胶检测32D_Defines.拍照位置, [args.PhotoPosition]);
            proc.ModuParams.SetInputInt(Procedure大面贴胶检测32D_Defines.批次号, [(int)args.Batch]);

            proc.Run();

            var mres = proc.ModuResult;

            var s =
                 from 图像路径 in mres.GetString(Procedure大面贴胶检测32D_Defines.图像路径)

                 from 无电芯 in mres.GetInt(Procedure大面贴胶检测32D_Defines.无电芯)
                 from 无胶料 in mres.GetInt(Procedure大面贴胶检测32D_Defines.无胶料)
                 from 未撕纸 in mres.GetInt(Procedure大面贴胶检测32D_Defines.未撕纸)

                 from 输入参数状态 in mres.GetInt(Procedure大面贴胶检测32D_Defines.输入参数状态)
                 from 总输出状态 in mres.GetInt(Procedure大面贴胶检测32D_Defines.总输出状态)


                 select new
                 {
                     图像路径,
                     无电芯,
                     无胶料,
                     未撕纸,
                     输入参数状态,
                     总输出状态,
                 };

            if (s.IsError)
            {
                var micerr = new StationErrWrap_大面贴胶检测() { ErrMsg = s.ErrorValue };
                return micerr.ToErrResult<StationOkWrap_大面贴胶检测, StationErrWrap_大面贴胶检测>();
            }
            var outputs = s.ResultValue;

            if (outputs.输入参数状态 != 1)
            {
                var err = new StationErrWrap_大面贴胶检测()
                {
                    NgReason = StationNgReason_Large.输入参数状态,
                    ErrMsg = Language.Msg_PLC参数错误,
                    ImagePath = outputs.图像路径
                };
                return err.ToErrResult<StationOkWrap_大面贴胶检测, StationErrWrap_大面贴胶检测>();
            }

            if (outputs.无电芯 != 1)
            {
                var err = new StationErrWrap_大面贴胶检测()
                {
                    NgReason = StationNgReason_Large.无左电芯,
                    ErrMsg = Language.Msg_PLC参数错误,
                    ImagePath = outputs.图像路径
                };
                return err.ToErrResult<StationOkWrap_大面贴胶检测, StationErrWrap_大面贴胶检测>();
            }

            if (outputs.无胶料 != 1)
            {
                var err = new StationErrWrap_大面贴胶检测()
                {
                    NgReason = StationNgReason_Large.无左胶料,
                    ErrMsg = Language.Msg_PLC参数错误,
                    ImagePath = outputs.图像路径
                };
                return err.ToErrResult<StationOkWrap_大面贴胶检测, StationErrWrap_大面贴胶检测>();
            }

            if (outputs.未撕纸 != 1)
            {
                var err = new StationErrWrap_大面贴胶检测()
                {
                    NgReason = StationNgReason_Large.左未撕纸,
                    ErrMsg = Language.Msg_PLC参数错误,
                    ImagePath = outputs.图像路径
                };
                return err.ToErrResult<StationOkWrap_大面贴胶检测, StationErrWrap_大面贴胶检测>();
            }

            if (outputs.总输出状态 != 1)
            {
                var err = new StationErrWrap_大面贴胶检测()
                {
                    NgReason = StationNgReason_Large.输入参数状态,
                    ErrMsg = Language.Msg_总输出状态NG,
                    ImagePath = outputs.图像路径
                };
                return err.ToErrResult<StationOkWrap_大面贴胶检测, StationErrWrap_大面贴胶检测>();
            }

            var ok = new StationOkWrap_大面贴胶检测
            {
                ImagePath = outputs.图像路径
            };
            return ok.ToOkResult<StationOkWrap_大面贴胶检测, StationErrWrap_大面贴胶检测>();
        }

        public async Task<FSharpResult<SpotStationOkWarp_大面贴胶检测, SpotStationErrWarp_大面贴胶检测>> 大面贴胶检测SpotProcAsync(SpotStationArgs_Large args)
        {
            VmProcedure proc = await LoadProcAsync(Procedure大面贴胶检测2DSpot_Defines.流程名);
            if (proc == null)
            {
                var micerr = new SpotStationErrWarp_大面贴胶检测() { ErrMsg = $"{Language.Msg_加载流程失败}:{Procedure大面贴胶检测2DSpot_Defines.流程名}" };
                return micerr.ToErrResult<SpotStationOkWarp_大面贴胶检测, SpotStationErrWarp_大面贴胶检测>();
            }
            proc.ModuParams.SetInputInt(Procedure大面贴胶检测2DSpot_Defines.相机号, [args.CameraNo]);

            proc.Run();

            var mres = proc.ModuResult;

            var s =
                 from 图像路径 in mres.GetString(Procedure大面贴胶检测2DSpot_Defines.图像路径)
                 from 特征大小 in mres.GetFloat(Procedure大面贴胶检测2DSpot_Defines.特征大小)
                 from 像素精度 in mres.GetFloat(Procedure大面贴胶检测2DSpot_Defines.像素精度)
                 from 总输出状态 in mres.GetInt(Procedure大面贴胶检测2DSpot_Defines.总输出状态)

                 select new
                 {
                     图像路径,
                     特征大小,
                     像素精度,
                     总输出状态,
                 };

            if (s.IsError)
            {
                var micerr = new SpotStationErrWarp_大面贴胶检测() { ErrMsg = s.ErrorValue };
                return micerr.ToErrResult<SpotStationOkWarp_大面贴胶检测, SpotStationErrWarp_大面贴胶检测>();
            }
            var outputs = s.ResultValue;

            if (outputs.总输出状态 != 1)
            {
                var err = new SpotStationErrWarp_大面贴胶检测()
                {
                    ImagePath = outputs.图像路径,
                    ErrMsg = Language.Msg_总输出状态NG,
                };
                return err.ToErrResult<SpotStationOkWarp_大面贴胶检测, SpotStationErrWarp_大面贴胶检测>();
            }

            var ok = new SpotStationOkWarp_大面贴胶检测
            {
                CameraPrecision = outputs.像素精度,
                FeatureSize = outputs.特征大小,
                ImagePath = outputs.图像路径
            };
            return ok.ToOkResult<SpotStationOkWarp_大面贴胶检测, SpotStationErrWarp_大面贴胶检测>();
        }

        public async Task<FSharpResult<SpotStationOkWarp_极性检测, SpotStationErrWarp_极性检测>> 极性检测SpotProcAsync(SpotStationArgs_JX args)
        {
           
            VmProcedure proc = await LoadProcAsync(Procedure极性检测2DSpot_Defines.流程名);
            if (proc == null)
            {
                var micerr = new SpotStationErrWarp_极性检测() { ErrMsg = $"{Language.Msg_加载流程失败}:{Procedure极性检测2DSpot_Defines.流程名}" };
                return micerr.ToErrResult<SpotStationOkWarp_极性检测, SpotStationErrWarp_极性检测>();
            }
            proc.ModuParams.SetInputInt(Procedure极性检测2DSpot_Defines.相机号, [args.CameraNo]);

            proc.Run();

            var mres = proc.ModuResult;

            var s =
                 from 图像路径 in mres.GetString(Procedure极性检测2DSpot_Defines.图像路径)
                 from 特征大小 in mres.GetFloat(Procedure极性检测2DSpot_Defines.特征大小)
                 from 像素精度 in mres.GetFloat(Procedure极性检测2DSpot_Defines.像素精度)
                 from 总输出状态 in mres.GetInt(Procedure极性检测2DSpot_Defines.总输出状态)

                 select new
                 {
                     图像路径,
                     特征大小,
                     像素精度,
                     总输出状态,
                 };

            if (s.IsError)
            {
                var micerr = new SpotStationErrWarp_极性检测() { ErrMsg = s.ErrorValue };
                return micerr.ToErrResult<SpotStationOkWarp_极性检测, SpotStationErrWarp_极性检测>();
            }
            var outputs = s.ResultValue;

            if (outputs.总输出状态 != 1)
            {
                var err = new SpotStationErrWarp_极性检测()
                {
                    ImagePath = outputs.图像路径,
                    ErrMsg = Language.Msg_总输出状态NG,
                };
                return err.ToErrResult<SpotStationOkWarp_极性检测, SpotStationErrWarp_极性检测>();
            }

            var ok = new SpotStationOkWarp_极性检测
            {
                CameraPrecision = outputs.像素精度,
                FeatureSize = outputs.特征大小,
                ImagePath = outputs.图像路径,
                Result=(ushort)outputs.总输出状态
            };
            return ok.ToOkResult<SpotStationOkWarp_极性检测, SpotStationErrWarp_极性检测>();
        }
    }
}
