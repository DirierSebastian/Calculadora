using Calculadora.Vista;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Calculadora
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Calcular();
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
