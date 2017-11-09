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
using CefSharp;


namespace KoalaDictDemo
{
    /// <summary>
    /// Dictionary.xaml 的交互逻辑
    /// </summary>
    public partial class Dictionary : UserControl
    {
        public Dictionary()
        {
            InitializeComponent();
            ChromiumWeb.MenuHandler = new MenuHandler();
        }

        internal class MenuHandler : IContextMenuHandler
        {


            public void OnBeforeContextMenu(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model)
            {
                //  清除上下文菜单
                model.Clear();
                //  throw new NotImplementedException();
            }


            public bool OnContextMenuCommand(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, CefMenuCommand commandId, CefEventFlags eventFlags)
            {
                //  throw new NotImplementedException();
                return false;
            }


            public void OnContextMenuDismissed(IWebBrowser browserControl, IBrowser browser, IFrame frame)
            {
                //  throw new NotImplementedException();
            }


            public bool RunContextMenu(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model, IRunContextMenuCallback callback)
            {
                return false;
                //  throw new NotImplementedException();
            }
            
        }

        
    }

    
}
