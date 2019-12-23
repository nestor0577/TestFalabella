using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.EnterpriseServices;
using Datos.RowsMappers;
using Datos.Entidades;

namespace Datos.Conn
{
    public class ConnProducto
    {

        [AutoComplete(true)]
        public decimal adicionar(DtoProducto objProducto)
        {

            DbCommand _cmd;
            Database _dbConn;

            try
            {
                decimal res = 0;

                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                _dbConn = factory.Create("testBD");

                _cmd = _dbConn.GetStoredProcCommand("dbo.SP_CREAR_PRODUCTO");
                _dbConn.AddInParameter(_cmd, "@NombreProducto", DbType.String, objProducto.NombreProducto);
                _dbConn.AddInParameter(_cmd, "@DescripcionProducto", DbType.String, objProducto.DescripcionProducto);
                _dbConn.AddInParameter(_cmd, "@IdCompania", DbType.Int32, objProducto.IdCompania);
                _dbConn.AddOutParameter(_cmd, "@Res", DbType.Int32, 0);
                _dbConn.ExecuteNonQuery(_cmd);

                res = Convert.ToDecimal(_dbConn.GetParameterValue(_cmd, "@Res"));
                _cmd.Dispose();

                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<DtoProducto> obtenerProductosxCompania(int idCompania)
        {
            DbCommand _cmd;
            Database _dbConn;

            try
            {
                List<DtoProducto> ltProducto = new List<DtoProducto>();
                RwProducto rwProducto = new RwProducto();

                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                _dbConn = factory.Create("testBD");

                _cmd = _dbConn.GetStoredProcCommand("dbo.SP_CONSULTAR_PRODUCTO");
                _dbConn.AddInParameter(_cmd, "@tipoConsulta", DbType.Int32, 1);
                _dbConn.AddInParameter(_cmd, "@IdCompania", DbType.Int32, idCompania);
                IDataReader _dr = _dbConn.ExecuteReader(_cmd);
                ltProducto = rwProducto.rProducto(_dr);
                _dr.Close();
                _cmd.Dispose();

                return ltProducto;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
