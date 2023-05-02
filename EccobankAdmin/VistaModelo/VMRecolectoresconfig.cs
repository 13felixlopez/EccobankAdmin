using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Threading.Tasks;
using EccobankAdmin.Datos;
using EccobankAdmin.Modelo;

namespace EccobankAdmin.VistaModelo
{
    public class VMRecolectoresconfig:BaseViewModel
    {
        #region VARIABLES
        string txtnombre;
        string txtcorreo;
        string txtidentificacion;
        #endregion
        #region CONSTRUCTOR
        public VMRecolectoresconfig(INavigation navigation)
        {
            Navigation = navigation;
            Insertarcomamd = new Command(async () => await InsertarRecolectores());
            Volvercomamd = new Command(async () => await Volver());
        }
        #endregion
        #region OBJETOS 
        public string Txtnombre
        {
            get { return txtnombre; }
            set { SetValue(ref txtnombre, value); }
        }

        public string Txtidentificacion
        {
            get { return txtidentificacion; }
            set { SetValue(ref txtidentificacion, value); }
        }
        public string Txtcorreo
        {
            get { return txtcorreo; }
            set { SetValue(ref txtcorreo, value); }
        }

        #endregion
        #region PROCESOS
        private async Task InsertarRecolectores()
        {
            var funcion = new DRecolectores();
            var parametros = new MRecolectores();
            parametros.Nombre = Txtnombre;
            parametros.Identificacion = Txtidentificacion;
            parametros.Correo = Txtcorreo;
            parametros.Estado = "Activo";
            var estadofuncion = await funcion.InsertarRecolectores(parametros);
            if (estadofuncion==true)
            {
                await DisplayAlert("Estado", "Registro realizado", "ok");
            }
        }
        private async Task Volver()
        {
            await Navigation.PopAsync();
        }
        #endregion
        #region COMANDOS
        public Command Insertarcomamd { get; }
        public Command Volvercomamd { get; }
        #endregion
    }
}
