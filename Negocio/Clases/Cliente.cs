using Datos.Conn;
using Datos.Dto;
using Datos.Entidades;
using Negocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Clases
{
    public class Cliente : ICliente
    {
        public void agregarUsuarioxProducto(DtoCliente objCl, DtoProducto objPr)
        {
            try
            {
                ConnCliente cdCliente = new ConnCliente();

                 cdCliente.adicionarClienteProducto(objCl, objPr);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public decimal crear(DtoCliente objCliente, DtoProducto objProducto)
        {
            try
            {
                ConnCliente cdCliente = new ConnCliente();
                decimal resAction = 0;

                resAction = cdCliente.adicionar(objCliente);

                if (resAction > 0)
                {
                    objCliente.IdCliente = (int)resAction;
                    agregarUsuarioxProducto(objCliente, objProducto);
                }


                return resAction;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
