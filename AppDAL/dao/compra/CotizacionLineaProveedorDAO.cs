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
  public class CotizacionLineaProveedorDAO
  {

      const string C_LISTAR = "USP_CotizacionLineaProveedor_Listar";
      const string C_ACTUALIZAR = "USP_CotizacionLineaProveedor_Actualizar";
      const string C_AGREGAR = "USP_CotizacionLineaProveedor_Agregar";
      const string C_ELIMINAR = "USP_CotizacionLineaProveedor_Eliminar";
      const string C_RECOMENDAR = "USP_CotizacionLineaProveedor_Recomendar";
      const string C_LISTAR_POR_CLAVE = "USP_CotizacionLineaProveedor_ListarPorClave";
      
      public List<CotizacionLineaProveedorDTO> Listar(int IdCotizacion, int IdCotizacionLinea)
      {
          List<CotizacionLineaProveedorDTO> Lista = new List<CotizacionLineaProveedorDTO>();
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_LISTAR);
          db.AddInParameter(dbCommand, "@id_cotizacion", DbType.Int32, IdCotizacion);
          db.AddInParameter(dbCommand, "@id_cotizacion_linea", DbType.Int32, IdCotizacionLinea);

          using (IDataReader dr = db.ExecuteReader(dbCommand)) 
          {
              while (dr.Read())
              {
                  CotizacionLineaProveedorDTO obj = new CotizacionLineaProveedorDTO();
                  if (dr["id_cotizacion"] != System.DBNull.Value)
                      obj.IdCotizacion = (int)dr["id_cotizacion"];
                  if (dr["id_cotizacion_linea"] != System.DBNull.Value)
                      obj.IdCotizacionLinea = (int)dr["id_cotizacion_linea"];
                  if (dr["id_proveedor"] != System.DBNull.Value)
                      obj.IdProveedor = (int)dr["id_proveedor"];
                  if (dr["precio"] != System.DBNull.Value)
                      obj.Precio = (Decimal)dr["precio"];
                  if (dr["cantidad"] != System.DBNull.Value)
                      obj.Cantidad = (Decimal)dr["cantidad"];
                  if (dr["importe"] != System.DBNull.Value)
                      obj.Importe = (Decimal)dr["importe"];
                  if (dr["fecha_pactada"] != System.DBNull.Value)
                      obj.FechaPactada = (DateTime)dr["fecha_pactada"];
                  if (dr["flag_igv"] != System.DBNull.Value)
                      obj.FlagIgv = (string)dr["flag_igv"];
                  if (dr["flag_seleccionado"] != System.DBNull.Value)
                      obj.FlagSeleccionado = (string)dr["flag_seleccionado"];
                  
                  if (dr["anotaciones"] != System.DBNull.Value)
                      obj.Anotaciones = (string)dr["anotaciones"];

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

                  if (dr["razon_social"] != System.DBNull.Value)
                      obj.RazonSocial = (string)dr["razon_social"];

                  if (dr["ruc"] != System.DBNull.Value)
                      obj.Ruc = (string)dr["ruc"];

                  Lista.Add(obj);

              }
          }
          return Lista;
      }

      public CotizacionLineaProveedorDTO ListarPorClave(int IdCotizacion, int IdCotizacionLinea, int IdProveerod)
      {
          CotizacionLineaProveedorDTO obj = null;
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_LISTAR_POR_CLAVE);
          db.AddInParameter(dbCommand, "@id_cotizacion", DbType.Int32, IdCotizacion);
          db.AddInParameter(dbCommand, "@id_cotizacion_linea", DbType.Int32, IdCotizacionLinea);
          db.AddInParameter(dbCommand, "@id_proveedor", DbType.Int32, IdProveerod);

          using (IDataReader dr = db.ExecuteReader(dbCommand))
          {
              if (dr.Read())
              {
                  obj = new CotizacionLineaProveedorDTO();

                  if (dr["id_cotizacion"] != System.DBNull.Value)
                      obj.IdCotizacion = (int)dr["id_cotizacion"];
                  if (dr["id_cotizacion_linea"] != System.DBNull.Value)
                      obj.IdCotizacionLinea = (int)dr["id_cotizacion_linea"];
                  if (dr["id_proveedor"] != System.DBNull.Value)
                      obj.IdProveedor = (int)dr["id_proveedor"];
                  if (dr["precio"] != System.DBNull.Value)
                      obj.Precio = (Decimal)dr["precio"];
                  if (dr["cantidad"] != System.DBNull.Value)
                      obj.Cantidad = (Decimal)dr["cantidad"];
                  if (dr["importe"] != System.DBNull.Value)
                      obj.Importe = (Decimal)dr["importe"];
                  if (dr["fecha_pactada"] != System.DBNull.Value)
                      obj.FechaPactada = (DateTime)dr["fecha_pactada"];
                  if (dr["flag_igv"] != System.DBNull.Value)
                      obj.FlagIgv = (string)dr["flag_igv"];
                  if (dr["flag_seleccionado"] != System.DBNull.Value)
                      obj.FlagSeleccionado = (string)dr["flag_seleccionado"];
                  if (dr["anotaciones"] != System.DBNull.Value)
                      obj.Anotaciones = (string)dr["anotaciones"];

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

                  if (dr["razon_social"] != System.DBNull.Value)
                      obj.RazonSocial = (string)dr["razon_social"];

                  if (dr["ruc"] != System.DBNull.Value)
                      obj.Ruc = (string)dr["ruc"];

              }
          }
          return obj;
      }

      public int Agregar(CotizacionLineaProveedorDTO obj)
      {
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_AGREGAR);
          db.AddInParameter(dbCommand, "@id_cotizacion", DbType.Int32, obj.IdCotizacion);
          db.AddInParameter(dbCommand, "@id_cotizacion_linea", DbType.Int32, obj.IdCotizacionLinea);
          db.AddInParameter(dbCommand, "@id_proveedor", DbType.Int32, obj.IdProveedor);
          db.AddInParameter(dbCommand, "@precio", DbType.Decimal, obj.Precio);
          db.AddInParameter(dbCommand, "@cantidad", DbType.Decimal, obj.Cantidad);
          db.AddInParameter(dbCommand, "@importe", DbType.Decimal, obj.Importe);

          if (obj.FechaPactada.Year == 1)
              db.AddInParameter(dbCommand, "@fecha_pactada", DbType.DateTime, null);
          else
              db.AddInParameter(dbCommand, "@fecha_pactada", DbType.DateTime, obj.FechaPactada);
                    
          db.AddInParameter(dbCommand, "@flag_igv", DbType.String, obj.FlagIgv);
          db.AddInParameter(dbCommand, "@flag_seleccionado", DbType.String, obj.FlagSeleccionado);
          db.AddInParameter(dbCommand, "@anotaciones", DbType.String, obj.Anotaciones);
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
          return 0;
      }

      public void Actualizar(CotizacionLineaProveedorDTO obj)
      {
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_ACTUALIZAR);
          db.AddInParameter(dbCommand, "@id_cotizacion", DbType.Int32, obj.IdCotizacion);
          db.AddInParameter(dbCommand, "@id_cotizacion_linea", DbType.Int32, obj.IdCotizacionLinea);
          db.AddInParameter(dbCommand, "@id_proveedor", DbType.Int32, obj.IdProveedor);
          db.AddInParameter(dbCommand, "@precio", DbType.Decimal, obj.Precio);
          db.AddInParameter(dbCommand, "@cantidad", DbType.Decimal, obj.Cantidad);
          db.AddInParameter(dbCommand, "@importe", DbType.Decimal, obj.Importe);
          db.AddInParameter(dbCommand, "@fecha_pactada", DbType.DateTime, obj.FechaPactada);
          db.AddInParameter(dbCommand, "@flag_igv", DbType.String, obj.FlagIgv);
          db.AddInParameter(dbCommand, "@flag_seleccionado", DbType.String, obj.FlagSeleccionado);
          db.AddInParameter(dbCommand, "@anotaciones", DbType.String, obj.Anotaciones);
          db.AddInParameter(dbCommand, "@dias_entrega", DbType.Int32, obj.DiasEntrega);
          db.AddInParameter(dbCommand, "@id_usuario_creacion", DbType.Int32, obj.IdUsuarioCreacion);
          db.AddInParameter(dbCommand, "@fecha_creacion", DbType.DateTime, obj.FechaCreacion);
          db.AddInParameter(dbCommand, "@id_usuario_modificacion", DbType.Int32, obj.IdUsuarioModificacion);
          db.AddInParameter(dbCommand, "@fecha_modificacion", DbType.DateTime, obj.FechaModificacion);
          db.ExecuteNonQuery(dbCommand);
      }

      public void Eliminar(int IdCotizacion, int IdCotizacionLinea, int IdProveedor)
      {
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_ELIMINAR);
          db.AddInParameter(dbCommand, "@id_cotizacion", DbType.Int32, IdCotizacion);
          db.AddInParameter(dbCommand, "@id_cotizacion_linea", DbType.Int32, IdCotizacionLinea);
          db.AddInParameter(dbCommand, "@id_proveedor", DbType.Int32, IdProveedor);
          db.ExecuteNonQuery(dbCommand);
      }

      public CotizacionLineaProveedorDTO RecomendarProveedor (int IdCotizacion, int IdCotizacionLinea)
      {
          CotizacionLineaProveedorDTO obj = null;
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_RECOMENDAR);
          db.AddInParameter(dbCommand, "@id_cotizacion", DbType.Int32, IdCotizacion);
          db.AddInParameter(dbCommand, "@id_cotizacion_linea", DbType.Int32, IdCotizacionLinea);

          using (IDataReader dr = db.ExecuteReader(dbCommand))
          {
              if (dr.Read())
              {
                  obj = new CotizacionLineaProveedorDTO();

                  if (dr["id_cotizacion"] != System.DBNull.Value)
                      obj.IdCotizacion = (int)dr["id_cotizacion"];
                  if (dr["id_cotizacion_linea"] != System.DBNull.Value)
                      obj.IdCotizacionLinea = (int)dr["id_cotizacion_linea"];
                  if (dr["id_proveedor"] != System.DBNull.Value)
                      obj.IdProveedor = (int)dr["id_proveedor"];
                  if (dr["precio"] != System.DBNull.Value)
                      obj.Precio = (Decimal)dr["precio"];
                  if (dr["cantidad"] != System.DBNull.Value)
                      obj.Cantidad = (Decimal)dr["cantidad"];
                  if (dr["importe"] != System.DBNull.Value)
                      obj.Importe = (Decimal)dr["importe"];
                  if (dr["fecha_pactada"] != System.DBNull.Value)
                      obj.FechaPactada = (DateTime)dr["fecha_pactada"];
                  if (dr["flag_igv"] != System.DBNull.Value)
                      obj.FlagIgv = (string)dr["flag_igv"];
                  if (dr["flag_seleccionado"] != System.DBNull.Value)
                      obj.FlagSeleccionado = (string)dr["flag_seleccionado"];
                  if (dr["anotaciones"] != System.DBNull.Value)
                      obj.Anotaciones = (string)dr["anotaciones"];
                  if (dr["id_usuario_creacion"] != System.DBNull.Value)
                      obj.IdUsuarioCreacion = (int)dr["id_usuario_creacion"];
                  if (dr["fecha_creacion"] != System.DBNull.Value)
                      obj.FechaCreacion = (DateTime)dr["fecha_creacion"];
                  if (dr["id_usuario_modificacion"] != System.DBNull.Value)
                      obj.IdUsuarioModificacion = (int)dr["id_usuario_modificacion"];
                  if (dr["fecha_modificacion"] != System.DBNull.Value)
                      obj.FechaModificacion = (DateTime)dr["fecha_modificacion"];

                  if (dr["razon_social"] != System.DBNull.Value)
                      obj.RazonSocial = (string)dr["razon_social"];

                  if (dr["ruc"] != System.DBNull.Value)
                      obj.Ruc = (string)dr["ruc"];

                  if (dr["dias_entrega"] != System.DBNull.Value)
                      obj.DiasEntrega = (int)dr["dias_entrega"];

                  
              }
          }
          return obj;
      }
  }
}
