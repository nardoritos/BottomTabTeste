using System.Collections.Generic;
using Android.App;
using Android.Views;
using Android.Widget;

namespace BottomTabTeste.ListViewMacoratti
{
    public class FilmeAdapter : BaseAdapter<Filme>
    {
        private readonly Activity context;
        private readonly List<Filme> filmes;
        public FilmeAdapter(Activity context, List<Filme> filmes)
        {
            this.context = context;
            this.filmes = filmes;
        }
        public override Filme this[int position]
        {
            get
            {
                return filmes[position];
            }
        }
        public override int Count
        {
            get
            {
                return filmes.Count;
            }
        }
        public override long GetItemId(int position)
        {
            return filmes[position].Id;
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? context.LayoutInflater.Inflate(Resource.Layout.Filmes, parent, false);

            var txtTitulo = view.FindViewById<TextView>(Resource.Id.tituloTextView);
            var txtDiretor = view.FindViewById<TextView>(Resource.Id.diretorTextView);
            var txtLancamento = view.FindViewById<TextView>(Resource.Id.dataLancamentoTextView);
            txtTitulo.Text = filmes[position].Titulo;
            txtDiretor.Text = "Dirigido por: " + filmes[position].Diretor;
            txtLancamento.Text = "Lançado em : " + filmes[position].DataLancamento.ToShortDateString();
            return view;
        }
    }
}