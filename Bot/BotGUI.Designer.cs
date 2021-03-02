
namespace Among_Us_Calibrator.Bot
{
    partial class BotGUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BotGUI));
            this.FileNameLabel = new System.Windows.Forms.Label();
            this.StartPauseButton = new System.Windows.Forms.Button();
            this.CurrentTaskLabel = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.returnToHomeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenFileButton = new System.Windows.Forms.Button();
            this.BotStatus = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // FileNameLabel
            // 
            this.FileNameLabel.AutoSize = true;
            this.FileNameLabel.Location = new System.Drawing.Point(87, 37);
            this.FileNameLabel.Name = "FileNameLabel";
            this.FileNameLabel.Size = new System.Drawing.Size(85, 13);
            this.FileNameLabel.TabIndex = 0;
            this.FileNameLabel.Text = "No File Selected";
            // 
            // StartPauseButton
            // 
            this.StartPauseButton.Location = new System.Drawing.Point(12, 105);
            this.StartPauseButton.Name = "StartPauseButton";
            this.StartPauseButton.Size = new System.Drawing.Size(186, 23);
            this.StartPauseButton.TabIndex = 1;
            this.StartPauseButton.Text = "Start";
            this.StartPauseButton.UseVisualStyleBackColor = true;
            this.StartPauseButton.Click += new System.EventHandler(this.StartPauseButton_Click);
            // 
            // CurrentTaskLabel
            // 
            this.CurrentTaskLabel.Location = new System.Drawing.Point(12, 77);
            this.CurrentTaskLabel.Name = "CurrentTaskLabel";
            this.CurrentTaskLabel.Size = new System.Drawing.Size(186, 13);
            this.CurrentTaskLabel.TabIndex = 2;
            this.CurrentTaskLabel.Text = "Current Task: None";
            this.CurrentTaskLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(210, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileToolStripMenuItem,
            this.returnToHomeToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(38, 22);
            this.toolStripDropDownButton1.Text = "File";
            // 
            // openFileToolStripMenuItem
            // 
            this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            this.openFileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openFileToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.openFileToolStripMenuItem.Text = "Open File";
            this.openFileToolStripMenuItem.Click += new System.EventHandler(this.openFileToolStripMenuItem_Click);
            // 
            // returnToHomeToolStripMenuItem
            // 
            this.returnToHomeToolStripMenuItem.Name = "returnToHomeToolStripMenuItem";
            this.returnToHomeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
            this.returnToHomeToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.returnToHomeToolStripMenuItem.Text = "Return to Menu";
            this.returnToHomeToolStripMenuItem.Click += new System.EventHandler(this.returnToHomeToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // OpenFileButton
            // 
            this.OpenFileButton.Location = new System.Drawing.Point(6, 32);
            this.OpenFileButton.Name = "OpenFileButton";
            this.OpenFileButton.Size = new System.Drawing.Size(75, 23);
            this.OpenFileButton.TabIndex = 4;
            this.OpenFileButton.Text = "Open File";
            this.OpenFileButton.UseVisualStyleBackColor = true;
            this.OpenFileButton.Click += new System.EventHandler(this.openFileToolStripMenuItem_Click);
            // 
            // BotStatus
            // 
            this.BotStatus.Location = new System.Drawing.Point(12, 58);
            this.BotStatus.Name = "BotStatus";
            this.BotStatus.Size = new System.Drawing.Size(186, 13);
            this.BotStatus.TabIndex = 5;
            this.BotStatus.Text = "Bot Status: No Bot";
            this.BotStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BotGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(210, 148);
            this.Controls.Add(this.BotStatus);
            this.Controls.Add(this.OpenFileButton);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.CurrentTaskLabel);
            this.Controls.Add(this.StartPauseButton);
            this.Controls.Add(this.FileNameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "BotGUI";
            this.Text = "BotGUI";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BotGUI_FormClosing);
            this.Load += new System.EventHandler(this.BotGUI_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label FileNameLabel;
        private System.Windows.Forms.Button StartPauseButton;
        private System.Windows.Forms.Label CurrentTaskLabel;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem returnToHomeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Button OpenFileButton;
        private System.Windows.Forms.Label BotStatus;
    }
}