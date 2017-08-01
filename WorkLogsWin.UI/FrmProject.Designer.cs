namespace WorkLogsWin.UI
{
    partial class FrmProject
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProject));
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToDeleteRows = false;
            this.dgvList.AllowUserToOrderColumns = true;
            this.dgvList.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column6,
            this.Column5,
            this.Column7,
            this.Column4,
            this.Column8,
            this.Column9,
            this.Column10});
            this.dgvList.Location = new System.Drawing.Point(12, 54);
            this.dgvList.Name = "dgvList";
            this.dgvList.ReadOnly = true;
            this.dgvList.RowHeadersVisible = false;
            this.dgvList.RowTemplate.Height = 23;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvList.Size = new System.Drawing.Size(839, 443);
            this.dgvList.TabIndex = 0;
            this.dgvList.ColumnDisplayIndexChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dgvList_ColumnDisplayIndexChanged);
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(230, 12);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(109, 29);
            this.txtNumber.TabIndex = 2;
            this.txtNumber.Leave += new System.EventHandler(this.txtNumber_Leave);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(441, 12);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(211, 29);
            this.txtName.TabIndex = 3;
            this.txtName.Leave += new System.EventHandler(this.txtNumber_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(345, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 21);
            this.label5.TabIndex = 2;
            this.label5.Text = "项目名称：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(150, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 21);
            this.label4.TabIndex = 1;
            this.label4.Text = "项目号：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "查询方式";
            // 
            // btnShowAll
            // 
            this.btnShowAll.Location = new System.Drawing.Point(762, 9);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(89, 33);
            this.btnShowAll.TabIndex = 4;
            this.btnShowAll.Text = "全部项目";
            this.btnShowAll.UseVisualStyleBackColor = true;
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "ID";
            this.Column1.FillWeight = 5F;
            this.Column1.HeaderText = "编号";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 67;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Pnumber";
            this.Column2.FillWeight = 10F;
            this.Column2.HeaderText = "项目号";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 83;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Item";
            this.Column3.FillWeight = 15F;
            this.Column3.HeaderText = "品目";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 67;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "Pname";
            this.Column6.FillWeight = 20F;
            this.Column6.HeaderText = "项目名";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 83;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "CustomerName";
            this.Column5.FillWeight = 20F;
            this.Column5.HeaderText = "用户名";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 83;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "Description";
            this.Column7.FillWeight = 15F;
            this.Column7.HeaderText = "摘要";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 67;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "MProperty";
            this.Column4.FillWeight = 15F;
            this.Column4.HeaderText = "参数";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 67;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "DDepartment2";
            this.Column8.HeaderText = "结构科";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 83;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "Design1";
            this.Column9.HeaderText = "电气担当";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Width = 99;
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "Design2";
            this.Column10.HeaderText = "结构担当";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Width = 99;
            // 
            // FrmProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 509);
            this.Controls.Add(this.btnShowAll);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtNumber);
            this.Controls.Add(this.dgvList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmProject";
            this.Text = "项目查询";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmProject_FormClosing);
            this.Load += new System.EventHandler(this.FrmProject_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnShowAll;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
    }
}