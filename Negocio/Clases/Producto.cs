using System;
using System.Collections.Generic;
using Datos.Conn;
using Datos.Entidades;
using Negocio.Interfaces;

namespace Negocio.Clases
{
    public class Producto : IProducto
    {

        public decimal crear(DtoProducto obj)
        {
            try
            {
                ConnProducto cdProducto = new ConnProducto();
                decimal resAction = 0;

                resAction = cdProducto.adicionar(obj);

                return resAction;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<DtoProducto> obtenerProductosxCompania(int idCompania)
        {
            try
            {
                List<DtoProducto> ltProducto = new List<DtoProducto>();
                ConnProducto cdProducto = new ConnProducto();

                ltProducto = cdProducto.obtenerProductosxCompania(idCompania);

                return ltProducto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
