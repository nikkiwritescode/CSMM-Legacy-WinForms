using System.IO;
using CustomStreetManager.FilePaths;
using CustomStreetManager.Panels.MainWindow;
using CustomStreetManager.Utilities;

namespace CustomStreetManager.Patches
{
    public class OptionalPatches
    {
        private MainWindow _mainWindow;

        public OptionalPatches(MainWindow mainWindow) => _mainWindow = mainWindow;

        public static void RemoveMusic()
        {
            if (!File.Exists(MusicFilePaths.musiclessConfigFile)) return;
            DiscIo.MoveFile(MusicFilePaths.musiclessConfigFile, IsoManagement.BaseDirectoryPath + MusicFilePaths.soundConfig1);
            DiscIo.MoveFile(MusicFilePaths.musiclessConfigFile, IsoManagement.BaseDirectoryPath + MusicFilePaths.soundConfig2);
            DiscIo.MoveFile(MusicFilePaths.musiclessConfigFile, IsoManagement.BaseDirectoryPath + MusicFilePaths.soundConfig3);
        }

        public void AsmHacks()
        {
            if (!_mainWindow.deflaktorsASMHacksToolStripMenuItem.Checked) return;
            if (File.Exists(UIMessageFilePaths.originalBootDol) && File.Exists(DefsAsmHackPaths.BootDol))
            {
                DiscIo.MoveFile(DefsAsmHackPaths.BootDol, UIMessageFilePaths.originalBootDol);
            }

            switch (_mainWindow.patchToWiimmfiToolStripMenuItem.Checked)
            {
                case true:
                    PatchUiForDefsAsmWithWiimmfi();
                    break;
                default:
                    PatchUiForAsmWithoutWiimmfi();
                    break;
            }
        }

        private void PatchUiForAsmWithoutWiimmfi()
        {
            if (File.Exists(IsoManagement.BaseDirectoryPath + UIMessageFilePaths.originalUIMessageDE) && File.Exists(DefsAsmHackPaths.UIMessageDE))
            {
                DiscIo.MoveFile(
                    DefsAsmHackPaths.UIMessageDE, 
                    IsoManagement.BaseDirectoryPath + UIMessageFilePaths.originalUIMessageDE);
            }

            if (File.Exists(IsoManagement.BaseDirectoryPath + UIMessageFilePaths.originalUIMessageEN) && File.Exists(DefsAsmHackPaths.UIMessageEN))
            {
                DiscIo.MoveFile(
                    DefsAsmHackPaths.UIMessageEN, 
                    IsoManagement.BaseDirectoryPath + UIMessageFilePaths.originalUIMessageEN);
            }

            if (File.Exists(IsoManagement.BaseDirectoryPath + UIMessageFilePaths.originalUIMessageUK) && File.Exists(DefsAsmHackPaths.UIMessageUK))
            {
                DiscIo.MoveFile(
                    DefsAsmHackPaths.UIMessageUK, 
                    IsoManagement.BaseDirectoryPath + UIMessageFilePaths.originalUIMessageUK);
            }
        }

        private void PatchUiForDefsAsmWithWiimmfi()
        {
            if (File.Exists(IsoManagement.BaseDirectoryPath + UIMessageFilePaths.originalUIMessageDE) && File.Exists(DefsAsmHackPaths.UIMessageDEPlusWiimmfi))
            {
                DiscIo.MoveFile(
                    DefsAsmHackPaths.UIMessageDEPlusWiimmfi, 
                    IsoManagement.BaseDirectoryPath + UIMessageFilePaths.originalUIMessageDE);
            }

            if (File.Exists(IsoManagement.BaseDirectoryPath + UIMessageFilePaths.originalUIMessageEN) && File.Exists(DefsAsmHackPaths.UIMessageENPlusWiimmfi))
            {
                DiscIo.MoveFile(
                    DefsAsmHackPaths.UIMessageENPlusWiimmfi, 
                    IsoManagement.BaseDirectoryPath + UIMessageFilePaths.originalUIMessageEN);
            }

            if (File.Exists(IsoManagement.BaseDirectoryPath + UIMessageFilePaths.originalUIMessageUK) && File.Exists(DefsAsmHackPaths.UIMessageUKPlusWiimmfi))
            {
                DiscIo.MoveFile(
                    DefsAsmHackPaths.UIMessageUKPlusWiimmfi, 
                    IsoManagement.BaseDirectoryPath + UIMessageFilePaths.originalUIMessageUK);
            }
        }

        public void UpdateUiForWiimmfi() //updates the UI when Wiimmfi is being patched in, and the ASM hacks aren't. (They do their own UI stuff).
        {
            if (!_mainWindow.patchToWiimmfiToolStripMenuItem.Checked || _mainWindow.deflaktorsASMHacksToolStripMenuItem.Checked) return;
            
            if (File.Exists(WiimmfiPaths.USWiimmfiUIUpdateFile) && File.Exists(IsoManagement.BaseDirectoryPath + UIMessageFilePaths.originalUIMessageEN))
            {
                DiscIo.MoveFile(
                    WiimmfiPaths.USWiimmfiUIUpdateFile,
                    IsoManagement.BaseDirectoryPath + UIMessageFilePaths.originalUIMessageEN);
            }
            if (File.Exists(WiimmfiPaths.UKWiimmfiUIUpdateFile) && File.Exists(IsoManagement.BaseDirectoryPath + UIMessageFilePaths.originalUIMessageUK))
            {
                DiscIo.MoveFile(
                    WiimmfiPaths.UKWiimmfiUIUpdateFile,
                    IsoManagement.BaseDirectoryPath + UIMessageFilePaths.originalUIMessageUK);
            }
            if (File.Exists(WiimmfiPaths.DEWiimmfiUIUpdateFile) && File.Exists(IsoManagement.BaseDirectoryPath + UIMessageFilePaths.originalUIMessageDE))
            {
                DiscIo.MoveFile(
                    WiimmfiPaths.DEWiimmfiUIUpdateFile,
                    IsoManagement.BaseDirectoryPath + UIMessageFilePaths.originalUIMessageDE);
            }
        }
    }
}