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
			((System.ComponentModel.ISupportInitialize)drawing).BeginInit();
			SuspendLayout();
			// 
			// drawing
			// 
			drawing.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			drawing.BackColor = Color.White;
			drawing.Location = new Point(0, 0);
			drawing.Name = "drawing";
			drawing.Size = new Size(954, 486);
			drawing.TabIndex = 0;
			drawing.TabStop = false;
			drawing.Paint += drawing_Paint;
			drawing.MouseDown += drawing_MouseDown;
			drawing.MouseMove += drawing_MouseMove;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(22, 509);
			label1.Name = "label1";
			label1.Size = new Size(38, 15);
			label1.TabIndex = 1;
			label1.Text = "label1";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(22, 552);
			label2.Name = "label2";
			label2.Size = new Size(38, 15);
			label2.TabIndex = 2;
			label2.Text = "label2";
			// 
			// pointButton
			// 
			pointButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			pointButton.Location = new Point(1022, 51);
			pointButton.Name = "pointButton";
			pointButton.Size = new Size(75, 23);
			pointButton.TabIndex = 3;
			pointButton.Text = "Point";
			pointButton.UseVisualStyleBackColor = true;
			pointButton.Click += pointButton_Click;
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = SystemColors.ControlLight;
			ClientSize = new Size(1184, 669);
			Controls.Add(pointButton);
			Controls.Add(label2);
			Controls.Add(label1);
			Controls.Add(drawing);
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
	}
}