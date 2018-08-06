namespace TestWcfUploadFile
{
    partial class FormUploadFile
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
            this.btnUoload1 = new System.Windows.Forms.Button();
            this.btnUpload2 = new System.Windows.Forms.Button();
            this.btnDownLoad1 = new System.Windows.Forms.Button();
            this.btnDownload2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnUoload1
            // 
            this.btnUoload1.Location = new System.Drawing.Point(12, 12);
            this.btnUoload1.Name = "btnUoload1";
            this.btnUoload1.Size = new System.Drawing.Size(103, 37);
            this.btnUoload1.TabIndex = 0;
            this.btnUoload1.Text = "上传文件1";
            this.btnUoload1.UseVisualStyleBackColor = true;
            this.btnUoload1.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // btnUpload2
            // 
            this.btnUpload2.Location = new System.Drawing.Point(164, 12);
            this.btnUpload2.Name = "btnUpload2";
            this.btnUpload2.Size = new System.Drawing.Size(103, 37);
            this.btnUpload2.TabIndex = 0;
            this.btnUpload2.Text = "上传文件2";
            this.btnUpload2.UseVisualStyleBackColor = true;
            this.btnUpload2.Click += new System.EventHandler(this.btnInvokeByHand_Click);
            // 
            // btnDownLoad1
            // 
            this.btnDownLoad1.Location = new System.Drawing.Point(12, 62);
            this.btnDownLoad1.Name = "btnDownLoad1";
            this.btnDownLoad1.Size = new System.Drawing.Size(103, 37);
            this.btnDownLoad1.TabIndex = 0;
            this.btnDownLoad1.Text = "下载文件1";
            this.btnDownLoad1.UseVisualStyleBackColor = true;
            this.btnDownLoad1.Click += new System.EventHandler(this.btnDownLoad1_Click);
            // 
            // btnDownload2
            // 
            this.btnDownload2.Location = new System.Drawing.Point(164, 62);
            this.btnDownload2.Name = "btnDownload2";
            this.btnDownload2.Size = new System.Drawing.Size(103, 37);
            this.btnDownload2.TabIndex = 0;
            this.btnDownload2.Text = "下载文件2";
            this.btnDownload2.UseVisualStyleBackColor = true;
            this.btnDownload2.Click += new System.EventHandler(this.btnDownload2_Click);
            // 
            // FormUploadFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 111);
            this.Controls.Add(this.btnUpload2);
            this.Controls.Add(this.btnDownload2);
            this.Controls.Add(this.btnDownLoad1);
            this.Controls.Add(this.btnUoload1);
            this.Name = "FormUploadFile";
            this.Text = "WCF上传文件测试客户端";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnUoload1;
        private System.Windows.Forms.Button btnUpload2;
        private System.Windows.Forms.Button btnDownLoad1;
        private System.Windows.Forms.Button btnDownload2;
    }
}

