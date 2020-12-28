namespace CustomStreetManager.Panels.MainWindow
{
    public class MapSelectionRadioButtonHelpers
    {
        private MainWindow _mainWindow;

        public MapSelectionRadioButtonHelpers(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
        }

        public void CheckMap(string s)
        {
            switch (s)
            {
                case "Castle Trodain":
                    _mainWindow.trodainButton.Checked = true;
                    return;
                case "The Observatory":
                    _mainWindow.observatoryButton.Checked = true;
                    return;
                case "Ghost Ship":
                    _mainWindow.ghostShipButton.Checked = true;
                    return;
                case "Slimenia":
                    _mainWindow.slimeniaButton.Checked = true;
                    return;
                case "Mt. Magmageddon":
                    _mainWindow.mtmagButton.Checked = true;
                    return;
                case "Robbin' Hood Ruins":
                    _mainWindow.rhrButton.Checked = true;
                    return;
                case "Mario Stadium":
                    _mainWindow.stadiumButton.Checked = true;
                    return;
                case "Starship Mario":
                    _mainWindow.starshipButton.Checked = true;
                    return;
                case "Mario Circuit":
                    _mainWindow.circuitButton.Checked = true;
                    return;
                case "Yoshi's Island":
                    _mainWindow.yoshiButton.Checked = true;
                    return;
                case "Delfino Plaza":
                    _mainWindow.delfinoButton.Checked = true;
                    return;
                case "Peach's Castle":
                    _mainWindow.peachButton.Checked = true;
                    return;
                case "Alefgard":
                    _mainWindow.alefgardButton.Checked = true;
                    return;
                case "Super Mario Bros.":
                    _mainWindow.smbButton.Checked = true;
                    return;
                case "Bowser's Castle":
                    _mainWindow.bowserButton.Checked = true;
                    return;
                case "Good Egg Galaxy":
                    _mainWindow.gegButton.Checked = true;
                    return;
                case "Colossus":
                    _mainWindow.colossusButton.Checked = true;
                    return;
                case "Alltrades Abbey":
                    _mainWindow.alltradesButton.Checked = true;
                    return;
                case "*The Observatory":
                    _mainWindow.dynTheObservatoryButton.Checked = true;
                    return;
                case "*Colossus":
                    _mainWindow.dynTheColossusButton.Checked = true;
                    return;
                case "*Mt. Magmageddon":
                    _mainWindow.dynMtMagButton.Checked = true;
                    return;
                case null:
                    _mainWindow.noneButton.Checked = true;
                    return;
            }
        }

        public void CheckAndDisableMapButton(string mapName)
        {
            switch (mapName)
            {
                case "Castle Trodain":
                    _mainWindow.trodainButton.Enabled = false;
                    return;
                case "The Observatory":
                    _mainWindow.observatoryButton.Enabled = false;
                    _mainWindow.dynTheObservatoryButton.Enabled = false;
                    return;
                case "*The Observatory":
                    _mainWindow.observatoryButton.Enabled = false;
                    _mainWindow.dynTheObservatoryButton.Enabled = false;
                    return;
                case "Ghost Ship":
                    _mainWindow.ghostShipButton.Enabled = false;
                    return;
                case "Slimenia":
                    _mainWindow.slimeniaButton.Enabled = false;
                    return;
                case "Mt. Magmageddon":
                    _mainWindow.mtmagButton.Enabled = false;
                    _mainWindow.dynMtMagButton.Enabled = false;
                    return;
                case "*Mt. Magmageddon":
                    _mainWindow.mtmagButton.Enabled = false;
                    _mainWindow.dynMtMagButton.Enabled = false;
                    return;
                case "Robbin' Hood Ruins":
                    _mainWindow.rhrButton.Enabled = false;
                    return;
                case "Mario Stadium":
                    _mainWindow.stadiumButton.Enabled = false;
                    return;
                case "Starship Mario":
                    _mainWindow.starshipButton.Enabled = false;
                    return;
                case "Mario Circuit":
                    _mainWindow.circuitButton.Enabled = false;
                    return;
                case "Yoshi's Island":
                    _mainWindow.yoshiButton.Enabled = false;
                    return;
                case "Delfino Plaza":
                    _mainWindow.delfinoButton.Enabled = false;
                    return;
                case "Peach's Castle":
                    _mainWindow.peachButton.Enabled = false;
                    return;
                case "Alefgard":
                    _mainWindow.alefgardButton.Enabled = false;
                    return;
                case "Super Mario Bros.":
                    _mainWindow.smbButton.Enabled = false;
                    return;
                case "Bowser's Castle":
                    _mainWindow.bowserButton.Enabled = false;
                    return;
                case "Good Egg Galaxy":
                    _mainWindow.gegButton.Enabled = false;
                    return;
                case "Colossus":
                    _mainWindow.colossusButton.Enabled = false;
                    _mainWindow.dynTheColossusButton.Enabled = false;
                    return;
                case "*Colossus":
                    _mainWindow.colossusButton.Enabled = false;
                    _mainWindow.dynTheColossusButton.Enabled = false;
                    return;
                case "Alltrades Abbey":
                    _mainWindow.alltradesButton.Enabled = false;
                    return;
                case "None":
                    return;
                case null:
                    return;
            }
        }

        public void SetAllMapButtonsActive()
        {
            _mainWindow.trodainButton.Enabled = true;
            _mainWindow.observatoryButton.Enabled = true;
            _mainWindow.ghostShipButton.Enabled = true;
            _mainWindow.slimeniaButton.Enabled = true;
            _mainWindow.mtmagButton.Enabled = true;
            _mainWindow.rhrButton.Enabled = true;
            _mainWindow.stadiumButton.Enabled = true;
            _mainWindow.starshipButton.Enabled = true;
            _mainWindow.circuitButton.Enabled = true;
            _mainWindow.yoshiButton.Enabled = true;
            _mainWindow.delfinoButton.Enabled = true;
            _mainWindow.peachButton.Enabled = true;
            _mainWindow.alefgardButton.Enabled = true;
            _mainWindow.smbButton.Enabled = true;
            _mainWindow.bowserButton.Enabled = true;
            _mainWindow.gegButton.Enabled = true;
            _mainWindow.colossusButton.Enabled = true;
            _mainWindow.alltradesButton.Enabled = true;
            _mainWindow.dynTheColossusButton.Enabled = true;
            _mainWindow.dynTheObservatoryButton.Enabled = true;
            _mainWindow.dynMtMagButton.Enabled = true;
        }
    }
}