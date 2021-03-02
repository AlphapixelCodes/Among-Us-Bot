
namespace Among_Us_Calibrator.GUIs
{
    partial class Change_Key_Binding
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Change_Key_Binding));
            this.label1 = new System.Windows.Forms.Label();
            this.Output = new System.Windows.Forms.Label();
            this.Reset = new System.Windows.Forms.Button();
            this.Confirm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(278, 50);
            this.label1.TabIndex = 0;
            this.label1.Text = "Press Any Key \r\n(Some may not work idk idc)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Output
            // 
            this.Output.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Output.Location = new System.Drawing.Point(12, 73);
            this.Output.Name = "Output";
            this.Output.Size = new System.Drawing.Size(278, 20);
            this.Output.TabIndex = 1;
            this.Output.Text = "Output";
            this.Output.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Reset
            // 
            this.Reset.Location = new System.Drawing.Point(12, 115);
            this.Reset.Name = "Reset";
            this.Reset.Size = new System.Drawing.Size(115, 23);
            this.Reset.TabIndex = 2;
            this.Reset.Text = "Reset";
            this.Reset.UseVisualStyleBackColor = true;
            this.Reset.Click += new System.EventHandler(this.Reset_Click);
            // 
            // Confirm
            // 
            this.Confirm.Location = new System.Drawing.Point(175, 115);
            this.Confirm.Name = "Confirm";
            this.Confirm.Size = new System.Drawing.Size(115, 23);
            this.Confirm.TabIndex = 3;
            this.Confirm.Text = "Confirm";
            this.Confirm.UseVisualStyleBackColor = true;
            this.Confirm.Click += new System.EventHandler(this.Confirm_Click);
            // 
            // Change_Key_Binding
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 150);
            this.Controls.Add(this.Confirm);
            this.Controls.Add(this.Reset);
            this.Controls.Add(this.Output);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Change_Key_Binding";
            this.Text = "Change Key Binding";
            this.TopMost = true;
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressM);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Output;
        private System.Windows.Forms.Button Reset;
        private System.Windows.Forms.Button Confirm;
    }
}