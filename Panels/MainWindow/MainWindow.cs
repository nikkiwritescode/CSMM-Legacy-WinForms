using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using CustomStreetManager.FilePaths;
using CustomStreetManager.Patches;
using CustomStreetManager.Utilities;

namespace CustomStreetManager.Panels.MainWindow
{
    public partial class MainWindow : Form
    {
        public string DiscPath = "";

        public MainWindow()
        {
            InitializeComponent();
            IsoManagement = new IsoManagement((this));
            MapReplacement = new MapReplacement(this);
            OptionalPatches = new OptionalPatches(this);
            MapSelectionRadioButtonHelpers = new MapSelectionRadioButtonHelpers(this);
            DynamicMapPanelHelpers = new DynamicMapPanelHelpers(this);
            InputValidation = new InputValidation(this);
        }
        public IsoManagement IsoManagement { get; }
        public MapReplacement MapReplacement { get; }
        public OptionalPatches OptionalPatches { get; }
        public MapSelectionRadioButtonHelpers MapSelectionRadioButtonHelpers { get; }
        public DynamicMapPanelHelpers DynamicMapPanelHelpers { get; }
        public InputValidation InputValidation { get; }

        public void Awake() => Directory.SetCurrentDirectory(Directory.GetCurrentDirectory());

        private void UpdateMapButton_Click(object sender, EventArgs e)
        {
            var extractDiscBatFilePath = Path.Combine(Directory.GetCurrentDirectory(), DiscOperationsHelperPaths.ExtractDiscFileName);

            var progressBar = new ProgressBar();
            progressBar.Show();

            UpdateProgressWindow(progressBar, "Extracting disc...", 25);

            if (!File.Exists(setInputISOLocation.Text))
            {
                ThrowSourceIsoCouldNotBeOpenedError(progressBar);
            }
            else
            {
                if (setOutputPathLabel.Text == "None")
                {
                    ThrowOutputFilePathCannotBeBlankError(progressBar);
                }
                else
                {
                    IsoManagement.StartExtractBatFileProcess(extractDiscBatFilePath);

                    DiscPath = IsoManagement.DetermineIsoFolderStructure(progressBar);

                    UpdateProgressWindow(progressBar, "Replacing maps...", 40);
                    MapReplacement.ReplaceMaps();

                    UpdateProgressWindow(progressBar, "Setting Options...", 70);
                    if(removeIntroMenuAndMapBgmToolStripMenuItem.Checked) { OptionalPatches.RemoveMusic(); }
                    OptionalPatches.AsmHacks();
                    OptionalPatches.UpdateUiForWiimmfi();

                    UpdateProgressWindow(progressBar, "Re-compiling disc...", 90);
                    IsoManagement.CompileTheDisc();

                    UpdateProgressWindow(progressBar, "Done!", 100);
                    progressBar.SetButtonToClose();
                }
            }
        }

        private static void ThrowOutputFilePathCannotBeBlankError(ProgressBar progressBar)
        {
            progressBar.SetProgressBarLabel("Error: The output file path cannot be blank!");
            progressBar.SetProgressBarValue(100);
            progressBar.SetButtonToGoBack();
        }

        private static void ThrowSourceIsoCouldNotBeOpenedError(ProgressBar progressBar)
        {
            progressBar.SetProgressBarLabel("Error: The source ISO could not be opened.");
            progressBar.SetProgressBarValue(100);
            progressBar.SetButtonToGoBack();
        }

        private static void UpdateProgressWindow(ProgressBar bar, string status, int amount)
        {
            bar.SetProgressBarLabel(status);
            bar.SetProgressBarValue(amount);
        }

        private void openMapButton_Click(object sender, EventArgs e)
        {
            switch (addMapButton.Text)
            {
                //if one item is selected
                case "Add map":
                    DynamicMapPanelHelpers.ClearDynamicMapLabels();
                    OpenAddMapsDialog();
                    break;
                //if two or more maps are selected, the button changes!
                case "Set Dynamic":
                    OpenDynamicMapPanel();
                    break;
            }
        }

        private void OpenDynamicMapPanel()
        {
            switch (listOfMapsToPatchIn.SelectedItems.Count)
            {
                case 2:
                    DynamicMapPanelHelpers.ConfigureDynamicPanelForTwoSelectedMaps();
                    break;
                case 3:
                    DynamicMapPanelHelpers.ConfigureDynamicPanelForThreeSelectedMaps();
                    break;
                case 4:
                    DynamicMapPanelHelpers.ConfigureDynamicPanelForFourSelectedMaps();
                    break;
                default:
                {
                    MessageBox.Show("No map slot supports greater than 4 slots.");
                    break;
                }
            }

            foreach (ListViewItem item in listOfMapsToPatchIn.SelectedItems) { item.SubItems[3].Text = "true"; }
        }

        private void OpenAddMapsDialog()
        {
            ConfigureAddMapsDialog();
            if (addMapsDialog.ShowDialog() != DialogResult.OK) return;
            ReadSelectedMaps();
        }

        private void ConfigureAddMapsDialog()
        {
            addMapsDialog.Multiselect = true;
            addMapsDialog.Filter = "Map files (*.frb)|*.frb|All files (*.*)|*.*";
        }

        private void ReadSelectedMaps()
        {
            var arr = new string[5];
            var sr = new StreamReader(addMapsDialog.FileName);

            for (var i = 0; i < addMapsDialog.SafeFileNames.Count(); i++)
            {
                arr[0] = addMapsDialog.SafeFileNames[i];
                arr[1] = "None";
                arr[2] = addMapsDialog.FileNames[i];
                arr[3] = "false";
                arr[4] = "0";

                var newItem = new ListViewItem(arr);
                listOfMapsToPatchIn.Items.Add(newItem);
            }

            sr.Close();
        }

        private void RemoveMapFromList(object sender, EventArgs e)
        {
            var indexes = listOfMapsToPatchIn.SelectedIndices;
            for(var i = (listOfMapsToPatchIn.Items.Count - 1); i >= 0; i--)
            {
                if (!indexes.Contains(i)) continue;
                listOfMapsToPatchIn.Items.RemoveAt(i);
            }
            whichMapShouldWeReplaceLabel.Text = "Which map should we replace?";
            noneButton.Checked = true;
            addMapButton.Text = "Add map";
            MapSelectionRadioButtonHelpers.SetAllMapButtonsActive();
            foreach (ListViewItem item in listOfMapsToPatchIn.Items)
            {
                var mapName = item.SubItems[1].Text;
                MapSelectionRadioButtonHelpers.CheckAndDisableMapButton(mapName);
            }
        }

        private void clearListButton_Click(object sender, EventArgs e)
        {
            listOfMapsToPatchIn.Items.Clear();
            noneButton.Checked = true;
            whichMapShouldWeReplaceLabel.Text = "Which map should we replace?";
            MapSelectionRadioButtonHelpers.SetAllMapButtonsActive();
            addMapButton.Text = "Add map";
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) => Application.Exit();

        private void listOfMapsToPatchIn_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listOfMapsToPatchIn.SelectedItems.Count >= 2)
            {
                addMapButton.Text = "Set Dynamic";
            }
            else
            {
                addMapButton.Text = "Add map";
                dynamicMapPanel.Visible = false;

                MapSelectionRadioButtonHelpers.SetAllMapButtonsActive();

                var allSelectedItems = this.listOfMapsToPatchIn.SelectedItems;

                var mapToPatch = "";
                foreach (ListViewItem item in allSelectedItems)
                {
                    mapToPatch = item.SubItems[1].Text;
                    whichMapShouldWeReplaceLabel.Text = "Which map should " + item.SubItems[0].Text + " replace?";
                }

                MapSelectionRadioButtonHelpers.CheckMap(mapToPatch); //see which map we're on and check the correct radio button

                foreach (ListViewItem item in listOfMapsToPatchIn.Items)
                {
                    var mapName = item.SubItems[1].Text;
                    MapSelectionRadioButtonHelpers.CheckAndDisableMapButton(mapName);
                }
            }
        }

        private void AddMapSlotNameToMapList(string mapName)
        {
            if (listOfMapsToPatchIn.SelectedItems.Count == 0) return;
            foreach (ListViewItem item in listOfMapsToPatchIn.SelectedItems)
            {
                item.SubItems[1].Text = mapName;
            }
        }

        private void trodainButton_CheckedChanged(object sender, EventArgs e)
        {
            if (!trodainButton.Checked) return;
            AddMapSlotNameToMapList("Castle Trodain");
        }

        private void observatoryButton_CheckedChanged(object sender, EventArgs e)
        {
            if (!observatoryButton.Checked) return;
            AddMapSlotNameToMapList("The Observatory");
        }

        private void ghostShipButton_CheckedChanged(object sender, EventArgs e)
        {
            if (!ghostShipButton.Checked) return;
            AddMapSlotNameToMapList("Ghost Ship");
        }

        private void slimeniaButton_CheckedChanged(object sender, EventArgs e)
        {
            if (!slimeniaButton.Checked) return;
            AddMapSlotNameToMapList("Slimenia");
        }

        private void mtmagButton_CheckedChanged(object sender, EventArgs e)
        {
            if (!mtmagButton.Checked) return;
            AddMapSlotNameToMapList("Mt. Magmageddon");
        }
        private void robbinHoodRuinsButton_CheckedChanged(object sender, EventArgs e)
        {
            if (!rhrButton.Checked) return;
            AddMapSlotNameToMapList("Robbin' Hood Ruins");
        }

        private void stadiumButton_CheckedChanged(object sender, EventArgs e)
        {
            if (!stadiumButton.Checked) return;
            AddMapSlotNameToMapList("Mario Stadium");
        }

        private void starshipButton_CheckedChanged(object sender, EventArgs e)
        {
            if (!starshipButton.Checked) return;
            AddMapSlotNameToMapList("Starship Mario");
        }

        private void circuitButton_CheckedChanged(object sender, EventArgs e)
        {
            if (!circuitButton.Checked) return;
            AddMapSlotNameToMapList("Mario Circuit");
        }

        private void yoshiButton_CheckedChanged(object sender, EventArgs e)
        {
            if (!yoshiButton.Checked) return;
            AddMapSlotNameToMapList("Yoshi's Island");
        }

        private void delfinoButton_CheckedChanged(object sender, EventArgs e)
        {
            if (!delfinoButton.Checked) return;
            AddMapSlotNameToMapList("Delfino Plaza");
        }

        private void peachButton_CheckedChanged(object sender, EventArgs e)
        {
            if (!peachButton.Checked) return;
            AddMapSlotNameToMapList("Peach's Castle");
        }

        private void alefgardButton_CheckedChanged(object sender, EventArgs e)
        {
            if (!alefgardButton.Checked) return;
            AddMapSlotNameToMapList("Alefgard");
        }

        private void smbButton_CheckedChanged(object sender, EventArgs e)
        {
            if (!smbButton.Checked) return;
            AddMapSlotNameToMapList("Super Mario Bros.");
        }

        private void bowserButton_CheckedChanged(object sender, EventArgs e)
        {
            if (!bowserButton.Checked) return;
            AddMapSlotNameToMapList("Bowser's Castle");
        }

        private void gegButton_CheckedChanged(object sender, EventArgs e)
        {
            if (!gegButton.Checked) return;
            AddMapSlotNameToMapList("Good Egg Galaxy");
        }

        private void colossusButton_CheckedChanged(object sender, EventArgs e)
        {
            if (!colossusButton.Checked) return;
            AddMapSlotNameToMapList("Colossus");
        }

        private void alltradesButton_CheckedChanged(object sender, EventArgs e)
        {
            if (!alltradesButton.Checked) return;
            AddMapSlotNameToMapList("Alltrades Abbey");
        }

        private void noneButton_CheckedChanged(object sender, EventArgs e)
        {
            if (!noneButton.Checked) return;
            AddMapSlotNameToMapList("None");
        }

        private void aboutCustomStreetMapManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var aboutPanel = new AboutPanel();
            aboutPanel.Show();
        }

        private void SaveFileDialog(object sender, EventArgs e) => setOutputPathLabel.Text = IsoSaveLoadDialogs.SaveFileDialog();
        private void OpenFileDialog(object sender, EventArgs e) => setInputISOLocation.Text = IsoSaveLoadDialogs.OpenFileDialog();

        private void EnableDefAsmHackToolStripMenuItem(object sender, EventArgs e)
        {
            if (deflaktorsASMHacksToolStripMenuItem.Checked != true) return;
            MessageBox.Show("Please be aware that I'm not checking for this -- " +
                            "but you need a PAL ISO to enable Deflaktor's ASM Hacks, otherwise " +
                            "your game will crash on startup.");
        }

        private void dynTheObservatoryButton_CheckedChanged(object sender, EventArgs e)
        {
            if (!dynTheObservatoryButton.Checked) return;
            var allSelectedItems = this.listOfMapsToPatchIn.SelectedItems;
            if (allSelectedItems.Count == 4)
            {
                if (!InputValidation.FourDynamicDropdownsAreNotNullAndNotEqualToEachOther()) return;
                foreach (ListViewItem item in allSelectedItems)
                {
                    item.SubItems[1].Text = "*The Observatory";
                    if (dynMapLabel1.Text == item.SubItems[0].Text)
                    {
                        item.SubItems[4].Text = map1OrderDropdown.SelectedItem.ToString();
                    }
                    else if (dynMap2Label.Text == item.SubItems[0].Text)
                    {
                        item.SubItems[4].Text = map2OrderDropdown.SelectedItem.ToString();
                    }
                    else if (dynMap3Label.Text == item.SubItems[0].Text)
                    {
                        item.SubItems[4].Text = map3OrderDropdown.SelectedItem.ToString();
                    }
                    else if (dynMap4Label.Text == item.SubItems[0].Text)
                    {
                        item.SubItems[4].Text = map4OrderDropdown.SelectedItem.ToString();
                    }
                }
            }
            else if (allSelectedItems.Count == 3)
            {
                if (!InputValidation.ThreeDynamicDropdownsAreNotNullAndNotEqualToEachOther())
                {
                    MessageBox.Show("Dynamic map order must be set for each map, and must be unique for each map.");
                    dynTheObservatoryButton.Checked = false;
                    return;
                }
                foreach (ListViewItem item in allSelectedItems)
                {
                    item.SubItems[1].Text = "*The Observatory";
                    if (dynMapLabel1.Text == item.SubItems[0].Text)
                    {
                        item.SubItems[4].Text = map1OrderDropdown.SelectedItem.ToString();
                    }
                    else if (dynMap2Label.Text == item.SubItems[0].Text)
                    {
                        item.SubItems[4].Text = map2OrderDropdown.SelectedItem.ToString();
                    }
                    else if (dynMap3Label.Text == item.SubItems[0].Text)
                    {
                        item.SubItems[4].Text = map3OrderDropdown.SelectedItem.ToString();
                    }
                }
            }
            else if (allSelectedItems.Count == 2)
            {
                if (!InputValidation.TwoDynamicDropdownsAreNotNullAndNotEqualToEachOther())
                {
                    MessageBox.Show("Dynamic map order must be set for each map, and must be unique for each map.");
                    dynTheObservatoryButton.Checked = false;
                }
                else
                {
                    foreach (ListViewItem item in allSelectedItems)
                    {
                        item.SubItems[1].Text = "*The Observatory";
                        if (dynMapLabel1.Text == item.SubItems[0].Text)
                        {
                            item.SubItems[4].Text = map1OrderDropdown.SelectedItem.ToString();
                        }
                        else if (dynMap2Label.Text == item.SubItems[0].Text)
                        {
                            item.SubItems[4].Text = map2OrderDropdown.SelectedItem.ToString();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Dynamic map order must be set for each map, and must be unique for each map.");
                dynTheObservatoryButton.Checked = false;
            }
        }

        private void dynMtMagButton_CheckedChanged_1(object sender, EventArgs e)
        {
            if (!dynMtMagButton.Checked) return;
            var allSelectedItems = listOfMapsToPatchIn.SelectedItems;

            if (allSelectedItems.Count == 2)
            {
                if (!InputValidation.TwoDynamicDropdownsAreNotNullAndNotEqualToEachOther())
                {
                    MessageBox.Show("Dynamic map order must be set for each map, and must be unique for each map.");
                    dynMtMagButton.Checked = false;
                }
                else
                {
                    foreach (ListViewItem item in allSelectedItems)
                    {
                        item.SubItems[1].Text = "*Mt. Magmageddon";
                        if (dynMapLabel1.Text == item.SubItems[0].Text)
                        {
                            item.SubItems[4].Text = map1OrderDropdown.SelectedItem.ToString();
                        }
                        else if (dynMap2Label.Text == item.SubItems[0].Text)
                        {
                            item.SubItems[4].Text = map2OrderDropdown.SelectedItem.ToString();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("This map only supports a maximum of 2 map slots.");
                dynMtMagButton.Checked = false;
            }
        }

        private void dynTheColossusButton_CheckedChanged_1(object sender, EventArgs e)
        {
            if (!dynTheColossusButton.Checked) return;
            var allSelectedItems = this.listOfMapsToPatchIn.SelectedItems;
            if (allSelectedItems.Count == 2)
            {
                if (!InputValidation.TwoDynamicDropdownsAreNotNullAndNotEqualToEachOther())
                {
                    MessageBox.Show("Dynamic map order must be set for each map, and must be unique for each map.");
                    dynTheColossusButton.Checked = false;
                }
                else
                {
                    foreach (ListViewItem item in allSelectedItems)
                    {
                        item.SubItems[1].Text = "*Colossus";
                        if (dynMapLabel1.Text == item.SubItems[0].Text)
                        {
                            item.SubItems[4].Text = map1OrderDropdown.SelectedItem.ToString();
                        }
                        else if (dynMap2Label.Text == item.SubItems[0].Text)
                        {
                            item.SubItems[4].Text = map2OrderDropdown.SelectedItem.ToString();
                        }
                    }
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("This map only supports a maximum of 2 map slots.");
                dynTheColossusButton.Checked = false;
            }
        }
    }
}
