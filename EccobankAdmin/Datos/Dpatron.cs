using EccobankAdmin.Conexiones;
using EccobankAdmin.Modelo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database.Query;

namespace EccobankAdmin.Datos
{
    public class Dpatron
    {
        public async Task<bool> Insertar(MRecolectores parametros)
        {
            await Constantes.firebase
                .Child("Tu tabla")
                .PostAsync(new MRecolectores()
                {
                    Correo = parametros.Correo,
                    Estado = parametros.Estado,
                    Identificacion = parametros.Identificacion,
                    Nombre = parametros.Nombre
                });
            return true;
        }
    }
}
