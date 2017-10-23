using Android.OS;
using Android.Views;
using Android.Widget;
using System;
using Android.App;
using Android.Content;

namespace BottomTabTeste.Fragments
{
    public class Fragment5 : Fragment
    {
        public static string tel;
        public static string ra;
        public static string nasc;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public static Fragment5 NewInstance()
        {
            var frag5 = new Fragment5 { Arguments = new Bundle() };
            return frag5;
        }


        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.fragment5, null);

            ISharedPreferences dadosLocais = Application.Context.GetSharedPreferences("arquivo1", Android.Content.FileCreationMode.WorldWriteable);
            var numero1 = dadosLocais.GetString("numero", null);
            var ra1 = dadosLocais.GetString("ra", null);
            var nascimento1 = dadosLocais.GetString("nascimento", null);
            var conferelogin = dadosLocais.GetString("login1", "sim");

            TextView textotel = view.FindViewById<TextView>(Resource.Id.textViewNUM);
            textotel.Text = conferelogin;
            TextView textora = view.FindViewById<TextView>(Resource.Id.textViewRA);
            textora.Text = ra1;
            TextView textonasc = view.FindViewById<TextView>(Resource.Id.textViewNASC);
            textonasc.Text = nascimento1;
            return inflater.Inflate(Resource.Layout.fragment5, null);
        }
    }
}