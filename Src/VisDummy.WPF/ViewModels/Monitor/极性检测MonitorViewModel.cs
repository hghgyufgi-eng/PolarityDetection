using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;
using VisDummy.Protocols.Common.Model;
using VisDummy.Protocols.极性检测;
using VisDummy.Protocols.极性检测.Model;

namespace VisDummy.WPF.ViewModels.Monitor
{
    public class 极性检测MonitorViewModel : ReactiveObject
    {
        public 极性检测MonitorViewModel()
        {
            ScanContextSubject1.Select(c => c.DevMsg.Heart).ToPropertyEx(this, x => x.Dev_CmdHeart, scheduler: RxApp.MainThreadScheduler);
            ScanContextSubject1.Select(c => c.MstMsg.Heart).ToPropertyEx(this, x => x.Mst_CmdHeart, scheduler: RxApp.MainThreadScheduler);

            ScanContextSubject1.Select(c => c.DevMsg.Station2D).ToPropertyEx(this, x => x.DevMsg_2DStation, scheduler: RxApp.MainThreadScheduler);
            ScanContextSubject1.Select(c => c.MstMsg.Station2D).ToPropertyEx(this, x => x.MstMsg_2DStation, scheduler: RxApp.MainThreadScheduler);

            ScanContextSubject2.Select(c => c.DevMsg.Station2D1).ToPropertyEx(this, x => x.DevMsg_2DStation1, scheduler: RxApp.MainThreadScheduler);
            ScanContextSubject2.Select(c => c.MstMsg.Station2D1).ToPropertyEx(this, x => x.MstMsg_2DStation1, scheduler: RxApp.MainThreadScheduler);

            ScanContextSubject2.Select(c => c.DevMsg.Station2DSpot).ToPropertyEx(this, x => x.DevMsg_2DSpotStation, scheduler: RxApp.MainThreadScheduler);
            ScanContextSubject2.Select(c => c.MstMsg.SpotStation).ToPropertyEx(this, x => x.MstMsg_2DSpotStation, scheduler: RxApp.MainThreadScheduler);
        }

        public Subject<Protocols.极性检测.ScanContext> ScanContextSubject1 { get; } = new Subject<Protocols.极性检测.ScanContext>();
        public Subject<Protocols.极性检测2.ScanContext> ScanContextSubject2 { get; } = new Subject<Protocols.极性检测2.ScanContext>();


        [ObservableAsProperty]
        public Dev_CmdHeart Dev_CmdHeart { get; }

        [ObservableAsProperty]
        public Mst_CmdHeart Mst_CmdHeart { get; }

        [ObservableAsProperty]
        public DevMsg_2DStation DevMsg_2DStation { get; }

        [ObservableAsProperty]
        public MstMsg_2DStation MstMsg_2DStation { get; }

        [ObservableAsProperty]
        public DevMsg_2DStation DevMsg_2DStation1 { get; }

        [ObservableAsProperty]
        public MstMsg_2DStation MstMsg_2DStation1 { get; }
        [ObservableAsProperty]
        public DevMsg_2DSpotStation DevMsg_2DSpotStation { get; }
        [ObservableAsProperty]
        public MstMsg_2DSpotStation MstMsg_2DSpotStation { get; }

    }
}
