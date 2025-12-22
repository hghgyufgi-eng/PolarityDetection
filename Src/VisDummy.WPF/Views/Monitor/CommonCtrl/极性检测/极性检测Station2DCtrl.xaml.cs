using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace VisDummy.WPF.Views.Monitor.CommonCtrl.极性检测
{
    /// <summary>
    /// 极性检测Station2DCtrl.xaml 的交互逻辑
    /// </summary>
    public partial class 极性检测Station2DCtrl : UserControl, INotifyPropertyChanged
    {
        public 极性检测Station2DCtrl()
        {
            InitializeComponent();
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public DevMsg_2DStation DevMsg
        {
            get { return (DevMsg_2DStation)GetValue(DevMsgProperty); }
            set { SetValue(DevMsgProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DevMsg.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DevMsgProperty =
            DependencyProperty.Register("DevMsg", typeof(DevMsg_2DStation), typeof(极性检测Station2DCtrl), new PropertyMetadata(null, DevMsgCallBack));
        protected virtual void NotifyDevPropertyChanged()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Trigger)));
        }
        private static void DevMsgCallBack(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is 极性检测Station2DCtrl ctrl)
            {
                ctrl.NotifyDevPropertyChanged();
            }
        }
        public Dev_CmdTrigger Trigger => DevMsg?.CmdTrigger;

        public MstMsg_2DStation MstMsg
        {
            get { return (MstMsg_2DStation)GetValue(MstMsgProperty); }
            set { SetValue(MstMsgProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MstMsg.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MstMsgProperty =
            DependencyProperty.Register("MstMsg", typeof(MstMsg_2DStation), typeof(极性检测Station2DCtrl), new PropertyMetadata(null, MstMsgCallBack));

        protected virtual void NotifyMstPropertyChanged()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Reply)));
        }
        private static void MstMsgCallBack(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is 极性检测Station2DCtrl ctrl)
            {
                ctrl.NotifyMstPropertyChanged();
            }
        }
        public Mst_CmdReply Reply => MstMsg?.CmdReply;
    }
}
