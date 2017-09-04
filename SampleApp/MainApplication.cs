using Android.App;
using Android.Runtime;
using Square.LeakCanary;
using System;

namespace SampleApp
{
    [Application]
    internal class MainApplication : Application
    {
        private RefWatcher _refWatcher;

        protected MainApplication(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();
            SetupLeakCanary();
        }

        protected void SetupLeakCanary()
        {
            if (LeakCanaryXamarin.IsInAnalyzerProcess(this))
            {
                return;
            }
            _refWatcher = LeakCanaryXamarin.Install(this);
        }
    }
}