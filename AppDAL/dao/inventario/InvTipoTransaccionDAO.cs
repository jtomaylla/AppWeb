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
  public class InvTipoTransaccionDAO
  {

      const string C_LISTAR = "USP_InvTipoTransaccion_Listar";
      const string C_LISTAR_POR_CLAVE = "USP_InvTipoTransaccion_ListarPorClave";
      const string C_ACTUALIZAR = "USP_InvTipoTransaccion_Actualizar";
      const string C_AGREGAR = "USP_InvTipoTransaccion_Agregar";
      const string C_ELIMINAR = "USP_InvTipoTransaccion_Eliminar";

      public List<InvTipoTransaccionDTO> Listar()
      {
          List<InvTipoTransaccionDTO> Lista = new List<InvTipoTransaccionDTO>();
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_LISTAR);
          using (IDataReader dr = db.ExecuteReader(dbCommand)) 
          {
              while (dr.Read())
              {
                  InvTipoTransaccionDTO obj = new InvTipoTransaccionDTO();
                  if (dr["id_tipo_transaccion"] != System.DBNull.Value)
                      obj.IdTipoTransaccion = (int)dr["id_tipo_transaccion"];
                  if (dr["nombre_transaccion"] != System.DBNull.Value)
                      obj.NombreTransaccion = (string)dr["nombre_transaccion"];
                  if (dr["estado"] != System.DBNull.Value)
                      obj.Estado = (string)dr["estado"];
                  if (dr["clase"] != System.DBNull.Value)
                      obj.Clase = (string)dr["clase"];

                  Lista.Add(obj);
              }
          }
          return Lista;
      }

      public InvTipoTransaccionDTO ListarPorClave(int idTransaccion)
      {
          List<InvTipoTransaccionDTO> Lista = new List<InvTipoTransaccionDTO>();
          InvTipoTransaccionDTO obj = null;
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_LISTAR_POR_CLAVE);
          db.AddInParameter(dbCommand, "@id_tipo_transaccion", DbType.Int32, idTransaccion);
          using (IDataReader dr = db.ExecuteReader(dbCommand))
          {
              while (dr.Read())
              {
                  obj = new InvTipoTransaccionDTO();
                  if (dr["id_tipo_transaccion"] != System.DBNull.Value)
                      obj.IdTipoTransaccion = (int)dr["id_tipo_transaccion"];
                  if (dr["nombre_transaccion"] != System.DBNull.Value)
                      obj.NombreTransaccion = (string)dr["nombre_transaccion"];
                  if (dr["estado"] != System.DBNull.Value)
                      obj.Estado = (string)dr["estado"];
                  if (dr["clase"] != System.DBNull.Value)
                      obj.Clase = (string)dr["clase"];

              }
          }
          return obj;
      }

      public int Agregar(InvTipoTransaccionDTO obj)
      {
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_AGREGAR);
          db.AddInParameter(dbCommand, "@id_tipo_transaccion", DbType.Int32, obj.IdTipoTransaccion);
          db.AddInParameter(dbCommand, "@nombre_transaccion", DbType.String, obj.NombreTransaccion);
          db.AddInParameter(dbCommand, "@estado", DbType.String, obj.Estado);
          db.AddInParameter(dbCommand, "@clase", DbType.String, obj.Clase);
          int id = db.ExecuteNonQuery(dbCommand);
          return id;
      }

      public void Actualizar(InvTipoTransaccionDTO obj)
      {
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_ACTUALIZAR);
          db.AddInParameter(dbCommand, "@id_tipo_transaccion", DbType.Int32, obj.IdTipoTransaccion);
          db.AddInParameter(dbCommand, "@nombre_transaccion", DbType.String, obj.NombreTransaccion);
          db.AddInParameter(dbCommand, "@estado", DbType.String, obj.Estado);
          db.AddInParameter(dbCommand, "@clase", DbType.String, obj.Clase);
          db.ExecuteNonQuery(dbCommand);
      }

      public void Eliminar(int IdTipoTransaccion)
      {
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_ELIMINAR);
          db.AddInParameter(dbCommand, "@id_tipo_transaccion", DbType.Int32, IdTipoTransaccion);
          db.ExecuteNonQuery(dbCommand);
      }
  }
}
