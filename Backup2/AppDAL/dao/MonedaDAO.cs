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
  public class MonedaDAO
  {

      const string C_LISTAR_POR_CLAVE = "USP_Moneda_ListarPorClave";
      const string C_ACTUALIZAR = "USP_Moneda_Actualizar";
      const string C_AGREGAR = "USP_Moneda_Agregar";
      const string C_ELIMINAR = "USP_Moneda_Eliminar";

      public MonedaDTO ListarPorClave( string CodMoneda)
      {
          MonedaDTO obj = null;
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_LISTAR_POR_CLAVE);
          db.AddInParameter(dbCommand, "@cod_moneda", DbType.String, CodMoneda);

          using (IDataReader dr = db.ExecuteReader(dbCommand)) 
          {
              if (dr.Read())
              {
                  obj = new MonedaDTO();

                  if (dr["cod_moneda"] != System.DBNull.Value)
                      obj.CodMoneda = (string)dr["cod_moneda"];

                  if (dr["nombre_moneda"] != System.DBNull.Value)
                      obj.NombreMoneda = (string)dr["nombre_moneda"];

                  if (dr["simbolo"] != System.DBNull.Value)
                      obj.Simbolo = (string)dr["simbolo"];
              }
          }
          return obj;
      }

      public int Agregar(MonedaDTO obj)
      {
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_AGREGAR);
          db.AddInParameter(dbCommand, "@cod_moneda", DbType.String, obj.CodMoneda);
          db.AddInParameter(dbCommand, "@nombre_moneda", DbType.String, obj.NombreMoneda);
          db.AddInParameter(dbCommand, "@simbolo", DbType.String, obj.Simbolo);
          int id = Convert.ToInt32(db.ExecuteScalar(dbCommand));
          return id;
      }

      public void Actualizar(MonedaDTO obj)
      {
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_ACTUALIZAR);
          db.AddInParameter(dbCommand, "@cod_moneda", DbType.String, obj.CodMoneda);
          db.AddInParameter(dbCommand, "@nombre_moneda", DbType.String, obj.NombreMoneda);
          db.AddInParameter(dbCommand, "@simbolo", DbType.String, obj.Simbolo);
          db.ExecuteNonQuery(dbCommand);
      }

      public void Eliminar(string CodMoneda)
      {
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_ELIMINAR);
          db.AddInParameter(dbCommand, "@cod_moneda", DbType.Int32, CodMoneda);
          db.ExecuteNonQuery(dbCommand);
      }

      protected object GetFechaValida(DateTime fecha) 
      {
          if (fecha.Year == 1) 
              return null; 
          else 
              return fecha; 
      } 

  }
}
