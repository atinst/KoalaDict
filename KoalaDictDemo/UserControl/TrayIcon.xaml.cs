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

namespace KoalaDictDemo
{
    /// <summary>
    /// TrayIcon.xaml 的交互逻辑
    /// </summary>
    public partial class TrayIcon : UserControl
    {
        public TrayIcon()
        {
            InitializeComponent();
        }

        private void ShowBtn_OnClick(object sender, RoutedEventArgs e)
        {
            var manwindow = new MainWindow();
            manwindow.Show();
        }


        private void CloseBtn_OnClick(object sender, RoutedEventArgs e)
        {
            var manwindow = new MainWindow();
            manwindow.Close();
        }
    }
}
