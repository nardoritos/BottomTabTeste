using Android.OS;
using Android.Views;
using Android.Widget;
using System;
using Android.App;
using BottomTabTeste.ListViewMacoratti;

namespace BottomTabTeste.Fragments
{
    public class Fragment1 : Fragment
    {
        public int id;
        public View row;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

               
        }

        public static Fragment1 NewInstance()
        {
            var frag1 = new Fragment1 { Arguments = new Bundle() };
            return frag1;
        }


        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            inflater = LayoutInflater.From(this.Context);
            View view = inflater.Inflate(Resource.Layout.fragment1, null);
            var msgListView = view.FindViewById<ListView>(Resource.Id.lv);
            msgListView.FastScrollEnabled = true;
            msgListView.ItemClick += Lv_ItemClick;
            var msgAdapter = new CustomAdapter(this.Activity, Holder.player);
            msgListView.Adapter = msgAdapter;
            return view;
            

        }

        private void Lv_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Fragment fragment = null;
            fragment = FragMessage.NewInstance();
            FragMessage.idmsg = Holder.player[e.Position].Id;
            FragMessage.titulomsg = Holder.player[e.Position].Name;
            FragMessage.textomsg = Holder.player[e.Position].Func;
            FragmentManager.BeginTransaction()
                .Replace(Resource.Id.content_frame, fragment)
                .AddToBackStack(fragment.Tag)
                .Commit();


            Toast.MakeText(Context, Holder.player[e.Position].Id + " | " + Holder.player[e.Position].Name + ": " + Holder.player[e.Position].Func, ToastLength.Short).Show();
        }



        public static string RandomDay(){
            Random gen = new Random();
            DateTime start = new DateTime(2017, 1, 1);
            int range = (DateTime.Today - start).Days;
            DateTime start1 = new DateTime(24);
            int range1 = (DateTime.Now - start1).Hours; 
           

            var get = start.AddDays(gen.Next(range));
            var replaceget = get.ToString();
            var replacedget = replaceget.Replace("00:00:00", "");

            var get1 = start1.AddHours(gen.Next(range1));
            var replaceget1 = get1.ToString();
            var replacedget1 = replaceget1.Replace("01/01/0001", "");
            replaceget1.Replace(":00:00", "");
            return replacedget + replacedget1 ;
        }
        
    }
}