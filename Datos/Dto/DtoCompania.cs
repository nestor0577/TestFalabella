using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Entidades
{
    public class DtoCompania
    {

        private int _IdCompania;

        private string _NombreCompania;

        private bool _Estado;

        public int IdCompania { get => _IdCompania; set => _IdCompania = value; }
        public string NombreCompania { get => _NombreCompania; set => _NombreCompania = value; }
        public bool Estado { get => _Estado; set => _Estado = value; }
    }
}
