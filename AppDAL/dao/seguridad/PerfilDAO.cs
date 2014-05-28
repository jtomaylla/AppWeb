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
    public class PerfilDAO
    {

        const string C_USP_BUSCAR_POR_CLAVE = "SELECT id_perfil, nombre_perfil, estado " +
                                                "FROM SEG_PERFIL " +
                                                "WHERE id_perfil = @id_perfil";

        const string C_USP_LISTAR = "SELECT id_perfil, nombre_perfil, estado " + 
                                    "FROM SEG_PERFIL " + 
                                    "ORDER BY id_perfil";
        
        const string C_USP_ACTUALIZAR = "UPDATE SEG_PERFIL " +
                                        "SET nombre_perfil = @nombre_perfil, estado = @estado " +
                                        "WHERE id_perfil = @id_perfil ";

        const string C_USP_AGREGAR = "INSERT INTO SEG_PERFIL ([nombre_perfil], [estado]) " +
                                      "VALUES (@nombre_perfil, @estado ) " ;
                                      
        const string C_USP_ELIMINAR = "DELETE SEG_PERFIL WHERE id_perfil = @id_perfil";


        public PerfilDTO ListarPorClave(int id)
        {
            PerfilDTO obj = new PerfilDTO();
            Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
            DbCommand dbCommand = db.GetSqlStringCommand(C_USP_BUSCAR_POR_CLAVE);
            db.AddInParameter(dbCommand, "@id_perfil", DbType.Int32, id);

            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                if (dr.Read())
                {
                    obj.IdPerfil = (int)dr["id_perfil"];
                    obj.NombrePerfil = (string)dr["nombre_perfil"];

                    if (dr["nombre_perfil"] != System.DBNull.Value)
                        obj.NombrePerfil = (string)dr["nombre_perfil"];

                    if (dr["estado"] != System.DBNull.Value)
                        obj.Estado = (string)dr["estado"];

                }
            }
            return obj;
        }


        public List<PerfilDTO> Listar()
        {
            List<PerfilDTO> Lista = new List<PerfilDTO>();
            Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
            DbCommand dbCommand = db.GetSqlStringCommand(C_USP_LISTAR); 

            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                while (dr.Read())
                {
                    PerfilDTO obj = new PerfilDTO();

                    obj.IdPerfil = (int)dr["id_perfil"];

                    if (dr["nombre_perfil"] != System.DBNull.Value)
                        obj.NombrePerfil = (string)dr["nombre_perfil"];

                    if (dr["estado"] != System.DBNull.Value)
                        obj.Estado = (string)dr["estado"];

                    Lista.Add(obj);
                }
            }


            return Lista;

        }

        public int Agregar(PerfilDTO obj)
        {
            Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
            DbCommand dbCommand = db.GetSqlStringCommand(C_USP_AGREGAR);
            db.AddInParameter(dbCommand, "@nombre_perfil", DbType.String, obj.NombrePerfil);
            db.AddInParameter(dbCommand, "@estado", DbType.String, obj.Estado);

            db.ExecuteNonQuery(dbCommand);

            dbCommand = db.GetSqlStringCommand("SELECT MAX(id_perfil) FROM SEG_PERFIL");

            int Id = Convert.ToInt32(db.ExecuteScalar (dbCommand));
            
            return Id;

        }

        public void Actualizar(PerfilDTO obj)
        {
            Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
            DbCommand dbCommand = db.GetSqlStringCommand (C_USP_ACTUALIZAR);
            db.AddInParameter(dbCommand, "@id_perfil", DbType.Int32, obj.IdPerfil);
            db.AddInParameter(dbCommand, "@nombre_perfil", DbType.String, obj.NombrePerfil);
            db.AddInParameter(dbCommand, "@estado", DbType.String, obj.Estado);
            db.ExecuteNonQuery(dbCommand);               
        }

        public void Eliminar(int IdPerfil)
        {
            Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
            DbCommand dbCommand = db.GetSqlStringCommand(C_USP_ELIMINAR);
            db.AddInParameter(dbCommand, "@id_perfil", DbType.Int32, IdPerfil);
            db.ExecuteNonQuery(dbCommand);

        }

        public List<UsuarioPerfilFuncionDTO> ListarMenu()
        {

            List<UsuarioPerfilFuncionDTO> Lista = new List<UsuarioPerfilFuncionDTO>();
            Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
            DbCommand dbCommand = db.GetStoredProcCommand("USP_Perfil_ListarMenu");

            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                while (dr.Read())
                {
                    UsuarioPerfilFuncionDTO obj = new UsuarioPerfilFuncionDTO();

                    obj.IdPerfil = (int)dr["id_perfil"];
                    obj.IdFuncion = (int)dr["id_funcion"];
                    if (dr["nombre_perfil"] != System.DBNull.Value) obj.NombrePerfil = (string)dr["nombre_perfil"];
                    if (dr["funcion"] != System.DBNull.Value) obj.Funcion = (string)dr["funcion"];
                    if (dr["nombre_funcion"] != System.DBNull.Value) obj.NombreFuncion = (string)dr["nombre_funcion"];

                    Lista.Add(obj);
                }
            }

            return Lista;

        }

    }

}
