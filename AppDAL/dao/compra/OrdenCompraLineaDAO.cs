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
  public class OrdenCompraLineaDAO
  {
      const string C_LISTAR = "USP_OrdenCompraLinea_Listar";
      const string C_ACTUALIZAR = "USP_OrdenCompraLinea_Actualizar";
      const string C_AGREGAR = "USP_OrdenCompraLinea_Agregar";
      const string C_ELIMINAR = "USP_OrdenCompraLinea_Eliminar";
      const string C_LISTAR_POR_CLAVE = "USP_OrdenCompraLinea_ListarPorClave";
      const string C_LISTAR_PENDIENTE_RECEPCION = "USP_OrdenCompraLinea_RecepcionListar";
      const string C_USP_UPD_ORDENCOMPRA_PU = "USP_UPD_ORDENCOMPRA_PU";
      
      public List<OrdenCompraLineaDTO> Listar(int IdOrdenCompra)
      {
          List<OrdenCompraLineaDTO> Lista = new List<OrdenCompraLineaDTO>();
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_LISTAR);
         db.AddInParameter(dbCommand, "@id_orden_compra", DbType.Int32, IdOrdenCompra);

          using (IDataReader dr = db.ExecuteReader(dbCommand)) 
          {
              while (dr.Read())
              {
                  OrdenCompraLineaDTO obj = new OrdenCompraLineaDTO();
                  if (dr["id_orden_compra"] != System.DBNull.Value)
                      obj.IdOrdenCompra = (int)dr["id_orden_compra"];
                  if (dr["id_orden_compra_linea"] != System.DBNull.Value)
                      obj.IdOrdenCompraLinea = (int)dr["id_orden_compra_linea"];
                  if (dr["numero_linea"] != System.DBNull.Value)
                      obj.NumeroLinea = (int)dr["numero_linea"];
                  if (dr["id_articulo"] != System.DBNull.Value)
                      obj.IdArticulo = (int)dr["id_articulo"];
                  if (dr["id_unidad_medida"] != System.DBNull.Value)
                      obj.IdUnidadMedida = (int)dr["id_unidad_medida"];
                  if (dr["descripcion_linea"] != System.DBNull.Value)
                      obj.DescripcionLinea = (string)dr["descripcion_linea"];
                  if (dr["precio"] != System.DBNull.Value)
                      obj.Precio = (Decimal)dr["precio"];
                  if (dr["cantidad"] != System.DBNull.Value)
                      obj.Cantidad = (Decimal)dr["cantidad"];
                  if (dr["importe"] != System.DBNull.Value)
                      obj.Importe = (Decimal)dr["importe"];
                  if (dr["id_cotizacion_linea"] != System.DBNull.Value)
                      obj.IdCotizacionLinea = (int)dr["id_cotizacion_linea"];
                  if (dr["id_pedido_linea"] != System.DBNull.Value)
                      obj.IdPedidoLinea = (int)dr["id_pedido_linea"];
                  if (dr["fecha_pactada"] != System.DBNull.Value)
                      obj.FechaPactada = (DateTime)dr["fecha_pactada"];
                  if (dr["fecha_creacion"] != System.DBNull.Value)
                      obj.FechaCreacion = (DateTime)dr["fecha_creacion"];
                  if (dr["id_usuario_creacion"] != System.DBNull.Value)
                      obj.IdUsuarioCreacion = (int)dr["id_usuario_creacion"];
                  if (dr["fecha_modificacion"] != System.DBNull.Value)
                      obj.FechaModificacion = (DateTime)dr["fecha_modificacion"];
                  if (dr["id_usuario_modificacion"] != System.DBNull.Value)
                      obj.IdUsuarioModificacion = (int)dr["id_usuario_modificacion"];

                  if (dr["codigo_articulo"] != System.DBNull.Value)
                      obj.CodigoArticulo = (string)dr["codigo_articulo"];

                  if (dr["descripcion_articulo"] != System.DBNull.Value)
                      obj.DescripcionArticulo = (string)dr["descripcion_articulo"];

                  if (dr["nombre_unidad_medida"] != System.DBNull.Value)
                      obj.NombreUnidadMedida = (string)dr["nombre_unidad_medida"];

                  if (dr["cantidad_recibida"] != System.DBNull.Value)
                      obj.CantidadRecibida = (Decimal)dr["cantidad_recibida"];

                  if (dr["DESC_ALTERNATIVA"] != System.DBNull.Value)
                      obj.DescAlternativo = (string)dr["DESC_ALTERNATIVA"];

				  Lista.Add(obj);
              }
          }
          return Lista;
      }

      public List<OrdenCompraLineaDTO> ListarPendienteRecepcion(int IdOrdenCompra)
      {
          List<OrdenCompraLineaDTO> Lista = new List<OrdenCompraLineaDTO>();
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_LISTAR_PENDIENTE_RECEPCION);
          db.AddInParameter(dbCommand, "@id_orden_compra", DbType.Int32, IdOrdenCompra);

          using (IDataReader dr = db.ExecuteReader(dbCommand))
          {
              while (dr.Read())
              {
                  OrdenCompraLineaDTO obj = new OrdenCompraLineaDTO();
                  if (dr["id_orden_compra"] != System.DBNull.Value)
                      obj.IdOrdenCompra = (int)dr["id_orden_compra"];
                  if (dr["id_orden_compra_linea"] != System.DBNull.Value)
                      obj.IdOrdenCompraLinea = (int)dr["id_orden_compra_linea"];
                  if (dr["numero_linea"] != System.DBNull.Value)
                      obj.NumeroLinea = (int)dr["numero_linea"];
                  if (dr["id_articulo"] != System.DBNull.Value)
                      obj.IdArticulo = (int)dr["id_articulo"];
                  if (dr["id_unidad_medida"] != System.DBNull.Value)
                      obj.IdUnidadMedida = (int)dr["id_unidad_medida"];
                  if (dr["descripcion_linea"] != System.DBNull.Value)
                      obj.DescripcionLinea = (string)dr["descripcion_linea"];
                  if (dr["precio"] != System.DBNull.Value)
                      obj.Precio = (Decimal)dr["precio"];
                  if (dr["cantidad"] != System.DBNull.Value)
                      obj.Cantidad = (Decimal)dr["cantidad"];
                  if (dr["importe"] != System.DBNull.Value)
                      obj.Importe = (Decimal)dr["importe"];
                  if (dr["id_cotizacion_linea"] != System.DBNull.Value)
                      obj.IdCotizacionLinea = (int)dr["id_cotizacion_linea"];
                  if (dr["id_pedido_linea"] != System.DBNull.Value)
                      obj.IdPedidoLinea = (int)dr["id_pedido_linea"];
                  if (dr["fecha_pactada"] != System.DBNull.Value)
                      obj.FechaPactada = (DateTime)dr["fecha_pactada"];
                  if (dr["fecha_creacion"] != System.DBNull.Value)
                      obj.FechaCreacion = (DateTime)dr["fecha_creacion"];
                  if (dr["id_usuario_creacion"] != System.DBNull.Value)
                      obj.IdUsuarioCreacion = (int)dr["id_usuario_creacion"];
                  if (dr["fecha_modificacion"] != System.DBNull.Value)
                      obj.FechaModificacion = (DateTime)dr["fecha_modificacion"];
                  if (dr["id_usuario_modificacion"] != System.DBNull.Value)
                      obj.IdUsuarioModificacion = (int)dr["id_usuario_modificacion"];

                  if (dr["codigo_articulo"] != System.DBNull.Value)
                      obj.CodigoArticulo = (string)dr["codigo_articulo"];

                  if (dr["descripcion_articulo"] != System.DBNull.Value)
                      obj.DescripcionArticulo = (string)dr["descripcion_articulo"];

                  if (dr["nombre_unidad_medida"] != System.DBNull.Value)
                      obj.NombreUnidadMedida = (string)dr["nombre_unidad_medida"];

                  if (dr["cantidad_recibida"] != System.DBNull.Value)
                      obj.CantidadRecibida = (Decimal)dr["cantidad_recibida"];

                  if (dr["MODELO"] != System.DBNull.Value)
                      obj.Modelo = (string)dr["MODELO"];

                  if (dr["MARCA"] != System.DBNull.Value)
                      obj.Marca = (string)dr["MARCA"];

                  Lista.Add(obj);
              }
          }
          return Lista;
      }

      public OrdenCompraLineaDTO ListarPorClave(int IdOrdenCompra, int IdOrdenCompraLinea)
      {
          OrdenCompraLineaDTO obj = null;
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_LISTAR_POR_CLAVE);
          db.AddInParameter(dbCommand, "@id_orden_compra", DbType.Int32, IdOrdenCompra);
          db.AddInParameter(dbCommand, "@id_orden_compra_linea", DbType.Int32, IdOrdenCompraLinea);

          using (IDataReader dr = db.ExecuteReader(dbCommand))
          {
              if (dr.Read())
              {
                  obj = new OrdenCompraLineaDTO();

                  if (dr["id_orden_compra"] != System.DBNull.Value)
                      obj.IdOrdenCompra = (int)dr["id_orden_compra"];
                  if (dr["id_orden_compra_linea"] != System.DBNull.Value)
                      obj.IdOrdenCompraLinea = (int)dr["id_orden_compra_linea"];
                  if (dr["numero_linea"] != System.DBNull.Value)
                      obj.NumeroLinea = (int)dr["numero_linea"];
                  if (dr["id_articulo"] != System.DBNull.Value)
                      obj.IdArticulo = (int)dr["id_articulo"];
                  if (dr["id_unidad_medida"] != System.DBNull.Value)
                      obj.IdUnidadMedida = (int)dr["id_unidad_medida"];
                  if (dr["descripcion_linea"] != System.DBNull.Value)
                      obj.DescripcionLinea = (string)dr["descripcion_linea"];
                  if (dr["precio"] != System.DBNull.Value)
                      obj.Precio = (Decimal)dr["precio"];
                  if (dr["cantidad"] != System.DBNull.Value)
                      obj.Cantidad = (Decimal)dr["cantidad"];
                  if (dr["importe"] != System.DBNull.Value)
                      obj.Importe = (Decimal)dr["importe"];
                  if (dr["id_cotizacion_linea"] != System.DBNull.Value)
                      obj.IdCotizacionLinea = (int)dr["id_cotizacion_linea"];
                  if (dr["id_pedido_linea"] != System.DBNull.Value)
                      obj.IdPedidoLinea = (int)dr["id_pedido_linea"];
                  if (dr["fecha_pactada"] != System.DBNull.Value)
                      obj.FechaPactada = (DateTime)dr["fecha_pactada"];
                  if (dr["fecha_creacion"] != System.DBNull.Value)
                      obj.FechaCreacion = (DateTime)dr["fecha_creacion"];
                  if (dr["id_usuario_creacion"] != System.DBNull.Value)
                      obj.IdUsuarioCreacion = (int)dr["id_usuario_creacion"];
                  if (dr["fecha_modificacion"] != System.DBNull.Value)
                      obj.FechaModificacion = (DateTime)dr["fecha_modificacion"];
                  if (dr["id_usuario_modificacion"] != System.DBNull.Value)
                      obj.IdUsuarioModificacion = (int)dr["id_usuario_modificacion"];

                  if (dr["descripcion_articulo"] != System.DBNull.Value)
                      obj.DescripcionArticulo = (string)dr["descripcion_articulo"];

                  if (dr["nombre_unidad_medida"] != System.DBNull.Value)
                      obj.NombreUnidadMedida = (string)dr["nombre_unidad_medida"];

              }
          }
          return obj;
      }

      public int Agregar(OrdenCompraLineaDTO obj)
      {
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_AGREGAR);
          db.AddInParameter(dbCommand, "@id_orden_compra", DbType.Int32, obj.IdOrdenCompra);
          db.AddInParameter(dbCommand, "@numero_linea", DbType.Int32, obj.NumeroLinea);
          db.AddInParameter(dbCommand, "@id_articulo", DbType.Int32, obj.IdArticulo);
          db.AddInParameter(dbCommand, "@id_unidad_medida", DbType.Int32, obj.IdUnidadMedida);
          db.AddInParameter(dbCommand, "@descripcion_linea", DbType.String, obj.DescripcionLinea);
          
		  	if (obj.Precio > 0)
				db.AddInParameter(dbCommand, "@precio", DbType.Decimal, obj.Precio);
			else
				db.AddInParameter(dbCommand, "@precio", DbType.Decimal, null);

			if (obj.Cantidad > 0)
				db.AddInParameter(dbCommand, "@cantidad", DbType.Decimal, obj.Cantidad);
			else
				db.AddInParameter(dbCommand, "@cantidad", DbType.Decimal, null);	

			if (obj.Importe > 0)
				db.AddInParameter(dbCommand, "@importe", DbType.Decimal, obj.Importe);
			else
				db.AddInParameter(dbCommand, "@importe", DbType.Decimal, null);

          db.AddInParameter(dbCommand, "@id_cotizacion_linea", DbType.Int32, obj.IdCotizacionLinea);
          db.AddInParameter(dbCommand, "@id_pedido_linea", DbType.Int32, obj.IdPedidoLinea);

		  if (obj.FechaPactada.Year == 1)
                db.AddInParameter(dbCommand, "@fecha_pactada", DbType.DateTime, null );
          else
                db.AddInParameter(dbCommand, "@fecha_pactada", DbType.DateTime, obj.FechaPactada);

          if (obj.CantidadRecibida > 0)
              db.AddInParameter(dbCommand, "@cantidad_recibida", DbType.Decimal, obj.CantidadRecibida);
          else
              db.AddInParameter(dbCommand, "@cantidad_recibida", DbType.Decimal, null);

          db.AddInParameter(dbCommand, "@estado_cotrol", DbType.String, obj.EstadoControl);

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

      public void Actualizar(OrdenCompraLineaDTO obj)
      {
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_ACTUALIZAR);
          db.AddInParameter(dbCommand, "@id_orden_compra", DbType.Int32, obj.IdOrdenCompra);
          db.AddInParameter(dbCommand, "@id_orden_compra_linea", DbType.Int32, obj.IdOrdenCompraLinea);
          db.AddInParameter(dbCommand, "@numero_linea", DbType.Int32, obj.NumeroLinea);
          db.AddInParameter(dbCommand, "@id_articulo", DbType.Int32, obj.IdArticulo);
          db.AddInParameter(dbCommand, "@id_unidad_medida", DbType.Int32, obj.IdUnidadMedida);
          db.AddInParameter(dbCommand, "@descripcion_linea", DbType.String, obj.DescripcionLinea);

			if (obj.Precio > 0)
				db.AddInParameter(dbCommand, "@precio", DbType.Decimal, obj.Precio);
			else
				db.AddInParameter(dbCommand, "@precio", DbType.Decimal, null);

			if (obj.Cantidad > 0)
				db.AddInParameter(dbCommand, "@cantidad", DbType.Decimal, obj.Cantidad);
			else
				db.AddInParameter(dbCommand, "@cantidad", DbType.Decimal, null);	

			if (obj.Importe > 0)
				db.AddInParameter(dbCommand, "@importe", DbType.Decimal, obj.Importe);
			else
				db.AddInParameter(dbCommand, "@importe", DbType.Decimal, null);

          db.AddInParameter(dbCommand, "@id_cotizacion_linea", DbType.Int32, obj.IdCotizacionLinea);
          db.AddInParameter(dbCommand, "@id_pedido_linea", DbType.Int32, obj.IdPedidoLinea);
          
		  if (obj.FechaPactada.Year == 1)
                db.AddInParameter(dbCommand, "@fecha_pactada", DbType.DateTime, null );
          else
                db.AddInParameter(dbCommand, "@fecha_pactada", DbType.DateTime, obj.FechaPactada);

          if (obj.CantidadRecibida > 0)
              db.AddInParameter(dbCommand, "@cantidad_recibida", DbType.Decimal, obj.CantidadRecibida);
          else
              db.AddInParameter(dbCommand, "@cantidad_recibida", DbType.Decimal, null);	

          db.AddInParameter(dbCommand, "@estado_control", DbType.String, obj.EstadoControl);
          
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

      public void Eliminar(int IdOrdenCompra, int IdOrdenCompraLinea)
      {
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_ELIMINAR);
          db.AddInParameter(dbCommand, "@id_orden_compra", DbType.Int32, IdOrdenCompra);
          db.AddInParameter(dbCommand, "@id_orden_compra_linea", DbType.Int32, IdOrdenCompraLinea);
          db.ExecuteNonQuery(dbCommand);
      }

      public int EditarPU(int nro_ordencompralinea, decimal preciounitario)
      {
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_USP_UPD_ORDENCOMPRA_PU);
          db.AddInParameter(dbCommand, "@id_ordencompra_linea", DbType.Int32, nro_ordencompralinea);
          db.AddInParameter(dbCommand, "@preciouni", DbType.Decimal, preciounitario);
          int resultado=db.ExecuteNonQuery(dbCommand);
          return resultado;
      }
  }
}
