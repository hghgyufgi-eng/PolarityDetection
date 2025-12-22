using System;
using System.Collections.Generic;
using System.Linq;
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
using VisDummy.Protocols.大面贴胶检测.Model;

namespace VisDummy.WPF.Views.Monitor.CommonCtrl.大面贴胶检测
{
    /// <summary>
    /// 大面贴胶检测DevSpotCtrl.xaml 的交互逻辑
    /// </summary>
    public partial class 大面贴胶检测DevSpotCtrl : UserControl
    {
        public 大面贴胶检测DevSpotCtrl()
        {
            InitializeComponent();
        }

        public Dev_CmdSpot DevMsg
        {
            get { return (Dev_CmdSpot)GetValue(DevMsgProperty); }
            set { SetValue(DevMsgProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DevMsg.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DevMsgProperty =
            DependencyProperty.Register("DevMsg", typeof(Dev_CmdSpot), typeof(大面贴胶检测DevSpotCtrl), new PropertyMetadata(null));
    }
}
