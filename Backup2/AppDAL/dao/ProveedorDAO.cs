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
    public class ProveedorDAO
    {
        const string C_LISTAR = "USP_Proveedor_Listar";
        const string C_LISTAR_POR_CLAVE = "USP_Proveedor_ListarPorClave";
        const string C_ACTUALIZAR = "USP_Proveedor_Actualizar";
        const string C_AGREGAR = "USP_Proveedor_Agregar";
        const string C_ELIMINAR = "USP_Proveedor_Eliminar";
        const string C_BUSCAR_POR_CLAVE = "USP_Proveedor_ListarPorClave";
        const string C_LISTAR_BUSQUEDA = "USP_Proveedor_ListarBusqueda";
        
        public List<ProveedorDTO> Listar()
        {
            List<ProveedorDTO> Lista = new List<ProveedorDTO>();
            Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
            DbCommand dbCommand = db.GetStoredProcCommand(C_LISTAR);
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                while (dr.Read())
                {
                    ProveedorDTO obj = new ProveedorDTO();

                    obj.IdProveedor = Int32.Parse(dr["id_proveedor"].ToString());

                    if (dr["razon_social"] != System.DBNull.Value)
                        obj.RazonSocial = (string)dr["razon_social"];

                    if (dr["ruc"] != System.DBNull.Value)
                        obj.Ruc = (string)dr["ruc"];

                    if (dr["tipo_persona"] != System.DBNull.Value)
                        obj.TipoPersona = (string)dr["tipo_persona"];

                    if (dr["nombre_tipo_persona"] != System.DBNull.Value)
                        obj.NombreTipoPersona = (string)dr["nombre_tipo_persona"];

                    if (dr["direccion"] != System.DBNull.Value)
                        obj.Direccion = (string)dr["direccion"];

                    if (dr["email"] != System.DBNull.Value)
                        obj.Email = (string)dr["email"];

                    if (dr["telefono"] != System.DBNull.Value)
                        obj.Telefono = (string)dr["telefono"];

                    if (dr["contacto"] != System.DBNull.Value)
                        obj.Contacto = (string)dr["contacto"];

                    if (dr["estado"] != System.DBNull.Value)
                        obj.Estado = (string)dr["estado"];

                    if (dr["fecha_creacion"] != System.DBNull.Value)
                        obj.FechaCreacion = (DateTime)dr["fecha_creacion"];
                    
                    if (dr["id_usuario_creacion"] != System.DBNull.Value)
                        obj.UsuarioCreacion = dr["id_usuario_creacion"].ToString();
                    
                    if (dr["fecha_modificacion"] != System.DBNull.Value)
                        obj.FechaModificacion = (DateTime)dr["fecha_modificacion"];
                    
                    if (dr["id_usuario_modificacion"] != System.DBNull.Value)
                        obj.UsuarioModificacion = dr["usuario_modificacion"].ToString();

                    Lista.Add(obj);
                }
            }
            return Lista;
        }

        public List<ProveedorDTO> ListarBusqueda(string strDescripcion)
        {
            List<ProveedorDTO> Lista = new List<ProveedorDTO>();
            Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
            DbCommand dbCommand = db.GetStoredProcCommand(C_LISTAR_BUSQUEDA);
            db.AddInParameter(dbCommand, "@descripcion", DbType.String, strDescripcion);
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                while (dr.Read())
                {
                    ProveedorDTO obj = new ProveedorDTO();

                    obj.IdProveedor = Int32.Parse(dr["id_proveedor"].ToString());

                    if (dr["razon_social"] != System.DBNull.Value)
                        obj.RazonSocial = (string)dr["razon_social"];

                    if (dr["ruc"] != System.DBNull.Value)
                        obj.Ruc = (string)dr["ruc"];

                    if (dr["tipo_persona"] != System.DBNull.Value)
                        obj.TipoPersona = (string)dr["tipo_persona"];

                    if (dr["nombre_tipo_persona"] != System.DBNull.Value)
                        obj.NombreTipoPersona = (string)dr["nombre_tipo_persona"];

                    if (dr["direccion"] != System.DBNull.Value)
                        obj.Direccion = (string)dr["direccion"];

                    if (dr["email"] != System.DBNull.Value)
                        obj.Email = (string)dr["email"];

                    if (dr["telefono"] != System.DBNull.Value)
                        obj.Telefono = (string)dr["telefono"];

                    if (dr["contacto"] != System.DBNull.Value)
                        obj.Contacto = (string)dr["contacto"];

                    if (dr["estado"] != System.DBNull.Value)
                        obj.Estado = (string)dr["estado"];

                    if (dr["fecha_creacion"] != System.DBNull.Value)
                        obj.FechaCreacion = (DateTime)dr["fecha_creacion"];

                    if (dr["id_usuario_creacion"] != System.DBNull.Value)
                        obj.UsuarioCreacion = dr["id_usuario_creacion"].ToString();

                    if (dr["fecha_modificacion"] != System.DBNull.Value)
                        obj.FechaModificacion = (DateTime)dr["fecha_modificacion"];

                    if (dr["id_usuario_modificacion"] != System.DBNull.Value)
                        obj.UsuarioModificacion = dr["usuario_modificacion"].ToString();

                    Lista.Add(obj);
                }
            }
            return Lista;
        }

        public ProveedorDTO ListarPorClave(int idProveedor)
        {
            ProveedorDTO obj = new ProveedorDTO();
            Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
            DbCommand dbCommand = db.GetStoredProcCommand(C_LISTAR_POR_CLAVE);
            db.AddInParameter(dbCommand, "@id_proveedor", DbType.Int32, idProveedor);

            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                while (dr.Read())
                {
                    obj.IdProveedor = Int32.Parse(dr["id_proveedor"].ToString());

                    if (dr["razon_social"] != System.DBNull.Value)
                        obj.RazonSocial = (string)dr["razon_social"];

                    if (dr["ruc"] != System.DBNull.Value)
                        obj.Ruc = (string)dr["ruc"];

                    if (dr["tipo_persona"] != System.DBNull.Value)
                        obj.TipoPersona = (string)dr["tipo_persona"];

                    if (dr["nombre_tipo_persona"] != System.DBNull.Value)
                        obj.NombreTipoPersona = (string)dr["nombre_tipo_persona"];

                    if (dr["direccion"] != System.DBNull.Value)
                        obj.Direccion = (string)dr["direccion"];

                    if (dr["email"] != System.DBNull.Value)
                        obj.Email = (string)dr["email"];

                    if (dr["telefono"] != System.DBNull.Value)
                        obj.Telefono = (string)dr["telefono"];

                    if (dr["contacto"] != System.DBNull.Value)
                        obj.Contacto = (string)dr["contacto"];

                    if (dr["estado"] != System.DBNull.Value)
                        obj.Estado = (string)dr["estado"];

                    if (dr["fecha_creacion"] != System.DBNull.Value)
                        obj.FechaCreacion = (DateTime)dr["fecha_creacion"];

                    if (dr["id_usuario_creacion"] != System.DBNull.Value)
                        obj.UsuarioCreacion = dr["id_usuario_creacion"].ToString();

                    if (dr["fecha_modificacion"] != System.DBNull.Value)
                        obj.FechaModificacion = (DateTime)dr["fecha_modificacion"];

                    if (dr["id_usuario_modificacion"] != System.DBNull.Value)
                        obj.UsuarioModificacion = dr["usuario_modificacion"].ToString();

                }
            }
            return obj;
        }

        public int Agregar(ProveedorDTO obj)
        {
            Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
            DbCommand dbCommand = db.GetStoredProcCommand(C_AGREGAR);
            db.AddInParameter(dbCommand, "@razon_social", DbType.String, obj.RazonSocial);
            db.AddInParameter(dbCommand, "@ruc", DbType.String, obj.Ruc);
            db.AddInParameter(dbCommand, "@tipo_persona", DbType.String, obj.TipoPersona);
            db.AddInParameter(dbCommand, "@direccion", DbType.String, obj.Direccion);
            db.AddInParameter(dbCommand, "@email", DbType.String, obj.Email);
            db.AddInParameter(dbCommand, "@telefono", DbType.String, obj.Telefono);
            db.AddInParameter(dbCommand, "@contacto", DbType.String, obj.Contacto);
            db.AddInParameter(dbCommand, "@estado", DbType.String, obj.Estado);
            db.AddInParameter(dbCommand, "@id_usuario_creacion", DbType.String, obj.UsuarioCreacion);

            int id = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return id;
        }

        public void Actualizar(ProveedorDTO obj)
        {
            Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
            DbCommand dbCommand = db.GetStoredProcCommand(C_ACTUALIZAR);

            db.AddInParameter(dbCommand, "@id_proveedor", DbType.Int32, obj.IdProveedor);
            db.AddInParameter(dbCommand, "@razon_social", DbType.String, obj.RazonSocial);
            db.AddInParameter(dbCommand, "@ruc", DbType.String, obj.Ruc);
            db.AddInParameter(dbCommand, "@tipo_persona", DbType.String, obj.TipoPersona);
            db.AddInParameter(dbCommand, "@direccion", DbType.String, obj.Direccion);
            db.AddInParameter(dbCommand, "@email", DbType.String, obj.Email);
            db.AddInParameter(dbCommand, "@telefono", DbType.String, obj.Telefono);
            db.AddInParameter(dbCommand, "@contacto", DbType.String, obj.Contacto);
            db.AddInParameter(dbCommand, "@estado", DbType.String, obj.Estado);
            db.AddInParameter(dbCommand, "@id_usuario_modificacion", DbType.Int32, obj.UsuarioModificacion);

            db.ExecuteNonQuery(dbCommand);
        }
        public void Eliminar(int IdProveedor)
        {
            Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
            DbCommand dbCommand = db.GetStoredProcCommand(C_ELIMINAR);
            db.AddInParameter(dbCommand, "@id_proveedor", DbType.Int32, IdProveedor);
            db.ExecuteNonQuery(dbCommand);
        }
    }
}
