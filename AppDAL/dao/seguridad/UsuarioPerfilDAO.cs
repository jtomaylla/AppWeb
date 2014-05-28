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
    public class UsuarioPerfilDAO
    {
        const string C_USP_BUSCAR_POR_CLAVE = "SELECT id_usuario, id_perfil " +
                                                "FROM SEG_USUARIO_PERFIL " +
                                                "WHERE id_usuario =@id_usuario and " +
                                                "       id_perfil = @id_perfil";

        const string C_USP_AGREGAR = "INSERT INTO SEG_USUARIO_PERFIL (id_usuario, id_perfil) " +
                                      "VALUES (@id_usuario, @id_perfil ) ";

        const string C_USP_ELIMINAR = "DELETE SEG_USUARIO_PERFIL WHERE id_usuario = @id_usuario and id_perfil = @id_perfil";

        const string C_LISTAR_POR_USUARIO = "SELECT A.id_usuario, A.id_perfil, B.nombre_perfil " +
                                            "FROM SEG_USUARIO_PERFIL A, SEG_PERFIL B " +
                                            "WHERE A.id_usuario =@id_usuario AND A.id_perfil = B.id_perfil AND B.estado = '1' ";
                                                

        public UsuarioPerfilDTO ListarPorClave(int idUsuario, int idPerfil)
        {
            UsuarioPerfilDTO obj = new UsuarioPerfilDTO();
            Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
            DbCommand dbCommand = db.GetSqlStringCommand(C_USP_BUSCAR_POR_CLAVE);
            db.AddInParameter(dbCommand, "@id_usuario", DbType.Int32, idUsuario);
            db.AddInParameter(dbCommand, "@id_perfil", DbType.Int32, idPerfil);

            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                if (dr.Read())
                {
                    obj.IdUsuario = (int)dr["id_usuario"];
                    obj.IdPerfil = (int)dr["id_perfil"];
                }
            }
            return obj;
        }

        public void Agregar(UsuarioPerfilDTO obj)
        {
            Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
            DbCommand dbCommand = db.GetSqlStringCommand(C_USP_AGREGAR);
            db.AddInParameter(dbCommand, "@id_usuario", DbType.Int32, obj.IdUsuario);
            db.AddInParameter(dbCommand, "@id_perfil", DbType.Int32, obj.IdPerfil);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Eliminar(UsuarioPerfilDTO obj)
        {
            Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
            DbCommand dbCommand = db.GetSqlStringCommand(C_USP_ELIMINAR);
            db.AddInParameter(dbCommand, "@id_usuario", DbType.Int32, obj.IdUsuario);
            db.AddInParameter(dbCommand, "@id_perfil", DbType.Int32, obj.IdPerfil);
            db.ExecuteNonQuery(dbCommand);

        }
        
        public List<UsuarioPerfilDTO> ListarPorUsuario(int idUsuario)
        {
            List<UsuarioPerfilDTO> Lista = new List<UsuarioPerfilDTO>();
            
            Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
            DbCommand dbCommand = db.GetSqlStringCommand(C_LISTAR_POR_USUARIO);
            db.AddInParameter(dbCommand, "@id_usuario", DbType.Int32, idUsuario);

            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                while (dr.Read())
                {
                    UsuarioPerfilDTO obj = new UsuarioPerfilDTO();
                    obj.IdUsuario = (int)dr["id_usuario"];
                    obj.IdPerfil = (int)dr["id_perfil"];
                    obj.NombrePerfil = (string)dr["nombre_perfil"];

                    Lista.Add(obj);
                }
            }
            return Lista;
        }

    }
}
