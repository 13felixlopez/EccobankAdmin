using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using EccobankAdmin.VistaModelo;

namespace EccobankAdmin.Vistas.Config
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Menuconfig : ContentPage
    {
        public Menuconfig()
        {
            InitializeComponent();
            BindingContext = new VMmenuconfig(Navigation);
        }
    }
}