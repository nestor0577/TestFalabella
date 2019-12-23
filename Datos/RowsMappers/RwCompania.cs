using Datos.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.RowsMappers
{
    class RwCompania
    {

        public List<DtoCompania> rwCompania(IDataReader reader)
        {
            List<DtoCompania> ltCompania = new List<DtoCompania>();

            while (reader.Read())
            {
                DtoCompania objCompania = new DtoCompania();

                if (reader.GetInt32(0) != 0)
                {
                    objCompania.IdCompania = reader.GetInt32(0);
                }
                if (reader.GetString(1) != "")
                {
                    objCompania.NombreCompania = reader.GetString(1);
                }

                objCompania.Estado = reader.GetBoolean(2);


                ltCompania.Add(objCompania);
            }
            return ltCompania;
        }


    }
}
