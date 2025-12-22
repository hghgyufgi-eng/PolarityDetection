using MediatR;
using Newtonsoft.Json;
using VisDummy.Protocols.极性检测;
using VisDummy.Protocols.极性检测.Middlewares.Common.PublishNotification;
using VisDummy.Shared.Utils;
using VisDummy.WPF.ViewModels.Monitor;

namespace VisDummy.WPF.Handlers
{
    internal class 极性检测ScanContextNotificationHandler : INotificationHandler<ScanContextNotification>
    {
        private readonly 极性检测MonitorViewModel _极性检测MonitorViewModel;

        public 极性检测ScanContextNotificationHandler()
        {
            _极性检测MonitorViewModel = Locator.Current.GetRequiredService<极性检测MonitorViewModel>();
        }
        public Task Handle(ScanContextNotification notification, CancellationToken cancellationToken)
        {
            var scan = JsonConvert.DeserializeObject<ScanContextNotification>(JsonConvert.SerializeObject(notification));
            var ctx = new ScanContext(null, scan.DevMsg, scan.MstMsg, scan.CreatedAt);
            _极性检测MonitorViewModel.ScanContextSubject.OnNext(ctx);
            return Task.CompletedTask;
        }
    }
}
