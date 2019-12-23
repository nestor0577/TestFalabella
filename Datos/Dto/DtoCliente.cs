using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Dto
{
    public class DtoCliente
    {

        private int _IdCliente;

        private string _Nombres;

        private string _Movil;

        private string _Edad;

        private string _Direccion;

        public int IdCliente { get => _IdCliente; set => _IdCliente = value; }
        public string Nombres { get => _Nombres; set => _Nombres = value; }
        public string Movil { get => _Movil; set => _Movil = value; }
        public string Edad { get => _Edad; set => _Edad = value; }
        public string Direccion { get => _Direccion; set => _Direccion = value; }
    }
}
