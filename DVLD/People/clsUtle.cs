using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    internal class clsUtle
    {
        public static string GenrateGUID()
        {
            return Guid.NewGuid().ToString();
        }
        public static string ReplaceFileWithGUID(string sourcefile)
        {
            string fileName = sourcefile;
            FileInfo fi = new FileInfo(fileName);
            string extn = fi.Extension;
            return GenrateGUID() + extn;
        }
        public static bool CreateFolderIfDoseNotExist(string folderPath)
        {
            try
            {
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public static bool CopyIamgeToProjectImagesFolder(ref string sourcefile)
        {
            string DestinationFolder = @"C:\Dvld-People-Image";

            if(!CreateFolderIfDoseNotExist(DestinationFolder))
            {
                return false;
            }

            string destinateionfile = DestinationFolder + ReplaceFileWithGUID(sourcefile);
            try
            {
                File.Copy(sourcefile, destinateionfile, true);

            }
            catch(IOException iox)
            {
                MessageBox.Show(iox.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            sourcefile = destinateionfile;
            return true;
        }
    }
}
