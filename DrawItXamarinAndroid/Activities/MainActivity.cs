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
        Button getBitmapBtn;
        ImageView testImageView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            InitViews();
            InitEventsViews();
        }
        void InitViews()
        {
            canvas = FindViewById<FingerPainCanvasView>(Resource.Id.canvas);
            canvas.SetBackground = Resource.Mipmap.Icon;
            clearAllBtn = FindViewById<Button>(Resource.Id.clearAllBtn);
            clearOnceBtn = FindViewById<Button>(Resource.Id.clearOnceBtn);
            getBitmapBtn = FindViewById<Button>(Resource.Id.getBitmapBtn);
            testImageView = FindViewById<ImageView>(Resource.Id.testImageView);
        }
        void InitEventsViews()
        {
            clearAllBtn.Click += (sender, e) => canvas.ClearAll();
            clearOnceBtn.Click += (sender, e) => canvas.ClearOnce();
            getBitmapBtn.Click += (sender, e) => {
                testImageView.SetImageBitmap(canvas.GetBitmap());
            };
        }
    }
}

