﻿namespace DrawingWithC_
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
			btnPoint = new Button();
			btnLine = new Button();
			btnCircle = new Button();
			btnEllipse = new Button();
			btnArc = new Button();
			vScrollbar = new VScrollBar();
			hScrollBar = new HScrollBar();
			btnPolyline = new Button();
			btnRectangle = new Button();
			((System.ComponentModel.ISupportInitialize)drawing).BeginInit();
			menuStrip.SuspendLayout();
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
			// btnPoint
			// 
			btnPoint.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			btnPoint.Location = new Point(48, 42);
			btnPoint.Margin = new Padding(4, 5, 4, 5);
			btnPoint.Name = "btnPoint";
			btnPoint.Size = new Size(100, 100);
			btnPoint.TabIndex = 3;
			btnPoint.Text = "Point";
			btnPoint.UseVisualStyleBackColor = true;
			btnPoint.Click += btnPoint_Click;
			// 
			// btnLine
			// 
			btnLine.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			btnLine.Image = Properties.Resources.line;
			btnLine.Location = new Point(187, 42);
			btnLine.Margin = new Padding(4, 5, 4, 5);
			btnLine.Name = "btnLine";
			btnLine.Size = new Size(100, 100);
			btnLine.TabIndex = 4;
			btnLine.UseVisualStyleBackColor = true;
			btnLine.Click += btnLine_Click;
			// 
			// btnCircle
			// 
			btnCircle.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			btnCircle.Image = Properties.Resources.circle;
			btnCircle.Location = new Point(326, 42);
			btnCircle.Margin = new Padding(4, 5, 4, 5);
			btnCircle.Name = "btnCircle";
			btnCircle.Size = new Size(100, 100);
			btnCircle.TabIndex = 5;
			btnCircle.UseVisualStyleBackColor = true;
			btnCircle.Click += btnCircle_Click;
			// 
			// btnEllipse
			// 
			btnEllipse.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			btnEllipse.Image = Properties.Resources.ellipse;
			btnEllipse.Location = new Point(473, 42);
			btnEllipse.Margin = new Padding(4, 5, 4, 5);
			btnEllipse.Name = "btnEllipse";
			btnEllipse.Size = new Size(100, 100);
			btnEllipse.TabIndex = 6;
			btnEllipse.UseVisualStyleBackColor = true;
			btnEllipse.Click += btnEllipse_Click;
			// 
			// btnArc
			// 
			btnArc.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			btnArc.Image = Properties.Resources.arc;
			btnArc.Location = new Point(619, 42);
			btnArc.Margin = new Padding(4, 5, 4, 5);
			btnArc.Name = "btnArc";
			btnArc.Size = new Size(100, 100);
			btnArc.TabIndex = 7;
			btnArc.UseVisualStyleBackColor = true;
			btnArc.Click += btnArc_Click;
			// 
			// vScrollbar
			// 
			vScrollbar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
			vScrollbar.Location = new Point(1652, 172);
			vScrollbar.Name = "vScrollbar";
			vScrollbar.Size = new Size(22, 700);
			vScrollbar.TabIndex = 8;
			vScrollbar.Scroll += vScrollbar_Scroll;
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
			btnPolyline.Location = new Point(772, 42);
			btnPolyline.Margin = new Padding(4, 5, 4, 5);
			btnPolyline.Name = "btnPolyline";
			btnPolyline.Size = new Size(100, 100);
			btnPolyline.TabIndex = 10;
			btnPolyline.Text = "Polyline";
			btnPolyline.UseVisualStyleBackColor = true;
			btnPolyline.Click += btnPolyline_Click;
			// 
			// btnRectangle
			// 
			btnRectangle.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			btnRectangle.Location = new Point(925, 42);
			btnRectangle.Margin = new Padding(4, 5, 4, 5);
			btnRectangle.Name = "btnRectangle";
			btnRectangle.Size = new Size(100, 100);
			btnRectangle.TabIndex = 11;
			btnRectangle.Text = "Rectangle";
			btnRectangle.UseVisualStyleBackColor = true;
			btnRectangle.Click += btnRectangle_Click;
			// 
			// GraphicsForm
			// 
			AutoScaleDimensions = new SizeF(10F, 25F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = SystemColors.ControlLight;
			ClientSize = new Size(1678, 912);
			Controls.Add(btnRectangle);
			Controls.Add(btnPolyline);
			Controls.Add(hScrollBar);
			Controls.Add(vScrollbar);
			Controls.Add(btnArc);
			Controls.Add(btnEllipse);
			Controls.Add(btnCircle);
			Controls.Add(btnLine);
			Controls.Add(btnPoint);
			Controls.Add(label2);
			Controls.Add(drawing);
			Margin = new Padding(4, 5, 4, 5);
			Name = "GraphicsForm";
			Text = "Form1";
			Load += Form1_Load;
			((System.ComponentModel.ISupportInitialize)drawing).EndInit();
			menuStrip.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private PictureBox drawing;
		private Label label2;
		private Button btnPoint;
		private Button btnLine;
		private Button btnCircle;
		private Button btnEllipse;
		private ContextMenuStrip menuStrip;
		private ToolStripMenuItem cancelToolStripMenuItem;
		private Button btnArc;
		private VScrollBar vScrollbar;
		private HScrollBar hScrollBar;
		private ToolStripMenuItem btnCloseBoundary;
		private Button btnPolyline;
		private Button btnRectangle;
	}
}