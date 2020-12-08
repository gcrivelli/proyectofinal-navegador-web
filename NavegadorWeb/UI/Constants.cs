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
        public const string AppMenuBackgroundColour = "#EBEBEB";

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
        public const string myAdultsButton = "MIS ADULTOS";
        public const string backMenuButton = "VOLVER A LA NAVECACIÓN";

        //public const string TourCardBackground = "#DCDEE2";
        public const string TourCardBackground = "#FFFFFF";

        public const string TourCardHover = "#D0D3D9";
        public const string TourCardNew = "#A3CEC6";
        public const string TourCardFontColour = "#14272E";
        public const int TourCardHeigth = 300;
        public const int TourCardWidth = 400;

        public const string ContentPanelBackground = "#FFFFFF";

        public static string audioPath = @"c:\Asistime";
        public static string ApiUrl = "https://proyecto-final-navegador-web.herokuapp.com/api/";
        //private static string path = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "/Images/";
        public static Image NavBackImage = NavegadorWeb.Properties.Resources.NavBackImage;
        public static Image NavRefreshImage = NavegadorWeb.Properties.Resources.NavRefreshImage;
        public static Image NavForwardImage = NavegadorWeb.Properties.Resources.NavForwardImage;
        public static Image NavProfileImage = NavegadorWeb.Properties.Resources.NavProfileImage;
        public static Image NavBackHoverImage = NavegadorWeb.Properties.Resources.NavBackHoverImage;
        public static Image NavRefreshHoverImage = NavegadorWeb.Properties.Resources.NavRefreshHoverImage;
        public static Image NavForwardHoverImage = NavegadorWeb.Properties.Resources.NavForwardHoverImage;
        public static Image NavProfileHoverImage = NavegadorWeb.Properties.Resources.NavProfileHoverImage;
        public static Image NavBackClickedImage = NavegadorWeb.Properties.Resources.NavBackClickedImage;
        public static Image NavRefreshClickedImage = NavegadorWeb.Properties.Resources.NavRefreshClickedImage;
        public static Image NavForwardClickedImage = NavegadorWeb.Properties.Resources.NavForwardClickedImage;
        public static Image NavProfileClickedImage = NavegadorWeb.Properties.Resources.NavProfileClickedImage;

        public static Image StepBackImage = NavegadorWeb.Properties.Resources.StepBackImage;
        public static Image StepBackClickImage = NavegadorWeb.Properties.Resources.StepBackClickImage;
        public static Image StepBackHoverImage = NavegadorWeb.Properties.Resources.StepBackHoverImage;
        public static Image StepPlayImage = NavegadorWeb.Properties.Resources.StepPlayImage;
        public static Image StepPlayClickImage = NavegadorWeb.Properties.Resources.StepPlayClickimage;
        public static Image StepPlayHoverImage = NavegadorWeb.Properties.Resources.StepPlayHoverImage;
        public static Image StepForwardImage = NavegadorWeb.Properties.Resources.StepForwardImage;
        public static Image StepForwardClickImage = NavegadorWeb.Properties.Resources.StepForwardClickImage;
        public static Image StepForwardHoverImage = NavegadorWeb.Properties.Resources.StepForwardHoverImage;
        public static Image CloseTourImage = NavegadorWeb.Properties.Resources.CloseTourImage;
        public static Image CloseTourHoverImage = NavegadorWeb.Properties.Resources.CloseTourHoverImage;
        public static Image CloseTourClickImage = NavegadorWeb.Properties.Resources.CloseTourClickImage;
        public static Image AddTourImage = NavegadorWeb.Properties.Resources.AddTourImage;
        public static Image AddTourHoverImage = NavegadorWeb.Properties.Resources.AddTourHoverImage;
        public static Image AddTourClickImage = NavegadorWeb.Properties.Resources.AddTourClickImage;
        public static Image AsistimeImage = NavegadorWeb.Properties.Resources.AsistimeImage;
        public static Image AsistimeHoverImage = NavegadorWeb.Properties.Resources.AsistimeHoverImage;
        public static Image AsistimeClickImage = NavegadorWeb.Properties.Resources.AsistimeClickImage;

        public static Image CloseImage = NavegadorWeb.Properties.Resources.CloseImage;
        public static Image CloseHoverImage = NavegadorWeb.Properties.Resources.CloseHoverImage;
        public static Image CloseClickedImage = NavegadorWeb.Properties.Resources.CloseClickedImage;
        public static Image DestroyImage = NavegadorWeb.Properties.Resources.DestroyImage;
        public static Image DestroyHoverImage = NavegadorWeb.Properties.Resources.DestroyHoverImage;
        public static Image DestroyClickedImage = NavegadorWeb.Properties.Resources.DestroyClickedImage;

        //Imágenes de formas sobre fondo azul
        public static Image DivImage2 = NavegadorWeb.Properties.Resources.DivImage2;
        public static Image DivHoverImage2 = NavegadorWeb.Properties.Resources.DivHoverImage2;
        public static Image DivClickImage2 = NavegadorWeb.Properties.Resources.DivClickImage2;
        public static Image DialogImage2 = NavegadorWeb.Properties.Resources.DialogImage2;
        public static Image DialogHoverImage2 = NavegadorWeb.Properties.Resources.DialogHoverImage2;
        public static Image DialogClickImage2 = NavegadorWeb.Properties.Resources.DialogClickImage2;
        public static Image TextImage2 = NavegadorWeb.Properties.Resources.TextImage2;
        public static Image TextHoverImage2 = NavegadorWeb.Properties.Resources.TextHoverImage2;
        public static Image TextClickImage2 = NavegadorWeb.Properties.Resources.TextClickImage2;
        public static Image CircleImage2 = NavegadorWeb.Properties.Resources.CircleImage2;
        public static Image CircleHoverImage2 = NavegadorWeb.Properties.Resources.CircleHoverImage2;
        public static Image CircleClickImage2 = NavegadorWeb.Properties.Resources.CircleClickImage2;
        public static Image ConfirmImage = NavegadorWeb.Properties.Resources.ConfirmImage;
        public static Image ConfirmHoverImage = NavegadorWeb.Properties.Resources.ConfirmHoverImage;
        public static Image ConfirmClickImage = NavegadorWeb.Properties.Resources.ConfirmClickImage;
        public static Image AudioImage = NavegadorWeb.Properties.Resources.AudioImage;
        public static Image AudioHoverImage = NavegadorWeb.Properties.Resources.AudioHoverImage;
        public static Image AudioClickImage = NavegadorWeb.Properties.Resources.AudioClickImage;
        public static Image EraseImage = NavegadorWeb.Properties.Resources.EraseImage;
        public static Image EraseHoverImage = NavegadorWeb.Properties.Resources.EraseHoverImage;
        public static Image EraseClickImage = NavegadorWeb.Properties.Resources.EraseClickImage;
        public static Image RectImage2 = NavegadorWeb.Properties.Resources.RectImage2;
        public static Image RectHoverImage2 = NavegadorWeb.Properties.Resources.RectHoverImage2;
        public static Image RectClickImage2 = NavegadorWeb.Properties.Resources.RectClickImage2;
        public static Image IconImage = NavegadorWeb.Properties.Resources.IconImage;
        public static Image IconHoverImage = NavegadorWeb.Properties.Resources.IconHoverImage;
        public static Image IconClickImage = NavegadorWeb.Properties.Resources.IconClickImage;

        //Imágenes de formas sobre fondo blanco
        public static Image RectImage = NavegadorWeb.Properties.Resources.RectImage;
        public static Image RectHoverImage = NavegadorWeb.Properties.Resources.RectHoverImage;
        public static Image RectClickImage = NavegadorWeb.Properties.Resources.RectClickImage;
        public static Image DivImage = NavegadorWeb.Properties.Resources.DivImage;
        public static Image DivHoverImage = NavegadorWeb.Properties.Resources.DivHoverImage;
        public static Image DivClickImage = NavegadorWeb.Properties.Resources.DivClickImage;
        public static Image DialogImage = NavegadorWeb.Properties.Resources.DialogImage;
        public static Image DialogHoverImage = NavegadorWeb.Properties.Resources.DialogHoverImage;
        public static Image DialogClickImage = NavegadorWeb.Properties.Resources.DialogClickImage;
        public static Image TextImage = NavegadorWeb.Properties.Resources.TextImage;
        public static Image TextHoverImage = NavegadorWeb.Properties.Resources.TextHoverImage;
        public static Image TextClickImage = NavegadorWeb.Properties.Resources.TextClickImage;
        public static Image CircleImage = NavegadorWeb.Properties.Resources.CircleImage;
        public static Image CircleHoverImage = NavegadorWeb.Properties.Resources.CircleHoverImage;
        public static Image CircleClickImage = NavegadorWeb.Properties.Resources.CircleClickImage;

        //Imágenes de flow sobre fondo gris
        public static Image PreviousImageG = NavegadorWeb.Properties.Resources.PreviousImageG;
        public static Image PreviousHoverImageG = NavegadorWeb.Properties.Resources.PreviousHoverImageG;
        public static Image PreviousClickImageG = NavegadorWeb.Properties.Resources.PreviousClickImageG;
        public static Image AsistimeImageG = NavegadorWeb.Properties.Resources.AsistimeImageG;
        public static Image AsistimeHoverImageG = NavegadorWeb.Properties.Resources.AsistimeHoverImageG;
        public static Image AsistimeClickImageG = NavegadorWeb.Properties.Resources.AsistimeClickImageG;


        //Imagenes de flow sobre fondo azul
        public static Image ConfirmGreenImageB = NavegadorWeb.Properties.Resources.ConfirmGreenImageB;
        public static Image ConfirmGreenHoverImageB = NavegadorWeb.Properties.Resources.ConfirmGreenHoverImageB;
        public static Image ConfirmGreenClickImageB = NavegadorWeb.Properties.Resources.ConfirmGreenClickImageB;
        public static Image CancelRedImageB = NavegadorWeb.Properties.Resources.CancelRedImageB;
        public static Image CancelRedHoverImageB = NavegadorWeb.Properties.Resources.CancelRedHoverImageB;
        public static Image CancelRedClickImageB = NavegadorWeb.Properties.Resources.CancelRedClickImageB;

        //Imagenes de flow sobre fondo blanco
        public static Image ConfirmGreenImageW = NavegadorWeb.Properties.Resources.ConfirmGreenImageW;
        public static Image ConfirmGreenHoverImageW = NavegadorWeb.Properties.Resources.ConfirmGreenHoverImageW;
        public static Image ConfirmGreenClickImageW = NavegadorWeb.Properties.Resources.ConfirmGreenClickImageW;
        public static Image CancelRedImageW = NavegadorWeb.Properties.Resources.CancelRedImageW;
        public static Image CancelRedHoverImageW = NavegadorWeb.Properties.Resources.CancelRedHoverImageW;
        public static Image CancelRedClickImageW = NavegadorWeb.Properties.Resources.CancelRedClickImageW;

        public static Image NextImage = NavegadorWeb.Properties.Resources.NextImage;
        public static Image NextHoverImage = NavegadorWeb.Properties.Resources.NextHoverImage;
        public static Image NextClickImage = NavegadorWeb.Properties.Resources.NextClickImage;
        public static Image PreviousImage = NavegadorWeb.Properties.Resources.PreviousImage;
        public static Image PreviousHoverImage = NavegadorWeb.Properties.Resources.PreviousHoverImage;
        public static Image PreviousClickImage = NavegadorWeb.Properties.Resources.PreviousClickImage;
        

        public static Image RecordImage = NavegadorWeb.Properties.Resources.RecordImage;
        public static Image RecordHoverImage = NavegadorWeb.Properties.Resources.RecordHoverImage;
        public static Image RecordClickImage = NavegadorWeb.Properties.Resources.RecordClickImage;
        public static Image StopImage = NavegadorWeb.Properties.Resources.StopImage;
        public static Image StopHoverImage = NavegadorWeb.Properties.Resources.StopHoverImage;
        public static Image StopClickImage = NavegadorWeb.Properties.Resources.StopClickImage;
        public static Image ListenImage = NavegadorWeb.Properties.Resources.Listenimage;
        public static Image ListenHoverImage = NavegadorWeb.Properties.Resources.ListenHoverImage;
        public static Image ListenClickImage = NavegadorWeb.Properties.Resources.ListenClickImage;
        public static Image AddStepImage = NavegadorWeb.Properties.Resources.AddStepImage;
        public static Image AddStepHoverImage = NavegadorWeb.Properties.Resources.AddStepHoverImage;
        public static Image AddStepClickImage = NavegadorWeb.Properties.Resources.AddStepClickImage;

        //Imágenes de modificación de formas
        public static Image UpImage = NavegadorWeb.Properties.Resources.Up;
        public static Image UpHoverImage = NavegadorWeb.Properties.Resources.UpHover;
        public static Image DownImage = NavegadorWeb.Properties.Resources.Down;
        public static Image DownHoverImage = NavegadorWeb.Properties.Resources.DownHover;
        public static Image PlusImage = NavegadorWeb.Properties.Resources.Plus;
        public static Image PlusHoverImage = NavegadorWeb.Properties.Resources.PlusHover;
        public static Image MinusImage = NavegadorWeb.Properties.Resources.Minus;
        public static Image MinusHoverImage = NavegadorWeb.Properties.Resources.MinusHover;
        public static Image TurnRightImage = NavegadorWeb.Properties.Resources.TurnRight;
        public static Image TurnRightHoverImage = NavegadorWeb.Properties.Resources.TurnRightHover;
        public static Image TurnLeftImage = NavegadorWeb.Properties.Resources.TurnLeft;
        public static Image TurnLeftHoverImage = NavegadorWeb.Properties.Resources.TurnLeftHover;
        public static Image FontUpImage = NavegadorWeb.Properties.Resources.FontUp;
        public static Image FontUpHoverImage = NavegadorWeb.Properties.Resources.FontUpHover;
        public static Image FontDownImage = NavegadorWeb.Properties.Resources.FontDown;
        public static Image FontDownHoverImage = NavegadorWeb.Properties.Resources.FontDownHover;
        public static Image BlueImage = NavegadorWeb.Properties.Resources.BlueImage;
        public static Image YellowImage = NavegadorWeb.Properties.Resources.YellowImage;
        public static Image RedImage = NavegadorWeb.Properties.Resources.RedImage;
        public static Image GreenImage = NavegadorWeb.Properties.Resources.GreenImage;
        public static Image OrangeImage = NavegadorWeb.Properties.Resources.OrangeImage;
        public static Image VioletImage = NavegadorWeb.Properties.Resources.VioletImage;
        public static Image BlackImage = NavegadorWeb.Properties.Resources.BlackImage;

        //Imágenes de font awesome
        public static Image Ban = NavegadorWeb.Properties.Resources.Ban;
        public static Image Bell = NavegadorWeb.Properties.Resources.Bell;
        public static Image Check = NavegadorWeb.Properties.Resources.Check;
        public static Image Comment = NavegadorWeb.Properties.Resources.Comment;
        public static Image Frown = NavegadorWeb.Properties.Resources.Frown;
        public static Image GrinAlt = NavegadorWeb.Properties.Resources.GrinAlt;
        public static Image HandPaper = NavegadorWeb.Properties.Resources.HandPaper;
        public static Image HandPointUp = NavegadorWeb.Properties.Resources.HandPointUp;
        public static Image ShoePrints = NavegadorWeb.Properties.Resources.ShoePrints;
        public static Image ShoppingCart = NavegadorWeb.Properties.Resources.ShoppingCart;
        public static Image ThumbsUp = NavegadorWeb.Properties.Resources.ThumbsUp;
        public static Image BanHover = NavegadorWeb.Properties.Resources.BanHover;
        public static Image BellHover = NavegadorWeb.Properties.Resources.BellHover;
        public static Image CheckHover = NavegadorWeb.Properties.Resources.CheckHover;
        public static Image CommentHover = NavegadorWeb.Properties.Resources.CommentHover;
        public static Image FrownHover = NavegadorWeb.Properties.Resources.FrownHover;
        public static Image GrinAltHover = NavegadorWeb.Properties.Resources.GrinAltHover;
        public static Image HandPaperHover = NavegadorWeb.Properties.Resources.HandPaperHover;
        public static Image HandPointUpHover = NavegadorWeb.Properties.Resources.HandPointUpHover;
        public static Image ShoePrintsHover = NavegadorWeb.Properties.Resources.ShoePrintsHover;
        public static Image ShoppingCartHover = NavegadorWeb.Properties.Resources.ShoppingCartHover;
        public static Image ThumbsUpHover = NavegadorWeb.Properties.Resources.ThumbsUpHover;

        public static Image AsistimeLogo = NavegadorWeb.Properties.Resources.logo;
        public static Image AsistimeLogo291x99 = NavegadorWeb.Properties.Resources.logo291x99;
        public static Image AsistimeIcon = NavegadorWeb.Properties.Resources.logo;
        public static Image NewImage = NavegadorWeb.Properties.Resources._new;

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
        public static Font MenuHeaderFont = new Font("Segoe UI", 20, FontStyle.Bold);
        public static Font HLabelFont = new Font("Segoe UI", 14, FontStyle.Bold);
        public static Font H1LabelFont = new Font("Segoe UI", 12, FontStyle.Bold);
        public static Font H2LabelFont = new Font("Segoe UI", 10, FontStyle.Bold);

        public const string InitiateTourTitle = "Vas a dejar esta pantalla";
        public const string InitiateTourConfirmation1 = "Estás por iniciar el tour ";
        public const string InitiateTourConfirmation2 = ". Vas a ser redirigido a la página incial del tour. ¿Estás seguro?";

        public const string DeleteTourTitle = "Vas a borrar el tour";
        public const string DeleteTourConfirmation1 = "Estás por borrar el tour ";
        public const string DeleteTourConfirmation2 = ". ¿Estás seguro?";

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
