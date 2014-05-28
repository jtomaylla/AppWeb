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
  public class SedeDAO
  {

      const string C_LISTAR = "USP_Sede_Listar";
      const string C_ACTUALIZAR = "USP_Sede_Actualizar";
      const string C_AGREGAR = "USP_Sede_Agregar";
      const string C_ELIMINAR = "USP_Sede_Eliminar";
      const string C_LISTAR_POR_CLAVE = "USP_Sede_ListarPorClave";

      public List<SedeDTO> Listar()
      {
          List<SedeDTO> Lista = new List<SedeDTO>();
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_LISTAR);
          using (IDataReader dr = db.ExecuteReader(dbCommand)) 
          {
              while (dr.Read())
              {
                  SedeDTO obj = new SedeDTO();
                  if (dr["id_sede"] != System.DBNull.Value)
                      obj.IdSede = (int)dr["id_sede"];
                  if (dr["nombre_sede"] != System.DBNull.Value)
                      obj.NombreSede = (string)dr["nombre_sede"];
                  if (dr["estado"] != System.DBNull.Value)
                      obj.Estado = (string)dr["estado"];
                  if (dr["direccion"] != System.DBNull.Value)
                      obj.Direccion = (string)dr["direccion"];
                  Lista.Add(obj); 
              }
          }
          return Lista;
      }

      public int Agregar(SedeDTO obj)
      {
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_AGREGAR);
          db.AddInParameter(dbCommand, "@nombre_sede", DbType.String, obj.NombreSede);
          db.AddInParameter(dbCommand, "@estado", DbType.String, obj.Estado);
          db.AddInParameter(dbCommand, "@direccion", DbType.String, obj.Direccion);
          int id = Convert.ToInt32 ( db.ExecuteScalar(dbCommand));
          return id;
      }

      public void Actualizar(SedeDTO obj)
      {
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_ACTUALIZAR);
          db.AddInParameter(dbCommand, "@id_sede", DbType.Int32, obj.IdSede);
          db.AddInParameter(dbCommand, "@nombre_sede", DbType.String, obj.NombreSede);
          db.AddInParameter(dbCommand, "@estado", DbType.String, obj.Estado);
          db.AddInParameter(dbCommand, "@direccion", DbType.String, obj.Direccion);
          db.ExecuteNonQuery(dbCommand);
      }

      public void Eliminar(int IdSede)
      {
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_ELIMINAR);
          db.AddInParameter(dbCommand, "@id_sede", DbType.Int32, IdSede);
          db.ExecuteNonQuery(dbCommand);
      }

      public SedeDTO ListarPorClave(int IdSede)
      {
          SedeDTO obj = null;
          List<SedeDTO> Lista = new List<SedeDTO>();
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_LISTAR_POR_CLAVE);
          db.AddInParameter(dbCommand, "@id_sede", DbType.Int32, IdSede);
          using (IDataReader dr = db.ExecuteReader(dbCommand))
          {
              while (dr.Read())
              {
                  obj = new SedeDTO();
                  if (dr["id_sede"] != System.DBNull.Value) obj.IdSede = (int)dr["id_sede"];
                  if (dr["nombre_sede"] != System.DBNull.Value) obj.NombreSede = (string)dr["nombre_sede"];
                  if (dr["estado"] != System.DBNull.Value) obj.Estado = (string)dr["estado"];
                  if (dr["direccion"] != System.DBNull.Value) obj.Direccion = (string)dr["direccion"];
              }
          }
          return obj;
      }

  }
}

