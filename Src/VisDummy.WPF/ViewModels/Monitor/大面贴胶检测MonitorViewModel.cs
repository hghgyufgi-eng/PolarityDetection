using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;
using VisDummy.Protocols.Common.Model;
using VisDummy.Protocols.大面贴胶检测;
using VisDummy.Protocols.大面贴胶检测.Model;

namespace VisDummy.WPF.ViewModels.Monitor
{
    public class 大面贴胶检测MonitorViewModel : ReactiveObject
    {
        public 大面贴胶检测MonitorViewModel()
        {
            ScanContextSubject.Select(c => c.DevMsg.Heart).ToPropertyEx(this, x => x.Dev_CmdHeart, scheduler: RxApp.MainThreadScheduler);
            ScanContextSubject.Select(c => c.MstMsg.Heart).ToPropertyEx(this, x => x.Mst_CmdHeart, scheduler: RxApp.MainThreadScheduler);

            ScanContextSubject.Select(c => c.DevMsg.Station2D1).ToPropertyEx(this, x => x.DevMsg_2DStation1, scheduler: RxApp.MainThreadScheduler);
            ScanContextSubject.Select(c => c.MstMsg.Station2D1).ToPropertyEx(this, x => x.MstMsg_2DStation1, scheduler: RxApp.MainThreadScheduler);

            ScanContextSubject.Select(c => c.DevMsg.Station2D2).ToPropertyEx(this, x => x.DevMsg_2DStation2, scheduler: RxApp.MainThreadScheduler);
            ScanContextSubject.Select(c => c.MstMsg.Station2D2).ToPropertyEx(this, x => x.MstMsg_2DStation2, scheduler: RxApp.MainThreadScheduler);

            ScanContextSubject.Select(c => c.DevMsg.Station2D3_NGReplace).ToPropertyEx(this, x => x.DevMsg_2DStation3, scheduler: RxApp.MainThreadScheduler);
            ScanContextSubject.Select(c => c.MstMsg.Station2D3_NGReplace).ToPropertyEx(this, x => x.MstMsg_2DStation3, scheduler: RxApp.MainThreadScheduler);

            ScanContextSubject.Select(c => c.DevMsg.Station2DSpot).ToPropertyEx(this, x => x.DevMsg_2DSpotStation, scheduler: RxApp.MainThreadScheduler);
            ScanContextSubject.Select(c => c.MstMsg.Station2DSpot).ToPropertyEx(this, x => x.MstMsg_2DSpotStation, scheduler: RxApp.MainThreadScheduler);

        }

        public Subject<ScanContext> ScanContextSubject { get; } = new Subject<ScanContext>();

        [ObservableAsProperty]
        public Dev_CmdHeart Dev_CmdHeart { get; }

        [ObservableAsProperty]
        public Mst_CmdHeart Mst_CmdHeart { get; }

        [ObservableAsProperty]
        public DevMsg_2DStation DevMsg_2DStation1 { get; }

        [ObservableAsProperty]
        public MstMsg_2DStation MstMsg_2DStation1 { get; }

        [ObservableAsProperty]
        public DevMsg_2DStation DevMsg_2DStation2 { get; }

        [ObservableAsProperty]
        public MstMsg_2DStation MstMsg_2DStation2 { get; }

        [ObservableAsProperty]
        public DevMsg_2DStation DevMsg_2DStation3 { get; }

        [ObservableAsProperty]
        public MstMsg_2DStation MstMsg_2DStation3 { get; }

        [ObservableAsProperty]
        public DevMsg_2DSpotStation DevMsg_2DSpotStation { get; }

        [ObservableAsProperty]
        public MstMsg_2DSpotStation MstMsg_2DSpotStation { get; }

    }
}
