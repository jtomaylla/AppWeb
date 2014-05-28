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
  public class PedidoDetalleDAO
  {

      const string C_LISTAR = "USP_PedidoDetalle_Listar";
      const string C_ACTUALIZAR = "USP_PedidoDetalle_Actualizar";
      const string C_AGREGAR = "USP_PedidoDetalle_Agregar";
      const string C_ELIMINAR = "USP_PedidoDetalle_Eliminar";
      const string C_LISTAR_POR_CLAVE = "USP_PedidoDetalle_ListarPorClave";
      const string C_LISTAR_POR_PEDIDO = "USP_PedidoDetalle_ListarPorPedido";

      public List<PedidoDetalleDTO> Listar()
      {
          List<PedidoDetalleDTO> Lista = new List<PedidoDetalleDTO>();
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_LISTAR);
          using (IDataReader dr = db.ExecuteReader(dbCommand)) 
          {
              while (dr.Read())
              {
                  PedidoDetalleDTO obj = new PedidoDetalleDTO();
                  if (dr["id_pedido_detalle"] != System.DBNull.Value)
                      obj.IdPedidoDetalle = (int)dr["id_pedido_detalle"];

                  if (dr["id_pedido"] != System.DBNull.Value)
                      obj.IdPedido = (int)dr["id_pedido"];
                  if (dr["id_tipo_articulo"] != System.DBNull.Value)
                      obj.IdTipoArticulo = (int)dr["id_tipo_articulo"];
                  if (dr["id_articulo_inventario"] != System.DBNull.Value)
                      obj.IdArticuloInventario = (int)dr["id_articulo_inventario"];
                  if (dr["numero_linea"] != System.DBNull.Value)
                      obj.NumeroLinea = (int)dr["numero_linea"];
                  if (dr["descripcion_linea"] != System.DBNull.Value)
                      obj.DescripcionLinea = (string)dr["descripcion_linea"];
                  if (dr["id_unidad_medida"] != System.DBNull.Value)
                      obj.IdUnidadMedida = (int)dr["id_unidad_medida"];
                  if (dr["cantidad"] != System.DBNull.Value)
                      obj.Cantidad = (Decimal)dr["cantidad"];
                  if (dr["precio_referencial"] != System.DBNull.Value)
                      obj.PrecioReferencial = (Decimal)dr["precio_referencial"];
                  if (dr["importe"] != System.DBNull.Value)
                      obj.Importe = (Decimal)dr["importe"];
                  if (dr["fecha_necesidad"] != System.DBNull.Value)
                      obj.FechaNecesidad = (DateTime)dr["fecha_necesidad"];
                  if (dr["id_proveedor"] != System.DBNull.Value)
                      obj.IdProveedor = (int)dr["id_proveedor"];
                  if (dr["cancelado"] != System.DBNull.Value)
                      obj.Cancelado = (string)dr["cancelado"];
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

      public List<PedidoDetalleDTO> ListarPorPedido(int IdPedido)
      {
          List<PedidoDetalleDTO> Lista = new List<PedidoDetalleDTO>();
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_LISTAR_POR_PEDIDO);
          db.AddInParameter(dbCommand, "@id_pedido", DbType.Int32, IdPedido);

          using (IDataReader dr = db.ExecuteReader(dbCommand))
          {
              while (dr.Read())
              {
                  PedidoDetalleDTO obj = new PedidoDetalleDTO();
                  if (dr["id_pedido_detalle"] != System.DBNull.Value)
                      obj.IdPedidoDetalle = (int)dr["id_pedido_detalle"];

                  if (dr["id_pedido"] != System.DBNull.Value)
                      obj.IdPedido = (int)dr["id_pedido"];
                  if (dr["id_tipo_articulo"] != System.DBNull.Value)
                      obj.IdTipoArticulo = (int)dr["id_tipo_articulo"];
                  if (dr["id_articulo_inventario"] != System.DBNull.Value)
                      obj.IdArticuloInventario = (int)dr["id_articulo_inventario"];
                  if (dr["numero_linea"] != System.DBNull.Value)
                      obj.NumeroLinea = (int)dr["numero_linea"];
                  if (dr["descripcion_linea"] != System.DBNull.Value)
                      obj.DescripcionLinea = (string)dr["descripcion_linea"];
                  if (dr["id_unidad_medida"] != System.DBNull.Value)
                      obj.IdUnidadMedida = (int)dr["id_unidad_medida"];
                  if (dr["cantidad"] != System.DBNull.Value)
                      obj.Cantidad = (Decimal)dr["cantidad"];
                  if (dr["precio_referencial"] != System.DBNull.Value)
                      obj.PrecioReferencial = (Decimal)dr["precio_referencial"];
                  if (dr["importe"] != System.DBNull.Value)
                      obj.Importe = (Decimal)dr["importe"];
                  if (dr["fecha_necesidad"] != System.DBNull.Value)
                      obj.FechaNecesidad = (DateTime)dr["fecha_necesidad"];
                  if (dr["id_proveedor"] != System.DBNull.Value)
                      obj.IdProveedor = (int)dr["id_proveedor"];
                  if (dr["cancelado"] != System.DBNull.Value)
                      obj.Cancelado = (string)dr["cancelado"];
                  if (dr["id_usuario_creacion"] != System.DBNull.Value)
                      obj.IdUsuarioCreacion = (int)dr["id_usuario_creacion"];
                  if (dr["fecha_creacion"] != System.DBNull.Value)
                      obj.FechaCreacion = (DateTime)dr["fecha_creacion"];
                  if (dr["id_usuario_modificacion"] != System.DBNull.Value)
                      obj.IdUsuarioModificacion = (int)dr["id_usuario_modificacion"];
                  if (dr["fecha_modificacion"] != System.DBNull.Value)
                      obj.FechaModificacion = (DateTime)dr["fecha_modificacion"];

                  if (dr["codigo_articulo"] != System.DBNull.Value) obj.CodigoArticulo = (string)dr["codigo_articulo"];
                  if (dr["nombre_unidad_medida"] != System.DBNull.Value) obj.NombreUnidadMedida = (string)dr["nombre_unidad_medida"];
                  if (dr["orden_compra"] != System.DBNull.Value) obj.OrdenCompra = (string)dr["orden_compra"];
                  if (dr["estado_pedido"] != System.DBNull.Value) obj.EstadoPedido = (string)dr["estado_pedido"];


                  Lista.Add(obj);
              }
          }
          return Lista;
      }

      public PedidoDetalleDTO ListarPorClave(int IdPedidoDetalle)
      {
          PedidoDetalleDTO obj = null;
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_LISTAR_POR_CLAVE);
          db.AddInParameter(dbCommand, "@id_pedido_detalle", DbType.Int32, IdPedidoDetalle);

          using (IDataReader dr = db.ExecuteReader(dbCommand))
          {
              if (dr.Read())
              {
                  obj = new PedidoDetalleDTO();
                  if (dr["id_pedido_detalle"] != System.DBNull.Value)
                      obj.IdPedidoDetalle = (int)dr["id_pedido_detalle"];
                  if (dr["id_pedido"] != System.DBNull.Value)
                      obj.IdPedido = (int)dr["id_pedido"];
                  if (dr["id_tipo_articulo"] != System.DBNull.Value)
                      obj.IdTipoArticulo = (int)dr["id_tipo_articulo"];
                  if (dr["id_articulo_inventario"] != System.DBNull.Value)
                      obj.IdArticuloInventario = (int)dr["id_articulo_inventario"];
                  if (dr["numero_linea"] != System.DBNull.Value)
                      obj.NumeroLinea = (int)dr["numero_linea"];
                  if (dr["descripcion_linea"] != System.DBNull.Value)
                      obj.DescripcionLinea = (string)dr["descripcion_linea"];
                  if (dr["id_unidad_medida"] != System.DBNull.Value)
                      obj.IdUnidadMedida = (int)dr["id_unidad_medida"];
                  if (dr["cantidad"] != System.DBNull.Value)
                      obj.Cantidad = (Decimal)dr["cantidad"];
                  if (dr["precio_referencial"] != System.DBNull.Value)
                      obj.PrecioReferencial = (Decimal)dr["precio_referencial"];
                  if (dr["importe"] != System.DBNull.Value)
                      obj.Importe = (Decimal)dr["importe"];
                  if (dr["fecha_necesidad"] != System.DBNull.Value)
                      obj.FechaNecesidad = (DateTime)dr["fecha_necesidad"];
                  if (dr["id_proveedor"] != System.DBNull.Value)
                      obj.IdProveedor = (int)dr["id_proveedor"];
                  if (dr["cancelado"] != System.DBNull.Value)
                      obj.Cancelado = (string)dr["cancelado"];
                  if (dr["id_usuario_creacion"] != System.DBNull.Value)
                      obj.IdUsuarioCreacion = (int)dr["id_usuario_creacion"];
                  if (dr["fecha_creacion"] != System.DBNull.Value)
                      obj.FechaCreacion = (DateTime)dr["fecha_creacion"];
                  if (dr["id_usuario_modificacion"] != System.DBNull.Value)
                      obj.IdUsuarioModificacion = (int)dr["id_usuario_modificacion"];
                  if (dr["fecha_modificacion"] != System.DBNull.Value)
                      obj.FechaModificacion = (DateTime)dr["fecha_modificacion"];

                  if (dr["codigo_articulo"] != System.DBNull.Value) obj.CodigoArticulo = (string)dr["codigo_articulo"];
                  if (dr["nombre_unidad_medida"] != System.DBNull.Value) obj.NombreUnidadMedida = (string)dr["nombre_unidad_medida"];
              }
          }
          return obj;
      }

      public int Agregar(PedidoDetalleDTO obj)
      {
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_AGREGAR);
          db.AddInParameter(dbCommand, "@id_pedido", DbType.Int32, obj.IdPedido);
          db.AddInParameter(dbCommand, "@id_tipo_articulo", DbType.Int32, obj.IdTipoArticulo);
          db.AddInParameter(dbCommand, "@id_articulo_inventario", DbType.Int32, obj.IdArticuloInventario);
          db.AddInParameter(dbCommand, "@numero_linea", DbType.Int32, obj.NumeroLinea);
          db.AddInParameter(dbCommand, "@descripcion_linea", DbType.String, obj.DescripcionLinea);
          db.AddInParameter(dbCommand, "@id_unidad_medida", DbType.Int32, obj.IdUnidadMedida);
          db.AddInParameter(dbCommand, "@cantidad", DbType.Decimal, obj.Cantidad);
          db.AddInParameter(dbCommand, "@precio_referencial", DbType.Decimal , obj.PrecioReferencial);
          db.AddInParameter(dbCommand, "@importe", DbType.Decimal , obj.Importe);

          if (obj.FechaNecesidad.Year == 1)
              db.AddInParameter(dbCommand, "@fecha_necesidad", DbType.DateTime, null);
          else
              db.AddInParameter(dbCommand, "@fecha_necesidad", DbType.DateTime, obj.FechaNecesidad);

          db.AddInParameter(dbCommand, "@id_proveedor", DbType.Int32, obj.IdProveedor);
          db.AddInParameter(dbCommand, "@cancelado", DbType.String, obj.Cancelado);
          db.AddInParameter(dbCommand, "@id_usuario_creacion", DbType.Int32, obj.IdUsuarioCreacion);
          
          if (obj.FechaCreacion.Year == 1)
             db.AddInParameter(dbCommand, "@fecha_creacion", DbType.DateTime, null);
          else
             db.AddInParameter(dbCommand, "@fecha_creacion", DbType.DateTime, obj.FechaCreacion);

          db.AddInParameter(dbCommand, "@id_usuario_modificacion", DbType.Int32, obj.IdUsuarioModificacion);
          
          if (obj.FechaModificacion.Year == 1)
              db.AddInParameter(dbCommand, "@fecha_modificacion", DbType.DateTime, null);
          else
              db.AddInParameter(dbCommand, "@fecha_modificacion", DbType.DateTime, obj.FechaModificacion);
          
          int id = Convert.ToInt32( db.ExecuteScalar(dbCommand));

          return id;

      }

      public void Actualizar(PedidoDetalleDTO obj)
      {
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_ACTUALIZAR);
          db.AddInParameter(dbCommand, "@id_pedido_detalle", DbType.Int32, obj.IdPedidoDetalle);
          db.AddInParameter(dbCommand, "@id_pedido", DbType.Int32, obj.IdPedido);
          db.AddInParameter(dbCommand, "@id_tipo_articulo", DbType.Int32, obj.IdTipoArticulo);
          db.AddInParameter(dbCommand, "@id_articulo_inventario", DbType.Int32, obj.IdArticuloInventario);
          db.AddInParameter(dbCommand, "@numero_linea", DbType.Int32, obj.NumeroLinea);
          db.AddInParameter(dbCommand, "@descripcion_linea", DbType.String, obj.DescripcionLinea);
          db.AddInParameter(dbCommand, "@id_unidad_medida", DbType.Int32, obj.IdUnidadMedida);
          db.AddInParameter(dbCommand, "@cantidad", DbType.Decimal, obj.Cantidad);
          db.AddInParameter(dbCommand, "@precio_referencial", DbType.Decimal , obj.PrecioReferencial);
          db.AddInParameter(dbCommand, "@importe", DbType.Decimal , obj.Importe);

          if (obj.FechaNecesidad.Year == 1)
              db.AddInParameter(dbCommand, "@fecha_necesidad", DbType.DateTime, null);
          else
              db.AddInParameter(dbCommand, "@fecha_necesidad", DbType.DateTime, obj.FechaNecesidad);

          db.AddInParameter(dbCommand, "@id_proveedor", DbType.Int32, obj.IdProveedor);
          db.AddInParameter(dbCommand, "@cancelado", DbType.String, obj.Cancelado);

          db.AddInParameter(dbCommand, "@cantidad_despacho", DbType.Decimal, obj.CantidadDespacho);

          db.AddInParameter(dbCommand, "@id_usuario_creacion", DbType.Int32, obj.IdUsuarioCreacion);
          
          if (obj.FechaCreacion.Year == 1)
             db.AddInParameter(dbCommand, "@fecha_creacion", DbType.DateTime, null);
          else
             db.AddInParameter(dbCommand, "@fecha_creacion", DbType.DateTime, obj.FechaCreacion);

          db.AddInParameter(dbCommand, "@id_usuario_modificacion", DbType.Int32, obj.IdUsuarioModificacion);
          
          if (obj.FechaModificacion.Year == 1)
              db.AddInParameter(dbCommand, "@fecha_modificacion", DbType.DateTime, null);
          else
              db.AddInParameter(dbCommand, "@fecha_modificacion", DbType.DateTime, obj.FechaModificacion);

          db.ExecuteNonQuery(dbCommand);
      }

      public void Eliminar(int IdPedidoDetalle)
      {
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_ELIMINAR);
          db.AddInParameter(dbCommand, "@id_pedido_detalle", DbType.Int32, IdPedidoDetalle);
          db.ExecuteNonQuery(dbCommand);
      }
  }
}
