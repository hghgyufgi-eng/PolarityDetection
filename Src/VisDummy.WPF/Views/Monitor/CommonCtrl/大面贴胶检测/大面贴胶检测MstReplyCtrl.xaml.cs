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
    /// 大面贴胶检测MstReplyCtrl.xaml 的交互逻辑
    /// </summary>
    public partial class 大面贴胶检测MstReplyCtrl : UserControl
    {
        public 大面贴胶检测MstReplyCtrl()
        {
            InitializeComponent();
        }

        public Mst_CmdReply MstMsg
        {
            get { return (Mst_CmdReply)GetValue(MstMsgProperty); }
            set { SetValue(MstMsgProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MstMsg.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MstMsgProperty =
            DependencyProperty.Register("MstMsg", typeof(Mst_CmdReply), typeof(大面贴胶检测MstReplyCtrl), new PropertyMetadata(null));
    }
}
