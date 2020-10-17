using NavegadorWeb.Extra;
using System;
using System.Windows.Forms;

namespace NavegadorWeb.Responsable
{
    public partial class CreateTutorial : Form
    {
        public CreateTutorial()
        {
            InitializeComponent();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void createBtn_Click(object sender, EventArgs e)
        {
            if (nameTxt.Text != string.Empty && descTxt.Text != string.Empty)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
                new PopupNotification("Error", "Complete todos los campos.");
        }
    }
}
