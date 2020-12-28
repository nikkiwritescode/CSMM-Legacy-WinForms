using System.Windows.Forms;
using ProgressBar = CustomStreetManager.Panels.ProgressBar;

namespace CustomStreetManager.ErrorHandling
{
    public static class ErrorMessages
    {
        public static void ThrowOutputFilePathCannotBeBlankError(ProgressBar progressBar)
        {
            progressBar.SetProgressBarLabel("Error: The output file path cannot be blank!");
            progressBar.SetProgressBarValue(100);
            progressBar.SetButtonToGoBack();
        }

        public static void ThrowSourceIsoCouldNotBeOpenedError(ProgressBar progressBar)
        {
            progressBar.SetProgressBarLabel("Error: The source ISO could not be opened.");
            progressBar.SetProgressBarValue(100);
            progressBar.SetButtonToGoBack();
        }
        public static void ShowDefAsmHackPALNotice()
        {
            MessageBox.Show("Please be aware that I'm not checking for this -- " +
                            "but you need a PAL ISO to enable Deflaktor's ASM Hacks, otherwise " +
                            "your game will crash on startup.");
        }

        public static void ThrowDynamicMapOrderMustBeSetAndUniqueError()
        {
            MessageBox.Show("Dynamic map order must be set for each map, and must be unique for each map.");
        }

        public  static void ThrowMapSlotSupportsMaxOf2Error()
        {
            MessageBox.Show("This map supports a maximum of 2 map slots.");
        }
    }
}