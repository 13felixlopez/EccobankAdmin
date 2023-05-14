using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Threading.Tasks;
using EccobankAdmin.Datos;
using EccobankAdmin.Modelo;

namespace EccobankAdmin.VistaModelo
{
    public class VMproductosconfig:BaseViewModel
    {
        #region VARIABLES
        public string descripcion,preciocompra,precioventa,unidadmedida,color,estado;
        #endregion
        #region CONSTRUCTOR
        public VMproductosconfig(INavigation navigation)
        {
            Navigation = navigation;
            Insertarcomamd = new Command(async () => await InsertarProductos());
            Volvercomamd = new Command(async () => await volver());
        }
        #endregion
        #region OBJETOS 
        public string Txtdescripcion
        {
            get { return descripcion; }
            set { SetValue(ref descripcion, value); }
        }
        public string Txtpreciocompra
        {
            get { return preciocompra; }
            set { SetValue(ref preciocompra, value); }
        }
        public string Txtprecioventa
        {
            get { return precioventa; }
            set { SetValue(ref precioventa, value); }
        }
        public string Txtunidadmedida
        {
            get { return unidadmedida; }
            set { SetValue(ref unidadmedida, value); }
        }
        public string Txtcolor
        {
            get { return color; }
            set { SetValue(ref color, value); }
        }
        public string Txtestado
        {
            get { return estado; }
            set { SetValue(ref estado, value); }
        }

        #endregion
        #region PROCESOS
        private async Task InsertarProductos()
        {
            var funcion = new Dproductos();
            var parametros = new Mproductos();
            parametros.Descripcion = Txtdescripcion;
            parametros.PrecioVenta = Txtprecioventa;
            parametros.PrecioCompra = Txtpreciocompra;
            parametros.Und = Txtunidadmedida;
            parametros.Color = Txtcolor;
            parametros.Icono = "-";
            parametros.Estado = "Activo";
            var estadofuncion = await funcion.InsertarProductos(parametros);
            if (estadofuncion==true)
            {
                await DisplayAlert("Registrado", "Registro realizado correctamente", "ok");
            }
        }
        private async Task volver()
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
