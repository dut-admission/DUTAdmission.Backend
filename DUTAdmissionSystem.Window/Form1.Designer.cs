namespace DUTAdmissionSystem.Window
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.percentageTxtBox = new System.Windows.Forms.Label();
            this.errorNumberLog = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(230, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 35);
            this.button1.TabIndex = 0;
            this.button1.Text = "Import";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 62);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(528, 12);
            this.progressBar.TabIndex = 1;
            // 
            // percentageTxtBox
            // 
            this.percentageTxtBox.AutoSize = true;
            this.percentageTxtBox.Location = new System.Drawing.Point(263, 77);
            this.percentageTxtBox.Name = "percentageTxtBox";
            this.percentageTxtBox.Size = new System.Drawing.Size(35, 13);
            this.percentageTxtBox.TabIndex = 2;
            this.percentageTxtBox.Text = "label1";
            // 
            // errorNumberLog
            // 
            this.errorNumberLog.AutoSize = true;
            this.errorNumberLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorNumberLog.ForeColor = System.Drawing.Color.Red;
            this.errorNumberLog.Location = new System.Drawing.Point(12, 112);
            this.errorNumberLog.Name = "errorNumberLog";
            this.errorNumberLog.Size = new System.Drawing.Size(96, 20);
            this.errorNumberLog.TabIndex = 3;
            this.errorNumberLog.Text = "Error rows:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 152);
            this.Controls.Add(this.errorNumberLog);
            this.Controls.Add(this.percentageTxtBox);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Import data";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label percentageTxtBox;
        private System.Windows.Forms.Label errorNumberLog;
    }
}

