using Datos.Entidades;
using Datos.RowsMappers;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Conn
{
    public class ConnCompania
    {

        public List<DtoCompania> obtenerCompanias()
        {
            DbCommand _cmd;
            Database _dbConn;

            try
            {
                List<DtoCompania> ltCompania = new List<DtoCompania>();
                RwCompania rCompania = new RwCompania();

                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                _dbConn = factory.Create("testBD");

                _cmd = _dbConn.GetStoredProcCommand("dbo.SP_CONSULTAR_COMPANIA");
                _dbConn.AddInParameter(_cmd, "@tipoConsulta", DbType.Int32, 1);
                IDataReader _dr = _dbConn.ExecuteReader(_cmd);
                ltCompania = rCompania.rwCompania(_dr);
                _dr.Close();
                _cmd.Dispose();

                return ltCompania;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
