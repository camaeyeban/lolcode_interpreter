namespace lolcode_interpreter
{
    partial class Buttons
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Button analyze;
            this.clear = new System.Windows.Forms.Button();
            this.reset = new System.Windows.Forms.Button();
            analyze = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // clear
            // 
            this.clear.BackColor = System.Drawing.Color.NavajoWhite;
            this.clear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.clear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clear.Location = new System.Drawing.Point(3, 3);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(75, 23);
            this.clear.TabIndex = 42;
            this.clear.Text = "Clear";
            this.clear.UseVisualStyleBackColor = false;
            this.clear.Click += new System.EventHandler(this.clear_Click);
            // 
            // reset
            // 
            this.reset.BackColor = System.Drawing.Color.IndianRed;
            this.reset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.reset.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.reset.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reset.Location = new System.Drawing.Point(84, 3);
            this.reset.Margin = new System.Windows.Forms.Padding(0);
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(75, 23);
            this.reset.TabIndex = 41;
            this.reset.Text = "Reset";
            this.reset.UseVisualStyleBackColor = false;
            this.reset.Click += new System.EventHandler(this.reset_Click);
            // 
            // analyze
            // 
            analyze.BackColor = System.Drawing.Color.SteelBlue;
            analyze.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            analyze.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            analyze.ForeColor = System.Drawing.SystemColors.ControlText;
            analyze.Location = new System.Drawing.Point(165, 3);
            analyze.Margin = new System.Windows.Forms.Padding(0);
            analyze.Name = "analyze";
            analyze.Size = new System.Drawing.Size(75, 23);
            analyze.TabIndex = 40;
            analyze.TabStop = false;
            analyze.Text = "Analyze";
            analyze.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            analyze.UseVisualStyleBackColor = false;
            analyze.Click += new System.EventHandler(this.analyze_Click);
            // 
            // Buttons
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.clear);
            this.Controls.Add(this.reset);
            this.Controls.Add(analyze);
            this.Name = "Buttons";
            this.Size = new System.Drawing.Size(243, 29);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button clear;
        private System.Windows.Forms.Button reset;
    }
}
