using Itminus.Protocols;
using Microsoft.Extensions.Options;
using StdUnit.Sharp7.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisDummy.Lang.Resources;
using VisDummy.Protocols.大面贴胶检测.Model;

namespace VisDummy.Protocols.大面贴胶检测
{
    public class 大面贴胶检测Flusher : S7PlcFlusher<大面贴胶检测Scanner, DevMsg, MstMsg>
    {
        public 大面贴胶检测Flusher(IOptionsMonitor<S7ScanOpt> scanOptsMonitor, 大面贴胶检测Scanner scanner) : base(scanOptsMonitor, scanner)
        {
        }

        protected override string PlcName => PlcNames.PLCNAME_大面贴胶检测;

        public override async Task FlushAsync(MstMsg mstmsg)
        {
            var s7ScanOpt = _scanOptsMonitor.Get(_scanner.ScanName);
            var write = await _scanner.PlcCtrl.WriteDBAsync(s7ScanOpt.MstMsg_DB_INDEX, s7ScanOpt.MstMsg_DB_OFFSET, mstmsg);
            if (write.IsError)
            {
                throw new Exception($"【{PlcName}】{Language.Msg_向PLC写数据错误}：{write.ErrorValue}");
            }
        }
    }
}
