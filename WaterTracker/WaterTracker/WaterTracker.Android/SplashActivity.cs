using Android.App;
using Android.Content;
using Android.OS;
using System.Threading.Tasks;

namespace WaterTracker.Droid
{
    [Activity(Theme = "@style/Theme.Splash", //Indicates the theme to use for this activity
            MainLauncher = true, //Set it as boot activity
            NoHistory = true)] //Doesn't place it in back stack
    public class SplashActivity : Activity
    {

        public override void OnCreate(Bundle savedInstanceState, PersistableBundle persistentState)
        {
            base.OnCreate(savedInstanceState, persistentState);
        }

        // Launches the startup task
        protected override void OnStart()
        {
            base.OnStart();
            //start a real main activity
            StartActivity(new Intent(Application.Context, typeof(MainActivity)));
        }
    }
}
