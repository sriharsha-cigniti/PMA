using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.IO;
using System.Windows.Forms;
//using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.Linq;

namespace AUT.Selenium.ApplicationSpecific.PMA.Pages
{
    public class ExportSpreadsheet
    {
        string FilePath;
        string DownloadPath;

            public ExportSpreadsheet(string FileName, string DownloadPath)
            {
                this.FilePath = FileFullPath(FileName, DownloadPath);
            }
       

        public bool FileExists()
        {
            bool FileFound = false;
            try
            {
                FileFound = File.Exists(FilePath);
                FileFound = true;
            }
            catch (Exception ex)
            {
                FileFound = false;
            }
            return FileFound;

        }

        public string FileFullPath(string partialName, string DownloadPath)
        {
            string fullName = string.Empty;
            DirectoryInfo hdDirectoryInWhichToSearch = new DirectoryInfo(DownloadPath);
            var filesInDir = hdDirectoryInWhichToSearch.GetFiles(partialName + "*");
            if (filesInDir.Length > 0)
            {
                FileInfo foundFile = filesInDir.OrderByDescending(f => f.LastWriteTime).First();
                fullName = foundFile.FullName;
            }
            return fullName;
        }

        public bool FileDelete()
        {
            bool fileDelete = true;
            File.Delete(FilePath);
            
            return fileDelete;
        }




    }
}
