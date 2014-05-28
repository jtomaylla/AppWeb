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
  public class RecepcionLineaDAO
  {

      const string C_LISTAR = "USP_RecepcionLinea_Listar";
      const string C_ACTUALIZAR = "USP_RecepcionLinea_Actualizar";
      const string C_AGREGAR = "USP_RecepcionLinea_Agregar";
      const string C_ELIMINAR = "USP_RecepcionLinea_Eliminar";
      const string C_LISTAR_PENDIENTE_INVENTARIAR = "USP_RecepcionLinea_PendienteInventariar";
      const string C_LISTAR_POR_CLAVE = "USP_RecepcionLinea_ListarPorClave";
      public List<RecepcionLineaDTO> Listar()
      {
          List<RecepcionLineaDTO> Lista = new List<RecepcionLineaDTO>();
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_LISTAR);
          using (IDataReader dr = db.ExecuteReader(dbCommand)) 
          {
              while (dr.Read())
              {
                  RecepcionLineaDTO obj = new RecepcionLineaDTO();
                  if (dr["id_recepcion"] != System.DBNull.Value)
                      obj.IdRecepcion = (int)dr["id_recepcion"];
                  if (dr["id_recepcion_linea"] != System.DBNull.Value)
                      obj.IdRecepcionLinea = (int)dr["id_recepcion_linea"];
                  if (dr["id_orden_compra"] != System.DBNull.Value)
                      obj.IdOrdenCompra = (int)dr["id_orden_compra"];
                  if (dr["id_orden_compra_linea"] != System.DBNull.Value)
                      obj.IdOrdenCompraLinea = (int)dr["id_orden_compra_linea"];
                  if (dr["id_articulo"] != System.DBNull.Value)
                      obj.IdArticulo = (int)dr["id_articulo"];
                  if (dr["cantidad_recepcionada"] != System.DBNull.Value)
                      obj.CantidadRecepcionada = (Decimal)dr["cantidad_recepcionada"];
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

      public List<RecepcionLineaDTO> ListarPendienteDeInventariar()
      {
          List<RecepcionLineaDTO> Lista = new List<RecepcionLineaDTO>();
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_LISTAR_PENDIENTE_INVENTARIAR);
          using (IDataReader dr = db.ExecuteReader(dbCommand))
          {
              while (dr.Read())
              {
                  RecepcionLineaDTO obj = new RecepcionLineaDTO();
                  
                  if (dr["id_recepcion"] != System.DBNull.Value)
                      obj.IdRecepcion = (int)dr["id_recepcion"];
                  
                  if (dr["id_recepcion_linea"] != System.DBNull.Value)
                      obj.IdRecepcionLinea = (int)dr["id_recepcion_linea"];
                  
                  if (dr["id_orden_compra"] != System.DBNull.Value)
                      obj.IdOrdenCompra = (int)dr["id_orden_compra"];
                  
                  if (dr["id_orden_compra_linea"] != System.DBNull.Value)
                      obj.IdOrdenCompraLinea = (int)dr["id_orden_compra_linea"];
                  
                  if (dr["id_articulo"] != System.DBNull.Value)
                      obj.IdArticulo = (int)dr["id_articulo"];
                  
                  if (dr["cantidad_recepcionada"] != System.DBNull.Value)
                      obj.CantidadRecepcionada = (Decimal)dr["cantidad_recepcionada"];
                  
                  if (dr["anotaciones"] != System.DBNull.Value)
                      obj.Anotaciones = (string)dr["anotaciones"];

                  if (dr["estado"] != System.DBNull.Value)
                      obj.Estado = (string)dr["estado"];

                  if (dr["fecha_creacion"] != System.DBNull.Value)
                      obj.FechaCreacion = (DateTime)dr["fecha_creacion"];
                  
                  if (dr["id_usuario_creacion"] != System.DBNull.Value)
                      obj.IdUsuarioCreacion = (int)dr["id_usuario_creacion"];
                  
                  if (dr["fecha_modificacion"] != System.DBNull.Value)
                      obj.FechaModificacion = (DateTime)dr["fecha_modificacion"];
                  
                  if (dr["id_usuario_modificacion"] != System.DBNull.Value)
                      obj.IdUsuarioModificacion = (int)dr["id_usuario_modificacion"];

                  if (dr["fecha_recepcion"] != System.DBNull.Value)
                      obj.FechaRecepcion = (DateTime)dr["fecha_recepcion"];

                  if (dr["codigo_articulo"] != System.DBNull.Value)
                      obj.CodigoArticulo = (string)dr["codigo_articulo"];

                  if (dr["nombre_articulo"] != System.DBNull.Value)
                      obj.NombreArticulo = (string)dr["nombre_articulo"];

                  if (dr["razon_social"] != System.DBNull.Value)
                      obj.RazonSocial = (string)dr["razon_social"];

                  if (dr["numero_linea_oc"] != System.DBNull.Value)
                      obj.NumeroLineaOC = (int)dr["numero_linea_oc"];

                  
                  Lista.Add(obj);
              }
          }
          return Lista;
      }

      public RecepcionLineaDTO ListarPorClave(int IdRecepcionLinea)
      {
          RecepcionLineaDTO obj = null;
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_LISTAR_POR_CLAVE);
          db.AddInParameter(dbCommand, "@id_recepcion_linea", DbType.Int32, IdRecepcionLinea);

          using (IDataReader dr = db.ExecuteReader(dbCommand))
          {
              if (dr.Read())
              {
                  obj = new RecepcionLineaDTO();

                  if (dr["id_recepcion"] != System.DBNull.Value)
                      obj.IdRecepcion = (int)dr["id_recepcion"];

                  if (dr["id_recepcion_linea"] != System.DBNull.Value)
                      obj.IdRecepcionLinea = (int)dr["id_recepcion_linea"];

                  if (dr["id_orden_compra"] != System.DBNull.Value)
                      obj.IdOrdenCompra = (int)dr["id_orden_compra"];

                  if (dr["id_orden_compra_linea"] != System.DBNull.Value)
                      obj.IdOrdenCompraLinea = (int)dr["id_orden_compra_linea"];

                  if (dr["id_articulo"] != System.DBNull.Value)
                      obj.IdArticulo = (int)dr["id_articulo"];

                  if (dr["cantidad_recepcionada"] != System.DBNull.Value)
                      obj.CantidadRecepcionada = (Decimal)dr["cantidad_recepcionada"];

                  if (dr["anotaciones"] != System.DBNull.Value)
                      obj.Anotaciones = (string)dr["anotaciones"];

                  if (dr["estado"] != System.DBNull.Value)
                      obj.Estado = (string)dr["estado"];

                  if (dr["fecha_creacion"] != System.DBNull.Value)
                      obj.FechaCreacion = (DateTime)dr["fecha_creacion"];

                  if (dr["id_usuario_creacion"] != System.DBNull.Value)
                      obj.IdUsuarioCreacion = (int)dr["id_usuario_creacion"];

                  if (dr["fecha_modificacion"] != System.DBNull.Value)
                      obj.FechaModificacion = (DateTime)dr["fecha_modificacion"];

                  if (dr["id_usuario_modificacion"] != System.DBNull.Value)
                      obj.IdUsuarioModificacion = (int)dr["id_usuario_modificacion"];

                  if (dr["fecha_recepcion"] != System.DBNull.Value)
                      obj.FechaRecepcion = (DateTime)dr["fecha_recepcion"];

                  if (dr["codigo_articulo"] != System.DBNull.Value)
                      obj.CodigoArticulo = (string)dr["codigo_articulo"];

                  if (dr["nombre_articulo"] != System.DBNull.Value)
                      obj.NombreArticulo = (string)dr["nombre_articulo"];

                  if (dr["razon_social"] != System.DBNull.Value)
                      obj.RazonSocial = (string)dr["razon_social"];

                  if (dr["numero_linea_oc"] != System.DBNull.Value)
                      obj.NumeroLineaOC = (int)dr["numero_linea_oc"];

              }
          }

          return obj;
      }

      public int Agregar(RecepcionLineaDTO obj)
      {
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_AGREGAR);
          db.AddInParameter(dbCommand, "@id_recepcion", DbType.Int32, obj.IdRecepcion);
          //db.AddInParameter(dbCommand, "@id_recepcion_linea", DbType.Int32, obj.IdRecepcionLinea);
          db.AddInParameter(dbCommand, "@id_orden_compra", DbType.Int32, obj.IdOrdenCompra);
          db.AddInParameter(dbCommand, "@id_orden_compra_linea", DbType.Int32, obj.IdOrdenCompraLinea);
          db.AddInParameter(dbCommand, "@id_articulo", DbType.Int32, obj.IdArticulo);
          db.AddInParameter(dbCommand, "@cantidad_recepcionada", DbType.Decimal, obj.CantidadRecepcionada);
          db.AddInParameter(dbCommand, "@anotaciones", DbType.String, obj.Anotaciones);
          db.AddInParameter(dbCommand, "@estado", DbType.String, obj.Estado);

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

      public void Actualizar(RecepcionLineaDTO obj)
      {
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_ACTUALIZAR);
          db.AddInParameter(dbCommand, "@id_recepcion", DbType.Int32, obj.IdRecepcion);
          db.AddInParameter(dbCommand, "@id_recepcion_linea", DbType.Int32, obj.IdRecepcionLinea);
          db.AddInParameter(dbCommand, "@id_orden_compra", DbType.Int32, obj.IdOrdenCompra);
          db.AddInParameter(dbCommand, "@id_orden_compra_linea", DbType.Int32, obj.IdOrdenCompraLinea);
          db.AddInParameter(dbCommand, "@id_articulo", DbType.Int32, obj.IdArticulo);
          db.AddInParameter(dbCommand, "@cantidad_recepcionada", DbType.Decimal, obj.CantidadRecepcionada);
          db.AddInParameter(dbCommand, "@anotaciones", DbType.String, obj.Anotaciones);
          db.AddInParameter(dbCommand, "@estado", DbType.String, obj.Estado);

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
