using EccobankAdmin.Conexiones;
using EccobankAdmin.Modelo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database.Query;
using System.Linq;

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
        public async Task<List<MRecolectores>> Buscarrecolectores(MRecolectores parametrosPedir)
        {
            return (await Constantes.firebase
                .Child("Recolectores")
                .OrderByKey()
                .OnceAsync<MRecolectores>())
                .Where(a => a.Object.Identificacion == parametrosPedir.Identificacion)
                .Where(b => b.Object.Estado == "Activo")
                .Select(item => new MRecolectores
                {
                    Idrecolectores=item.Key,
                    Nombre=item.Object.Nombre
                }).ToList();
        }
    }
}
