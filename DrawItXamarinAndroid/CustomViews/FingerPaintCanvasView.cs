using System.Collections.Generic;

using Android.Content;
using Android.Util;
using Android.Graphics;
using Android.Views;
using DrawItXamarinAndroid.Models;

namespace DrawItXamarinAndroid.CustomViews
{
    public class FingerPainCanvasView : View
    {
        Dictionary<int, PolygonLine> inProgressPolygoneLine = new Dictionary<int, PolygonLine>();
        List<PolygonLine> completedPolygonLine = new List<PolygonLine>();
        Paint paint = new Paint();
        PolygonLine currentLine;

        public FingerPainCanvasView(Context context) : base(context)
        {
            Initialize();
        }

        public FingerPainCanvasView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            Initialize();
        }

        void Initialize()
        {

        }

        public Color StrokeColor { get; set; } = Color.Black;
        public float StrokeWidth { get; set; } = 5;

        //Clear methods
        public void ClearAll()
        {
            completedPolygonLine.Clear();
            Invalidate();
        }

        public void ClearOnce()
        {
            completedPolygonLine.Remove(currentLine);
            if (completedPolygonLine.Count > 0)
                currentLine = completedPolygonLine[completedPolygonLine.Count - 1];
                
            Invalidate();
        }

        //Overrides
        public override bool OnTouchEvent(MotionEvent e)
        {
            
            int pointerIndex = e.ActionIndex;
            int id = e.GetPointerId(pointerIndex);

            switch(e.ActionMasked)
            {
                case MotionEventActions.Down:
                case MotionEventActions.PointerDown:

                    PolygonLine line = new PolygonLine()
                    {
                        Color = StrokeColor,
                        StrokeWidth = StrokeWidth
                    };

                    line.Path.MoveTo(e.GetX(pointerIndex), e.GetY(pointerIndex));
                    inProgressPolygoneLine.Add(id, line);
                    break;
                case MotionEventActions.Move:

                    for (pointerIndex = 0; pointerIndex < e.PointerCount; pointerIndex++)
                    {
                        id = e.GetPointerId(pointerIndex);
                        inProgressPolygoneLine[id].Path.LineTo(e.GetX(pointerIndex), e.GetY(pointerIndex));
                    }
                    break;
                case MotionEventActions.Up:
                case MotionEventActions.Pointer1Up:

                    inProgressPolygoneLine[id].Path.MoveTo(e.GetX(pointerIndex), e.GetY(pointerIndex));
                    completedPolygonLine.Add(inProgressPolygoneLine[id]);
                    currentLine = inProgressPolygoneLine[id];
                    inProgressPolygoneLine.Remove(id);
                    currentLine = inProgressPolygoneLine[id];
                    break;
                case MotionEventActions.Cancel:
                    inProgressPolygoneLine.Remove(id);
                    break;
            }
            Invalidate();
            return true;
        }

        protected override void OnDraw(Canvas canvas)
        {
            base.OnDraw(canvas);
            //Set attributes canvas
            paint.SetStyle(Paint.Style.Fill);
            paint.Color = Color.Red;
            canvas.DrawPaint(paint);
            // Draw Stroke
            paint.SetStyle(Paint.Style.Stroke);
            paint.StrokeCap = Paint.Cap.Round;
            paint.StrokeJoin = Paint.Join.Round;

            //Draw the completed polynes
            foreach(PolygonLine line in completedPolygonLine)
            {
                paint.Color = Color.Red;
                paint.StrokeWidth = 400;
                canvas.DrawPath(line.Path, paint);
            }

            //Draw the in-progress polynes
            foreach (PolygonLine line in inProgressPolygoneLine.Values)
            {
                paint.Color = Color.Red;
                paint.StrokeWidth = 400;
                canvas.DrawPath(line.Path, paint);
            }

        }

    }
}
