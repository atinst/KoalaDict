using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
using CefSharp;
using Koala.Data.DataFromDB;
using MongoDB.Driver;
using MongoDB.Bson;
using MessageBox = System.Windows.MessageBox;
using Rect = System.Windows.Rect;
using static KoalaDictDemo.TrayIcon;


//using WebBrowser = System.Windows.Forms.WebBrowser;
public delegate void CBtn(object sender, RoutedEventArgs e);
public delegate void HBtn();


namespace KoalaDictDemo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public static CBtn CBtn;
        public static HBtn HBtn;
        private Rect _normal;

        public MainWindow()
        {
            InitializeComponent();
            Dic.ChromiumWeb.Address = @"http://html6test.com/";
            CBtn = CloBtn_OnClick;
            HBtn = HBtn_OnClick;

        }

        private void HBtn_OnClick()
        {
            
            if (Visibility == Visibility.Visible)
            {
                ShowInTaskbar = false;
                Visibility = Visibility.Hidden;
                Ishow();
            }
            else
            {
                ShowInTaskbar = true;
                Visibility = Visibility.Visible;
                Ihide();
            }
            
        }


        private void TitleBar_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }


        private void DicBtn_OnClick(object sender, RoutedEventArgs e)
        {
            
            Dic.Visibility = Visibility.Visible;
            Tra.Visibility = Visibility.Hidden;
            if (Dic.Visibility != Visibility.Visible) return;
            var traBtnStyle = (Style)FindResource("TraBtnStyle");
            var dicBtnStyle = (Style)FindResource("DicBtnStyleDown");
            TraBtn.Style = traBtnStyle;
            DicBtn.Style = dicBtnStyle;
        }

        private void TraBtn_OnClick(object sender, RoutedEventArgs e)
        {
            
            Dic.Visibility = Visibility.Hidden;
            Tra.Visibility = Visibility.Visible;
            if (Tra.Visibility != Visibility.Visible) return;
            var traBtnStyle = (Style)FindResource("TraBtnStyleDown");
            var dicBtnStyle = (Style) FindResource("DicBtnStyle");
            TraBtn.Style = traBtnStyle;
            DicBtn.Style = dicBtnStyle;
        }

        private void MinBtn_OnClick(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
            Topmost = false;
        }

        /// <summary>
        /// 关闭主窗口事件
        /// </summary>
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
            var mongoDb = new MongoDb();
            const string url = "mongodb://114.67.141.164:27017";
            const string databaseName = "admin";
            const string collectionName = "demo";
            const string dataEntity = "SpiderDoc";
            var word = SearchBox.Text;
            mongoDb.ConnectDb(url, databaseName, collectionName, dataEntity);
            mongoDb.GetPendingPageSourceByWord(word);
            string strJson = mongoDb.GetPendingPageSourceByWord(word);
            string htmlPath = Environment.CurrentDirectory + "\\html\\Template.html";
            string targetHtmlPath = Environment.CurrentDirectory + "\\html\\NewTemplate.html";
            string strFlag = "{{ jsn }}";
            Template tmp = new Template(htmlPath, targetHtmlPath, strFlag, strJson);
            tmp.RenderHtml();
            Dic.ChromiumWeb.Address = targetHtmlPath;
           
        }
        
        
    }

   
}
