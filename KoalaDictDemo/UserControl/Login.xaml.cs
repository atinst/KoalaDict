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
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace KoalaDictDemo
{
    /// <summary>
    /// Login.xaml 的交互逻辑
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void LoginBtn_OnClick(object sender, RoutedEventArgs e)
        {

            const string conParameter =
                "Server = 114.67.141.164; User Id = root; Password = qaz123@; Port = 443; DataBase = login_account;";

            var conData = new MySqlConnection(conParameter);
            conData.Open();

            var dbSql =
                $@"select * from account where user='{UserBox.Text}' and password='{PassBox.Password}'";

            var cmd = new MySqlCommand(dbSql, conData);
            var obj = cmd.ExecuteScalar();
            if (obj != null)
            {
                MessageBox.Show("欢迎使用考拉翻译俄语词典");
                var manwindow = new MainWindow();
                manwindow.Show();
                Close();
            }
            else
            {
                MessageBox.Show("账号或密码不正确");
            }
        }

        private void TitleBar_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void CloBtn_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void PassBox_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter) return;

            const string conParameter =
                "Server = 114.67.141.164; User Id = root; Password = qaz123@; Port = 443; DataBase = login_account;";

            var conData = new MySqlConnection(conParameter);
            conData.Open();

            var dbSql =
                $@"select * from account where user='{UserBox.Text}' and password='{PassBox.Password}'";

            var cmd = new MySqlCommand(dbSql, conData);
            var obj = cmd.ExecuteScalar();
            if (obj != null)
            {
                MessageBox.Show("欢迎使用考拉翻译俄语词典");
                var manwindow = new MainWindow();
                manwindow.Show();
                Close();
            }
            else
            {
                MessageBox.Show("账号或密码不正确");
            }
        }
    }
}

