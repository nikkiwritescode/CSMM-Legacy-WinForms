using System.IO;
using System.Windows.Forms;
using CustomStreetManager.FilePaths;
using CustomStreetManager.Panels.MainWindow;
using CustomStreetManager.Utilities;

namespace CustomStreetManager.Patches
{
    public class MapReplacement
    {
        private MainWindow _mainWindow;

        public MapReplacement(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
        }

        private string _discPath = "";

        public void ReplaceMaps()
        {

            foreach (ListViewItem item in _mainWindow.listOfMapsToPatchIn.Items)
            {
                _discPath = IsoManagement.BaseDirectoryPath;
                var newMapPath = item.SubItems[2].Text;
                var mapToReplace = item.SubItems[1].Text;

                switch (item.SubItems[1].Text)
                {
                    case "*The Observatory" when item.SubItems[3].Text == "true":
                        ReplaceDynamicObservatory(item, item.SubItems[2].Text);
                        break;
                    case "*Colossus" when item.SubItems[3].Text == "true":
                        ReplaceDynamicColossus(item, item.SubItems[2].Text);
                        break;
                    case "*Mt. Magmageddon" when item.SubItems[3].Text == "true":
                        ReplaceDynamicMtMagmageddon(item, item.SubItems[2].Text);
                        break;
                }

                switch (mapToReplace) //Single-File Maps
                {
                    case "Castle Trodain":
                        ReplaceCastleTrodain(newMapPath);
                        break;
                    case "The Observatory":
                        ReplaceSingleObservatory(newMapPath);
                        break;
                    case "Ghost Ship":
                        ReplaceGhostShip(newMapPath);
                        break;
                    case "Slimenia":
                        ReplaceSlimenia(newMapPath);
                        break;
                    case "Mt. Magmageddon":
                        ReplaceStaticMtMagmageddon(newMapPath);
                        break;
                    case "Robbin' Hood Ruins":
                        ReplaceRobbinHoodRuins(newMapPath);
                        break;
                    case "Peach's Castle":
                        ReplacePeachsCastle(newMapPath);
                        break;
                    case "Delfino Plaza":
                        ReplaceDelfinoPlaza(newMapPath);
                        break;
                    case "Yoshi's Island":
                        ReplaceYoshisIsland(newMapPath);
                        break;
                    case "Mario Circuit":
                        ReplaceMarioCircuit(newMapPath);
                        break;
                    case "Starship Mario":
                        ReplaceStarshipMario(newMapPath);
                        break;
                    case "Mario Stadium":
                        ReplaceMarioStadium(newMapPath);
                        break;
                    case "Alltrades Abbey":
                        ReplaceAlltradesAbbey(newMapPath);
                        break;
                    case "Colossus":
                        ReplaceSingleColossus(newMapPath);
                        break;
                    case "Good Egg Galaxy":
                        ReplaceGoodEggGalaxy(newMapPath);
                        break;
                    case "Bowser's Castle":
                        ReplaceBowsersCastle(newMapPath);
                        break;
                    case "Super Mario Bros.":
                        ReplaceSmb(newMapPath);
                        break;
                    case "Alefgard":
                        ReplaceAlefgard(newMapPath);
                        break;
                }
            }
        }

        private void ReplaceDynamicMtMagmageddon(ListViewItem item, string newMapPath)
        {
            var mapNumber = item.SubItems[4].Text;
            switch (mapNumber)
            {
                case "1" when !File.Exists(newMapPath) || !File.Exists(_discPath + MapFilePaths.MtMag1):
                    return;
                case "1":
                    DiscIo.MoveFile(newMapPath, _discPath + MapFilePaths.MtMag1);
                    break;
                case "2" when !File.Exists(newMapPath) || !File.Exists(_discPath + MapFilePaths.MtMag2):
                    return;
                case "2":
                    DiscIo.MoveFile(newMapPath, _discPath + MapFilePaths.MtMag2);
                    break;
            }
        }

        private void ReplaceDynamicColossus(ListViewItem item, string newMapPath)
        {
            var mapNumber = item.SubItems[4].Text;
            switch (mapNumber)
            {
                case "1" when !File.Exists(newMapPath) || !File.Exists(_discPath + MapFilePaths.Colossus1):
                    return;
                case "1":
                    DiscIo.MoveFile(newMapPath, _discPath + MapFilePaths.Colossus1);
                    break;
                case "2" when !File.Exists(newMapPath) || !File.Exists(_discPath + MapFilePaths.Colossus2):
                    return;
                case "2":
                    DiscIo.MoveFile(newMapPath, _discPath + MapFilePaths.Colossus2);
                    break;
            }
        }

        private void ReplaceDynamicObservatory(ListViewItem item, string newMapPath)
        {
            var mapNumber = item.SubItems[4].Text;
            switch (mapNumber)
            {
                case "1" when !File.Exists(newMapPath) || !File.Exists(_discPath + MapFilePaths.Observatory1):
                    return;
                case "1":
                    DiscIo.MoveFile(newMapPath, _discPath + MapFilePaths.Observatory1);
                    break;
                case "2" when !File.Exists(newMapPath) || !File.Exists(_discPath + MapFilePaths.Observatory2):
                    return;
                case "2":
                    DiscIo.MoveFile(newMapPath, _discPath + MapFilePaths.Observatory2);
                    break;
                case "3" when !File.Exists(newMapPath) || !File.Exists(_discPath + MapFilePaths.Observatory3):
                    return;
                case "3":
                    DiscIo.MoveFile(newMapPath, _discPath + MapFilePaths.Observatory3);
                    break;
                case "4" when !File.Exists(newMapPath) || !File.Exists(_discPath + MapFilePaths.Observatory4):
                    return;
                case "4":
                    DiscIo.MoveFile(newMapPath, _discPath + MapFilePaths.Observatory4);
                    break;
            }
        }

        private void ReplaceCastleTrodain(string newMapPath)
        {
            if (!File.Exists(newMapPath) || !File.Exists(_discPath + MapFilePaths.CastleTrodain)) return;
            DiscIo.MoveFile(newMapPath, _discPath + MapFilePaths.CastleTrodain);
        }

        private void ReplaceSingleObservatory(string newMapPath)
        {
            if (!File.Exists(newMapPath) || !File.Exists(_discPath + MapFilePaths.Observatory1)) return;
            DiscIo.MoveFile(newMapPath, _discPath + MapFilePaths.Observatory1);
        }

        private void ReplaceGhostShip(string newMapPath)
        {
            if (!File.Exists(newMapPath) || !File.Exists(_discPath + MapFilePaths.GhostShip)) return;
            DiscIo.MoveFile(newMapPath, _discPath + MapFilePaths.GhostShip);
        }

        private void ReplaceSlimenia(string newMapPath)
        {
            if (!File.Exists(newMapPath) || !File.Exists(_discPath + MapFilePaths.Slimenia)) return;
            DiscIo.MoveFile(newMapPath, _discPath + MapFilePaths.Slimenia);
        }

        private void ReplaceStaticMtMagmageddon(string newMapPath)
        {
            if (!File.Exists(newMapPath) || !File.Exists(_discPath + MapFilePaths.MtMag1)) return;
            DiscIo.MoveFile(newMapPath, _discPath + MapFilePaths.MtMag1);
        }

        private void ReplaceRobbinHoodRuins(string newMapPath)
        {
            if (!File.Exists(newMapPath) || !File.Exists(_discPath + MapFilePaths.RobbinHoodRuins)) return;
            DiscIo.MoveFile(newMapPath, _discPath + MapFilePaths.RobbinHoodRuins);
        }

        private void ReplacePeachsCastle(string newMapPath)
        {
            if (!File.Exists(newMapPath) || !File.Exists(_discPath + MapFilePaths.PeachsCastle)) return;
            DiscIo.MoveFile(newMapPath, _discPath + MapFilePaths.PeachsCastle);
        }

        private void ReplaceDelfinoPlaza(string newMapPath)
        {
            if (!File.Exists(newMapPath) || !File.Exists(_discPath + MapFilePaths.DelfinoPlaza)) return;
            DiscIo.MoveFile(newMapPath, _discPath + MapFilePaths.DelfinoPlaza);
        }

        private void ReplaceYoshisIsland(string newMapPath)
        {
            if (!File.Exists(newMapPath) || !File.Exists(_discPath + MapFilePaths.YoshisIsland)) return;
            DiscIo.MoveFile(newMapPath, _discPath + MapFilePaths.YoshisIsland);
        }

        private void ReplaceMarioCircuit(string newMapPath)
        {
            if (!File.Exists(newMapPath) || !File.Exists(_discPath + MapFilePaths.MarioCircuit)) return;
            DiscIo.MoveFile(newMapPath, _discPath + MapFilePaths.MarioCircuit);
        }

        private void ReplaceStarshipMario(string newMapPath)
        {
            if (!File.Exists(newMapPath) || !File.Exists(_discPath + MapFilePaths.StarshipMario)) return;
            DiscIo.MoveFile(newMapPath, _discPath + MapFilePaths.StarshipMario);
        }

        private void ReplaceMarioStadium(string newMapPath)
        {
            if (!File.Exists(newMapPath) || !File.Exists(_discPath + MapFilePaths.MarioStadium)) return;
            DiscIo.MoveFile(newMapPath, _discPath + MapFilePaths.MarioStadium);
        }

        private void ReplaceAlltradesAbbey(string newMapPath)
        {
            if (!File.Exists(newMapPath) || !File.Exists(_discPath + MapFilePaths.AlltradesAbbey)) return;
            DiscIo.MoveFile(newMapPath, _discPath + MapFilePaths.AlltradesAbbey);
        }

        private void ReplaceSingleColossus(string newMapPath)
        {
            if (!File.Exists(newMapPath) || !File.Exists(_discPath + MapFilePaths.Colossus1)) return;
            DiscIo.MoveFile(newMapPath, _discPath + MapFilePaths.Colossus1);
        }

        private void ReplaceGoodEggGalaxy(string newMapPath)
        {
            if (!File.Exists(newMapPath) || !File.Exists(_discPath + MapFilePaths.GoodEggGalaxy)) return;
            DiscIo.MoveFile(newMapPath, _discPath + MapFilePaths.GoodEggGalaxy);
        }

        private void ReplaceBowsersCastle(string newMapPath)
        {
            if (!File.Exists(newMapPath) || !File.Exists(_discPath + MapFilePaths.BowsersCastle)) return;
            DiscIo.MoveFile(newMapPath, _discPath + MapFilePaths.BowsersCastle);
        }

        private void ReplaceSmb(string newMapPath)
        {
            if (!File.Exists(newMapPath) || !File.Exists(_discPath + MapFilePaths.SMB)) return;
            DiscIo.MoveFile(newMapPath, _discPath + MapFilePaths.SMB);
        }

        private void ReplaceAlefgard(string newMapPath)
        {
            if (!File.Exists(newMapPath) || !File.Exists(_discPath + MapFilePaths.Alefgard)) return;
            DiscIo.MoveFile(newMapPath, _discPath + MapFilePaths.Alefgard);
        }
    }
}