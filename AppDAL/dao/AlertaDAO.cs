using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;
using pe.com.sil.dal.dto;
using Microsoft.Practices.EnterpriseLibrary.Data;

using Microsoft.Practices.EnterpriseLibrary.Data;

namespace pe.com.sil.dal.dao
{
    public class AlertaDAO
    {

        const string C_LISTAR_POR_USUARIO = "USP_Alerta_ListarPorUsuario";

        public DataTable ListarPorUsuario(int IdUsuario)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable(); 

            Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
            DbCommand dbCommand = db.GetStoredProcCommand(C_LISTAR_POR_USUARIO);
            db.AddInParameter(dbCommand, "@id_usuario", DbType.Int32, IdUsuario);

            ds = db.ExecuteDataSet(dbCommand);

            dt = ds.Tables[0];
            if (dt != null)
                return dt;
            else
                return null; 

        }
    }
}
