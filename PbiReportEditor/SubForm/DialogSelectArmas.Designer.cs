namespace ExpressBI.SubForm
{
    partial class DialogSelectArmas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.col_cuscod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_cusnam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_orgnum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_custyp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_custyp_desc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_addr01 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_addr02 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_addr03 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_zipcod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnReorder = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(253)))), ((int)(((byte)(155)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(235)))), ((int)(((byte)(2)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeight = 25;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_cuscod,
            this.col_cusnam,
            this.col_orgnum,
            this.col_custyp,
            this.col_custyp_desc,
            this.col_addr01,
            this.col_addr02,
            this.col_addr03,
            this.col_zipcod});
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(2, 2);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(630, 166);
            this.dataGridView1.StandardTab = true;
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
            this.dataGridView1.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_ColumnHeaderMouseClick);
            this.dataGridView1.CurrentCellChanged += new System.EventHandler(this.dataGridView1_CurrentCellChanged);
            this.dataGridView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseDoubleClick);
            // 
            // col_cuscod
            // 
            this.col_cuscod.DataPropertyName = "cuscod";
            this.col_cuscod.HeaderText = "รหัส";
            this.col_cuscod.MinimumWidth = 100;
            this.col_cuscod.Name = "col_cuscod";
            this.col_cuscod.ReadOnly = true;
            // 
            // col_cusnam
            // 
            this.col_cusnam.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_cusnam.DataPropertyName = "cusnam";
            this.col_cusnam.HeaderText = "ชื่อลูกค้า";
            this.col_cusnam.MinimumWidth = 200;
            this.col_cusnam.Name = "col_cusnam";
            this.col_cusnam.ReadOnly = true;
            // 
            // col_orgnum
            // 
            this.col_orgnum.DataPropertyName = "orgnum";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.col_orgnum.DefaultCellStyle = dataGridViewCellStyle2;
            this.col_orgnum.HeaderText = "สาขา #";
            this.col_orgnum.MinimumWidth = 60;
            this.col_orgnum.Name = "col_orgnum";
            this.col_orgnum.ReadOnly = true;
            this.col_orgnum.Width = 60;
            // 
            // col_custyp
            // 
            this.col_custyp.DataPropertyName = "custyp";
            this.col_custyp.HeaderText = "";
            this.col_custyp.MinimumWidth = 30;
            this.col_custyp.Name = "col_custyp";
            this.col_custyp.ReadOnly = true;
            this.col_custyp.Width = 30;
            // 
            // col_custyp_desc
            // 
            this.col_custyp_desc.DataPropertyName = "custyp_desc";
            this.col_custyp_desc.HeaderText = "ประเภทลูกค้า";
            this.col_custyp_desc.MinimumWidth = 140;
            this.col_custyp_desc.Name = "col_custyp_desc";
            this.col_custyp_desc.ReadOnly = true;
            this.col_custyp_desc.Width = 140;
            // 
            // col_addr01
            // 
            this.col_addr01.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_addr01.DataPropertyName = "addr01";
            this.col_addr01.HeaderText = "ที่อยู่บรรทัดที่ 1";
            this.col_addr01.MinimumWidth = 220;
            this.col_addr01.Name = "col_addr01";
            this.col_addr01.ReadOnly = true;
            // 
            // col_addr02
            // 
            this.col_addr02.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_addr02.DataPropertyName = "addr02";
            this.col_addr02.HeaderText = "ที่อยู่บรรทัดที่ 2";
            this.col_addr02.MinimumWidth = 220;
            this.col_addr02.Name = "col_addr02";
            this.col_addr02.ReadOnly = true;
            // 
            // col_addr03
            // 
            this.col_addr03.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_addr03.DataPropertyName = "addr03";
            this.col_addr03.HeaderText = "ที่อยู่บรรทัดที่ 3";
            this.col_addr03.MinimumWidth = 140;
            this.col_addr03.Name = "col_addr03";
            this.col_addr03.ReadOnly = true;
            // 
            // col_zipcod
            // 
            this.col_zipcod.DataPropertyName = "zipcod";
            this.col_zipcod.HeaderText = "รหัสไปรษณีย์";
            this.col_zipcod.MinimumWidth = 100;
            this.col_zipcod.Name = "col_zipcod";
            this.col_zipcod.ReadOnly = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Enabled = false;
            this.btnOK.Location = new System.Drawing.Point(12, 183);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 29);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "ตกลง";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(93, 183);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 29);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "ยกเลิก";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSearch.Location = new System.Drawing.Point(191, 183);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 29);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "ค้นหา";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnReorder
            // 
            this.btnReorder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReorder.Location = new System.Drawing.Point(272, 183);
            this.btnReorder.Name = "btnReorder";
            this.btnReorder.Size = new System.Drawing.Size(119, 29);
            this.btnReorder.TabIndex = 4;
            this.btnReorder.Text = "เรียงใหม่ <Tab>";
            this.btnReorder.UseVisualStyleBackColor = true;
            this.btnReorder.Click += new System.EventHandler(this.btnReorder_Click);
            // 
            // DialogSelectArmas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 224);
            this.ControlBox = false;
            this.Controls.Add(this.btnReorder);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DialogSelectArmas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.DialogSelectArmas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_cuscod;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_cusnam;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_orgnum;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_custyp;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_custyp_desc;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_addr01;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_addr02;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_addr03;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_zipcod;
        private System.Windows.Forms.Button btnReorder;
    }
}