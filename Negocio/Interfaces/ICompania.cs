using Datos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Interfaces
{
    interface ICompania
    {

        List<DtoCompania> cargarCompanias();

    }
}
