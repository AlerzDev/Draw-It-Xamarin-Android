using Android.App;
using Android.Widget;
using Android.OS;
using DrawItXamarinAndroid.CustomViews;

namespace DrawItXamarinAndroid
{
    [Activity(Label = "Draw It Xamarin Android", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        FingerPainCanvasView canvas;
        Button clearAllBtn;
        Button clearOnceBtn;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            canvas = FindViewById<FingerPainCanvasView>(Resource.Id.canvas);
            clearAllBtn = FindViewById<Button>(Resource.Id.clearAllBtn);
            clearOnceBtn = FindViewById<Button>(Resource.Id.clearOnceBtn);

            clearAllBtn.Click += (sender, e) => canvas.ClearAll();
            clearOnceBtn.Click += (sender, e) => canvas.ClearOnce();

        }
    }
}

