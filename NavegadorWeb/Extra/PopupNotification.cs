using NavegadorWeb.UI;
using System.Drawing;
using System.Windows.Forms;
using Tulpep.NotificationWindow;

namespace NavegadorWeb.Extra
{
    public class PopupNotification
    {
        public PopupNotification( string title, string body)
        {
            PopupNotifier popup = new PopupNotifier();
            
            popup.TitleText = title;
            popup.ContentText = body;
            
            popup.TitleFont = new Font("Gadugi", 20, FontStyle.Bold);
            popup.ContentFont = new Font("Gadugi", 13, FontStyle.Bold);
            
            popup.ContentPadding = new Padding(20, 0, 20, 20);
            popup.TitlePadding = new Padding(20, 20, 20, 20);
            
            popup.TitleColor = ColorTranslator.FromHtml(Constants.AppPrimaryColour); 
            popup.BodyColor = ColorTranslator.FromHtml(Constants.MenuButtonSelected);
            popup.ContentColor = ColorTranslator.FromHtml(Constants.AppSecondaryColour);
            popup.BorderColor = Color.Black;
            popup.ButtonBorderColor = ColorTranslator.FromHtml(Constants.MenuButtonSelected);

            popup.ShowCloseButton = true;
            popup.Delay = 5000;
            popup.Size = new Size(300, 180);
            popup.Popup();
        }
    }
}
