using System;
using System.Windows.Forms;

namespace CustomStreetManager.Panels
{
    public partial class AboutPanel : Form
    {
        public AboutPanel() => InitializeComponent();

        private void aboutOKButton_Click(object sender, EventArgs e) => Hide();
    }
}
