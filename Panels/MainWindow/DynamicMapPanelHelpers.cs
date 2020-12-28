namespace CustomStreetManager.Panels.MainWindow
{
    public class DynamicMapPanelHelpers
    {
        private MainWindow _mainWindow;

        public DynamicMapPanelHelpers(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
        }

        public void ClearDynamicMapLabels()
        {
            _mainWindow.dynMapLabel1.Text = "";
            _mainWindow.dynMap2Label.Text = "";
            _mainWindow.dynMap3Label.Text = "";
            _mainWindow.dynMap4Label.Text = "";
        }

        public void ConfigureDynamicPanelForFourSelectedMaps()
        {
            _mainWindow.dynamicMapPanel.Visible = true;
            _mainWindow.dynMapLabel1.Visible = true;
            _mainWindow.dynMap2Label.Visible = true;
            _mainWindow.dynMap3Label.Visible = true;
            _mainWindow.dynMap4Label.Visible = true;
            _mainWindow.map1OrderDropdown.Visible = true;
            _mainWindow.map2OrderDropdown.Visible = true;
            _mainWindow.map3OrderDropdown.Visible = true;
            _mainWindow.map4OrderDropdown.Visible = true;

            _mainWindow.mtmagButton.Enabled = false;
            _mainWindow.colossusButton.Enabled = false;

            _mainWindow.map1OrderDropdown.SelectedItem = null;
            _mainWindow.map2OrderDropdown.SelectedItem = null;
            _mainWindow.map3OrderDropdown.SelectedItem = null;
            _mainWindow.map4OrderDropdown.SelectedItem = null;

            _mainWindow.map1OrderDropdown.Items.Clear();
            _mainWindow.map2OrderDropdown.Items.Clear();
            _mainWindow.map3OrderDropdown.Items.Clear();
            _mainWindow.map4OrderDropdown.Items.Clear();

            _mainWindow.dynMapLabel1.Text = "";
            _mainWindow.dynMap2Label.Text = "";
            _mainWindow.dynMap3Label.Text = "";
            _mainWindow.dynMap4Label.Text = "";

            _mainWindow.map1OrderDropdown.Items.Add("1");
            _mainWindow.map1OrderDropdown.Items.Add("2");
            _mainWindow.map1OrderDropdown.Items.Add("3");
            _mainWindow.map1OrderDropdown.Items.Add("4");

            _mainWindow.map2OrderDropdown.Items.Add("1");
            _mainWindow.map2OrderDropdown.Items.Add("2");
            _mainWindow.map2OrderDropdown.Items.Add("3");
            _mainWindow.map2OrderDropdown.Items.Add("4");

            _mainWindow.map3OrderDropdown.Items.Add("1");
            _mainWindow.map3OrderDropdown.Items.Add("2");
            _mainWindow.map3OrderDropdown.Items.Add("3");
            _mainWindow.map3OrderDropdown.Items.Add("4");

            _mainWindow.map4OrderDropdown.Items.Add("1");
            _mainWindow.map4OrderDropdown.Items.Add("2");
            _mainWindow.map4OrderDropdown.Items.Add("3");
            _mainWindow.map4OrderDropdown.Items.Add("4");

            _mainWindow.dynMapLabel1.Text = _mainWindow.listOfMapsToPatchIn.SelectedItems[0].SubItems[0].Text;
            _mainWindow.dynMap2Label.Text = _mainWindow.listOfMapsToPatchIn.SelectedItems[1].SubItems[0].Text;
            _mainWindow.dynMap3Label.Text = _mainWindow.listOfMapsToPatchIn.SelectedItems[2].SubItems[0].Text;
            _mainWindow.dynMap4Label.Text = _mainWindow.listOfMapsToPatchIn.SelectedItems[3].SubItems[0].Text;
        }

        public void ConfigureDynamicPanelForThreeSelectedMaps()
        {
            _mainWindow.dynMapLabel1.Visible = true;
            _mainWindow.dynMap2Label.Visible = true;
            _mainWindow.dynMap3Label.Visible = true;
            _mainWindow.dynMap4Label.Visible = false;

            _mainWindow.map1OrderDropdown.Visible = true;
            _mainWindow.map2OrderDropdown.Visible = true;
            _mainWindow.map3OrderDropdown.Visible = true;
            _mainWindow.map4OrderDropdown.Visible = false;

            _mainWindow.dynamicMapPanel.Visible = true;

            _mainWindow.dynMapLabel1.Text = "";
            _mainWindow.dynMap2Label.Text = "";
            _mainWindow.dynMap3Label.Text = "";

            _mainWindow.map1OrderDropdown.SelectedItem = null;
            _mainWindow.map2OrderDropdown.SelectedItem = null;
            _mainWindow.map3OrderDropdown.SelectedItem = null;

            _mainWindow.map1OrderDropdown.Items.Clear();
            _mainWindow.map2OrderDropdown.Items.Clear();
            _mainWindow.map3OrderDropdown.Items.Clear();

            _mainWindow.map1OrderDropdown.Items.Add("1");
            _mainWindow.map1OrderDropdown.Items.Add("2");
            _mainWindow.map1OrderDropdown.Items.Add("3");

            _mainWindow.map2OrderDropdown.Items.Add("1");
            _mainWindow.map2OrderDropdown.Items.Add("2");
            _mainWindow.map2OrderDropdown.Items.Add("3");

            _mainWindow.map3OrderDropdown.Items.Add("1");
            _mainWindow.map3OrderDropdown.Items.Add("2");
            _mainWindow.map3OrderDropdown.Items.Add("3");

            _mainWindow.dynMapLabel1.Text = _mainWindow.listOfMapsToPatchIn.SelectedItems[0].SubItems[0].Text;
            _mainWindow.dynMap2Label.Text = _mainWindow.listOfMapsToPatchIn.SelectedItems[1].SubItems[0].Text;
            _mainWindow.dynMap3Label.Text = _mainWindow.listOfMapsToPatchIn.SelectedItems[2].SubItems[0].Text;
        }

        public void ConfigureDynamicPanelForTwoSelectedMaps()
        {
            _mainWindow.dynamicMapPanel.Visible = true;
            _mainWindow.dynMapLabel1.Visible = true;
            _mainWindow.dynMap2Label.Visible = true;
            _mainWindow.dynMap3Label.Visible = false;
            _mainWindow.dynMap4Label.Visible = false;

            _mainWindow.map1OrderDropdown.Visible = true;
            _mainWindow.map2OrderDropdown.Visible = true;
            _mainWindow.map3OrderDropdown.Visible = false;
            _mainWindow.map4OrderDropdown.Visible = false;

            _mainWindow.map1OrderDropdown.SelectedItem = null;
            _mainWindow.map2OrderDropdown.SelectedItem = null;

            _mainWindow.map1OrderDropdown.Items.Clear();
            _mainWindow.map2OrderDropdown.Items.Clear();

            _mainWindow.dynMapLabel1.Text = "";
            _mainWindow.dynMap2Label.Text = "";

            _mainWindow.map1OrderDropdown.Items.Add("1");
            _mainWindow.map1OrderDropdown.Items.Add("2");

            _mainWindow.map2OrderDropdown.Items.Add("1");
            _mainWindow.map2OrderDropdown.Items.Add("2");

            _mainWindow.dynMapLabel1.Text = _mainWindow.listOfMapsToPatchIn.SelectedItems[0].SubItems[0].Text;
            _mainWindow.dynMap2Label.Text = _mainWindow.listOfMapsToPatchIn.SelectedItems[1].SubItems[0].Text;
        }
    }
}