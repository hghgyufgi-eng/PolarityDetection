using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using VisDummy.Shared.Utils;
using VisDummy.WPF.ViewModels.Monitor;

namespace VisDummy.WPF.Views.Monitor
{
    /// <summary>
    /// 极性检测MonitorView.xaml 的交互逻辑
    /// </summary>
    public partial class 极性检测MonitorView : UserControl, IViewFor<极性检测MonitorViewModel>
    {
        public 极性检测MonitorView()
        {
            InitializeComponent();
            this.ViewModel = Locator.Current.GetRequiredService<极性检测MonitorViewModel>();
            this.WhenActivated(d =>
            {
                this.OneWayBind(this.ViewModel, vm => vm.Dev_CmdHeart, v => v.heart.DevMsg).DisposeWith(d);
                this.OneWayBind(this.ViewModel, vm => vm.Mst_CmdHeart, v => v.heart.MstMsg).DisposeWith(d);

                this.OneWayBind(this.ViewModel, vm => vm.DevMsg_2DStation, v => v.station2d.DevMsg).DisposeWith(d);
                this.OneWayBind(this.ViewModel, vm => vm.MstMsg_2DStation, v => v.station2d.MstMsg).DisposeWith(d);

                this.OneWayBind(this.ViewModel, vm => vm.DevMsg_2DStation1, v => v.station2d1.DevMsg).DisposeWith(d);
                this.OneWayBind(this.ViewModel, vm => vm.MstMsg_2DStation1, v => v.station2d1.MstMsg).DisposeWith(d);

                this.OneWayBind(this.ViewModel, vm => vm.DevMsg_2DSpotStation, v => v.station2DSpot.DevMsg).DisposeWith(d);
                this.OneWayBind(this.ViewModel, vm => vm.MstMsg_2DSpotStation, v => v.station2DSpot.MstMsg).DisposeWith(d);
            });
        }

        #region ViewModel --极性检测1
        public 极性检测MonitorViewModel ViewModel
        {
            get { return (极性检测MonitorViewModel)GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }

        object IViewFor.ViewModel { get => this.ViewModel; set => this.ViewModel = (极性检测MonitorViewModel)value; }

        public static readonly DependencyProperty ViewModelProperty =
            DependencyProperty.Register(nameof(ViewModel), typeof(极性检测MonitorViewModel), typeof(极性检测MonitorView), new PropertyMetadata(null));
        #endregion

        
    }
}
