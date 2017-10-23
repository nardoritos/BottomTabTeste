using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using Android.Support.V7.App;
using Android.Support.Design.Widget;
using static Android.App.ActivityManager;
using Android.Graphics;
using BottomTabTeste.Fragments;

namespace BottomTabTeste
{
    [Activity(Label = "Class Pad",Theme ="@style/MyTheme", Icon = "@drawable/Icon")]
    public class MainActivity : AppCompatActivity
    {
        BottomNavigationView bottomNavigation;
        public string anima;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            DBConnect.Conecta_Banco(this);
            Bitmap bm = BitmapFactory.DecodeResource(Resources, Resource.Drawable.Icon);
            TaskDescription tDesc = new TaskDescription("Class Pad", bm, Color.Rgb(141, 195, 239));
            SetTaskDescription(tDesc);
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);

            var toolbar = FindViewById<Toolbar>(Resource.Id.sstoolbar);
            
            SetActionBar(toolbar);
            
            ActionBar.SetIcon(Resource.Drawable.portinari);
            toolbar.SetTitleTextColor(Color.Rgb(140, 118, 123));
            toolbar.InflateMenu(Resource.Menu.home);
            

            bottomNavigation = FindViewById<BottomNavigationView>(Resource.Id.bottom_navigation);
            BottomNavigationViewHelper.SetShiftMode(bottomNavigation, false, false);

            bottomNavigation.NavigationItemSelected += BottomNavigation_NavigationItemSelected;
            LoadFragment(Resource.Id.action_add);



        }
        private void BottomNavigation_NavigationItemSelected(object sender, BottomNavigationView.NavigationItemSelectedEventArgs e)
        {
            LoadFragment(e.Item.ItemId);
        }

        void LoadFragment(int id)
        {
            Fragment fragment = null;
            switch (id)
            {
                case Resource.Id.action_add:
                    fragment = Fragment1.NewInstance();
                    break;
                case Resource.Id.action_edit:
                    fragment = Fragment2.NewInstance();
                    break;
                case Resource.Id.action_remove:
                    fragment = Fragment3.NewInstance();
                    break;
                case Resource.Id.action_select:
                    fragment = Fragment4.NewInstance();
                    break;
                case Resource.Id.action_batata:
                    fragment = Fragment5.NewInstance();
                    break;
            }
            if (fragment == null)
                return;
            else {
                
                FragmentManager.BeginTransaction()
                   .Replace(Resource.Id.content_frame, fragment)
                   .AddToBackStack(fragment.Tag)
                   .Commit();
            }

        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.TitleFormatted.ToString() == "Sair") {
                Finish();
            }
           
            return base.OnOptionsItemSelected(item);
        }

        //Animações

    }
}

