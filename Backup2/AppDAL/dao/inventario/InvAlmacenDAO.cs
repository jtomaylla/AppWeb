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
  public class InvAlmacenDAO
  {

      const string C_LISTAR = "USP_InvAlmacen_Listar";
      const string C_LISTAR_POR_CLAVE = "USP_InvAlmacen_ListarPorClave";
      const string C_ACTUALIZAR = "USP_InvAlmacen_Actualizar";
      const string C_AGREGAR = "USP_InvAlmacen_Agregar";
      const string C_ELIMINAR = "USP_InvAlmacen_Eliminar";

      public List<InvAlmacenDTO> Listar()
      {
          List<InvAlmacenDTO> Lista = new List<InvAlmacenDTO>();
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_LISTAR);
          using (IDataReader dr = db.ExecuteReader(dbCommand)) 
          {
              while (dr.Read())
              {
                  InvAlmacenDTO obj = new InvAlmacenDTO();
                  if (dr["id_almacen"] != System.DBNull.Value)
                      obj.IdAlmacen = (int)dr["id_almacen"];
                  if (dr["cod_almacen"] != System.DBNull.Value)
                      obj.CodAlmacen = (string)dr["cod_almacen"];
                  if (dr["nombre_almacen"] != System.DBNull.Value)
                      obj.NombreAlmacen = (string)dr["nombre_almacen"];
                  if (dr["direccion"] != System.DBNull.Value)
                      obj.Direccion = (string)dr["direccion"];
                  if (dr["estado"] != System.DBNull.Value)
                      obj.Estado = (string)dr["estado"];

                  Lista.Add(obj);
              }
          }
          return Lista;
      }

      public InvAlmacenDTO ListarPorClave(int idAlmacen)
      {
          List<InvAlmacenDTO> Lista = new List<InvAlmacenDTO>();
          InvAlmacenDTO obj = null;
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_LISTAR_POR_CLAVE);
          db.AddInParameter(dbCommand, "@id_almacen", DbType.Int32, idAlmacen);
          using (IDataReader dr = db.ExecuteReader(dbCommand))
          {
              while (dr.Read())
              {
                  obj = new InvAlmacenDTO();
                  if (dr["id_almacen"] != System.DBNull.Value)
                      obj.IdAlmacen = (int)dr["id_almacen"];
                  if (dr["cod_almacen"] != System.DBNull.Value)
                      obj.CodAlmacen = (string)dr["cod_almacen"];
                  if (dr["nombre_almacen"] != System.DBNull.Value)
                      obj.NombreAlmacen = (string)dr["nombre_almacen"];
                  if (dr["direccion"] != System.DBNull.Value)
                      obj.Direccion = (string)dr["direccion"];
                  if (dr["estado"] != System.DBNull.Value)
                      obj.Estado = (string)dr["estado"];

              }
          }
          return obj;
      }

      public int Agregar(InvAlmacenDTO obj)
      {
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_AGREGAR);
          db.AddInParameter(dbCommand, "@id_almacen", DbType.Int32, obj.IdAlmacen);
          db.AddInParameter(dbCommand, "@cod_almacen", DbType.String, obj.CodAlmacen);
          db.AddInParameter(dbCommand, "@nombre_almacen", DbType.String, obj.NombreAlmacen);
          db.AddInParameter(dbCommand, "@direccion", DbType.String, obj.Direccion);
          db.AddInParameter(dbCommand, "@estado", DbType.String, obj.Estado);
          int id = db.ExecuteNonQuery(dbCommand);
          return id;
      }

      public void Actualizar(InvAlmacenDTO obj)
      {
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_ACTUALIZAR);
          db.AddInParameter(dbCommand, "@id_almacen", DbType.Int32, obj.IdAlmacen);
          db.AddInParameter(dbCommand, "@cod_almacen", DbType.String, obj.CodAlmacen);
          db.AddInParameter(dbCommand, "@nombre_almacen", DbType.String, obj.NombreAlmacen);
          db.AddInParameter(dbCommand, "@direccion", DbType.String, obj.Direccion);
          db.AddInParameter(dbCommand, "@estado", DbType.String, obj.Estado);
          db.ExecuteNonQuery(dbCommand);
      }

      public void Eliminar(int IdAlmacen)
      {
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_ELIMINAR);
          db.AddInParameter(dbCommand, "@id_almacen", DbType.Int32, IdAlmacen);
          db.ExecuteNonQuery(dbCommand);
      }
  }
}
