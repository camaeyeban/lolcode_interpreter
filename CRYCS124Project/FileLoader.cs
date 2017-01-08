using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace lolcode_interpreter
{
    class FileLoader
    {
        // Opens a file explorer whose default location is C:\\Desktop\\ and has an option to either show .txt files or all files
            OpenFileDialog open_file_dialog = new OpenFileDialog();

            public FileLoader()
            {
                open_file_dialog.InitialDirectory = "c:\\Dektop\\";
                open_file_dialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                open_file_dialog.FilterIndex = 2;
                open_file_dialog.RestoreDirectory = true;

                if (open_file_dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Appends the content of the file to the code's rich text box line by line, then closes the file after the process
                        String tempReader;
                        System.IO.StreamReader file = new System.IO.StreamReader(open_file_dialog.FileName);
                        while ((tempReader = file.ReadLine()) != null)
                        {
                            Program.main.code.AppendText(tempReader + "\n");
                        }
                        file.Close();
                    }
                    // Displays a message if an error occured while reading the file
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                    }
                }
            }
    }
}
