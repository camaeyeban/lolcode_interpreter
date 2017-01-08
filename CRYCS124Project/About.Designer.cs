namespace lolcode_interpreter
{
    partial class about_program
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(about_program));
            System.Windows.Forms.Button okButton;
            this.about_program_logo = new System.Windows.Forms.PictureBox();
            this.program_name = new System.Windows.Forms.Label();
            this.section = new System.Windows.Forms.Label();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.group_name = new System.Windows.Forms.Label();
            this.author_info = new System.Windows.Forms.TextBox();
            okButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.about_program_logo)).BeginInit();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // about_program_logo
            // 
            this.about_program_logo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.about_program_logo.Image = ((System.Drawing.Image)(resources.GetObject("about_program_logo.Image")));
            this.about_program_logo.Location = new System.Drawing.Point(3, 3);
            this.about_program_logo.Name = "about_program_logo";
            this.tableLayoutPanel.SetRowSpan(this.about_program_logo, 6);
            this.about_program_logo.Size = new System.Drawing.Size(155, 259);
            this.about_program_logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.about_program_logo.TabIndex = 12;
            this.about_program_logo.TabStop = false;
            // 
            // program_name
            // 
            this.program_name.Dock = System.Windows.Forms.DockStyle.Fill;
            this.program_name.Font = new System.Drawing.Font("28 Days Later", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.program_name.Location = new System.Drawing.Point(167, 0);
            this.program_name.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.program_name.MaximumSize = new System.Drawing.Size(0, 40);
            this.program_name.Name = "program_name";
            this.tableLayoutPanel.SetRowSpan(this.program_name, 2);
            this.program_name.Size = new System.Drawing.Size(318, 40);
            this.program_name.TabIndex = 19;
            this.program_name.Text = "LOLCODE INTERPRETER";
            this.program_name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // section
            // 
            this.section.Dock = System.Windows.Forms.DockStyle.Fill;
            this.section.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.section.Location = new System.Drawing.Point(167, 52);
            this.section.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.section.MaximumSize = new System.Drawing.Size(0, 30);
            this.section.Name = "section";
            this.section.Size = new System.Drawing.Size(318, 26);
            this.section.TabIndex = 21;
            this.section.Text = "CMSC 124 Project";
            this.section.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67F));
            this.tableLayoutPanel.Controls.Add(this.about_program_logo, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.program_name, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.section, 1, 2);
            this.tableLayoutPanel.Controls.Add(this.group_name, 1, 3);
            this.tableLayoutPanel.Controls.Add(this.author_info, 1, 4);
            this.tableLayoutPanel.Controls.Add(okButton, 1, 5);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(9, 9);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 6;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(488, 265);
            this.tableLayoutPanel.TabIndex = 1;
            // 
            // group_name
            // 
            this.group_name.Dock = System.Windows.Forms.DockStyle.Fill;
            this.group_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.group_name.Location = new System.Drawing.Point(167, 78);
            this.group_name.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.group_name.MaximumSize = new System.Drawing.Size(0, 17);
            this.group_name.Name = "group_name";
            this.group_name.Size = new System.Drawing.Size(318, 17);
            this.group_name.TabIndex = 22;
            this.group_name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // author_info
            // 
            this.author_info.BackColor = System.Drawing.Color.Gainsboro;
            this.author_info.Dock = System.Windows.Forms.DockStyle.Fill;
            this.author_info.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.author_info.Location = new System.Drawing.Point(167, 107);
            this.author_info.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
            this.author_info.Multiline = true;
            this.author_info.Name = "author_info";
            this.author_info.ReadOnly = true;
            this.author_info.Size = new System.Drawing.Size(318, 126);
            this.author_info.TabIndex = 23;
            this.author_info.TabStop = false;
            this.author_info.Text = "Created by:\r\n\r\nErica Mae M. Yeban\r\nBS Computer Science\r\nUniversity of the Philipp" +
    "ines\r\nLos Banos, Laguna";
            this.author_info.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // okButton
            // 
            okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            okButton.BackColor = System.Drawing.Color.LightBlue;
            okButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            okButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            okButton.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            okButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            okButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            okButton.Location = new System.Drawing.Point(410, 239);
            okButton.Name = "okButton";
            okButton.Size = new System.Drawing.Size(75, 23);
            okButton.TabIndex = 24;
            okButton.Text = "&OK";
            okButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            okButton.UseVisualStyleBackColor = false;
            okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // about_program
            // 
            this.AcceptButton = okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(506, 283);
            this.Controls.Add(this.tableLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "about_program";
            this.Padding = new System.Windows.Forms.Padding(9, 9, 9, 9);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About";
            ((System.ComponentModel.ISupportInitialize)(this.about_program_logo)).EndInit();
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox about_program_logo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Label program_name;
        private System.Windows.Forms.Label section;
        private System.Windows.Forms.Label group_name;
        private System.Windows.Forms.TextBox author_info;

    }
}
