using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Threading.Tasks;
using EccobankAdmin.Datos;
using EccobankAdmin.Modelo;
using Firebase.Auth;
using EccobankAdmin.Conexiones;

namespace EccobankAdmin.VistaModelo
{
    public class VMRecolectoresconfig:BaseViewModel
    {
        #region VARIABLES
        string txtnombre;
        string txtcorreo;
        string txtidentificacion;
        string txtcontraseña;
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
        public string Txtcontraseña
        {
            get { return txtcontraseña; }
            set { SetValue(ref txtcontraseña, value); }
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
            if (string.IsNullOrEmpty(Txtnombre) & string.IsNullOrEmpty(Txtidentificacion) & string.IsNullOrEmpty(Txtcorreo) & string.IsNullOrEmpty(Txtcontraseña))
            {
                await DisplayAlert("ERROR", "Tiene campos vacios", "OK");
            }
            else
            {
                var estadofuncion = await funcion.InsertarRecolectores(parametros);
                if (estadofuncion == true)
                {
                    await CrearCorreo(txtcorreo, txtcontraseña);
                }
            }

        }
        private async Task Volver()
        {
            await Navigation.PopAsync();
        }
        private async Task CrearCorreo(string correo, string contraseña)
        {
            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(Constantes.webapiFirebase));
            await authProvider.CreateUserWithEmailAndPasswordAsync(correo, contraseña);
            await DisplayAlert("Estado", "Registro realizado", "OK");
            limpiar();
        }

        private void limpiar()
        {
            Txtnombre = "";
            Txtidentificacion = "";
            Txtcorreo = "";
            Txtcontraseña = "";
        }
        #endregion
        #region COMANDOS
        public Command Insertarcomamd { get; }
        public Command Volvercomamd { get; }
        #endregion
    }
}
