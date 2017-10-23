using System.Collections.Generic;
using Android.Views;
using Android.Widget;
using Android.App;

namespace BottomTabTeste
{
    public class CustomAdapter : BaseAdapter<Player>
    {
        //Não me pergunte pq troquei de tipo Activity pra tipo Context, mas comigo funciona assim ahsuhas, lembra de mandar um context e não uma activity quando for chamar o Adapter, se chamar ele fora do OnCreate cria uma variavel Context e iguala ela a this dentro do OnCreate pq acho que o this só funciona dentro dele, mas não sei afirmar
        private readonly Activity context;
        private readonly List<Player> players;
        public CustomAdapter(Activity context, List<Player> players)
        {
            this.context = context;
            this.players = players;
        }
        public override Player this[int position]
        {
            get
            {
                return players[position];
            }

        }
        public override int Count
        {
            get
            {
                return players.Count;
            }
        }
        public override long GetItemId(int position)
        {
            return players[position].Id;
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var inflate = LayoutInflater.From(context); //aqui passa o contexto de onde vai ser mostrado, o context é aquela variável lá
            var view = inflate.Inflate(Resource.Layout.model, parent, false); //aqui ele infla o layout e view recebe ele
            //var view = convertView ?? context.LayoutInflater.Inflate(Resource.Layout.model, parent, false); //comentei esse pq tava dando uma exceção bem nessa linha
            var Img = view.FindViewById<ImageView>(Resource.Id.playerImg);
            var NameTxt = view.FindViewById<TextView>(Resource.Id.nameTxt);
            var FuncTxt = view.FindViewById<TextView>(Resource.Id.funcTxt);
            var Check = view.FindViewById<ImageView>(Resource.Id.checkImg);
            NameTxt.Text = players[position].Name;
            FuncTxt.Text = players[position].Func;
            Img.SetImageResource(players[position].Image);
            Check.SetImageResource(players[position].Check);



            return view;
        }
    }
}