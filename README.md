[![nuget link](https://img.shields.io/badge/%20nuget-v.1.5.1.1-blue.svg?style=flat-square)](https://www.nuget.org/packages/LeakCanaryBinding/)




# LeakCanaryBinding
This is a Xamarin.Android Binding for the [Square.LeakCanary](https://github.com/square/leakcanary) library.
A memory leak detection library for Android and Java.

*“A small leak will sink a great ship.”* - Benjamin Franklin

![screenshot](https://raw.githubusercontent.com/crehmann/LeakCanaryBinding/master/assets/screenshot.png)

## Getting started

In your `Application` class:
```c#
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
                // This process is dedicated to LeakCanary for heap analysis.
                // You should not init your app in this process.
                return;
            }
            _refWatcher = LeakCanaryXamarin.Install(this);
        }
    }
```

**You're good to go!** LeakCanary will automatically show a notification when an activity memory leak is detected in your debug build.

Questions? Check out [the official LeakCanary FAQ](https://github.com/square/leakcanary/wiki/FAQ)!

## Customizing LeakCanary
To customize LeakCanary, see the [wiki of LeakCanary](https://github.com/square/leakcanary/wiki/Customizing-LeakCanary).

## LeakCanary Modifications for Xamarin
Unfortunately, there is a [bug](https://bugzilla.xamarin.com/show_bug.cgi?id=51940) in Xamarin.Android, which does not allow to have a custom `Application` class and a `Service` running within an isolated process. Therefore it was required to use a [modified version](https://github.com/crehmann/leakcanary/commit/7719f24f277691d2fc4224325f8ac9461d3a9cdb) of the LeakCanaray library for the binding to work.
