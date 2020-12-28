﻿using System.IO;

namespace CustomStreetManager.Utilities
{
    public static class DiscIO
    {
        public static void MoveFile(string newFilePath, string fileToReplacePath)
        {
            File.Delete(fileToReplacePath);
            File.Copy(newFilePath, fileToReplacePath, true);
        }
    }
}