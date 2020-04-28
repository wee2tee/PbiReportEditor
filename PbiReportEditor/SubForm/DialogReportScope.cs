using CC;
using ExpressBI.SubForm;
using Newtonsoft.Json;
using PbiReportEditor.Misc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PbiReportEditor.SubForm
{
    public partial class DialogReportScope : Form
    {
        public DataTable data_table;
        public QueryModel query_model;

        private FormReportEditor form_report_editor;
        private string data_path = null;
        private List<Control> controlScope = new List<Control>();

        private List<Armas> list_armas;
        private List<Apmas> list_apmas;
        private List<Stmas> list_stmas;
        private List<Glacc> list_glacc;
        private List<Slm> list_slm;
        private List<Istab> list_dep;
        private List<Istab> list_loc;
        private List<Istab> list_stkgrp;
        private List<Istab> list_area;
        private List<Istab> list_suptyp;
        private List<Istab> list_custyp;

        public DialogReportScope(FormReportEditor form_report_editor, QueryModel query_model, string data_path = null)
        {
            this.form_report_editor = form_report_editor;
            this.query_model = query_model;

            InitializeComponent();

            if (data_path != null && data_path.Trim().Length > 0)
            {
                this.txtPath.Text = data_path;
            }
        }

        private void DialogReportScope_Load(object sender, EventArgs e)
        {
            if(this.data_path == null || this.data_path.Trim().Length == 0)
            {
                DialogDataPath d = new DialogDataPath(this.data_path);
                if (d.ShowDialog() == DialogResult.OK)
                {
                    this.txtPath.Text = d.data_path;
                }
                else
                {
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                    return;
                }
            }

            this.PrepareNecessaryData();
            this.ShowControlScope(this.query_model);
        }

        private void PrepareNecessaryData()
        {
            this.list_armas = HelperDbf.GetArmas(this.data_path);
            this.list_apmas = HelperDbf.GetApmas(this.data_path);
            this.list_stmas = HelperDbf.GetStmas(this.data_path);
            this.list_glacc = HelperDbf.GetGlacc(this.data_path);
            this.list_slm = HelperDbf.GetSlm(this.data_path);
            this.list_dep = HelperDbf.GetDep(this.data_path);
            this.list_loc = HelperDbf.GetLoc(this.data_path);
            this.list_stkgrp = HelperDbf.GetStkgrp(this.data_path);
            this.list_area = HelperDbf.GetArea(this.data_path);
            this.list_suptyp = HelperDbf.GetSuptyp(this.data_path);
            this.list_custyp = HelperDbf.GetCustyp(this.data_path);
        }

        private Label CreateLabel(string label_string, int col, int y_position)
        {
            Label lbl = new Label();
            lbl.AutoSize = false;
            lbl.TextAlign = ContentAlignment.MiddleRight; //col == 1 ? ContentAlignment.MiddleRight : ContentAlignment.MiddleCenter;
            lbl.Text = label_string;
            //lbl.BorderStyle = BorderStyle.FixedSingle;

            int x = col == 1 ? 20 : col == 3 ? 315 : -99999;
            int width = col == 1 ? 130 : col == 3 ? 30 : 0;

            lbl.SetBounds(x, y_position, width, lbl.Height);

            return lbl;
        }

        private void ClearControlScope()
        {
            this.panel1.Controls.Cast<Control>().ToList().ForEach(c =>
            {
                this.panel1.Controls.Remove(c);
            });
        }

        private void ShowControlScope(QueryModel qm)
        {
            this.controlScope.Clear();
            int cnt_ctrl = 0;
            int tabindex = 0;
            foreach (var scope in qm.controlScope)
            {
                int col1 = 20;
                int col2 = 155;
                int col3 = 320;
                int col4 = 350;
                int line_height = 28;
                int y = 10;
                cnt_ctrl++;

                switch (scope.controlType)
                {
                    #region Datetime
                    case ControlType.DateAs:
                        this.panel1.Controls.Add(this.CreateLabel(scope.label[0], 1, y + (cnt_ctrl * line_height)));
                        var dateAs = new XDatePicker();
                        dateAs.Tag = scope.bindingTo + "=CTOD('  /  /    ')";
                        dateAs._SelectedDateChanged += delegate (object sender, EventArgs e)
                        {
                            dateAs.Tag = scope.bindingTo + "=" + (((XDatePicker)sender)._SelectedDate.HasValue ? "CTOD('" + ((XDatePicker)sender)._SelectedDate.Value.ToString("MM/dd/yyyy", CultureInfo.GetCultureInfo("en-US")) + "')" : "CTOD('  /  /    ')");
                        };
                        dateAs.SetBounds(col2, y + (cnt_ctrl * line_height), 118, dateAs.Bounds.Height);
                        dateAs.TabIndex = ++tabindex;
                        dateAs.txtDate.KeyPress += delegate (object sender, KeyPressEventArgs e)
                        {
                            if (e.KeyChar == (char)13)
                            {
                                SendKeys.Send("{TAB}");
                            }
                        };
                        this.panel1.Controls.Add(dateAs);
                        this.controlScope.Add(dateAs);
                        break;
                    case ControlType.DateRange:
                        this.panel1.Controls.Add(this.CreateLabel(scope.label[0], 1, y + (cnt_ctrl * line_height)));
                        var dateFrom = new XDatePicker();
                        dateFrom.Tag = scope.bindingTo + "=CTOD('  /  /    ')";
                        dateFrom._SelectedDateChanged += delegate (object sender, EventArgs e)
                        {
                            dateFrom.Tag = scope.bindingTo + ">=" + (((XDatePicker)sender)._SelectedDate.HasValue ? "CTOD('" + ((XDatePicker)sender)._SelectedDate.Value.ToString("MM/dd/yyyy", CultureInfo.GetCultureInfo("en-US")) + "')" : "CTOD('  /  /    ')");
                        };
                        dateFrom.SetBounds(col2, y + (cnt_ctrl * line_height), 118, dateFrom.Bounds.Height);
                        dateFrom.TabIndex = ++tabindex;
                        dateFrom.txtDate.KeyPress += delegate (object sender, KeyPressEventArgs e)
                        {
                            if (e.KeyChar == (char)13)
                            {
                                SendKeys.Send("{TAB}");
                            }
                        };
                        this.panel1.Controls.Add(dateFrom);
                        this.controlScope.Add(dateFrom);

                        this.panel1.Controls.Add(this.CreateLabel(scope.label[1], 3, y + (cnt_ctrl * line_height)));
                        var dateTo = new XDatePicker();
                        dateTo.Tag = scope.bindingTo + "=CTOD('  /  /    ')";
                        dateTo._SelectedDateChanged += delegate (object sender, EventArgs e)
                        {
                            dateTo.Tag = scope.bindingTo + "<=" + (((XDatePicker)sender)._SelectedDate.HasValue ? "CTOD('" + ((XDatePicker)sender)._SelectedDate.Value.ToString("MM/dd/yyyy", CultureInfo.GetCultureInfo("en-US")) + "')" : "CTOD('  /  /    ')");
                        };
                        dateTo.SetBounds(col4, y + (cnt_ctrl * line_height), 118, dateTo.Bounds.Height);
                        dateTo.TabIndex = ++tabindex;
                        dateTo.txtDate.KeyPress += delegate (object sender, KeyPressEventArgs e)
                        {
                            if (e.KeyChar == (char)13)
                            {
                                SendKeys.Send("{TAB}");
                            }
                        };
                        this.panel1.Controls.Add(dateTo);
                        this.controlScope.Add(dateTo);
                        break;
                    #endregion Datetime
                    #region Armas
                    case ControlType.CusAs:
                        this.panel1.Controls.Add(this.CreateLabel(scope.label[0], 1, y + (cnt_ctrl * line_height)));
                        var custAs = new XBrowseBox();
                        custAs.Tag = scope.bindingTo + "=''";
                        custAs._ButtonClick += delegate (object sender, EventArgs e)
                        {
                            using (DialogSelectArmas dl = new DialogSelectArmas(this.list_armas, custAs._Text))
                            {
                                dl.SetBounds(custAs.PointToScreen(Point.Empty).X, custAs.PointToScreen(Point.Empty).Y + custAs.Bounds.Height, dl.Bounds.Width, dl.Bounds.Height);
                                if (dl.ShowDialog() == DialogResult.OK)
                                {
                                    custAs._Text = dl.selected_cuscod;
                                }
                            }
                        };
                        custAs._Leave += delegate (object sender, EventArgs e)
                        {
                            if (custAs._Text.Trim().Length == 0 || custAs._Text.Trim().Length != 0 && this.list_armas.Where(a => a.cuscod == custAs._Text).Count() != 0)
                                return;

                            custAs.Focus();
                            custAs.PerformButtonClick();
                            custAs._textBox.SelectionStart = custAs._Text.Length;
                        };
                        custAs._TextChanged += delegate (object sender, EventArgs e)
                        {
                            custAs.Tag = scope.bindingTo + "='" + custAs._Text + "'";
                        };
                        custAs.SetBounds(col2, y + (cnt_ctrl * line_height), custAs.Bounds.Width, custAs.Bounds.Height);
                        custAs.TabIndex = ++tabindex;
                        custAs._textBox.KeyPress += delegate (object sender, KeyPressEventArgs e)
                        {
                            if (e.KeyChar == (char)13)
                            {
                                SendKeys.Send("{TAB}");
                            }
                        };
                        this.panel1.Controls.Add(custAs);
                        this.controlScope.Add(custAs);
                        break;
                    case ControlType.CusRange:
                        this.panel1.Controls.Add(this.CreateLabel(scope.label[0], 1, y + (cnt_ctrl * line_height)));
                        var custFrom = new XBrowseBox();
                        custFrom.Tag = scope.bindingTo + ">=''";
                        custFrom._ButtonClick += delegate (object sender, EventArgs e)
                        {
                            using (DialogSelectArmas dl = new DialogSelectArmas(this.list_armas, custFrom._Text))
                            {
                                dl.SetBounds(custFrom.PointToScreen(Point.Empty).X, custFrom.PointToScreen(Point.Empty).Y + custFrom.Bounds.Height, dl.Bounds.Width, dl.Bounds.Height);
                                if (dl.ShowDialog() == DialogResult.OK)
                                {
                                    custFrom._Text = dl.selected_cuscod;
                                }
                            }
                        };
                        custFrom._Leave += delegate (object sender, EventArgs e)
                        {
                            if (custFrom._Text.Trim().Length == 0 || custFrom._Text.Trim().Length != 0 && this.list_armas.Where(a => a.cuscod == custFrom._Text).Count() != 0)
                                return;

                            custFrom.Focus();
                            custFrom.PerformButtonClick();
                            custFrom._textBox.SelectionStart = custFrom._Text.Length;
                        };

                        custFrom._TextChanged += delegate (object sender, EventArgs e)
                        {
                            custFrom.Tag = scope.bindingTo + ">='" + custFrom._Text + "'";
                        };
                        custFrom.SetBounds(col2, y + (cnt_ctrl * line_height), custFrom.Bounds.Width, custFrom.Bounds.Height);
                        custFrom.TabIndex = ++tabindex;
                        custFrom._textBox.KeyPress += delegate (object sender, KeyPressEventArgs e)
                        {
                            if (e.KeyChar == (char)13)
                            {
                                SendKeys.Send("{TAB}");
                            }
                        };
                        this.panel1.Controls.Add(custFrom);
                        this.controlScope.Add(custFrom);

                        this.panel1.Controls.Add(this.CreateLabel(scope.label[1], 3, y + (cnt_ctrl * line_height)));
                        var custTo = new XBrowseBox();
                        custTo.Tag = scope.bindingTo + "<=''";
                        custTo._ButtonClick += delegate (object sender, EventArgs e)
                        {
                            using (DialogSelectArmas dl = new DialogSelectArmas(this.list_armas, custTo._Text))
                            {
                                dl.SetBounds(custTo.PointToScreen(Point.Empty).X, custTo.PointToScreen(Point.Empty).Y + custTo.Bounds.Height, dl.Bounds.Width, dl.Bounds.Height);
                                if (dl.ShowDialog() == DialogResult.OK)
                                {
                                    custTo._Text = dl.selected_cuscod;
                                }
                            }
                        };
                        custTo._Leave += delegate (object sender, EventArgs e)
                        {
                            if (custTo._Text.Trim().Length == 0 || custTo._Text.Trim().Length != 0 && this.list_armas.Where(a => a.cuscod == custTo._Text).Count() != 0)
                                return;

                            custTo.Focus();
                            custTo.PerformButtonClick();
                            custTo._textBox.SelectionStart = custTo._Text.Length;
                        };
                        custTo._TextChanged += delegate (object sender, EventArgs e)
                        {
                            custTo.Tag = scope.bindingTo + "<='" + custTo._Text + "'";
                        };
                        custTo.SetBounds(col4, y + (cnt_ctrl * line_height), custTo.Bounds.Width, custTo.Bounds.Height);
                        custTo.TabIndex = ++tabindex;
                        custTo._textBox.KeyPress += delegate (object sender, KeyPressEventArgs e)
                        {
                            if (e.KeyChar == (char)13)
                            {
                                SendKeys.Send("{TAB}");
                            }
                        };
                        custTo._Text = this.list_armas.Count == 0 ? string.Empty : this.list_armas.Last().cuscod.TrimEnd();
                        this.panel1.Controls.Add(custTo);
                        this.controlScope.Add(custTo);
                        break;
                    #endregion Armas
                    #region Apmas
                    case ControlType.SupAs:
                        this.panel1.Controls.Add(this.CreateLabel(scope.label[0], 1, y + (cnt_ctrl * line_height)));
                        var supAs = new XBrowseBox();
                        supAs.Tag = scope.bindingTo + "=''";
                        supAs._ButtonClick += delegate (object sender, EventArgs e)
                        {
                            DialogSelectApmas ds = new DialogSelectApmas(this.list_apmas, supAs._Text);
                            ds.SetBounds(supAs.PointToScreen(Point.Empty).X, supAs.PointToScreen(Point.Empty).Y + supAs.Bounds.Height, ds.Bounds.Width, ds.Bounds.Height);
                            if (ds.ShowDialog() == DialogResult.OK)
                            {
                                supAs._Text = ds.selected_supcod;
                            }
                        };
                        supAs._Leave += delegate (object sender, EventArgs e)
                        {
                            if (supAs._Text.Trim().Length == 0 || supAs._Text.Trim().Length != 0 && this.list_apmas.Where(a => a.supcod == supAs._Text).Count() != 0)
                                return;

                            supAs.Focus();
                            supAs.PerformButtonClick();
                            supAs._textBox.SelectionStart = supAs._Text.Length;
                        };
                        supAs._TextChanged += delegate (object sender, EventArgs e)
                        {
                            supAs.Tag = scope.bindingTo + "='" + supAs._Text + "'";
                        };
                        supAs.SetBounds(col2, y + (cnt_ctrl * line_height), supAs.Bounds.Width, supAs.Bounds.Height);
                        supAs.TabIndex = ++tabindex;
                        supAs._textBox.KeyPress += delegate (object sender, KeyPressEventArgs e)
                        {
                            if (e.KeyChar == (char)13)
                            {
                                SendKeys.Send("{TAB}");
                            }
                        };
                        this.panel1.Controls.Add(supAs);
                        this.controlScope.Add(supAs);
                        break;
                    case ControlType.SupRange:
                        this.panel1.Controls.Add(this.CreateLabel(scope.label[0], 1, y + (cnt_ctrl * line_height)));
                        var supFrom = new XBrowseBox();
                        supFrom.Tag = scope.bindingTo + ">=''";
                        supFrom._ButtonClick += delegate (object sender, EventArgs e)
                        {
                            DialogSelectApmas ds = new DialogSelectApmas(this.list_apmas, supFrom._Text);
                            ds.SetBounds(supFrom.PointToScreen(Point.Empty).X, supFrom.PointToScreen(Point.Empty).Y + supFrom.Bounds.Height, ds.Bounds.Width, ds.Bounds.Height);
                            if (ds.ShowDialog() == DialogResult.OK)
                            {
                                supFrom._Text = ds.selected_supcod;
                            }
                        };
                        supFrom._Leave += delegate (object sender, EventArgs e)
                        {
                            if (supFrom._Text.Trim().Length == 0 || supFrom._Text.Trim().Length != 0 && this.list_apmas.Where(a => a.supcod == supFrom._Text).Count() != 0)
                                return;

                            supFrom.Focus();
                            supFrom.PerformButtonClick();
                            supFrom._textBox.SelectionStart = supFrom._Text.Length;
                        };
                        supFrom._TextChanged += delegate (object sender, EventArgs e)
                        {
                            supFrom.Tag = scope.bindingTo + ">='" + supFrom._Text + "'";
                        };
                        supFrom.SetBounds(col2, y + (cnt_ctrl * line_height), supFrom.Bounds.Width, supFrom.Bounds.Height);
                        supFrom.TabIndex = ++tabindex;
                        supFrom._textBox.KeyPress += delegate (object sender, KeyPressEventArgs e)
                        {
                            if (e.KeyChar == (char)13)
                            {
                                SendKeys.Send("{TAB}");
                            }
                        };
                        this.panel1.Controls.Add(supFrom);
                        this.controlScope.Add(supFrom);

                        this.panel1.Controls.Add(this.CreateLabel(scope.label[1], 3, y + (cnt_ctrl * line_height)));
                        var supTo = new XBrowseBox();
                        supTo.Tag = scope.bindingTo + "<=''";
                        supTo._ButtonClick += delegate (object sender, EventArgs e)
                        {
                            DialogSelectApmas ds = new DialogSelectApmas(this.list_apmas, supTo._Text);
                            ds.SetBounds(supTo.PointToScreen(Point.Empty).X, supTo.PointToScreen(Point.Empty).Y + supTo.Bounds.Height, ds.Bounds.Width, ds.Bounds.Height);
                            if (ds.ShowDialog() == DialogResult.OK)
                            {
                                supTo._Text = ds.selected_supcod;
                            }
                        };
                        supTo._Leave += delegate (object sender, EventArgs e)
                        {
                            if (supTo._Text.Trim().Length == 0 || supTo._Text.Trim().Length != 0 && this.list_apmas.Where(a => a.supcod == supTo._Text).Count() != 0)
                                return;

                            supTo.Focus();
                            supTo.PerformButtonClick();
                            supTo._textBox.SelectionStart = supTo._Text.Length;
                        };
                        supTo._TextChanged += delegate (object sender, EventArgs e)
                        {
                            supTo.Tag = scope.bindingTo + "<='" + supTo._Text + "'";
                        };
                        supTo.SetBounds(col4, y + (cnt_ctrl * line_height), supTo.Bounds.Width, supTo.Bounds.Height);
                        supTo.TabIndex = ++tabindex;
                        supTo._textBox.KeyPress += delegate (object sender, KeyPressEventArgs e)
                        {
                            if (e.KeyChar == (char)13)
                            {
                                SendKeys.Send("{TAB}");
                            }
                        };
                        supTo._Text = this.list_apmas.Count == 0 ? string.Empty : this.list_apmas.Last().supcod.TrimEnd();
                        this.panel1.Controls.Add(supTo);
                        this.controlScope.Add(supTo);
                        break;
                    #endregion Apmas
                    #region Stmas
                    case ControlType.StkAs:
                        this.panel1.Controls.Add(this.CreateLabel(scope.label[0], 1, y + (cnt_ctrl * line_height)));
                        var stkAs = new XBrowseBox();
                        stkAs.Tag = scope.bindingTo + "=''";
                        stkAs._ButtonClick += delegate (object sender, EventArgs e)
                        {
                            DialogSelectStmas ds = new DialogSelectStmas(this.list_stmas, stkAs._Text);
                            ds.SetBounds(stkAs.PointToScreen(Point.Empty).X, stkAs.PointToScreen(Point.Empty).Y + stkAs.Bounds.Height, ds.Width, ds.Height);
                            if (ds.ShowDialog() == DialogResult.OK)
                            {
                                stkAs._Text = ds.selected_stkcod;
                            }
                        };
                        stkAs._Leave += delegate (object sender, EventArgs e)
                        {
                            if (stkAs._Text.Trim().Length == 0 || stkAs._Text.Trim().Length != 0 && this.list_stmas.Where(a => a.stkcod == stkAs._Text).Count() != 0)
                                return;

                            stkAs.Focus();
                            stkAs.PerformButtonClick();
                            stkAs._textBox.SelectionStart = stkAs._Text.Length;
                        };
                        stkAs._TextChanged += delegate (object sender, EventArgs e)
                        {
                            stkAs.Tag = scope.bindingTo + "='" + stkAs._Text + "'";
                        };
                        stkAs.SetBounds(col2, y + (cnt_ctrl * line_height), /*stkAs.Bounds.Width*/160, stkAs.Bounds.Height);
                        stkAs.TabIndex = ++tabindex;
                        stkAs._textBox.KeyPress += delegate (object sender, KeyPressEventArgs e)
                        {
                            if (e.KeyChar == (char)13)
                            {
                                SendKeys.Send("{TAB}");
                            }
                        };
                        this.panel1.Controls.Add(stkAs);
                        this.controlScope.Add(stkAs);
                        break;
                    case ControlType.StkRange:
                        this.panel1.Controls.Add(this.CreateLabel(scope.label[0], 1, y + (cnt_ctrl * line_height)));
                        var stkFrom = new XBrowseBox();
                        stkFrom.Tag = scope.bindingTo + ">=''";
                        stkFrom._ButtonClick += delegate (object sender, EventArgs e)
                        {
                            DialogSelectStmas ds = new DialogSelectStmas(this.list_stmas, stkFrom._Text);
                            ds.SetBounds(stkFrom.PointToScreen(Point.Empty).X, stkFrom.PointToScreen(Point.Empty).Y + stkFrom.Bounds.Height, ds.Width, ds.Height);
                            if (ds.ShowDialog() == DialogResult.OK)
                            {
                                stkFrom._Text = ds.selected_stkcod;
                            }
                        };
                        stkFrom._Leave += delegate (object sender, EventArgs e)
                        {
                            if (stkFrom._Text.Trim().Length == 0 || stkFrom._Text.Trim().Length != 0 && this.list_stmas.Where(a => a.stkcod == stkFrom._Text).Count() != 0)
                                return;

                            stkFrom.Focus();
                            stkFrom.PerformButtonClick();
                            stkFrom._textBox.SelectionStart = stkFrom._Text.Length;
                        };
                        stkFrom._TextChanged += delegate (object sender, EventArgs e)
                        {
                            stkFrom.Tag = scope.bindingTo + ">='" + stkFrom._Text + "'";
                        };
                        stkFrom.SetBounds(col2, y + (cnt_ctrl * line_height), /*stkFrom.Bounds.Width*/ 160, stkFrom.Bounds.Height);
                        stkFrom.TabIndex = ++tabindex;
                        stkFrom._textBox.KeyPress += delegate (object sender, KeyPressEventArgs e)
                        {
                            if (e.KeyChar == (char)13)
                            {
                                SendKeys.Send("{TAB}");
                            }
                        };
                        stkFrom._Text = this.list_stmas.Count == 0 ? string.Empty : this.list_stmas.First().stkcod.TrimEnd();
                        this.panel1.Controls.Add(stkFrom);
                        this.controlScope.Add(stkFrom);

                        this.panel1.Controls.Add(this.CreateLabel(scope.label[1], 3, y + (cnt_ctrl * line_height)));
                        var stkTo = new XBrowseBox();
                        stkTo.Tag = scope.bindingTo + "<=''";
                        stkTo._ButtonClick += delegate (object sender, EventArgs e)
                        {
                            DialogSelectStmas ds = new DialogSelectStmas(this.list_stmas, stkTo._Text);
                            ds.SetBounds(stkTo.PointToScreen(Point.Empty).X, stkTo.PointToScreen(Point.Empty).Y + stkTo.Bounds.Height, ds.Width, ds.Height);
                            if (ds.ShowDialog() == DialogResult.OK)
                            {
                                stkTo._Text = ds.selected_stkcod;
                            }
                        };
                        stkTo._Leave += delegate (object sender, EventArgs e)
                        {
                            if (stkTo._Text.Trim().Length == 0 || stkTo._Text.Trim().Length != 0 && this.list_stmas.Where(a => a.stkcod == stkTo._Text).Count() != 0)
                                return;

                            stkTo.Focus();
                            stkTo.PerformButtonClick();
                            stkTo._textBox.SelectionStart = stkTo._Text.Length;
                        };
                        stkTo._TextChanged += delegate (object sender, EventArgs e)
                        {
                            stkTo.Tag = scope.bindingTo + "<='" + stkTo._Text + "'";
                        };
                        stkTo.SetBounds(col4, y + (cnt_ctrl * line_height), /*stkTo.Bounds.Width*/ 160, stkTo.Bounds.Height);
                        stkTo.TabIndex = ++tabindex;
                        stkTo._textBox.KeyPress += delegate (object sender, KeyPressEventArgs e)
                        {
                            if (e.KeyChar == (char)13)
                            {
                                SendKeys.Send("{TAB}");
                            }
                        };
                        stkTo._Text = this.list_stmas.Count == 0 ? string.Empty : this.list_stmas.Last().stkcod.TrimEnd();
                        this.panel1.Controls.Add(stkTo);
                        this.controlScope.Add(stkTo);
                        break;
                    #endregion Stmas
                    #region Glacc
                    case ControlType.AccAs:
                        this.panel1.Controls.Add(this.CreateLabel(scope.label[0], 1, y + (cnt_ctrl * line_height)));
                        var accAs = new XBrowseBox();
                        accAs.Tag = scope.bindingTo + "=''";
                        accAs._ButtonClick += delegate (object sender, EventArgs e)
                        {
                            DialogSelectGlacc ds = new DialogSelectGlacc(this.list_glacc, accAs._Text);
                            ds.SetBounds(accAs.PointToScreen(Point.Empty).X, accAs.PointToScreen(Point.Empty).Y + accAs.Bounds.Height, ds.Bounds.Width, ds.Bounds.Height);
                            if (ds.ShowDialog() == DialogResult.OK)
                            {
                                accAs._Text = ds.selected_accnum;
                            }
                        };
                        accAs._Leave += delegate (object sender, EventArgs e)
                        {
                            if (accAs._Text.Trim().Length == 0 || accAs._Text.Trim().Length != 0 && this.list_glacc.Where(a => a.accnum == accAs._Text).Count() != 0)
                                return;

                            accAs.Focus();
                            accAs.PerformButtonClick();
                            accAs._textBox.SelectionStart = accAs._Text.Length;
                        };
                        accAs._TextChanged += delegate (object sender, EventArgs e)
                        {
                            accAs.Tag = scope.bindingTo + "='" + accAs._Text + "'";
                        };
                        accAs.SetBounds(col2, y + (cnt_ctrl * line_height), accAs.Bounds.Width, accAs.Bounds.Height);
                        accAs.TabIndex = ++tabindex;
                        accAs._textBox.KeyPress += delegate (object sender, KeyPressEventArgs e)
                        {
                            if (e.KeyChar == (char)13)
                            {
                                SendKeys.Send("{TAB}");
                            }
                        };
                        this.panel1.Controls.Add(accAs);
                        this.controlScope.Add(accAs);
                        break;
                    case ControlType.AccRange:
                        this.panel1.Controls.Add(this.CreateLabel(scope.label[0], 1, y + (cnt_ctrl * line_height)));
                        var accFrom = new XBrowseBox();
                        accFrom.Tag = scope.bindingTo + ">=''";
                        accFrom._ButtonClick += delegate (object sender, EventArgs e)
                        {
                            DialogSelectGlacc ds = new DialogSelectGlacc(this.list_glacc, accFrom._Text);
                            ds.SetBounds(accFrom.PointToScreen(Point.Empty).X, accFrom.PointToScreen(Point.Empty).Y + accFrom.Bounds.Height, ds.Bounds.Width, ds.Bounds.Height);
                            if (ds.ShowDialog() == DialogResult.OK)
                            {
                                accFrom._Text = ds.selected_accnum;
                            }
                        };
                        accFrom._Leave += delegate (object sender, EventArgs e)
                        {
                            if (accFrom._Text.Trim().Length == 0 || accFrom._Text.Trim().Length != 0 && this.list_glacc.Where(a => a.accnum == accFrom._Text).Count() != 0)
                                return;

                            accFrom.Focus();
                            accFrom.PerformButtonClick();
                            accFrom._textBox.SelectionStart = accFrom._Text.Length;
                        };
                        accFrom._TextChanged += delegate (object sender, EventArgs e)
                        {
                            accFrom.Tag = scope.bindingTo + ">='" + accFrom._Text + "'";
                        };
                        accFrom.SetBounds(col2, y + (cnt_ctrl * line_height), accFrom.Bounds.Width, accFrom.Bounds.Height);
                        accFrom.TabIndex = ++tabindex;
                        accFrom._textBox.KeyPress += delegate (object sender, KeyPressEventArgs e)
                        {
                            if (e.KeyChar == (char)13)
                            {
                                SendKeys.Send("{TAB}");
                            }
                        };
                        this.panel1.Controls.Add(accFrom);
                        this.controlScope.Add(accFrom);

                        this.panel1.Controls.Add(this.CreateLabel(scope.label[1], 3, y + (cnt_ctrl * line_height)));
                        var accTo = new XBrowseBox();
                        accTo.Tag = scope.bindingTo + "<=''";
                        accTo._ButtonClick += delegate (object sender, EventArgs e)
                        {
                            DialogSelectGlacc ds = new DialogSelectGlacc(this.list_glacc, accTo._Text);
                            ds.SetBounds(accTo.PointToScreen(Point.Empty).X, accTo.PointToScreen(Point.Empty).Y + accTo.Bounds.Height, ds.Bounds.Width, ds.Bounds.Height);
                            if (ds.ShowDialog() == DialogResult.OK)
                            {
                                accTo._Text = ds.selected_accnum;
                            }
                        };
                        accTo._Leave += delegate (object sender, EventArgs e)
                        {
                            if (accTo._Text.Trim().Length == 0 || accTo._Text.Trim().Length != 0 && this.list_glacc.Where(a => a.accnum == accTo._Text).Count() != 0)
                                return;

                            accTo.Focus();
                            accTo.PerformButtonClick();
                            accTo._textBox.SelectionStart = accTo._Text.Length;
                        };
                        accTo._TextChanged += delegate (object sender, EventArgs e)
                        {
                            accTo.Tag = scope.bindingTo + "<='" + accTo._Text + "'";
                        };
                        accTo.SetBounds(col4, y + (cnt_ctrl * line_height), accTo.Bounds.Width, accTo.Bounds.Height);
                        accTo.TabIndex = ++tabindex;
                        accTo._textBox.KeyPress += delegate (object sender, KeyPressEventArgs e)
                        {
                            if (e.KeyChar == (char)13)
                            {
                                SendKeys.Send("{TAB}");
                            }
                        };
                        accTo._Text = this.list_glacc.Count == 0 ? string.Empty : this.list_glacc.Last().accnum.TrimEnd();
                        this.panel1.Controls.Add(accTo);
                        this.controlScope.Add(accTo);
                        break;
                    #endregion Glacc
                    #region Docnum
                    case ControlType.DocAs:
                        this.panel1.Controls.Add(this.CreateLabel(scope.label[0], 1, y + (cnt_ctrl * line_height)));
                        var docAs = new XTextEdit();
                        docAs.Tag = scope.bindingTo + "=''";
                        docAs._TextChanged += delegate (object sender, EventArgs e)
                        {
                            docAs.Tag = scope.bindingTo + "='" + docAs._Text + "'";
                        };
                        docAs.SetBounds(col2, y + (cnt_ctrl * line_height), 118, docAs.Bounds.Height);
                        docAs.TabIndex = ++tabindex;
                        docAs.textBox1.KeyPress += delegate (object sender, KeyPressEventArgs e)
                        {
                            if (e.KeyChar == (char)13)
                            {
                                SendKeys.Send("{TAB}");
                            }
                        };
                        this.panel1.Controls.Add(docAs);
                        this.controlScope.Add(docAs);
                        break;
                    case ControlType.DocRange:
                        this.panel1.Controls.Add(this.CreateLabel(scope.label[0], 1, y + (cnt_ctrl * line_height)));
                        var docFrom = new XTextEdit();
                        docFrom.Tag = scope.bindingTo + ">=''";
                        docFrom._TextChanged += delegate (object sender, EventArgs e)
                        {
                            docFrom.Tag = scope.bindingTo + ">='" + docFrom._Text + "'";
                        };
                        docFrom.SetBounds(col2, y + (cnt_ctrl * line_height), 118, docFrom.Bounds.Height);
                        docFrom.TabIndex = ++tabindex;
                        docFrom.textBox1.KeyPress += delegate (object sender, KeyPressEventArgs e)
                        {
                            if (e.KeyChar == (char)13)
                            {
                                SendKeys.Send("{TAB}");
                            }
                        };
                        this.panel1.Controls.Add(docFrom);
                        this.controlScope.Add(docFrom);

                        this.panel1.Controls.Add(this.CreateLabel(scope.label[1], 3, y + (cnt_ctrl * line_height)));
                        var docTo = new XTextEdit();
                        docTo.Tag = scope.bindingTo + "<=''";
                        docTo._TextChanged += delegate (object sender, EventArgs e)
                        {
                            docTo.Tag = scope.bindingTo + "<='" + docTo._Text + "'";
                        };
                        docTo.SetBounds(col4, y + (cnt_ctrl * line_height), 118, docTo.Bounds.Height);
                        docTo.TabIndex = ++tabindex;
                        docTo.textBox1.KeyPress += delegate (object sender, KeyPressEventArgs e)
                        {
                            if (e.KeyChar == (char)13)
                            {
                                SendKeys.Send("{TAB}");
                            }
                        };
                        this.panel1.Controls.Add(docTo);
                        this.controlScope.Add(docTo);
                        break;
                    #endregion Docnum
                    #region Text
                    case ControlType.TextAs:
                        this.panel1.Controls.Add(this.CreateLabel(scope.label[0], 1, y + (cnt_ctrl * line_height)));
                        var textAs = new XTextEdit();
                        textAs.Tag = scope.bindingTo + "=''";
                        textAs._TextChanged += delegate (object sender, EventArgs e)
                        {
                            textAs.Tag = scope.bindingTo + "='" + textAs._Text + "'";
                        };
                        textAs.SetBounds(col2, y + (cnt_ctrl * line_height), 118, textAs.Bounds.Height);
                        textAs.TabIndex = ++tabindex;
                        textAs.textBox1.KeyPress += delegate (object sender, KeyPressEventArgs e)
                        {
                            if (e.KeyChar == (char)13)
                            {
                                SendKeys.Send("{TAB}");
                            }
                        };
                        this.panel1.Controls.Add(textAs);
                        this.controlScope.Add(textAs);
                        break;
                    case ControlType.TextRange:
                        this.panel1.Controls.Add(this.CreateLabel(scope.label[0], 1, y + (cnt_ctrl * line_height)));
                        var textFrom = new XTextEdit();
                        textFrom.Tag = scope.bindingTo + ">=''";
                        textFrom._TextChanged += delegate (object sender, EventArgs e)
                        {
                            textFrom.Tag = scope.bindingTo + ">='" + textFrom._Text + "'";
                        };
                        textFrom.SetBounds(col2, y + (cnt_ctrl * line_height), 118, textFrom.Bounds.Height);
                        textFrom.TabIndex = ++tabindex;
                        textFrom.textBox1.KeyPress += delegate (object sender, KeyPressEventArgs e)
                        {
                            if (e.KeyChar == (char)13)
                            {
                                SendKeys.Send("{TAB}");
                            }
                        };
                        this.panel1.Controls.Add(textFrom);
                        this.controlScope.Add(textFrom);

                        this.panel1.Controls.Add(this.CreateLabel(scope.label[1], 3, y + (cnt_ctrl * line_height)));
                        var textTo = new XTextEdit();
                        textTo.Tag = scope.bindingTo + "<=''";
                        textTo._TextChanged += delegate (object sender, EventArgs e)
                        {
                            textTo.Tag = scope.bindingTo + "<='" + textTo._Text + "'";
                        };
                        textTo.SetBounds(col4, y + (cnt_ctrl * line_height), 118, textTo.Bounds.Height);
                        textTo.TabIndex = ++tabindex;
                        textTo.textBox1.KeyPress += delegate (object sender, KeyPressEventArgs e)
                        {
                            if (e.KeyChar == (char)13)
                            {
                                SendKeys.Send("{TAB}");
                            }
                        };
                        this.panel1.Controls.Add(textTo);
                        this.controlScope.Add(textTo);
                        break;
                    #endregion Text
                    #region Dep
                    case ControlType.DepAs:
                        this.panel1.Controls.Add(this.CreateLabel(scope.label[0], 1, y + (cnt_ctrl * line_height)));
                        var depAs = new XBrowseBox();
                        depAs.Tag = scope.bindingTo + "=''";
                        depAs._ButtonClick += delegate (object sender, EventArgs e)
                        {
                            DialogSelectIstab dl = new DialogSelectIstab(this.list_dep, depAs._Text);
                            dl.SetBounds(depAs.PointToScreen(Point.Empty).X, depAs.PointToScreen(Point.Empty).Y + depAs.Bounds.Height, dl.Bounds.Width, dl.Bounds.Height);
                            if (dl.ShowDialog() == DialogResult.OK)
                            {
                                depAs._Text = dl.selected_typcod;
                            }
                        };
                        depAs._Leave += delegate (object sender, EventArgs e)
                        {
                            if (depAs._Text.Trim().Length == 0 || depAs._Text.Trim().Length != 0 && this.list_dep.Where(a => a.typcod == depAs._Text).Count() != 0)
                                return;

                            depAs.Focus();
                            depAs.PerformButtonClick();
                            depAs._textBox.SelectionStart = depAs._Text.Length;
                        };
                        depAs._TextChanged += delegate (object sender, EventArgs e)
                        {
                            depAs.Tag = scope.bindingTo + "='" + depAs._Text + "'";
                        };
                        depAs.SetBounds(col2, y + (cnt_ctrl * line_height), 80/*depAs.Bounds.Width*/, depAs.Bounds.Height);
                        depAs.TabIndex = ++tabindex;
                        depAs._textBox.KeyPress += delegate (object sender, KeyPressEventArgs e)
                        {
                            if (e.KeyChar == (char)13)
                            {
                                SendKeys.Send("{TAB}");
                            }
                        };
                        this.panel1.Controls.Add(depAs);
                        this.controlScope.Add(depAs);
                        break;
                    case ControlType.DepRange:
                        this.panel1.Controls.Add(this.CreateLabel(scope.label[0], 1, y + (cnt_ctrl * line_height)));
                        var depFrom = new XBrowseBox();
                        depFrom.Tag = scope.bindingTo + ">=''";
                        depFrom._ButtonClick += delegate (object sender, EventArgs e)
                        {
                            DialogSelectIstab dl = new DialogSelectIstab(this.list_dep, depFrom._Text);
                            dl.SetBounds(depFrom.PointToScreen(Point.Empty).X, depFrom.PointToScreen(Point.Empty).Y + depFrom.Bounds.Height, dl.Bounds.Width, dl.Bounds.Height);
                            if (dl.ShowDialog() == DialogResult.OK)
                            {
                                depFrom._Text = dl.selected_typcod;
                            }
                        };
                        depFrom._Leave += delegate (object sender, EventArgs e)
                        {
                            if (depFrom._Text.Trim().Length == 0 || depFrom._Text.Trim().Length != 0 && this.list_dep.Where(a => a.typcod == depFrom._Text).Count() != 0)
                                return;

                            depFrom.Focus();
                            depFrom.PerformButtonClick();
                            depFrom._textBox.SelectionStart = depFrom._Text.Length;
                        };
                        depFrom._TextChanged += delegate (object sender, EventArgs e)
                        {
                            depFrom.Tag = scope.bindingTo + ">='" + depFrom._Text + "'";
                        };
                        depFrom.SetBounds(col2, y + (cnt_ctrl * line_height), 80/*depFrom.Bounds.Width*/, depFrom.Bounds.Height);
                        depFrom.TabIndex = ++tabindex;
                        depFrom._textBox.KeyPress += delegate (object sender, KeyPressEventArgs e)
                        {
                            if (e.KeyChar == (char)13)
                            {
                                SendKeys.Send("{TAB}");
                            }
                        };
                        this.panel1.Controls.Add(depFrom);
                        this.controlScope.Add(depFrom);

                        this.panel1.Controls.Add(this.CreateLabel(scope.label[1], 3, y + (cnt_ctrl * line_height)));
                        var depTo = new XBrowseBox();
                        depTo.Tag = scope.bindingTo + "<=''";
                        depTo._ButtonClick += delegate (object sender, EventArgs e)
                        {
                            DialogSelectIstab dl = new DialogSelectIstab(this.list_dep, depTo._Text);
                            dl.SetBounds(depTo.PointToScreen(Point.Empty).X, depTo.PointToScreen(Point.Empty).Y + depTo.Bounds.Height, dl.Bounds.Width, dl.Bounds.Height);
                            if (dl.ShowDialog() == DialogResult.OK)
                            {
                                depTo._Text = dl.selected_typcod;
                            }
                        };
                        depTo._Leave += delegate (object sender, EventArgs e)
                        {
                            if (depTo._Text.Trim().Length == 0 || depTo._Text.Trim().Length != 0 && this.list_dep.Where(a => a.typcod == depTo._Text).Count() != 0)
                                return;

                            depTo.Focus();
                            depTo.PerformButtonClick();
                            depTo._textBox.SelectionStart = depTo._Text.Length;
                        };
                        depTo._TextChanged += delegate (object sender, EventArgs e)
                        {
                            depTo.Tag = scope.bindingTo + "<='" + depTo._Text + "'";
                        };
                        depTo.SetBounds(col4, y + (cnt_ctrl * line_height), 80/*depTo.Bounds.Width*/, depTo.Bounds.Height);
                        depTo.TabIndex = ++tabindex;
                        depTo._textBox.KeyPress += delegate (object sender, KeyPressEventArgs e)
                        {
                            if (e.KeyChar == (char)13)
                            {
                                SendKeys.Send("{TAB}");
                            }
                        };
                        depTo._Text = this.list_dep.Count == 0 ? string.Empty : this.list_dep.Last().typcod.TrimEnd();
                        this.panel1.Controls.Add(depTo);
                        this.controlScope.Add(depTo);
                        break;
                    #endregion Dep
                    #region Slm
                    case ControlType.SlmAs:
                        this.panel1.Controls.Add(this.CreateLabel(scope.label[0], 1, y + (cnt_ctrl * line_height)));
                        var slmAs = new XBrowseBox();
                        slmAs.Tag = scope.bindingTo + "=''";
                        slmAs._ButtonClick += delegate (object sender, EventArgs e)
                        {
                            DialogSelectSlm dl = new DialogSelectSlm(this.list_slm, slmAs._Text);
                            dl.SetBounds(slmAs.PointToScreen(Point.Empty).X, slmAs.PointToScreen(Point.Empty).Y + slmAs.Bounds.Height, dl.Bounds.Width, dl.Bounds.Height);
                            if (dl.ShowDialog() == DialogResult.OK)
                            {
                                slmAs._Text = dl.selected_slmcod;
                            }
                        };
                        slmAs._Leave += delegate (object sender, EventArgs e)
                        {
                            if (slmAs._Text.Trim().Length == 0 || slmAs._Text.Trim().Length != 0 && this.list_slm.Where(a => a.slmcod == slmAs._Text).Count() != 0)
                                return;

                            slmAs.Focus();
                            slmAs.PerformButtonClick();
                            slmAs._textBox.SelectionStart = slmAs._Text.Length;
                        };
                        slmAs._TextChanged += delegate (object sender, EventArgs e)
                        {
                            slmAs.Tag = scope.bindingTo + "='" + slmAs._Text + "'";
                        };
                        slmAs.SetBounds(col2, y + (cnt_ctrl * line_height), 80/*slmAs.Bounds.Width*/, slmAs.Bounds.Height);
                        slmAs.TabIndex = ++tabindex;
                        slmAs._textBox.KeyPress += delegate (object sender, KeyPressEventArgs e)
                        {
                            if (e.KeyChar == (char)13)
                            {
                                SendKeys.Send("{TAB}");
                            }
                        };
                        this.panel1.Controls.Add(slmAs);
                        this.controlScope.Add(slmAs);
                        break;
                    case ControlType.SlmRange:
                        this.panel1.Controls.Add(this.CreateLabel(scope.label[0], 1, y + (cnt_ctrl * line_height)));
                        var slmFrom = new XBrowseBox();
                        slmFrom.Tag = scope.bindingTo + ">=''";
                        slmFrom._ButtonClick += delegate (object sender, EventArgs e)
                        {
                            DialogSelectSlm dl = new DialogSelectSlm(this.list_slm, slmFrom._Text);
                            dl.SetBounds(slmFrom.PointToScreen(Point.Empty).X, slmFrom.PointToScreen(Point.Empty).Y + slmFrom.Bounds.Height, dl.Bounds.Width, dl.Bounds.Height);
                            if (dl.ShowDialog() == DialogResult.OK)
                            {
                                slmFrom._Text = dl.selected_slmcod;
                            }
                        };
                        slmFrom._Leave += delegate (object sender, EventArgs e)
                        {
                            if (slmFrom._Text.Trim().Length == 0 || slmFrom._Text.Trim().Length != 0 && this.list_slm.Where(a => a.slmcod == slmFrom._Text).Count() != 0)
                                return;

                            slmFrom.Focus();
                            slmFrom.PerformButtonClick();
                            slmFrom._textBox.SelectionStart = slmFrom._Text.Length;
                        };
                        slmFrom._TextChanged += delegate (object sender, EventArgs e)
                        {
                            slmFrom.Tag = scope.bindingTo + ">='" + slmFrom._Text + "'";
                        };
                        slmFrom.SetBounds(col2, y + (cnt_ctrl * line_height), 80/*slmFrom.Bounds.Width*/, slmFrom.Bounds.Height);
                        slmFrom.TabIndex = ++tabindex;
                        slmFrom._textBox.KeyPress += delegate (object sender, KeyPressEventArgs e)
                        {
                            if (e.KeyChar == (char)13)
                            {
                                SendKeys.Send("{TAB}");
                            }
                        };
                        this.panel1.Controls.Add(slmFrom);
                        this.controlScope.Add(slmFrom);

                        this.panel1.Controls.Add(this.CreateLabel(scope.label[1], 3, y + (cnt_ctrl * line_height)));
                        var slmTo = new XBrowseBox();
                        slmTo.Tag = scope.bindingTo + "<=''";
                        slmTo._ButtonClick += delegate (object sender, EventArgs e)
                        {
                            DialogSelectSlm dl = new DialogSelectSlm(this.list_slm, slmTo._Text);
                            dl.SetBounds(slmTo.PointToScreen(Point.Empty).X, slmTo.PointToScreen(Point.Empty).Y + slmTo.Bounds.Height, dl.Bounds.Width, dl.Bounds.Height);
                            if (dl.ShowDialog() == DialogResult.OK)
                            {
                                slmTo._Text = dl.selected_slmcod;
                            }
                        };
                        slmTo._Leave += delegate (object sender, EventArgs e)
                        {
                            if (slmTo._Text.Trim().Length == 0 || slmTo._Text.Trim().Length != 0 && this.list_slm.Where(a => a.slmcod == slmTo._Text).Count() != 0)
                                return;

                            slmTo.Focus();
                            slmTo.PerformButtonClick();
                            slmTo._textBox.SelectionStart = slmTo._Text.Length;
                        };
                        slmTo._TextChanged += delegate (object sender, EventArgs e)
                        {
                            slmTo.Tag = scope.bindingTo + "<='" + slmTo._Text + "'";
                        };
                        slmTo.SetBounds(col4, y + (cnt_ctrl * line_height), 80/*slmTo.Bounds.Width*/, slmTo.Bounds.Height);
                        slmTo.TabIndex = ++tabindex;
                        slmTo._textBox.KeyPress += delegate (object sender, KeyPressEventArgs e)
                        {
                            if (e.KeyChar == (char)13)
                            {
                                SendKeys.Send("{TAB}");
                            }
                        };
                        slmTo._Text = this.list_slm.Count == 0 ? string.Empty : this.list_slm.Last().slmcod.TrimEnd();
                        this.panel1.Controls.Add(slmTo);
                        this.controlScope.Add(slmTo);
                        break;
                    #endregion Slm
                    #region Loc
                    case ControlType.LocAs:
                        this.panel1.Controls.Add(this.CreateLabel(scope.label[0], 1, y + (cnt_ctrl * line_height)));
                        var locAs = new XBrowseBox();
                        locAs.Tag = scope.bindingTo + "=''";
                        locAs._ButtonClick += delegate (object sender, EventArgs e)
                        {
                            DialogSelectIstab dl = new DialogSelectIstab(this.list_loc, locAs._Text);
                            dl.SetBounds(locAs.PointToScreen(Point.Empty).X, locAs.PointToScreen(Point.Empty).Y + locAs.Bounds.Height, dl.Bounds.Width, dl.Bounds.Height);
                            if (dl.ShowDialog() == DialogResult.OK)
                            {
                                locAs._Text = dl.selected_typcod;
                            }
                        };
                        locAs._Leave += delegate (object sender, EventArgs e)
                        {
                            if (locAs._Text.Trim().Length == 0 || locAs._Text.Trim().Length != 0 && this.list_loc.Where(a => a.typcod == locAs._Text).Count() != 0)
                                return;

                            locAs.Focus();
                            locAs.PerformButtonClick();
                            locAs._textBox.SelectionStart = locAs._Text.Length;
                        };
                        locAs._TextChanged += delegate (object sender, EventArgs e)
                        {
                            locAs.Tag = scope.bindingTo + "='" + locAs._Text + "'";
                        };
                        locAs.SetBounds(col2, y + (cnt_ctrl * line_height), 80/*locAs.Bounds.Width*/, locAs.Bounds.Height);
                        locAs.TabIndex = ++tabindex;
                        locAs._textBox.KeyPress += delegate (object sender, KeyPressEventArgs e)
                        {
                            if (e.KeyChar == (char)13)
                            {
                                SendKeys.Send("{TAB}");
                            }
                        };
                        this.panel1.Controls.Add(locAs);
                        this.controlScope.Add(locAs);
                        break;
                    case ControlType.LocRange:
                        this.panel1.Controls.Add(this.CreateLabel(scope.label[0], 1, y + (cnt_ctrl * line_height)));
                        var locFrom = new XBrowseBox();
                        locFrom.Tag = scope.bindingTo + ">=''";
                        locFrom._ButtonClick += delegate (object sender, EventArgs e)
                        {
                            DialogSelectIstab dl = new DialogSelectIstab(this.list_loc, locFrom._Text);
                            dl.SetBounds(locFrom.PointToScreen(Point.Empty).X, locFrom.PointToScreen(Point.Empty).Y + locFrom.Bounds.Height, dl.Bounds.Width, dl.Bounds.Height);
                            if (dl.ShowDialog() == DialogResult.OK)
                            {
                                locFrom._Text = dl.selected_typcod;
                            }
                        };
                        locFrom._Leave += delegate (object sender, EventArgs e)
                        {
                            if (locFrom._Text.Trim().Length == 0 || locFrom._Text.Trim().Length != 0 && this.list_loc.Where(a => a.typcod == locFrom._Text).Count() != 0)
                                return;

                            locFrom.Focus();
                            locFrom.PerformButtonClick();
                            locFrom._textBox.SelectionStart = locFrom._Text.Length;
                        };
                        locFrom._TextChanged += delegate (object sender, EventArgs e)
                        {
                            locFrom.Tag = scope.bindingTo + ">='" + locFrom._Text + "'";
                        };
                        locFrom.SetBounds(col2, y + (cnt_ctrl * line_height), 80/*locFrom.Bounds.Width*/, locFrom.Bounds.Height);
                        locFrom.TabIndex = ++tabindex;
                        locFrom._textBox.KeyPress += delegate (object sender, KeyPressEventArgs e)
                        {
                            if (e.KeyChar == (char)13)
                            {
                                SendKeys.Send("{TAB}");
                            }
                        };
                        locFrom._Text = this.list_loc.Count == 0 ? string.Empty : this.list_loc.First().typcod.TrimEnd();
                        this.panel1.Controls.Add(locFrom);
                        this.controlScope.Add(locFrom);

                        this.panel1.Controls.Add(this.CreateLabel(scope.label[1], 3, y + (cnt_ctrl * line_height)));
                        var locTo = new XBrowseBox();
                        locTo.Tag = scope.bindingTo + "<=''";
                        locTo._ButtonClick += delegate (object sender, EventArgs e)
                        {
                            DialogSelectIstab dl = new DialogSelectIstab(this.list_loc, locTo._Text);
                            dl.SetBounds(locTo.PointToScreen(Point.Empty).X, locTo.PointToScreen(Point.Empty).Y + locTo.Bounds.Height, dl.Bounds.Width, dl.Bounds.Height);
                            if (dl.ShowDialog() == DialogResult.OK)
                            {
                                locTo._Text = dl.selected_typcod;
                            }
                        };
                        locTo._Leave += delegate (object sender, EventArgs e)
                        {
                            if (locTo._Text.Trim().Length == 0 || locTo._Text.Trim().Length != 0 && this.list_loc.Where(a => a.typcod == locTo._Text).Count() != 0)
                                return;

                            locTo.Focus();
                            locTo.PerformButtonClick();
                            locTo._textBox.SelectionStart = locTo._Text.Length;
                        };
                        locTo._TextChanged += delegate (object sender, EventArgs e)
                        {
                            locTo.Tag = scope.bindingTo + "<='" + locTo._Text + "'";
                        };
                        locTo.SetBounds(col4, y + (cnt_ctrl * line_height), 80/*locTo.Bounds.Width*/, locTo.Bounds.Height);
                        locTo.TabIndex = ++tabindex;
                        locTo._textBox.KeyPress += delegate (object sender, KeyPressEventArgs e)
                        {
                            if (e.KeyChar == (char)13)
                            {
                                SendKeys.Send("{TAB}");
                            }
                        };
                        locTo._Text = this.list_loc.Count == 0 ? string.Empty : this.list_loc.Last().typcod.TrimEnd();
                        this.panel1.Controls.Add(locTo);
                        this.controlScope.Add(locTo);
                        break;
                    #endregion Loc
                    #region Stkgrp
                    case ControlType.StkgrpAs:
                        this.panel1.Controls.Add(this.CreateLabel(scope.label[0], 1, y + (cnt_ctrl * line_height)));
                        var stkgrpAs = new XBrowseBox();
                        stkgrpAs.Tag = scope.bindingTo + "=''";
                        stkgrpAs._ButtonClick += delegate (object sender, EventArgs e)
                        {
                            DialogSelectIstab dl = new DialogSelectIstab(this.list_stkgrp, stkgrpAs._Text);
                            dl.SetBounds(stkgrpAs.PointToScreen(Point.Empty).X, stkgrpAs.PointToScreen(Point.Empty).Y + stkgrpAs.Bounds.Height, dl.Bounds.Width, dl.Bounds.Height);
                            if (dl.ShowDialog() == DialogResult.OK)
                            {
                                stkgrpAs._Text = dl.selected_typcod;
                            }
                        };
                        stkgrpAs._Leave += delegate (object sender, EventArgs e)
                        {
                            if (stkgrpAs._Text.Trim().Length == 0 || stkgrpAs._Text.Trim().Length != 0 && this.list_stkgrp.Where(a => a.typcod == stkgrpAs._Text).Count() != 0)
                                return;

                            stkgrpAs.Focus();
                            stkgrpAs.PerformButtonClick();
                            stkgrpAs._textBox.SelectionStart = stkgrpAs._Text.Length;
                        };
                        stkgrpAs._TextChanged += delegate (object sender, EventArgs e)
                        {
                            stkgrpAs.Tag = scope.bindingTo + "='" + stkgrpAs._Text + "'";
                        };
                        stkgrpAs.SetBounds(col2, y + (cnt_ctrl * line_height), 80/*stkgrpAs.Bounds.Width*/, stkgrpAs.Bounds.Height);
                        stkgrpAs.TabIndex = ++tabindex;
                        stkgrpAs._textBox.KeyPress += delegate (object sender, KeyPressEventArgs e)
                        {
                            if (e.KeyChar == (char)13)
                            {
                                SendKeys.Send("{TAB}");
                            }
                        };
                        this.panel1.Controls.Add(stkgrpAs);
                        this.controlScope.Add(stkgrpAs);
                        break;
                    case ControlType.StkgrpRange:
                        this.panel1.Controls.Add(this.CreateLabel(scope.label[0], 1, y + (cnt_ctrl * line_height)));
                        var stkgrpFrom = new XBrowseBox();
                        stkgrpFrom.Tag = scope.bindingTo + ">=''";
                        stkgrpFrom._ButtonClick += delegate (object sender, EventArgs e)
                        {
                            DialogSelectIstab dl = new DialogSelectIstab(this.list_stkgrp, stkgrpFrom._Text);
                            dl.SetBounds(stkgrpFrom.PointToScreen(Point.Empty).X, stkgrpFrom.PointToScreen(Point.Empty).Y + stkgrpFrom.Bounds.Height, dl.Bounds.Width, dl.Bounds.Height);
                            if (dl.ShowDialog() == DialogResult.OK)
                            {
                                stkgrpFrom._Text = dl.selected_typcod;
                            }
                        };
                        stkgrpFrom._Leave += delegate (object sender, EventArgs e)
                        {
                            if (stkgrpFrom._Text.Trim().Length == 0 || stkgrpFrom._Text.Trim().Length != 0 && this.list_stkgrp.Where(a => a.typcod == stkgrpFrom._Text).Count() != 0)
                                return;

                            stkgrpFrom.Focus();
                            stkgrpFrom.PerformButtonClick();
                            stkgrpFrom._textBox.SelectionStart = stkgrpFrom._Text.Length;
                        };
                        stkgrpFrom._TextChanged += delegate (object sender, EventArgs e)
                        {
                            stkgrpFrom.Tag = scope.bindingTo + ">='" + stkgrpFrom._Text + "'";
                        };
                        stkgrpFrom.SetBounds(col2, y + (cnt_ctrl * line_height), 80/*stkgrpFrom.Bounds.Width*/, stkgrpFrom.Bounds.Height);
                        stkgrpFrom.TabIndex = ++tabindex;
                        stkgrpFrom._textBox.KeyPress += delegate (object sender, KeyPressEventArgs e)
                        {
                            if (e.KeyChar == (char)13)
                            {
                                SendKeys.Send("{TAB}");
                            }
                        };
                        this.panel1.Controls.Add(stkgrpFrom);
                        this.controlScope.Add(stkgrpFrom);

                        this.panel1.Controls.Add(this.CreateLabel(scope.label[1], 3, y + (cnt_ctrl * line_height)));
                        var stkgrpTo = new XBrowseBox();
                        stkgrpTo.Tag = scope.bindingTo + "<=''";
                        stkgrpTo._ButtonClick += delegate (object sender, EventArgs e)
                        {
                            DialogSelectIstab dl = new DialogSelectIstab(this.list_stkgrp, stkgrpTo._Text);
                            dl.SetBounds(stkgrpTo.PointToScreen(Point.Empty).X, stkgrpTo.PointToScreen(Point.Empty).Y + stkgrpTo.Bounds.Height, dl.Bounds.Width, dl.Bounds.Height);
                            if (dl.ShowDialog() == DialogResult.OK)
                            {
                                stkgrpTo._Text = dl.selected_typcod;
                            }
                        };
                        stkgrpTo._Leave += delegate (object sender, EventArgs e)
                        {
                            if (stkgrpTo._Text.Trim().Length == 0 || stkgrpTo._Text.Trim().Length != 0 && this.list_stkgrp.Where(a => a.typcod == stkgrpTo._Text).Count() != 0)
                                return;

                            stkgrpTo.Focus();
                            stkgrpTo.PerformButtonClick();
                            stkgrpTo._textBox.SelectionStart = stkgrpTo._Text.Length;
                        };
                        stkgrpTo._TextChanged += delegate (object sender, EventArgs e)
                        {
                            stkgrpTo.Tag = scope.bindingTo + "<='" + stkgrpTo._Text + "'";
                        };
                        stkgrpTo.SetBounds(col4, y + (cnt_ctrl * line_height), 80/*stkgrpTo.Bounds.Width*/, stkgrpTo.Bounds.Height);
                        stkgrpTo.TabIndex = ++tabindex;
                        stkgrpTo._textBox.KeyPress += delegate (object sender, KeyPressEventArgs e)
                        {
                            if (e.KeyChar == (char)13)
                            {
                                SendKeys.Send("{TAB}");
                            }
                        };
                        stkgrpTo._Text = this.list_stkgrp.Count == 0 ? string.Empty : this.list_stkgrp.Last().typcod.TrimEnd();
                        this.panel1.Controls.Add(stkgrpTo);
                        this.controlScope.Add(stkgrpTo);
                        break;
                    #endregion Stkgrp
                    #region Area
                    case ControlType.AreaAs:
                        this.panel1.Controls.Add(this.CreateLabel(scope.label[0], 1, y + (cnt_ctrl * line_height)));
                        var areaAs = new XBrowseBox();
                        areaAs.Tag = scope.bindingTo + "=''";
                        areaAs._ButtonClick += delegate (object sender, EventArgs e)
                        {
                            DialogSelectIstab dl = new DialogSelectIstab(this.list_area, areaAs._Text);
                            dl.SetBounds(areaAs.PointToScreen(Point.Empty).X, areaAs.PointToScreen(Point.Empty).Y + areaAs.Bounds.Height, dl.Bounds.Width, dl.Bounds.Height);
                            if (dl.ShowDialog() == DialogResult.OK)
                            {
                                areaAs._Text = dl.selected_typcod;
                            }
                        };
                        areaAs._Leave += delegate (object sender, EventArgs e)
                        {
                            if (areaAs._Text.Trim().Length == 0 || areaAs._Text.Trim().Length != 0 && this.list_area.Where(a => a.typcod == areaAs._Text).Count() != 0)
                                return;

                            areaAs.Focus();
                            areaAs.PerformButtonClick();
                            areaAs._textBox.SelectionStart = areaAs._Text.Length;
                        };
                        areaAs._TextChanged += delegate (object sender, EventArgs e)
                        {
                            areaAs.Tag = scope.bindingTo + "='" + areaAs._Text + "'";
                        };
                        areaAs.SetBounds(col2, y + (cnt_ctrl * line_height), 80/*areaAs.Bounds.Width*/, areaAs.Bounds.Height);
                        areaAs.TabIndex = ++tabindex;
                        areaAs._textBox.KeyPress += delegate (object sender, KeyPressEventArgs e)
                        {
                            if (e.KeyChar == (char)13)
                            {
                                SendKeys.Send("{TAB}");
                            }
                        };
                        this.panel1.Controls.Add(areaAs);
                        this.controlScope.Add(areaAs);
                        break;
                    case ControlType.AreaRange:
                        this.panel1.Controls.Add(this.CreateLabel(scope.label[0], 1, y + (cnt_ctrl * line_height)));
                        var areaFrom = new XBrowseBox();
                        areaFrom.Tag = scope.bindingTo + ">=''";
                        areaFrom._ButtonClick += delegate (object sender, EventArgs e)
                        {
                            DialogSelectIstab dl = new DialogSelectIstab(this.list_area, areaFrom._Text);
                            dl.SetBounds(areaFrom.PointToScreen(Point.Empty).X, areaFrom.PointToScreen(Point.Empty).Y + areaFrom.Bounds.Height, dl.Bounds.Width, dl.Bounds.Height);
                            if (dl.ShowDialog() == DialogResult.OK)
                            {
                                areaFrom._Text = dl.selected_typcod;
                            }
                        };
                        areaFrom._Leave += delegate (object sender, EventArgs e)
                        {
                            if (areaFrom._Text.Trim().Length == 0 || areaFrom._Text.Trim().Length != 0 && this.list_area.Where(a => a.typcod == areaFrom._Text).Count() != 0)
                                return;

                            areaFrom.Focus();
                            areaFrom.PerformButtonClick();
                            areaFrom._textBox.SelectionStart = areaFrom._Text.Length;
                        };
                        areaFrom._TextChanged += delegate (object sender, EventArgs e)
                        {
                            areaFrom.Tag = scope.bindingTo + ">='" + areaFrom._Text + "'";
                        };
                        areaFrom.SetBounds(col2, y + (cnt_ctrl * line_height), 80/*areaFrom.Bounds.Width*/, areaFrom.Bounds.Height);
                        areaFrom.TabIndex = ++tabindex;
                        areaFrom._textBox.KeyPress += delegate (object sender, KeyPressEventArgs e)
                        {
                            if (e.KeyChar == (char)13)
                            {
                                SendKeys.Send("{TAB}");
                            }
                        };
                        this.panel1.Controls.Add(areaFrom);
                        this.controlScope.Add(areaFrom);

                        this.panel1.Controls.Add(this.CreateLabel(scope.label[1], 3, y + (cnt_ctrl * line_height)));
                        var areaTo = new XBrowseBox();
                        areaTo.Tag = scope.bindingTo + "<=''";
                        areaTo._ButtonClick += delegate (object sender, EventArgs e)
                        {
                            DialogSelectIstab dl = new DialogSelectIstab(this.list_area, areaTo._Text);
                            dl.SetBounds(areaTo.PointToScreen(Point.Empty).X, areaTo.PointToScreen(Point.Empty).Y + areaTo.Bounds.Height, dl.Bounds.Width, dl.Bounds.Height);
                            if (dl.ShowDialog() == DialogResult.OK)
                            {
                                areaTo._Text = dl.selected_typcod;
                            }
                        };
                        areaTo._Leave += delegate (object sender, EventArgs e)
                        {
                            if (areaTo._Text.Trim().Length == 0 || areaTo._Text.Trim().Length != 0 && this.list_area.Where(a => a.typcod == areaTo._Text).Count() != 0)
                                return;

                            areaTo.Focus();
                            areaTo.PerformButtonClick();
                            areaTo._textBox.SelectionStart = areaTo._Text.Length;
                        };
                        areaTo._TextChanged += delegate (object sender, EventArgs e)
                        {
                            areaTo.Tag = scope.bindingTo + "<='" + areaTo._Text + "'";
                        };
                        areaTo.SetBounds(col4, y + (cnt_ctrl * line_height), 80/*areaTo.Bounds.Width*/, areaTo.Bounds.Height);
                        areaTo.TabIndex = ++tabindex;
                        areaTo._textBox.KeyPress += delegate (object sender, KeyPressEventArgs e)
                        {
                            if (e.KeyChar == (char)13)
                            {
                                SendKeys.Send("{TAB}");
                            }
                        };
                        areaTo._Text = this.list_area.Count == 0 ? string.Empty : this.list_area.Last().typcod.TrimEnd();
                        this.panel1.Controls.Add(areaTo);
                        this.controlScope.Add(areaTo);
                        break;
                    #endregion Area
                    #region Suptyp
                    case ControlType.SuptypAs:
                        this.panel1.Controls.Add(this.CreateLabel(scope.label[0], 1, y + (cnt_ctrl * line_height)));
                        var suptypAs = new XBrowseBox();
                        suptypAs.Tag = scope.bindingTo + "=''";
                        suptypAs._ButtonClick += delegate (object sender, EventArgs e)
                        {
                            DialogSelectIstab dl = new DialogSelectIstab(this.list_suptyp, suptypAs._Text);
                            dl.SetBounds(suptypAs.PointToScreen(Point.Empty).X, suptypAs.PointToScreen(Point.Empty).Y + suptypAs.Bounds.Height, dl.Bounds.Width, dl.Bounds.Height);
                            if (dl.ShowDialog() == DialogResult.OK)
                            {
                                suptypAs._Text = dl.selected_typcod;
                            }
                        };
                        suptypAs._Leave += delegate (object sender, EventArgs e)
                        {
                            if (suptypAs._Text.Trim().Length == 0 || suptypAs._Text.Trim().Length != 0 && this.list_suptyp.Where(a => a.typcod == suptypAs._Text).Count() != 0)
                                return;

                            suptypAs.Focus();
                            suptypAs.PerformButtonClick();
                            suptypAs._textBox.SelectionStart = suptypAs._Text.Length;
                        };
                        suptypAs._TextChanged += delegate (object sender, EventArgs e)
                        {
                            suptypAs.Tag = scope.bindingTo + "='" + suptypAs._Text + "'";
                        };
                        suptypAs.SetBounds(col2, y + (cnt_ctrl * line_height), 80/*suptypAs.Bounds.Width*/, suptypAs.Bounds.Height);
                        suptypAs.TabIndex = ++tabindex;
                        suptypAs._textBox.KeyPress += delegate (object sender, KeyPressEventArgs e)
                        {
                            if (e.KeyChar == (char)13)
                            {
                                SendKeys.Send("{TAB}");
                            }
                        };
                        this.panel1.Controls.Add(suptypAs);
                        this.controlScope.Add(suptypAs);
                        break;
                    case ControlType.SuptypRange:
                        this.panel1.Controls.Add(this.CreateLabel(scope.label[0], 1, y + (cnt_ctrl * line_height)));
                        var suptypFrom = new XBrowseBox();
                        suptypFrom.Tag = scope.bindingTo + ">=''";
                        suptypFrom._ButtonClick += delegate (object sender, EventArgs e)
                        {
                            DialogSelectIstab dl = new DialogSelectIstab(this.list_suptyp, suptypFrom._Text);
                            dl.SetBounds(suptypFrom.PointToScreen(Point.Empty).X, suptypFrom.PointToScreen(Point.Empty).Y + suptypFrom.Bounds.Height, dl.Bounds.Width, dl.Bounds.Height);
                            if (dl.ShowDialog() == DialogResult.OK)
                            {
                                suptypFrom._Text = dl.selected_typcod;
                            }
                        };
                        suptypFrom._Leave += delegate (object sender, EventArgs e)
                        {
                            if (suptypFrom._Text.Trim().Length == 0 || suptypFrom._Text.Trim().Length != 0 && this.list_suptyp.Where(a => a.typcod == suptypFrom._Text).Count() != 0)
                                return;

                            suptypFrom.Focus();
                            suptypFrom.PerformButtonClick();
                            suptypFrom._textBox.SelectionStart = suptypFrom._Text.Length;
                        };
                        suptypFrom._TextChanged += delegate (object sender, EventArgs e)
                        {
                            suptypFrom.Tag = scope.bindingTo + ">='" + suptypFrom._Text + "'";
                        };
                        suptypFrom.SetBounds(col2, y + (cnt_ctrl * line_height), 80/*suptypFrom.Bounds.Width*/, suptypFrom.Bounds.Height);
                        suptypFrom.TabIndex = ++tabindex;
                        suptypFrom._textBox.KeyPress += delegate (object sender, KeyPressEventArgs e)
                        {
                            if (e.KeyChar == (char)13)
                            {
                                SendKeys.Send("{TAB}");
                            }
                        };
                        this.panel1.Controls.Add(suptypFrom);
                        this.controlScope.Add(suptypFrom);

                        this.panel1.Controls.Add(this.CreateLabel(scope.label[1], 3, y + (cnt_ctrl * line_height)));
                        var suptypTo = new XBrowseBox();
                        suptypTo.Tag = scope.bindingTo + "<=''";
                        suptypTo._ButtonClick += delegate (object sender, EventArgs e)
                        {
                            DialogSelectIstab dl = new DialogSelectIstab(this.list_suptyp, suptypTo._Text);
                            dl.SetBounds(suptypTo.PointToScreen(Point.Empty).X, suptypTo.PointToScreen(Point.Empty).Y + suptypTo.Bounds.Height, dl.Bounds.Width, dl.Bounds.Height);
                            if (dl.ShowDialog() == DialogResult.OK)
                            {
                                suptypTo._Text = dl.selected_typcod;
                            }
                        };
                        suptypTo._Leave += delegate (object sender, EventArgs e)
                        {
                            if (suptypTo._Text.Trim().Length == 0 || suptypTo._Text.Trim().Length != 0 && this.list_suptyp.Where(a => a.typcod == suptypTo._Text).Count() != 0)
                                return;

                            suptypTo.Focus();
                            suptypTo.PerformButtonClick();
                            suptypTo._textBox.SelectionStart = suptypTo._Text.Length;
                        };
                        suptypTo._TextChanged += delegate (object sender, EventArgs e)
                        {
                            suptypTo.Tag = scope.bindingTo + "<='" + suptypTo._Text + "'";
                        };
                        suptypTo.SetBounds(col4, y + (cnt_ctrl * line_height), 80/*suptypTo.Bounds.Width*/, suptypTo.Bounds.Height);
                        suptypTo.TabIndex = ++tabindex;
                        suptypTo._textBox.KeyPress += delegate (object sender, KeyPressEventArgs e)
                        {
                            if (e.KeyChar == (char)13)
                            {
                                SendKeys.Send("{TAB}");
                            }
                        };
                        suptypTo._Text = this.list_suptyp.Count == 0 ? string.Empty : this.list_suptyp.Last().typcod.TrimEnd();
                        this.panel1.Controls.Add(suptypTo);
                        this.controlScope.Add(suptypTo);
                        break;
                    #endregion Suptyp
                    #region Custyp
                    case ControlType.CustypAs:
                        this.panel1.Controls.Add(this.CreateLabel(scope.label[0], 1, y + (cnt_ctrl * line_height)));
                        var custypAs = new XBrowseBox();
                        custypAs.Tag = scope.bindingTo + "=''";
                        custypAs._ButtonClick += delegate (object sender, EventArgs e)
                        {
                            DialogSelectIstab dl = new DialogSelectIstab(this.list_custyp, custypAs._Text);
                            dl.SetBounds(custypAs.PointToScreen(Point.Empty).X, custypAs.PointToScreen(Point.Empty).Y + custypAs.Bounds.Height, dl.Bounds.Width, dl.Bounds.Height);
                            if (dl.ShowDialog() == DialogResult.OK)
                            {
                                custypAs._Text = dl.selected_typcod;
                            }
                        };
                        custypAs._Leave += delegate (object sender, EventArgs e)
                        {
                            if (custypAs._Text.Trim().Length == 0 || custypAs._Text.Trim().Length != 0 && this.list_custyp.Where(a => a.typcod == custypAs._Text).Count() != 0)
                                return;

                            custypAs.Focus();
                            custypAs.PerformButtonClick();
                            custypAs._textBox.SelectionStart = custypAs._Text.Length;
                        };
                        custypAs._TextChanged += delegate (object sender, EventArgs e)
                        {
                            custypAs.Tag = scope.bindingTo + "='" + custypAs._Text + "'";
                        };
                        custypAs.SetBounds(col2, y + (cnt_ctrl * line_height), 80/*custypAs.Bounds.Width*/, custypAs.Bounds.Height);
                        custypAs.TabIndex = ++tabindex;
                        custypAs._textBox.KeyPress += delegate (object sender, KeyPressEventArgs e)
                        {
                            if (e.KeyChar == (char)13)
                            {
                                SendKeys.Send("{TAB}");
                            }
                        };
                        this.panel1.Controls.Add(custypAs);
                        this.controlScope.Add(custypAs);
                        break;
                    case ControlType.CustypRange:
                        this.panel1.Controls.Add(this.CreateLabel(scope.label[0], 1, y + (cnt_ctrl * line_height)));
                        var custypFrom = new XBrowseBox();
                        custypFrom.Tag = scope.bindingTo + ">=''";
                        custypFrom._ButtonClick += delegate (object sender, EventArgs e)
                        {
                            DialogSelectIstab dl = new DialogSelectIstab(this.list_custyp, custypFrom._Text);
                            dl.SetBounds(custypFrom.PointToScreen(Point.Empty).X, custypFrom.PointToScreen(Point.Empty).Y + custypFrom.Bounds.Height, dl.Bounds.Width, dl.Bounds.Height);
                            if (dl.ShowDialog() == DialogResult.OK)
                            {
                                custypFrom._Text = dl.selected_typcod;
                            }
                        };
                        custypFrom._Leave += delegate (object sender, EventArgs e)
                        {
                            if (custypFrom._Text.Trim().Length == 0 || custypFrom._Text.Trim().Length != 0 && this.list_custyp.Where(a => a.typcod == custypFrom._Text).Count() != 0)
                                return;

                            custypFrom.Focus();
                            custypFrom.PerformButtonClick();
                            custypFrom._textBox.SelectionStart = custypFrom._Text.Length;
                        };
                        custypFrom._TextChanged += delegate (object sender, EventArgs e)
                        {
                            custypFrom.Tag = scope.bindingTo + ">='" + custypFrom._Text + "'";
                        };
                        custypFrom.SetBounds(col2, y + (cnt_ctrl * line_height), 80/*custypFrom.Bounds.Width*/, custypFrom.Bounds.Height);
                        custypFrom.TabIndex = ++tabindex;
                        custypFrom._textBox.KeyPress += delegate (object sender, KeyPressEventArgs e)
                        {
                            if (e.KeyChar == (char)13)
                            {
                                SendKeys.Send("{TAB}");
                            }
                        };
                        this.panel1.Controls.Add(custypFrom);
                        this.controlScope.Add(custypFrom);

                        this.panel1.Controls.Add(this.CreateLabel(scope.label[1], 3, y + (cnt_ctrl * line_height)));
                        var custypTo = new XBrowseBox();
                        custypTo.Tag = scope.bindingTo + "<=''";
                        custypTo._ButtonClick += delegate (object sender, EventArgs e)
                        {
                            DialogSelectIstab dl = new DialogSelectIstab(this.list_custyp, custypTo._Text);
                            dl.SetBounds(custypTo.PointToScreen(Point.Empty).X, custypTo.PointToScreen(Point.Empty).Y + custypTo.Bounds.Height, dl.Bounds.Width, dl.Bounds.Height);
                            if (dl.ShowDialog() == DialogResult.OK)
                            {
                                custypTo._Text = dl.selected_typcod;
                            }
                        };
                        custypTo._Leave += delegate (object sender, EventArgs e)
                        {
                            if (custypTo._Text.Trim().Length == 0 || custypTo._Text.Trim().Length != 0 && this.list_custyp.Where(a => a.typcod == custypTo._Text).Count() != 0)
                                return;

                            custypTo.Focus();
                            custypTo.PerformButtonClick();
                            custypTo._textBox.SelectionStart = custypTo._Text.Length;
                        };
                        custypTo._TextChanged += delegate (object sender, EventArgs e)
                        {
                            custypTo.Tag = scope.bindingTo + "<='" + custypTo._Text + "'";
                        };
                        custypTo.SetBounds(col4, y + (cnt_ctrl * line_height), 80/*custypTo.Bounds.Width*/, custypTo.Bounds.Height);
                        custypTo.TabIndex = ++tabindex;
                        custypTo._textBox.KeyPress += delegate (object sender, KeyPressEventArgs e)
                        {
                            if (e.KeyChar == (char)13)
                            {
                                SendKeys.Send("{TAB}");
                            }
                        };
                        custypTo._Text = this.list_custyp.Count == 0 ? string.Empty : this.list_custyp.Last().typcod.TrimEnd();
                        this.panel1.Controls.Add(custypTo);
                        this.controlScope.Add(custypTo);
                        break;
                    #endregion Custyp
                    default:
                        break;
                }
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            DialogDataPath d = new DialogDataPath(this.data_path);
            if(d.ShowDialog() == DialogResult.OK)
            {
                //this.data_path = d.data_path;
                this.txtPath.Text = d.data_path;
                this.PrepareNecessaryData();
                this.ClearControlScope();
                this.ShowControlScope(this.query_model);
            }
        }

        private void txtPath_TextChanged(object sender, EventArgs e)
        {
            this.data_path = ((TextBox)sender).Text;
            this.form_report_editor.default_data_path = ((TextBox)sender).Text;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if(keyData == Keys.Escape)
            {
                this.btnCancel.PerformClick();
                return true;
            }

            if(keyData == Keys.F5)
            {
                this.btnOK.PerformClick();
                return true;
            }
            
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                this.query_model.AddWhereClause(this.controlScope.Select(c => (string)c.Tag).ToList());

                //Console.WriteLine("==>" + this.query_model.sql);

                this.data_table = this.query_model.Query(this.data_path);
                //FormQueryResult fq = new FormQueryResult(table);
                //fq.Show();

                if (this.data_table.Rows.Count == 0)
                {
                    MessageBox.Show("ไม่มีข้อมูลตามขอบเขตที่กำหนด", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
