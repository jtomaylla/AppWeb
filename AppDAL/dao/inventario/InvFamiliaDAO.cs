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
  public class InvFamiliaDAO
  {

      const string C_LISTAR = "SELECT id_familia,cod_familia,nombre_familia,estado FROM INV_FAMILIA ORDER BY 1";
      const string C_LISTAR_POR_CLAVE = "SELECT id_familia,cod_familia,nombre_familia,estado FROM INV_FAMILIA WHERE id_familia = @id_familia";
      const string C_AGREGAR = "INSERT INTO INV_FAMILIA(cod_familia,nombre_familia,estado)VALUES ( @cod_familia,@nombre_familia,@estado)";
	  const string C_ACTUALIZAR = "UPDATE INV_FAMILIA SET cod_familia = @cod_familia,nombre_familia = @nombre_familia,estado = @estado WHERE id_familia = @id_familia";
      const string C_ELIMINAR = "DELETE INV_FAMILIA WHERE id_familia = @id_familia";

      public List<InvFamiliaDTO> Listar()
      {
          List<InvFamiliaDTO> Lista = new List<InvFamiliaDTO>();
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetSqlStringCommand(C_LISTAR);
          using (IDataReader dr = db.ExecuteReader(dbCommand)) 
          {
              while (dr.Read())
              {
                  InvFamiliaDTO obj = new InvFamiliaDTO();
                  if (dr["id_familia"] != System.DBNull.Value)
                      obj.IdFamilia = (int)dr["id_familia"];
                  if (dr["cod_familia"] != System.DBNull.Value)
                      obj.CodFamilia = (string)dr["cod_familia"];
                  if (dr["nombre_familia"] != System.DBNull.Value)
                      obj.NombreFamilia = (string)dr["nombre_familia"];
                  if (dr["estado"] != System.DBNull.Value)
                      obj.Estado = (string)dr["estado"];

				  Lista.Add(obj);

              }
          }
          return Lista;
      }

      public InvFamiliaDTO ListarPorClave(int IdFamilia)
      {
          InvFamiliaDTO obj = null;
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          try
          {
              DbCommand dbCommand = db.GetSqlStringCommand(C_LISTAR_POR_CLAVE);
              db.AddInParameter(dbCommand, "@id_familia", DbType.String, IdFamilia);
              using (IDataReader dr = db.ExecuteReader(dbCommand)) 
              {
                  if (dr.Read())
                  {
                      obj = new InvFamiliaDTO();
                      if (dr["id_familia"] != System.DBNull.Value)
                          obj.IdFamilia = (int)dr["id_familia"];
                      if (dr["cod_familia"] != System.DBNull.Value)
                          obj.CodFamilia = (string)dr["cod_familia"];
                      if (dr["nombre_familia"] != System.DBNull.Value)
                          obj.NombreFamilia = (string)dr["nombre_familia"];
                      if (dr["estado"] != System.DBNull.Value)
                          obj.Estado = (string)dr["estado"];

                  }
              }
          }
          catch (Exception err)
          {
              throw err;   
          }
          return obj;
      }

      public int Agregar(InvFamiliaDTO obj)
      {
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetSqlStringCommand(C_AGREGAR);
          db.AddInParameter(dbCommand, "@cod_familia", DbType.String, obj.CodFamilia);
          db.AddInParameter(dbCommand, "@nombre_familia", DbType.String, obj.NombreFamilia);
          db.AddInParameter(dbCommand, "@estado", DbType.String, obj.Estado);
          db.ExecuteNonQuery(dbCommand);

          dbCommand = db.GetSqlStringCommand("SELECT MAX(id_familia) FROM INV_FAMILIA");
 	      int id = Convert.ToInt32(db.ExecuteScalar (dbCommand));

          return id;
      }

      public void Actualizar(InvFamiliaDTO obj)
      {
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetSqlStringCommand(C_ACTUALIZAR);
          db.AddInParameter(dbCommand, "@id_familia", DbType.Int32, obj.IdFamilia);
          db.AddInParameter(dbCommand, "@cod_familia", DbType.String, obj.CodFamilia);
          db.AddInParameter(dbCommand, "@nombre_familia", DbType.String, obj.NombreFamilia);
          db.AddInParameter(dbCommand, "@estado", DbType.String, obj.Estado);
          db.ExecuteNonQuery(dbCommand);
      }

      public void Eliminar(int IdFamilia)
      {
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetSqlStringCommand(C_ELIMINAR);
          db.AddInParameter(dbCommand, "@id_familia", DbType.Int32, IdFamilia);
          db.ExecuteNonQuery(dbCommand);
      }
  }
}
