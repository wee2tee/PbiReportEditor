using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PbiReportEditor.Misc;
using PbiReportEditor.Utils;
using ScintillaNET;

namespace PbiReportEditor
{
    public partial class FormReportEditor : Form
    {
		private const string salt = "esg.co.th";
		private string curr_file_path = null;
		private Scintilla TextArea;

        public FormReportEditor()
        {
            InitializeComponent();
        }

        private void FormReportEditor_Load(object sender, EventArgs e)
        {
			this.TextArea = new Scintilla();
			this.TextArea.Dock = DockStyle.Fill;
			this.TextPanel.Controls.Add(this.TextArea);
            this.TextArea.TabWidth = 4;

            // INITIAL VIEW CONFIG
            this.TextArea.WrapMode = WrapMode.None;
            this.TextArea.IndentationGuides = IndentView.LookBoth;
			

            // STYLING
            InitColors();
            InitSyntaxColoring();

            // NUMBER MARGIN
            InitNumberMargin();

            // BOOKMARK MARGIN
            InitBookmarkMargin();

            // CODE FOLDING MARGIN
            InitCodeFolding();

            // DRAG DROP
            InitDragDropFile();

            // DEFAULT FILE
            //LoadDataFromFile("../../MainForm.cs");

            // INIT HOTKEYS
            InitHotkeys();
        }

		private void InitColors()
        {

            TextArea.SetSelectionBackColor(true, IntToColor(0x114D9C));

        }

        private void InitHotkeys()
        {

            // register the hotkeys with the form
            HotKeyManager.AddHotKey(this, OpenSearch, Keys.F, true);
            HotKeyManager.AddHotKey(this, OpenFindDialog, Keys.F, true, false, true);
            HotKeyManager.AddHotKey(this, OpenReplaceDialog, Keys.R, true);
            HotKeyManager.AddHotKey(this, OpenReplaceDialog, Keys.H, true);
            HotKeyManager.AddHotKey(this, Uppercase, Keys.U, true);
            HotKeyManager.AddHotKey(this, Lowercase, Keys.L, true);
            HotKeyManager.AddHotKey(this, ZoomIn, Keys.Oemplus, true);
            HotKeyManager.AddHotKey(this, ZoomOut, Keys.OemMinus, true);
            HotKeyManager.AddHotKey(this, ZoomDefault, Keys.D0, true);
            HotKeyManager.AddHotKey(this, CloseSearch, Keys.Escape);
			HotKeyManager.AddHotKey(this, NewFile, Keys.N, true);
			HotKeyManager.AddHotKey(this, OpenFile, Keys.O, true);
			HotKeyManager.AddHotKey(this, SaveFile, Keys.S, true);
			HotKeyManager.AddHotKey(this, CloseFile, Keys.X, true);

			// remove conflicting hotkeys from scintilla
			TextArea.ClearCmdKey(Keys.Control | Keys.N);
			TextArea.ClearCmdKey(Keys.Control | Keys.O);
			TextArea.ClearCmdKey(Keys.Control | Keys.S);
			TextArea.ClearCmdKey(Keys.Control | Keys.X);
			TextArea.ClearCmdKey(Keys.Control | Keys.F);

			TextArea.ClearCmdKey(Keys.Control | Keys.R);
			TextArea.ClearCmdKey(Keys.Control | Keys.H);
			TextArea.ClearCmdKey(Keys.Control | Keys.L);
			TextArea.ClearCmdKey(Keys.Control | Keys.U);
			//TextArea.ClearCmdKey(Keys.Control | Keys.S);

		}

        private void InitSyntaxColoring()
        {
            // Configure the default style
            TextArea.StyleResetDefault();
            TextArea.Styles[Style.Default].Font = "Courier New";
            TextArea.Styles[Style.Default].Size = 10;
			TextArea.Styles[Style.Default].Bold = false;
            //TextArea.Styles[Style.Default].BackColor = IntToColor(0x212121);
            //TextArea.Styles[Style.Default].ForeColor = IntToColor(0xFFFFFF);
            TextArea.Styles[Style.Default].BackColor = Color.White;
            TextArea.Styles[Style.Default].ForeColor = Color.DimGray;
			TextArea.StyleClearAll();

			// Configure the CPP (C#) lexer styles
			TextArea.Styles[Style.Cpp.Identifier].ForeColor = IntToColor(0xD0DAE2);
			TextArea.Styles[Style.Cpp.Comment].ForeColor = IntToColor(0xBD758B);
			TextArea.Styles[Style.Cpp.CommentLine].ForeColor = IntToColor(0x40BF57);
			TextArea.Styles[Style.Cpp.CommentDoc].ForeColor = IntToColor(0x2FAE35);
			TextArea.Styles[Style.Cpp.Number].ForeColor = Color.LightGreen; //IntToColor(0xFFFF00);
			TextArea.Styles[Style.Cpp.String].ForeColor = Color.BurlyWood; //IntToColor(0xFFFF00);
			TextArea.Styles[Style.Cpp.Character].ForeColor = IntToColor(0xE95454);
			TextArea.Styles[Style.Cpp.Preprocessor].ForeColor = IntToColor(0x8AAFEE);
			TextArea.Styles[Style.Cpp.Operator].ForeColor = IntToColor(0xE0E0E0);
			TextArea.Styles[Style.Cpp.Regex].ForeColor = IntToColor(0xff00ff);
			TextArea.Styles[Style.Cpp.CommentLineDoc].ForeColor = IntToColor(0x77A7DB);
			TextArea.Styles[Style.Cpp.Word].ForeColor = IntToColor(0x48A8EE);
			TextArea.Styles[Style.Cpp.Word2].ForeColor = IntToColor(0xF98906);
			TextArea.Styles[Style.Cpp.CommentDocKeyword].ForeColor = IntToColor(0xB3D991);
			TextArea.Styles[Style.Cpp.CommentDocKeywordError].ForeColor = IntToColor(0xFF0000);
			TextArea.Styles[Style.Cpp.GlobalClass].ForeColor = IntToColor(0x48A8EE);



			// Configure the JSON lexer styles
			TextArea.Styles[Style.Json.PropertyName].ForeColor = IntToColor(0x538799); //IntToColor(0x6E96E9);
			//TextArea.Styles[Style.Json.Comment].ForeColor = IntToColor(0xBD758B);
			//TextArea.Styles[Style.Json.CommentLine].ForeColor = IntToColor(0x40BF57);
			//TextArea.Styles[Style.Json.CommentDoc].ForeColor = IntToColor(0x2FAE35);
			TextArea.Styles[Style.Json.Number].ForeColor = Color.OrangeRed; //IntToColor(0xFFFF00);
			TextArea.Styles[Style.Json.String].ForeColor = Color.Chocolate; //IntToColor(0xFFFF00);
			//TextArea.Styles[Style.Json.Character].ForeColor = IntToColor(0xE95454);
			//TextArea.Styles[Style.Json.Preprocessor].ForeColor = IntToColor(0x8AAFEE);
			TextArea.Styles[Style.Json.Operator].ForeColor = IntToColor(0xE0E0E0);
			//TextArea.Styles[Style.Json.Regex].ForeColor = IntToColor(0xff00ff);
			//TextArea.Styles[Style.Json.CommentLineDoc].ForeColor = IntToColor(0x77A7DB);
			//TextArea.Styles[Style.Json.Word].ForeColor = IntToColor(0x48A8EE);
			//TextArea.Styles[Style.Json.Word2].ForeColor = IntToColor(0xF98906);
			//TextArea.Styles[Style.Json.CommentDocKeyword].ForeColor = IntToColor(0xB3D991);
			//TextArea.Styles[Style.Json.CommentDocKeywordError].ForeColor = IntToColor(0xFF0000);
			//TextArea.Styles[Style.Json.GlobalClass].ForeColor = IntToColor(0x48A8EE);
			TextArea.Styles[Style.Json.Operator].ForeColor = Color.Black;
			TextArea.Styles[Style.Json.Keyword].ForeColor = Color.DarkKhaki;
			TextArea.Styles[Style.Json.Keyword].Italic = true;
			TextArea.Styles[Style.Json.Keyword].Bold = true;

			TextArea.Lexer = Lexer.Json;


            TextArea.SetKeywords(0, "class extends implements import interface new case do while else if for in switch throw get set function var try catch finally while with default break continue delete return each const namespace package include use is as instanceof typeof author copy default deprecated eventType example exampleText exception haxe inheritDoc internal link mtasc mxmlc param private return see serial serialData serialField since throws usage version langversion playerversion productversion dynamic private public partial static intrinsic internal native override protected AS3 final super this arguments null Infinity NaN undefined true false abstract as base bool break by byte case catch char checked class const continue decimal default delegate do double descending explicit event extern else enum false finally fixed float for foreach from goto group if implicit in int interface internal into is lock long new null namespace object operator out override orderby params private protected public readonly ref return switch struct sbyte sealed short sizeof stackalloc static string select this throw true try typeof uint ulong unchecked unsafe ushort using var virtual volatile void while where yield");
            TextArea.SetKeywords(1, "void Null ArgumentError arguments Array Boolean Class Date DefinitionError Error EvalError Function int Math Namespace Number Object RangeError ReferenceError RegExp SecurityError String SyntaxError TypeError uint XML XMLList Boolean Byte Char DateTime Decimal Double Int16 Int32 Int64 IntPtr SByte Single UInt16 UInt32 UInt64 UIntPtr Void Path File System Windows Forms ScintillaNET");

        }

		#region Numbers, Bookmarks, Code Folding

		/// <summary>
		/// the background color of the text area
		/// </summary>
		private const int BACK_COLOR = 0x2A211C;

		/// <summary>
		/// default text color of the text area
		/// </summary>
		private const int FORE_COLOR = 0xB7B7B7;

		/// <summary>
		/// change this to whatever margin you want the line numbers to show in
		/// </summary>
		private const int NUMBER_MARGIN = 1;

		/// <summary>
		/// change this to whatever margin you want the bookmarks/breakpoints to show in
		/// </summary>
		private const int BOOKMARK_MARGIN = 2;
		private const int BOOKMARK_MARKER = 2;

		/// <summary>
		/// change this to whatever margin you want the code folding tree (+/-) to show in
		/// </summary>
		private const int FOLDING_MARGIN = 3;

		/// <summary>
		/// set this true to show circular buttons for code folding (the [+] and [-] buttons on the margin)
		/// </summary>
		private const bool CODEFOLDING_CIRCULAR = false;

		private void InitNumberMargin()
		{

			TextArea.Styles[Style.LineNumber].BackColor = Color.LightGray; //IntToColor(BACK_COLOR);
			TextArea.Styles[Style.LineNumber].ForeColor = Color.DimGray; //IntToColor(FORE_COLOR);
			TextArea.Styles[Style.LineNumber].Size = 8;
			TextArea.Styles[Style.IndentGuide].ForeColor = IntToColor(0xC9C9C9);
			TextArea.Styles[Style.IndentGuide].BackColor = IntToColor(0xFEFEFE);

			var nums = TextArea.Margins[NUMBER_MARGIN];
			nums.Width = 30;
			nums.Type = MarginType.Number;
			nums.Sensitive = true;
			nums.Mask = 0;

			TextArea.MarginClick += TextArea_MarginClick;
		}

		private void InitBookmarkMargin()
		{

			//TextArea.SetFoldMarginColor(true, IntToColor(BACK_COLOR));

			var margin = TextArea.Margins[BOOKMARK_MARGIN];
			margin.Width = 20;
			margin.Sensitive = true;
			margin.Type = MarginType.Symbol;
			margin.Mask = (1 << BOOKMARK_MARKER);
			//margin.Cursor = MarginCursor.Arrow;

			var marker = TextArea.Markers[BOOKMARK_MARKER];
			marker.Symbol = MarkerSymbol.Circle;
			marker.SetBackColor(IntToColor(0xFF003B));
			marker.SetForeColor(IntToColor(0x000000));
			marker.SetAlpha(100);

		}

		private void InitCodeFolding()
		{

			//TextArea.SetFoldMarginColor(true, IntToColor(BACK_COLOR));
			//TextArea.SetFoldMarginHighlightColor(true, IntToColor(BACK_COLOR));
			TextArea.SetFoldMarginColor(true, Color.WhiteSmoke);
			TextArea.SetFoldMarginHighlightColor(true, Color.LightGray);

			// Enable code folding
			TextArea.SetProperty("fold", "1");
			TextArea.SetProperty("fold.compact", "1");

			// Configure a margin to display folding symbols
			TextArea.Margins[FOLDING_MARGIN].Type = MarginType.Symbol;
			TextArea.Margins[FOLDING_MARGIN].Mask = Marker.MaskFolders;
			TextArea.Margins[FOLDING_MARGIN].Sensitive = true;
			TextArea.Margins[FOLDING_MARGIN].Width = 12;

			// Set colors for all folding markers
			for (int i = 25; i <= 31; i++)
			{
				//TextArea.Markers[i].SetForeColor(IntToColor(BACK_COLOR)); // styles for [+] and [-]
				//TextArea.Markers[i].SetBackColor(IntToColor(FORE_COLOR)); // styles for [+] and [-]
				TextArea.Markers[i].SetForeColor(IntToColor(FORE_COLOR)); // styles for [+] and [-]
				TextArea.Markers[i].SetBackColor(IntToColor(BACK_COLOR)); // styles for [+] and [-]
			}

			// Configure folding markers with respective symbols
			TextArea.Markers[Marker.Folder].Symbol = CODEFOLDING_CIRCULAR ? MarkerSymbol.CirclePlus : MarkerSymbol.BoxPlus;
			TextArea.Markers[Marker.FolderOpen].Symbol = CODEFOLDING_CIRCULAR ? MarkerSymbol.CircleMinus : MarkerSymbol.BoxMinus;
			TextArea.Markers[Marker.FolderEnd].Symbol = CODEFOLDING_CIRCULAR ? MarkerSymbol.CirclePlusConnected : MarkerSymbol.BoxPlusConnected;
			TextArea.Markers[Marker.FolderMidTail].Symbol = MarkerSymbol.TCorner;
			TextArea.Markers[Marker.FolderOpenMid].Symbol = CODEFOLDING_CIRCULAR ? MarkerSymbol.CircleMinusConnected : MarkerSymbol.BoxMinusConnected;
			TextArea.Markers[Marker.FolderSub].Symbol = MarkerSymbol.VLine;
			TextArea.Markers[Marker.FolderTail].Symbol = MarkerSymbol.LCorner;

			// Enable automatic folding
			TextArea.AutomaticFold = (AutomaticFold.Show | AutomaticFold.Click | AutomaticFold.Change);

		}

		private void TextArea_MarginClick(object sender, MarginClickEventArgs e)
		{
			//if (e.Margin == BOOKMARK_MARGIN)
			//{
			//	// Do we have a marker for this line?
			//	const uint mask = (1 << BOOKMARK_MARKER);
			//	var line = TextArea.Lines[TextArea.LineFromPosition(e.Position)];
			//	if ((line.MarkerGet() & mask) > 0)
			//	{
			//		// Remove existing bookmark
			//		line.MarkerDelete(BOOKMARK_MARKER);
			//	}
			//	else
			//	{
			//		// Add bookmark
			//		line.MarkerAdd(BOOKMARK_MARKER);
			//	}
			//}

			if(e.Margin == BOOKMARK_MARGIN)
			{
				var line = this.TextArea.Lines[this.TextArea.LineFromPosition(e.Position)];
				Console.WriteLine(" => Click at line : " + line.Index);

			}
		}

		#endregion

		#region Drag & Drop File

		public void InitDragDropFile()
		{
			TextArea.AllowDrop = true;
			TextArea.DragEnter += delegate (object sender, DragEventArgs e) {
				//e.Effect = DragDropEffects.Move;
				if (e.Data.GetDataPresent(DataFormats.FileDrop))
					e.Effect = DragDropEffects.Copy;
				else
					e.Effect = DragDropEffects.None;
			};
			TextArea.DragDrop += delegate (object sender, DragEventArgs e) {

				// get file drop
				if (e.Data.GetDataPresent(DataFormats.FileDrop))
				{

					Array a = (Array)e.Data.GetData(DataFormats.FileDrop);
					if (a != null)
					{

						string path = a.GetValue(0).ToString();

						LoadDataFromFile(path);

					}
				}
			};

		}

		private void LoadDataFromFile(string path)
		{
			if (File.Exists(path))
			{
				try
				{
					this.TextArea.Text = File.ReadAllText(path).AES_Decrypt(salt);
					this.TextArea.EmptyUndoBuffer();
					this.curr_file_path = path;
					lblFileName.Text = this.curr_file_path; //Path.GetFileName(path);
					//this.btnSave.Enabled = true;
					this.btnCloseFile.Enabled = true;
					this.btnUndo.Enabled = true;
					this.btnRedo.Enabled = true;
					this.btnExpandAll.Enabled = true;
					this.btnCollapseAll.Enabled = true;
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		#endregion

		#region Main Menu Commands

		//private void openToolStripMenuItem_Click(object sender, EventArgs e)
		//{
		//	if (openFileDialog.ShowDialog() == DialogResult.OK)
		//	{
		//		LoadDataFromFile(openFileDialog.FileName);
		//	}
		//}

		private void findToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenSearch();
		}

		private void findDialogToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenFindDialog();
		}

		private void findAndReplaceToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenReplaceDialog();
		}

		private void cutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			TextArea.Cut();
		}

		private void copyToolStripMenuItem_Click(object sender, EventArgs e)
		{
			TextArea.Copy();
		}

		private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			TextArea.Paste();
		}

		private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
		{
			TextArea.SelectAll();
		}

		private void selectLineToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Line line = TextArea.Lines[TextArea.CurrentLine];
			TextArea.SetSelection(line.Position + line.Length, line.Position);
		}

		private void clearSelectionToolStripMenuItem_Click(object sender, EventArgs e)
		{
			TextArea.SetEmptySelection(0);
		}

		private void indentSelectionToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Indent();
		}

		private void outdentSelectionToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Outdent();
		}

		private void uppercaseSelectionToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Uppercase();
		}

		private void lowercaseSelectionToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Lowercase();
		}

		//private void wordWrapToolStripMenuItem1_Click(object sender, EventArgs e)
		//{

		//	// toggle word wrap
		//	wordWrapItem.Checked = !wordWrapItem.Checked;
		//	TextArea.WrapMode = wordWrapItem.Checked ? WrapMode.Word : WrapMode.None;
		//}

		//private void indentGuidesToolStripMenuItem_Click(object sender, EventArgs e)
		//{

		//	// toggle indent guides
		//	indentGuidesItem.Checked = !indentGuidesItem.Checked;
		//	TextArea.IndentationGuides = indentGuidesItem.Checked ? IndentView.LookBoth : IndentView.None;
		//}

		//private void hiddenCharactersToolStripMenuItem_Click(object sender, EventArgs e)
		//{

		//	// toggle view whitespace
		//	hiddenCharactersItem.Checked = !hiddenCharactersItem.Checked;
		//	TextArea.ViewWhitespace = hiddenCharactersItem.Checked ? WhitespaceMode.VisibleAlways : WhitespaceMode.Invisible;
		//}

		//private void zoomInToolStripMenuItem_Click(object sender, EventArgs e)
		//{
		//	ZoomIn();
		//}

		//private void zoomOutToolStripMenuItem_Click(object sender, EventArgs e)
		//{
		//	ZoomOut();
		//}

		//private void zoom100ToolStripMenuItem_Click(object sender, EventArgs e)
		//{
		//	ZoomDefault();
		//}

		//private void collapseAllToolStripMenuItem_Click(object sender, EventArgs e)
		//{
		//	TextArea.FoldAll(FoldAction.Contract);
		//}

		//private void expandAllToolStripMenuItem_Click(object sender, EventArgs e)
		//{
		//	TextArea.FoldAll(FoldAction.Expand);
		//}


		#endregion

		#region Uppercase / Lowercase

		private void Lowercase()
		{

			// save the selection
			int start = TextArea.SelectionStart;
			int end = TextArea.SelectionEnd;

			// modify the selected text
			TextArea.ReplaceSelection(TextArea.GetTextRange(start, end - start).ToLower());

			// preserve the original selection
			TextArea.SetSelection(start, end);
		}

		private void Uppercase()
		{

			// save the selection
			int start = TextArea.SelectionStart;
			int end = TextArea.SelectionEnd;

			// modify the selected text
			TextArea.ReplaceSelection(TextArea.GetTextRange(start, end - start).ToUpper());

			// preserve the original selection
			TextArea.SetSelection(start, end);
		}

		#endregion

		#region Indent / Outdent

		private void Indent()
		{
			// we use this hack to send "Shift+Tab" to scintilla, since there is no known API to indent,
			// although the indentation function exists. Pressing TAB with the editor focused confirms this.
			GenerateKeystrokes("{TAB}");
		}

		private void Outdent()
		{
			// we use this hack to send "Shift+Tab" to scintilla, since there is no known API to outdent,
			// although the indentation function exists. Pressing Shift+Tab with the editor focused confirms this.
			GenerateKeystrokes("+{TAB}");
		}

		private void GenerateKeystrokes(string keys)
		{
			HotKeyManager.Enable = false;
			TextArea.Focus();
			SendKeys.Send(keys);
			HotKeyManager.Enable = true;
		}

		#endregion

		#region Zoom

		private void ZoomIn()
		{
			TextArea.ZoomIn();
		}

		private void ZoomOut()
		{
			TextArea.ZoomOut();
		}

		private void ZoomDefault()
		{
			TextArea.Zoom = 0;
		}


		#endregion

		#region Quick Search Bar

		bool SearchIsOpen = false;

		private void OpenSearch()
		{

			SearchManager.SearchBox = TxtSearch;
			SearchManager.TextArea = TextArea;

			if (!SearchIsOpen)
			{
				SearchIsOpen = true;
				InvokeIfNeeded(delegate () {
					PanelSearch.Visible = true;
					TxtSearch.Text = SearchManager.LastSearch;
					TxtSearch.Focus();
					TxtSearch.SelectAll();
				});
			}
			else
			{
				InvokeIfNeeded(delegate () {
					TxtSearch.Focus();
					TxtSearch.SelectAll();
				});
			}
		}
		private void CloseSearch()
		{
			if (SearchIsOpen)
			{
				SearchIsOpen = false;
				InvokeIfNeeded(delegate () {
					PanelSearch.Visible = false;
					//CurBrowser.GetBrowser().StopFinding(true);
				});
			}
		}

		private void BtnClearSearch_Click(object sender, EventArgs e)
		{
			CloseSearch();
		}

		private void BtnPrevSearch_Click(object sender, EventArgs e)
		{
			SearchManager.Find(false, false);
		}
		private void BtnNextSearch_Click(object sender, EventArgs e)
		{
			SearchManager.Find(true, false);
		}
		private void TxtSearch_TextChanged(object sender, EventArgs e)
		{
			SearchManager.Find(true, true);
		}

		private void TxtSearch_KeyDown(object sender, KeyEventArgs e)
		{

		}

		#endregion

		#region Find & Replace Dialog

		private void OpenFindDialog()
		{

		}
		private void OpenReplaceDialog()
		{


		}
		#endregion

		#region Toolbar button
		private void NewFile()
		{
			this.btnNewFile.PerformClick();
		}

		private void OpenFile()
		{
			this.btnOpenFile.PerformClick();
		}

		private void SaveFile()
		{
			this.btnSave.PerformClick();
		}

        private void CloseFile()
		{
			this.btnCloseFile.PerformClick();
		}

		private void ExpandAll()
		{
			this.TextArea.FoldAll(FoldAction.Expand);
		}

		private void CollapseAll()
		{
			this.TextArea.Lines.ToList().ForEach(l => l.FoldChildren(FoldAction.Contract));
		}
		#endregion


		#region Utils

		public static Color IntToColor(int rgb)
		{
			return Color.FromArgb(255, (byte)(rgb >> 16), (byte)(rgb >> 8), (byte)rgb);
		}

		public void InvokeIfNeeded(Action action)
		{
			if (this.InvokeRequired)
			{
				this.BeginInvoke(action);
			}
			else
			{
				action.Invoke();
			}
		}

		#endregion






		private void btnOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Report File (*.rpbi)|*.rpbi";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
				if((this.curr_file_path == null && this.TextArea.Text.Trim().Length > 0) ||
					(this.curr_file_path != null && !File.Exists(this.curr_file_path)) ||
					(this.curr_file_path != null && File.Exists(this.curr_file_path) && this.TextArea.Text.CompareTo(File.ReadAllText(this.curr_file_path).AES_Decrypt(salt)) != 0))
				{
					DialogResult result = MessageBox.Show("บันทึกแฟ้มข้อมูลปัจจุบันนี้ก่อนหรือไม่?", "Save File", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
					switch (result)
					{
						case DialogResult.Yes:
							this.btnSave.PerformClick();
							break;
						case DialogResult.No:
							break;
						default:
							return; ;
					}
				}
				this.LoadDataFromFile(ofd.FileName);


                //string source_content = File.ReadAllText(ofd.FileName);
                //string decrypted_content = source_content.AES_Decrypt(salt);
                //this.TextArea.Text = decrypted_content;
            }
        }

		private void btnSave_Click(object sender, EventArgs e)
		{
			try
			{
				if (this.curr_file_path != null)
				{
					File.WriteAllText(this.curr_file_path, this.TextArea.Text.AES_Encrypt(salt));
				}
				else
				{
					SaveFileDialog sfd = new SaveFileDialog();
					sfd.Filter = "Report file(*.rpbi)|*.rpbi";
					sfd.DefaultExt = "rpbi";
					if (sfd.ShowDialog() == DialogResult.OK)
					{
						this.curr_file_path = sfd.FileName;
						File.WriteAllText(this.curr_file_path, this.TextArea.Text.AES_Encrypt(salt));
						this.lblFileName.Text = this.curr_file_path;
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnCloseFile_Click(object sender, EventArgs e)
		{
			if((this.curr_file_path == null && this.TextArea.Text.Trim().Length > 0) ||
				(this.curr_file_path != null && !File.Exists(this.curr_file_path)) ||
				(this.curr_file_path != null && File.Exists(this.curr_file_path) && this.TextArea.Text.CompareTo(File.ReadAllText(this.curr_file_path).AES_Decrypt(salt)) != 0))
			{
				DialogResult result = MessageBox.Show("บันทึกแฟ้มนี้หรือไม่?", "Save File", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
				switch (result)
				{
					case DialogResult.Cancel:
						return;
					case DialogResult.Yes:
						this.btnSave.PerformClick();
						break;
					case DialogResult.No:
						break;
					default:
						return;
				}
			}

			this.curr_file_path = null;
			this.lblFileName.Text = string.Empty;
			//this.btnSave.Enabled = false;
			this.btnCloseFile.Enabled = false;
			this.btnUndo.Enabled = false;
			this.btnRedo.Enabled = false;
			this.btnExpandAll.Enabled = false;
			this.btnCollapseAll.Enabled = false;
			this.TextArea.Text = string.Empty;

		}

		private void btnUndo_Click(object sender, EventArgs e)
		{
			this.TextArea.Undo();
		}

		private void btnRedo_Click(object sender, EventArgs e)
		{
			this.TextArea.Redo();
		}

		private void btnNewFile_Click(object sender, EventArgs e)
		{
			if((this.curr_file_path == null && this.TextArea.Text.Trim().Length > 0) ||
				(this.curr_file_path != null && !File.Exists(this.curr_file_path)) ||
				(this.curr_file_path != null && File.Exists(this.curr_file_path) && this.TextArea.Text.CompareTo(File.ReadAllText(this.curr_file_path).AES_Decrypt(salt)) != 0))
			{
                DialogResult result = MessageBox.Show("บันทึกแฟ้มข้อมูลปัจจุบันนี้ก่อนหรือไม่?", "Save File", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                switch (result)
                {
                    case DialogResult.Cancel:
                        return;
                    case DialogResult.Yes:
                        this.btnSave.PerformClick();
                        break;
                    case DialogResult.No:
                        break;
                    default:
                        return; ;
                }
            }

            this.curr_file_path = null;
            //this.btnSave.Enabled = true;
            this.btnCloseFile.Enabled = true;
            this.btnUndo.Enabled = true;
            this.btnRedo.Enabled = true;
            this.btnExpandAll.Enabled = true;
            this.btnCollapseAll.Enabled = true;
            this.TextArea.Text = string.Empty;
        }

        private void btnExpandAll_Click(object sender, EventArgs e)
		{
			this.ExpandAll();
		}

		private void btnCollapseAll_Click(object sender, EventArgs e)
		{
			this.CollapseAll();
		}
	}
}
