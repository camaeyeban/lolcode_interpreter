namespace lolcode_interpreter
{
    partial class main_form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.file_menu = new System.Windows.Forms.ToolStripMenuItem();
            this.load_file = new System.Windows.Forms.ToolStripMenuItem();
            this.exit = new System.Windows.Forms.ToolStripMenuItem();
            this.about_menu = new System.Windows.Forms.ToolStripMenuItem();
            this.about_program = new System.Windows.Forms.ToolStripMenuItem();
            this.label4 = new System.Windows.Forms.Label();
            this.symbol_table = new System.Windows.Forms.DataGridView();
            this.symbol_table_var = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.symbol_table_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.symbol_table_value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.console_output = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lexemes = new System.Windows.Forms.DataGridView();
            this.lexemes_lexemes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lexemes_token_tags = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.code = new System.Windows.Forms.RichTextBox();
            this.buttons1 = new lolcode_interpreter.Buttons();
            this.line_numbers = new LineNumbers.LineNumbers_For_RichTextBox();
            this.lineNumbers_For_RichTextBox1 = new LineNumbers.LineNumbers_For_RichTextBox();
            this.menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.symbol_table)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lexemes)).BeginInit();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.Color.SteelBlue;
            this.menu.GripMargin = new System.Windows.Forms.Padding(2);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.file_menu,
            this.about_menu});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.menu.Size = new System.Drawing.Size(857, 25);
            this.menu.TabIndex = 40;
            this.menu.Text = "menuStrip1";
            // 
            // file_menu
            // 
            this.file_menu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.file_menu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.load_file,
            this.exit});
            this.file_menu.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.file_menu.ForeColor = System.Drawing.SystemColors.ControlText;
            this.file_menu.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.file_menu.Name = "file_menu";
            this.file_menu.Padding = new System.Windows.Forms.Padding(30, 0, 30, 0);
            this.file_menu.Size = new System.Drawing.Size(92, 21);
            this.file_menu.Text = "File";
            // 
            // load_file
            // 
            this.load_file.Name = "load_file";
            this.load_file.Size = new System.Drawing.Size(152, 22);
            this.load_file.Text = "Load File";
            this.load_file.Click += new System.EventHandler(this.open_file_Click);
            // 
            // exit
            // 
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(152, 22);
            this.exit.Text = "Exit";
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // about_menu
            // 
            this.about_menu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.about_program});
            this.about_menu.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.about_menu.ForeColor = System.Drawing.SystemColors.ControlText;
            this.about_menu.Name = "about_menu";
            this.about_menu.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.about_menu.Size = new System.Drawing.Size(90, 21);
            this.about_menu.Text = "About";
            // 
            // about_program
            // 
            this.about_program.Name = "about_program";
            this.about_program.Size = new System.Drawing.Size(152, 22);
            this.about_program.Text = "Program";
            this.about_program.Click += new System.EventHandler(this.about_program_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(448, 310);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 16);
            this.label4.TabIndex = 36;
            this.label4.Text = "Symbol Table";
            // 
            // symbol_table
            // 
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.symbol_table.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.symbol_table.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.symbol_table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.symbol_table.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.symbol_table_var,
            this.symbol_table_type,
            this.symbol_table_value});
            this.symbol_table.Location = new System.Drawing.Point(451, 328);
            this.symbol_table.Name = "symbol_table";
            this.symbol_table.ReadOnly = true;
            this.symbol_table.Size = new System.Drawing.Size(394, 231);
            this.symbol_table.TabIndex = 35;
            // 
            // symbol_table_var
            // 
            this.symbol_table_var.HeaderText = "Var";
            this.symbol_table_var.Name = "symbol_table_var";
            this.symbol_table_var.ReadOnly = true;
            this.symbol_table_var.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.symbol_table_var.Width = 115;
            // 
            // symbol_table_type
            // 
            this.symbol_table_type.HeaderText = "Type";
            this.symbol_table_type.Name = "symbol_table_type";
            this.symbol_table_type.ReadOnly = true;
            this.symbol_table_type.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.symbol_table_type.Width = 115;
            // 
            // symbol_table_value
            // 
            this.symbol_table_value.HeaderText = "Value";
            this.symbol_table_value.Name = "symbol_table_value";
            this.symbol_table_value.ReadOnly = true;
            this.symbol_table_value.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.symbol_table_value.Width = 115;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 310);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 16);
            this.label2.TabIndex = 34;
            this.label2.Text = "Console Output";
            // 
            // console_output
            // 
            this.console_output.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.console_output.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.console_output.ForeColor = System.Drawing.Color.White;
            this.console_output.Location = new System.Drawing.Point(12, 328);
            this.console_output.Name = "console_output";
            this.console_output.ReadOnly = true;
            this.console_output.Size = new System.Drawing.Size(423, 231);
            this.console_output.TabIndex = 33;
            this.console_output.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(448, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 16);
            this.label3.TabIndex = 32;
            this.label3.Text = "Lexemes";
            // 
            // lexemes
            // 
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lexemes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.lexemes.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.lexemes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.lexemes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.lexemes_lexemes,
            this.lexemes_token_tags});
            this.lexemes.Location = new System.Drawing.Point(451, 54);
            this.lexemes.Name = "lexemes";
            this.lexemes.ReadOnly = true;
            this.lexemes.Size = new System.Drawing.Size(394, 231);
            this.lexemes.TabIndex = 31;
            // 
            // lexemes_lexemes
            // 
            this.lexemes_lexemes.HeaderText = "Lexemes";
            this.lexemes_lexemes.Name = "lexemes_lexemes";
            this.lexemes_lexemes.ReadOnly = true;
            this.lexemes_lexemes.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // lexemes_token_tags
            // 
            this.lexemes_token_tags.HeaderText = "Token Tags";
            this.lexemes_token_tags.Name = "lexemes_token_tags";
            this.lexemes_token_tags.ReadOnly = true;
            this.lexemes_token_tags.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.lexemes_token_tags.Width = 250;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 16);
            this.label1.TabIndex = 30;
            this.label1.Text = "Code";
            // 
            // code
            // 
            this.code.AcceptsTab = true;
            this.code.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.code.Location = new System.Drawing.Point(39, 54);
            this.code.Name = "code";
            this.code.Size = new System.Drawing.Size(396, 231);
            this.code.TabIndex = 29;
            this.code.Text = "";
            // 
            // buttons1
            // 
            this.buttons1.Location = new System.Drawing.Point(195, 285);
            this.buttons1.Name = "buttons1";
            this.buttons1.Size = new System.Drawing.Size(243, 29);
            this.buttons1.TabIndex = 43;
            // 
            // line_numbers
            // 
            this.line_numbers._SeeThroughMode_ = false;
            this.line_numbers.AutoSizing = true;
            this.line_numbers.BackgroundGradient_AlphaColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.line_numbers.BackgroundGradient_BetaColor = System.Drawing.Color.LightSteelBlue;
            this.line_numbers.BackgroundGradient_Direction = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.line_numbers.BorderLines_Color = System.Drawing.Color.SlateGray;
            this.line_numbers.BorderLines_Style = System.Drawing.Drawing2D.DashStyle.Dot;
            this.line_numbers.BorderLines_Thickness = 1F;
            this.line_numbers.DockSide = LineNumbers.LineNumbers_For_RichTextBox.LineNumberDockSide.Left;
            this.line_numbers.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.line_numbers.GridLines_Color = System.Drawing.Color.SlateGray;
            this.line_numbers.GridLines_Style = System.Drawing.Drawing2D.DashStyle.Dot;
            this.line_numbers.GridLines_Thickness = 1F;
            this.line_numbers.LineNrs_Alignment = System.Drawing.ContentAlignment.TopRight;
            this.line_numbers.LineNrs_AntiAlias = true;
            this.line_numbers.LineNrs_AsHexadecimal = false;
            this.line_numbers.LineNrs_ClippedByItemRectangle = true;
            this.line_numbers.LineNrs_LeadingZeroes = true;
            this.line_numbers.LineNrs_Offset = new System.Drawing.Size(0, 0);
            this.line_numbers.Location = new System.Drawing.Point(15, 54);
            this.line_numbers.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.line_numbers.MarginLines_Color = System.Drawing.Color.SlateGray;
            this.line_numbers.MarginLines_Side = LineNumbers.LineNumbers_For_RichTextBox.LineNumberDockSide.Right;
            this.line_numbers.MarginLines_Style = System.Drawing.Drawing2D.DashStyle.Solid;
            this.line_numbers.MarginLines_Thickness = 1F;
            this.line_numbers.Name = "line_numbers";
            this.line_numbers.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.line_numbers.ParentRichTextBox = this.code;
            this.line_numbers.Show_BackgroundGradient = true;
            this.line_numbers.Show_BorderLines = false;
            this.line_numbers.Show_GridLines = false;
            this.line_numbers.Show_LineNrs = true;
            this.line_numbers.Show_MarginLines = false;
            this.line_numbers.Size = new System.Drawing.Size(23, 231);
            this.line_numbers.TabIndex = 42;
            // 
            // lineNumbers_For_RichTextBox1
            // 
            this.lineNumbers_For_RichTextBox1._SeeThroughMode_ = false;
            this.lineNumbers_For_RichTextBox1.AutoSizing = true;
            this.lineNumbers_For_RichTextBox1.BackgroundGradient_AlphaColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lineNumbers_For_RichTextBox1.BackgroundGradient_BetaColor = System.Drawing.Color.LightSteelBlue;
            this.lineNumbers_For_RichTextBox1.BackgroundGradient_Direction = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.lineNumbers_For_RichTextBox1.BorderLines_Color = System.Drawing.Color.SlateGray;
            this.lineNumbers_For_RichTextBox1.BorderLines_Style = System.Drawing.Drawing2D.DashStyle.Dot;
            this.lineNumbers_For_RichTextBox1.BorderLines_Thickness = 1F;
            this.lineNumbers_For_RichTextBox1.DockSide = LineNumbers.LineNumbers_For_RichTextBox.LineNumberDockSide.Left;
            this.lineNumbers_For_RichTextBox1.GridLines_Color = System.Drawing.Color.SlateGray;
            this.lineNumbers_For_RichTextBox1.GridLines_Style = System.Drawing.Drawing2D.DashStyle.Dot;
            this.lineNumbers_For_RichTextBox1.GridLines_Thickness = 1F;
            this.lineNumbers_For_RichTextBox1.LineNrs_Alignment = System.Drawing.ContentAlignment.TopRight;
            this.lineNumbers_For_RichTextBox1.LineNrs_AntiAlias = true;
            this.lineNumbers_For_RichTextBox1.LineNrs_AsHexadecimal = false;
            this.lineNumbers_For_RichTextBox1.LineNrs_ClippedByItemRectangle = true;
            this.lineNumbers_For_RichTextBox1.LineNrs_LeadingZeroes = true;
            this.lineNumbers_For_RichTextBox1.LineNrs_Offset = new System.Drawing.Size(0, 0);
            this.lineNumbers_For_RichTextBox1.Location = new System.Drawing.Point(-42, 54);
            this.lineNumbers_For_RichTextBox1.Margin = new System.Windows.Forms.Padding(0);
            this.lineNumbers_For_RichTextBox1.MarginLines_Color = System.Drawing.Color.SlateGray;
            this.lineNumbers_For_RichTextBox1.MarginLines_Side = LineNumbers.LineNumbers_For_RichTextBox.LineNumberDockSide.Right;
            this.lineNumbers_For_RichTextBox1.MarginLines_Style = System.Drawing.Drawing2D.DashStyle.Solid;
            this.lineNumbers_For_RichTextBox1.MarginLines_Thickness = 1F;
            this.lineNumbers_For_RichTextBox1.Name = "lineNumbers_For_RichTextBox1";
            this.lineNumbers_For_RichTextBox1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.lineNumbers_For_RichTextBox1.ParentRichTextBox = null;
            this.lineNumbers_For_RichTextBox1.Show_BackgroundGradient = true;
            this.lineNumbers_For_RichTextBox1.Show_BorderLines = true;
            this.lineNumbers_For_RichTextBox1.Show_GridLines = true;
            this.lineNumbers_For_RichTextBox1.Show_LineNrs = true;
            this.lineNumbers_For_RichTextBox1.Show_MarginLines = true;
            this.lineNumbers_For_RichTextBox1.Size = new System.Drawing.Size(17, 176);
            this.lineNumbers_For_RichTextBox1.TabIndex = 41;
            // 
            // main_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(857, 571);
            this.Controls.Add(this.buttons1);
            this.Controls.Add(this.line_numbers);
            this.Controls.Add(this.lineNumbers_For_RichTextBox1);
            this.Controls.Add(this.menu);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.symbol_table);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.console_output);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lexemes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.code);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "main_form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LOLCode Interpreter";
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.symbol_table)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lexemes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem file_menu;
        private System.Windows.Forms.ToolStripMenuItem load_file;
        private System.Windows.Forms.ToolStripMenuItem exit;
        private System.Windows.Forms.ToolStripMenuItem about_menu;
        private System.Windows.Forms.ToolStripMenuItem about_program;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn symbol_table_var;
        private System.Windows.Forms.DataGridViewTextBoxColumn symbol_table_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn symbol_table_value;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn lexemes_lexemes;
        private System.Windows.Forms.DataGridViewTextBoxColumn lexemes_token_tags;
        private System.Windows.Forms.Label label1;
        private LineNumbers.LineNumbers_For_RichTextBox lineNumbers_For_RichTextBox1;
        private LineNumbers.LineNumbers_For_RichTextBox line_numbers;
        protected internal System.Windows.Forms.DataGridView lexemes;
        protected internal System.Windows.Forms.DataGridView symbol_table;
        protected internal System.Windows.Forms.RichTextBox console_output;
        private Buttons buttons1;
        protected internal System.Windows.Forms.RichTextBox code;
    }
}

