using Datos.Conn;
using Datos.Entidades;
using Negocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Clases
{
    public class Compania : ICompania
    {
        public List<DtoCompania> cargarCompanias()
        {

            ConnCompania cCompania = new ConnCompania();
            List<DtoCompania> ltComapnia = new List<DtoCompania>();

            try
            {
                ltComapnia = cCompania.obtenerCompanias();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ltComapnia;
        }
    }
}
