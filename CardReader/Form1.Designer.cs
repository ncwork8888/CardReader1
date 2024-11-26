namespace CardReader
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
            this.WFSStartUP = new System.Windows.Forms.Button();
            this.WFSOpen = new System.Windows.Forms.Button();
            this.WFSRegister = new System.Windows.Forms.Button();
            this.WFSStartUpResult = new System.Windows.Forms.TextBox();
            this.WFSOpenResult = new System.Windows.Forms.TextBox();
            this.WFSRegisterResult = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // WFSStartUp
            // 
            this.WFSStartUP.Location = new System.Drawing.Point(55,75);
            this.WFSStartUP.Name = "WFSStartUp";
            this.WFSStartUP.Size = new System.Drawing.Size(147, 25);
            this.WFSStartUP.TabIndex = 0;
            this.WFSStartUP.Text = "WFSStartUp";
            this.WFSStartUP.UseVisualStyleBackColor = true;
            this.WFSStartUP.Click += new System.EventHandler(this.WFSStartUp_Click);
            // 
            // WFSOpen
            // 
            this.WFSOpen.Location = new System.Drawing.Point(55, 116);
            this.WFSOpen.Name = "WFSOpen";
            this.WFSOpen.Size = new System.Drawing.Size(147, 25);
            this.WFSOpen.TabIndex = 1;
            this.WFSOpen.Text = "WFSOpen";
            this.WFSOpen.UseVisualStyleBackColor = true;
            this.WFSOpen.Click += new System.EventHandler(this.WFSOpen_Click);
            // 
            // WFSRegister
            // 
            this.WFSRegister.Location = new System.Drawing.Point(55, 153);
            this.WFSRegister.Name = "WFSRegister";
            this.WFSRegister.Size = new System.Drawing.Size(147, 25);
            this.WFSRegister.TabIndex = 2;
            this.WFSRegister.Text = "WFSRegister";
            this.WFSRegister.UseVisualStyleBackColor = true;
            this.WFSRegister.Click += new System.EventHandler(this.WFSRegister_Click);
            // 
            // WFSStartUpResult
            // 
            this.WFSStartUpResult.Location = new System.Drawing.Point(208, 76);
            this.WFSStartUpResult.Name = "WFSStartUpResult";
            this.WFSStartUpResult.Size = new System.Drawing.Size(411, 22);
            this.WFSStartUpResult.TabIndex = 3;
            // 
            // WFSOpenResult
            // 
            this.WFSOpenResult.Location = new System.Drawing.Point(208, 117);
            this.WFSOpenResult.Name = "WFSOpenResult";
            this.WFSOpenResult.Size = new System.Drawing.Size(411, 22);
            this.WFSOpenResult.TabIndex = 4;
            // 
            // WFSRegisterResult
            // 
            this.WFSRegisterResult.Location = new System.Drawing.Point(208, 153);
            this.WFSRegisterResult.Name = "WFSRegisterResult";
            this.WFSRegisterResult.Size = new System.Drawing.Size(411, 22);
            this.WFSRegisterResult.TabIndex = 5;
            // 
            // Form1
            // 
            this.Controls.Add(this.WFSStartUP);
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 251);
            this.Controls.Add(this.WFSRegisterResult);
            this.Controls.Add(this.WFSOpenResult);
            this.Controls.Add(this.WFSStartUpResult);
            this.Controls.Add(this.WFSRegister);
            this.Controls.Add(this.WFSOpen);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button WFSStartUP;
        private System.Windows.Forms.Button WFSOpen;
        private System.Windows.Forms.Button WFSRegister;
        private System.Windows.Forms.TextBox WFSStartUpResult;
        private System.Windows.Forms.TextBox WFSOpenResult;
        private System.Windows.Forms.TextBox WFSRegisterResult;
        
    }
}

