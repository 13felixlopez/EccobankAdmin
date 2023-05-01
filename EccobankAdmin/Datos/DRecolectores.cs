using EccobankAdmin.Conexiones;
using EccobankAdmin.Modelo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database.Query;

namespace EccobankAdmin.Datos
{
    public class DRecolectores
    {
        public async Task <bool>InsertarRecolectores(MRecolectores parametros)
        {
            await Constantes.firebase
                .Child("Recolectores")
                .PostAsync(new MRecolectores()
                {
                    Correo=parametros.Correo,
                    Estado=parametros.Estado,
                    Identificacion=parametros.Identificacion,
                    Nombre=parametros.Nombre
                });
            return true;
        }
    }
}
