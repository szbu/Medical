using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalgorithmicsSeleniumTest.Utils
{
    public class FilesOperations
    {

        public static string GetDownloadedFileName()
        {
            var directory = new DirectoryInfo(AppConfig.DownloadPath);
            var downloadedFile = (from f in directory.GetFiles()
                                  orderby f.LastAccessTime descending
                                  select f).First();
            string downloadedFileName = downloadedFile.Name;
            return downloadedFileName;
        }

        public static void DeleteDownloadedFiles()
        {
            string[] files = Directory.GetFiles(AppConfig.DownloadPath);
            foreach (string file in files)
            {
                File.Delete(file);
            }
        }

        public static void ExtractFile(string fileName)
        {
            ZipFile.ExtractToDirectory(AppConfig.DownloadPath + @"\"+ fileName, AppConfig.DownloadPath);
        }

        public static bool CheckFileExistInDownloadFolder(string fileName)
        {
            return File.Exists(AppConfig.DownloadPath + @"\" + fileName);
        }
    }
}
