using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
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

        public async Task StartExtractBatFileProcess(string extractDiscBatFilePath)
        {
            /*var args = "\"" + _mainWindow.setInputISOLocation.Text + "\"";
            var p = await ProcessAsyncHelper.RunAsync(extractDiscBatFilePath, args, 0).ConfigureAwait(true); ;
            return p;*/
            
            var psi = new ProcessStartInfo(extractDiscBatFilePath, Arguments)
            {
                Arguments = "\"" + _mainWindow.setInputISOLocation.Text + "\"",
                CreateNoWindow = true,
                UseShellExecute = false,
                WorkingDirectory = Directory.GetCurrentDirectory()
            };

            var p = await ProcessAsyncHelper.RunAsync(psi);
            return;
        }

        public async Task CompileTheDisc()
        {
            var compileDiscBatFilePath = Path.Combine(Directory.GetCurrentDirectory(), DiscOperationsHelperPaths.CompileDiscFileName);
            var compileDiscWithWiimmfiBatFilePath = Path.Combine(Directory.GetCurrentDirectory(), DiscOperationsHelperPaths.CompileDiscWithWiimmfiFileName);

            if (!File.Exists(compileDiscBatFilePath) && !File.Exists(compileDiscWithWiimmfiBatFilePath)) return;
            switch (_mainWindow.patchToWiimmfiToolStripMenuItem.Checked)
            {
                case true:
                {
                    /*var args = "\"" + _mainWindow.setOutputPathLabel.Text + "\"";
                    var p = await ProcessAsyncHelper.RunAsync(compileDiscWithWiimmfiBatFilePath, args, 0).ConfigureAwait(false); ;
                    break;*/
                    //return p;

                    var psi3 = new ProcessStartInfo(compileDiscWithWiimmfiBatFilePath, Arguments)
                    {
                        Arguments = "\"" + _mainWindow.setOutputPathLabel.Text + "\"",
                        CreateNoWindow = true,
                        UseShellExecute = false,
                        WorkingDirectory = Directory.GetCurrentDirectory()
                    };

                    var p = await ProcessAsyncHelper.RunAsync(psi3);
                    return;
                }
                case false:
                {
                    /*var args = "\"" + _mainWindow.setOutputPathLabel.Text + "\"";
                    var p = await ProcessAsyncHelper.RunAsync(compileDiscBatFilePath, args, 0).ConfigureAwait(false); ;
                    break;*/
                    //return p;
                    var psi3 = new ProcessStartInfo(compileDiscBatFilePath, Arguments)
                    {
                        Arguments = "\"" + _mainWindow.setOutputPathLabel.Text + "\"",
                        CreateNoWindow = true,
                        UseShellExecute = false,
                        WorkingDirectory = Directory.GetCurrentDirectory()
                    };
                    await ProcessAsyncHelper.RunAsync(psi3);
                    return;
                }
            }

            return; //new ProcessAsyncHelper.Result();
        }
    }
}