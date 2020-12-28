using System.Diagnostics;
using System.IO;
using CustomStreetManager.FilePaths;
using CustomStreetManager.Panels.MainWindow;
using ProgressBar = CustomStreetManager.Panels.ProgressBar;

namespace CustomStreetManager.Utilities
{
    public class IsoManagement
    {
        private MainWindow _mainWindow;

        public IsoManagement(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
        }

        private const string Arguments = "start /wait /min /c";

        public static string BaseDirectoryPath = @"..\_working_directory\";

        public string DetermineIsoFolderStructure(ProgressBar instance)
        {
            if (Directory.Exists(BaseDirectoryPath + "files"))
            {
                BaseDirectoryPath += @"files\";
                return BaseDirectoryPath;
            }
            else if (Directory.Exists(BaseDirectoryPath + "data"))
            {
                BaseDirectoryPath += @"data\files\";
                return BaseDirectoryPath;
            }
            else
            {
                instance.SetProgressBarLabel("Error: The working directory is missing or empty!");
                instance.SetButtonToClose();
                return null;
            }
        }

        public void StartExtractBatFileProcess(string extractDiscBatFilePath)
        {
            ProcessStartInfo psi = new ProcessStartInfo(extractDiscBatFilePath, Arguments)
            {
                Arguments = "\"" + _mainWindow.setInputISOLocation.Text + "\"",
                CreateNoWindow = true,
                UseShellExecute = false,
                WorkingDirectory = Directory.GetCurrentDirectory()
            };

            var p = Process.Start(psi);
            p?.WaitForExit();
        }

        public void CompileTheDisc()
        {
            var compileDiscBatFilePath = Path.Combine(Directory.GetCurrentDirectory(), DiscOperationsHelperPaths.CompileDiscFileName);
            var compileDiscWithWiimmfiBatFilePath = Path.Combine(Directory.GetCurrentDirectory(), DiscOperationsHelperPaths.CompileDiscWithWiimmfiFileName);

            if (!File.Exists(compileDiscBatFilePath) && !File.Exists(compileDiscWithWiimmfiBatFilePath)) return;
            switch (_mainWindow.patchToWiimmfiToolStripMenuItem.Checked)
            {
                case true:
                {
                    var psi3 = new ProcessStartInfo(compileDiscWithWiimmfiBatFilePath, Arguments)
                    {
                        Arguments = "\"" + _mainWindow.setOutputPathLabel.Text + "\"",
                        CreateNoWindow = true,
                        UseShellExecute = false,
                        WorkingDirectory = Directory.GetCurrentDirectory()
                    };
                    var p3 = Process.Start(psi3);
                    p3?.WaitForExit();
                    break;
                }
                case false:
                {
                    var psi3 = new ProcessStartInfo(compileDiscBatFilePath, Arguments)
                    {
                        Arguments = "\"" + _mainWindow.setOutputPathLabel.Text + "\"",
                        CreateNoWindow = true,
                        UseShellExecute = false,
                        WorkingDirectory = Directory.GetCurrentDirectory()
                    };
                    var p3 = Process.Start(psi3);
                    p3?.WaitForExit();
                    break;
                }
            }
        }
    }
}