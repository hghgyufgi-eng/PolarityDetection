using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using VisDummy.Protocols.极性检测.Middlewares;
using VisDummy.Protocols.极性检测.Middlewares.Common;
using VisDummy.Protocols.极性检测2.Middlewares;
using VisDummy.Protocols.极性检测2.Middlewares.Common;
using VisDummy.Protocols.极性检测2.Middlewares.Common.PublishNotification;

namespace VisDummy.Protocols.极性检测2
{
    public static class ServiceCollectionExtensions
    {

        public static IServiceCollection AddPlcServicesFor极性检测2(this IServiceCollection services)
        {
            // background services & plc processor
            services.AddSingleton<IHostedService, PlcHostedService>();
            services.AddSingleton<极性检测2Flusher>();
            services.AddSingleton<极性检测2Scanner>();
            services.AddSingleton<ScanProcessor>();

            #region 中间件
            //services.TryAddScoped<HeartBeatMiddleware>();
            services.AddScoped<PublishNotificationMiddleware>();
            //services.AddScoped<MaintainMiddleware>();
            services.AddScoped<FlushPending2Middleware>();

            //services.AddScoped<HandleStation2DMiddleware>();
            services.AddScoped<HandleStation2D1Middleware>();
            services.AddScoped<HandleStation2DSpotMiddleware>(); 
            #endregion

            return services;
        }


    }
}
