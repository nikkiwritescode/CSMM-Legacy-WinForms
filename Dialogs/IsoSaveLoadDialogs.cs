using System;
using System.Windows.Forms;

namespace CustomStreetManager.Panels.MainWindow
{
    public static class IsoSaveLoadDialogs
    {
        public static string SaveFileDialog() //set output location button
        {
            var dialog = new SaveFileDialog
            {
                Filter = "ISO Image|*.iso",
                Title = "Where should I save the patched ISO?",
                FileName = "UpdatedISOFile"
            };
            return dialog.ShowDialog() == DialogResult.OK ? dialog.FileName : "None";
        }

        public static string OpenFileDialog()
        {
            var dialog = new OpenFileDialog
            {
                Filter = "ISO Image|*.iso|WBFS file|*.wbfs", 
                Title = "Which ISO image or WBFS file should we patch?"
            };

            return dialog.ShowDialog() == DialogResult.OK ? dialog.FileName : "None";
        }
    }
}