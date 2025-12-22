using Itminus.FSharpExtensions;
using Itminus.Protocols;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.FSharp.Core;
using VisDummy.Abstractions.Args;
using VisDummy.Abstractions.Infra;
using VisDummy.Abstractions.Warp;
using VisDummy.Lang.Resources;
using VisDummy.Protocols.极性检测2.Middlewares.Common;
using VisDummy.Protocols.极性检测.Model;

namespace VisDummy.Protocols.极性检测2.Middlewares
{
    public class HandleStation2DSpotMiddleware(极性检测2Flusher flusher, IVisProc visproc, IVisParams visParams, ILogger<HandlePlcRequestMiddleware2Base<DevMsg_2DSpotStation, MstMsg_2DSpotStation, SpotStationArgs_JX, SpotStationOkWarp_极性检测, SpotStationErrWarp_极性检测>> logger, IMediator mediator) : HandlePlcRequestMiddleware2Base<
        DevMsg_2DSpotStation, MstMsg_2DSpotStation, SpotStationArgs_JX,
        SpotStationOkWarp_极性检测, SpotStationErrWarp_极性检测
        >(flusher, logger, mediator)
    {
        public override string PlcName => PlcNames.PLCNAME_极性检测2;

        public override string ProcName => Language.Msg_精度校验 + "2";

        public override bool HasAck(MstMsg_2DSpotStation p) => p.CmdSpot.Ack;


        public override bool HasReq(DevMsg_2DSpotStation i) => i.CmdSpot.CameraTrigger;
        
        public override DevMsg_2DSpotStation RefIncoming(ScanContext ctx) => ctx.DevMsg.Station2DSpot;


        public override MstMsg_2DSpotStation RefPending(ScanContext ctx) => ctx.MstMsg.SpotStation;

        protected override async Task<FSharpResult<SpotStationOkWarp_极性检测, SpotStationErrWarp_极性检测>> HandleArgsAsync(SpotStationArgs_JX args)
        {
            await RecordLogAsync(LogLevel.Information, $"{ProcName}:{Language.Msg_视觉输入参数}：{args.ToMsg()}");
            var res = from r1 in visParams.SetTriggerGlobalParams()
                      .SelectError(s => new SpotStationErrWarp_极性检测 { ErrMsg = s })
                      from r2 in visproc.极性检测SpotProcAsync(args)
                      select r2;
            return await res;
        }

        protected override async Task HandleErrAsync(MstMsg_2DSpotStation pending, SpotStationErrWarp_极性检测 err)
        {
            pending.CmdSpot.SetOn(false);
            await RecordLogAsync(LogLevel.Error, $"{Language.Msg_拍照失败}：{err.ToMsg()}");
        }

        protected override async Task HandleOkAsync(MstMsg_2DSpotStation pending, SpotStationOkWarp_极性检测 descriptions)
        {
            pending.CmdSpot.SetOn(true);
            pending.CmdSpot.SetResult(descriptions.FeatureSize, descriptions.CameraPrecision,descriptions.Result);
            await RecordLogAsync(LogLevel.Information, $"{Language.Msg_拍照成功}：{descriptions.ToMsg()}");
        }

        protected override async Task ResetAckAsync(MstMsg_2DSpotStation pending)
        {
            pending.CmdSpot.SetOff();
            await RecordLogAsync(LogLevel.Information, Language.Msg_初始化);
        }

        protected override FSharpResult<SpotStationArgs_JX, string> TryParseArgs(DevMsg_2DSpotStation incoming)
        {
            var args = new SpotStationArgs_JX()
            {
                CameraNo = incoming.CmdSpot.CameraNo,
            };
            return args.ToOkResult<SpotStationArgs_JX, string>();
        }
    }
}
