namespace DrawingWithC_
{
	partial class MainForm
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
			mainMenu = new MenuStrip();
			fileToolStripMenuItem = new ToolStripMenuItem();
			btnNew = new ToolStripMenuItem();
			btnOpen = new ToolStripMenuItem();
			btnExit = new ToolStripMenuItem();
			mainMenu.SuspendLayout();
			SuspendLayout();
			// 
			// mainMenu
			// 
			mainMenu.ImageScalingSize = new Size(24, 24);
			mainMenu.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
			mainMenu.Location = new Point(0, 0);
			mainMenu.Name = "mainMenu";
			mainMenu.Size = new Size(1678, 33);
			mainMenu.TabIndex = 1;
			mainMenu.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { btnNew, btnOpen, btnExit });
			fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			fileToolStripMenuItem.Size = new Size(54, 29);
			fileToolStripMenuItem.Text = "File";
			// 
			// btnNew
			// 
			btnNew.Name = "btnNew";
			btnNew.Size = new Size(158, 34);
			btnNew.Text = "New";
			btnNew.Click += btnNew_Click;
			// 
			// btnOpen
			// 
			btnOpen.Name = "btnOpen";
			btnOpen.Size = new Size(158, 34);
			btnOpen.Text = "Open";
			// 
			// btnExit
			// 
			btnExit.Name = "btnExit";
			btnExit.Size = new Size(158, 34);
			btnExit.Text = "Exit";
			// 
			// MainForm
			// 
			AutoScaleDimensions = new SizeF(10F, 25F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1678, 944);
			Controls.Add(mainMenu);
			IsMdiContainer = true;
			MainMenuStrip = mainMenu;
			Name = "MainForm";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "MainForm";
			mainMenu.ResumeLayout(false);
			mainMenu.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private MenuStrip mainMenu;
		private ToolStripMenuItem fileToolStripMenuItem;
		private ToolStripMenuItem btnNew;
		private ToolStripMenuItem btnOpen;
		private ToolStripMenuItem btnExit;
	}
}