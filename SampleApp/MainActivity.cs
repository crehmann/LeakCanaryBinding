using Android.App;
using Android.OS;
using System.Threading;
using System.Threading.Tasks;

namespace SampleApp
{
    [Activity(Label = "SampleApp", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected MainActivity(System.IntPtr javaReference, Android.Runtime.JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public MainActivity() : base()
        {
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);
            var button = FindViewById(Resource.Id.async_task);
            button.Click += async (sender, e) => await Task.Factory.StartNew(() => Thread.Sleep(5000)).ConfigureAwait(false);
        }
    }
}

