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
                case "1" when !File.Exists(newMapPath) || !File.Exists(_discPath + MapFilePaths.volcano0FilePath):
                    return;
                case "1":
                    DiscIo.MoveFile(newMapPath, _discPath + MapFilePaths.volcano0FilePath);
                    break;
                case "2" when !File.Exists(newMapPath) || !File.Exists(_discPath + MapFilePaths.volcano1FilePath):
                    return;
                case "2":
                    DiscIo.MoveFile(newMapPath, _discPath + MapFilePaths.volcano1FilePath);
                    break;
            }
        }

        private void ReplaceDynamicColossus(ListViewItem item, string newMapPath)
        {
            var mapNumber = item.SubItems[4].Text;
            switch (mapNumber)
            {
                case "1" when !File.Exists(newMapPath) || !File.Exists(_discPath + MapFilePaths.majinzo0FilePath):
                    return;
                case "1":
                    DiscIo.MoveFile(newMapPath, _discPath + MapFilePaths.majinzo0FilePath);
                    break;
                case "2" when !File.Exists(newMapPath) || !File.Exists(_discPath + MapFilePaths.majinzo1FilePath):
                    return;
                case "2":
                    DiscIo.MoveFile(newMapPath, _discPath + MapFilePaths.majinzo1FilePath);
                    break;
            }
        }

        private void ReplaceDynamicObservatory(ListViewItem item, string newMapPath)
        {
            var mapNumber = item.SubItems[4].Text;
            switch (mapNumber)
            {
                case "1" when !File.Exists(newMapPath) || !File.Exists(_discPath + MapFilePaths.angel0FilePath):
                    return;
                case "1":
                    DiscIo.MoveFile(newMapPath, _discPath + MapFilePaths.angel0FilePath);
                    break;
                case "2" when !File.Exists(newMapPath) || !File.Exists(_discPath + MapFilePaths.angel1FilePath):
                    return;
                case "2":
                    DiscIo.MoveFile(newMapPath, _discPath + MapFilePaths.angel1FilePath);
                    break;
                case "3" when !File.Exists(newMapPath) || !File.Exists(_discPath + MapFilePaths.angel2FilePath):
                    return;
                case "3":
                    DiscIo.MoveFile(newMapPath, _discPath + MapFilePaths.angel2FilePath);
                    break;
                case "4" when !File.Exists(newMapPath) || !File.Exists(_discPath + MapFilePaths.angel3FilePath):
                    return;
                case "4":
                    DiscIo.MoveFile(newMapPath, _discPath + MapFilePaths.angel3FilePath);
                    break;
            }
        }

        private void ReplaceCastleTrodain(string newMapPath)
        {
            if (!File.Exists(newMapPath) || !File.Exists(_discPath + MapFilePaths.torodeenFilePath)) return;
            DiscIo.MoveFile(newMapPath, _discPath + MapFilePaths.torodeenFilePath);
        }

        private void ReplaceSingleObservatory(string newMapPath)
        {
            if (!File.Exists(newMapPath) || !File.Exists(_discPath + MapFilePaths.angel0FilePath)) return;
            DiscIo.MoveFile(newMapPath, _discPath + MapFilePaths.angel0FilePath);
        }

        private void ReplaceGhostShip(string newMapPath)
        {
            if (!File.Exists(newMapPath) || !File.Exists(_discPath + MapFilePaths.yuureisenFilePath)) return;
            DiscIo.MoveFile(newMapPath, _discPath + MapFilePaths.yuureisenFilePath);
        }

        private void ReplaceSlimenia(string newMapPath)
        {
            if (!File.Exists(newMapPath) || !File.Exists(_discPath + MapFilePaths.slabbakatouFilePath)) return;
            DiscIo.MoveFile(newMapPath, _discPath + MapFilePaths.slabbakatouFilePath);
        }

        private void ReplaceStaticMtMagmageddon(string newMapPath)
        {
            if (!File.Exists(newMapPath) || !File.Exists(_discPath + MapFilePaths.volcano0FilePath)) return;
            DiscIo.MoveFile(newMapPath, _discPath + MapFilePaths.volcano0FilePath);
        }

        private void ReplaceRobbinHoodRuins(string newMapPath)
        {
            if (!File.Exists(newMapPath) || !File.Exists(_discPath + MapFilePaths.kandataFilePath)) return;
            DiscIo.MoveFile(newMapPath, _discPath + MapFilePaths.kandataFilePath);
        }

        private void ReplacePeachsCastle(string newMapPath)
        {
            if (!File.Exists(newMapPath) || !File.Exists(_discPath + MapFilePaths.hidariFilePath)) return;
            DiscIo.MoveFile(newMapPath, _discPath + MapFilePaths.hidariFilePath);
        }

        private void ReplaceDelfinoPlaza(string newMapPath)
        {
            if (!File.Exists(newMapPath) || !File.Exists(_discPath + MapFilePaths.dolpicFilePath)) return;
            DiscIo.MoveFile(newMapPath, _discPath + MapFilePaths.dolpicFilePath);
        }

        private void ReplaceYoshisIsland(string newMapPath)
        {
            if (!File.Exists(newMapPath) || !File.Exists(_discPath + MapFilePaths.yosshiFilePath)) return;
            DiscIo.MoveFile(newMapPath, _discPath + MapFilePaths.yosshiFilePath);
        }

        private void ReplaceMarioCircuit(string newMapPath)
        {
            if (!File.Exists(newMapPath) || !File.Exists(_discPath + MapFilePaths.circuitFilePath)) return;
            DiscIo.MoveFile(newMapPath, _discPath + MapFilePaths.circuitFilePath);
        }

        private void ReplaceStarshipMario(string newMapPath)
        {
            if (!File.Exists(newMapPath) || !File.Exists(_discPath + MapFilePaths.mooncityFilePath)) return;
            DiscIo.MoveFile(newMapPath, _discPath + MapFilePaths.mooncityFilePath);
        }

        private void ReplaceMarioStadium(string newMapPath)
        {
            if (!File.Exists(newMapPath) || !File.Exists(_discPath + MapFilePaths.stadiumFilePath)) return;
            DiscIo.MoveFile(newMapPath, _discPath + MapFilePaths.stadiumFilePath);
        }

        private void ReplaceAlltradesAbbey(string newMapPath)
        {
            if (!File.Exists(newMapPath) || !File.Exists(_discPath + MapFilePaths.dahmaFilePath)) return;
            DiscIo.MoveFile(newMapPath, _discPath + MapFilePaths.dahmaFilePath);
        }

        private void ReplaceSingleColossus(string newMapPath)
        {
            if (!File.Exists(newMapPath) || !File.Exists(_discPath + MapFilePaths.majinzo0FilePath)) return;
            DiscIo.MoveFile(newMapPath, _discPath + MapFilePaths.majinzo0FilePath);
        }

        private void ReplaceGoodEggGalaxy(string newMapPath)
        {
            if (!File.Exists(newMapPath) || !File.Exists(_discPath + MapFilePaths.colonyFilePath)) return;
            DiscIo.MoveFile(newMapPath, _discPath + MapFilePaths.colonyFilePath);
        }

        private void ReplaceBowsersCastle(string newMapPath)
        {
            if (!File.Exists(newMapPath) || !File.Exists(_discPath + MapFilePaths.koopaFilePath)) return;
            DiscIo.MoveFile(newMapPath, _discPath + MapFilePaths.koopaFilePath);
        }

        private void ReplaceSmb(string newMapPath)
        {
            if (!File.Exists(newMapPath) || !File.Exists(_discPath + MapFilePaths.marioFilePath)) return;
            DiscIo.MoveFile(newMapPath, _discPath + MapFilePaths.marioFilePath);
        }

        private void ReplaceAlefgard(string newMapPath)
        {
            if (!File.Exists(newMapPath) || !File.Exists(_discPath + MapFilePaths.alephgardFilePath)) return;
            DiscIo.MoveFile(newMapPath, _discPath + MapFilePaths.alephgardFilePath);
        }
    }
}