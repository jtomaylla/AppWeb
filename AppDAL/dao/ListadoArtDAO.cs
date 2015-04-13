using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;
using pe.com.sil.dal.dto;
using Microsoft.Practices.EnterpriseLibrary.Data;


namespace pe.com.sil.dal.dao
{
    public class ListadoArtDAO
    {
        const string C_GENERAR_LISTADO = "USP_InvTransaccion_ListarTodos1";

        public DataTable ListarTodos()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
            DbCommand dbCommand = db.GetStoredProcCommand(C_GENERAR_LISTADO);
            ds = db.ExecuteDataSet(dbCommand);
            dt = ds.Tables[0];
            if (dt != null) { return dt; } else { return null; } 
        }
    }
}
