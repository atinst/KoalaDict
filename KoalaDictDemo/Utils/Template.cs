using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

class Template
{

    public string HtmlPath { get; set; }
    public string TargetHtmlPath { get; set; }
    public string FlagStr { get; set; }
    public string JsonStr { get; set; }

    public Template(string htmlPath, string targetHtmlPath, string flagStr, string jsonStr)
    {
        HtmlPath = htmlPath;
        TargetHtmlPath = targetHtmlPath;
        FlagStr = flagStr;
        JsonStr = jsonStr;
    }

    /// <summary>
    /// 通过模板生成新的html页面
    /// </summary>
    public void RenderHtml()
    {

        using (StreamReader srReader = new StreamReader(HtmlPath, Encoding.UTF8))
        {
            string textHtml = srReader.ReadToEnd();

            string newTextHtml = textHtml.Replace(FlagStr, JsonStr);

            using (FileStream fs = new FileStream(TargetHtmlPath, FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.Write(newTextHtml);
                }
            }
        }
    }
}

