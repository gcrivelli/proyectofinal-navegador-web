using System;
using System.Windows.Forms;

namespace NavegadorWeb.Responsable
{
    public partial class NavWebResponsable : NavigatorForm
    {
        public NavWebResponsable()
        {
            InitializeComponent();
        }

        private void addStepBntt_Click(object sender, EventArgs e)
        {
            /*string pattern = @"(<(input|button|a) [^>]+ id=.(\w+). [^>]*)";
            string replacement = "$1 style='background-color:red;' onmouseover=\"alert('$3')\"";
            webBrowser.DocumentText = Regex.Replace(webBrowser.DocumentText, pattern, replacement);*/

            HtmlDocument doc = webBrowser.Document;
            HtmlElement head = doc.GetElementsByTagName("head")[0];
            HtmlElement script = doc.CreateElement("script");
            script.SetAttribute("text", "$('head').append('<style>.asistime-border{border:solid;border-color:red;}</style>'); $('div').mouseover(function(e) {$(this).addClass('asistime-border');}); $('div').mouseout(function(e) {$(this).removeClass('asistime-border');});");
            head.AppendChild(script);
        }
    }
}
