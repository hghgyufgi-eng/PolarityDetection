using Itminus.FSharpExtensions;
using Itminus.Protocols;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.FSharp.Core;
using VisDummy.Abstractions.Args;
using VisDummy.Abstractions.Infra;
using VisDummy.Abstractions.Warp;
using VisDummy.Lang.Resources;
using VisDummy.Protocols.大面贴胶检测.Middlewares.Common;
using VisDummy.Protocols.大面贴胶检测.Model;

namespace VisDummy.Protocols.大面贴胶检测.Middlewares
{
    public class HandleStation2DSpotMiddleware(大面贴胶检测Flusher flusher, IVisProc visproc, IVisParams visParams, ILogger<HandlePlcRequestMiddlewareBase<DevMsg_2DSpotStation, MstMsg_2DSpotStation, SpotStationArgs_Large, SpotStationOkWarp_大面贴胶检测, SpotStationErrWarp_大面贴胶检测>> logger, IMediator mediator) : HandlePlcRequestMiddlewareBase<
        DevMsg_2DSpotStation, MstMsg_2DSpotStation, SpotStationArgs_Large,
        SpotStationOkWarp_大面贴胶检测, SpotStationErrWarp_大面贴胶检测
        >(flusher, logger, mediator)
    {
        public override string PlcName => PlcNames.PLCNAME_大面贴胶检测;

        public override string ProcName => Language.Msg_精度校验 + "2";

        public override bool HasAck(MstMsg_2DSpotStation p) => p.CmdSpot.Ack;


        public override bool HasReq(DevMsg_2DSpotStation i) => i.CmdSpot.CameraTrigger;

        public override DevMsg_2DSpotStation RefIncoming(ScanContext ctx) => ctx.DevMsg.Station2DSpot;


        public override MstMsg_2DSpotStation RefPending(ScanContext ctx) => ctx.MstMsg.Station2DSpot;

        protected override async Task<FSharpResult<SpotStationOkWarp_大面贴胶检测, SpotStationErrWarp_大面贴胶检测>> HandleArgsAsync(SpotStationArgs_Large args)
        {
            await RecordLogAsync(LogLevel.Information, $"{ProcName}:{Language.Msg_视觉输入参数}：{args.ToMsg()}");
            var res = from r1 in visParams.SetTriggerGlobalParams()
                      .SelectError(s => new SpotStationErrWarp_大面贴胶检测 { ErrMsg = s })
                      from r2 in visproc.大面贴胶检测SpotProcAsync(args)
                      select r2;
            return await res;
        }

        protected override async Task HandleErrAsync(MstMsg_2DSpotStation pending, SpotStationErrWarp_大面贴胶检测 err)
        {
            pending.CmdSpot.SetOn(false);
            await RecordLogAsync(LogLevel.Error, $"{Language.Msg_拍照失败}：{err.ToMsg()}");
        }

        protected override async Task HandleOkAsync(MstMsg_2DSpotStation pending, SpotStationOkWarp_大面贴胶检测 descriptions)
        {
            pending.CmdSpot.SetOn(true);
            pending.CmdSpot.SetResult(descriptions.FeatureSize, descriptions.CameraPrecision);
            await RecordLogAsync(LogLevel.Information, $"{Language.Msg_拍照成功}：{descriptions.ToMsg()}");
        }

        protected override async Task ResetAckAsync(MstMsg_2DSpotStation pending)
        {
            pending.CmdSpot.SetOff();
            await RecordLogAsync(LogLevel.Information, Language.Msg_初始化);
        }

        protected override FSharpResult<SpotStationArgs_Large, string> TryParseArgs(DevMsg_2DSpotStation incoming)
        {
            var args = new SpotStationArgs_Large()
            {
                CameraNo = incoming.CmdSpot.CameraNo,
            };
            return args.ToOkResult<SpotStationArgs_Large, string>();
        }
    }
}
