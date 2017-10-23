using System;

using Android.App;
using Android.OS;
using Android.Widget;
using Android.Content;
using BottomTabTeste.Classes;
using BottomTabTeste.Fragments;

namespace BottomTabTeste
{

    [Activity(Label = "Class Pad", Theme = "@style/MyTheme", Icon = "@drawable/Icon")]
    public class ActivityLogin : Activity
    {
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            ISharedPreferences dadosLocais = GetSharedPreferences("arquivo1", Android.Content.FileCreationMode.WorldWriteable);
            var conferelogin = dadosLocais.GetString("login1", "sim");
            var numero1 = dadosLocais.GetString("numero", "");
            var ra1 = dadosLocais.GetString("ra", "");
            var nascimento1 = dadosLocais.GetString("nascimento", "");
            if (dadosLocais.Contains("sim"))
            {
                base.OnCreate(savedInstanceState);
                SetContentView(Resource.Layout.Login);
                StartActivity(typeof(MainActivity));
                Finish();
            }
            else
            {

                var context = this.ApplicationContext;
                var isOnline = NetworkConnection.IsNetworkConnected(context);
                if (isOnline)
                {
                    DBConnect.Conecta_Banco(this);
                    Toast.MakeText(this, "Conectado com sucesso!", ToastLength.Short).Show();
                }
                else
                {
                    AlertDialog.Builder dialog = new AlertDialog.Builder(this);
                    AlertDialog alert = dialog.Create();
                    alert.SetTitle("Status da Conexão");
                    alert.SetMessage("Falha na conexão, cheque sua conexão por favor!");
                    alert.SetButton("OK", (c, ev) =>
                    {
                        Finish();
                    });
                    alert.Show();

                }


                base.OnCreate(savedInstanceState);


                SetContentView(Resource.Layout.Login);
                Button button = FindViewById<Button>(Resource.Id.buttonLogin);
                button.Click += Button_Click;

                EditText login = FindViewById<EditText>(Resource.Id.editTextLogin);

            EditText ra = FindViewById<EditText>(Resource.Id.editTextLogin1);

            EditText nascimento = FindViewById<EditText>(Resource.Id.editTextLogin2);
                nascimento.AddTextChangedListener(new Mask(nascimento,"##/##/####"));
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            var contexto =  Application.Context;
            EditText login = FindViewById<EditText>(Resource.Id.editTextLogin);
            EditText ra = FindViewById<EditText>(Resource.Id.editTextLogin1);
            EditText nascimento = FindViewById<EditText>(Resource.Id.editTextLogin2);
            string resultado = DBConnect.GetText(login.Text, contexto);
            if (resultado != null)
            {
                ISharedPreferences dadosLocais = GetSharedPreferences("arquivo1", FileCreationMode.Private);
                ISharedPreferencesEditor editor = dadosLocais.Edit();
                editor.PutString("login1","sim");
                editor.PutString("numero", login.Text);
                editor.PutString("ra", ra.Text);
                editor.PutString("nascimento", nascimento.Text);
                editor.Commit();
                StartActivity(typeof(MainActivity));
            }
            else {
                AlertDialog.Builder dialog = new AlertDialog.Builder(this);
                AlertDialog alert = dialog.Create();
                alert.SetTitle("Falha no Login");
                alert.SetMessage("Usuário não encontrado! Contate a escola para resolver o problema!");
                alert.SetButton("OK", (c, ev) =>
                {

                });
                alert.Show();
            }
    
        }
    }
}