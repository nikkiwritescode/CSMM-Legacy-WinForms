using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CustomStreetManager
{
    public partial class ProgressBar : Form
    {
        public ProgressBar()
        {
            InitializeComponent();
        }

        private void ProgressBar_Load(object sender, EventArgs e)
        {

        }

        public void SetProgressBarLabel(string text)
        {
            progressLabel.Text = text;
        }

        public void SetProgressBarValue(int num)
        {
            if(num != 100)
            {
                mapReplaceProgressBar.Value = num + 1;
                mapReplaceProgressBar.Value--;
            }
            else
            {
                mapReplaceProgressBar.Value = num;
            }
                
            //if (mapReplaceProgressBar.Value > 100)
            //{
            //    mapReplaceProgressBar.Value = 100;
            //}
            //else if (mapReplaceProgressBar.Value < 0)
            //{
            //    mapReplaceProgressBar.Value = 0;
            //}
        }

        public void SetButtonToClose()
        {
            cancelButton.Text = "Close";
        }

        private void progressLabel_Click(object sender, EventArgs e)
        {

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }
    }
}
