using EccobankAdmin.Vistas;
using EccobankAdmin.Vistas.Config;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EccobankAdmin
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Menuprincipal();
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
