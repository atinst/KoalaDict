using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Newtonsoft.Json;

namespace KoalaDictDemo
{
    /// <summary>
    /// Translate.xaml 的交互逻辑
    /// </summary>
    public partial class Translate : UserControl
    {
        public string Selected = "";
        public string Out = "";
        public Translate()
        {
            InitializeComponent();
            var country = new List<string> { "中文", "日文", "英文", "韩文", "法文", "俄文", "葡萄牙文", "西班牙文" };
            LanguageSelected.ItemsSource = country;
            LanguageOut.ItemsSource = country;


        }

        public void _Translate()
        {
            var i = InBox.Text;
            const string appKey = "76f727cb09492e92";
            var from = Selected;
            var to = Out;
            var salt = DateTime.Now.Millisecond.ToString();
            const string appSecret = "3Chbu5plRETDsjHfMZgbXIuiY2CCgp90";
            MD5 md5 = new MD5CryptoServiceProvider();
            var md5Str = appKey + i + salt + appSecret;
            var output = md5.ComputeHash(Encoding.UTF8.GetBytes(md5Str));
            var sign = BitConverter.ToString(output).Replace("-", "");
            var url =
                $"http://openapi.youdao.com/api?appKey={appKey}&q={System.Web.HttpUtility.UrlDecode(i, Encoding.GetEncoding("UTF-8"))}&from={from}&to={to}&sign={sign}&salt={salt}";
            var translationWebRequest = WebRequest.Create(url);
            var response = translationWebRequest.GetResponse();
            var stream = response.GetResponseStream();
            var encode = Encoding.GetEncoding("utf-8");
            if (stream == null) return;
            var reader = new StreamReader(stream, encode);
            var results = reader.ReadToEnd();
            var type = new { translation = new string[0] };
            var reType = JsonConvert.DeserializeAnonymousType(results, type);
            var temp = reType.translation[0];
            OutBox.Text = temp;
            var brush = new SolidColorBrush(Colors.Black);
            OutBox.Foreground = brush;

        }
        private void TransBtn_OnClick(object sender, RoutedEventArgs e)
        {
            if (LanguageSelected.SelectedItem == null || LanguageOut.SelectedItem == null || InBox.Text == "请输入要翻译的内容") return;


            switch (LanguageSelected.SelectedItem.ToString())
            {
                case "中文":
                    Selected = "zh-CHS";
                    break;

                case "日文":
                    Selected = "ja";
                    break;

                case "英文":
                    Selected = "EN";
                    break;

                case "韩文":
                    Selected = "ko";
                    break;

                case "法文":
                    Selected = "fr";
                    break;

                case "俄文":
                    Selected = "ru";
                    break;

                case "葡萄牙文":
                    Selected = "pt";
                    break;

                case "西班牙文":
                    Selected = "es";
                    break;
            }

            switch (LanguageOut.SelectedItem.ToString())
            {
                case "中文":
                    Out = "zh-CHS";
                    break;

                case "日文":
                    Out = "ja";
                    break;

                case "英文":
                    Out = "EN";
                    break;

                case "韩文":
                    Out = "ko";
                    break;

                case "法文":
                    Out = "fr";
                    break;

                case "俄文":
                    Out = "ru";
                    break;

                case "葡萄牙文":
                    Out = "pt";
                    break;

                case "西班牙文":
                    Out = "es";
                    break;
            }
            _Translate();
        }

        private void InBox_OnGotFocus(object sender, RoutedEventArgs e)
        {
            var brush = new SolidColorBrush(Colors.Black);
            if (InBox.Text != "请输入要翻译的内容") return;
            InBox.Foreground = brush;
            InBox.Text = "";
        }

        private void InBox_OnLostFocus(object sender, RoutedEventArgs e)
        {
            var brush = new SolidColorBrush(Colors.Gray);
            if (InBox.Text != "") return;
            InBox.Foreground = brush;
            InBox.Text = "请输入要翻译的内容";
        }

        private void TransformBtn_OnClick(object sender, RoutedEventArgs e)
        {
            if (LanguageSelected.SelectedItem == null || LanguageOut.SelectedItem == null)return;
            var languageSelected = LanguageSelected.SelectedItem.ToString();
            var languageOut = LanguageOut.SelectedItem.ToString();
            LanguageSelected.Text = languageOut;
            LanguageOut.Text = languageSelected;
        }


        private void EmptyBtn_OnClick(object sender, RoutedEventArgs e)
        {
            var brush = new SolidColorBrush(Colors.Gray);
            InBox.Foreground = brush;
            InBox.Text = "请输入要翻译的内容";
        }
    }
}
