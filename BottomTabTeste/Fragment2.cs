using Android.OS;
using Android.Views;
using Android.Widget;
using System;
using Android.App;
using BottomTabTeste.ListViewMacoratti;

namespace BottomTabTeste.Fragments
{
    public class Fragment2 : Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

     
        }

        private void FilmesListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            
            Toast.MakeText(this.Context, FilmesRepositorio.Filmes[e.Position].ToString(), ToastLength.Short).Show();
        }

        public static Fragment2 NewInstance()
        {
            var frag2 = new Fragment2 { Arguments = new Bundle() };
            return frag2;
        }


        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {

            View view = inflater.Inflate(Resource.Layout.fragment2, null);
            var filmesListView = view.FindViewById<ListView>(Resource.Id.filmeslistView);
            filmesListView.FastScrollEnabled = true;
            filmesListView.ItemClick += FilmesListView_ItemClick;
            var filmesAdapter = new FilmeAdapter(this.Activity, FilmesRepositorio.Filmes);
            filmesListView.Adapter = filmesAdapter;
            return view;
        }
    }
}