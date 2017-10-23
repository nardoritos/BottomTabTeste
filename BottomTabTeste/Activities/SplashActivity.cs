using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Util;

namespace BottomTabTeste
{
    [Activity(Label = "Class Pad", Theme = "@style/MyTheme.Splash", Icon = "@drawable/Icon", NoHistory = true, MainLauncher = true)]
    public class SplashActivity : AppCompatActivity
    {
        static readonly string TAG = "X:" + typeof(SplashActivity).Name;

        public override void OnCreate(Bundle savedInstanceState, PersistableBundle persistentState)
        {
            base.OnCreate(savedInstanceState, persistentState);
        }

        // Launches the startup task
        protected override void OnResume()
        {
            base.OnResume();
            Task startupWork = new Task(() => { SimulateStartup(); });
            startupWork.Start();
        }

        // Simulates background work that happens behind the splash screen
        async void SimulateStartup()
        {
            await Task.Delay(1500); // Simulate a bit of startup work.
            StartActivity(new Intent(Application.Context, typeof(ActivityLogin)));
        }
    }
}