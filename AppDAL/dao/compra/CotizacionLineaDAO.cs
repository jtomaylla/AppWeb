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
  public class CotizacionLineaDAO
  {

      const string C_LISTAR = "USP_CotizacionLinea_Listar";
      const string C_ACTUALIZAR = "USP_CotizacionLinea_Actualizar";
      const string C_AGREGAR = "USP_CotizacionLinea_Agregar";
      const string C_ELIMINAR = "USP_CotizacionLinea_Eliminar";

      const string C_LISTAR_POR_COTIZACION = "USP_CotizacionLinea_ListarPorCotizacion";
      const string C_LISTAR_POR_CLAVE = "USP_CotizacionLinea_ListarPorClave";
      
      public List<CotizacionLineaDTO> ListarPorCotizacion(int IdCotizacion)
      {
          List<CotizacionLineaDTO> Lista = new List<CotizacionLineaDTO>();
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_LISTAR_POR_COTIZACION);
          db.AddInParameter(dbCommand, "@id_cotizacion", DbType.Int32, IdCotizacion);
          using (IDataReader dr = db.ExecuteReader(dbCommand)) 
          {
              while (dr.Read())
              {
                  CotizacionLineaDTO obj = new CotizacionLineaDTO();

                  if (dr["id_cotizacion"] != System.DBNull.Value) obj.IdCotizacion = (int)dr["id_cotizacion"];
                  if (dr["id_cotizacion_linea"] != System.DBNull.Value) obj.IdCotizacionLinea = (int)dr["id_cotizacion_linea"];
                  if (dr["id_pedido_linea"] != System.DBNull.Value) obj.IdPedidoLinea = (int)dr["id_pedido_linea"];
                  if (dr["numero_linea"] != System.DBNull.Value)
                      obj.NumeroLinea = (int)dr["numero_linea"];
                  if (dr["id_unidad_medida"] != System.DBNull.Value)
                      obj.IdUnidadMedida = (int)dr["id_unidad_medida"];
                  if (dr["id_articulo"] != System.DBNull.Value)
                      obj.IdArticulo = (int)dr["id_articulo"];
                  if (dr["descripcion_linea"] != System.DBNull.Value)
                      obj.DescripcionLinea = (string)dr["descripcion_linea"];
                  if (dr["precio"] != System.DBNull.Value)
                      obj.Precio = (Decimal)dr["precio"];
                  if (dr["cantidad"] != System.DBNull.Value)
                      obj.Cantidad = (Decimal)dr["cantidad"];
                  if (dr["importe"] != System.DBNull.Value)
                      obj.Importe = (Decimal)dr["importe"];
                  if (dr["flag_igv"] != System.DBNull.Value)
                      obj.FlagIgv = (string)dr["flag_igv"];
                  if (dr["id_proveedor_seleccionado"] != System.DBNull.Value)
                      obj.IdProveedorSeleccionado = (int)dr["id_proveedor_seleccionado"];

                  if (dr["dias_entrega"] != System.DBNull.Value)
                      obj.DiasEntrega = (int)dr["dias_entrega"];
                  
                  if (dr["id_usuario_creacion"] != System.DBNull.Value)
                      obj.IdUsuarioCreacion = (int)dr["id_usuario_creacion"];
                  if (dr["fecha_creacion"] != System.DBNull.Value)
                      obj.FechaCreacion = (DateTime)dr["fecha_creacion"];
                  if (dr["id_usuario_modificacion"] != System.DBNull.Value)
                      obj.IdUsuarioModificacion = (int)dr["id_usuario_modificacion"];
                  if (dr["fecha_modificacion"] != System.DBNull.Value)
                      obj.FechaModificacion = (DateTime)dr["fecha_modificacion"];

                  if (dr["codigo_articulo"] != System.DBNull.Value) obj.CodigoArticulo = (string)dr["codigo_articulo"];
                  if (dr["nombre_corto_unidad_medida"] != System.DBNull.Value) obj.NombreCortoUnidadMedida = (string)dr["nombre_corto_unidad_medida"];
                  if (dr["razon_social"] != System.DBNull.Value) obj.RazonSocial = (string)dr["razon_social"];

                  Lista.Add(obj);
              }
          }
          return Lista;
      }

      public CotizacionLineaDTO ListarPorClave(int IdCotizacionLinea)
      {
          CotizacionLineaDTO obj = null;
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_LISTAR_POR_CLAVE);
          db.AddInParameter(dbCommand, "@id_cotizacion_linea", DbType.Int32, IdCotizacionLinea);
          using (IDataReader dr = db.ExecuteReader(dbCommand))
          {
              if (dr.Read())
              {
                  obj = new CotizacionLineaDTO();

                  if (dr["id_cotizacion"] != System.DBNull.Value) obj.IdCotizacion = (int)dr["id_cotizacion"];
                  if (dr["id_cotizacion_linea"] != System.DBNull.Value) obj.IdCotizacionLinea = (int)dr["id_cotizacion_linea"];
                  if (dr["id_pedido_linea"] != System.DBNull.Value) obj.IdPedidoLinea = (int)dr["id_pedido_linea"];
                  if (dr["numero_linea"] != System.DBNull.Value)
                      obj.NumeroLinea = (int)dr["numero_linea"];
                  if (dr["id_unidad_medida"] != System.DBNull.Value)
                      obj.IdUnidadMedida = (int)dr["id_unidad_medida"];
                  if (dr["id_articulo"] != System.DBNull.Value)
                      obj.IdArticulo = (int)dr["id_articulo"];
                  if (dr["descripcion_linea"] != System.DBNull.Value)
                      obj.DescripcionLinea = (string)dr["descripcion_linea"];
                  if (dr["precio"] != System.DBNull.Value)
                      obj.Precio = (Decimal)dr["precio"];
                  if (dr["cantidad"] != System.DBNull.Value)
                      obj.Cantidad = (Decimal)dr["cantidad"];
                  if (dr["importe"] != System.DBNull.Value)
                      obj.Importe = (Decimal)dr["importe"];
                  if (dr["flag_igv"] != System.DBNull.Value)
                      obj.FlagIgv = (string)dr["flag_igv"];
                  
                  if (dr["id_proveedor_seleccionado"] != System.DBNull.Value)
                      obj.IdProveedorSeleccionado = (int)dr["id_proveedor_seleccionado"];

                  if (dr["dias_entrega"] != System.DBNull.Value)
                      obj.DiasEntrega = (int)dr["dias_entrega"];

                  if (dr["id_usuario_creacion"] != System.DBNull.Value)
                      obj.IdUsuarioCreacion = (int)dr["id_usuario_creacion"];
                  if (dr["fecha_creacion"] != System.DBNull.Value)
                      obj.FechaCreacion = (DateTime)dr["fecha_creacion"];
                  if (dr["id_usuario_modificacion"] != System.DBNull.Value)
                      obj.IdUsuarioModificacion = (int)dr["id_usuario_modificacion"];
                  if (dr["fecha_modificacion"] != System.DBNull.Value)
                      obj.FechaModificacion = (DateTime)dr["fecha_modificacion"];

                  if (dr["codigo_articulo"] != System.DBNull.Value) obj.CodigoArticulo = (string)dr["codigo_articulo"];
                  if (dr["nombre_corto_unidad_medida"] != System.DBNull.Value) obj.NombreCortoUnidadMedida = (string)dr["nombre_corto_unidad_medida"];
                  if (dr["razon_social"] != System.DBNull.Value) obj.RazonSocial = (string)dr["razon_social"];
                  
              }
          }
          return obj;
      }
      
      public int Agregar(CotizacionLineaDTO obj)
      {
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_AGREGAR);
          db.AddInParameter(dbCommand, "@id_cotizacion", DbType.Int32, obj.IdCotizacion);
          db.AddInParameter(dbCommand, "@id_cotizacion_linea", DbType.Int32, obj.IdCotizacionLinea);
          db.AddInParameter(dbCommand, "@id_pedido_linea", DbType.Int32, obj.IdPedidoLinea);
          db.AddInParameter(dbCommand, "@numero_linea", DbType.Int32, obj.NumeroLinea);
          db.AddInParameter(dbCommand, "@id_unidad_medida", DbType.Int32, obj.IdUnidadMedida);
          db.AddInParameter(dbCommand, "@id_articulo", DbType.Int32, obj.IdArticulo);
          db.AddInParameter(dbCommand, "@descripcion_linea", DbType.String, obj.DescripcionLinea);
          db.AddInParameter(dbCommand, "@precio", DbType.Decimal, obj.Precio);
          db.AddInParameter(dbCommand, "@cantidad", DbType.Decimal, obj.Cantidad);
          db.AddInParameter(dbCommand, "@importe", DbType.Decimal, obj.Importe);
          db.AddInParameter(dbCommand, "@flag_igv", DbType.String, obj.FlagIgv);
          db.AddInParameter(dbCommand, "@id_proveedor_seleccionado", DbType.Int32, obj.IdProveedorSeleccionado);
          db.AddInParameter(dbCommand, "@dias_entrega", DbType.Int32, obj.DiasEntrega);

          db.AddInParameter(dbCommand, "@id_usuario_creacion", DbType.Int32, obj.IdUsuarioCreacion);
          db.AddInParameter(dbCommand, "@fecha_creacion", DbType.DateTime, obj.FechaCreacion);
          db.AddInParameter(dbCommand, "@id_usuario_modificacion", DbType.Int32, obj.IdUsuarioModificacion);
          db.AddInParameter(dbCommand, "@fecha_modificacion", DbType.DateTime, obj.FechaModificacion);
          int id = db.ExecuteNonQuery(dbCommand);
          return id;
      }

      public void Actualizar(CotizacionLineaDTO obj)
      {
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_ACTUALIZAR);
          db.AddInParameter(dbCommand, "@id_cotizacion", DbType.Int32, obj.IdCotizacion);
          db.AddInParameter(dbCommand, "@id_cotizacion_linea", DbType.Int32, obj.IdCotizacionLinea);
          db.AddInParameter(dbCommand, "@id_pedido_linea", DbType.Int32, obj.IdPedidoLinea);
          db.AddInParameter(dbCommand, "@numero_linea", DbType.Int32, obj.NumeroLinea);
          db.AddInParameter(dbCommand, "@id_unidad_medida", DbType.Int32, obj.IdUnidadMedida);
          db.AddInParameter(dbCommand, "@id_articulo", DbType.Int32, obj.IdArticulo);
          db.AddInParameter(dbCommand, "@descripcion_linea", DbType.String, obj.DescripcionLinea);
          db.AddInParameter(dbCommand, "@precio", DbType.Decimal, obj.Precio);
          db.AddInParameter(dbCommand, "@cantidad", DbType.Decimal, obj.Cantidad);
          db.AddInParameter(dbCommand, "@importe", DbType.Decimal, obj.Importe);
          db.AddInParameter(dbCommand, "@flag_igv", DbType.String, obj.FlagIgv);
          db.AddInParameter(dbCommand, "@id_proveedor_seleccionado", DbType.Int32, obj.IdProveedorSeleccionado);
          db.AddInParameter(dbCommand, "@dias_entrega", DbType.Int32, obj.DiasEntrega);

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

      public void Eliminar(int IdCotizacion)
      {
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_ELIMINAR);
          db.AddInParameter(dbCommand, "@id_cotizacion", DbType.Int32, IdCotizacion);
          db.ExecuteNonQuery(dbCommand);
      }
  }
}
