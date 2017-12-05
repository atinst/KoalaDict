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
using static KoalaDictDemo.MainWindow;

public delegate void Ihide();
public delegate void Ishow();

namespace KoalaDictDemo
{

    /// <summary>
    /// TrayIcon.xaml 的交互逻辑
    /// </summary>
    public partial class TrayIcon : UserControl
    {
        public static Ihide Ihide;
        public static Ishow Ishow;
        public TrayIcon()
        {
            InitializeComponent();
            Ihide = Hide_OnClick;
            Ishow = Show_OnClick;

        }

        private void ShowBtn_OnClick(object sender, RoutedEventArgs e)
        {   
            HBtn();
            

        }

        private void Hide_OnClick()
        {
            ShowBtn.Content = "   隐藏主窗口";
        }

        private void Show_OnClick()
        {
            ShowBtn.Content = "   显示主窗口";
        }



        /// <summary>
        /// 托盘图标退出事件
        /// </summary>
        private void CloseBtn_OnClick(object sender, RoutedEventArgs e)
        {
            CBtn(sender, e);
        }
    }
}


