namespace ExpressBI.SubForm
{
    partial class DialogSelectGlacc
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnReorder = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.col_accnum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_accnam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_group_desc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_level = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_acctyp_desc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_parent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_group = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_acctyp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnReorder
            // 
            this.btnReorder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReorder.Location = new System.Drawing.Point(272, 188);
            this.btnReorder.Name = "btnReorder";
            this.btnReorder.Size = new System.Drawing.Size(119, 29);
            this.btnReorder.TabIndex = 19;
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
            this.btnSearch.TabIndex = 18;
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
            this.btnCancel.TabIndex = 17;
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
            this.btnOK.TabIndex = 16;
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
            this.col_accnum,
            this.col_accnam,
            this.col_group_desc,
            this.col_level,
            this.col_acctyp_desc,
            this.col_parent,
            this.col_group,
            this.col_acctyp});
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(2, 7);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(630, 166);
            this.dataGridView1.StandardTab = true;
            this.dataGridView1.TabIndex = 15;
            this.dataGridView1.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
            this.dataGridView1.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_ColumnHeaderMouseClick);
            this.dataGridView1.CurrentCellChanged += new System.EventHandler(this.dataGridView1_CurrentCellChanged);
            this.dataGridView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseDoubleClick);
            // 
            // col_accnum
            // 
            this.col_accnum.DataPropertyName = "accnum";
            this.col_accnum.HeaderText = "เลขที่บัญชี";
            this.col_accnum.MinimumWidth = 120;
            this.col_accnum.Name = "col_accnum";
            this.col_accnum.ReadOnly = true;
            this.col_accnum.Width = 120;
            // 
            // col_accnam
            // 
            this.col_accnam.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_accnam.DataPropertyName = "accnam";
            dataGridViewCellStyle2.NullValue = null;
            this.col_accnam.DefaultCellStyle = dataGridViewCellStyle2;
            this.col_accnam.HeaderText = "ชื่อบัญชี";
            this.col_accnam.MinimumWidth = 250;
            this.col_accnam.Name = "col_accnam";
            this.col_accnam.ReadOnly = true;
            // 
            // col_group_desc
            // 
            this.col_group_desc.DataPropertyName = "_group_desc";
            this.col_group_desc.HeaderText = "หมวด";
            this.col_group_desc.MinimumWidth = 80;
            this.col_group_desc.Name = "col_group_desc";
            this.col_group_desc.ReadOnly = true;
            this.col_group_desc.Width = 80;
            // 
            // col_level
            // 
            this.col_level.DataPropertyName = "level";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.col_level.DefaultCellStyle = dataGridViewCellStyle3;
            this.col_level.HeaderText = "ระดับ";
            this.col_level.MinimumWidth = 60;
            this.col_level.Name = "col_level";
            this.col_level.ReadOnly = true;
            this.col_level.Width = 60;
            // 
            // col_acctyp_desc
            // 
            this.col_acctyp_desc.DataPropertyName = "_acctyp_desc";
            this.col_acctyp_desc.HeaderText = "ประเภท";
            this.col_acctyp_desc.MinimumWidth = 70;
            this.col_acctyp_desc.Name = "col_acctyp_desc";
            this.col_acctyp_desc.ReadOnly = true;
            this.col_acctyp_desc.Width = 70;
            // 
            // col_parent
            // 
            this.col_parent.DataPropertyName = "parent";
            this.col_parent.HeaderText = "บัญชีคุม";
            this.col_parent.MinimumWidth = 120;
            this.col_parent.Name = "col_parent";
            this.col_parent.ReadOnly = true;
            this.col_parent.Width = 120;
            // 
            // col_group
            // 
            this.col_group.DataPropertyName = "group";
            this.col_group.HeaderText = "Group";
            this.col_group.Name = "col_group";
            this.col_group.ReadOnly = true;
            this.col_group.Visible = false;
            // 
            // col_acctyp
            // 
            this.col_acctyp.DataPropertyName = "acctyp";
            this.col_acctyp.HeaderText = "Acctyp";
            this.col_acctyp.Name = "col_acctyp";
            this.col_acctyp.ReadOnly = true;
            this.col_acctyp.Visible = false;
            // 
            // DialogSelectGlacc
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
            this.Name = "DialogSelectGlacc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.DialogSelectGlacc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnReorder;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_accnum;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_accnam;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_group_desc;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_level;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_acctyp_desc;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_parent;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_group;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_acctyp;
    }
}