using Itminus.Middlewares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisDummy.Protocols.大面贴胶检测.Middlewares;
using VisDummy.Protocols.大面贴胶检测.Middlewares.Common;
using VisDummy.Protocols.大面贴胶检测.Middlewares.Common.PublishNotification;

namespace VisDummy.Protocols.大面贴胶检测
{
    public class ScanProcessor
    {
        private WorkDelegate<ScanContext> BuildContainer()
        {
            var container = new WorkBuilder<ScanContext>()
                .Use<PublishNotificationMiddleware>()     // 发布
                .Use<HeartBeatMiddleware>()               // 心跳
                .Use<MaintainMiddleware>()                // 维护

            #region 具体业务中间件
                .Use<HandleStation12DMiddleware>()
                .Use<HandleStation22DMiddleware>()
                .Use<HandleStation32DMiddleware>()
                .Use<HandleStation2DSpotMiddleware>()
            #endregion

                .Use<FlushPendingMiddleware>()
                .Build();

            return container;
        }

        public async Task HandleAsync(ScanContext ctx)
        {
            var workcontainer = BuildContainer();
            await workcontainer.Invoke(ctx);
        }

    }
}
