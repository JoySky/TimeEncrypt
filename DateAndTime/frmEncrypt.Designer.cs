namespace DateAndTime
{
    partial class frmEncrypt
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtMacCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRegCode = new System.Windows.Forms.TextBox();
            this.btnReg = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "机器码：";
            // 
            // txtMacCode
            // 
            this.txtMacCode.Location = new System.Drawing.Point(71, 57);
            this.txtMacCode.Name = "txtMacCode";
            this.txtMacCode.ReadOnly = true;
            this.txtMacCode.Size = new System.Drawing.Size(201, 21);
            this.txtMacCode.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "注册码：";
            // 
            // txtRegCode
            // 
            this.txtRegCode.Location = new System.Drawing.Point(71, 106);
            this.txtRegCode.Name = "txtRegCode";
            this.txtRegCode.Size = new System.Drawing.Size(201, 21);
            this.txtRegCode.TabIndex = 3;
            // 
            // btnReg
            // 
            this.btnReg.Location = new System.Drawing.Point(98, 212);
            this.btnReg.Name = "btnReg";
            this.btnReg.Size = new System.Drawing.Size(75, 23);
            this.btnReg.TabIndex = 4;
            this.btnReg.Text = "注册";
            this.btnReg.UseVisualStyleBackColor = true;
            this.btnReg.Click += new System.EventHandler(this.btnReg_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(179, 212);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmEncrypt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnReg);
            this.Controls.Add(this.txtRegCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMacCode);
            this.Controls.Add(this.label1);
            this.Name = "frmEncrypt";
            this.Text = "注册";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmEncrypt_FormClosing);
            this.Load += new System.EventHandler(this.frmEncrypt_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMacCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRegCode;
        private System.Windows.Forms.Button btnReg;
        private System.Windows.Forms.Button btnClose;
    }
}