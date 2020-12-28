namespace CustomStreetManager.Panels.MainWindow
{
    public class InputValidation
    {
        private MainWindow _mainWindow;

        public InputValidation(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
        }

        public bool TwoDynamicDropdownsAreNotNullAndNotEqualToEachOther()
        {
            return _mainWindow.map1OrderDropdown.SelectedItem != null && 
                   _mainWindow.map2OrderDropdown.SelectedItem != null && 
                   _mainWindow.map1OrderDropdown.SelectedItem.ToString() != _mainWindow.map2OrderDropdown.SelectedItem.ToString();
        }

        public bool ThreeDynamicDropdownsAreNotNullAndNotEqualToEachOther()
        {
            return _mainWindow.map1OrderDropdown.SelectedItem != null && 
                   _mainWindow.map2OrderDropdown.SelectedItem != null && 
                   _mainWindow.map3OrderDropdown.SelectedItem != null && 
                   _mainWindow.map1OrderDropdown.SelectedItem.ToString() != _mainWindow.map2OrderDropdown.SelectedItem.ToString() && 
                   _mainWindow.map1OrderDropdown.SelectedItem.ToString() != _mainWindow.map3OrderDropdown.SelectedItem.ToString() && 
                   _mainWindow.map2OrderDropdown.SelectedItem.ToString() != _mainWindow.map3OrderDropdown.SelectedItem.ToString();
        }

        public bool FourDynamicDropdownsAreNotNullAndNotEqualToEachOther()
        {
            return _mainWindow.map1OrderDropdown.SelectedItem != null && 
                   _mainWindow.map2OrderDropdown.SelectedItem != null && 
                   _mainWindow.map3OrderDropdown.SelectedItem != null && 
                   _mainWindow.map4OrderDropdown.SelectedItem != null && 
                   _mainWindow.map1OrderDropdown.SelectedItem.ToString() != _mainWindow.map2OrderDropdown.SelectedItem.ToString() && 
                   _mainWindow.map1OrderDropdown.SelectedItem.ToString() != _mainWindow.map3OrderDropdown.SelectedItem.ToString() &&
                   _mainWindow.map1OrderDropdown.SelectedItem.ToString() != _mainWindow.map4OrderDropdown.SelectedItem.ToString() && 
                   _mainWindow.map2OrderDropdown.SelectedItem.ToString() != _mainWindow.map3OrderDropdown.SelectedItem.ToString() && 
                   _mainWindow.map2OrderDropdown.SelectedItem.ToString() != _mainWindow.map4OrderDropdown.SelectedItem.ToString() && 
                   _mainWindow.map3OrderDropdown.SelectedItem.ToString() != _mainWindow.map4OrderDropdown.SelectedItem.ToString();
        }
    }
}