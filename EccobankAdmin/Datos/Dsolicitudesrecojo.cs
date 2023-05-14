using EccobankAdmin.Conexiones;
using EccobankAdmin.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EccobankAdmin.Datos
{
    public class Dsolicitudesrecojo
    {
        public async Task <List<Msolicitudesrecojo>> Mostrarsolicitudesrecojo()
        {
            return (await Constantes.firebase
                .Child("Solicitudes")
                .OnceAsync<Msolicitudesrecojo>())
                .Select(item => new Msolicitudesrecojo
                {
                    Estado=item.Object.Estado,
                    Fecha=item.Object.Fecha,
                    Idsolicitud=item.Key
                }).ToList();
        }
    }
}
