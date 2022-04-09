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
    public partial class ListaPedagios : ContentPage
    {
        App DadosApp;

        public ListaPedagios()
        {
            DadosApp = (App) Application.Current;

            InitializeComponent();

            lst_pedagios.ItemsSource = DadosApp.ListaPedagios;
        }

        private async void MenuItem_Clicked(object sender, EventArgs e)
        {
            MenuItem disparador = (MenuItem)sender;

            Pedagio pedagio_selecionado = (Pedagio)disparador.BindingContext;

            bool confirmacao = await DisplayAlert("Tem ctza?", "Remover Pedágio?", "Sim", "Não");

            if(confirmacao)
            {
                DadosApp.ListaPedagios.RemoveAll(i => i.Id == pedagio_selecionado.Id);

                lst_pedagios.ItemsSource = new List<Pedagio>();
                lst_pedagios.ItemsSource = DadosApp.ListaPedagios;
            }
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            double total_pedagios = DadosApp.ListaPedagios.Sum(i => i.Valor);

            string msg = "O valor total é " + total_pedagios.ToString("C");

            DisplayAlert("Valor Total", msg, "OK");
        }
    }
}