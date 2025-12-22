using MediatR;
using Splat;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VisDummy.MKVMs.Messages;
using VisDummy.MKVMs.ViewModels;

namespace VisDummy.MKVMs.MessageHandles
{
    public class Vision3DNotificationHandle : INotificationHandler<Vision3DNotification>
    {
        public Vision3DNotificationHandle()
        {
        }
        public Task Handle(Vision3DNotification notification, CancellationToken cancellationToken)
        {
            var rts = Locator.Current.GetServices<Vis3DRtViewModel>();
            if (notification.Message != null)
            {
                var rt = rts.First(s => s.ViewName == notification.ProcName);
                rt.OnNext(notification.Message);
            }
            return Task.CompletedTask;
        }
    }
}
