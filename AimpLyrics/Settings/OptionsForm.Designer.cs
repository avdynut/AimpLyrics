namespace AimpLyrics.Settings
{
    partial class OptionsForm
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
            this.RestoreWindowHeightCheckBox = new System.Windows.Forms.CheckBox();
            this.OpenWindowOnInitCheckBox = new System.Windows.Forms.CheckBox();
            this.backgroundGroupBox = new System.Windows.Forms.GroupBox();
            this.optionsGroupBox = new System.Windows.Forms.GroupBox();
            this.backgroundGroupBox.SuspendLayout();
            this.optionsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // RestoreWindowHeightCheckBox
            // 
            this.RestoreWindowHeightCheckBox.AutoSize = true;
            this.RestoreWindowHeightCheckBox.Location = new System.Drawing.Point(6, 43);
            this.RestoreWindowHeightCheckBox.Name = "RestoreWindowHeightCheckBox";
            this.RestoreWindowHeightCheckBox.Size = new System.Drawing.Size(167, 17);
            this.RestoreWindowHeightCheckBox.TabIndex = 1;
            this.RestoreWindowHeightCheckBox.Text = "Remember last window height";
            this.RestoreWindowHeightCheckBox.UseVisualStyleBackColor = true;
            // 
            // OpenWindowOnInitCheckBox
            // 
            this.OpenWindowOnInitCheckBox.AutoSize = true;
            this.OpenWindowOnInitCheckBox.Location = new System.Drawing.Point(6, 19);
            this.OpenWindowOnInitCheckBox.Name = "OpenWindowOnInitCheckBox";
            this.OpenWindowOnInitCheckBox.Size = new System.Drawing.Size(186, 17);
            this.OpenWindowOnInitCheckBox.TabIndex = 0;
            this.OpenWindowOnInitCheckBox.Text = "Open lyrics window on player start";
            this.OpenWindowOnInitCheckBox.UseVisualStyleBackColor = true;
            // 
            // backgroundGroupBox
            // 
            this.backgroundGroupBox.Controls.Add(this.optionsGroupBox);
            this.backgroundGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.backgroundGroupBox.Location = new System.Drawing.Point(0, 0);
            this.backgroundGroupBox.Margin = new System.Windows.Forms.Padding(0);
            this.backgroundGroupBox.Name = "backgroundGroupBox";
            this.backgroundGroupBox.Size = new System.Drawing.Size(570, 400);
            this.backgroundGroupBox.TabIndex = 3;
            this.backgroundGroupBox.TabStop = false;
            // 
            // optionsGroupBox
            // 
            this.optionsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.optionsGroupBox.Controls.Add(this.OpenWindowOnInitCheckBox);
            this.optionsGroupBox.Controls.Add(this.RestoreWindowHeightCheckBox);
            this.optionsGroupBox.Location = new System.Drawing.Point(12, 19);
            this.optionsGroupBox.Name = "optionsGroupBox";
            this.optionsGroupBox.Size = new System.Drawing.Size(546, 73);
            this.optionsGroupBox.TabIndex = 2;
            this.optionsGroupBox.TabStop = false;
            // 
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 400);
            this.Controls.Add(this.backgroundGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "OptionsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.backgroundGroupBox.ResumeLayout(false);
            this.optionsGroupBox.ResumeLayout(false);
            this.optionsGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.CheckBox RestoreWindowHeightCheckBox;
        internal System.Windows.Forms.CheckBox OpenWindowOnInitCheckBox;
        private System.Windows.Forms.GroupBox backgroundGroupBox;
        private System.Windows.Forms.GroupBox optionsGroupBox;
    }
}