using PbiReportEditor.Misc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExpressBI.SubForm
{
    public partial class DialogSelectStmas : Form
    {
        private BindingList<Stmas> binding_list;
        private string sorted_col = "stkcod";
        public string selected_stkcod = null;
        private string init_stkcod = null;

        public DialogSelectStmas(List<Stmas> list_stmas, string init_stkcod = "")
        {
            this.binding_list = new BindingList<Stmas>(list_stmas);
            this.init_stkcod = init_stkcod;
            InitializeComponent();
        }

        private void DialogSelectStmas_Load(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = this.binding_list;

            if(this.init_stkcod.Trim().Length > 0)
            {
                var selected_row = this.dataGridView1.Rows.Cast<DataGridViewRow>().Where(r => ((string)r.Cells[this.col_stkcod.Name].Value).CompareTo(this.init_stkcod) >= 0).FirstOrDefault();
                if (selected_row != null)
                    selected_row.Cells[this.dataGridView1.FirstDisplayedScrollingColumnIndex].Selected = true;
            }
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string prop_name = ((DataGridView)sender).Columns[e.ColumnIndex].DataPropertyName;
            if (prop_name == "stkcod" || prop_name == "stkdes")
                this.ReorderDatagridviewRow(prop_name);
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1)    // Draw order sign on column header
            {
                var col_prop_name = ((DataGridView)sender).Columns[e.ColumnIndex].DataPropertyName;

                if (col_prop_name == "stkcod" || col_prop_name == "stkdes")
                {
                    if (col_prop_name == this.sorted_col)
                    {
                        e.CellStyle.BackColor = Color.FromArgb(95, 235, 2);
                        e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                        e.Graphics.FillPolygon(new SolidBrush(Color.DarkSeaGreen), new Point[] { new Point(e.CellBounds.Right - 15, e.CellBounds.Top + 7), new Point(e.CellBounds.Right - 20, e.CellBounds.Bottom - 7), new Point(e.CellBounds.Right - 10, e.CellBounds.Bottom - 7) });
                        e.Graphics.DrawPolygon(new Pen(Color.DarkGreen), new Point[] { new Point(e.CellBounds.Right - 15, e.CellBounds.Top + 7), new Point(e.CellBounds.Right - 20, e.CellBounds.Bottom - 7), new Point(e.CellBounds.Right - 10, e.CellBounds.Bottom - 7) });
                        e.Handled = true;
                    }
                    else
                    {
                        e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                        e.Graphics.DrawPolygon(new Pen(Color.Gray), new Point[] { new Point(e.CellBounds.Right - 15, e.CellBounds.Top + 7), new Point(e.CellBounds.Right - 20, e.CellBounds.Bottom - 7), new Point(e.CellBounds.Right - 10, e.CellBounds.Bottom - 7) });
                        e.Handled = true;
                    }
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DialogInlineSearch ds = new DialogInlineSearch();
            ds.SetBounds(this.btnOK.PointToScreen(Point.Empty).X - 15, this.btnOK.PointToScreen(Point.Empty).Y - 15, ds.Bounds.Width, ds.Bounds.Height);

            if (ds.ShowDialog() == DialogResult.OK)
            {
                this.FindingMatchSearchKeyword(ds.keyword);
            }
        }

        private void btnReorder_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{TAB}");
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            if (((DataGridView)sender).CurrentCell != null)
            {
                this.btnOK.Enabled = true;

                this.selected_stkcod = (string)((DataGridView)sender).Rows[((DataGridView)sender).CurrentCell.RowIndex].Cells[this.col_stkcod.Name].Value;
            }
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int row_index = ((DataGridView)sender).HitTest(e.X, e.Y).RowIndex;

            if (row_index > -1)
                this.btnOK.PerformClick();
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back)
            {
                base.OnKeyPress(e);
                return;
            }

            if (((char)e.KeyChar).ToString().Trim().Length > 0)
            {
                DialogInlineSearch ds = new DialogInlineSearch(((char)e.KeyChar).ToString());
                ds.SetBounds(this.btnOK.PointToScreen(Point.Empty).X - 15, this.btnOK.PointToScreen(Point.Empty).Y - 15, ds.Bounds.Width, ds.Bounds.Height);

                if (ds.ShowDialog() == DialogResult.OK)
                {
                    this.FindingMatchSearchKeyword(ds.keyword);
                }
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Tab)
            {
                if (this.sorted_col == "stkcod")
                {
                    this.ReorderDatagridviewRow("stkdes");
                }
                else
                {
                    this.ReorderDatagridviewRow("stkcod");
                }

                return true;
            }

            if (keyData == Keys.Enter)
            {
                this.btnOK.PerformClick();
                return true;
            }

            if (keyData == Keys.Escape)
            {
                this.btnCancel.PerformClick();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void ReorderDatagridviewRow(string field_name)
        {
            string prev_selected_stkcod = this.selected_stkcod;

            if (field_name == "stkcod")
            {
                this.binding_list = new BindingList<Stmas>(this.binding_list.OrderBy(b => b.stkcod, new ThaiStringComparerOrdinal()).ToList());
                this.dataGridView1.DataSource = this.binding_list;
                this.sorted_col = field_name;
            }

            if (field_name == "stkdes")
            {
                this.binding_list = new BindingList<Stmas>(this.binding_list.OrderBy(b => b.stkdes, new ThaiStringComparerOrdinal()).ToList());
                this.dataGridView1.DataSource = this.binding_list;
                this.sorted_col = field_name;
            }

            if (prev_selected_stkcod.Trim().Length > 0)
                this.dataGridView1.Rows.Cast<DataGridViewRow>().Where(r => (string)r.Cells[this.col_stkcod.Name].Value == prev_selected_stkcod).First().Cells[this.dataGridView1.FirstDisplayedScrollingColumnIndex].Selected = true;
        }

        private void FindingMatchSearchKeyword(string keyword)
        {
            DataGridViewRow target_row = null;
            if (this.sorted_col == "stkcod")
            {
                //target_row = this.dataGridView1.Rows.Cast<DataGridViewRow>().Where(r => ((string)r.Cells[this.col_stkcod.Name].Value).StartsWith(keyword)).FirstOrDefault();
                target_row = this.dataGridView1.Rows.Cast<DataGridViewRow>().Where(r => ((string)r.Cells[this.col_stkcod.Name].Value).Substring(0, keyword.Length) == keyword).FirstOrDefault();
            }

            if (this.sorted_col == "stkdes")
            {
                //target_row = this.dataGridView1.Rows.Cast<DataGridViewRow>().Where(r => ((string)r.Cells[this.col_stkdes.Name].Value).StartsWith(keyword)).FirstOrDefault();
                target_row = this.dataGridView1.Rows.Cast<DataGridViewRow>().Where(r => ((string)r.Cells[this.col_stkdes.Name].Value).Substring(0, keyword.Length) == keyword).FirstOrDefault();
            }

            if (target_row != null)
                this.dataGridView1.Rows[target_row.Index].Cells[this.dataGridView1.FirstDisplayedScrollingColumnIndex].Selected = true;
        }
    }
}
