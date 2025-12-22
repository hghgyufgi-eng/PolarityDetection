using Itminus.Middlewares;
using Itminus.Protocols.Common;
using Newtonsoft.Json;
using StdUnit.Sharp7.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisDummy.Protocols.极性检测2.Model;
//using VisDummy.Protocols.极性检测.Model;

namespace VisDummy.Protocols.极性检测2
{
    public class ScanContext : IWorkContext, IScanContext<DevMsg, MstMsg>, IScanContextWithHeartBeat
    {
        public ScanContext(IServiceProvider sp, DevMsg devmsg, MstMsg mstmsg, DateTimeOffset createdAt)
        {
            ServiceProvider = sp;
            DevMsg = devmsg;
            MstMsg = mstmsg;
            CreatedAt = createdAt;
            //HeartBeatSynced = DevMsg2.Heart.HasHeartBeat == MstMsg2.Heart.HasHeartBeat;
        }

        /// <summary>
        /// 只读属性
        /// </summary>
        public DevMsg DevMsg { get; }
        /// <summary>
        /// 只读属性2
        /// </summary>
        public 极性检测.Model.DevMsg DevMsg2 { get; }

        /// <summary>
        /// 只读属性
        /// </summary>
        public MstMsg MstMsg { get; }
        /// <summary>
        /// 只读属性2
        /// </summary>
        public 极性检测.Model.MstMsg MstMsg2 { get; }

        [JsonIgnore]
        public IServiceProvider ServiceProvider { get; }

        public DateTimeOffset CreatedAt { get; }

        /// <summary>
        /// 心跳是否已经同步
        /// </summary>
        public bool HeartBeatSynced { get; }
    }
}
