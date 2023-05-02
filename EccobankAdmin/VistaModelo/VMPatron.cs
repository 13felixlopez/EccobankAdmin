using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Threading.Tasks;
using EccobankAdmin.Datos;
using EccobankAdmin.Modelo;

namespace EccobankAdmin.VistaModelo
{
    class VMPatron:BaseViewModel
    {
        #region VARIABLES
        string identificacion;
        #endregion
        #region CONSTRUCTOR
        public VMPatron(INavigation navigation)
        {
            Navigation = navigation;
            Logincomamd = new Command(async () => await proceso());
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
        private async Task proceso()
        {

        }
        #endregion
        #region COMANDOS
        public Command Logincomamd { get; }
        #endregion
    }
}
