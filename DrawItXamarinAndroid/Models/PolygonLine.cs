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
        public float StrokeWidth { get; set; }
        public Path Path { get; private set; }
    }
}
