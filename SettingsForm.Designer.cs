namespace DrawingWithC_
{
	partial class SettingsForm
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
			panel1 = new Panel();
			btnCancelSettings = new Button();
			btnOKSettings = new Button();
			btnPolygonSettings = new Label();
			btnBrushSettings = new Label();
			btnPenSettings = new Label();
			panelPenSettings = new Panel();
			picPenColor = new PictureBox();
			cbbPenStyle = new ComboBox();
			btnPenColorWheel = new Button();
			nudPenSize = new NumericUpDown();
			lbPenStyle = new Label();
			lbPenColor = new Label();
			lbPenSize = new Label();
			panelBrushSettings = new Panel();
			panelPolygonSettings = new Panel();
			cbbPolygonStatus = new ComboBox();
			lbPolygonStatus = new Label();
			nudPolygonSides = new NumericUpDown();
			lbSides = new Label();
			btnBrushColorWheel = new Button();
			picBrushColor = new PictureBox();
			lbBrushFillColor = new Label();
			colorDialog1 = new ColorDialog();
			panel1.SuspendLayout();
			panelPenSettings.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)picPenColor).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudPenSize).BeginInit();
			panelBrushSettings.SuspendLayout();
			panelPolygonSettings.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudPolygonSides).BeginInit();
			((System.ComponentModel.ISupportInitialize)picBrushColor).BeginInit();
			SuspendLayout();
			// 
			// panel1
			// 
			panel1.BackColor = SystemColors.ControlLight;
			panel1.Controls.Add(btnCancelSettings);
			panel1.Controls.Add(btnOKSettings);
			panel1.Controls.Add(btnPolygonSettings);
			panel1.Controls.Add(btnBrushSettings);
			panel1.Controls.Add(btnPenSettings);
			panel1.Location = new Point(-3, -4);
			panel1.Name = "panel1";
			panel1.Size = new Size(261, 716);
			panel1.TabIndex = 0;
			// 
			// btnCancelSettings
			// 
			btnCancelSettings.Location = new Point(45, 629);
			btnCancelSettings.Name = "btnCancelSettings";
			btnCancelSettings.Size = new Size(162, 55);
			btnCancelSettings.TabIndex = 4;
			btnCancelSettings.Text = "Cancel";
			btnCancelSettings.UseVisualStyleBackColor = true;
			btnCancelSettings.Click += btnCancelSettings_Click;
			// 
			// btnOKSettings
			// 
			btnOKSettings.Location = new Point(45, 546);
			btnOKSettings.Name = "btnOKSettings";
			btnOKSettings.Size = new Size(162, 55);
			btnOKSettings.TabIndex = 3;
			btnOKSettings.Text = "OK";
			btnOKSettings.UseVisualStyleBackColor = true;
			btnOKSettings.Click += btnOKSettings_Click;
			// 
			// btnPolygonSettings
			// 
			btnPolygonSettings.AutoSize = true;
			btnPolygonSettings.Cursor = Cursors.Hand;
			btnPolygonSettings.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
			btnPolygonSettings.Location = new Point(40, 252);
			btnPolygonSettings.Name = "btnPolygonSettings";
			btnPolygonSettings.Size = new Size(117, 38);
			btnPolygonSettings.TabIndex = 2;
			btnPolygonSettings.Text = "Polygon";
			btnPolygonSettings.Click += btnPolygonSettings_Click;
			// 
			// btnBrushSettings
			// 
			btnBrushSettings.AutoSize = true;
			btnBrushSettings.Cursor = Cursors.Hand;
			btnBrushSettings.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
			btnBrushSettings.Location = new Point(40, 155);
			btnBrushSettings.Name = "btnBrushSettings";
			btnBrushSettings.Size = new Size(191, 38);
			btnBrushSettings.TabIndex = 1;
			btnBrushSettings.Text = "Brush settings";
			btnBrushSettings.Click += btnBrushSettings_Click;
			// 
			// btnPenSettings
			// 
			btnPenSettings.AutoSize = true;
			btnPenSettings.Cursor = Cursors.Hand;
			btnPenSettings.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
			btnPenSettings.Location = new Point(40, 56);
			btnPenSettings.Name = "btnPenSettings";
			btnPenSettings.Size = new Size(167, 38);
			btnPenSettings.TabIndex = 0;
			btnPenSettings.Text = "Pen settings";
			btnPenSettings.Click += btnPenSettings_Click;
			// 
			// panelPenSettings
			// 
			panelPenSettings.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			panelPenSettings.Controls.Add(picPenColor);
			panelPenSettings.Controls.Add(cbbPenStyle);
			panelPenSettings.Controls.Add(btnPenColorWheel);
			panelPenSettings.Controls.Add(nudPenSize);
			panelPenSettings.Controls.Add(lbPenStyle);
			panelPenSettings.Controls.Add(lbPenColor);
			panelPenSettings.Controls.Add(lbPenSize);
			panelPenSettings.Location = new Point(275, 12);
			panelPenSettings.Name = "panelPenSettings";
			panelPenSettings.Size = new Size(722, 687);
			panelPenSettings.TabIndex = 0;
			// 
			// picPenColor
			// 
			picPenColor.BackColor = Color.Blue;
			picPenColor.BorderStyle = BorderStyle.Fixed3D;
			picPenColor.Location = new Point(274, 268);
			picPenColor.Name = "picPenColor";
			picPenColor.Size = new Size(75, 75);
			picPenColor.TabIndex = 6;
			picPenColor.TabStop = false;
			// 
			// cbbPenStyle
			// 
			cbbPenStyle.DisplayMember = "0";
			cbbPenStyle.FormattingEnabled = true;
			cbbPenStyle.Items.AddRange(new object[] { "Solid", "Dash", "Dash dot", "Dot" });
			cbbPenStyle.Location = new Point(274, 507);
			cbbPenStyle.Name = "cbbPenStyle";
			cbbPenStyle.Size = new Size(259, 33);
			cbbPenStyle.TabIndex = 5;
			// 
			// btnPenColorWheel
			// 
			btnPenColorWheel.Cursor = Cursors.Hand;
			btnPenColorWheel.FlatAppearance.BorderSize = 0;
			btnPenColorWheel.FlatStyle = FlatStyle.Flat;
			btnPenColorWheel.Image = Properties.Resources.colorwheel;
			btnPenColorWheel.Location = new Point(376, 232);
			btnPenColorWheel.Name = "btnPenColorWheel";
			btnPenColorWheel.Size = new Size(155, 149);
			btnPenColorWheel.TabIndex = 4;
			btnPenColorWheel.UseVisualStyleBackColor = true;
			btnPenColorWheel.Click += btnPenColorWheel_Click;
			// 
			// nudPenSize
			// 
			nudPenSize.Location = new Point(274, 84);
			nudPenSize.Name = "nudPenSize";
			nudPenSize.Size = new Size(257, 31);
			nudPenSize.TabIndex = 3;
			nudPenSize.Value = new decimal(new int[] { 1, 0, 0, 0 });
			// 
			// lbPenStyle
			// 
			lbPenStyle.AutoSize = true;
			lbPenStyle.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
			lbPenStyle.Location = new Point(83, 504);
			lbPenStyle.Name = "lbPenStyle";
			lbPenStyle.Size = new Size(65, 32);
			lbPenStyle.TabIndex = 2;
			lbPenStyle.Text = "Style";
			// 
			// lbPenColor
			// 
			lbPenColor.AutoSize = true;
			lbPenColor.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
			lbPenColor.Location = new Point(83, 288);
			lbPenColor.Name = "lbPenColor";
			lbPenColor.Size = new Size(71, 32);
			lbPenColor.TabIndex = 1;
			lbPenColor.Text = "Color";
			// 
			// lbPenSize
			// 
			lbPenSize.AutoSize = true;
			lbPenSize.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
			lbPenSize.Location = new Point(83, 84);
			lbPenSize.Name = "lbPenSize";
			lbPenSize.Size = new Size(57, 32);
			lbPenSize.TabIndex = 0;
			lbPenSize.Text = "Size";
			// 
			// panelBrushSettings
			// 
			panelBrushSettings.Controls.Add(btnBrushColorWheel);
			panelBrushSettings.Controls.Add(picBrushColor);
			panelBrushSettings.Controls.Add(lbBrushFillColor);
			panelBrushSettings.Location = new Point(275, 12);
			panelBrushSettings.Name = "panelBrushSettings";
			panelBrushSettings.Size = new Size(722, 687);
			panelBrushSettings.TabIndex = 0;
			// 
			// panelPolygonSettings
			// 
			panelPolygonSettings.Controls.Add(cbbPolygonStatus);
			panelPolygonSettings.Controls.Add(lbPolygonStatus);
			panelPolygonSettings.Controls.Add(nudPolygonSides);
			panelPolygonSettings.Controls.Add(lbSides);
			panelPolygonSettings.Location = new Point(275, 12);
			panelPolygonSettings.Name = "panelPolygonSettings";
			panelPolygonSettings.Size = new Size(722, 691);
			panelPolygonSettings.TabIndex = 0;
			// 
			// cbbPolygonStatus
			// 
			cbbPolygonStatus.FormattingEnabled = true;
			cbbPolygonStatus.Items.AddRange(new object[] { "Noi tiep", "Ngoai tiep" });
			cbbPolygonStatus.Location = new Point(295, 417);
			cbbPolygonStatus.Name = "cbbPolygonStatus";
			cbbPolygonStatus.Size = new Size(221, 33);
			cbbPolygonStatus.TabIndex = 3;
			// 
			// lbPolygonStatus
			// 
			lbPolygonStatus.AutoSize = true;
			lbPolygonStatus.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
			lbPolygonStatus.Location = new Point(83, 414);
			lbPolygonStatus.Name = "lbPolygonStatus";
			lbPolygonStatus.Size = new Size(78, 32);
			lbPolygonStatus.TabIndex = 2;
			lbPolygonStatus.Text = "Status";
			// 
			// nudPolygonSides
			// 
			nudPolygonSides.Location = new Point(285, 199);
			nudPolygonSides.Name = "nudPolygonSides";
			nudPolygonSides.Size = new Size(231, 31);
			nudPolygonSides.TabIndex = 1;
			nudPolygonSides.Value = new decimal(new int[] { 3, 0, 0, 0 });
			// 
			// lbSides
			// 
			lbSides.AutoSize = true;
			lbSides.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
			lbSides.Location = new Point(79, 198);
			lbSides.Name = "lbSides";
			lbSides.Size = new Size(70, 32);
			lbSides.TabIndex = 0;
			lbSides.Text = "Sides";
			// 
			// btnBrushColorWheel
			// 
			btnBrushColorWheel.Cursor = Cursors.Hand;
			btnBrushColorWheel.FlatAppearance.BorderSize = 0;
			btnBrushColorWheel.FlatStyle = FlatStyle.Flat;
			btnBrushColorWheel.Image = Properties.Resources.colorwheel;
			btnBrushColorWheel.Location = new Point(411, 254);
			btnBrushColorWheel.Name = "btnBrushColorWheel";
			btnBrushColorWheel.Size = new Size(150, 150);
			btnBrushColorWheel.TabIndex = 2;
			btnBrushColorWheel.UseVisualStyleBackColor = true;
			btnBrushColorWheel.Click += btnBrushColorWheel_Click;
			// 
			// picBrushColor
			// 
			picBrushColor.BackColor = Color.Blue;
			picBrushColor.BorderStyle = BorderStyle.Fixed3D;
			picBrushColor.Location = new Point(295, 288);
			picBrushColor.Name = "picBrushColor";
			picBrushColor.Size = new Size(75, 75);
			picBrushColor.TabIndex = 1;
			picBrushColor.TabStop = false;
			// 
			// lbBrushFillColor
			// 
			lbBrushFillColor.AutoSize = true;
			lbBrushFillColor.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
			lbBrushFillColor.Location = new Point(56, 311);
			lbBrushFillColor.Name = "lbBrushFillColor";
			lbBrushFillColor.Size = new Size(108, 32);
			lbBrushFillColor.TabIndex = 0;
			lbBrushFillColor.Text = "Fill Color";
			// 
			// SettingsForm
			// 
			AutoScaleDimensions = new SizeF(10F, 25F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1009, 711);
			Controls.Add(panelPolygonSettings);
			Controls.Add(panelBrushSettings);
			Controls.Add(panelPenSettings);
			Controls.Add(panel1);
			Name = "SettingsForm";
			Text = "SettingsForm";
			Load += SettingsForm_Load;
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			panelPenSettings.ResumeLayout(false);
			panelPenSettings.PerformLayout();
			((System.ComponentModel.ISupportInitialize)picPenColor).EndInit();
			((System.ComponentModel.ISupportInitialize)nudPenSize).EndInit();
			panelBrushSettings.ResumeLayout(false);
			panelBrushSettings.PerformLayout();
			panelPolygonSettings.ResumeLayout(false);
			panelPolygonSettings.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudPolygonSides).EndInit();
			((System.ComponentModel.ISupportInitialize)picBrushColor).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private Panel panel1;
		private Label btnPenSettings;
		private Label btnPolygonSettings;
		private Label btnBrushSettings;
		private Button btnCancelSettings;
		private Button btnOKSettings;
		private Panel panelPenSettings;
		private Label lbPenSize;
		private Label lbPenStyle;
		private Label lbPenColor;
		private NumericUpDown nudPenSize;
		private ColorDialog colorDialog1;
		private Button btnPenColorWheel;
		private ComboBox cbbPenStyle;
		private PictureBox picPenColor;
		private Panel panelBrushSettings;
		private Label lbBrushFillColor;
		private PictureBox picBrushColor;
		private Button btnBrushColorWheel;
		private Panel panelPolygonSettings;
		private Label lbSides;
		private NumericUpDown nudPolygonSides;
		private Label lbPolygonStatus;
		private ComboBox cbbPolygonStatus;
	}
}