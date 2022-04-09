using AppCustoViagemFatec2022.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCustoViagemFatec2022.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FormPedagio : ContentPage
    {
        App DadosApp;

        public FormPedagio()
        {
            DadosApp = (App) Application.Current;
            
            InitializeComponent();
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            try
            {
                Navigation.PushAsync(new ListaPedagios());
            } catch (Exception ex)
            {
                DisplayAlert("Ops", ex.Message, "OK");
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                Pedagio p = new Pedagio();
                p.Id = DadosApp.ListaPedagios.Count + 1;
                p.Local = txt_local.Text;
                p.Valor = Convert.ToDouble(txt_valor.Text);

                DadosApp.ListaPedagios.Add(p);

                DisplayAlert("Adicionado!", "Pedágio computado", "OK");
                txt_local.Text = "";
                txt_valor.Text = "";

            }catch (Exception ex)
            {
                DisplayAlert("Ops", ex.Message, "OK");
            }
        }

        private void Button_Clicked_Calcular(object sender, EventArgs e)
        {
            string origem = txt_origem.Text;
            string destino = txt_destino.Text;

            double distancia = Convert.ToDouble(txt_distancia.Text);
            double consumo = Convert.ToDouble(txt_consumo.Text);
            double preco = Convert.ToDouble(txt_preco.Text);

            double pedagios = DadosApp.ListaPedagios.Sum(i => i.Valor);

            double custo = pedagios + ( (distancia / consumo) * preco );          

            string msg = string.Format("O consumo entre {0} e {1} é de {2} Pedágios {3}",
                                        origem,
                                        destino,
                                        custo.ToString("C"),
                                        pedagios.ToString("C")
                                      );

           // string teste = $"O consumo entre {origem} e {destino} é de {custo}";

            DisplayAlert("CUSTO VIAGEM", msg, "OK");

        }

        private void Button_Clicked_Limpar(object sender, EventArgs e)
        {
            txt_origem.Text = "";
            txt_destino.Text = "";
            txt_consumo.Text = "";
            txt_distancia.Text = "";
            txt_local.Text = "";
            txt_preco.Text = "";
            txt_valor.Text = "";
        }
    }
}