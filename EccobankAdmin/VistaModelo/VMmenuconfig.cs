using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Threading.Tasks;
using EccobankAdmin.Vistas;
using EccobankAdmin.Vistas.Config;

namespace EccobankAdmin.VistaModelo
{
   public class VMmenuconfig:BaseViewModel
    {
        #region VARIABLES
        string identificacion;
        #endregion
        #region CONSTRUCTOR
        public VMmenuconfig(INavigation navigation)
        {
            Navigation = navigation;
            Volvercomamd = new Command(async () => await volver());
            NavegarRecolectoresconfigcomamd = new Command(async () => await NavegarRecolectoresconfig());
            NavegarProductosconfigcomamd = new Command(async () => await NavegarProductosconfig());
        }
        #endregion
        #region OBJETOS 
        public string Identificacion
        {
            get { return identificacion; }
            set { SetValue(ref identificacion, value); }
        }

        #endregion
        #region PROCESOS
        private async Task volver()
        {
            await Navigation.PopAsync();
        }
        private async Task NavegarRecolectoresconfig()
        {
            await Navigation.PushAsync(new Recolectoresconfig());
        } 
        private async Task NavegarProductosconfig()
        {
            await Navigation.PushAsync(new Productosconfig());
        }
        #endregion
        #region COMANDOS
        public Command Volvercomamd { get; }
        public Command NavegarRecolectoresconfigcomamd { get; }
        public Command NavegarProductosconfigcomamd { get; }
        #endregion
    }
}
