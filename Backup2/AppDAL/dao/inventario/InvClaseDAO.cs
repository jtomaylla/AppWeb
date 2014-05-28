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
  public class InvClaseDAO
  {
      const string C_LISTAR = "SELECT ID_CLASE, COD_CLASE, NOMBRE_CLASE, ESTADO FROM INV_CLASE ORDER BY ID_CLASE";
      const string C_LISTAR_POR_CLAVE = "SELECT ID_CLASE, COD_CLASE, NOMBRE_CLASE, ESTADO FROM INV_CLASE WHERE ID_CLASE = @id_clase";
      const string C_AGREGAR = "INSERT INTO INV_CLASE(cod_clase, nombre_clase, estado) VALUES (@cod_clase,@nombre_clase,@estado)";
	  const string C_ACTUALIZAR = "UPDATE INV_CLASE SET cod_clase = @cod_clase, nombre_clase = @nombre_clase, estado = @estado WHERE id_clase = @id_clase";
      const string C_ELIMINAR = "DELETE INV_CLASE WHERE id_clase = @id_clase";

      public List<InvClaseDTO> Listar()
      {
          List<InvClaseDTO> Lista = new List<InvClaseDTO>();
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetSqlStringCommand(C_LISTAR);
          using (IDataReader dr = db.ExecuteReader(dbCommand)) 
          {
              while (dr.Read())
              {
                  InvClaseDTO obj = new InvClaseDTO();
                  if (dr["id_clase"] != System.DBNull.Value)
                      obj.IdClase = (int)dr["id_clase"];
                  if (dr["cod_clase"] != System.DBNull.Value)
                      obj.CodClase = (string)dr["cod_clase"];
                  if (dr["nombre_clase"] != System.DBNull.Value)
                      obj.NombreClase = (string)dr["nombre_clase"];
                  if (dr["estado"] != System.DBNull.Value)
                      obj.Estado = (string)dr["estado"];
				
				  Lista.Add(obj);	
              }
          }
          return Lista;
      }

		public InvClaseDTO ListarPorClave(int IdClase)
        {
            InvClaseDTO obj = null;
            Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
            DbCommand dbCommand = db.GetSqlStringCommand(C_LISTAR_POR_CLAVE);
            db.AddInParameter(dbCommand, "id_clase", DbType.Int32, IdClase);

            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                if (dr.Read())
                {

                    obj = new InvClaseDTO();
                  
				  if (dr["id_clase"] != System.DBNull.Value)
                      obj.IdClase = (int)dr["id_clase"];
                  if (dr["cod_clase"] != System.DBNull.Value)
                      obj.CodClase = (string)dr["cod_clase"];
                  if (dr["nombre_clase"] != System.DBNull.Value)
                      obj.NombreClase = (string)dr["nombre_clase"];
                  if (dr["estado"] != System.DBNull.Value)
                      obj.Estado = (string)dr["estado"];

                }
            }
            return obj;
        }

      public int Agregar(InvClaseDTO obj)
      {
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetSqlStringCommand(C_AGREGAR);
          db.AddInParameter(dbCommand, "@cod_clase", DbType.String, obj.CodClase);
          db.AddInParameter(dbCommand, "@nombre_clase", DbType.String, obj.NombreClase);
          db.AddInParameter(dbCommand, "@estado", DbType.String, obj.Estado);
		  db.ExecuteNonQuery(dbCommand);

          dbCommand = db.GetSqlStringCommand("SELECT MAX(id_clase) FROM INV_CLASE");
          int id = Convert.ToInt32(db.ExecuteScalar(dbCommand));

          return id;
      }

      public void Actualizar(InvClaseDTO obj)
      {
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetSqlStringCommand(C_ACTUALIZAR);
          db.AddInParameter(dbCommand, "@id_clase", DbType.Int32, obj.IdClase);
          db.AddInParameter(dbCommand, "@cod_clase", DbType.String, obj.CodClase);
          db.AddInParameter(dbCommand, "@nombre_clase", DbType.String, obj.NombreClase);
          db.AddInParameter(dbCommand, "@estado", DbType.String, obj.Estado);
          db.ExecuteNonQuery(dbCommand);
      }

      public void Eliminar(int IdClase)
      {
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetSqlStringCommand(C_ELIMINAR);
          db.AddInParameter(dbCommand, "@id_clase", DbType.Int32, IdClase);
          db.ExecuteNonQuery(dbCommand);
      }
  }
}
