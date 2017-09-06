using Android.App;
using Android.OS;
using Android.Widget;
using System;

namespace SampleApp
{
    [Activity(Label = "SampleApp", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private Button _button;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);
            _button = FindViewById<Button>(Resource.Id.button);
            _button.Click += OnButtonClicked;
        }

        protected override void OnDestroy()
        {
            _button.Click -= OnButtonClicked;
            _button.Dispose();
            base.OnDestroy();
            Dispose();
        }

        private void OnButtonClicked(object sender, EventArgs e)
        {
            StartActivity(typeof(LeakingActivity));
        }
    }
}

