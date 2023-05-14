using EccobankAdmin.Conexiones;
using EccobankAdmin.Modelo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database.Query;

namespace EccobankAdmin.Datos
{
    public class Dproductos
    {
        public async Task<bool> InsertarProductos(Mproductos parametros)
        {
            await Constantes.firebase
                .Child("Productos")
                .PostAsync(new Mproductos()
                {
                    Estado = parametros.Estado,
                    PrecioCompra = parametros.PrecioCompra,
                    PrecioVenta = parametros.PrecioVenta,
                    Color = parametros.Color,
                    Und=parametros.Und,
                    Descripcion=parametros.Descripcion,
                    Icono=parametros.Icono
                });
            return true;
        }

    }
}
