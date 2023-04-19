namespace DrawingWithC_
{
	partial class Form1
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
			drawing = new PictureBox();
			label1 = new Label();
			label2 = new Label();
			pointButton = new Button();
			lineBtn = new Button();
			circleBtn = new Button();
			ellipseBtn = new Button();
			((System.ComponentModel.ISupportInitialize)drawing).BeginInit();
			SuspendLayout();
			// 
			// drawing
			// 
			drawing.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			drawing.BackColor = Color.White;
			drawing.Location = new Point(0, 0);
			drawing.Margin = new Padding(4, 5, 4, 5);
			drawing.Name = "drawing";
			drawing.Size = new Size(1363, 810);
			drawing.TabIndex = 0;
			drawing.TabStop = false;
			drawing.Paint += drawing_Paint;
			drawing.MouseDown += drawing_MouseDown;
			drawing.MouseMove += drawing_MouseMove;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(31, 848);
			label1.Margin = new Padding(4, 0, 4, 0);
			label1.Name = "label1";
			label1.Size = new Size(59, 25);
			label1.TabIndex = 1;
			label1.Text = "label1";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(31, 920);
			label2.Margin = new Padding(4, 0, 4, 0);
			label2.Name = "label2";
			label2.Size = new Size(59, 25);
			label2.TabIndex = 2;
			label2.Text = "label2";
			// 
			// pointButton
			// 
			pointButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			pointButton.Location = new Point(1460, 85);
			pointButton.Margin = new Padding(4, 5, 4, 5);
			pointButton.Name = "pointButton";
			pointButton.Size = new Size(107, 38);
			pointButton.TabIndex = 3;
			pointButton.Text = "Point";
			pointButton.UseVisualStyleBackColor = true;
			pointButton.Click += pointButton_Click;
			// 
			// lineBtn
			// 
			lineBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			lineBtn.Location = new Point(1460, 190);
			lineBtn.Margin = new Padding(4, 5, 4, 5);
			lineBtn.Name = "lineBtn";
			lineBtn.Size = new Size(107, 38);
			lineBtn.TabIndex = 4;
			lineBtn.Text = "Line";
			lineBtn.UseVisualStyleBackColor = true;
			lineBtn.Click += lineBtn_Click;
			// 
			// circleBtn
			// 
			circleBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			circleBtn.Location = new Point(1460, 300);
			circleBtn.Margin = new Padding(4, 5, 4, 5);
			circleBtn.Name = "circleBtn";
			circleBtn.Size = new Size(107, 38);
			circleBtn.TabIndex = 5;
			circleBtn.Text = "Circle";
			circleBtn.UseVisualStyleBackColor = true;
			circleBtn.Click += circleBtn_Click;
			// 
			// ellipseBtn
			// 
			ellipseBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			ellipseBtn.Location = new Point(1460, 411);
			ellipseBtn.Margin = new Padding(4, 5, 4, 5);
			ellipseBtn.Name = "ellipseBtn";
			ellipseBtn.Size = new Size(107, 38);
			ellipseBtn.TabIndex = 6;
			ellipseBtn.Text = "Ellipse";
			ellipseBtn.UseVisualStyleBackColor = true;
			ellipseBtn.Click += ellipseBtn_Click;
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(10F, 25F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = SystemColors.ControlLight;
			ClientSize = new Size(1691, 1115);
			Controls.Add(ellipseBtn);
			Controls.Add(circleBtn);
			Controls.Add(lineBtn);
			Controls.Add(pointButton);
			Controls.Add(label2);
			Controls.Add(label1);
			Controls.Add(drawing);
			Margin = new Padding(4, 5, 4, 5);
			Name = "Form1";
			Text = "Form1";
			Load += Form1_Load;
			((System.ComponentModel.ISupportInitialize)drawing).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private PictureBox drawing;
		private Label label1;
		private Label label2;
		private Button pointButton;
		private Button lineBtn;
		private Button circleBtn;
		private Button ellipseBtn;
	}
}