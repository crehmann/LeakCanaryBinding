using Android.App;
using Android.OS;
using Android.Widget;

namespace SampleApp
{
    [Activity(Label = "LeakingActivity")]
    public class LeakingActivity : Activity
    {
        private TextView _textView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.LeakingActivity);
            _textView = FindViewById<TextView>(Resource.Id.textView);
        }

        protected override void OnDestroy()
        {
            // Dispose all disposable members
            //_textView.Dispose();

            base.OnDestroy();
            
            // Dispose the activity itself
            //Dispose();
        }
    }
}