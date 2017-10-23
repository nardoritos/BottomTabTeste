using Android.OS;
using Android.Views;
using Android.Widget;
using System;
using Android.App;
namespace BottomTabTeste.Fragments
{
    public class FragMessage : Fragment
    {
        public static int idmsg { get; set; }
        public static string titulomsg { get; set; }
        public static string textomsg { get; set; }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }
        public static FragMessage NewInstance()
        {
            var fragmsg = new FragMessage { Arguments = new Bundle() };

            return fragmsg;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.fragmsg, null);
            TextView titulo = view.FindViewById<TextView>(Resource.Id.TituloMsg);
            titulo.Text = titulomsg;
            TextView texto = view.FindViewById<TextView>(Resource.Id.ConteudoMsg);
            texto.Text = textomsg;
            return view;
        }

    }
}