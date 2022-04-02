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

            }catch (Exception ex)
            {
                DisplayAlert("Ops", ex.Message, "OK");
            }
        }
    }
}