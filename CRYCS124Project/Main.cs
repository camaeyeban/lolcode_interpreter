using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace lolcode_interpreter
{
    public partial class main_form : Form
    {
        
        public Buttons buttons = new Buttons();

        public main_form()
        {
            InitializeComponent();
        }

        // in menu, under File button, if the Open File is clicked, whatever the content of the file will be paste on wherever the cursor (blinking bar) is
        private void open_file_Click(object sender, EventArgs e)
        {
            // Opens a file explorer whose default location is C:\\Desktop\\ and has an option to either show .txt files or all files
            FileLoader fl = new FileLoader();
        }

        // in menu, under the File button, if the Exit is clicked, the application will then be closed
        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // in menu, under the About button, if the Program is clicked, another form will be displayed showing the program's and author's information
        private void about_program_Click(object sender, EventArgs e)
        {
            about_program box = new about_program();
            box.Show();
        }

    }
}
