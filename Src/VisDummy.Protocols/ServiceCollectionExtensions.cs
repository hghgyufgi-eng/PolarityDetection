using Itminus.Protocols.Loading;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StdUnit.Sharp7.Options;
using VisDummy.Protocols.大面贴胶检测;
using VisDummy.Protocols.极性检测;
using VisDummy.Protocols.极性检测2;

namespace Itminus.Protocols
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// 添加Plc相关服务
        /// </summary>
        /// <param name="services"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public static IServiceCollection AddPlcServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddS7PlcOptions(config.GetSection("PlcConnections"), config.GetSection("PlcScanOpts"));
            services.AddPlcServicesForLoading();
            services.AddPlcServicesFor大面贴胶检测();
            services.AddPlcServicesFor极性检测();
            services.AddPlcServicesFor极性检测2();
            return services;
        }

    }
}
