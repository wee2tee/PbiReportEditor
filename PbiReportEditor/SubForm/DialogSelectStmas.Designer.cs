namespace ExpressBI.SubForm
{
    partial class DialogSelectStmas
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
            this.col_stkcod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_totbal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_stkdes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_qucod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_stkcods = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_stktyp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_packing = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_stkdes2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnReorder
            // 
            this.btnReorder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReorder.Location = new System.Drawing.Point(272, 188);
            this.btnReorder.Name = "btnReorder";
            this.btnReorder.Size = new System.Drawing.Size(119, 29);
            this.btnReorder.TabIndex = 14;
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
            this.btnSearch.TabIndex = 13;
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
            this.btnCancel.TabIndex = 12;
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
            this.btnOK.TabIndex = 11;
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
            this.col_stkcod,
            this.col_totbal,
            this.col_stkdes,
            this.col_qucod,
            this.col_stkcods,
            this.col_stktyp,
            this.col_packing,
            this.col_stkdes2});
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(2, 7);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(630, 166);
            this.dataGridView1.StandardTab = true;
            this.dataGridView1.TabIndex = 10;
            this.dataGridView1.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
            this.dataGridView1.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_ColumnHeaderMouseClick);
            this.dataGridView1.CurrentCellChanged += new System.EventHandler(this.dataGridView1_CurrentCellChanged);
            this.dataGridView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseDoubleClick);
            // 
            // col_stkcod
            // 
            this.col_stkcod.DataPropertyName = "stkcod";
            this.col_stkcod.HeaderText = "รหัส";
            this.col_stkcod.MinimumWidth = 180;
            this.col_stkcod.Name = "col_stkcod";
            this.col_stkcod.ReadOnly = true;
            this.col_stkcod.Width = 180;
            // 
            // col_totbal
            // 
            this.col_totbal.DataPropertyName = "totbal";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.col_totbal.DefaultCellStyle = dataGridViewCellStyle2;
            this.col_totbal.HeaderText = "คงเหลือ";
            this.col_totbal.MinimumWidth = 120;
            this.col_totbal.Name = "col_totbal";
            this.col_totbal.ReadOnly = true;
            this.col_totbal.Width = 120;
            // 
            // col_stkdes
            // 
            this.col_stkdes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_stkdes.DataPropertyName = "stkdes";
            this.col_stkdes.HeaderText = "รายละเอียด";
            this.col_stkdes.MinimumWidth = 320;
            this.col_stkdes.Name = "col_stkdes";
            this.col_stkdes.ReadOnly = true;
            // 
            // col_qucod
            // 
            this.col_qucod.DataPropertyName = "qucod";
            this.col_qucod.HeaderText = "";
            this.col_qucod.MinimumWidth = 35;
            this.col_qucod.Name = "col_qucod";
            this.col_qucod.ReadOnly = true;
            this.col_qucod.Width = 35;
            // 
            // col_stkcods
            // 
            this.col_stkcods.DataPropertyName = "stkcods";
            this.col_stkcods.HeaderText = "สินค้าทดแทน";
            this.col_stkcods.MinimumWidth = 180;
            this.col_stkcods.Name = "col_stkcods";
            this.col_stkcods.ReadOnly = true;
            this.col_stkcods.Width = 180;
            // 
            // col_stktyp
            // 
            this.col_stktyp.DataPropertyName = "stktyp";
            this.col_stktyp.HeaderText = "ประเภท";
            this.col_stktyp.MinimumWidth = 60;
            this.col_stktyp.Name = "col_stktyp";
            this.col_stktyp.ReadOnly = true;
            this.col_stktyp.Width = 60;
            // 
            // col_packing
            // 
            this.col_packing.DataPropertyName = "packing";
            this.col_packing.HeaderText = "ขนาดบรรจุ";
            this.col_packing.MinimumWidth = 160;
            this.col_packing.Name = "col_packing";
            this.col_packing.ReadOnly = true;
            this.col_packing.Width = 160;
            // 
            // col_stkdes2
            // 
            this.col_stkdes2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_stkdes2.DataPropertyName = "stkdes2";
            this.col_stkdes2.HeaderText = "ชื่อภาษาอังกฤษ";
            this.col_stkdes2.MinimumWidth = 320;
            this.col_stkdes2.Name = "col_stkdes2";
            this.col_stkdes2.ReadOnly = true;
            // 
            // DialogSelectStmas
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
            this.Name = "DialogSelectStmas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.DialogSelectStmas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnReorder;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_stkcod;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_totbal;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_stkdes;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_qucod;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_stkcods;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_stktyp;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_packing;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_stkdes2;
    }
}