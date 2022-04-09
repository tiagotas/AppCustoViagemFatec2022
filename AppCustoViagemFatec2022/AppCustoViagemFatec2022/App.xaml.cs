using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppCustoViagemFatec2022.Views;
using AppCustoViagemFatec2022.Models;
using System.Collections.Generic;
using System.Globalization;

namespace AppCustoViagemFatec2022
{
    public partial class App : Application
    {
        // DadosApp = (App) Application.Current;
        public List<Pedagio> ListaPedagios = new List<Pedagio>();

        public App()
        {
            CultureInfo.CurrentCulture = new CultureInfo("pt-BR");

            InitializeComponent();

            MainPage = new NavigationPage(new FormPedagio());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
