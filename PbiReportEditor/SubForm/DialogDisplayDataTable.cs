using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PbiReportEditor.SubForm
{
    public partial class DialogDisplayDataTable : Form
    {
        private DataTable data_table;

        public DialogDisplayDataTable(DataTable data_table)
        {
            this.data_table = data_table;
            InitializeComponent();
        }

        private void DialogDisplayDataTable_Load(object sender, EventArgs e)
        {
            this.dgv.DataSource = this.data_table;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if(keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
