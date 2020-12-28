using CustomStreetManager.Panels;

namespace CustomStreetManager.Utilities
{
    public class ProgressBarHelpers
    {
        public static void UpdateProgressWindow(ProgressBar bar, string status, int amount)
        {
            bar.SetProgressBarLabel(status);
            bar.SetProgressBarValue(amount);
        }
    }
}