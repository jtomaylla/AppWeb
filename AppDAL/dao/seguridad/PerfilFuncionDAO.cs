using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;
using pe.com.seg.dal.dto;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace pe.com.seg.dal.dao
{
  public class PerfilFuncionDAO
  {
      const string C_USP_BUSCAR_POR_CLAVE = "SELECT id_perfil, id_funcion, orden, estado " +
                                                "FROM SEG_PERFIL_FUNCION " +
                                                "WHERE id_perfil =@id_perfil and " +
                                                "       id_funcion = @id_funcion";

      const string C_LISTAR = "USP_PerfilFuncion_Listar";
      const string C_ACTUALIZAR = "USP_PerfilFuncion_Actualizar";
      const string C_AGREGAR = "USP_PerfilFuncion_Agregar";
      const string C_USP_AGREGAR = "INSERT INTO SEG_PERFIL_FUNCION (id_perfil, id_funcion, orden, estado) " +
                                      "VALUES (@id_perfil, @id_funcion, @orden, @estado ) ";

      const string C_USP_ELIMINAR = "DELETE FROM SEG_PERFIL_FUNCION WHERE id_perfil = @id_perfil and id_funcion = @id_funcion";

      const string C_ELIMINAR = "USP_PerfilFuncion_Eliminar";

      const string C_LISTAR_POR_PERFIL_FUNCION = "USP_PerfilFuncion_Listar";

      const string C_LISTAR_FUNCION_POR_PERFIL = "SELECT id_funcion, nombre_funcion, funcion, estado " +
                                                 "FROM SEG_FUNCION sf " +
                                                 "WHERE sf.id_funcion not in ( " +
                                                 "	SELECT id_funcion " +
                                                 "	FROM SEG_PERFIL_FUNCION " +
                                                 "	WHERE id_perfil = @id_perfil " +
                                                 ")";

      const string C_LISTAR_POR_PERFIL = "select sf.id_funcion, sf.nombre_funcion, sf.funcion, sf.estado, spf.orden  " +
                                         "from SEG_PERFIL_FUNCION spf, SEG_FUNCION sf " +
                                         "where spf.id_perfil = @id_perfil " +
                                         "and spf.id_funcion = sf.id_funcion " +
                                         "order by spf.orden ";


      public PerfilFuncionDTO ListarPorClave(int idPerfil, int idFuncion)
      {
          PerfilFuncionDTO obj = new PerfilFuncionDTO();
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetSqlStringCommand(C_USP_BUSCAR_POR_CLAVE);
          db.AddInParameter(dbCommand, "@id_perfil", DbType.Int32, idPerfil);
          db.AddInParameter(dbCommand, "@id_funcion", DbType.Int32, idFuncion);

          using (IDataReader dr = db.ExecuteReader(dbCommand))
          {
              if (dr.Read())
              {
                  obj.IdPerfil = (int)dr["id_perfil"];
                  obj.IdFuncion = (int)dr["id_funcion"];
              }
          }
          return obj;
      }

      public List<PerfilFuncionDTO> Listar()
      {
          List<PerfilFuncionDTO> Lista = new List<PerfilFuncionDTO>();
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_LISTAR);
          using (IDataReader dr = db.ExecuteReader(dbCommand)) 
          {
              while (dr.Read())
              {
                  PerfilFuncionDTO obj = new PerfilFuncionDTO();
                  if (dr["id_perfil"] != System.DBNull.Value)
                      obj.IdPerfil = (int)dr["id_perfil"];
                  if (dr["id_funcion"] != System.DBNull.Value)
                      obj.IdFuncion = (int)dr["id_funcion"];
                  if (dr["orden"] != System.DBNull.Value)
                      obj.Orden = (int)dr["orden"];
                  if (dr["Estado"] != System.DBNull.Value)
                      obj.Estado = (string)dr["Estado"];

              }
          }
          return Lista;
      }

      public int Agregar(PerfilFuncionDTO obj)
      {
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetSqlStringCommand(C_USP_AGREGAR);
          db.AddInParameter(dbCommand, "@id_perfil", DbType.Int32, obj.IdPerfil);
          db.AddInParameter(dbCommand, "@id_funcion", DbType.Int32, obj.IdFuncion);
          db.AddInParameter(dbCommand, "@orden", DbType.Int32, obj.Orden);
          db.AddInParameter(dbCommand, "@estado", DbType.String, obj.Estado);
          int id = db.ExecuteNonQuery(dbCommand);
          return id;
      }

      public void Actualizar(PerfilFuncionDTO obj)
      {
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_ACTUALIZAR);
          db.AddInParameter(dbCommand, "@id_perfil", DbType.Int32, obj.IdPerfil);
          db.AddInParameter(dbCommand, "@id_funcion", DbType.Int32, obj.IdFuncion);
          db.AddInParameter(dbCommand, "@orden", DbType.Int32, obj.Orden);
          db.AddInParameter(dbCommand, "@Estado", DbType.String, obj.Estado);
          db.ExecuteNonQuery(dbCommand);
      }

      public void Eliminar(int IdPerfil)
      {
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_ELIMINAR);
          db.AddInParameter(dbCommand, "@id_perfil", DbType.Int32, IdPerfil);
          db.ExecuteNonQuery(dbCommand);
      }

      public void Eliminar(PerfilFuncionDTO obj)
      {
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetSqlStringCommand(C_USP_ELIMINAR);
          db.AddInParameter(dbCommand, "@id_funcion", DbType.Int32, obj.IdFuncion);
          db.AddInParameter(dbCommand, "@id_perfil", DbType.Int32, obj.IdPerfil);
          db.ExecuteNonQuery(dbCommand);
      }

      public List<PerfilFuncionDTO> ListarPorPerfil(int IdPerfil)
      {
          List<PerfilFuncionDTO> Lista = new List<PerfilFuncionDTO>();
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand("USP_PerfilFuncion_ListarPorPerfil");
          db.AddInParameter(dbCommand, "@id_perfil", DbType.Int32, IdPerfil);

          using (IDataReader dr = db.ExecuteReader(dbCommand))
          {
              while (dr.Read())
              {
                  PerfilFuncionDTO obj = new PerfilFuncionDTO();
                  if (dr["id_perfil"] != System.DBNull.Value)
                      obj.IdPerfil = (int)dr["id_perfil"];

                  if (dr["id_funcion"] != System.DBNull.Value)
                      obj.IdFuncion = (int)dr["id_funcion"];
                  
                  if (dr["orden"] != System.DBNull.Value)
                      obj.Orden = (int)dr["orden"];
                  
                  if (dr["Estado"] != System.DBNull.Value)
                      obj.Estado = (string)dr["Estado"];

                  if (dr["nombre_funcion"] != System.DBNull.Value)
                      obj.NombreFuncion = (string)dr["nombre_funcion"];

                  Lista.Add(obj); 

              }
          }
          return Lista;
      }

      public PerfilFuncionDTO ListarPorPerfilFuncion(int IdPerfil, int IdFuncion)
      {
          PerfilFuncionDTO obj = null;
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetSqlStringCommand(C_LISTAR_POR_PERFIL_FUNCION);
          db.AddInParameter(dbCommand, "@id_perfil", DbType.Int32, IdPerfil);
          db.AddInParameter(dbCommand, "@id_funcion", DbType.Int32, IdFuncion);

          using (IDataReader dr = db.ExecuteReader(dbCommand))
          {
              while (dr.Read())
              {
                  obj = new PerfilFuncionDTO();

                  if (dr["id_perfil"] != System.DBNull.Value)
                      obj.IdPerfil = (int)dr["id_perfil"];

                  if (dr["id_funcion"] != System.DBNull.Value)
                      obj.IdFuncion = (int)dr["id_funcion"];

                  if (dr["orden"] != System.DBNull.Value)
                      obj.Orden = (int)dr["orden"];

                  if (dr["Estado"] != System.DBNull.Value)
                      obj.Estado = (string)dr["Estado"];
              }
          }
          return obj;
      }

      public List<FuncionDTO> ListarFuncionPorPerfil(int IdPerfil)
      {
          List<FuncionDTO> Lista = new List<FuncionDTO>();
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetSqlStringCommand(C_LISTAR_FUNCION_POR_PERFIL);
          db.AddInParameter(dbCommand, "@id_perfil", DbType.Int32, IdPerfil);

          using (IDataReader dr = db.ExecuteReader(dbCommand))
          {
              while (dr.Read())
              {
                  FuncionDTO obj = new FuncionDTO();

                  obj.IdFuncion = (int)dr["id_funcion"];

                  if (dr["nombre_funcion"] != System.DBNull.Value)
                      obj.NombreFuncion = (string)dr["nombre_funcion"];

                  if (dr["funcion"] != System.DBNull.Value)
                      obj.Funcion = (string)dr["funcion"];

                  if (dr["estado"] != System.DBNull.Value)
                      obj.Estado = (string)dr["estado"];

                  Lista.Add(obj);
              }
          }
          
          return Lista;

      }

  }
}
