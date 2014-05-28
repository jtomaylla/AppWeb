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
  public class InvTransaccionDAO
  {

      const string C_LISTAR = "USP_InvTransaccion_Listar";
      const string C_LISTAR_POR_CLAVE = "USP_InvTransaccion_ListarPorClave";
      const string C_LISTAR_POR_ARTICULO = "USP_InvTransaccion_ListarPorArticulo";
      const string C_LISTAR_POR_ARTICULO_PROYECTO = "USP_InvTransaccion_ListarPorArticuloProyecto";

      const string C_ACTUALIZAR = "USP_InvTransaccion_Actualizar";
      const string C_AGREGAR = "USP_InvTransaccion_Agregar";
      const string C_ELIMINAR = "USP_InvTransaccion_Eliminar";

      public List<InvTransaccionDTO> Listar()
      {
          List<InvTransaccionDTO> Lista = new List<InvTransaccionDTO>();
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_LISTAR);
          using (IDataReader dr = db.ExecuteReader(dbCommand)) 
          {
              while (dr.Read())
              {
                  InvTransaccionDTO obj = new InvTransaccionDTO();
                  if (dr["id_transaccion"] != System.DBNull.Value)
                      obj.IdTransaccion = (int)dr["id_transaccion"];
                  if (dr["id_articulo"] != System.DBNull.Value)
                      obj.IdArticulo = (int)dr["id_articulo"];
                  if (dr["id_almacen"] != System.DBNull.Value)
                      obj.IdAlmacen = (int)dr["id_almacen"];
                  if (dr["id_tipo_transaccion"] != System.DBNull.Value)
                      obj.IdTipoTransaccion = (int)dr["id_tipo_transaccion"];
                  if (dr["fecha"] != System.DBNull.Value)
                      obj.Fecha = (DateTime)dr["fecha"];
                  if (dr["cantidad"] != System.DBNull.Value)
                      obj.Cantidad = (Decimal)dr["cantidad"];
                  if (dr["costo_unitario"] != System.DBNull.Value)
                      obj.CostoUnitario = (Decimal)dr["costo_unitario"];
                  if (dr["costo"] != System.DBNull.Value)
                      obj.Costo = (Decimal)dr["costo"];
                  if (dr["tipo_origen"] != System.DBNull.Value)
                      obj.TipoOrigen = (string)dr["tipo_origen"];
                  if (dr["id_transaccion_origen"] != System.DBNull.Value)
                      obj.IdTransaccionOrigen = (int)dr["id_transaccion_origen"];
                  if (dr["id_linea_origen"] != System.DBNull.Value)
                      obj.IdLineaOrigen = (int)dr["id_linea_origen"];
                  if (dr["descripcion"] != System.DBNull.Value)
                      obj.Descripcion = (string)dr["descripcion"];

                  if (dr["id_sede"] != System.DBNull.Value)
                      obj.IdSede = (int)dr["id_sede"];

                  if (dr["id_proyecto"] != System.DBNull.Value)
                      obj.IdProyecto = (int)dr["id_proyecto"];

                  if (dr["fecha_vencimiento"] != System.DBNull.Value)
                      obj.FechaVencimiento = (DateTime)dr["fecha_vencimiento"];

                  if (dr["ubicacion"] != System.DBNull.Value)
                      obj.Ubicacion = (string)dr["ubicacion"];

                  if (dr["marca"] != System.DBNull.Value)
                      obj.Marca = (string)dr["marca"];

                  if (dr["modelo"] != System.DBNull.Value)
                      obj.Modelo = (string)dr["modelo"];

                  if (dr["serie"] != System.DBNull.Value)
                      obj.Serie = (string)dr["serie"];

                  if (dr["lote"] != System.DBNull.Value)
                      obj.Lote = (string)dr["lote"];

                  if (dr["observaciones_almacenamiento"] != System.DBNull.Value)
                      obj.ObservacionesAlmacenamiento = (string)dr["observaciones_almacenamiento"];



                  if (dr["id_usuario_creacion"] != System.DBNull.Value)
                      obj.IdUsuarioCreacion = (int)dr["id_usuario_creacion"];
                  if (dr["fecha_creacion"] != System.DBNull.Value)
                      obj.FechaCreacion = (DateTime)dr["fecha_creacion"];
                  if (dr["id_usuario_modificador"] != System.DBNull.Value)
                      obj.IdUsuarioModificador = (int)dr["id_usuario_modificador"];
                  if (dr["fecha_modificacion"] != System.DBNull.Value)
                      obj.FechaModificacion = (DateTime)dr["fecha_modificacion"];

                  Lista.Add(obj);
              }
          }
          return Lista;
      }

      public InvTransaccionDTO ListarPorClave(int idTransaccion)
      {
          List<InvTransaccionDTO> Lista = new List<InvTransaccionDTO>();
          InvTransaccionDTO obj = null;
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_LISTAR_POR_CLAVE);
          db.AddInParameter(dbCommand, "@id_transaccion", DbType.Int32, idTransaccion);
          using (IDataReader dr = db.ExecuteReader(dbCommand))
          {
              while (dr.Read())
              {
                  obj = new InvTransaccionDTO();
                  if (dr["id_transaccion"] != System.DBNull.Value)
                      obj.IdTransaccion = (int)dr["id_transaccion"];
                  if (dr["id_articulo"] != System.DBNull.Value)
                      obj.IdArticulo = (int)dr["id_articulo"];
                  if (dr["id_almacen"] != System.DBNull.Value)
                      obj.IdAlmacen = (int)dr["id_almacen"];
                  if (dr["id_tipo_transaccion"] != System.DBNull.Value)
                      obj.IdTipoTransaccion = (int)dr["id_tipo_transaccion"];
                  if (dr["fecha"] != System.DBNull.Value)
                      obj.Fecha = (DateTime)dr["fecha"];
                  if (dr["cantidad"] != System.DBNull.Value)
                      obj.Cantidad = (Decimal)dr["cantidad"];
                  if (dr["costo_unitario"] != System.DBNull.Value)
                      obj.CostoUnitario = (Decimal)dr["costo_unitario"];
                  if (dr["costo"] != System.DBNull.Value)
                      obj.Costo = (Decimal)dr["costo"];
                  if (dr["tipo_origen"] != System.DBNull.Value)
                      obj.TipoOrigen = (string)dr["tipo_origen"];
                  if (dr["id_transaccion_origen"] != System.DBNull.Value)
                      obj.IdTransaccionOrigen = (int)dr["id_transaccion_origen"];
                  if (dr["id_linea_origen"] != System.DBNull.Value)
                      obj.IdLineaOrigen = (int)dr["id_linea_origen"];
                  if (dr["descripcion"] != System.DBNull.Value)
                      obj.Descripcion = (string)dr["descripcion"];

                  if (dr["id_sede"] != System.DBNull.Value)
                      obj.IdSede = (int)dr["id_sede"];

                  if (dr["id_proyecto"] != System.DBNull.Value)
                      obj.IdProyecto = (int)dr["id_proyecto"];

                  if (dr["fecha_vencimiento"] != System.DBNull.Value)
                      obj.FechaVencimiento = (DateTime)dr["fecha_vencimiento"];

                  if (dr["ubicacion"] != System.DBNull.Value)
                      obj.Ubicacion = (string)dr["ubicacion"];

                  if (dr["marca"] != System.DBNull.Value)
                      obj.Marca = (string)dr["marca"];

                  if (dr["modelo"] != System.DBNull.Value)
                      obj.Modelo = (string)dr["modelo"];

                  if (dr["serie"] != System.DBNull.Value)
                      obj.Serie = (string)dr["serie"];

                  if (dr["lote"] != System.DBNull.Value)
                      obj.Lote = (string)dr["lote"];

                  if (dr["observaciones_almacenamiento"] != System.DBNull.Value)
                      obj.ObservacionesAlmacenamiento = (string)dr["observaciones_almacenamiento"];

                  
                  if (dr["id_usuario_creacion"] != System.DBNull.Value)
                      obj.IdUsuarioCreacion = (int)dr["id_usuario_creacion"];
                  if (dr["fecha_creacion"] != System.DBNull.Value)
                      obj.FechaCreacion = (DateTime)dr["fecha_creacion"];
                  if (dr["id_usuario_modificador"] != System.DBNull.Value)
                      obj.IdUsuarioModificador = (int)dr["id_usuario_modificador"];
                  if (dr["fecha_modificacion"] != System.DBNull.Value)
                      obj.FechaModificacion = (DateTime)dr["fecha_modificacion"];

                  Lista.Add(obj);
              }
          }
          return obj;
      }

      public List<InvTransaccionDTO> ListarPorArticulo(int idArticulo)
      {
          List<InvTransaccionDTO> Lista = new List<InvTransaccionDTO>();
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_LISTAR_POR_ARTICULO);
          db.AddInParameter(dbCommand, "@id_articulo", DbType.Int32, idArticulo);
          using (IDataReader dr = db.ExecuteReader(dbCommand))
          {
              while (dr.Read())
              {
                  InvTransaccionDTO obj = new InvTransaccionDTO();
                  if (dr["id_transaccion"] != System.DBNull.Value)
                      obj.IdTransaccion = (int)dr["id_transaccion"];
                  if (dr["id_articulo"] != System.DBNull.Value)
                      obj.IdArticulo = (int)dr["id_articulo"];
                  if (dr["id_almacen"] != System.DBNull.Value)
                      obj.IdAlmacen = (int)dr["id_almacen"];
                  if (dr["id_tipo_transaccion"] != System.DBNull.Value)
                      obj.IdTipoTransaccion = (int)dr["id_tipo_transaccion"];
                  if (dr["fecha"] != System.DBNull.Value)
                      obj.Fecha = (DateTime)dr["fecha"];
                  if (dr["cantidad"] != System.DBNull.Value)
                      obj.Cantidad = (Decimal)dr["cantidad"];
                  if (dr["costo_unitario"] != System.DBNull.Value)
                      obj.CostoUnitario = (Decimal)dr["costo_unitario"];
                  if (dr["costo"] != System.DBNull.Value)
                      obj.Costo = (Decimal)dr["costo"];
                  if (dr["tipo_origen"] != System.DBNull.Value)
                      obj.TipoOrigen = (string)dr["tipo_origen"];
                  if (dr["id_transaccion_origen"] != System.DBNull.Value)
                      obj.IdTransaccionOrigen = (int)dr["id_transaccion_origen"];
                  if (dr["id_linea_origen"] != System.DBNull.Value)
                      obj.IdLineaOrigen = (int)dr["id_linea_origen"];
                  if (dr["descripcion"] != System.DBNull.Value)
                      obj.Descripcion = (string)dr["descripcion"];

                  if (dr["id_sede"] != System.DBNull.Value)
                      obj.IdSede = (int)dr["id_sede"];

                  if (dr["id_proyecto"] != System.DBNull.Value)
                      obj.IdProyecto = (int)dr["id_proyecto"];

                  if (dr["fecha_vencimiento"] != System.DBNull.Value)
                      obj.FechaVencimiento = (DateTime)dr["fecha_vencimiento"];

                  if (dr["ubicacion"] != System.DBNull.Value)
                      obj.Ubicacion = (string)dr["ubicacion"];

                  if (dr["marca"] != System.DBNull.Value)
                      obj.Marca = (string)dr["marca"];

                  if (dr["modelo"] != System.DBNull.Value)
                      obj.Modelo = (string)dr["modelo"];

                  if (dr["serie"] != System.DBNull.Value)
                      obj.Serie = (string)dr["serie"];

                  if (dr["lote"] != System.DBNull.Value)
                      obj.Lote = (string)dr["lote"];

                  if (dr["observaciones_almacenamiento"] != System.DBNull.Value)
                      obj.ObservacionesAlmacenamiento = (string)dr["observaciones_almacenamiento"];
                                    
                  if (dr["id_usuario_creacion"] != System.DBNull.Value)
                      obj.IdUsuarioCreacion = (int)dr["id_usuario_creacion"];
                  if (dr["fecha_creacion"] != System.DBNull.Value)
                      obj.FechaCreacion = (DateTime)dr["fecha_creacion"];
                  if (dr["id_usuario_modificador"] != System.DBNull.Value)
                      obj.IdUsuarioModificador = (int)dr["id_usuario_modificador"];
                  if (dr["fecha_modificacion"] != System.DBNull.Value)
                      obj.FechaModificacion = (DateTime)dr["fecha_modificacion"];

                  Lista.Add(obj);
              }
          }
          return Lista;
      }

      public List<InvTransaccionDTO> ListarPorArticuloProyecto(int idArticulo, int IdProyecto)
      {
          List<InvTransaccionDTO> Lista = new List<InvTransaccionDTO>();
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_LISTAR_POR_ARTICULO_PROYECTO);
          db.AddInParameter(dbCommand, "@id_articulo", DbType.Int32, idArticulo);
          db.AddInParameter(dbCommand, "@id_proyecto", DbType.Int32, IdProyecto);

          using (IDataReader dr = db.ExecuteReader(dbCommand))
          {
              while (dr.Read())
              {
                  InvTransaccionDTO obj = new InvTransaccionDTO();
                  if (dr["id_transaccion"] != System.DBNull.Value)
                      obj.IdTransaccion = (int)dr["id_transaccion"];
                  if (dr["id_articulo"] != System.DBNull.Value)
                      obj.IdArticulo = (int)dr["id_articulo"];
                  if (dr["id_almacen"] != System.DBNull.Value)
                      obj.IdAlmacen = (int)dr["id_almacen"];
                  if (dr["id_tipo_transaccion"] != System.DBNull.Value)
                      obj.IdTipoTransaccion = (int)dr["id_tipo_transaccion"];
                  if (dr["fecha"] != System.DBNull.Value)
                      obj.Fecha = (DateTime)dr["fecha"];
                  if (dr["cantidad"] != System.DBNull.Value)
                      obj.Cantidad = (Decimal)dr["cantidad"];
                  if (dr["costo_unitario"] != System.DBNull.Value)
                      obj.CostoUnitario = (Decimal)dr["costo_unitario"];
                  if (dr["costo"] != System.DBNull.Value)
                      obj.Costo = (Decimal)dr["costo"];
                  if (dr["tipo_origen"] != System.DBNull.Value)
                      obj.TipoOrigen = (string)dr["tipo_origen"];
                  if (dr["id_transaccion_origen"] != System.DBNull.Value)
                      obj.IdTransaccionOrigen = (int)dr["id_transaccion_origen"];
                  if (dr["id_linea_origen"] != System.DBNull.Value)
                      obj.IdLineaOrigen = (int)dr["id_linea_origen"];
                  if (dr["descripcion"] != System.DBNull.Value)
                      obj.Descripcion = (string)dr["descripcion"];

                  if (dr["id_sede"] != System.DBNull.Value)
                      obj.IdSede = (int)dr["id_sede"];

                  if (dr["id_proyecto"] != System.DBNull.Value)
                      obj.IdProyecto = (int)dr["id_proyecto"];

                  if (dr["fecha_vencimiento"] != System.DBNull.Value)
                      obj.FechaVencimiento = (DateTime)dr["fecha_vencimiento"];

                  if (dr["ubicacion"] != System.DBNull.Value)
                      obj.Ubicacion = (string)dr["ubicacion"];

                  if (dr["marca"] != System.DBNull.Value)
                      obj.Marca = (string)dr["marca"];

                  if (dr["modelo"] != System.DBNull.Value)
                      obj.Modelo = (string)dr["modelo"];

                  if (dr["serie"] != System.DBNull.Value)
                      obj.Serie = (string)dr["serie"];

                  if (dr["lote"] != System.DBNull.Value)
                      obj.Lote = (string)dr["lote"];

                  if (dr["observaciones_almacenamiento"] != System.DBNull.Value)
                      obj.ObservacionesAlmacenamiento = (string)dr["observaciones_almacenamiento"];

                  if (dr["id_usuario_creacion"] != System.DBNull.Value)
                      obj.IdUsuarioCreacion = (int)dr["id_usuario_creacion"];
                  if (dr["fecha_creacion"] != System.DBNull.Value)
                      obj.FechaCreacion = (DateTime)dr["fecha_creacion"];
                  if (dr["id_usuario_modificador"] != System.DBNull.Value)
                      obj.IdUsuarioModificador = (int)dr["id_usuario_modificador"];
                  if (dr["fecha_modificacion"] != System.DBNull.Value)
                      obj.FechaModificacion = (DateTime)dr["fecha_modificacion"];

                  Lista.Add(obj);
              }
          }
          return Lista;
      }
      public int Agregar(InvTransaccionDTO obj)
      {
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_AGREGAR);

          db.AddInParameter(dbCommand, "@id_articulo", DbType.Int32, obj.IdArticulo);
          db.AddInParameter(dbCommand, "@id_almacen", DbType.Int32, obj.IdAlmacen);
          db.AddInParameter(dbCommand, "@id_tipo_transaccion", DbType.Int32, obj.IdTipoTransaccion);
          db.AddInParameter(dbCommand, "@fecha", DbType.DateTime, GetFechaValida(obj.Fecha));
          db.AddInParameter(dbCommand, "@cantidad", DbType.Decimal, obj.Cantidad);
          db.AddInParameter(dbCommand, "@costo_unitario", DbType.Decimal, obj.CostoUnitario);
          db.AddInParameter(dbCommand, "@costo", DbType.Decimal, obj.Costo);
          db.AddInParameter(dbCommand, "@tipo_origen", DbType.String, obj.TipoOrigen);
          db.AddInParameter(dbCommand, "@id_transaccion_origen", DbType.Int32, obj.IdTransaccionOrigen);
          db.AddInParameter(dbCommand, "@id_linea_origen", DbType.Int32, obj.IdLineaOrigen);
          db.AddInParameter(dbCommand, "@descripcion", DbType.String, obj.Descripcion);
          db.AddInParameter(dbCommand, "@id_sede", DbType.Int32, obj.IdSede);
          db.AddInParameter(dbCommand, "@id_proyecto", DbType.Int32, obj.IdProyecto);
          db.AddInParameter(dbCommand, "@fecha_vencimiento", DbType.DateTime, GetFechaValida(obj.FechaVencimiento));
          db.AddInParameter(dbCommand, "@ubicacion", DbType.String, obj.Ubicacion);
          db.AddInParameter(dbCommand, "@marca", DbType.String, obj.Marca);
          db.AddInParameter(dbCommand, "@modelo", DbType.String, obj.Modelo);
          db.AddInParameter(dbCommand, "@serie", DbType.String, obj.Serie);
          db.AddInParameter(dbCommand, "@lote", DbType.String, obj.Lote);
          db.AddInParameter(dbCommand, "@observaciones_almacenamiento", DbType.String, obj.ObservacionesAlmacenamiento);
          db.AddInParameter(dbCommand, "@id_usuario_creacion", DbType.Int32, obj.IdUsuarioCreacion);
          db.AddInParameter(dbCommand, "@fecha_creacion", DbType.DateTime, GetFechaValida(obj.FechaCreacion));
          db.AddInParameter(dbCommand, "@id_usuario_modificador", DbType.Int32, obj.IdUsuarioModificador);
          db.AddInParameter(dbCommand, "@fecha_modificacion", DbType.DateTime, GetFechaValida(obj.FechaModificacion));

          int id = Convert.ToInt32(db.ExecuteScalar(dbCommand));

          return id;
      }

      public void Actualizar(InvTransaccionDTO obj)
      {
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_ACTUALIZAR);

          db.AddInParameter(dbCommand, "@id_transaccion", DbType.Int32, obj.IdTransaccion);
          db.AddInParameter(dbCommand, "@id_articulo", DbType.Int32, obj.IdArticulo);
          db.AddInParameter(dbCommand, "@id_almacen", DbType.Int32, obj.IdAlmacen);
          db.AddInParameter(dbCommand, "@id_tipo_transaccion", DbType.Int32, obj.IdTipoTransaccion);
          db.AddInParameter(dbCommand, "@fecha", DbType.DateTime, GetFechaValida(obj.Fecha));
          db.AddInParameter(dbCommand, "@cantidad", DbType.Decimal, obj.Cantidad);
          db.AddInParameter(dbCommand, "@costo_unitario", DbType.Decimal, obj.CostoUnitario);
          db.AddInParameter(dbCommand, "@costo", DbType.Decimal, obj.Costo);
          db.AddInParameter(dbCommand, "@tipo_origen", DbType.String, obj.TipoOrigen);
          db.AddInParameter(dbCommand, "@id_transaccion_origen", DbType.Int32, obj.IdTransaccionOrigen);
          db.AddInParameter(dbCommand, "@id_linea_origen", DbType.Int32, obj.IdLineaOrigen);
          db.AddInParameter(dbCommand, "@descripcion", DbType.String, obj.Descripcion);

          db.AddInParameter(dbCommand, "@id_sede", DbType.Int32, obj.IdSede);
          db.AddInParameter(dbCommand, "@id_proyecto", DbType.Int32, obj.IdProyecto);
          db.AddInParameter(dbCommand, "@fecha_vencimiento", DbType.DateTime, GetFechaValida(obj.FechaVencimiento));
          db.AddInParameter(dbCommand, "@ubicacion", DbType.String, obj.Ubicacion);
          db.AddInParameter(dbCommand, "@marca", DbType.String, obj.Marca);
          db.AddInParameter(dbCommand, "@modelo", DbType.String, obj.Modelo);
          db.AddInParameter(dbCommand, "@serie", DbType.String, obj.Serie);
          db.AddInParameter(dbCommand, "@lote", DbType.String, obj.Lote);
          db.AddInParameter(dbCommand, "@observaciones_almacenamiento", DbType.String, obj.ObservacionesAlmacenamiento);

          db.AddInParameter(dbCommand, "@id_usuario_creacion", DbType.Int32, obj.IdUsuarioCreacion);
          db.AddInParameter(dbCommand, "@fecha_creacion", DbType.DateTime, GetFechaValida(obj.FechaCreacion));
          db.AddInParameter(dbCommand, "@id_usuario_modificador", DbType.Int32, obj.IdUsuarioModificador);
          db.AddInParameter(dbCommand, "@fecha_modificacion", DbType.DateTime, GetFechaValida(obj.FechaModificacion));

          db.ExecuteNonQuery(dbCommand);
      }

      public void Eliminar(int IdTransaccion)
      {
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_ELIMINAR);
          db.AddInParameter(dbCommand, "@id_transaccion", DbType.Int32, IdTransaccion);
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
