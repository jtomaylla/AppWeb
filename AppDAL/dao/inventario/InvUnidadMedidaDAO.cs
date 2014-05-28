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
  public class InvUnidadMedidaDAO
  {

      const string C_LISTAR = "SELECT id_unidad_medida, nombre_unidad_medida, nombre_corto, estado FROM INV_UNIDAD_MEDIDA ORDER BY 1";
      const string C_LISTAR_POR_CLAVE = "SELECT id_unidad_medida, nombre_unidad_medida, nombre_corto, estado FROM INV_UNIDAD_MEDIDA WHERE id_unidad_medida = @id_unidad_medida";
      const string C_AGREGAR = "INSERT INTO INV_UNIDAD_MEDIDA(nombre_unidad_medida,nombre_corto,estado) VALUES (@nombre_unidad_medida,@nombre_corto,@estado)";
	  const string C_ACTUALIZAR = "UPDATE INV_UNIDAD_MEDIDA SET nombre_unidad_medida = @nombre_unidad_medida,nombre_corto = @nombre_corto ,estado = @estado WHERE id_unidad_medida = @id_unidad_medida";
      const string C_ELIMINAR = "DELETE INV_UNIDAD_MEDIDA WHERE id_unidad_medida = @id_unidad_medida";

      public List<InvUnidadMedidaDTO> Listar()
      {
          List<InvUnidadMedidaDTO> Lista = new List<InvUnidadMedidaDTO>();
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetSqlStringCommand(C_LISTAR);
          using (IDataReader dr = db.ExecuteReader(dbCommand)) 
          {
              while (dr.Read())
              {
                  InvUnidadMedidaDTO obj = new InvUnidadMedidaDTO();
                  if (dr["id_unidad_medida"] != System.DBNull.Value)
                      obj.IdUnidadMedida = (int)dr["id_unidad_medida"];
                  if (dr["nombre_unidad_medida"] != System.DBNull.Value)
                      obj.NombreUnidadMedida = (string)dr["nombre_unidad_medida"];
                  if (dr["nombre_corto"] != System.DBNull.Value)
                      obj.NombreCorto = (string)dr["nombre_corto"];
                  if (dr["estado"] != System.DBNull.Value)
                      obj.Estado = (string)dr["estado"];

				  Lista.Add(obj);

              }
          }
          return Lista;
      }

     public InvUnidadMedidaDTO ListarPorClave(int IdUnidadMedida)
      {
		  	
          InvUnidadMedidaDTO obj = null;
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetSqlStringCommand(C_LISTAR_POR_CLAVE);
          db.AddInParameter(dbCommand, "@id_unidad_medida", DbType.Int32, IdUnidadMedida);

          using (IDataReader dr = db.ExecuteReader(dbCommand)) 
          {
              if (dr.Read())
              {
                  obj = new InvUnidadMedidaDTO();
                  if (dr["id_unidad_medida"] != System.DBNull.Value)
                      obj.IdUnidadMedida = (int)dr["id_unidad_medida"];
                  if (dr["nombre_unidad_medida"] != System.DBNull.Value)
                      obj.NombreUnidadMedida = (string)dr["nombre_unidad_medida"];
                  if (dr["nombre_corto"] != System.DBNull.Value)
                      obj.NombreCorto = (string)dr["nombre_corto"];
                  if (dr["estado"] != System.DBNull.Value)
                      obj.Estado = (string)dr["estado"];


              }
          }
          return obj;
      }

      public int Agregar(InvUnidadMedidaDTO obj)
      {
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetSqlStringCommand(C_AGREGAR);
          db.AddInParameter(dbCommand, "@nombre_unidad_medida", DbType.String, obj.NombreUnidadMedida);
          db.AddInParameter(dbCommand, "@nombre_corto", DbType.String, obj.NombreCorto);
          db.AddInParameter(dbCommand, "@estado", DbType.String, obj.Estado);

          db.ExecuteNonQuery(dbCommand);

          dbCommand = db.GetSqlStringCommand("SELECT MAX(id_unidad_medida) FROM INV_UNIDAD_MEDIDA");
 	      int id = Convert.ToInt32(db.ExecuteScalar (dbCommand));

          return id;
      }

      public void Actualizar(InvUnidadMedidaDTO obj)
      {
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetSqlStringCommand(C_ACTUALIZAR);
          db.AddInParameter(dbCommand, "@id_unidad_medida", DbType.Int32, obj.IdUnidadMedida);
          db.AddInParameter(dbCommand, "@nombre_unidad_medida", DbType.String, obj.NombreUnidadMedida);
          db.AddInParameter(dbCommand, "@nombre_corto", DbType.String, obj.NombreCorto);
          db.AddInParameter(dbCommand, "@estado", DbType.String, obj.Estado);
          db.ExecuteNonQuery(dbCommand);
      }

      public void Eliminar(int IdUnidadMedida)
      {
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetSqlStringCommand(C_ELIMINAR);
          db.AddInParameter(dbCommand, "@id_unidad_medida", DbType.Int32, IdUnidadMedida);
          db.ExecuteNonQuery(dbCommand);
      }
  }
}
