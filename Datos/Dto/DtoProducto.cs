using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Entidades
{
    public class DtoProducto
    {

        private int _IdProducto;

        private  string _NombreProducto;

        private string _DescripcionProducto;

        private  int _IdCompania;

        public int IdProducto { get => _IdProducto; set => _IdProducto = value; }
        public string NombreProducto { get => _NombreProducto; set => _NombreProducto = value; }
        public string DescripcionProducto { get => _DescripcionProducto; set => _DescripcionProducto = value; }
        public int IdCompania { get => _IdCompania; set => _IdCompania = value; }
    }
}
