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
  public class OrdenCompraDAO
  {
      const string C_LISTAR = "USP_OrdenCompra_Listar";
      const string C_LISTAR_OS_ATENDIDOS = "USP_OrdenCompra_ListarOSAtendidos";
      const string C_ACTUALIZAR = "USP_OrdenCompra_Actualizar";
      const string C_AGREGAR = "USP_OrdenCompra_Agregar";
      const string C_ELIMINAR = "USP_OrdenCompra_Eliminar";
      const string C_GENERAR = "USP_OrdenCompra_Generar";
      const string C_LISTAR_POR_CLAVE = "USP_OrdenCompra_ListarPorClave";

      const string C_LISTAR_PENDIENTES_RECEPCION = "USP_OrdenCompra_ListarRecepcion";

      const string C_LISTAR_APROBACION_PENDIENTE = "USP_OrdenCompra_ListarAprobacionPendiente";
      const string C_LISTAR_APROBACION_LOGISTICA = "USP_OrdenCompra_ListarAprobacionLogistica";
      const string C_LISTAR_ENVIO_PROVEEDOR = "USP_OrdenCompra_ListarEnvioProveedor";

      const string C_USP_U_AnularOC = "USP_U_AnularOC";
      const string C_USP_DESCARTAR_OC = "USP_DESCARTAR_OC";


      public List<OrdenCompraDTO> ListarPendientesRecepcion()
      {
          List<OrdenCompraDTO> Lista = new List<OrdenCompraDTO>();
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_LISTAR_PENDIENTES_RECEPCION);
          using (IDataReader dr = db.ExecuteReader(dbCommand))
          {
              while (dr.Read())
              {
                  OrdenCompraDTO obj = new OrdenCompraDTO();

                  if (dr["id_orden_compra"] != System.DBNull.Value) obj.IdOrdenCompra = (int)dr["id_orden_compra"];

                  if (dr["id_proyecto"] != System.DBNull.Value) obj.IdProyecto = (int)dr["id_proyecto"];
                  if (dr["id_sede"] != System.DBNull.Value) obj.IdSede = (int)dr["id_sede"];
                  if (dr["id_proveedor"] != System.DBNull.Value) obj.IdProveedor = (int)dr["id_proveedor"];
                  if (dr["numero_orden_compra"] != System.DBNull.Value) obj.NumeroOrdenCompra = (string)dr["numero_orden_compra"];
                  if (dr["fecha_orden_compra"] != System.DBNull.Value) obj.FechaOrdenCompra = (DateTime)dr["fecha_orden_compra"];
                  if (dr["descripcion_orden_compra"] != System.DBNull.Value) obj.DescripcionOrdenCompra = (string)dr["descripcion_orden_compra"];
                  if (dr["cod_moneda"] != System.DBNull.Value) obj.CodMoneda = (string)dr["cod_moneda"];
                  if (dr["importe_orden_compra"] != System.DBNull.Value) obj.ImporteOrdenCompra = (Decimal)dr["importe_orden_compra"];
                  if (dr["id_forma_pago"] != System.DBNull.Value) obj.IdFormaPago = (int)dr["id_forma_pago"];

                  if (dr["id_cotizacion"] != System.DBNull.Value) obj.IdCotizacion = (int)dr["id_cotizacion"];

                  if (dr["estado_control"] != System.DBNull.Value) obj.EstadoControl = (string)dr["estado_control"];

                  if (dr["estado_aprobacion"] != System.DBNull.Value) obj.EstadoAprobacion = (string)dr["estado_aprobacion"];
                  if (dr["fecha_aprobacion"] != System.DBNull.Value) obj.FechaAprobacion = (DateTime)dr["fecha_aprobacion"];
                  if (dr["id_usuario_aprobacion"] != System.DBNull.Value) obj.IdUsuarioAprobacion = (int)dr["id_usuario_aprobacion"];

                  if (dr["enviado_proveedor"] != System.DBNull.Value) obj.EnviadoProveedor = (string)dr["enviado_proveedor"];
                  if (dr["fecha_envio_proveedor"] != System.DBNull.Value) obj.FechaEnvioProveedor = (DateTime)dr["fecha_envio_proveedor"];
                  if (dr["comentarios_envio_proveedor"] != System.DBNull.Value) obj.ComentariosEnvioProveedor = (string)dr["comentarios_envio_proveedor"];

                  if (dr["fecha_creacion"] != System.DBNull.Value) obj.FechaCreacion = (DateTime)dr["fecha_creacion"];
                  if (dr["id_usuario_creacion"] != System.DBNull.Value) obj.IdUsuarioCreacion = (int)dr["id_usuario_creacion"];
                  if (dr["fecha_modificacion"] != System.DBNull.Value) obj.FechaModificacion = (DateTime)dr["fecha_modificacion"];
                  if (dr["id_usuario_modificacion"] != System.DBNull.Value) obj.IdUsuarioModificacion = (int)dr["id_usuario_modificacion"];

                  if (dr["nombre_proyecto"] != System.DBNull.Value) obj.NombreProyecto = (string)dr["nombre_proyecto"];
                  if (dr["nombre_sede"] != System.DBNull.Value) obj.NombreSede = (string)dr["nombre_sede"];
                  if (dr["nombre_moneda"] != System.DBNull.Value) obj.NombreMoneda = (string)dr["nombre_moneda"];
                  if (dr["razon_social"] != System.DBNull.Value) obj.RazonSocial = (string)dr["razon_social"];

                  if (dr["nombre_estado_control"] != System.DBNull.Value) obj.NombreEstadoControl = (string)dr["nombre_estado_control"];
                  if (dr["nombre_estado_aprobacion"] != System.DBNull.Value) obj.NombreEstadoAprobacion = (string)dr["nombre_estado_aprobacion"];
                  if (dr["nombre_tipo_orden_compra"] != System.DBNull.Value) obj.NombreTipoOrdenCompra = (string)dr["nombre_tipo_orden_compra"];

                  if (dr["flag_igv"] != System.DBNull.Value) obj.FlagIGV = (string)dr["flag_igv"];

                  if (dr["recepcionado"] != System.DBNull.Value) obj.Recepcionadoitems = (Decimal)dr["recepcionado"];
                  if (dr["totalorden"] != System.DBNull.Value) obj.Totalitems = (Decimal)dr["totalorden"];
                  if (dr["faltante"] != System.DBNull.Value) obj.Faltante = (Decimal)dr["faltante"];

                  //if (dr["NRO_COTIZ_PROV"] != System.DBNull.Value) obj.NroCotizProv = (string)dr["NRO_COTIZ_PROV"];

                  Lista.Add(obj);
              }
          }
          return Lista;
      }
      
      public List<OrdenCompraDTO> Listar(string modo)
      {
          List<OrdenCompraDTO> Lista = new List<OrdenCompraDTO>();
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_LISTAR);
          db.AddInParameter(dbCommand, "@modo", DbType.String, modo);
          using (IDataReader dr = db.ExecuteReader(dbCommand)) 
          {
              while (dr.Read())
              {
                  OrdenCompraDTO obj = new OrdenCompraDTO();

                  if (dr["id_orden_compra"] != System.DBNull.Value) obj.IdOrdenCompra = (int)dr["id_orden_compra"];
                  
                  if (dr["id_proyecto"] != System.DBNull.Value) obj.IdProyecto = (int)dr["id_proyecto"];
                  if (dr["id_sede"] != System.DBNull.Value) obj.IdSede = (int)dr["id_sede"];
                  if (dr["id_proveedor"] != System.DBNull.Value) obj.IdProveedor = (int)dr["id_proveedor"];
                  if (dr["numero_orden_compra"] != System.DBNull.Value) obj.NumeroOrdenCompra = (string)dr["numero_orden_compra"];
                  if (dr["fecha_orden_compra"] != System.DBNull.Value)  obj.FechaOrdenCompra = (DateTime)dr["fecha_orden_compra"];
                  if (dr["descripcion_orden_compra"] != System.DBNull.Value) obj.DescripcionOrdenCompra = (string)dr["descripcion_orden_compra"];
                  if (dr["cod_moneda"] != System.DBNull.Value) obj.CodMoneda = (string)dr["cod_moneda"];
                  if (dr["importe_orden_compra"] != System.DBNull.Value) obj.ImporteOrdenCompra = (Decimal)dr["importe_orden_compra"];
                  if (dr["id_forma_pago"] != System.DBNull.Value) obj.IdFormaPago = (int)dr["id_forma_pago"];

                  if (dr["id_cotizacion"] != System.DBNull.Value) obj.IdCotizacion = (int)dr["id_cotizacion"];

                  if (dr["estado_control"] != System.DBNull.Value) obj.EstadoControl = (string)dr["estado_control"];

                  if (dr["estado_aprobacion"] != System.DBNull.Value) obj.EstadoAprobacion = (string)dr["estado_aprobacion"];
                  if (dr["fecha_aprobacion"] != System.DBNull.Value) obj.FechaAprobacion = (DateTime)dr["fecha_aprobacion"];
                  if (dr["id_usuario_aprobacion"] != System.DBNull.Value) obj.IdUsuarioAprobacion = (int)dr["id_usuario_aprobacion"];

                  if (dr["enviado_proveedor"] != System.DBNull.Value) obj.EnviadoProveedor = (string)dr["enviado_proveedor"];
                  if (dr["fecha_envio_proveedor"] != System.DBNull.Value) obj.FechaEnvioProveedor = (DateTime)dr["fecha_envio_proveedor"];
                  if (dr["comentarios_envio_proveedor"] != System.DBNull.Value) obj.ComentariosEnvioProveedor = (string)dr["comentarios_envio_proveedor"];
                  
                  if (dr["fecha_creacion"] != System.DBNull.Value) obj.FechaCreacion = (DateTime)dr["fecha_creacion"];
                  if (dr["id_usuario_creacion"] != System.DBNull.Value) obj.IdUsuarioCreacion = (int)dr["id_usuario_creacion"];
                  if (dr["fecha_modificacion"] != System.DBNull.Value) obj.FechaModificacion = (DateTime)dr["fecha_modificacion"];
                  if (dr["id_usuario_modificacion"] != System.DBNull.Value) obj.IdUsuarioModificacion = (int)dr["id_usuario_modificacion"];

                  if (dr["nombre_proyecto"] != System.DBNull.Value) obj.NombreProyecto = (string)dr["nombre_proyecto"];
                  if (dr["nombre_sede"] != System.DBNull.Value) obj.NombreSede = (string)dr["nombre_sede"];
                  if (dr["nombre_moneda"] != System.DBNull.Value) obj.NombreMoneda = (string)dr["nombre_moneda"];
                  if (dr["razon_social"] != System.DBNull.Value) obj.RazonSocial = (string)dr["razon_social"];

                  if (dr["nombre_estado_control"] != System.DBNull.Value) obj.NombreEstadoControl = (string)dr["nombre_estado_control"];
                  if (dr["nombre_estado_aprobacion"] != System.DBNull.Value) obj.NombreEstadoAprobacion = (string)dr["nombre_estado_aprobacion"];
                  if (dr["nombre_tipo_orden_compra"] != System.DBNull.Value) obj.NombreTipoOrdenCompra = (string)dr["nombre_tipo_orden_compra"];

                  if (dr["flag_igv"] != System.DBNull.Value) obj.FlagIGV = (string)dr["flag_igv"];

                  if (dr["FECHA_ANULACION"] != System.DBNull.Value) obj.FechaAnula = (DateTime)dr["Fecha_anulacion"];
                  if (dr["ID_USUARIO_ANULACION"] != System.DBNull.Value) obj.IdUsuarioAnulacion = (string)dr["ID_USUARIO_ANULACION"];
                  if (dr["motivo_anula"] != System.DBNull.Value) obj.MotivoAnula = (string)dr["motivo_anula"];

                  //if (dr["NRO_COTIZ_PROV"] != System.DBNull.Value) obj.NroCotizProv = (string)dr["NRO_COTIZ_PROV"];

                  Lista.Add(obj);
              }
          }
          return Lista;
      }

      public List<OrdenCompraDTO> ListarOrdenServicioAtendidas()
      {
          List<OrdenCompraDTO> Lista = new List<OrdenCompraDTO>();
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_LISTAR_OS_ATENDIDOS);
          using (IDataReader dr = db.ExecuteReader(dbCommand))
          {
              while (dr.Read())
              {
                  OrdenCompraDTO obj = new OrdenCompraDTO();

                  if (dr["id_orden_compra"] != System.DBNull.Value) obj.IdOrdenCompra = (int)dr["id_orden_compra"];

                  if (dr["id_proyecto"] != System.DBNull.Value) obj.IdProyecto = (int)dr["id_proyecto"];
                  if (dr["id_sede"] != System.DBNull.Value) obj.IdSede = (int)dr["id_sede"];
                  if (dr["id_proveedor"] != System.DBNull.Value) obj.IdProveedor = (int)dr["id_proveedor"];
                  if (dr["numero_orden_compra"] != System.DBNull.Value) obj.NumeroOrdenCompra = (string)dr["numero_orden_compra"];
                  if (dr["fecha_orden_compra"] != System.DBNull.Value) obj.FechaOrdenCompra = (DateTime)dr["fecha_orden_compra"];
                  if (dr["descripcion_orden_compra"] != System.DBNull.Value) obj.DescripcionOrdenCompra = (string)dr["descripcion_orden_compra"];
                  if (dr["cod_moneda"] != System.DBNull.Value) obj.CodMoneda = (string)dr["cod_moneda"];
                  if (dr["importe_orden_compra"] != System.DBNull.Value) obj.ImporteOrdenCompra = (Decimal)dr["importe_orden_compra"];
                  if (dr["id_forma_pago"] != System.DBNull.Value) obj.IdFormaPago = (int)dr["id_forma_pago"];

                  if (dr["id_cotizacion"] != System.DBNull.Value) obj.IdCotizacion = (int)dr["id_cotizacion"];

                  if (dr["estado_control"] != System.DBNull.Value) obj.EstadoControl = (string)dr["estado_control"];

                  if (dr["estado_aprobacion"] != System.DBNull.Value) obj.EstadoAprobacion = (string)dr["estado_aprobacion"];
                  if (dr["fecha_aprobacion"] != System.DBNull.Value) obj.FechaAprobacion = (DateTime)dr["fecha_aprobacion"];
                  if (dr["id_usuario_aprobacion"] != System.DBNull.Value) obj.IdUsuarioAprobacion = (int)dr["id_usuario_aprobacion"];

                  if (dr["enviado_proveedor"] != System.DBNull.Value) obj.EnviadoProveedor = (string)dr["enviado_proveedor"];
                  if (dr["fecha_envio_proveedor"] != System.DBNull.Value) obj.FechaEnvioProveedor = (DateTime)dr["fecha_envio_proveedor"];
                  if (dr["comentarios_envio_proveedor"] != System.DBNull.Value) obj.ComentariosEnvioProveedor = (string)dr["comentarios_envio_proveedor"];

                  if (dr["fecha_creacion"] != System.DBNull.Value) obj.FechaCreacion = (DateTime)dr["fecha_creacion"];
                  if (dr["id_usuario_creacion"] != System.DBNull.Value) obj.IdUsuarioCreacion = (int)dr["id_usuario_creacion"];
                  if (dr["fecha_modificacion"] != System.DBNull.Value) obj.FechaModificacion = (DateTime)dr["fecha_modificacion"];
                  if (dr["id_usuario_modificacion"] != System.DBNull.Value) obj.IdUsuarioModificacion = (int)dr["id_usuario_modificacion"];

                  if (dr["nombre_proyecto"] != System.DBNull.Value) obj.NombreProyecto = (string)dr["nombre_proyecto"];
                  if (dr["nombre_sede"] != System.DBNull.Value) obj.NombreSede = (string)dr["nombre_sede"];
                  if (dr["nombre_moneda"] != System.DBNull.Value) obj.NombreMoneda = (string)dr["nombre_moneda"];
                  if (dr["razon_social"] != System.DBNull.Value) obj.RazonSocial = (string)dr["razon_social"];

                  if (dr["nombre_estado_control"] != System.DBNull.Value) obj.NombreEstadoControl = (string)dr["nombre_estado_control"];
                  if (dr["nombre_estado_aprobacion"] != System.DBNull.Value) obj.NombreEstadoAprobacion = (string)dr["nombre_estado_aprobacion"];
                  if (dr["nombre_tipo_orden_compra"] != System.DBNull.Value) obj.NombreTipoOrdenCompra = (string)dr["nombre_tipo_orden_compra"];

                  if (dr["flag_igv"] != System.DBNull.Value) obj.FlagIGV = (string)dr["flag_igv"];

                  Lista.Add(obj);
              }
          }
          return Lista;
      }


      public List<OrdenCompraDTO> ListarAprobacionLogistica()
      {
          List<OrdenCompraDTO> Lista = new List<OrdenCompraDTO>();
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_LISTAR_APROBACION_LOGISTICA);
          using (IDataReader dr = db.ExecuteReader(dbCommand))
          {
              while (dr.Read())
              {
                  OrdenCompraDTO obj = new OrdenCompraDTO();
  
                  if (dr["id_orden_compra"] != System.DBNull.Value)  obj.IdOrdenCompra = (int)dr["id_orden_compra"];
                  if (dr["id_proyecto"] != System.DBNull.Value) obj.IdProyecto = (int)dr["id_proyecto"];
                  if (dr["id_sede"] != System.DBNull.Value) obj.IdSede = (int)dr["id_sede"];
                  if (dr["id_proveedor"] != System.DBNull.Value) obj.IdProveedor = (int)dr["id_proveedor"];
                  if (dr["numero_orden_compra"] != System.DBNull.Value) obj.NumeroOrdenCompra = (string)dr["numero_orden_compra"];
                  if (dr["fecha_orden_compra"] != System.DBNull.Value) obj.FechaOrdenCompra = (DateTime)dr["fecha_orden_compra"];
                  if (dr["descripcion_orden_compra"] != System.DBNull.Value) obj.DescripcionOrdenCompra = (string)dr["descripcion_orden_compra"];
                  if (dr["cod_moneda"] != System.DBNull.Value) obj.CodMoneda = (string)dr["cod_moneda"];
                  if (dr["importe_orden_compra"] != System.DBNull.Value) obj.ImporteOrdenCompra = (Decimal)dr["importe_orden_compra"];
                  if (dr["id_forma_pago"] != System.DBNull.Value) obj.IdFormaPago = (int)dr["id_forma_pago"];

                  if (dr["id_cotizacion"] != System.DBNull.Value) obj.IdCotizacion = (int)dr["id_cotizacion"];
                  if (dr["estado_control"] != System.DBNull.Value) obj.EstadoControl = (string)dr["estado_control"];
                  if (dr["estado_aprobacion"] != System.DBNull.Value) obj.EstadoAprobacion = (string)dr["estado_aprobacion"];
                  if (dr["fecha_aprobacion"] != System.DBNull.Value) obj.FechaAprobacion = (DateTime)dr["fecha_aprobacion"];
                  if (dr["id_usuario_aprobacion"] != System.DBNull.Value) obj.IdUsuarioAprobacion = (int)dr["id_usuario_aprobacion"];

                  if (dr["enviado_proveedor"] != System.DBNull.Value) obj.EnviadoProveedor = (string)dr["enviado_proveedor"];
                  if (dr["fecha_envio_proveedor"] != System.DBNull.Value) obj.FechaEnvioProveedor = (DateTime)dr["fecha_envio_proveedor"];
                  if (dr["comentarios_envio_proveedor"] != System.DBNull.Value) obj.ComentariosEnvioProveedor = (string)dr["comentarios_envio_proveedor"];

                  if (dr["fecha_creacion"] != System.DBNull.Value) obj.FechaCreacion = (DateTime)dr["fecha_creacion"];
                  if (dr["id_usuario_creacion"] != System.DBNull.Value) obj.IdUsuarioCreacion = (int)dr["id_usuario_creacion"];
                  if (dr["fecha_modificacion"] != System.DBNull.Value) obj.FechaModificacion = (DateTime)dr["fecha_modificacion"];
                  if (dr["id_usuario_modificacion"] != System.DBNull.Value) obj.IdUsuarioModificacion = (int)dr["id_usuario_modificacion"];

                  if (dr["nombre_proyecto"] != System.DBNull.Value) obj.NombreProyecto = (string)dr["nombre_proyecto"];
                  if (dr["nombre_sede"] != System.DBNull.Value) obj.NombreSede = (string)dr["nombre_sede"];
                  if (dr["nombre_moneda"] != System.DBNull.Value) obj.NombreMoneda = (string)dr["nombre_moneda"];
                  if (dr["razon_social"] != System.DBNull.Value) obj.RazonSocial = (string)dr["razon_social"];

                  if (dr["nombre_estado_control"] != System.DBNull.Value) obj.NombreEstadoControl = (string)dr["nombre_estado_control"];
                  if (dr["nombre_estado_aprobacion"] != System.DBNull.Value) obj.NombreEstadoAprobacion = (string)dr["nombre_estado_aprobacion"];
                  if (dr["nombre_tipo_orden_compra"] != System.DBNull.Value) obj.NombreTipoOrdenCompra = (string)dr["nombre_tipo_orden_compra"];

                  if (dr["flag_igv"] != System.DBNull.Value) obj.FlagIGV = (string)dr["flag_igv"];

                  Lista.Add(obj);
              }
          }
          return Lista;
      }

      public List<OrdenCompraDTO> ListarAprobacionPendiente(int IdUsuarioAprobacion)
      {
          List<OrdenCompraDTO> Lista = new List<OrdenCompraDTO>();
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_LISTAR_APROBACION_PENDIENTE);
          db.AddInParameter(dbCommand, "@id_usuario_aprobacion", DbType.Int32, IdUsuarioAprobacion);

          using (IDataReader dr = db.ExecuteReader(dbCommand))
          {
              while (dr.Read())
              {
                  OrdenCompraDTO obj = new OrdenCompraDTO();

                  if (dr["id_orden_compra"] != System.DBNull.Value) obj.IdOrdenCompra = (int)dr["id_orden_compra"];
                  if (dr["id_proyecto"] != System.DBNull.Value) obj.IdProyecto = (int)dr["id_proyecto"];
                  if (dr["id_sede"] != System.DBNull.Value) obj.IdSede = (int)dr["id_sede"];
                  if (dr["id_proveedor"] != System.DBNull.Value) obj.IdProveedor = (int)dr["id_proveedor"];
                  if (dr["numero_orden_compra"] != System.DBNull.Value) obj.NumeroOrdenCompra = (string)dr["numero_orden_compra"];
                  if (dr["fecha_orden_compra"] != System.DBNull.Value) obj.FechaOrdenCompra = (DateTime)dr["fecha_orden_compra"];
                  if (dr["descripcion_orden_compra"] != System.DBNull.Value) obj.DescripcionOrdenCompra = (string)dr["descripcion_orden_compra"];
                  if (dr["cod_moneda"] != System.DBNull.Value) obj.CodMoneda = (string)dr["cod_moneda"];
                  if (dr["importe_orden_compra"] != System.DBNull.Value) obj.ImporteOrdenCompra = (Decimal)dr["importe_orden_compra"];
                  if (dr["id_forma_pago"] != System.DBNull.Value) obj.IdFormaPago = (int)dr["id_forma_pago"];

                  if (dr["id_cotizacion"] != System.DBNull.Value) obj.IdCotizacion = (int)dr["id_cotizacion"];
                  if (dr["estado_control"] != System.DBNull.Value) obj.EstadoControl = (string)dr["estado_control"];
                  if (dr["estado_aprobacion"] != System.DBNull.Value) obj.EstadoAprobacion = (string)dr["estado_aprobacion"];
                  if (dr["fecha_aprobacion"] != System.DBNull.Value) obj.FechaAprobacion = (DateTime)dr["fecha_aprobacion"];
                  if (dr["id_usuario_aprobacion"] != System.DBNull.Value) obj.IdUsuarioAprobacion = (int)dr["id_usuario_aprobacion"];

                  if (dr["enviado_proveedor"] != System.DBNull.Value) obj.EnviadoProveedor = (string)dr["enviado_proveedor"];
                  if (dr["fecha_envio_proveedor"] != System.DBNull.Value) obj.FechaEnvioProveedor = (DateTime)dr["fecha_envio_proveedor"];
                  if (dr["comentarios_envio_proveedor"] != System.DBNull.Value) obj.ComentariosEnvioProveedor = (string)dr["comentarios_envio_proveedor"];

                  if (dr["fecha_creacion"] != System.DBNull.Value) obj.FechaCreacion = (DateTime)dr["fecha_creacion"];
                  if (dr["id_usuario_creacion"] != System.DBNull.Value) obj.IdUsuarioCreacion = (int)dr["id_usuario_creacion"];
                  if (dr["fecha_modificacion"] != System.DBNull.Value) obj.FechaModificacion = (DateTime)dr["fecha_modificacion"];
                  if (dr["id_usuario_modificacion"] != System.DBNull.Value) obj.IdUsuarioModificacion = (int)dr["id_usuario_modificacion"];

                  if (dr["nombre_proyecto"] != System.DBNull.Value) obj.NombreProyecto = (string)dr["nombre_proyecto"];
                  if (dr["nombre_sede"] != System.DBNull.Value) obj.NombreSede = (string)dr["nombre_sede"];
                  if (dr["nombre_moneda"] != System.DBNull.Value) obj.NombreMoneda = (string)dr["nombre_moneda"];
                  if (dr["razon_social"] != System.DBNull.Value) obj.RazonSocial = (string)dr["razon_social"];

                  if (dr["nombre_estado_control"] != System.DBNull.Value) obj.NombreEstadoControl = (string)dr["nombre_estado_control"];
                  if (dr["nombre_estado_aprobacion"] != System.DBNull.Value) obj.NombreEstadoAprobacion = (string)dr["nombre_estado_aprobacion"];
                  if (dr["nombre_tipo_orden_compra"] != System.DBNull.Value) obj.NombreTipoOrdenCompra = (string)dr["nombre_tipo_orden_compra"];

                  if (dr["flag_igv"] != System.DBNull.Value) obj.FlagIGV = (string)dr["flag_igv"];

                  Lista.Add(obj);
              }
          }
          return Lista;
      }

      public List<OrdenCompraDTO> ListarPendienteEnvioProveedor()
      {
          List<OrdenCompraDTO> Lista = new List<OrdenCompraDTO>();
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_LISTAR_ENVIO_PROVEEDOR);
          using (IDataReader dr = db.ExecuteReader(dbCommand))
          {
              while (dr.Read())
              {
                  OrdenCompraDTO obj = new OrdenCompraDTO();

                  if (dr["id_orden_compra"] != System.DBNull.Value) obj.IdOrdenCompra = (int)dr["id_orden_compra"];
                  if (dr["id_proyecto"] != System.DBNull.Value) obj.IdProyecto = (int)dr["id_proyecto"];
                  if (dr["id_sede"] != System.DBNull.Value) obj.IdSede = (int)dr["id_sede"];
                  if (dr["id_proveedor"] != System.DBNull.Value) obj.IdProveedor = (int)dr["id_proveedor"];
                  if (dr["numero_orden_compra"] != System.DBNull.Value) obj.NumeroOrdenCompra = (string)dr["numero_orden_compra"];
                  if (dr["fecha_orden_compra"] != System.DBNull.Value) obj.FechaOrdenCompra = (DateTime)dr["fecha_orden_compra"];
                  if (dr["descripcion_orden_compra"] != System.DBNull.Value) obj.DescripcionOrdenCompra = (string)dr["descripcion_orden_compra"];
                  if (dr["cod_moneda"] != System.DBNull.Value) obj.CodMoneda = (string)dr["cod_moneda"];
                  if (dr["importe_orden_compra"] != System.DBNull.Value) obj.ImporteOrdenCompra = (Decimal)dr["importe_orden_compra"];
                  if (dr["id_forma_pago"] != System.DBNull.Value) obj.IdFormaPago = (int)dr["id_forma_pago"];

                  if (dr["id_cotizacion"] != System.DBNull.Value) obj.IdCotizacion = (int)dr["id_cotizacion"];
                  if (dr["estado_control"] != System.DBNull.Value) obj.EstadoControl = (string)dr["estado_control"];
                  if (dr["estado_aprobacion"] != System.DBNull.Value) obj.EstadoAprobacion = (string)dr["estado_aprobacion"];
                  if (dr["fecha_aprobacion"] != System.DBNull.Value) obj.FechaAprobacion = (DateTime)dr["fecha_aprobacion"];
                  if (dr["id_usuario_aprobacion"] != System.DBNull.Value) obj.IdUsuarioAprobacion = (int)dr["id_usuario_aprobacion"];

                  if (dr["enviado_proveedor"] != System.DBNull.Value) obj.EnviadoProveedor = (string)dr["enviado_proveedor"];
                  if (dr["fecha_envio_proveedor"] != System.DBNull.Value) obj.FechaEnvioProveedor = (DateTime)dr["fecha_envio_proveedor"];
                  if (dr["comentarios_envio_proveedor"] != System.DBNull.Value) obj.ComentariosEnvioProveedor = (string)dr["comentarios_envio_proveedor"];

                  if (dr["fecha_creacion"] != System.DBNull.Value) obj.FechaCreacion = (DateTime)dr["fecha_creacion"];
                  if (dr["id_usuario_creacion"] != System.DBNull.Value) obj.IdUsuarioCreacion = (int)dr["id_usuario_creacion"];
                  if (dr["fecha_modificacion"] != System.DBNull.Value) obj.FechaModificacion = (DateTime)dr["fecha_modificacion"];
                  if (dr["id_usuario_modificacion"] != System.DBNull.Value) obj.IdUsuarioModificacion = (int)dr["id_usuario_modificacion"];

                  if (dr["nombre_proyecto"] != System.DBNull.Value) obj.NombreProyecto = (string)dr["nombre_proyecto"];
                  if (dr["nombre_sede"] != System.DBNull.Value) obj.NombreSede = (string)dr["nombre_sede"];
                  if (dr["nombre_moneda"] != System.DBNull.Value) obj.NombreMoneda = (string)dr["nombre_moneda"];
                  if (dr["razon_social"] != System.DBNull.Value) obj.RazonSocial = (string)dr["razon_social"];

                  if (dr["nombre_estado_control"] != System.DBNull.Value) obj.NombreEstadoControl = (string)dr["nombre_estado_control"];
                  if (dr["nombre_estado_aprobacion"] != System.DBNull.Value) obj.NombreEstadoAprobacion = (string)dr["nombre_estado_aprobacion"];
                  if (dr["nombre_tipo_orden_compra"] != System.DBNull.Value) obj.NombreTipoOrdenCompra = (string)dr["nombre_tipo_orden_compra"];

                  if (dr["flag_igv"] != System.DBNull.Value) obj.FlagIGV = (string)dr["flag_igv"];

                  Lista.Add(obj);
              }
          }
          return Lista;
      }

      public OrdenCompraDTO ListarPorClave(int IdOrdenCompra)
      {
          OrdenCompraDTO obj = null;
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_LISTAR_POR_CLAVE);
          db.AddInParameter(dbCommand, "@id_orden_compra", DbType.Int32, IdOrdenCompra);

          using (IDataReader dr = db.ExecuteReader(dbCommand))
          {
              if (dr.Read())
              {
                  obj = new OrdenCompraDTO();

                  if (dr["id_orden_compra"] != System.DBNull.Value) obj.IdOrdenCompra = (int)dr["id_orden_compra"];
                  if (dr["id_proyecto"] != System.DBNull.Value) obj.IdProyecto = (int)dr["id_proyecto"];
                  if (dr["id_sede"] != System.DBNull.Value) obj.IdSede = (int)dr["id_sede"];
                  if (dr["id_proveedor"] != System.DBNull.Value) obj.IdProveedor = (int)dr["id_proveedor"];
                  if (dr["numero_orden_compra"] != System.DBNull.Value) obj.NumeroOrdenCompra = (string)dr["numero_orden_compra"];
                  if (dr["fecha_orden_compra"] != System.DBNull.Value) obj.FechaOrdenCompra = (DateTime)dr["fecha_orden_compra"];
                  if (dr["descripcion_orden_compra"] != System.DBNull.Value) obj.DescripcionOrdenCompra = (string)dr["descripcion_orden_compra"];
                  if (dr["cod_moneda"] != System.DBNull.Value) obj.CodMoneda = (string)dr["cod_moneda"];
                  if (dr["importe_orden_compra"] != System.DBNull.Value) obj.ImporteOrdenCompra = (Decimal)dr["importe_orden_compra"];
                  if (dr["id_forma_pago"] != System.DBNull.Value) obj.IdFormaPago = (int)dr["id_forma_pago"];

                  if (dr["id_cotizacion"] != System.DBNull.Value) obj.IdCotizacion = (int)dr["id_cotizacion"];
                  if (dr["estado_control"] != System.DBNull.Value) obj.EstadoControl = (string)dr["estado_control"];
                  if (dr["estado_aprobacion"] != System.DBNull.Value) obj.EstadoAprobacion = (string)dr["estado_aprobacion"];
                  if (dr["fecha_aprobacion"] != System.DBNull.Value) obj.FechaAprobacion = (DateTime)dr["fecha_aprobacion"];
                  if (dr["id_usuario_aprobacion"] != System.DBNull.Value) obj.IdUsuarioAprobacion = (int)dr["id_usuario_aprobacion"];

                  if (dr["enviado_proveedor"] != System.DBNull.Value) obj.EnviadoProveedor = (string)dr["enviado_proveedor"];
                  if (dr["fecha_envio_proveedor"] != System.DBNull.Value) obj.FechaEnvioProveedor = (DateTime)dr["fecha_envio_proveedor"];
                  if (dr["comentarios_envio_proveedor"] != System.DBNull.Value) obj.ComentariosEnvioProveedor = (string)dr["comentarios_envio_proveedor"];

                  if (dr["fecha_creacion"] != System.DBNull.Value) obj.FechaCreacion = (DateTime)dr["fecha_creacion"];
                  if (dr["id_usuario_creacion"] != System.DBNull.Value) obj.IdUsuarioCreacion = (int)dr["id_usuario_creacion"];
                  if (dr["fecha_modificacion"] != System.DBNull.Value) obj.FechaModificacion = (DateTime)dr["fecha_modificacion"];
                  if (dr["id_usuario_modificacion"] != System.DBNull.Value) obj.IdUsuarioModificacion = (int)dr["id_usuario_modificacion"];

                  if (dr["nombre_proyecto"] != System.DBNull.Value) obj.NombreProyecto = (string)dr["nombre_proyecto"];
                  if (dr["nombre_sede"] != System.DBNull.Value) obj.NombreSede = (string)dr["nombre_sede"];
                  if (dr["nombre_moneda"] != System.DBNull.Value) obj.NombreMoneda = (string)dr["nombre_moneda"];
                  if (dr["razon_social"] != System.DBNull.Value) obj.RazonSocial = (string)dr["razon_social"];

                  if (dr["nombre_estado_control"] != System.DBNull.Value) obj.NombreEstadoControl = (string)dr["nombre_estado_control"];
                  if (dr["nombre_estado_aprobacion"] != System.DBNull.Value) obj.NombreEstadoAprobacion = (string)dr["nombre_estado_aprobacion"];

                  if (dr["fecha_entrega"] != System.DBNull.Value) obj.FechaEntrega = (DateTime)dr["fecha_entrega"];
                  if (dr["id_tipo_orden_compra"] != System.DBNull.Value) obj.IdTipoOrdenCompra = (int)dr["id_tipo_orden_compra"];
                  if (dr["nombre_tipo_orden_compra"] != System.DBNull.Value) obj.NombreTipoOrdenCompra = (string)dr["nombre_tipo_orden_compra"];

                  if (dr["flag_igv"] != System.DBNull.Value) obj.FlagIGV = (string)dr["flag_igv"];

                  if (dr["NRO_COTIZ_PROV"] != System.DBNull.Value) obj.NroCotizProv = (string)dr["NRO_COTIZ_PROV"];

                  if (dr["Redondeo"] != System.DBNull.Value) obj.Redondeo = (Decimal)dr["Redondeo"];

              }
          }
          return obj;
      }

      public int Anular(int idOrdenCompra, string motivo, int usuario_anula)
      {
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_USP_U_AnularOC);
          db.AddInParameter(dbCommand, "@id_ordencompra", DbType.Int32, idOrdenCompra);
          db.AddInParameter(dbCommand, "@motivo", DbType.String, motivo);
          //db.AddInParameter(dbCommand, "@fecha_anula", DbType.DateTime, fecha_anula);
          db.AddInParameter(dbCommand, "@id_usuario", DbType.Int32, usuario_anula);
          int retorno = db.ExecuteNonQuery(dbCommand);
          return retorno;
      }

      public int Descartar(int idOrdenCompra, string motivo, int usuario_anula)
      {
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_USP_DESCARTAR_OC);
          db.AddInParameter(dbCommand, "@id_ordencompra", DbType.Int32, idOrdenCompra);
          db.AddInParameter(dbCommand, "@motivo", DbType.String, motivo);
          //db.AddInParameter(dbCommand, "@fecha_anula", DbType.DateTime, fecha_anula);
          db.AddInParameter(dbCommand, "@id_usuario", DbType.Int32, usuario_anula);
          int retorno = db.ExecuteNonQuery(dbCommand);
          return retorno;
      }

      public int Generar(int IdCotizacion, int IdUsuarioCreacion)
      {
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_GENERAR);
          db.AddInParameter(dbCommand, "@id_cotizacion", DbType.Int32, IdCotizacion);
          db.AddInParameter(dbCommand, "@id_usuario_creacion", DbType.Int32, IdUsuarioCreacion);
          int id = Convert.ToInt32(db.ExecuteScalar(dbCommand));
          return id;
      }
      
      public int Agregar(OrdenCompraDTO obj)
      {
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_AGREGAR);

          db.AddInParameter(dbCommand, "@id_proyecto", DbType.Int32, obj.IdProyecto);
          db.AddInParameter(dbCommand, "@id_sede", DbType.Int32, obj.IdSede);
          db.AddInParameter(dbCommand, "@id_proveedor", DbType.Int32, obj.IdProveedor);
          db.AddInParameter(dbCommand, "@numero_orden_compra", DbType.String, obj.NumeroOrdenCompra);
          db.AddInParameter(dbCommand, "@fecha_orden_compra", DbType.DateTime, GetFechaValida(obj.FechaOrdenCompra));
          db.AddInParameter(dbCommand, "@descripcion_orden_compra", DbType.String, obj.DescripcionOrdenCompra);
          db.AddInParameter(dbCommand, "@cod_moneda", DbType.String, obj.CodMoneda);
          db.AddInParameter(dbCommand, "@importe_orden_compra", DbType.Decimal, obj.ImporteOrdenCompra);
          db.AddInParameter(dbCommand, "@id_forma_pago", DbType.Int32, obj.IdFormaPago);
          
          db.AddInParameter(dbCommand, "@id_cotizacion", DbType.Int32, obj.IdCotizacion);
          db.AddInParameter(dbCommand, "@estado_control", DbType.String, obj.EstadoControl);

          db.AddInParameter(dbCommand, "@estado_aprobacion", DbType.String, obj.EstadoAprobacion);
          db.AddInParameter(dbCommand, "@fecha_aprobacion", DbType.DateTime, GetFechaValida(obj.FechaAprobacion));
          db.AddInParameter(dbCommand, "@id_usuario_aprobacion", DbType.Int32, obj.IdUsuarioAprobacion);

          db.AddInParameter(dbCommand, "@enviado_proveedor", DbType.String, obj.EnviadoProveedor);
          db.AddInParameter(dbCommand, "@fecha_envio_proveedor", DbType.DateTime, GetFechaValida(obj.FechaEnvioProveedor));
          db.AddInParameter(dbCommand, "@comentarios_envio_proveedor", DbType.String, obj.ComentariosEnvioProveedor);
          db.AddInParameter(dbCommand, "@fecha_entrega", DbType.DateTime, GetFechaValida(obj.FechaEntrega));
          db.AddInParameter(dbCommand, "@id_tipo_orden_compra", DbType.Int32, obj.IdTipoOrdenCompra);
          db.AddInParameter(dbCommand, "@flag_igv", DbType.String, obj.FlagIGV);

          db.AddInParameter(dbCommand, "@fecha_creacion", DbType.DateTime, GetFechaValida(obj.FechaCreacion));
          db.AddInParameter(dbCommand, "@id_usuario_creacion", DbType.Int32, obj.IdUsuarioCreacion);
          db.AddInParameter(dbCommand, "@fecha_modificacion", DbType.DateTime, GetFechaValida(obj.FechaModificacion));
          db.AddInParameter(dbCommand, "@id_usuario_modificacion", DbType.Int32, obj.IdUsuarioModificacion);

          int id = Convert.ToInt32(db.ExecuteScalar(dbCommand));

          return id;

      }

      public void Actualizar(OrdenCompraDTO obj)
      {
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_ACTUALIZAR);

          db.AddInParameter(dbCommand, "@id_orden_compra", DbType.Int32, obj.IdOrdenCompra);
          db.AddInParameter(dbCommand, "@id_proyecto", DbType.Int32, obj.IdProyecto);
          db.AddInParameter(dbCommand, "@id_sede", DbType.Int32, obj.IdSede);
          db.AddInParameter(dbCommand, "@id_proveedor", DbType.Int32, obj.IdProveedor);
          db.AddInParameter(dbCommand, "@numero_orden_compra", DbType.String, obj.NumeroOrdenCompra);
          db.AddInParameter(dbCommand, "@fecha_orden_compra", DbType.DateTime, GetFechaValida(obj.FechaOrdenCompra));
          db.AddInParameter(dbCommand, "@descripcion_orden_compra", DbType.String, obj.DescripcionOrdenCompra);
          db.AddInParameter(dbCommand, "@cod_moneda", DbType.String, obj.CodMoneda);
          db.AddInParameter(dbCommand, "@importe_orden_compra", DbType.Decimal, obj.ImporteOrdenCompra);
          db.AddInParameter(dbCommand, "@id_forma_pago", DbType.Int32, obj.IdFormaPago);

          db.AddInParameter(dbCommand, "@id_cotizacion", DbType.Int32, obj.IdCotizacion);
          db.AddInParameter(dbCommand, "@estado_control", DbType.String, obj.EstadoControl);

          db.AddInParameter(dbCommand, "@estado_aprobacion", DbType.String, obj.EstadoAprobacion);
          db.AddInParameter(dbCommand, "@fecha_aprobacion", DbType.DateTime, GetFechaValida(obj.FechaAprobacion));
          db.AddInParameter(dbCommand, "@id_usuario_aprobacion", DbType.Int32, obj.IdUsuarioAprobacion);

          db.AddInParameter(dbCommand, "@enviado_proveedor", DbType.String, obj.EnviadoProveedor);
          db.AddInParameter(dbCommand, "@fecha_envio_proveedor", DbType.DateTime, GetFechaValida(obj.FechaEnvioProveedor));
          db.AddInParameter(dbCommand, "@comentarios_envio_proveedor", DbType.String, obj.ComentariosEnvioProveedor);
          db.AddInParameter(dbCommand, "@fecha_entrega", DbType.DateTime, GetFechaValida(obj.FechaEntrega));
          db.AddInParameter(dbCommand, "@id_tipo_orden_compra", DbType.Int32, obj.IdTipoOrdenCompra);
          db.AddInParameter(dbCommand, "@flag_igv", DbType.String, obj.FlagIGV);

          db.AddInParameter(dbCommand, "@fecha_creacion", DbType.DateTime, GetFechaValida(obj.FechaCreacion));
          db.AddInParameter(dbCommand, "@id_usuario_creacion", DbType.Int32, obj.IdUsuarioCreacion);
          db.AddInParameter(dbCommand, "@fecha_modificacion", DbType.DateTime, GetFechaValida(obj.FechaModificacion));
          db.AddInParameter(dbCommand, "@id_usuario_modificacion", DbType.Int32, obj.IdUsuarioModificacion);

          db.AddInParameter(dbCommand, "@cotizprov", DbType.String, obj.NroCotizProv);
 
          db.ExecuteNonQuery(dbCommand);

      }

      public void Eliminar(int IdOrdenCompra)
      {
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_ELIMINAR);
          db.AddInParameter(dbCommand, "@id_orden_compra", DbType.Int32, IdOrdenCompra);
          db.ExecuteNonQuery(dbCommand);
      }

      protected object GetFechaValida(DateTime fecha) { 
        if (fecha.Year == 1)
            return null;
        else
            return fecha;
      }

  }
}
