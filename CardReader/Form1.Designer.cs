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
            this.WFSStartUPBtn = new System.Windows.Forms.Button();
            this.WFSOpenBtn = new System.Windows.Forms.Button();
            this.WFSRegisterBtn = new System.Windows.Forms.Button();
            this.WFSStartUpResult = new System.Windows.Forms.TextBox();
            this.WFSOpenResult = new System.Windows.Forms.TextBox();
            this.WFSRegisterResult = new System.Windows.Forms.TextBox();
            this.WFSLockBtn = new System.Windows.Forms.Button();
            this.WFSLockResult = new System.Windows.Forms.TextBox();
            this.WFSGetInfoBtn = new System.Windows.Forms.Button();
            this.WFSGetInfoResult = new System.Windows.Forms.TextBox();
            this.WFSIsBlockingBtn = new System.Windows.Forms.Button();
            this.WFSIsBlockingResult = new System.Windows.Forms.TextBox();
            this.WFSAsyncExecuteBtn = new System.Windows.Forms.Button();
            this.WFSAsyncExecuteResult = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // WFSStartUPBtn
            // 
            this.WFSStartUPBtn.Location = new System.Drawing.Point(55, 75);
            this.WFSStartUPBtn.Name = "WFSStartUPBtn";
            this.WFSStartUPBtn.Size = new System.Drawing.Size(147, 25);
            this.WFSStartUPBtn.TabIndex = 0;
            this.WFSStartUPBtn.Text = "WFSStartUp";
            this.WFSStartUPBtn.UseVisualStyleBackColor = true;
            this.WFSStartUPBtn.Click += new System.EventHandler(this.WFSStartUp_Click);
            // 
            // WFSOpenBtn
            // 
            this.WFSOpenBtn.Location = new System.Drawing.Point(55, 116);
            this.WFSOpenBtn.Name = "WFSOpenBtn";
            this.WFSOpenBtn.Size = new System.Drawing.Size(147, 25);
            this.WFSOpenBtn.TabIndex = 1;
            this.WFSOpenBtn.Text = "WFSOpen";
            this.WFSOpenBtn.UseVisualStyleBackColor = true;
            this.WFSOpenBtn.Click += new System.EventHandler(this.WFSOpen_Click);
            // 
            // WFSRegisterBtn
            // 
            this.WFSRegisterBtn.Location = new System.Drawing.Point(55, 153);
            this.WFSRegisterBtn.Name = "WFSRegisterBtn";
            this.WFSRegisterBtn.Size = new System.Drawing.Size(147, 25);
            this.WFSRegisterBtn.TabIndex = 2;
            this.WFSRegisterBtn.Text = "WFSRegister";
            this.WFSRegisterBtn.UseVisualStyleBackColor = true;
            this.WFSRegisterBtn.Click += new System.EventHandler(this.WFSRegister_Click);
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
            // WFSLockBtn
            // 
            this.WFSLockBtn.Location = new System.Drawing.Point(55, 193);
            this.WFSLockBtn.Name = "WFSLockBtn";
            this.WFSLockBtn.Size = new System.Drawing.Size(147, 25);
            this.WFSLockBtn.TabIndex = 6;
            this.WFSLockBtn.Text = "WFSLock";
            this.WFSLockBtn.UseVisualStyleBackColor = true;
            this.WFSLockBtn.Click += new System.EventHandler(this.WFSLockBtn_Click);
            // 
            // WFSLockResult
            // 
            this.WFSLockResult.Location = new System.Drawing.Point(208, 194);
            this.WFSLockResult.Name = "WFSLockResult";
            this.WFSLockResult.Size = new System.Drawing.Size(411, 22);
            this.WFSLockResult.TabIndex = 7;
            // 
            // WFSGetInfoBtn
            // 
            this.WFSGetInfoBtn.Location = new System.Drawing.Point(55, 233);
            this.WFSGetInfoBtn.Name = "WFSGetInfoBtn";
            this.WFSGetInfoBtn.Size = new System.Drawing.Size(147, 25);
            this.WFSGetInfoBtn.TabIndex = 8;
            this.WFSGetInfoBtn.Text = "WFSGetInfo";
            this.WFSGetInfoBtn.UseVisualStyleBackColor = true;
            this.WFSGetInfoBtn.Click += new System.EventHandler(this.WFSGetInfoBtn_Click);
            // 
            // WFSGetInfoResult
            // 
            this.WFSGetInfoResult.Location = new System.Drawing.Point(208, 236);
            this.WFSGetInfoResult.Name = "WFSGetInfoResult";
            this.WFSGetInfoResult.Size = new System.Drawing.Size(411, 22);
            this.WFSGetInfoResult.TabIndex = 9;
            // 
            // WFSIsBlockingBtn
            // 
            this.WFSIsBlockingBtn.Location = new System.Drawing.Point(55, 264);
            this.WFSIsBlockingBtn.Name = "WFSIsBlockingBtn";
            this.WFSIsBlockingBtn.Size = new System.Drawing.Size(147, 25);
            this.WFSIsBlockingBtn.TabIndex = 10;
            this.WFSIsBlockingBtn.Text = "WFSIsBlocking";
            this.WFSIsBlockingBtn.UseVisualStyleBackColor = true;
            this.WFSIsBlockingBtn.Click += new System.EventHandler(this.WFSIsBlockingBtn_Click);
            // 
            // WFSIsBlockingResult
            // 
            this.WFSIsBlockingResult.Location = new System.Drawing.Point(208, 267);
            this.WFSIsBlockingResult.Name = "WFSIsBlockingResult";
            this.WFSIsBlockingResult.Size = new System.Drawing.Size(411, 22);
            this.WFSIsBlockingResult.TabIndex = 11;
            // 
            // WFSAsyncExecuteBtn
            // 
            this.WFSAsyncExecuteBtn.Location = new System.Drawing.Point(55, 295);
            this.WFSAsyncExecuteBtn.Name = "WFSAsyncExecuteBtn";
            this.WFSAsyncExecuteBtn.Size = new System.Drawing.Size(147, 25);
            this.WFSAsyncExecuteBtn.TabIndex = 12;
            this.WFSAsyncExecuteBtn.Text = "WFSAsyncExecute";
            this.WFSAsyncExecuteBtn.UseVisualStyleBackColor = true;
            this.WFSAsyncExecuteBtn.Click += new System.EventHandler(this.WFSAsyncExecuteBtn_Click);
            // 
            // WFSAsyncExecuteResult
            // 
            this.WFSAsyncExecuteResult.Location = new System.Drawing.Point(208, 298);
            this.WFSAsyncExecuteResult.Name = "WFSAsyncExecuteResult";
            this.WFSAsyncExecuteResult.Size = new System.Drawing.Size(411, 22);
            this.WFSAsyncExecuteResult.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 457);
            this.Controls.Add(this.WFSAsyncExecuteResult);
            this.Controls.Add(this.WFSAsyncExecuteBtn);
            this.Controls.Add(this.WFSIsBlockingResult);
            this.Controls.Add(this.WFSIsBlockingBtn);
            this.Controls.Add(this.WFSGetInfoResult);
            this.Controls.Add(this.WFSGetInfoBtn);
            this.Controls.Add(this.WFSLockResult);
            this.Controls.Add(this.WFSLockBtn);
            this.Controls.Add(this.WFSStartUPBtn);
            this.Controls.Add(this.WFSRegisterResult);
            this.Controls.Add(this.WFSOpenResult);
            this.Controls.Add(this.WFSStartUpResult);
            this.Controls.Add(this.WFSRegisterBtn);
            this.Controls.Add(this.WFSOpenBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button WFSStartUPBtn;
        private System.Windows.Forms.Button WFSOpenBtn;
        private System.Windows.Forms.Button WFSRegisterBtn;
        private System.Windows.Forms.TextBox WFSStartUpResult;
        private System.Windows.Forms.TextBox WFSOpenResult;
        private System.Windows.Forms.TextBox WFSRegisterResult;
        private System.Windows.Forms.Button WFSLockBtn;
        private System.Windows.Forms.TextBox WFSLockResult;
        private System.Windows.Forms.Button WFSGetInfoBtn;
        private System.Windows.Forms.TextBox WFSGetInfoResult;
        private System.Windows.Forms.Button WFSIsBlockingBtn;
        private System.Windows.Forms.TextBox WFSIsBlockingResult;
        private System.Windows.Forms.Button WFSAsyncExecuteBtn;
        private System.Windows.Forms.TextBox WFSAsyncExecuteResult;
    }
}

