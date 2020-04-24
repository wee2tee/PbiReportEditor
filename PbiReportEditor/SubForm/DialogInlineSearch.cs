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
    public partial class DialogInlineSearch : Form
    {
        public string keyword;

        public DialogInlineSearch(string keyword = "")
        {
            this.keyword = keyword;
            InitializeComponent();
        }

        private void InlineSearch_Load(object sender, EventArgs e)
        {
            this.txtKeyword.Text = this.keyword;
            this.txtKeyword.SelectionStart = this.txtKeyword.Text.Length;
        }

        private void txtKeyword_TextChanged(object sender, EventArgs e)
        {
            this.keyword = ((TextBox)sender).Text;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if(keyData == Keys.Enter)
            {
                this.btnOK.PerformClick();
                return true;
            }

            if(keyData == Keys.Escape)
            {
                this.btnCancel.PerformClick();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
