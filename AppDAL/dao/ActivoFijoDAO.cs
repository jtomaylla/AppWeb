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
  public class ActivoFijoDAO
  {

      const string C_LISTAR = "USP_ActivoFijo_Listar";
      const string C_LISTAR_POR_CLAVE = "USP_ActivoFijo_ListarPorClave";
      const string C_LISTAR_BUSQUEDA = "USP_ActivoFijo_ListarBusqueda";
      const string C_ACTUALIZAR = "USP_ActivoFijo_Actualizar";
      const string C_AGREGAR = "USP_ActivoFijo_Agregar";
      const string C_ELIMINAR = "USP_ActivoFijo_Eliminar";

      public List<ActivoFijoDTO> Listar()
      {
          List<ActivoFijoDTO> Lista = new List<ActivoFijoDTO>();
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_LISTAR);
          using (IDataReader dr = db.ExecuteReader(dbCommand)) 
          {
              while (dr.Read())
              {
                  ActivoFijoDTO obj = new ActivoFijoDTO();

                  if (dr["id_activo_fijo"] != System.DBNull.Value)
                      obj.IdActivoFijo = (int)dr["id_activo_fijo"];

                  if (dr["codigo"] != System.DBNull.Value)
                      obj.Codigo = (string)dr["codigo"];

                  if (dr["observacion1"] != System.DBNull.Value)
                      obj.Observacion1 = (string)dr["observacion1"];

                  if (dr["fecha_baja"] != System.DBNull.Value)
                      obj.FechaBaja = (DateTime)dr["fecha_baja"];

                  if (dr["descripcion"] != System.DBNull.Value)
                      obj.Descripcion = (string)dr["descripcion"];

                  if (dr["marca"] != System.DBNull.Value)
                      obj.Marca = (string)dr["marca"];

                  if (dr["modelo"] != System.DBNull.Value)
                      obj.Modelo = (string)dr["modelo"];

                  if (dr["serie"] != System.DBNull.Value)
                      obj.Serie = (string)dr["serie"];

                  if (dr["estado"] != System.DBNull.Value)
                      obj.Estado = (string)dr["estado"];

                  if (dr["factura"] != System.DBNull.Value)
                      obj.Factura = (string)dr["factura"];

                  if (dr["fecha_factura"] != System.DBNull.Value)
                      obj.FechaFactura = (DateTime)dr["fecha_factura"];

                  if (dr["id_proveedor"] != System.DBNull.Value)
                      obj.IdProveedor = (int)dr["id_proveedor"];

                  if (dr["proveedor"] != System.DBNull.Value)
                      obj.Proveedor = (string)dr["proveedor"];

                  if (dr["ruc_proveedor"] != System.DBNull.Value)
                      obj.RucProveedor = (string)dr["ruc_proveedor"];

                  if (dr["precio_soles"] != System.DBNull.Value)
                      obj.PrecioSoles = (Decimal)dr["precio_soles"];

                  if (dr["precio_dolares"] != System.DBNull.Value)
                      obj.PrecioDolares = (Decimal)dr["precio_dolares"];

                  if (dr["observacion2"] != System.DBNull.Value)
                      obj.Observacion2 = (string)dr["observacion2"];

                  if (dr["local_origen"] != System.DBNull.Value)
                      obj.LocalOrigen = (string)dr["local_origen"];

                  if (dr["ubicacion"] != System.DBNull.Value)
                      obj.Ubicacion = (string)dr["ubicacion"];

                  if (dr["area_proyecto"] != System.DBNull.Value)
                      obj.AreaProyecto = (string)dr["area_proyecto"];

                  if (dr["usuario_asignacion"] != System.DBNull.Value)
                      obj.UsuarioAsignacion = (string)dr["usuario_asignacion"];

                  if (dr["id_usuario_creacion"] != System.DBNull.Value)
                      obj.IdUsuarioCreacion = (int)dr["id_usuario_creacion"];

                  if (dr["fecha_creacion"] != System.DBNull.Value)
                      obj.FechaCreacion = (DateTime)dr["fecha_creacion"];

                  if (dr["id_usuario_modificacion"] != System.DBNull.Value)
                      obj.IdUsuarioModificacion = (int)dr["id_usuario_modificacion"];

                  if (dr["fecha_modificacion"] != System.DBNull.Value)
                      obj.FechaModificacion = (DateTime)dr["fecha_modificacion"];


                  Lista.Add(obj);
              }
          }
          return Lista;
      }


      public ActivoFijoDTO ListarPorClave(int idActivoFijo)
      {
          ActivoFijoDTO obj = null;
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_LISTAR_POR_CLAVE);
          db.AddInParameter(dbCommand, "@id_activo_fijo", DbType.Int32, idActivoFijo);

          using (IDataReader dr = db.ExecuteReader(dbCommand))
          {
              if (dr.Read())
              {
                  obj = new ActivoFijoDTO();

                  if (dr["id_activo_fijo"] != System.DBNull.Value)
                      obj.IdActivoFijo = (int)dr["id_activo_fijo"];

                  if (dr["codigo"] != System.DBNull.Value)
                      obj.Codigo = (string)dr["codigo"];

                  if (dr["observacion1"] != System.DBNull.Value)
                      obj.Observacion1 = (string)dr["observacion1"];

                  if (dr["fecha_baja"] != System.DBNull.Value)
                      obj.FechaBaja = (DateTime)dr["fecha_baja"];

                  if (dr["descripcion"] != System.DBNull.Value)
                      obj.Descripcion = (string)dr["descripcion"];

                  if (dr["marca"] != System.DBNull.Value)
                      obj.Marca = (string)dr["marca"];

                  if (dr["modelo"] != System.DBNull.Value)
                      obj.Modelo = (string)dr["modelo"];

                  if (dr["serie"] != System.DBNull.Value)
                      obj.Serie = (string)dr["serie"];

                  if (dr["estado"] != System.DBNull.Value)
                      obj.Estado = (string)dr["estado"];

                  if (dr["factura"] != System.DBNull.Value)
                      obj.Factura = (string)dr["factura"];

                  if (dr["fecha_factura"] != System.DBNull.Value)
                      obj.FechaFactura = (DateTime)dr["fecha_factura"];

                  if (dr["id_proveedor"] != System.DBNull.Value)
                      obj.IdProveedor = (int)dr["id_proveedor"];

                  if (dr["proveedor"] != System.DBNull.Value)
                      obj.Proveedor = (string)dr["proveedor"];

                  if (dr["ruc_proveedor"] != System.DBNull.Value)
                      obj.RucProveedor = (string)dr["ruc_proveedor"];

                  if (dr["precio_soles"] != System.DBNull.Value)
                      obj.PrecioSoles = (Decimal)dr["precio_soles"];

                  if (dr["precio_dolares"] != System.DBNull.Value)
                      obj.PrecioDolares = (Decimal)dr["precio_dolares"];

                  if (dr["observacion2"] != System.DBNull.Value)
                      obj.Observacion2 = (string)dr["observacion2"];

                  if (dr["local_origen"] != System.DBNull.Value)
                      obj.LocalOrigen = (string)dr["local_origen"];

                  if (dr["ubicacion"] != System.DBNull.Value)
                      obj.Ubicacion = (string)dr["ubicacion"];

                  if (dr["area_proyecto"] != System.DBNull.Value)
                      obj.AreaProyecto = (string)dr["area_proyecto"];

                  if (dr["usuario_asignacion"] != System.DBNull.Value)
                      obj.UsuarioAsignacion = (string)dr["usuario_asignacion"];

                  if (dr["id_usuario_creacion"] != System.DBNull.Value)
                      obj.IdUsuarioCreacion = (int)dr["id_usuario_creacion"];

                  if (dr["fecha_creacion"] != System.DBNull.Value)
                      obj.FechaCreacion = (DateTime)dr["fecha_creacion"];

                  if (dr["id_usuario_modificacion"] != System.DBNull.Value)
                      obj.IdUsuarioModificacion = (int)dr["id_usuario_modificacion"];

                  if (dr["fecha_modificacion"] != System.DBNull.Value)
                      obj.FechaModificacion = (DateTime)dr["fecha_modificacion"];

              }
          }
          return obj;
      }

      public List<ActivoFijoDTO> ListarBusqueda(string strDescripcion)
      {
          List<ActivoFijoDTO> Lista = new List<ActivoFijoDTO>();
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_LISTAR_BUSQUEDA);
          db.AddInParameter(dbCommand, "@descripcion", DbType.String, strDescripcion);
          using (IDataReader dr = db.ExecuteReader(dbCommand))
          {
              while (dr.Read())
              {
                  ActivoFijoDTO obj = new ActivoFijoDTO();

                  if (dr["id_activo_fijo"] != System.DBNull.Value)
                      obj.IdActivoFijo = (int)dr["id_activo_fijo"];

                  if (dr["codigo"] != System.DBNull.Value)
                      obj.Codigo = (string)dr["codigo"];

                  if (dr["observacion1"] != System.DBNull.Value)
                      obj.Observacion1 = (string)dr["observacion1"];

                  if (dr["fecha_baja"] != System.DBNull.Value)
                      obj.FechaBaja = (DateTime)dr["fecha_baja"];

                  if (dr["descripcion"] != System.DBNull.Value)
                      obj.Descripcion = (string)dr["descripcion"];

                  if (dr["marca"] != System.DBNull.Value)
                      obj.Marca = (string)dr["marca"];

                  if (dr["modelo"] != System.DBNull.Value)
                      obj.Modelo = (string)dr["modelo"];

                  if (dr["serie"] != System.DBNull.Value)
                      obj.Serie = (string)dr["serie"];

                  if (dr["estado"] != System.DBNull.Value)
                      obj.Estado = (string)dr["estado"];

                  if (dr["factura"] != System.DBNull.Value)
                      obj.Factura = (string)dr["factura"];

                  if (dr["fecha_factura"] != System.DBNull.Value)
                      obj.FechaFactura = (DateTime)dr["fecha_factura"];

                  if (dr["id_proveedor"] != System.DBNull.Value)
                      obj.IdProveedor = (int)dr["id_proveedor"];

                  if (dr["proveedor"] != System.DBNull.Value)
                      obj.Proveedor = (string)dr["proveedor"];

                  if (dr["ruc_proveedor"] != System.DBNull.Value)
                      obj.RucProveedor = (string)dr["ruc_proveedor"];

                  if (dr["precio_soles"] != System.DBNull.Value)
                      obj.PrecioSoles = (Decimal)dr["precio_soles"];

                  if (dr["precio_dolares"] != System.DBNull.Value)
                      obj.PrecioDolares = (Decimal)dr["precio_dolares"];

                  if (dr["observacion2"] != System.DBNull.Value)
                      obj.Observacion2 = (string)dr["observacion2"];

                  if (dr["local_origen"] != System.DBNull.Value)
                      obj.LocalOrigen = (string)dr["local_origen"];

                  if (dr["ubicacion"] != System.DBNull.Value)
                      obj.Ubicacion = (string)dr["ubicacion"];

                  if (dr["area_proyecto"] != System.DBNull.Value)
                      obj.AreaProyecto = (string)dr["area_proyecto"];

                  if (dr["usuario_asignacion"] != System.DBNull.Value)
                      obj.UsuarioAsignacion = (string)dr["usuario_asignacion"];

                  if (dr["id_usuario_creacion"] != System.DBNull.Value)
                      obj.IdUsuarioCreacion = (int)dr["id_usuario_creacion"];

                  if (dr["fecha_creacion"] != System.DBNull.Value)
                      obj.FechaCreacion = (DateTime)dr["fecha_creacion"];

                  if (dr["id_usuario_modificacion"] != System.DBNull.Value)
                      obj.IdUsuarioModificacion = (int)dr["id_usuario_modificacion"];

                  if (dr["fecha_modificacion"] != System.DBNull.Value)
                      obj.FechaModificacion = (DateTime)dr["fecha_modificacion"];


                  Lista.Add(obj);
              }
          }
          return Lista;
      }

      public int Agregar(ActivoFijoDTO obj)
      {
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_AGREGAR);
          db.AddInParameter(dbCommand, "@codigo", DbType.String, obj.Codigo);
          db.AddInParameter(dbCommand, "@observacion1", DbType.String, obj.Observacion1);
          db.AddInParameter(dbCommand, "@fecha_baja", DbType.DateTime, GetFechaValida( obj.FechaBaja) );
          db.AddInParameter(dbCommand, "@descripcion", DbType.String, obj.Descripcion);
          db.AddInParameter(dbCommand, "@marca", DbType.String, obj.Marca);
          db.AddInParameter(dbCommand, "@modelo", DbType.String, obj.Modelo);
          db.AddInParameter(dbCommand, "@serie", DbType.String, obj.Serie);
          db.AddInParameter(dbCommand, "@estado", DbType.String, obj.Estado);
          db.AddInParameter(dbCommand, "@factura", DbType.String, obj.Factura);
          db.AddInParameter(dbCommand, "@fecha_factura", DbType.DateTime, GetFechaValida( obj.FechaFactura) );
          db.AddInParameter(dbCommand, "@id_proveedor", DbType.Int32, obj.IdProveedor);
          db.AddInParameter(dbCommand, "@proveedor", DbType.String, obj.Proveedor);
          db.AddInParameter(dbCommand, "@ruc_proveedor", DbType.String, obj.RucProveedor);
          db.AddInParameter(dbCommand, "@precio_soles", DbType.Decimal, obj.PrecioSoles);
          db.AddInParameter(dbCommand, "@precio_dolares", DbType.Decimal, obj.PrecioDolares);
          db.AddInParameter(dbCommand, "@observacion2", DbType.String, obj.Observacion2);
          db.AddInParameter(dbCommand, "@local_origen", DbType.String, obj.LocalOrigen);
          db.AddInParameter(dbCommand, "@ubicacion", DbType.String, obj.Ubicacion);
          db.AddInParameter(dbCommand, "@area_proyecto", DbType.String, obj.AreaProyecto);
          db.AddInParameter(dbCommand, "@usuario_asignacion", DbType.String, obj.UsuarioAsignacion);
          db.AddInParameter(dbCommand, "@id_usuario_creacion", DbType.Int32, obj.IdUsuarioCreacion);
          db.AddInParameter(dbCommand, "@fecha_creacion", DbType.DateTime, GetFechaValida( obj.FechaCreacion) );
          int id = Convert.ToInt32(db.ExecuteScalar(dbCommand));
          return id;
      }

      public void Actualizar(ActivoFijoDTO obj)
      {
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_ACTUALIZAR);
          db.AddInParameter(dbCommand, "@id_activo_fijo", DbType.Int32, obj.IdActivoFijo);
          db.AddInParameter(dbCommand, "@codigo", DbType.String, obj.Codigo);
          db.AddInParameter(dbCommand, "@observacion1", DbType.String, obj.Observacion1);
          db.AddInParameter(dbCommand, "@fecha_baja", DbType.DateTime, GetFechaValida(obj.FechaBaja) );
          db.AddInParameter(dbCommand, "@descripcion", DbType.String, obj.Descripcion);
          db.AddInParameter(dbCommand, "@marca", DbType.String, obj.Marca);
          db.AddInParameter(dbCommand, "@modelo", DbType.String, obj.Modelo);
          db.AddInParameter(dbCommand, "@serie", DbType.String, obj.Serie);
          db.AddInParameter(dbCommand, "@estado", DbType.String, obj.Estado);
          db.AddInParameter(dbCommand, "@factura", DbType.String, obj.Factura);
          db.AddInParameter(dbCommand, "@fecha_factura", DbType.DateTime, GetFechaValida(obj.FechaFactura) );
          db.AddInParameter(dbCommand, "@id_proveedor", DbType.Int32, obj.IdProveedor);
          db.AddInParameter(dbCommand, "@proveedor", DbType.String, obj.Proveedor);
          db.AddInParameter(dbCommand, "@ruc_proveedor", DbType.String, obj.RucProveedor);
          db.AddInParameter(dbCommand, "@precio_soles", DbType.Decimal, obj.PrecioSoles);
          db.AddInParameter(dbCommand, "@precio_dolares", DbType.Decimal, obj.PrecioDolares);
          db.AddInParameter(dbCommand, "@observacion2", DbType.String, obj.Observacion2);
          db.AddInParameter(dbCommand, "@local_origen", DbType.String, obj.LocalOrigen);
          db.AddInParameter(dbCommand, "@ubicacion", DbType.String, obj.Ubicacion);
          db.AddInParameter(dbCommand, "@area_proyecto", DbType.String, obj.AreaProyecto);
          db.AddInParameter(dbCommand, "@usuario_asignacion", DbType.String, obj.UsuarioAsignacion);
          db.AddInParameter(dbCommand, "@id_usuario_modificacion", DbType.Int32, obj.IdUsuarioModificacion);
          db.AddInParameter(dbCommand, "@fecha_modificacion", DbType.DateTime, GetFechaValida(obj.FechaModificacion) );
          db.ExecuteNonQuery(dbCommand);
      }

      public void Eliminar(int IdActivoFijo)
      {
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_ELIMINAR);
          db.AddInParameter(dbCommand, "@id_activo_fijo", DbType.Int32, IdActivoFijo);
          db.ExecuteNonQuery(dbCommand);
      }

      protected object GetFechaValida(DateTime fecha) 
      {
          if (fecha.Year == 1) 
              return null; 
          else 
              return fecha; 
      } 

  }
}
