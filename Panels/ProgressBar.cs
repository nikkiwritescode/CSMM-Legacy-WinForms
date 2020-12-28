using System;
using System.IO;
using System.Windows.Forms;

namespace CustomStreetManager.Panels
{
    public partial class ProgressBar : Form
    {
        public ProgressBar() => InitializeComponent();
        public void SetProgressBarLabel(string text) => progressLabel.Text = text;
        public void SetButtonToClose() => cancelButton.Text = "Close";
        public void SetButtonToGoBack() => cancelButton.Text = "Go Back";

        public void SetProgressBarValue(int num)
        {
            switch (num)
            {
                case 100:
                    mapReplaceProgressBar.Value = num;
                    break;
                default:
                    mapReplaceProgressBar.Value = num + 1;
                    mapReplaceProgressBar.Value--;
                    break;
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
            switch (cancelButton.Text)
            {
                //I don't want to quit the app if there's an error, but I do want to remove the working directory folder.
                case "Go Back" when !Directory.Exists("..\\_working_directory\\"):
                    return;
                case "Go Back":
                    Directory.Delete("..\\_working_directory\\");
                    break;
                case "Close":
                    Application.Exit();
                    break;
            }
        }
    }
}
