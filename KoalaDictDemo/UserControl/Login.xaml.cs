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
                "Server = 114.67.141.164 ; User Id = root ; Password = 008350Zyx ; DataBase = login_account";

            var conData = new MySqlConnection(conParameter);
            conData.Open();

            const string dbSql =
                "select * from account where user='admin' and password='admin'";

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
                MessageBox.Show("用户名或密码错误");
            }
        }
    }
}

