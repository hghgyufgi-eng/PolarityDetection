using Itminus.FSharpExtensions;
using Itminus.Protocols;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.FSharp.Core;
using VisDummy.Abstractions.Args;
using VisDummy.Abstractions.Infra;
using VisDummy.Abstractions.Warp;
using VisDummy.Lang.Resources;
using VisDummy.Protocols.极性检测.Middlewares.Common;
using VisDummy.Protocols.极性检测.Model;

namespace VisDummy.Protocols.极性检测.Middlewares
{
    public class HandleStation2DMiddleware(极性检测Flusher flusher, IVisProc visproc, IVisParams visParams, ILogger<HandlePlcRequestMiddlewareBase<DevMsg_2DStation, MstMsg_2DStation, StationArgs_Polarity, StationOkWrap_极性检测, StationErrWrap_极性检测>> logger, IMediator mediator) : HandlePlcRequestMiddlewareBase<
        DevMsg_2DStation, MstMsg_2DStation, StationArgs_Polarity,
        StationOkWrap_极性检测, StationErrWrap_极性检测
        >(flusher, logger, mediator)
    {
        public override string PlcName => PlcNames.PLCNAME_极性检测;

        public override string ProcName => Language.Msg_正常工作拍照 + "1";

        public override bool HasAck(MstMsg_2DStation p) => p.CmdReply.Ack;


        public override bool HasReq(DevMsg_2DStation i) => i.CmdTrigger.Trigger;

        public override DevMsg_2DStation RefIncoming(ScanContext ctx) => ctx.DevMsg.Station2D;


        public override MstMsg_2DStation RefPending(ScanContext ctx) => ctx.MstMsg.Station2D;

        protected override async Task<FSharpResult<StationOkWrap_极性检测, StationErrWrap_极性检测>> HandleArgsAsync(StationArgs_Polarity args)
        {
            await RecordLogAsync(LogLevel.Information, $"{ProcName}:{Language.Msg_视觉输入参数}：{args.ToMsg()}");
            var res = from r1 in visParams.SetTriggerGlobalParams()
                      .SelectError(s => new StationErrWrap_极性检测 { ErrMsg = s })
                      from r2 in visproc.极性检测ProcAsync(args)
                      select r2;
            return await res;
        }

        protected override async Task HandleErrAsync(MstMsg_2DStation pending, StationErrWrap_极性检测 err)
        {
            pending.CmdReply.SetOn(false);
            await RecordLogAsync(LogLevel.Error, $"{Language.Msg_拍照失败}：{err.ToMsg()}");
        }

        protected override async Task HandleOkAsync(MstMsg_2DStation pending, StationOkWrap_极性检测 descriptions)
        {
            pending.CmdReply.SetOn(true);
            pending.CmdReply.SetOnResult(new Model.CellDetail()
            {
                cellWhether = (ushort)descriptions.CellDetai1.CellWhether,
                cellCode = new Protocols.Common.String30() { EffectiveContent = descriptions.CellDetai1.CellCode },
                cellPolarity = (ushort)descriptions.CellDetai1.CellPolarity,
                cellVariety = (ushort)descriptions.CellDetai1.CellVariety
            },
            new Model.CellDetail()
            {
                cellWhether = (ushort)descriptions.CellDetai2.CellWhether,
                cellCode = new Protocols.Common.String30() { EffectiveContent = descriptions.CellDetai2.CellCode },
                cellPolarity = (ushort)descriptions.CellDetai2.CellPolarity,
                cellVariety = (ushort)descriptions.CellDetai2.CellVariety
            }, descriptions.ParameterStatus);
            await RecordLogAsync(LogLevel.Information, $"{Language.Msg_拍照成功}：{descriptions.ToMsg()}");
        }

        protected override async Task ResetAckAsync(MstMsg_2DStation pending)
        {
            pending.CmdReply.SetOff();
            await RecordLogAsync(LogLevel.Information, Language.Msg_初始化);
        }

        protected override FSharpResult<StationArgs_Polarity, string> TryParseArgs(DevMsg_2DStation incoming)
        {
            var args = new StationArgs_Polarity()
            {
                Function = incoming.CmdTrigger.function,
                PhotoPosition = incoming.CmdTrigger.photoPosition,
                Batch = incoming.CmdTrigger.batch,
                Phototimes = incoming.CmdTrigger.phototimes,
            };
            return args.ToOkResult<StationArgs_Polarity, string>();
        }
    }
}
