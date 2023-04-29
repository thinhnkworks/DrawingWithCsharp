namespace DrawingWithC_
{
	partial class GraphicsForm
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			drawing = new PictureBox();
			menuStrip = new ContextMenuStrip(components);
			cancelToolStripMenuItem = new ToolStripMenuItem();
			btnCloseBoundary = new ToolStripMenuItem();
			label2 = new Label();
			btnLine = new Button();
			btnCircle = new Button();
			btnEllipse = new Button();
			btnArc = new Button();
			vScrollBar = new VScrollBar();
			hScrollBar = new HScrollBar();
			btnPolyline = new Button();
			btnRectangle = new Button();
			btnPolygon = new Button();
			btnSettings = new Button();
			btnCopy = new Button();
			btnMove = new Button();
			panelShapes = new Panel();
			lbShapes = new Label();
			panel1 = new Panel();
			btnFill = new Button();
			btnDelete = new Button();
			lbEdit = new Label();
			lbSettings = new Label();
			panelPen = new Panel();
			cbbPenStyle = new ComboBox();
			lbStyle = new Label();
			nudPenWidth = new NumericUpDown();
			lbWidth = new Label();
			picPenColor = new PictureBox();
			lbPen = new Label();
			((System.ComponentModel.ISupportInitialize)drawing).BeginInit();
			menuStrip.SuspendLayout();
			panelShapes.SuspendLayout();
			panel1.SuspendLayout();
			panelPen.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudPenWidth).BeginInit();
			((System.ComponentModel.ISupportInitialize)picPenColor).BeginInit();
			SuspendLayout();
			// 
			// drawing
			// 
			drawing.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			drawing.BackColor = Color.White;
			drawing.ContextMenuStrip = menuStrip;
			drawing.Location = new Point(0, 172);
			drawing.Margin = new Padding(4, 5, 4, 5);
			drawing.Name = "drawing";
			drawing.Size = new Size(1651, 703);
			drawing.TabIndex = 0;
			drawing.TabStop = false;
			drawing.Paint += drawing_Paint;
			drawing.MouseDown += drawing_MouseDown;
			drawing.MouseMove += drawing_MouseMove;
			drawing.MouseWheel += drawing_MouseWheel;
			// 
			// menuStrip
			// 
			menuStrip.ImageScalingSize = new Size(24, 24);
			menuStrip.Items.AddRange(new ToolStripItem[] { cancelToolStripMenuItem, btnCloseBoundary });
			menuStrip.Name = "menuStrip";
			menuStrip.Size = new Size(136, 68);
			// 
			// cancelToolStripMenuItem
			// 
			cancelToolStripMenuItem.Name = "cancelToolStripMenuItem";
			cancelToolStripMenuItem.Size = new Size(135, 32);
			cancelToolStripMenuItem.Text = "Cancel";
			cancelToolStripMenuItem.Click += cancelToolStripMenuItem_Click;
			// 
			// btnCloseBoundary
			// 
			btnCloseBoundary.Name = "btnCloseBoundary";
			btnCloseBoundary.Size = new Size(135, 32);
			btnCloseBoundary.Text = "Close";
			btnCloseBoundary.Click += btnCloseBoundary_Click;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(10, 876);
			label2.Margin = new Padding(4, 0, 4, 0);
			label2.Name = "label2";
			label2.Size = new Size(59, 25);
			label2.TabIndex = 2;
			label2.Text = "label2";
			// 
			// btnLine
			// 
			btnLine.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			btnLine.Image = Properties.Resources.line;
			btnLine.Location = new Point(16, 5);
			btnLine.Margin = new Padding(4, 5, 4, 5);
			btnLine.Name = "btnLine";
			btnLine.Size = new Size(50, 50);
			btnLine.TabIndex = 4;
			btnLine.UseVisualStyleBackColor = true;
			btnLine.Click += btnLine_Click;
			// 
			// btnCircle
			// 
			btnCircle.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			btnCircle.Image = Properties.Resources.circle;
			btnCircle.Location = new Point(16, 60);
			btnCircle.Margin = new Padding(4, 5, 4, 5);
			btnCircle.Name = "btnCircle";
			btnCircle.Size = new Size(50, 50);
			btnCircle.TabIndex = 5;
			btnCircle.UseVisualStyleBackColor = true;
			btnCircle.Click += btnCircle_Click;
			// 
			// btnEllipse
			// 
			btnEllipse.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			btnEllipse.Image = Properties.Resources.ellipse;
			btnEllipse.Location = new Point(74, 60);
			btnEllipse.Margin = new Padding(4, 5, 4, 5);
			btnEllipse.Name = "btnEllipse";
			btnEllipse.Size = new Size(50, 50);
			btnEllipse.TabIndex = 6;
			btnEllipse.UseVisualStyleBackColor = true;
			btnEllipse.Click += btnEllipse_Click;
			// 
			// btnArc
			// 
			btnArc.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			btnArc.Image = Properties.Resources.arc;
			btnArc.Location = new Point(132, 60);
			btnArc.Margin = new Padding(4, 5, 4, 5);
			btnArc.Name = "btnArc";
			btnArc.Size = new Size(50, 50);
			btnArc.TabIndex = 7;
			btnArc.UseVisualStyleBackColor = true;
			btnArc.Click += btnArc_Click;
			// 
			// vScrollBar
			// 
			vScrollBar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
			vScrollBar.Location = new Point(1652, 172);
			vScrollBar.Name = "vScrollBar";
			vScrollBar.Size = new Size(22, 700);
			vScrollBar.TabIndex = 8;
			vScrollBar.Scroll += vScrollBar_Scroll;
			// 
			// hScrollBar
			// 
			hScrollBar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			hScrollBar.Location = new Point(1302, 876);
			hScrollBar.Name = "hScrollBar";
			hScrollBar.Size = new Size(345, 22);
			hScrollBar.TabIndex = 9;
			hScrollBar.Scroll += hScrollBar_Scroll;
			// 
			// btnPolyline
			// 
			btnPolyline.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			btnPolyline.Image = Properties.Resources.polyline;
			btnPolyline.Location = new Point(132, 5);
			btnPolyline.Margin = new Padding(4, 5, 4, 5);
			btnPolyline.Name = "btnPolyline";
			btnPolyline.Size = new Size(50, 50);
			btnPolyline.TabIndex = 10;
			btnPolyline.UseVisualStyleBackColor = true;
			btnPolyline.Click += btnPolyline_Click;
			// 
			// btnRectangle
			// 
			btnRectangle.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			btnRectangle.Image = Properties.Resources.rectangle;
			btnRectangle.Location = new Point(74, 5);
			btnRectangle.Margin = new Padding(4, 5, 4, 5);
			btnRectangle.Name = "btnRectangle";
			btnRectangle.Size = new Size(50, 50);
			btnRectangle.TabIndex = 11;
			btnRectangle.UseVisualStyleBackColor = true;
			btnRectangle.Click += btnRectangle_Click;
			// 
			// btnPolygon
			// 
			btnPolygon.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			btnPolygon.Image = Properties.Resources.polygon;
			btnPolygon.Location = new Point(190, 5);
			btnPolygon.Margin = new Padding(4, 5, 4, 5);
			btnPolygon.Name = "btnPolygon";
			btnPolygon.Size = new Size(50, 50);
			btnPolygon.TabIndex = 12;
			btnPolygon.UseVisualStyleBackColor = true;
			btnPolygon.Click += btnPolygon_Click;
			// 
			// btnSettings
			// 
			btnSettings.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			btnSettings.Cursor = Cursors.Hand;
			btnSettings.Image = Properties.Resources.settings;
			btnSettings.Location = new Point(1547, 27);
			btnSettings.Margin = new Padding(4, 5, 4, 5);
			btnSettings.Name = "btnSettings";
			btnSettings.Size = new Size(100, 100);
			btnSettings.TabIndex = 13;
			btnSettings.UseVisualStyleBackColor = true;
			btnSettings.Click += btnSettings_Click;
			// 
			// btnCopy
			// 
			btnCopy.Location = new Point(10, 15);
			btnCopy.Name = "btnCopy";
			btnCopy.Size = new Size(112, 34);
			btnCopy.TabIndex = 14;
			btnCopy.Text = "Copy";
			btnCopy.UseVisualStyleBackColor = true;
			btnCopy.Click += btnCopy_Click;
			// 
			// btnMove
			// 
			btnMove.Location = new Point(138, 15);
			btnMove.Name = "btnMove";
			btnMove.Size = new Size(112, 34);
			btnMove.TabIndex = 15;
			btnMove.Text = "Move";
			btnMove.UseVisualStyleBackColor = true;
			btnMove.Click += btnMove_Click;
			// 
			// panelShapes
			// 
			panelShapes.BorderStyle = BorderStyle.FixedSingle;
			panelShapes.Controls.Add(btnLine);
			panelShapes.Controls.Add(btnCircle);
			panelShapes.Controls.Add(btnRectangle);
			panelShapes.Controls.Add(btnEllipse);
			panelShapes.Controls.Add(btnPolyline);
			panelShapes.Controls.Add(btnPolygon);
			panelShapes.Controls.Add(btnArc);
			panelShapes.Location = new Point(33, 16);
			panelShapes.Name = "panelShapes";
			panelShapes.Size = new Size(256, 117);
			panelShapes.TabIndex = 16;
			// 
			// lbShapes
			// 
			lbShapes.AutoSize = true;
			lbShapes.Location = new Point(118, 137);
			lbShapes.Name = "lbShapes";
			lbShapes.Size = new Size(69, 25);
			lbShapes.TabIndex = 17;
			lbShapes.Text = "Shapes";
			// 
			// panel1
			// 
			panel1.BorderStyle = BorderStyle.FixedSingle;
			panel1.Controls.Add(btnFill);
			panel1.Controls.Add(btnDelete);
			panel1.Controls.Add(btnCopy);
			panel1.Controls.Add(btnMove);
			panel1.Location = new Point(336, 16);
			panel1.Name = "panel1";
			panel1.Size = new Size(264, 117);
			panel1.TabIndex = 18;
			// 
			// btnFill
			// 
			btnFill.Location = new Point(138, 69);
			btnFill.Name = "btnFill";
			btnFill.Size = new Size(112, 34);
			btnFill.TabIndex = 17;
			btnFill.Text = "Fill";
			btnFill.UseVisualStyleBackColor = true;
			// 
			// btnDelete
			// 
			btnDelete.Location = new Point(10, 69);
			btnDelete.Name = "btnDelete";
			btnDelete.Size = new Size(112, 34);
			btnDelete.TabIndex = 16;
			btnDelete.Text = "Delete";
			btnDelete.UseVisualStyleBackColor = true;
			// 
			// lbEdit
			// 
			lbEdit.AutoSize = true;
			lbEdit.Location = new Point(437, 137);
			lbEdit.Name = "lbEdit";
			lbEdit.Size = new Size(42, 25);
			lbEdit.TabIndex = 19;
			lbEdit.Text = "Edit";
			// 
			// lbSettings
			// 
			lbSettings.AutoSize = true;
			lbSettings.Location = new Point(1557, 131);
			lbSettings.Name = "lbSettings";
			lbSettings.Size = new Size(76, 25);
			lbSettings.TabIndex = 20;
			lbSettings.Text = "Settings";
			// 
			// panelPen
			// 
			panelPen.BorderStyle = BorderStyle.FixedSingle;
			panelPen.Controls.Add(cbbPenStyle);
			panelPen.Controls.Add(lbStyle);
			panelPen.Controls.Add(nudPenWidth);
			panelPen.Controls.Add(lbWidth);
			panelPen.Controls.Add(picPenColor);
			panelPen.Location = new Point(648, 16);
			panelPen.Name = "panelPen";
			panelPen.Size = new Size(391, 117);
			panelPen.TabIndex = 21;
			// 
			// cbbPenStyle
			// 
			cbbPenStyle.FormattingEnabled = true;
			cbbPenStyle.Items.AddRange(new object[] { "Solid", "Dash", "Dash dot" });
			cbbPenStyle.Location = new Point(209, 62);
			cbbPenStyle.Name = "cbbPenStyle";
			cbbPenStyle.Size = new Size(151, 33);
			cbbPenStyle.TabIndex = 4;
			cbbPenStyle.SelectedIndexChanged += cbbPenStyle_SelectedIndexChanged;
			// 
			// lbStyle
			// 
			lbStyle.AutoSize = true;
			lbStyle.Location = new Point(127, 65);
			lbStyle.Name = "lbStyle";
			lbStyle.Size = new Size(49, 25);
			lbStyle.TabIndex = 3;
			lbStyle.Text = "Style";
			// 
			// nudPenWidth
			// 
			nudPenWidth.Location = new Point(209, 18);
			nudPenWidth.Name = "nudPenWidth";
			nudPenWidth.Size = new Size(151, 31);
			nudPenWidth.TabIndex = 2;
			nudPenWidth.Value = new decimal(new int[] { 1, 0, 0, 0 });
			nudPenWidth.ValueChanged += nudPenWidth_ValueChanged;
			// 
			// lbWidth
			// 
			lbWidth.AutoSize = true;
			lbWidth.Location = new Point(128, 20);
			lbWidth.Name = "lbWidth";
			lbWidth.Size = new Size(60, 25);
			lbWidth.TabIndex = 1;
			lbWidth.Text = "Width";
			// 
			// picPenColor
			// 
			picPenColor.BorderStyle = BorderStyle.Fixed3D;
			picPenColor.Location = new Point(24, 19);
			picPenColor.Name = "picPenColor";
			picPenColor.Size = new Size(75, 75);
			picPenColor.TabIndex = 0;
			picPenColor.TabStop = false;
			// 
			// lbPen
			// 
			lbPen.AutoSize = true;
			lbPen.Location = new Point(820, 137);
			lbPen.Name = "lbPen";
			lbPen.Size = new Size(40, 25);
			lbPen.TabIndex = 22;
			lbPen.Text = "Pen";
			// 
			// GraphicsForm
			// 
			AutoScaleDimensions = new SizeF(10F, 25F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = SystemColors.ControlLight;
			ClientSize = new Size(1678, 912);
			Controls.Add(lbPen);
			Controls.Add(panelPen);
			Controls.Add(lbSettings);
			Controls.Add(lbEdit);
			Controls.Add(panel1);
			Controls.Add(lbShapes);
			Controls.Add(panelShapes);
			Controls.Add(btnSettings);
			Controls.Add(hScrollBar);
			Controls.Add(vScrollBar);
			Controls.Add(label2);
			Controls.Add(drawing);
			Margin = new Padding(4, 5, 4, 5);
			Name = "GraphicsForm";
			Text = "Graphics Form";
			Load += Form1_Load;
			((System.ComponentModel.ISupportInitialize)drawing).EndInit();
			menuStrip.ResumeLayout(false);
			panelShapes.ResumeLayout(false);
			panel1.ResumeLayout(false);
			panelPen.ResumeLayout(false);
			panelPen.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudPenWidth).EndInit();
			((System.ComponentModel.ISupportInitialize)picPenColor).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private PictureBox drawing;
		private Label label2;
		private Button btnLine;
		private Button btnCircle;
		private Button btnEllipse;
		private ContextMenuStrip menuStrip;
		private ToolStripMenuItem cancelToolStripMenuItem;
		private Button btnArc;
		private VScrollBar vScrollBar;
		private HScrollBar hScrollBar;
		private ToolStripMenuItem btnCloseBoundary;
		private Button btnPolyline;
		private Button btnRectangle;
		private Button btnPolygon;
		private Button btnSettings;
		private Button btnCopy;
		private Button btnMove;
		private Panel panelShapes;
		private Label lbShapes;
		private Panel panel1;
		private Label lbEdit;
		private Button btnDelete;
		private Label lbSettings;
		private Panel panelPen;
		private Label lbPen;
		private Button btnFill;
		private Label lbWidth;
		private Label lbStyle;
		private NumericUpDown nudPenWidth;
		private ComboBox cbbPenStyle;
		public static PictureBox picPenColor;
	}
}