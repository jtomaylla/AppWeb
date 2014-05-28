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
  public class RecepcionDAO
  {

      const string C_LISTAR = "USP_Recepcion_Listar";
      const string C_ACTUALIZAR = "USP_Recepcion_Actualizar";
      const string C_AGREGAR = "USP_Recepcion_Agregar";
      const string C_ELIMINAR = "USP_Recepcion_Eliminar";

      const string C_LISTAR_POR_CLAVE = "USP_Recepcion_ListarPorClave";

      const string C_LISTAR_POR_DESPACHAR = "USP_Recepcion_ListarPorDespachar";

      public List<RecepcionDTO> Listar()
      {
          List<RecepcionDTO> Lista = new List<RecepcionDTO>();
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_LISTAR);
          using (IDataReader dr = db.ExecuteReader(dbCommand)) 
          {
              while (dr.Read())
              {
                  RecepcionDTO obj = new RecepcionDTO();
                  if (dr["id_recepcion"] != System.DBNull.Value)
                      obj.IdRecepcion = (int)dr["id_recepcion"];
                  if (dr["id_proveedor"] != System.DBNull.Value)
                      obj.IdProveedor = (int)dr["id_proveedor"];
                  if (dr["fecha_recepcion"] != System.DBNull.Value)
                      obj.FechaRecepcion = (DateTime)dr["fecha_recepcion"];
                  if (dr["numero_recibo"] != System.DBNull.Value)
                      obj.NumeroRecibo = (string)dr["numero_recibo"];
                  if (dr["id_orden_compra"] != System.DBNull.Value)
                      obj.IdOrdenCompra = (int)dr["id_orden_compra"];
                  if (dr["anotaciones"] != System.DBNull.Value)
                      obj.Anotaciones = (string)dr["anotaciones"];
                  if (dr["fecha_creacion"] != System.DBNull.Value)
                      obj.FechaCreacion = (DateTime)dr["fecha_creacion"];
                  if (dr["id_usuario_creacion"] != System.DBNull.Value)
                      obj.IdUsuarioCreacion = (int)dr["id_usuario_creacion"];
                  if (dr["fecha_modificacion"] != System.DBNull.Value)
                      obj.FechaModificacion = (DateTime)dr["fecha_modificacion"];
                  if (dr["id_usuario_modificacion"] != System.DBNull.Value)
                      obj.IdUsuarioModificacion = (int)dr["id_usuario_modificacion"];

                  Lista.Add(obj);
              }
          }
          return Lista;
      }

      public List<RecepcionDTO> ListarPorDespachar()
      {
          List<RecepcionDTO> Lista = new List<RecepcionDTO>();
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_LISTAR_POR_DESPACHAR);
          using (IDataReader dr = db.ExecuteReader(dbCommand))
          {
              while (dr.Read())
              {
                  RecepcionDTO obj = new RecepcionDTO();
                  
                  if (dr["id_recepcion"] != System.DBNull.Value)
                      obj.IdRecepcion = (int)dr["id_recepcion"];
                  
                  if (dr["id_proveedor"] != System.DBNull.Value)
                      obj.IdProveedor = (int)dr["id_proveedor"];
                  
                  if (dr["fecha_recepcion"] != System.DBNull.Value)
                      obj.FechaRecepcion = (DateTime)dr["fecha_recepcion"];
                  
                  if (dr["numero_recibo"] != System.DBNull.Value)
                      obj.NumeroRecibo = (string)dr["numero_recibo"];
                  
                  if (dr["id_orden_compra"] != System.DBNull.Value)
                      obj.IdOrdenCompra = (int)dr["id_orden_compra"];

                  if (dr["id_sede"] != System.DBNull.Value)
                      obj.IdSede = (int)dr["id_sede"];

                  if (dr["id_proyecto"] != System.DBNull.Value)
                      obj.IdProyecto = (int)dr["id_proyecto"];
                  
                  if (dr["anotaciones"] != System.DBNull.Value)
                      obj.Anotaciones = (string)dr["anotaciones"];
                  
                  if (dr["fecha_creacion"] != System.DBNull.Value)
                      obj.FechaCreacion = (DateTime)dr["fecha_creacion"];
                  
                  if (dr["id_usuario_creacion"] != System.DBNull.Value)
                      obj.IdUsuarioCreacion = (int)dr["id_usuario_creacion"];

                  if (dr["fecha_modificacion"] != System.DBNull.Value)
                      obj.FechaModificacion = (DateTime)dr["fecha_modificacion"];
                  
                  if (dr["id_usuario_modificacion"] != System.DBNull.Value)
                      obj.IdUsuarioModificacion = (int)dr["id_usuario_modificacion"];

                  if (dr["razon_social"] != System.DBNull.Value)
                      obj.RazonSocial = (string)dr["razon_social"];

                  if (dr["nombre_proyecto"] != System.DBNull.Value)
                      obj.NombreProyecto = (string)dr["nombre_proyecto"];

                  Lista.Add(obj);
              }
          }
          return Lista;
      }

      public RecepcionDTO ListarPorClave(int IdRecepcion)
      {
          RecepcionDTO obj = null;
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_LISTAR_POR_CLAVE);
          db.AddInParameter(dbCommand, "@id_recepcion", DbType.Int32, IdRecepcion);

          using (IDataReader dr = db.ExecuteReader(dbCommand))
          {
              if (dr.Read())
              {
                  obj = new RecepcionDTO();
                  
                  if (dr["id_recepcion"] != System.DBNull.Value)
                      obj.IdRecepcion = (int)dr["id_recepcion"];

                  if (dr["id_proveedor"] != System.DBNull.Value)
                      obj.IdProveedor = (int)dr["id_proveedor"];
                  
                  if (dr["fecha_recepcion"] != System.DBNull.Value)
                      obj.FechaRecepcion = (DateTime)dr["fecha_recepcion"];
                  
                  if (dr["numero_recibo"] != System.DBNull.Value)
                      obj.NumeroRecibo = (string)dr["numero_recibo"];

                  if (dr["numero_factura"] != System.DBNull.Value)
                      obj.NumeroFactura = (string)dr["numero_factura"];

                  if (dr["anotaciones"] != System.DBNull.Value)
                      obj.Anotaciones = (string)dr["anotaciones"];

                  if (dr["id_orden_compra"] != System.DBNull.Value)
                      obj.IdOrdenCompra = (int)dr["id_orden_compra"];

                  if (dr["id_sede"] != System.DBNull.Value)
                      obj.IdSede = (int)dr["id_sede"];

                  if (dr["id_proyecto"] != System.DBNull.Value)
                      obj.IdProyecto = (int)dr["id_proyecto"];
                  
                  if (dr["fecha_creacion"] != System.DBNull.Value)
                      obj.FechaCreacion = (DateTime)dr["fecha_creacion"];
                  
                  if (dr["id_usuario_creacion"] != System.DBNull.Value)
                      obj.IdUsuarioCreacion = (int)dr["id_usuario_creacion"];
                  
                  if (dr["fecha_modificacion"] != System.DBNull.Value)
                      obj.FechaModificacion = (DateTime)dr["fecha_modificacion"];
                  
                  if (dr["id_usuario_modificacion"] != System.DBNull.Value)
                      obj.IdUsuarioModificacion = (int)dr["id_usuario_modificacion"];

               }
          }
          return obj;
      }

      public int Agregar(RecepcionDTO obj)
      {
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_AGREGAR);
          db.AddInParameter(dbCommand, "@id_proveedor", DbType.Int32, obj.IdProveedor);

          if (obj.FechaRecepcion.Year == 1)
              db.AddInParameter(dbCommand, "@fecha_recepcion", DbType.DateTime, null);
          else
              db.AddInParameter(dbCommand, "@fecha_recepcion", DbType.DateTime, obj.FechaRecepcion);

          db.AddInParameter(dbCommand, "@numero_recibo", DbType.String, obj.NumeroRecibo);
          db.AddInParameter(dbCommand, "@numero_factura", DbType.String, obj.NumeroFactura);
          db.AddInParameter(dbCommand, "@anotaciones", DbType.String, obj.Anotaciones);
          db.AddInParameter(dbCommand, "@id_orden_compra", DbType.Int32, obj.IdOrdenCompra);
          db.AddInParameter(dbCommand, "@tipo_recepcion", DbType.String, obj.TipoRecepcion);

          db.AddInParameter(dbCommand, "@id_sede", DbType.Int32, obj.IdSede);
          db.AddInParameter(dbCommand, "@id_proyecto", DbType.Int32, obj.IdProyecto);

          if (obj.FechaCreacion.Year == 1)
              db.AddInParameter(dbCommand, "@fecha_creacion", DbType.DateTime, null);
          else
              db.AddInParameter(dbCommand, "@fecha_creacion", DbType.DateTime, obj.FechaCreacion);

          db.AddInParameter(dbCommand, "@id_usuario_creacion", DbType.Int32, obj.IdUsuarioCreacion);

          if (obj.FechaModificacion.Year == 1)
              db.AddInParameter(dbCommand, "@fecha_modificacion", DbType.DateTime, null);
          else
              db.AddInParameter(dbCommand, "@fecha_modificacion", DbType.DateTime, obj.FechaModificacion);

          db.AddInParameter(dbCommand, "@id_usuario_modificacion", DbType.Int32, obj.IdUsuarioModificacion);
          int id = Convert.ToInt32(db.ExecuteScalar(dbCommand));
          return id;
      }

      public void Actualizar(RecepcionDTO obj)
      {
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_ACTUALIZAR);
          db.AddInParameter(dbCommand, "@id_recepcion", DbType.Int32, obj.IdRecepcion);
          db.AddInParameter(dbCommand, "@id_proveedor", DbType.Int32, obj.IdProveedor);
          db.AddInParameter(dbCommand, "@fecha_recepcion", DbType.DateTime, obj.FechaRecepcion);
          db.AddInParameter(dbCommand, "@numero_recibo", DbType.String, obj.NumeroRecibo);
          db.AddInParameter(dbCommand, "@id_orden_compra", DbType.Int32, obj.IdOrdenCompra);
          db.AddInParameter(dbCommand, "@anotaciones", DbType.String, obj.Anotaciones);
          db.AddInParameter(dbCommand, "@fecha_creacion", DbType.DateTime, obj.FechaCreacion);
          db.AddInParameter(dbCommand, "@id_usuario_creacion", DbType.Int32, obj.IdUsuarioCreacion);
          db.AddInParameter(dbCommand, "@fecha_modificacion", DbType.DateTime, obj.FechaModificacion);
          db.AddInParameter(dbCommand, "@id_usuario_modificacion", DbType.Int32, obj.IdUsuarioModificacion);
          db.ExecuteNonQuery(dbCommand);
      }

      public void Eliminar(int IdRecepcion)
      {
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_ELIMINAR);
          db.AddInParameter(dbCommand, "@id_recepcion", DbType.Int32, IdRecepcion);
          db.ExecuteNonQuery(dbCommand);
      }
  }
}
