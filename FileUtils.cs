using System;
using System.IO;
using System.Linq;

namespace RTD2_CSharp
{
    public static class FileUtils
    {
        // Get the home directory
        public static string GetHomeDirectory()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        }

        // Get the operating system
        public static string GetOperatingSystem()
        {
            return Environment.OSVersion.ToString();
        }

        // Get the username
        public static string GetUserName()
        {
            return Environment.UserName;
        }

        // Get the last opened file in a given directory
        public static string GetLastOpenedFile(string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
                return null;

            var mostRecentFile = new DirectoryInfo(directoryPath).GetFiles("*.json");
            var lastFile = mostRecentFile.OrderByDescending(f => f.LastWriteTime).FirstOrDefault();

            return lastFile?.FullName;  // mostRecentFile.FirstOrDefault()?.FullName;
        }
    }
}