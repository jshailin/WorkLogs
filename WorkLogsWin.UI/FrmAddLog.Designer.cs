namespace WorkLogsWin.UI
{
    partial class FrmAddLog
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
            this.txtPNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPName = new System.Windows.Forms.TextBox();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.lblCreateDate = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "相关生产编号：";
            // 
            // txtPNumber
            // 
            this.txtPNumber.Location = new System.Drawing.Point(125, 6);
            this.txtPNumber.Name = "txtPNumber";
            this.txtPNumber.Size = new System.Drawing.Size(189, 26);
            this.txtPNumber.TabIndex = 1;
            this.txtPNumber.Leave += new System.EventHandler(this.txtPNumber_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "项目名称:";
            // 
            // txtPName
            // 
            this.txtPName.Location = new System.Drawing.Point(91, 38);
            this.txtPName.Name = "txtPName";
            this.txtPName.ReadOnly = true;
            this.txtPName.Size = new System.Drawing.Size(445, 26);
            this.txtPName.TabIndex = 1;
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(12, 70);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(524, 329);
            this.txtLog.TabIndex = 2;
            // 
            // lblCreateDate
            // 
            this.lblCreateDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCreateDate.AutoSize = true;
            this.lblCreateDate.Location = new System.Drawing.Point(480, 9);
            this.lblCreateDate.Name = "lblCreateDate";
            this.lblCreateDate.Size = new System.Drawing.Size(56, 16);
            this.lblCreateDate.TabIndex = 0;
            this.lblCreateDate.Text = "label1";
            this.lblCreateDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FrmAddLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 411);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.txtPName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPNumber);
            this.Controls.Add(this.lblCreateDate);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAddLog";
            this.Text = "frmAddLog";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAddLog_FormClosing);
            this.Load += new System.EventHandler(this.FrmAddLog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPName;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Label lblCreateDate;
    }
}