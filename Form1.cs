namespace DrawingWithC_
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private PointF currentPosition;

		private void drawing_MouseMove(object sender, MouseEventArgs e)
		{
			currentPosition = PointToCartesian(e.Location);
			label1.Text = string.Format("{0}, {1}", e.Location.X, e.Location.Y);
			label2.Text = string.Format("{0,0:F3}, {1,0:F3}", currentPosition.X, currentPosition.Y);
		}
		// convert system point to world point
		private PointF PointToCartesian(Point point)
		{
			return new PointF(PixelToMl(point.X), PixelToMl(this.drawing.Height - point.Y));
		}
		// convert pixels to milimeters
		private float PixelToMl(float pixel)
		{
			return pixel * 25.4f / DPI;
		}
		private float DPI
		{
			get
			{
				using (var g = CreateGraphics()) return g.DpiX;
			}
		}
	}
}