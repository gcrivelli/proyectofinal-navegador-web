using NavegadorWeb.Adult;
using NavegadorWeb.Controller;
using NavegadorWeb.Extra;
using NavegadorWeb.Models;
using NavegadorWeb.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace NavegadorWeb.Responsable
{
    public partial class NavigatorAssistant : NavigatorForm
    {
        private AsistimeFormBar formBar;
        private AsistimeIconBar iconBar;
        private AsistimeStepsBar stepsBar;
        private AsistimeTourCreationBar tourBar;
        private TextElement textPopup;
        private static HtmlDocument doc;

        private AsistimeTourCreation createTourView;

        private CreateStep createStepView;
        public int countStep;
        public Tour tour;

        private System.Windows.Forms.ColorDialog colorDialog1;

        //TODO: pasar esto a la barra de creacion de tour
        /*private System.Windows.Forms.Button addStepBntt;
        private System.Windows.Forms.Button endTutorialBtn;
        public System.Windows.Forms.Button addStepBtn;
        public System.Windows.Forms.TextBox countTxt;*/

        public NavigatorAssistant()
        {
            InitializeComponent();
            asistimeAppBar = new AssistantAppBar() { Parent = this };
            iconBar = new AsistimeIconBar() { Parent = this };
            formBar = new AsistimeFormBar() { Parent = this };
            stepsBar = new AsistimeStepsBar() { Parent = this };
            tourBar = new AsistimeTourCreationBar() { Parent = this };
            this.Controls.Add(iconBar);
            this.Controls.Add(formBar);
            this.Controls.Add(stepsBar);
            this.Controls.Add(tourBar);
            iconBar.Hide();
            formBar.Hide();
            stepsBar.Hide();
            tourBar.Hide();
            asistimeAppBar.Width = this.Width;
            this.Controls.Add(asistimeAppBar);
        }

        public void AddTour() {
            //doc = initJsFile();
            initTourCreation();
            createTourView = new AsistimeTourCreation(this);
            createTourView.TopMost = true;
            createTourView.Show();
        }

        public override void ShowMenu() {

            MenuAssistant menu = new MenuAssistant(Constants.tours, this);

            this.Hide();
            menu.Show();
        }

        public void showTourBar()
        {
            asistimeAppBar.Hide();
            tourBar.Show();
        }

        public void showForms()
        {
            tourBar.Hide();
            stepsBar.Show();
        }

        public void RecordAudio()
        {
            formBar.Hide();
            iconBar.Hide();
            createTourView.AdvanceToAudio(tour.name, countStep);
        }

        public void BackToNavigation() { }

        private HtmlDocument initJsFile()
        {
            try
            {
                HtmlDocument doc = webBrowser.Document;
                HtmlElement head = doc.GetElementsByTagName("head")[0];
                HtmlElement script = doc.CreateElement("script");
                HtmlElement style = doc.CreateElement("link");
                style.SetAttribute("rel", "stylesheet");
                style.SetAttribute("href", "https://maxcdn.bootstrapcdn.com/font-awesome/4.5.0/css/font-awesome.min.css");

                //var path = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "/Responsable/CreateCanvas.js";
                //var js = File.ReadAllText(path);
                var js = NavegadorWeb.Properties.Resources.CreateCanvas;
                script.SetAttribute("type", "text/javascript");
                script.InnerText = js;
                head.AppendChild(style);
                head.AppendChild(script);
                doc.InvokeScript("init");

                return doc;
            }
            catch
            {
                throw new Exception("No se pudo crear el documento.");
            }
        }

        public void initStep()
        {
            doc = initJsFile();
            showForms();
        }

        public void cancelTour()
        {
            tourBar.Hide();
            asistimeAppBar.Show();
        }

        private void initTourCreation()
        {
            tour = new Tour()
            {
                steps = new List<Step>(),
                active = true
            };

            countStep = 0;
            tourBar.stepsLabel.Text = "CANTIDAD DE PASOS: " + countStep;

            //countTxt.Text = countStep.ToString();

            /*initStep();

            addStepBntt.Visible = false;
            endTutorialBtn.Visible = true;
            addStepBtn.Visible = true;
            countTxt.Visible = true;*/
        }

        public void setTourName(String name, String desc)
        {
            this.tour.name = name;
            this.tour.description = desc;
        }

        /*private void addStep(object sender, EventArgs e)
        {
            if (webBrowser.ReadyState == WebBrowserReadyState.Complete)
            {
                var model = new CreateTutorial();
                model.ShowDialog();
                if (model.DialogResult == DialogResult.OK)
                {
                    //Init all the tour components
                    tour = new Tour()
                    {
                        steps = new List<Step>(),
                        name = model.nameTxt.Text,
                        description = model.descTxt.Text,
                        active = true
                    };

                    countStep = 0;
                    countTxt.Text = countStep.ToString();

                    initStep();

                    addStepBntt.Visible = false;
                    endTutorialBtn.Visible = true;
                    addStepBtn.Visible = true;
                    countTxt.Visible = true;

                    MessageBox.Show("Comenza la grabación del tutorial", "Comienza el Tutorial", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
                MessageBox.Show("Cargando, espere.");
        }*/

        public void endTutorial()//object sender, EventArgs e)
        {
            // post del tour
            if (countStep == 0)
            {
                new PopupNotification("Error", "Debe agregar al menos un paso.");
            }
            else
            {
                var tourController = new TourController();
                var userController = new UserController();

                //Busco lista de usuarios
                var adults = userController.GetAdults().Result;

                tour.user_id = Constants.user._id;
                var tourResponse = tourController.PostAsync(tour).Result;

                // Asigno a todos los adultos el tour
                /*adults.ForEach(adult =>
                {
                    var a = userController.AsignTourAdult(tourResponse._id, adult._id).Result;
                });*/

                // post de los audios
                var allAudioResponse = true;
                for (int i = 0; i < countStep; i++)
                {
                    var nameTourWithoutSpace = tour.name.Replace(" ", "");
                    var audioName = "/Audio" + nameTourWithoutSpace + i + ".wav";
                    var filename = Constants.audioPath + audioName;
                    if (File.Exists(filename))
                    {
                        allAudioResponse = allAudioResponse && tourController.PostAudio(filename, tourResponse._id, tourResponse.steps[i]._id).Result;
                    }
                }

                /*addStepBntt.Visible = true;
                endTutorialBtn.Visible = false;
                addStepBtn.Visible = false;*/
                //countTxt.Visible = false;
                //createStepView.Close();
                webBrowser.Refresh();

                if (tourResponse._id != null && allAudioResponse)
                    new PopupNotification("Fin del tutorial", "Tutorial Terminado! Se guardaron " + countStep.ToString() + " pasos");
                else
                    new PopupNotification("Error", "Un error ha ocurrido tratando de conectar al servidor.");

                formBar.Hide();
                stepsBar.Hide();
                tourBar.Hide();

                Constants.tours = tourController.GetAllToursAsync().Result;
                asistimeAppBar.Show();
            }
        }

        /*private void addStepBtn_Click(object sender, EventArgs e)
        {
            //initStep();
            //addStepBtn.Enabled = false;
        }*/

        public void addStepToTour()
        {
            //cargar audio --> URL 
            //incrementStepCount();

            var step = new Step()
            {
                order = countStep,
                elements = new List<Element>(),
                url = webBrowser.Url.ToString()
            };

            tour.steps.Add(step);
        }

        public void incrementStepCount()
        {
            countStep++;
            //countTxt.Text = countStep.ToString();
        }

        public void cancelLastStep()
        {
            tour.steps.RemoveAt(countStep);
            countStep--;
        }

        public void BackToTourCreation()
        {
            createTourView.BackToForms();
        }

        public void drawForm(String form){
            formBar.Location = new System.Drawing.Point(asistimeAppBar.Location.X + 30, asistimeAppBar.Location.Y + asistimeAppBar.Height + 30);
            iconBar.Location = new System.Drawing.Point(asistimeAppBar.Location.X + 30, asistimeAppBar.Location.Y + asistimeAppBar.Height + 30);
            //formBar.Show();
            formBar.BringToFront();
            iconBar.BringToFront();
            asistimeAppBar.Hide();
            //stepsBar.Show();

            switch (form)
            {
                case "circulo":
                    iconBar.Hide();
                    formBar.ShowControlsCircle();
                    circle();
                    break;
                case "rectangulo":
                    iconBar.Hide();
                    formBar.ShowControlsRect();
                    rectangle();
                    break;
                case "div":
                    iconBar.Hide();
                    formBar.Hide();
                    div();
                    break;
                case "borrador":
                    iconBar.Hide();
                    formBar.Hide();
                    erase();
                    break;
                case "texto":
                    iconBar.Hide();
                    formBar.Hide();
                    textPopup = new TextElement() { Parent = this};
                    this.Controls.Add(textPopup);
                    textPopup.Location = new System.Drawing.Point(this.Width/2 - textPopup.Width/2, this.Height / 2 - textPopup.Height / 2);
                    textPopup.BringToFront();
                    textPopup.Show();
                    break;
                case "icono":
                    formBar.Hide();
                    iconBar.Show();
                    break;
            }
        }

        public void DrawTextForm(String text)
        {
            textPopup.Hide();
            iconBar.Hide();
            formBar.ShowControlsText();
            //text(); aca hay que dibujar el canvas texto con la variable text
        }

        public void CloseTextPopup()
        {
            textPopup.Hide();
        }

        private void cancel()
        {
            doc.InvokeScript("finishStep");
            webBrowser.Refresh();
            //navWebResponsable.addStepBtn.Enabled = true;
            this.Close();
        }

        private void circle()
        {
            doc.InvokeScript("initCanvas");
            doc.InvokeScript("initCirculo");
        }

        private void rectangle()
        {
            doc.InvokeScript("initCanvas");
            doc.InvokeScript("initCuadrado");
        }

        private void erase()
        {
            /*
             * doc.InvokeScript("initCanvas");
             * doc.InvokeScript("initFlecha");
             */
            /*
             * doc.InvokeScript("initCanvas");
             * doc.InvokeScript("initBan");
             */
            doc.InvokeScript("initBorrar");
        }

        private void text()
        {
            doc.InvokeScript("initCanvas");
            doc.InvokeScript("initTexto");
        }

        private void color(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            String color = (colorDialog1.Color.ToArgb() & 0x00FFFFFF).ToString("X6");
            //colorBtn.BackColor = colorDialog1.Color;
            HtmlElement head = doc.GetElementsByTagName("head")[0];

            HtmlElement script = doc.CreateElement("script");
            script.SetAttribute("type", "text/javascript");
            script.InnerText = "function setColor" + color + "() { setColor('" + color + "'); }";
            head.AppendChild(script);

            doc.InvokeScript("setColor" + color);
        }

        public void ModifyForm(String param)
        {
            switch (param)
            {
                case "agrandarLine":
                    moreLine();
                    break;
                case "achicarLine":
                    lessLine();
                    break;
                case "achicarCanvas":
                    lessCanvas();
                    break;
                case "agrandarCanvas":
                    moreCanvas();
                    break;
                case "agrandarAngulo":
                    moreAngle();
                    break;
                case "achicarAngulo":
                    lessAngle();
                    break;
                case "achicarLetra":
                    lessFontSize();
                    break;
                case "agrandarLetra":
                    moreFontSize();
                    break;
            }
        }

        private void moreLine()
        {
            doc.InvokeScript("agrandarLine");
            doc.InvokeScript("agrandarOpacity");
        }

        private void lessLine()
        {
            doc.InvokeScript("achicarLine");
            doc.InvokeScript("achicarOpacity");
        }

        private void lessCanvas()
        {
            doc.InvokeScript("achicarCanvas");
        }

        private void moreCanvas()
        {
            doc.InvokeScript("agrandarCanvas");
        }

        public void save()
        {
            iconBar.Hide();
            formBar.Hide();

            //Aca va el comportamiento para guardar el paso
            incrementStepCount();
            addStepToTour();
            tourBar.stepsLabel.Text = "CANTIDAD DE PASOS: " + countStep;

            for (int i = 1; i < 20; i++)
            {
                HtmlElement canvas = doc.GetElementById("canvas" + i);
                if (canvas != null)
                {
                    Int16 x = 0;
                    Int16 y = 0;
                    Int16 width = 0;
                    Int16 height = 0;
                    String color = "";
                    Int16 type = 0;
                    Int16 weight = 1;
                    String inclination;
                    String text;

                    color = canvas.GetAttribute("data-color");
                    if (color == null)
                    {
                        color = "000000";
                    }
                    width = Int16.Parse(canvas.OffsetRectangle.Width.ToString());
                    height = Int16.Parse(canvas.OffsetRectangle.Height.ToString());
                    x = Int16.Parse(canvas.OffsetRectangle.X.ToString());
                    y = Int16.Parse(canvas.OffsetRectangle.Y.ToString());
                    type = Int16.Parse(canvas.GetAttribute("data-tipo"));
                    weight = Int16.Parse(canvas.GetAttribute("data-weight"));
                    inclination = canvas.GetAttribute("data-inclinacion");
                    text = canvas.GetAttribute("data-text");

                    addElementToStep(x, y, height, width, color, type, weight, inclination, text);
                }
            }

            HtmlElement div = doc.GetElementById("asistime-div");
            if (div != null)
            {
                Int16 x = 0;
                Int16 y = 0;
                Int16 width = 0;
                Int16 height = 0;
                String opacity = "";
                String color = "";
                Int16 type = 9;

                opacity = div.GetAttribute("data-opacity");
                if (opacity == null)
                {
                    opacity = "0.5";
                }

                color = div.GetAttribute("data-color");
                if (color == null)
                {
                    color = "000000";
                }

                x = Int16.Parse(div.GetAttribute("data-x1"));
                y = Int16.Parse(div.GetAttribute("data-y1"));
                width = Int16.Parse(div.GetAttribute("data-x2"));
                height = Int16.Parse(div.GetAttribute("data-y2"));
                addElementToStep(x, y, height, width, color, type, 0, opacity, "");
            }

            webBrowser.Refresh();
            //navWebResponsable.addStepBtn.Enabled = true;
            doc.InvokeScript("finishStep");
            //this.Close();

            stepsBar.Hide();
            tourBar.Show();
        }

        private void addElementToStep(int x, int y, int height, int width, string color, int type, int weight, string inclination, string text)
        {
            var element = new Element()
            {
                x = x,
                y = y,
                height = height,
                width = width,
                color = color,
                weight = weight,
                type = type,
                inclination = inclination,
                text = text
            };

            tour.steps.Find(
                step => step.order == countStep).elements.Add(element);
        }

        private void div()
        {
            doc.InvokeScript("initDiv");
        }

        private void moreAngle()
        {
            doc.InvokeScript("agrandarAngulo");
        }

        private void lessAngle()
        {
            doc.InvokeScript("achicarAngulo");
        }

        /*private void createDirectory()
        {
            var path = Constants.audioPath;
            try
            {
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
            }
            catch
            {
                new PopupNotification("Error", "Error al crear el directorio para los audios");
            }
        }*/

        private void lessFontSize()
        {
            doc.InvokeScript("achicarLetra");
        }

        private void moreFontSize()
        {
            doc.InvokeScript("agrandarLetra");
        }

        private void lessOpacity()
        {
            doc.InvokeScript("achicarOpacity");
        }

        private void moreOpacity()
        {
            doc.InvokeScript("agrandarOpacity");
        }

        public void cancelStep()
        {
            doc.InvokeScript("finishStep");
            webBrowser.Refresh();
            iconBar.Hide();
            formBar.Hide();
            stepsBar.Hide();
            tourBar.Show();
        }

        public void ModifyColor(String colorHTML)
        {
            HtmlElement head = doc.GetElementsByTagName("head")[0];

            HtmlElement script = doc.CreateElement("script");
            script.SetAttribute("type", "text/javascript");
            script.InnerText = "function modifyColor() { setColor('" + colorHTML + "'); }";
            head.AppendChild(script);

            doc.InvokeScript("modifyColor");
        }

        public void drawIcon(String icon)
        {
            doc.InvokeScript("initCanvas");
            switch (icon)
            {
                case "ban":
                    doc.InvokeScript("initBan");
                    break;
                case "bell":
                    doc.InvokeScript("initBell");
                    break;
                case "check":
                    doc.InvokeScript("initCheck");
                    break;
                case "comment":
                    doc.InvokeScript("initComment");
                    break;
                case "frown":
                    doc.InvokeScript("initFrown");
                    break;
                case "grin-alt":
                    doc.InvokeScript("initGrin");
                    break;
                case "hand-paper":
                    doc.InvokeScript("initHandpaper");
                    break;
                case "hand-point-up":
                    doc.InvokeScript("initHandpoint");
                    break;
                case "shopping-cart":
                    doc.InvokeScript("initShopping");
                    break;
                case "thumbs-up":
                    doc.InvokeScript("initThumbs");
                    break;
            }
        }

    }
}
