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
    public class ProyectoDAO
    {

        const string C_BUSCAR_POR_CLAVE = "SELECT id_proyecto, nombre_proyecto, estado, nombre_corto " +
                                                "FROM PROYECTO " +
                                                "WHERE id_proyecto = @id_proyecto";

        const string C_LISTAR = "SELECT id_proyecto, nombre_proyecto, nombre_corto, estado " +
                                    "FROM PROYECTO " +
                                    "ORDER BY id_proyecto ";


        const string C_LISTAR_ORDEN_POR_NOMBRE = "USP_Proyecto_ListaOrdenadoPorNombre";

        const string C_LISTAR_POR_USUARIO = "USP_Proyecto_ListaPorUsuario";
        
        const string C_ACTUALIZAR = "USP_Proyecto_Actualizar";

        const string C_AGREGAR = "USP_Proyecto_Agregar";

        const string C_ELIMINAR = "USP_Proyecto_Eliminar";

        const string C_ASIGNAR_USUARIO = "INSERT INTO USUARIO_PROYECTO (ID_USUARIO, ID_PROYECTO, ESTADO, TIPO ) " +
                                         "VALUES (@id_usuario, @id_proyecto, @estado, @tipo) ";


        public ProyectoDTO ListarPorClave(int id)
        {
            ProyectoDTO obj = new ProyectoDTO();
            Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
            DbCommand dbCommand = db.GetSqlStringCommand(C_BUSCAR_POR_CLAVE);
            db.AddInParameter(dbCommand, "@id_proyecto", DbType.Int32, id);

            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                if (dr.Read())
                {
                    obj.IdProyecto = (int)dr["id_proyecto"];

                    if (dr["nombre_proyecto"] != System.DBNull.Value)
                        obj.NombreProyecto = (string)dr["nombre_proyecto"];

                    if (dr["estado"] != System.DBNull.Value)
                        obj.Estado = (string)dr["estado"];

                    if (dr["nombre_corto"] != System.DBNull.Value)
                        obj.NombreCorto = (string)dr["nombre_corto"];

                }
            }
            return obj;
        }

        public List<ProyectoDTO> Listar()
        {
            List<ProyectoDTO> Lista = new List<ProyectoDTO>();
            Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
            DbCommand dbCommand = db.GetSqlStringCommand(C_LISTAR);

            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                while (dr.Read())
                {
                    ProyectoDTO obj = new ProyectoDTO();

                    obj.IdProyecto = (int)dr["id_proyecto"];

                    if (dr["nombre_proyecto"] != System.DBNull.Value)
                        obj.NombreProyecto  = (string)dr["nombre_proyecto"];

                    if (dr["nombre_corto"] != System.DBNull.Value)
                        obj.NombreCorto = (string)dr["nombre_corto"];

                    if (dr["estado"] != System.DBNull.Value)
                        obj.Estado = (string)dr["estado"];

                    Lista.Add(obj);
                }
            }


            return Lista;

        }

        public List<ProyectoDTO> ListarOrdenPorNombre()
        {
            List<ProyectoDTO> Lista = new List<ProyectoDTO>();
            Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
            DbCommand dbCommand = db.GetStoredProcCommand(C_LISTAR_ORDEN_POR_NOMBRE);

            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                while (dr.Read())
                {
                    ProyectoDTO obj = new ProyectoDTO();

                    obj.IdProyecto = (int)dr["id_proyecto"];

                    if (dr["nombre_proyecto"] != System.DBNull.Value)
                        obj.NombreProyecto = (string)dr["nombre_proyecto"];

                    if (dr["nombre_corto"] != System.DBNull.Value)
                        obj.NombreCorto = (string)dr["nombre_corto"];

                    if (dr["estado"] != System.DBNull.Value)
                        obj.Estado = (string)dr["estado"];

                    Lista.Add(obj);
                }
            }


            return Lista;

        }

        public List<ProyectoDTO> Listar(int IdUsuario)
        {
            List<ProyectoDTO> Lista = new List<ProyectoDTO>();
            Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
            DbCommand dbCommand = db.GetStoredProcCommand (C_LISTAR_POR_USUARIO);
            db.AddInParameter(dbCommand, "@id_usuario", DbType.Int32, IdUsuario);

            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                while (dr.Read())
                {
                    ProyectoDTO obj = new ProyectoDTO();

                    obj.IdProyecto = (int)dr["id_proyecto"];

                    if (dr["nombre_proyecto"] != System.DBNull.Value)
                        obj.NombreProyecto = (string)dr["nombre_proyecto"];

                    if (dr["nombre_corto"] != System.DBNull.Value)
                        obj.NombreCorto = (string)dr["nombre_corto"];

                    if (dr["estado"] != System.DBNull.Value)
                        obj.Estado = (string)dr["estado"];

                    Lista.Add(obj);
                }
            }


            return Lista;

        }
        
        public int Agregar(ProyectoDTO obj)
        {
            Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
            DbCommand dbCommand = db.GetStoredProcCommand(C_AGREGAR);
            db.AddInParameter(dbCommand, "@nombre_proyecto", DbType.String, obj.NombreProyecto );
            db.AddInParameter(dbCommand, "@nombre_corto", DbType.String, obj.NombreCorto);
            db.AddInParameter(dbCommand, "@estado", DbType.String, obj.Estado);

            int id = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return id;

        }

        public void Actualizar(ProyectoDTO obj)
        {
            Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
            DbCommand dbCommand = db.GetStoredProcCommand(C_ACTUALIZAR);
            db.AddInParameter(dbCommand, "@id_proyecto", DbType.Int32, obj.IdProyecto );
            db.AddInParameter(dbCommand, "@nombre_proyecto", DbType.String, obj.NombreProyecto);
            db.AddInParameter(dbCommand, "@nombre_corto", DbType.String, obj.NombreCorto);
            db.AddInParameter(dbCommand, "@estado", DbType.String, obj.Estado);
            db.ExecuteNonQuery(dbCommand);
        }

        public void Eliminar(int IdProyecto)
        {
            Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
            DbCommand dbCommand = db.GetStoredProcCommand(C_ELIMINAR);
            db.AddInParameter(dbCommand, "@id_proyecto", DbType.Int32, IdProyecto);
            db.ExecuteNonQuery(dbCommand);

        }

        public void AsignarUsuario(UsuarioProyectoDTO obj) {
            Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
            DbCommand dbCommand = db.GetSqlStringCommand(C_ASIGNAR_USUARIO);
            db.AddInParameter(dbCommand, "@id_usuario", DbType.String, obj.IdUsuario);
            db.AddInParameter(dbCommand, "@id_proyecto", DbType.String, obj.IdProyecto);
            db.AddInParameter(dbCommand, "@estado", DbType.String, obj.Estado);
            db.AddInParameter(dbCommand, "@tipo", DbType.String, obj.Tipo);

            db.ExecuteNonQuery(dbCommand);
            
        }

        public int CountPedidos(int IdProyecto)
        {
            Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
            DbCommand dbCommand = db.GetSqlStringCommand("SELECT COUNT(*) FROM PEDIDO WHERE ID_PROYECTO = @id_proyecto");
            db.AddInParameter(dbCommand, "@id_proyecto", DbType.Int32, IdProyecto);
            int count = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return count;
        }
    }
}
