using ReactiveUI;
using Splat;
using System.Security.Policy;
using TApp.ViewModels.Dbg;
using TApp.ViewModels.ParamsMgmt;
using TApp.ViewModels.Realtime;
using TApp.ViewModels;

namespace TApp.ViewModels
{
    public static class UrlDefines
    {
        public const string URL_Realtime = "URL_Realtime";
        public const string URL_History = "URL_History";
        public const string URL_Simulation = "URL_Simulation";
        public const string URL_BatteryPackStockManangement = "URL_BatteryPackStockManangement";
        public const string URL_UserMgmt = "URL_UserMgmt";
        public const string URL_ParamsMgmt = "URL_ParamsMgmt";
        public const string URL_DebugTools = "URL_DebugTools";

        public static IRoutableViewModel GetRoutableViewModel(string url)
        {
            switch (url)
            {
                case UrlDefines.URL_Realtime:
                    return Locator.Current.GetService<RealtimeViewModel>();

                case UrlDefines.URL_UserMgmt:
                    return Locator.Current.GetService<UserMgmtViewModel>();

                case UrlDefines.URL_ParamsMgmt:
                    return Locator.Current.GetService<ParamsMgmtViewModel>();

                case UrlDefines.URL_DebugTools:
                    return Locator.Current.GetService<DbgToolsViewModel>();

                default:
                    return Locator.Current.GetService<UserMgmtViewModel>();
            }
        }
    }
}
