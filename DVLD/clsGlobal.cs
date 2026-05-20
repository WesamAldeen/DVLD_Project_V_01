using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_BuisnessLayer;

namespace DVLD
{
    internal static class clsGlobal
    {
        public static clsUsers CurrentUser;

        public static void StyleDataGridView(DataGridView dgv)
        {
            dgv.EnableHeadersVisualStyles = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.BackgroundColor = Color.White;
            dgv.RowHeadersVisible = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.BorderStyle = BorderStyle.None;
            dgv.GridColor = Color.FromArgb(245, 245, 245);

            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.ColumnHeadersHeight = 30;

            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            // Pink color
            dgv.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#fd79a8");

            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(80, 80, 80);
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            DataGridViewCellStyle rowStyle = new DataGridViewCellStyle();
            rowStyle.BackColor = Color.White;
            rowStyle.ForeColor = Color.FromArgb(64, 64, 64);
            rowStyle.Font = new Font("Segoe UI", 8);
            rowStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            Color lightSelection = Color.FromArgb(245, 240, 255);
            rowStyle.SelectionBackColor = lightSelection;
            rowStyle.SelectionForeColor = Color.Black;

            dgv.DefaultCellStyle = rowStyle;

            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(252, 251, 255);
            dgv.AlternatingRowsDefaultCellStyle.SelectionBackColor = lightSelection;
            dgv.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.Black;

            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = dgv.ColumnHeadersDefaultCellStyle.BackColor;
            dgv.DefaultCellStyle.SelectionBackColor = lightSelection;
            dgv.RowTemplate.Height = 30;
        }
        public static bool RememberUsernameAndPassword(string Username, string Password)
        {
            try
            {
                //this will get the current project directory folder.
                string currentDirectory = System.IO.Directory.GetCurrentDirectory();
                // Define the path to the text file where you want to save the data
                string filePath = currentDirectory + "\\data.txt";
                //incase the username is empty, delete the file
                if (Username == "" && File.Exists(filePath))
                {
                    File.Delete(filePath);
                    return true;
                }
                // concatonate username and passwrod with seperator.
                string dataToSave = Username + "#//#" + Password;

                // Create a StreamWriter to write to the file
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    // Write the data to the file
                    writer.WriteLine(dataToSave);

                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                return false;
            }
        }
        public static bool GetStoredCredential(ref string Username, ref string Password)
        {
            //this will get the stored username and password and will return true if found and false if not found.
            try
            {
                //gets the current project's directory
                string currentDirectory = System.IO.Directory.GetCurrentDirectory();
                // Path for the file that contains the credential.
                string filePath = currentDirectory + "\\data.txt";
                // Check if the file exists before attempting to read it
                if (File.Exists(filePath))
                {
                    // Create a StreamReader to read from the file
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        // Read data line by line until the end of the file
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            Console.WriteLine(line); // Output each line of data to the console
                            string[] result = line.Split(new string[] { "#//#" }, StringSplitOptions.None);

                            Username = result[0];
                            Password = result[1];
                        }
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                return false;
            }
        }
    }
    public class clsFormat
    {
        public static string DateToShort(DateTime Dt1)
        {
            return Dt1.ToString("dd/MMM/yyyy");
        }

    }
}
