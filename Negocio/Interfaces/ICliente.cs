using Datos.Dto;
using Datos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Interfaces
{
    interface ICliente
    {
        decimal crear(DtoCliente objCl, DtoProducto objPr);

        void agregarUsuarioxProducto(DtoCliente objCl, DtoProducto objPr);

    }
}
