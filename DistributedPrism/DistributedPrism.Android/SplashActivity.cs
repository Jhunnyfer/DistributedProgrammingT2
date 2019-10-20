using Android.App;
using Android.OS;
using DistributedPrism.Droid;

namespace DistributedPrism.Prism.Droid
{
    [Activity(
        Theme = "@style/Theme.Splash",
        MainLauncher = true,
        NoHistory = true)]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            System.Threading.Thread.Sleep(1800); //TODO: Set 1800
            StartActivity(typeof(MainActivity));
        }
    }
}
