using Android.Graphics;

namespace DrawItXamarinAndroid.Models
{
    public class PolygonLine
    {
        public PolygonLine()
        {
            Path = new Path();
        }
        public Color Color { get; set; }
        public float StrokeWidht { get; set; }
        public Path Path { get; set; }
    }
}
