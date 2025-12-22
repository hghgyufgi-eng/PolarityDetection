using Itminus.Middlewares;
using Itminus.Protocols.Common;
using Newtonsoft.Json;
using StdUnit.Sharp7.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisDummy.Protocols.大面贴胶检测.Model;

namespace VisDummy.Protocols.大面贴胶检测
{
    public class ScanContext : IWorkContext, IScanContext<DevMsg, MstMsg>, IScanContextWithHeartBeat
    {
        public ScanContext(IServiceProvider sp, DevMsg devmsg, MstMsg mstmsg, DateTimeOffset createdAt)
        {
            ServiceProvider = sp;
            DevMsg = devmsg;
            MstMsg = mstmsg;
            CreatedAt = createdAt;
            //HeartBeatSynced = DevMsg.Heart.HasHeartBeat == MstMsg.Heart.HasHeartBeat;
        }

        /// <summary>
        /// 只读属性
        /// </summary>
        public DevMsg DevMsg { get; }

        /// <summary>
        /// 只读属性
        /// </summary>
        public MstMsg MstMsg { get; }

        [JsonIgnore]
        public IServiceProvider ServiceProvider { get; }

        public DateTimeOffset CreatedAt { get; }

        /// <summary>
        /// 心跳是否已经同步
        /// </summary>
        public bool HeartBeatSynced { get; }
    }
}
