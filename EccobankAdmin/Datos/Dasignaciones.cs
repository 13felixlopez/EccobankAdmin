using EccobankAdmin.Conexiones;
using EccobankAdmin.Modelo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database.Query;
using EccobankAdmin.VistaModelo;

namespace EccobankAdmin.Datos
{
    public class Dasignaciones
    {
        public async Task<bool> Insertar(Masignaciones parametros)
        {
            await Constantes.firebase
                .Child("Asignaciones")
                .PostAsync(new Masignaciones()
                {
                    IdSolicitud = parametros.IdSolicitud,
                    Estado = parametros.Estado,
                    IdRecolector = parametros.IdRecolector
                });
            return true;
        }
    }
}
