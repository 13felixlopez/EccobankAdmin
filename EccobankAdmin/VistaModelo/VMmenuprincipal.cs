using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using EccobankAdmin.Vistas.Config;
using EccobankAdmin.Vistas;
using EccobankAdmin.Datos;
using EccobankAdmin.Modelo;

namespace EccobankAdmin.VistaModelo
{
    class VMmenuprincipal:BaseViewModel
    {
        #region VARIABLES
        string identificacion;
        List<Msolicitudesrecojo> listasolRecojo;
        #endregion
        #region CONSTRUCTOR
        public VMmenuprincipal(INavigation navigation)
        {
            Navigation = navigation;
            Navegarmenuconfigcomamd = new Command(async () => await NavegarMenuconfig());
            Navegarasignacionesgcomamd = new Command<Msolicitudesrecojo>(async (f) => await NavegarAsignaciones(f));

           Mostrarsolicitudesrecojo();
        }
        #endregion
        #region OBJETOS 
        public List<Msolicitudesrecojo> ListasolRecojo
        {
            get { return listasolRecojo; }
            set { SetValue(ref listasolRecojo, value); }
        }
        public string Identificacion
        {
            get { return identificacion; }
            set { SetValue(ref identificacion, value); }
        }

        #endregion
        #region PROCESOS
        private async Task NavegarMenuconfig()
        {
            await Navigation.PushAsync(new Menuconfig());
        }
        private async Task NavegarAsignaciones(Msolicitudesrecojo parametros)
        {
            string Idsolicitud = parametros.Idsolicitud;
            VMasignaciones.idsolicitud = Idsolicitud;
            await Navigation.PushAsync(new Asignaciones());
        }
        private async Task Mostrarsolicitudesrecojo()
        {
            var funcion = new Dsolicitudesrecojo();
            ListasolRecojo = await funcion.Mostrarsolicitudesrecojo();
        }
        #endregion
        #region Comandos
        public Command Navegarmenuconfigcomamd { get; }
        public Command Navegarasignacionesgcomamd { get; }

        #endregion
    }
}
