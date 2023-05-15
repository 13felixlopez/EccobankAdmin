using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Threading.Tasks;
using EccobankAdmin.Datos;
using EccobankAdmin.Modelo;

namespace EccobankAdmin.VistaModelo
{
    public class VMasignaciones : BaseViewModel
    {
        #region VARIABLES
        string idrecolector;
        public static string idsolicitud;
        string txtidentificacion;
        string txtnombreRecolector;
        #endregion
        #region CONSTRUCTOR
        public VMasignaciones(INavigation navigation)
        {
            Navigation = navigation;
            Insertarcomamd = new Command(async () => await Insertarasignaciones());
            volvercomamd = new Command(async () => await volver());
            buscarcomamd = new Command(async () => await Buscarrecolectores());
        }
        #endregion
        #region OBJETOS 
        public string Idrecolector
        {
            get { return idrecolector; }
            set { SetValue(ref idrecolector, value); }
        }
        public string Txtidentificacion
        {
            get { return txtidentificacion; }
            set { SetValue(ref txtidentificacion, value); }
        }
        public string TxtnombreRecolector
        {
            get { return txtnombreRecolector; }
            set { SetValue(ref txtnombreRecolector, value); }
        }

        #endregion
        #region PROCESOS
        private async Task Insertarasignaciones()
        {
            if (!string.IsNullOrEmpty(Txtidentificacion))
            {
                var funcion = new Dasignaciones();
                var parametros = new Masignaciones();
                parametros.Estado = "Pendiente";
                parametros.IdRecolector = Idrecolector;
                parametros.IdSolicitud = idsolicitud;
                var estadofuncion = await funcion.Insertar(parametros);
                if (estadofuncion == true)
                {
                    await DisplayAlert("Registrado", "Registro realizado", "OK");
                }
            }
            else
            {
                await DisplayAlert("Sin datos", "Asigne un recolector", "OK");
            }

        }
        private async Task volver()
        {
            await Navigation.PopAsync();
        }
        private async Task Buscarrecolectores()
        {
            var funcion = new DRecolectores();
            var parametros = new MRecolectores();
            parametros.Identificacion = Txtidentificacion;
            var lista = await funcion.Buscarrecolectores(parametros);
            foreach (var data in lista)
            {
                TxtnombreRecolector = data.Nombre;
                Idrecolector = data.Idrecolectores;
            }
        }
        #endregion
        #region COMANDOS
        public Command Insertarcomamd { get; }
        public Command volvercomamd { get; }
        public Command buscarcomamd { get; }
        #endregion
    }
}
