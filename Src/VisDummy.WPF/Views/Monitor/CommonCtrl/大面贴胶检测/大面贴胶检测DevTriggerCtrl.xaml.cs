using System.Windows;
using System.Windows.Controls;
using VisDummy.Protocols.大面贴胶检测.Model;

namespace VisDummy.WPF.Views.Monitor.CommonCtrl.大面贴胶检测
{
    /// <summary>
    /// 大面贴胶检测DevTriggerCtrl.xaml 的交互逻辑
    /// </summary>
    public partial class 大面贴胶检测DevTriggerCtrl : UserControl
    {
        public 大面贴胶检测DevTriggerCtrl()
        {
            InitializeComponent();
        }

        public Dev_CmdTrigger DevMsg
        {
            get { return (Dev_CmdTrigger)GetValue(DevMsgProperty); }
            set { SetValue(DevMsgProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DevMsg.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DevMsgProperty =
            DependencyProperty.Register("DevMsg", typeof(Dev_CmdTrigger), typeof(大面贴胶检测DevTriggerCtrl), new PropertyMetadata(null));
    }
}
