namespace ExpressBI.SubForm
{
    partial class DialogSelectApmas
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
            this.btnReorder = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.col_supcod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_supnam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_orgnum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_suptyp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_suptyp_desc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_addr01 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_addr02 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_addr03 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnReorder
            // 
            this.btnReorder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReorder.Location = new System.Drawing.Point(272, 188);
            this.btnReorder.Name = "btnReorder";
            this.btnReorder.Size = new System.Drawing.Size(119, 29);
            this.btnReorder.TabIndex = 9;
            this.btnReorder.Text = "เรียงใหม่ <Tab>";
            this.btnReorder.UseVisualStyleBackColor = true;
            this.btnReorder.Click += new System.EventHandler(this.btnReorder_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSearch.Location = new System.Drawing.Point(191, 188);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 29);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "ค้นหา";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(93, 188);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 29);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "ยกเลิก";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Enabled = false;
            this.btnOK.Location = new System.Drawing.Point(12, 188);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 29);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "ตกลง";
            this.btnOK.UseVisualStyleBackColor = true;
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
            this.col_supcod,
            this.col_supnam,
            this.col_orgnum,
            this.col_suptyp,
            this.col_suptyp_desc,
            this.col_addr01,
            this.col_addr02,
            this.col_addr03});
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(2, 7);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(630, 166);
            this.dataGridView1.StandardTab = true;
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
            this.dataGridView1.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_ColumnHeaderMouseClick);
            this.dataGridView1.CurrentCellChanged += new System.EventHandler(this.dataGridView1_CurrentCellChanged);
            this.dataGridView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseDoubleClick);
            // 
            // col_supcod
            // 
            this.col_supcod.DataPropertyName = "supcod";
            this.col_supcod.HeaderText = "รหัส";
            this.col_supcod.MinimumWidth = 100;
            this.col_supcod.Name = "col_supcod";
            this.col_supcod.ReadOnly = true;
            // 
            // col_supnam
            // 
            this.col_supnam.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_supnam.DataPropertyName = "supnam";
            this.col_supnam.HeaderText = "ชื่อ";
            this.col_supnam.MinimumWidth = 200;
            this.col_supnam.Name = "col_supnam";
            this.col_supnam.ReadOnly = true;
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
            // col_suptyp
            // 
            this.col_suptyp.DataPropertyName = "suptyp";
            this.col_suptyp.HeaderText = "";
            this.col_suptyp.MinimumWidth = 30;
            this.col_suptyp.Name = "col_suptyp";
            this.col_suptyp.ReadOnly = true;
            this.col_suptyp.Width = 30;
            // 
            // col_suptyp_desc
            // 
            this.col_suptyp_desc.DataPropertyName = "suptyp_desc";
            this.col_suptyp_desc.HeaderText = "ประเภทผู้จำหน่าย";
            this.col_suptyp_desc.MinimumWidth = 140;
            this.col_suptyp_desc.Name = "col_suptyp_desc";
            this.col_suptyp_desc.ReadOnly = true;
            this.col_suptyp_desc.Width = 140;
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
            // DialogSelectApmas
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
            this.Name = "DialogSelectApmas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.DialogSelectApmas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnReorder;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_supcod;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_supnam;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_orgnum;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_suptyp;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_suptyp_desc;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_addr01;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_addr02;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_addr03;
    }
}