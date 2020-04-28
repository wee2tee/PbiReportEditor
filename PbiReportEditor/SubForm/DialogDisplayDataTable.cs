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
            this.Text += "  [ " + this.data_table.Rows.Count + " Row(s) ]";
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

        private void dgv_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if(e.RowIndex == 0)
            {
                ((DataGridView)sender).Columns.Cast<DataGridViewColumn>().ToList().ForEach(c =>
                {
                    var cell = ((DataGridView)sender).Rows[e.RowIndex].Cells[c.Index];

                    if(cell.Value.GetType() == typeof(DateTime))
                    {
                        c.DefaultCellStyle.Format = "dd/MM/yyyy";
                    }

                    if(cell.Value.GetType() == typeof(Int32))
                    {
                        c.DefaultCellStyle.Format = "N0";
                        c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }

                    if(cell.Value.GetType() == typeof(double) || cell.Value.GetType() == typeof(float))
                    {
                        c.DefaultCellStyle.Format = "N2";
                        c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }
                });
            }
        }
    }
}
