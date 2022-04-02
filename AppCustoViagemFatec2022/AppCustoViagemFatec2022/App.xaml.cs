using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppCustoViagemFatec2022.Views;
using AppCustoViagemFatec2022.Models;
using System.Collections.Generic;

namespace AppCustoViagemFatec2022
{
    public partial class App : Application
    {
        public List<Pedagio> ListaPedagios = new List<Pedagio>();

        public App()
        {
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
