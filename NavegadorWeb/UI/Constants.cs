using NavegadorWeb.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace NavegadorWeb.UI
{
    class Constants
    {
        //public const string AppPrimaryColour = "#14272E";
        public const string AppPrimaryColour = "#1B3770";
        //public const string AppSecondaryColour = "#FFFFFF";
        public const string AppSecondaryColour = "#4EB19D";

        public const int AppBarHeight = 150;
        public const int AppBarWidth = 1920;

        public const string MenuButtonBackground = "";
        public const string MenuButtonHover = "#465F95";
        public const string MenuButtonSelected = "#FFFFFF";
        public const int MenuWidth = 400;
        public const int MenuButtonHeight = 80;
        public const string profileMenuButton = "MI PERFIL";
        public const string newToursMenuButton = "TOURS NUEVOS";
        public const string myToursMenuButton = "MIS TOURS";
        public const string backMenuButton = "VOLVER A LA NAVECACIÓN";

        


        public const string TourCardBackground = "#D0D3D9";
        public const string TourCardHover = "";
        public const string TourCardSelected = "";
        public const string TourCardFontColour = "#14272E";
        public const int TourCardHeigth = 300;
        public const int TourCardWidth = 400;

        public const string ContentPanelBackground = "#FFFFFF";

        public static string audioPath = @"c:\Asistime";
        public static string ApiUrl = "https://proyecto-final-navegador-web.herokuapp.com/api/";
        private static string path = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "/Images/";
        public static string NavBackImage = path + "NavBackImage.jpg";
        public static string NavRefreshImage = path + "NavRefreshImage.jpg";
        public static string NavForwardImage = path + "NavForwardImage.jpg";
        public static string NavProfileImage = path + "NavProfileImage.jpg";
        public static string NavBackHoverImage = path + "NavBackHoverImage.jpg";
        public static string NavRefreshHoverImage = path + "NavRefreshHoverImage.jpg";
        public static string NavForwardHoverImage = path + "NavForwardHoverImage.jpg";
        public static string NavProfileHoverImage = path + "NavProfileHoverImage.jpg";
        public static string NavBackClickedImage = path + "NavBackClickedImage.jpg";
        public static string NavRefreshClickedImage = path + "NavRefreshClickedImage.jpg";
        public static string NavForwardClickedImage = path + "NavForwardClickedImage.jpg";
        public static string NavProfileClickedImage = path + "NavProfileClickedImage.jpg";

        public static string StepBackImage = path + "StepBackImage.jpg";
        public static string StepBackClickImage = path + "StepBackClickImage.jpg";
        public static string StepBackHoverImage = path + "StepBackHoverImage.jpg";
        public static string StepPlayImage = path + "StepPlayImage.jpg";
        public static string StepPlayClickImage = path + "StepPlayClickImage.jpg";
        public static string StepPlayHoverImage = path + "StepPlayHoverImage.jpg";
        public static string StepForwardImage = path + "StepForwardImage.jpg";
        public static string StepForwardClickImage = path + "StepForwardClickImage.jpg";
        public static string StepForwardHoverImage = path + "StepForwardHoverImage.jpg";
        public static string CloseTourImage = path + "CloseTourImage.jpg";
        public static string CloseTourHoverImage = path + "CloseTourHoverImage.jpg";
        public static string CloseTourClickImage = path + "CloseTourClickImage.jpg";
        public static string AddTourImage = path + "AddTourImage.jpg";
        public static string AddTourHoverImage = path + "AddTourHoverImage.jpg";
        public static string AddTourClickImage = path + "AddTourClickImage.jpg";
        public static string AsistimeImage = path + "AsistimeImage.jpg";
        public static string AsistimeHoverImage = path + "AsistimeHoverImage.jpg";
        public static string AsistimeClickImage = path + "AsistimeClickImage.jpg";

        public static string CloseImage = path + "CloseImage.jpg";
        public static string CloseHoverImage = path + "CloseHoverImage.jpg";
        public static string CloseClickedImage = path + "CloseClickedImage.jpg";

        public static string RectImage = path + "RectImage.jpg";
        public static string RectHoverImage = path + "RectHoverImage.jpg";
        public static string RectClickImage = path + "RectClickImage.jpg";
        public static string DivImage = path + "DivImage.jpg";
        public static string DivHoverImage = path + "DivHoverImage.jpg";
        public static string DivClickImage = path + "DivClickImage.jpg";
        public static string DialogImage = path + "DialogImage.jpg";
        public static string DialogHoverImage = path + "DialogHoverImage.jpg";
        public static string DialogClickImage = path + "DialogClickImage.jpg";
        public static string TextImage = path + "TextImage.jpg";
        public static string TextHoverImage = path + "TextHoverImage.jpg";
        public static string TextClickImage = path + "TextClickImage.jpg";
        public static string CircleImage = path + "CircleImage.jpg";
        public static string CircleHoverImage = path + "CircleHoverImage.jpg";
        public static string CircleClickImage = path + "CircleClickImage.jpg";
        public static string RectImage2 = path + "RectImage2.jpg";
        public static string RectHoverImage2 = path + "RectHoverImage2.jpg";
        public static string RectClickImage2 = path + "RectClickImage2.jpg";
        public static string DivImage2 = path + "DivImage2.jpg";
        public static string DivHoverImage2 = path + "DivHoverImage2.jpg";
        public static string DivClickImage2 = path + "DivClickImage2.jpg";
        public static string DialogImage2 = path + "DialogImage2.jpg";
        public static string DialogHoverImage2 = path + "DialogHoverImage2.jpg";
        public static string DialogClickImage2 = path + "DialogClickImage2.jpg";
        public static string TextImage2 = path + "TextImage2.jpg";
        public static string TextHoverImage2 = path + "TextHoverImage2.jpg";
        public static string TextClickImage2 = path + "TextClickImage2.jpg";
        public static string CircleImage2 = path + "CircleImage2.jpg";
        public static string CircleHoverImage2 = path + "CircleHoverImage2.jpg";
        public static string CircleClickImage2 = path + "CircleClickImage2.jpg";
        public static string ConfirmImage = path + "ConfirmImage.jpg";
        public static string ConfirmHoverImage = path + "ConfirmHoverImage.jpg";
        public static string ConfirmClickImage = path + "ConfirmClickImage.jpg";

        public static string RecordImage = path + "RecordImage.jpg";
        public static string RecordHoverImage = path + "RecordHoverImage.jpg";
        public static string RecordClickImage = path + "RecordClickImage.jpg";
        public static string StopImage = path + "StopImage.jpg";
        public static string StopHoverImage = path + "StopHoverImage.jpg";
        public static string StopClickImage = path + "StopClickImage.jpg";
        public static string ListenImage = path + "ListenImage.jpg";
        public static string ListenHoverImage = path + "ListenHoverImage.jpg";
        public static string ListenClickImage = path + "ListenClickImage.jpg";
        public static string AddStepImage = path + "AddStepImage.jpg";
        public static string AddStepHoverImage = path + "AddStepHoverImage.jpg";
        public static string AddStepClickImage = path + "AddStepClickImage.jpg";

        public static string AsistimeLogo = path + "logo.png";
        public static string AsistimeIcon = path + "logo.iso";

        public static Font ActionbuttonFont = new Font("Segoe UI", 10, FontStyle.Bold);
        public static Font TextBoxFont = new Font("Segoe UI", 8, FontStyle.Regular);
        public const string SearchButtonText = "Ir";
        public const string SeeToursButtonText = "Ver tours disponibles";
        public const string ActionButtonFillColor = "#4EB19D";
        public const string ActionButtonHoverFillColor = "#465F95";
        public const string ActionButtonForeColor = "#FFFFFF";
        public const int ActionButtonCornerRadius = 20;
        public const int SearchBoxCornerRadius = 10;
        public const int ActionButtonHeight = 55;
        public const int SearchBoxButtonHeight = 48;
        public const string SearchBoxText = "Ingrese aquí la dirección a buscar";

        public static Font ProgressBarFont = new Font("Segoe UI", 15, FontStyle.Bold);
        public static Font HLabelFont = new Font("Segoe UI", 14, FontStyle.Bold);
        public static Font H1LabelFont = new Font("Segoe UI", 12, FontStyle.Bold);
        public static Font H2LabelFont = new Font("Segoe UI", 10, FontStyle.Bold);

        public const string InitiateTourTitle = "Vas a dejar esta pantalla";
        public const string InitiateTourConfirmation1 = "Estás por iniciar el tour ";
        public const string InitiateTourConfirmation2 = ". Vas a ser redirigido a la página incial del tour. ¿Estás seguro?";

        public static Color ConfirmationMessageBackColor = Color.Green;
        public static Color WarningMessageBackColor = Color.Yellow;
        public static Color ErrorMessageBackColor = Color.Red;
        public static Color ConfirmationMessageForeColor = Color.White;
        public static Color WarningMessageForeColor = Color.Black;
        public static Color ErrorMessageForeColor = Color.Yellow;

        public static String token;
        public static User user;
        public static List<Tour> tours;
    }

}
