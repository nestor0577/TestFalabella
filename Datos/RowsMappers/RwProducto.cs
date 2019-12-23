using Datos.Entidades;
using System;
using System.Collections.Generic;
using System.Data;

namespace Datos.RowsMappers
{
    public class RwProducto
    {

        public List<DtoProducto> rProducto(IDataReader reader)
        {
            List<DtoProducto> ltProducto = new List<DtoProducto>();

            while (reader.Read())
            {
                DtoProducto objProducto = new DtoProducto();

                if (reader.GetInt32(0) != 0)
                {
                    objProducto.IdProducto = reader.GetInt32(0);
                }
                if (reader.GetString(1) != "")
                {
                    objProducto.NombreProducto = reader.GetString(1);
                }
                if (reader.GetString(2) != "")
                {
                    objProducto.DescripcionProducto = reader.GetString(2);
                }
                if (reader.GetInt32(3) != 0)
                {
                    objProducto.IdCompania = reader.GetInt32(3);
                }

                ltProducto.Add(objProducto);
            }
                return ltProducto;
        }

    }
}
