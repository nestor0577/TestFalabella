using Datos.Dto;
using Datos.Entidades;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.EnterpriseServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Conn
{
    public class ConnCliente
    {

        [AutoComplete(true)]
        public decimal adicionar(DtoCliente objCliente)
        {

            DbCommand _cmd;
            Database _dbConn;

            try
            {
                decimal res = 0;

                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                _dbConn = factory.Create("testBD");

                _cmd = _dbConn.GetStoredProcCommand("dbo.SP_CREAR_CLIENTE");
                _dbConn.AddInParameter(_cmd, "@Nombres", DbType.String, objCliente.Nombres);
                _dbConn.AddInParameter(_cmd, "@Movil", DbType.String, objCliente.Movil);
                _dbConn.AddInParameter(_cmd, "@Edad", DbType.String, objCliente.Edad);
                _dbConn.AddInParameter(_cmd, "@Direccion", DbType.String, objCliente.Direccion);
                _dbConn.AddOutParameter(_cmd, "@Identity", DbType.Int32, 0);
                _dbConn.ExecuteNonQuery(_cmd);

                res = Convert.ToDecimal(_dbConn.GetParameterValue(_cmd, "@Identity"));
                _cmd.Dispose();

                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public decimal adicionarClienteProducto(DtoCliente objCliente, DtoProducto objProducto)
        {

            DbCommand _cmd;
            Database _dbConn;

            try
            {
                decimal res = 0;

                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                _dbConn = factory.Create("testBD");

                _cmd = _dbConn.GetStoredProcCommand("dbo.SP_CREAR_CLIENTE_PRODUCTO");
                _dbConn.AddInParameter(_cmd, "@IdCliente", DbType.String, objCliente.IdCliente);
                _dbConn.AddInParameter(_cmd, "@IdProducto", DbType.String, objProducto.IdProducto);
                _dbConn.ExecuteNonQuery(_cmd);

                _cmd.Dispose();

                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
