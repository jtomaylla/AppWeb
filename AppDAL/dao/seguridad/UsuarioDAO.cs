using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;
using pe.com.seg.dal.dto;
using pe.com.sil.dal.dto;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace pe.com.seg.dal.dao
{
    public class UsuarioDAO
    {

        const string C_USP_BUSCAR_POR_CLAVE = "USP_Usuario_BuscarPorClave";
        const string C_LISTAR = "USP_Usuario_Listar";
        const string C_ACTUALIZAR = "USP_Usuario_Actualizar";
        const string C_AGREGAR = "USP_Usuario_Agregar";
        const string C_ELIMINAR = "USP_Usuario_Eliminar";
        const string C_USP_VERIFICA_ACCESO = "USP_Usuario_VerificaAcceso";
        const string C_USP_LISTAR_MENU_USUARIO = "USP_Usuario_ListarMenu";
        const string C_USP_LISTAR_PERFIL_USUARIO = "USP_Usuario_ListarPerfil";
        const string C_USP_BUSCAR_POR_LOGIN = "USP_Usuario_BuscarPorLogin";
        const string C_ACTUALIZAR_CLAVE = "USP_Usuario_Actualizar_Clave";
        
        //Asginacion a Proyecto
        const string C_USUARIO_PROYECTO_AGREGAR = "INSERT  INTO USUARIO_PROYECTO (ID_USUARIO, ID_PROYECTO, ESTADO, TIPO) VALUES ( @id_usuario, @id_proyecto, @estado, @tipo)";
        const string C_USUARIO_PROYECTO_ACTUALIZAR = "UPDATE USUARIO_PROYECTO SET ESTADO=@estado, TIPO=@tipo WHERE ID_USUARIO = @id_usuario AND ID_PROYECTO = @id_proyecto";
        const string C_USUARIO_PROYECTO_ELIMINAR = "DELETE USUARIO_PROYECTO WHERE ID_USUARIO = @id_usuario AND ID_PROYECTO = @id_proyecto";
        const string C_USUARIO_PROYECTO_LISTAR = "SELECT a.id_usuario, a.id_proyecto, b.nombre_usuario, a.estado, a.tipo , c.descripcion nombre_tipo " +
                                                 "FROM USUARIO_PROYECTO a " +
                                                 "	LEFT JOIN SEG_USUARIO B ON (A.ID_USUARIO = B.ID_USUARIO ) " +
                                                 "	LEFT JOIN TABLA_DETALLE C ON (2 = C.ID_TABLA AND A.TIPO = C.VALOR) " + 
                                                 "WHERE A.ID_PROYECTO = @id_proyecto " +
                                                 "ORDER BY b.nombre_usuario ";

        
        public List<UsuarioDTO> Listar()
        {
            List<UsuarioDTO> Lista = new List<UsuarioDTO>();
            Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
            DbCommand dbCommand = db.GetStoredProcCommand(C_LISTAR);
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                while (dr.Read())
                {
                    UsuarioDTO obj = new UsuarioDTO();
                    if (dr["id_usuario"] != System.DBNull.Value)
                        obj.IdUsuario = (int)dr["id_usuario"];
                    if (dr["login_usuario"] != System.DBNull.Value)
                        obj.LoginUsuario = (string)dr["login_usuario"];
                    if (dr["nombre_usuario"] != System.DBNull.Value)
                        obj.NombreUsuario = (string)dr["nombre_usuario"];
                    if (dr["clave"] != System.DBNull.Value)
                        obj.Clave = (string)dr["clave"];
                    if (dr["estado"] != System.DBNull.Value)
                        obj.Estado = (string)dr["estado"];
                    if (dr["fecha_creacion"] != System.DBNull.Value)
                        obj.FechaCreacion = (DateTime)dr["fecha_creacion"];
                    if (dr["usuario_creacion"] != System.DBNull.Value)
                        obj.UsuarioCreacion = (string)dr["usuario_creacion"];
                    if (dr["fecha_modificacion"] != System.DBNull.Value)
                        obj.FechaModificacion = (DateTime)dr["fecha_modificacion"];
                    if (dr["usuario_modificacion"] != System.DBNull.Value)
                        obj.UsuarioModificacion = (string)dr["usuario_modificacion"];

                    Lista.Add(obj);
 
                }
            }
            return Lista;
        }

        public List<UsuarioDTO> ListarOrdenadoPorNombreUsuario()
        {
            List<UsuarioDTO> Lista = new List<UsuarioDTO>();
            Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
            DbCommand dbCommand = db.GetStoredProcCommand("USP_Usuario_ListarOrdenadoPorNombreUsuario");
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                while (dr.Read())
                {
                    UsuarioDTO obj = new UsuarioDTO();
                    if (dr["id_usuario"] != System.DBNull.Value)
                        obj.IdUsuario = (int)dr["id_usuario"];
                    if (dr["login_usuario"] != System.DBNull.Value)
                        obj.LoginUsuario = (string)dr["login_usuario"];
                    if (dr["nombre_usuario"] != System.DBNull.Value)
                        obj.NombreUsuario = (string)dr["nombre_usuario"];
                    if (dr["clave"] != System.DBNull.Value)
                        obj.Clave = (string)dr["clave"];
                    if (dr["estado"] != System.DBNull.Value)
                        obj.Estado = (string)dr["estado"];
                    if (dr["fecha_creacion"] != System.DBNull.Value)
                        obj.FechaCreacion = (DateTime)dr["fecha_creacion"];
                    if (dr["usuario_creacion"] != System.DBNull.Value)
                        obj.UsuarioCreacion = (string)dr["usuario_creacion"];
                    if (dr["fecha_modificacion"] != System.DBNull.Value)
                        obj.FechaModificacion = (DateTime)dr["fecha_modificacion"];
                    if (dr["usuario_modificacion"] != System.DBNull.Value)
                        obj.UsuarioModificacion = (string)dr["usuario_modificacion"];

                    Lista.Add(obj);

                }
            }
            return Lista;
        }

        public int Agregar(UsuarioDTO obj)
        {
            Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
            DbCommand dbCommand = db.GetStoredProcCommand(C_AGREGAR);
            db.AddInParameter(dbCommand, "@login_usuario", DbType.String, obj.LoginUsuario);
            db.AddInParameter(dbCommand, "@nombre_usuario", DbType.String, obj.NombreUsuario);
            db.AddInParameter(dbCommand, "@clave", DbType.String , obj.Clave);
            db.AddInParameter(dbCommand, "@estado", DbType.String, obj.Estado);
            db.AddInParameter(dbCommand, "@email", DbType.String, obj.Email);

            if (obj.FechaCreacion.Year == 1)
                db.AddInParameter(dbCommand, "@fecha_creacion", DbType.DateTime, null);
            else
                db.AddInParameter(dbCommand, "@fecha_creacion", DbType.DateTime, obj.FechaCreacion);

            db.AddInParameter(dbCommand, "@usuario_creacion", DbType.String, obj.UsuarioCreacion);

            if (obj.FechaModificacion.Year == 1)
                db.AddInParameter(dbCommand, "@fecha_modificacion", DbType.DateTime, null);
            else
                db.AddInParameter(dbCommand, "@fecha_modificacion", DbType.DateTime, obj.FechaModificacion);
          
            db.AddInParameter(dbCommand, "@usuario_modificacion", DbType.String, obj.UsuarioModificacion);
            int id = Convert.ToInt32( db.ExecuteScalar(dbCommand)) ;
            return id;
      }

        public void Actualizar(UsuarioDTO obj)
      {
            Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
            DbCommand dbCommand = db.GetStoredProcCommand(C_ACTUALIZAR);
            db.AddInParameter(dbCommand, "@id_usuario", DbType.Int32, obj.IdUsuario);
            db.AddInParameter(dbCommand, "@login_usuario", DbType.String, obj.LoginUsuario);
            db.AddInParameter(dbCommand, "@nombre_usuario", DbType.String, obj.NombreUsuario);
            //db.AddInParameter(dbCommand, "@clave", DbType.String , obj.Clave);
            db.AddInParameter(dbCommand, "@estado", DbType.String, obj.Estado);
            db.AddInParameter(dbCommand, "@email", DbType.String, obj.Email);

            if (obj.FechaCreacion.Year == 1)
                db.AddInParameter(dbCommand, "@fecha_creacion", DbType.DateTime, null);
            else
                db.AddInParameter(dbCommand, "@fecha_creacion", DbType.DateTime, obj.FechaCreacion);

            db.AddInParameter(dbCommand, "@usuario_creacion", DbType.String, obj.UsuarioCreacion);
            
            if (obj.FechaCreacion.Year == 1)
                db.AddInParameter(dbCommand, "@fecha_modificacion", DbType.DateTime, null);
            else
                db.AddInParameter(dbCommand, "@fecha_modificacion", DbType.DateTime, obj.FechaModificacion);

                db.AddInParameter(dbCommand, "@usuario_modificacion", DbType.String, obj.UsuarioModificacion);
                db.ExecuteNonQuery(dbCommand);
      }

        public void Eliminar(int IdUsuario)
        {
            Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
            DbCommand dbCommand = db.GetStoredProcCommand(C_ELIMINAR);
            db.AddInParameter(dbCommand, "@id_usuario", DbType.Int32, IdUsuario);
            db.ExecuteNonQuery(dbCommand);
        }

        public UsuarioDTO ListarPorClave(int id)
        {
            UsuarioDTO obj = null;
            Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
            DbCommand dbCommand = db.GetStoredProcCommand(C_USP_BUSCAR_POR_CLAVE);
            db.AddInParameter(dbCommand, "@id_usuario", DbType.Int32, id);

            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                if (dr.Read())
                {
                    obj = new UsuarioDTO();

                    if (dr["id_usuario"] != System.DBNull.Value)
                        obj.IdUsuario = (int)dr["id_usuario"];

                    if (dr["login_usuario"] != System.DBNull.Value)
                        obj.LoginUsuario = (string)dr["login_usuario"];
                    
                    if (dr["nombre_usuario"] != System.DBNull.Value)
                        obj.NombreUsuario = (string)dr["nombre_usuario"];
                    
                    if (dr["clave"] != System.DBNull.Value)
                        obj.Clave = (string)dr["clave"];
                    
                    if (dr["estado"] != System.DBNull.Value)
                        obj.Estado = (string)dr["estado"];

                    if (dr["email"] != System.DBNull.Value)
                        obj.Email = (string)dr["email"];
                    
                    
                    if (dr["fecha_creacion"] != System.DBNull.Value)
                        obj.FechaCreacion = (DateTime)dr["fecha_creacion"];
                    
                    if (dr["usuario_creacion"] != System.DBNull.Value)
                        obj.UsuarioCreacion = (string)dr["usuario_creacion"];
                    
                    if (dr["fecha_modificacion"] != System.DBNull.Value)
                        obj.FechaModificacion = (DateTime)dr["fecha_modificacion"];
                    
                    if (dr["usuario_modificacion"] != System.DBNull.Value)
                        obj.UsuarioModificacion = (string)dr["usuario_modificacion"];

                }
            }
            return obj;
        }

        public UsuarioDTO ListarPorLogin(string LoginUsuario)
        {
            UsuarioDTO obj = null;
            Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
            DbCommand dbCommand = db.GetStoredProcCommand(C_USP_BUSCAR_POR_LOGIN);
            db.AddInParameter(dbCommand, "@login_usuario", DbType.String, LoginUsuario);

            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                if (dr.Read())
                {
                    obj = new UsuarioDTO();

                    if (dr["id_usuario"] != System.DBNull.Value)
                        obj.IdUsuario = (int)dr["id_usuario"];

                    if (dr["login_usuario"] != System.DBNull.Value)
                        obj.LoginUsuario = (string)dr["login_usuario"];

                    if (dr["nombre_usuario"] != System.DBNull.Value)
                        obj.NombreUsuario = (string)dr["nombre_usuario"];

                    if (dr["clave"] != System.DBNull.Value)
                        obj.Clave = (string)dr["clave"];

                    if (dr["estado"] != System.DBNull.Value)
                        obj.Estado = (string)dr["estado"];


                    if (dr["email"] != System.DBNull.Value)
                        obj.Email = (string)dr["email"];

                    if (dr["fecha_creacion"] != System.DBNull.Value)
                        obj.FechaCreacion = (DateTime)dr["fecha_creacion"];

                    if (dr["usuario_creacion"] != System.DBNull.Value)
                        obj.UsuarioCreacion = (string)dr["usuario_creacion"];

                    if (dr["fecha_modificacion"] != System.DBNull.Value)
                        obj.FechaModificacion = (DateTime)dr["fecha_modificacion"];

                    if (dr["usuario_modificacion"] != System.DBNull.Value)
                        obj.UsuarioModificacion = (string)dr["usuario_modificacion"];

                    if (dr["PERF_ANULACION"] != System.DBNull.Value)
                        obj.AnulaDescarta = (string)dr["PERF_ANULACION"];

                }
            }
            return obj;
        }

        public List<PerfilDTO> ListarPerfilUsuario(int IdUsuario)
        {
            List<PerfilDTO> Lista = new List<PerfilDTO>();
            Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
            DbCommand dbCommand = db.GetStoredProcCommand(C_USP_LISTAR_PERFIL_USUARIO);
            db.AddInParameter(dbCommand, "@id_usuario", DbType.Int32, IdUsuario);
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                while (dr.Read())
                {
                    PerfilDTO obj = new PerfilDTO();

                    obj.IdPerfil = (int)dr["id_perfil"];
                    if (dr["nombre_perfil"] != System.DBNull.Value) obj.NombrePerfil = (string)dr["nombre_perfil"];

                    Lista.Add(obj);
                }
            }

            return Lista;

        }
                
        public List<UsuarioPerfilFuncionDTO> ListarMenuUsuario(int IdUsuario)
        {

            List<UsuarioPerfilFuncionDTO> Lista = new List<UsuarioPerfilFuncionDTO>();
            Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
            DbCommand dbCommand = db.GetStoredProcCommand(C_USP_LISTAR_MENU_USUARIO);
            db.AddInParameter(dbCommand, "@id_usuario", DbType.Int32, IdUsuario);

            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                while (dr.Read())
                {
                    UsuarioPerfilFuncionDTO obj = new UsuarioPerfilFuncionDTO();

                    obj.IdUsuario = (int)dr["id_usuario"];
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

        public UsuarioDTO VerificaAcceso(string Usuario, string Clave) {
            UsuarioDTO obj = null;
            Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
            DbCommand dbCommand = db.GetStoredProcCommand(C_USP_VERIFICA_ACCESO);
            db.AddInParameter(dbCommand, "@login_usuario", DbType.String , Usuario);
            db.AddInParameter(dbCommand, "@clave", DbType.String, Clave);

            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                if (dr.Read())
                {

                    obj = new UsuarioDTO();

                    if (dr["id_usuario"] != System.DBNull.Value)
                        obj.IdUsuario = (int)dr["id_usuario"];

                    if (dr["login_usuario"] != System.DBNull.Value)
                        obj.LoginUsuario = (string)dr["login_usuario"];

                    if (dr["nombre_usuario"] != System.DBNull.Value)
                        obj.NombreUsuario = (string)dr["nombre_usuario"];

                    if (dr["clave"] != System.DBNull.Value)
                        obj.Clave = (string)dr["clave"];

                    if (dr["estado"] != System.DBNull.Value)
                        obj.Estado = (string)dr["estado"];

                    if (dr["fecha_creacion"] != System.DBNull.Value)
                        obj.FechaCreacion = (DateTime)dr["fecha_creacion"];

                    if (dr["usuario_creacion"] != System.DBNull.Value)
                        obj.UsuarioCreacion = (string)dr["usuario_creacion"];

                    if (dr["fecha_modificacion"] != System.DBNull.Value)
                        obj.FechaModificacion = (DateTime)dr["fecha_modificacion"];

                    if (dr["usuario_modificacion"] != System.DBNull.Value)
                        obj.UsuarioModificacion = (string)dr["usuario_modificacion"];

                }
            }
            return obj;

        
        }

        public void UsuarioProyectoAgregar(UsuarioProyectoDTO obj)
        {
            Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
            DbCommand dbCommand = db.GetSqlStringCommand(C_USUARIO_PROYECTO_AGREGAR);

            db.AddInParameter(dbCommand, "@id_usuario", DbType.Int32, obj.IdUsuario);
            db.AddInParameter(dbCommand, "@id_proyecto", DbType.Int32, obj.IdProyecto);
            db.AddInParameter(dbCommand, "@estado", DbType.String, obj.Estado);
            db.AddInParameter(dbCommand, "@tipo", DbType.String, obj.Tipo);

            db.ExecuteNonQuery(dbCommand);

        }

        public void UsuarioProyectoActualizar(UsuarioProyectoDTO obj)
        {
            Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
            DbCommand dbCommand = db.GetSqlStringCommand(C_USUARIO_PROYECTO_ACTUALIZAR);

            db.AddInParameter(dbCommand, "@id_usuario", DbType.Int32, obj.IdUsuario);
            db.AddInParameter(dbCommand, "@id_proyecto", DbType.Int32, obj.IdProyecto);
            db.AddInParameter(dbCommand, "@estado", DbType.String, obj.Estado);
            db.AddInParameter(dbCommand, "@tipo", DbType.String, obj.Tipo);

            db.ExecuteNonQuery(dbCommand);

        }


        public List<UsuarioProyectoDTO> ListarUsuarioProyecto(int IdProyecto)
        {
            List<UsuarioProyectoDTO> Lista = new List<UsuarioProyectoDTO>();
            Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
            DbCommand dbCommand = db.GetSqlStringCommand(C_USUARIO_PROYECTO_LISTAR);
            db.AddInParameter(dbCommand, "@id_proyecto", DbType.Int32, IdProyecto);

            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                while (dr.Read())
                {
                    UsuarioProyectoDTO obj = new UsuarioProyectoDTO();
            
                    obj.IdUsuario = (int)dr["id_usuario"];

                    obj.IdProyecto = (int)dr["id_proyecto"];

                    if (dr["nombre_usuario"] != System.DBNull.Value)
                        obj.NombreUsuario = (string)dr["nombre_usuario"];
                    
                    if (dr["estado"] != System.DBNull.Value)
                        obj.Estado = (string)dr["estado"];

                    if (dr["nombre_tipo"] != System.DBNull.Value)
                        obj.NombreTipo = (string)dr["nombre_tipo"];
                                  
                    if (dr["tipo"] != System.DBNull.Value)
                        obj.Tipo = (string)dr["tipo"];

                    Lista.Add(obj);
 
                }
            }
            return Lista;
        }

        public void ActualizarClave(UsuarioDTO obj)
        {
            Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
            DbCommand dbCommand = db.GetStoredProcCommand(C_ACTUALIZAR_CLAVE);
            db.AddInParameter(dbCommand, "@id_usuario", DbType.Int32, obj.IdUsuario);
            db.AddInParameter(dbCommand, "@clave", DbType.String, obj.Clave);
            db.AddInParameter(dbCommand, "@usuario_modificacion", DbType.String, obj.UsuarioModificacion);
            db.ExecuteNonQuery(dbCommand);
        }

    
    }
}
