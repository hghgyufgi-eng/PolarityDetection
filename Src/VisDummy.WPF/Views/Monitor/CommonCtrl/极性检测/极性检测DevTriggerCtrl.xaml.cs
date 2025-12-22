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
using VisDummy.Protocols.极性检测.Model;
using VisDummy.WPF.Views.Monitor.CommonCtrl.大面贴胶检测;

namespace VisDummy.WPF.Views.Monitor.CommonCtrl.极性检测
{
    /// <summary>
    /// 极性检测DevTriggerCtrl.xaml 的交互逻辑
    /// </summary>
    public partial class 极性检测DevTriggerCtrl : UserControl
    {
        public 极性检测DevTriggerCtrl()
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
            DependencyProperty.Register("DevMsg", typeof(Dev_CmdTrigger), typeof(极性检测DevTriggerCtrl), new PropertyMetadata(null));
    }
}
