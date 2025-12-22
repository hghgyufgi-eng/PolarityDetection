using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisDummy.Protocols.大面贴胶检测;
using VisDummy.Protocols.大面贴胶检测.Middlewares;
using VisDummy.Protocols.大面贴胶检测.Middlewares.Common;
using VisDummy.Protocols.大面贴胶检测.Middlewares.Common.PublishNotification;

namespace VisDummy.Protocols.大面贴胶检测
{
    public static class ServiceCollectionExtensions
    {

        public static IServiceCollection AddPlcServicesFor大面贴胶检测(this IServiceCollection services)
        {
            // background services & plc processor
            services.AddSingleton<IHostedService, PlcHostedService>();
            services.AddSingleton<大面贴胶检测Flusher>();
            services.AddSingleton<大面贴胶检测Scanner>();
            services.AddSingleton<ScanProcessor>();

            #region 中间件
            services.TryAddScoped<HeartBeatMiddleware>();
            services.AddScoped<PublishNotificationMiddleware>();
            services.AddScoped<MaintainMiddleware>();
            services.AddScoped<FlushPendingMiddleware>();

            services.AddScoped<HandleStation12DMiddleware>();
            services.AddScoped<HandleStation22DMiddleware>();
            services.AddScoped<HandleStation32DMiddleware>();
            services.AddScoped<HandleStation2DSpotMiddleware>();
            #endregion

            return services;
        }


    }
}
