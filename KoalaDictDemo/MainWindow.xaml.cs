using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using Koala.Data.DataFromDB;
using MongoDB.Driver;
using MongoDB.Bson;


//using WebBrowser = System.Windows.Forms.WebBrowser;

namespace KoalaDictDemo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        
        private Rect _normal;
        public MainWindow()
        {
            InitializeComponent();
            var borderBrowser = new WebBrowserOverlay(BdBrowser);
            var dicWeb = borderBrowser.WebBrowser;
            dicWeb.Navigate("http://www.52yee.com/");
           
        }

        private void TitleBar_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void DicBtn_OnClick(object sender, RoutedEventArgs e)
        {
            BdBrowser.Height = double.NaN;
            BdBrowser.Width = double.NaN;
            Tra.Visibility = Visibility.Hidden;
        }

        private void TraBtn_OnClick(object sender, RoutedEventArgs e)
        {
            BdBrowser.Height = 0;
            BdBrowser.Width = 0;
            Tra.Visibility = Visibility.Visible;
        }

        private void MinBtn_OnClick(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void CloBtn_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MaxBtn_OnClick(object sender, RoutedEventArgs e)
        {

            if (Height != 620)
            {

                BorderThickness = new Thickness(10, 10, 10, 10);
                Left = _normal.Left;
                Top = _normal.Top;
                Width = _normal.Width;
                Height = _normal.Height;
                MaxBtn.Visibility = Visibility.Visible;
                BacBtn.Visibility = Visibility.Collapsed;

            }

            else
            {
                BorderThickness = new Thickness(0, 0, 0, 0);
                MaxBtn.Visibility = Visibility.Collapsed;
                BacBtn.Visibility = Visibility.Visible;
                _normal = new Rect(Left, Top, Width, Height);
                Left = 0;
                Top = 0;
                Rect rc = SystemParameters.WorkArea;
                Width = rc.Width;
                Height = rc.Height;

            }
        }


        private void SearchBox_OnGotFocus(object sender, RoutedEventArgs e)
        {
            var brush = new SolidColorBrush(Colors.Black);
            if (SearchBox.Text != "请输入要查询的单词或词组") return;
            SearchBox.Foreground = brush;
            SearchBox.Text = "";
        }

        private void SearchBox_OnLostFocus(object sender, RoutedEventArgs e)
        {
            var brush = new SolidColorBrush(Colors.Gray);
            if (SearchBox.Text != "") return;
            SearchBox.Foreground = brush;
            SearchBox.Text = "请输入要查询的单词或词组";
        }

        private void LoginBtn_OnClick(object sender, RoutedEventArgs e)
        {
            var login = new Login();
            login.Show();
        }

        private void SearBtn_OnClick(object sender, RoutedEventArgs e)
        {
            //BdBrowser.Height = 0;
            //BdBrowser.Width = 0;
            //var borderBrowser = new WebBrowserOverlay(BdBrowser);
            //var dicWeb = borderBrowser.WebBrowser;
            //dicWeb.Navigate("https://www.baidu.com/");
            //BdBrowser.Height = double.NaN;
            //BdBrowser.Width = double.NaN;
            var mongoDb = new MongoDb();
            const string url = "mongodb://114.67.141.164:27017";
            const string databaseName = "admin";
            const string collectionName = "demo";
            const string dataEntity = "SpiderDoc";
            var word = SearchBox.Text;
            mongoDb.ConnectDb(url, databaseName, collectionName, dataEntity);
            mongoDb.GetPendingPageSourceByWord(word);
        }

        



    }
}
