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
        public const string AppPrimaryColour = "#14272E";
        //public const string AppSecondaryColour = "#FFD123";
        public const string AppSecondaryColour = "#FFFFFF";

        public const int AppBarHeight = 170;
        public const int AppBarWidth = 1920;

        public const string MenuButtonBackground = "";
        public const string MenuButtonHover = "#2C454E";
        public const string MenuButtonSelected = "#FFFFFF";
        public const int MenuWidth = 400;
        public const int MenuButtonHeight = 80;
        public const string profileMenuButton = "MI PERFIL";
        public const string newToursMenuButton = "TOURS NUEVOS";
        public const string myToursMenuButton = "MIS TOURS";
        public const string backMenuButton = "VOLVER A LA NAVECACIÓN";

        


        public const string TourCardBackground = "#C2C2C2";
        public const string TourCardHover = "";
        public const string TourCardSelected = "";
        public const string TourCardFontColour = "#14272E";
        public const int TourCardHeigth = 300;
        public const int TourCardWidth = 400;

        public const string ContentPanelBackground = "#FFFFFF";


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
        public static string StepPlayImage = path + "StepPlayImage.jpg";
        public static string StepPlayClickImage = path + "StepPlayClickImage.jpg";
        public static string StepForwardImage = path + "StepForwardImage.jpg";
        public static string StepForwardClickImage = path + "StepForwardClickImage.jpg";
        public static string CloseTourImage = path + "CloseTourImage.jpg";

        public static Font ActionbuttonFont = new Font("Segoe UI", 10, FontStyle.Bold);
        public static Font TextBoxFont = new Font("Segoe UI", 8, FontStyle.Regular);
        public const string SearchButtonText = "Ir";
        public const string SeeToursButtonText = "Ver tours disponibles";
        public const string ActionButtonFillColor = "#FFFFFF";
        public const string ActionButtonHoverFillColor = "#2C454E";
        public const int ActionButtonCornerRadius = 20;
        public const int SearchBoxCornerRadius = 10;
        public const int ActionButtonHeight = 55;
        public const int SearchBoxButtonHeight = 48;
        public const string SearchBoxText = "Ingrese aquí la dirección a buscar";

        public static Font ProgressBarFont = new Font("Segoe UI", 15, FontStyle.Bold);
        public static Font H2LabelFont = new Font("Segoe UI", 10, FontStyle.Regular);
        public static Font LogoLabelFont = new Font("Segoe UI", 30, FontStyle.Regular);

        public const string InitiateTourTitle = "Vas a dejar esta pantalla";
        public const string InitiateTourConfirmation1 = "Estás por iniciar el tour ";
        public const string InitiateTourConfirmation2 = ". Vas a ser redirigido a la página incial del tour. ¿Estás seguro?";

    }

}
