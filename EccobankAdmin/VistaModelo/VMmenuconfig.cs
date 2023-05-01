using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Threading.Tasks;
using EccobankAdmin.Vistas;

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
        #endregion
        #region COMANDOS
        public Command Volvercomamd { get; }
        #endregion
    }
}
