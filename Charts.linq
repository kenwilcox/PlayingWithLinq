<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Drawing.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Windows.Forms.DataVisualization.dll</Reference>
  <NuGetReference>Linq2Charts</NuGetReference>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Linq.Charting</Namespace>
  <Namespace>System.Windows.Forms.DataVisualization.Charting</Namespace>
</Query>

void Main()
{
	//var path = Path.Combine(Environment.CurrentDirectory, "logo.png");
	var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), @"LINQPad Queries\logo.png");
    var image = new Bitmap(path);
	var pixels = ColorPoint.Pixels(image);
	
	var copy = from pixel in pixels
	        let y = new System.Linq.Charting.Point.DataPoint(image.Height - pixel.Y) { Color = pixel.Color }
	        let x = pixel.X + 1
	        select KeyValuePair.Create(x, y);
	
	var pixelated = new System.Linq.Charting.Point { Points = { copy } };
	var chart = new System.Linq.Charting.Chart { ChartAreas = { pixelated }};
	chart.Dump();
}

// Define other methods and classes here
class ColorPoint
{
  public int X { get; set; }
  public int Y { get; set; }
  public Color Color { get; set; }

  public static IEnumerable<ColorPoint> Pixels(Bitmap image)
  {
      for (var x = 0; x < image.Width; x++)
          for (var y = 0; y < image.Height; y++)
              yield return new ColorPoint { X = x, Y = y, Color = image.GetPixel(x, y) };
  }
}