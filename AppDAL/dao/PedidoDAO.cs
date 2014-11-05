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
    public class PedidoDAO
    {

        const string C_LISTAR = "USP_Pedido_Listar";
        const string C_ACTUALIZAR = "USP_Pedido_Actualizar";
        const string C_AGREGAR = "USP_Pedido_Agregar";
        const string C_ELIMINAR = "USP_Pedido_Eliminar";
        const string C_LISTAR_POR_CLAVE = "USP_Pedido_ListarPorClave";

        const string C_LISTAR_POR_ESTADO = "USP_Pedido_ListarPorEstado";
        const string C_LISTAR_POR_SOLICITANTE = "USP_Pedido_ListarPorSolicitante";

        const string C_LISTAR_POR_APROBACION_RESPONSABLE = "USP_Pedido_ListarAprobacionResponsable";
        const string C_LISTAR_POR_APROBACION_LOGISTICA = "USP_Pedido_ListarAprobacionLogistica";

        const string C_LISTAR_PEDIDOS_POR_COTIZAR = "USP_Pedido_ListarPorCotizar";
        const string C_LISTAR_PEDIDOS_POR_DESPACHAR = "USP_Pedido_ListarDespachoInventario";

        const string C_LISTAR_REPORTE = "USP_Pedido_ListarReporte";
        const string C_LISTAR_REPORTE1 = "USP_Pedido_ListarReporte1";
        
        public List<PedidoDTO> Listar()
        {
            List<PedidoDTO> Lista = new List<PedidoDTO>();
            Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
            DbCommand dbCommand = db.GetStoredProcCommand(C_LISTAR);
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                while (dr.Read())
                {
                    PedidoDTO obj = new PedidoDTO();
                    
                    obj.IdPedido = (int)dr["id_pedido"];
                    
                    obj.IdProyecto = (int)dr["id_proyecto"];
                    
                    obj.IdSede = (int)dr["id_sede"];
                    
                    obj.IdSolicitante = (int)dr["id_solicitante"];
                    
                    obj.IdResponsableProyecto = (int)dr["id_responsable_proyecto"];

                    if (dr["numero_pedido"] != System.DBNull.Value)
                        obj.NumeroPedido = (string)dr["numero_pedido"];

                    if (dr["fecha_pedido"] != System.DBNull.Value)
                        obj.FechaPedido = (DateTime)dr["fecha_pedido"];
                    
                    if (dr["descripcion"] != System.DBNull.Value)
                        obj.Descripcion = (string)dr["descripcion"];
                    
                    if (dr["observaciones"] != System.DBNull.Value)
                        obj.Observaciones = (string)dr["observaciones"];
                    
                    if (dr["estado"] != System.DBNull.Value)
                        obj.Estado = (string)dr["estado"];

                    if (dr["fecha_aprobacion"] != System.DBNull.Value)
                        obj.FechaAprobacion = (DateTime)dr["fecha_aprobacion"];

                    if (dr["estado_control"] != System.DBNull.Value)
                        obj.EstadoControl = (string)dr["estado_control"];

                    if (dr["cancelado"] != System.DBNull.Value)
                        obj.Cancelado = (string)dr["cancelado"];

                    if (dr["fecha_cancelacion"] != System.DBNull.Value)
                        obj.FechaCancelacion = (DateTime)dr["fecha_cancelacion"];

                    if (dr["id_usuario_cancelacion"] != System.DBNull.Value)
                        obj.IdUsuarioCancelacion = (int)dr["id_usuario_cancelacion"];

                    if (dr["codigo_presupuesto"] != System.DBNull.Value)
                        obj.CodigoPresupuesto = (string)dr["codigo_presupuesto"];
                    
                    if (dr["fecha_creacion"] != System.DBNull.Value)
                        obj.FechaCreacion = (DateTime)dr["fecha_creacion"];

                    if (dr["id_usuario_creacion"] != System.DBNull.Value)
                        obj.IdUsuarioCreacion = (int)dr["id_usuario_creacion"];

                    if (dr["fecha_modificacion"] != System.DBNull.Value)
                        obj.FechaModificacion = (DateTime)dr["fecha_modificacion"];

                    if (dr["id_usuario_modificacion"] != System.DBNull.Value)
                        obj.IdUsuarioModificacion = (int)dr["id_usuario_modificacion"];

                    if (dr["nombre_proyecto"] != System.DBNull.Value)
                        obj.NombreProyecto = (string)dr["nombre_proyecto"];

                    if (dr["nombre_sede"] != System.DBNull.Value)
                        obj.NombreSede = (string)dr["nombre_sede"];

                    if (dr["nombre_estado"] != System.DBNull.Value)
                        obj.NombreEstado = (string)dr["nombre_estado"];

                    Lista.Add(obj);
                }
            }
            return Lista;
        }
        
        public List<PedidoDTO> ListarPorSolicitante(int IdSolicitante)
        {
            List<PedidoDTO> Lista = new List<PedidoDTO>();
            Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
            DbCommand dbCommand = db.GetStoredProcCommand(C_LISTAR_POR_SOLICITANTE);
            db.AddInParameter(dbCommand, "@id_solicitante", DbType.Int32, IdSolicitante);

            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                while (dr.Read())
                {
                    PedidoDTO obj = new PedidoDTO();

                    obj.IdPedido = (int)dr["id_pedido"];

                    obj.IdProyecto = (int)dr["id_proyecto"];

                    obj.IdSede = (int)dr["id_sede"];

                    obj.IdSolicitante = (int)dr["id_solicitante"];

                    obj.IdResponsableProyecto = (int)dr["id_responsable_proyecto"];

                    if (dr["cod_moneda"] != System.DBNull.Value)
                        obj.CodMoneda = (string)dr["cod_moneda"];

                    if (dr["numero_pedido"] != System.DBNull.Value)
                        obj.NumeroPedido = (string)dr["numero_pedido"];

                    if (dr["fecha_pedido"] != System.DBNull.Value)
                        obj.FechaPedido = (DateTime)dr["fecha_pedido"];

                    if (dr["descripcion"] != System.DBNull.Value)
                        obj.Descripcion = (string)dr["descripcion"];

                    if (dr["observaciones"] != System.DBNull.Value)
                        obj.Observaciones = (string)dr["observaciones"];

                    if (dr["estado"] != System.DBNull.Value)
                        obj.Estado = (string)dr["estado"];

                    if (dr["fecha_aprobacion"] != System.DBNull.Value)
                        obj.FechaAprobacion = (DateTime)dr["fecha_aprobacion"];

                    if (dr["estado_control"] != System.DBNull.Value)
                        obj.EstadoControl = (string)dr["estado_control"];

                    if (dr["cancelado"] != System.DBNull.Value)
                        obj.Cancelado = (string)dr["cancelado"];

                    if (dr["fecha_cancelacion"] != System.DBNull.Value)
                        obj.FechaCancelacion = (DateTime)dr["fecha_cancelacion"];

                    if (dr["codigo_presupuesto"] != System.DBNull.Value)
                        obj.CodigoPresupuesto = (string)dr["codigo_presupuesto"];

                    if (dr["id_usuario_cancelacion"] != System.DBNull.Value)
                        obj.IdUsuarioCancelacion = (int)dr["id_usuario_cancelacion"];

                    if (dr["fecha_creacion"] != System.DBNull.Value)
                        obj.FechaCreacion = (DateTime)dr["fecha_creacion"];

                    if (dr["id_usuario_creacion"] != System.DBNull.Value)
                        obj.IdUsuarioCreacion = (int)dr["id_usuario_creacion"];

                    if (dr["fecha_modificacion"] != System.DBNull.Value)
                        obj.FechaModificacion = (DateTime)dr["fecha_modificacion"];

                    if (dr["id_usuario_modificacion"] != System.DBNull.Value)
                        obj.IdUsuarioModificacion = (int)dr["id_usuario_modificacion"];

                    if (dr["nombre_proyecto"] != System.DBNull.Value)
                        obj.NombreProyecto = (string)dr["nombre_proyecto"];

                    if (dr["nombre_sede"] != System.DBNull.Value)
                        obj.NombreSede = (string)dr["nombre_sede"];

                    if (dr["nombre_estado"] != System.DBNull.Value)
                        obj.NombreEstado = (string)dr["nombre_estado"];

                    if (dr["nombre_moneda"] != System.DBNull.Value)
                        obj.NombreMoneda = (string)dr["nombre_moneda"];

                    if (dr["nombre_solicitante"] != System.DBNull.Value)
                        obj.NombreSolicitante = (string)dr["nombre_solicitante"];

                    if (dr["nombre_tipo_pedido"] != System.DBNull.Value) obj.NombreTipoPedido = (string)dr["nombre_tipo_pedido"];

                    if (dr["orden_compra"] != System.DBNull.Value) obj.OrdenCompra = (string)dr["orden_compra"];

                    if (dr["nombre_estado_control"] != System.DBNull.Value) obj.NombreEstadoControl = (string)dr["nombre_estado_control"];

                    Lista.Add(obj);
                }
            }
            return Lista;
        }
        
        public List<PedidoDTO> ListarPorAprobacionResponsable(int IdResponsable)
        {
            List<PedidoDTO> Lista = new List<PedidoDTO>();
            Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
            DbCommand dbCommand = db.GetStoredProcCommand(C_LISTAR_POR_APROBACION_RESPONSABLE);
            db.AddInParameter(dbCommand, "@id_responsable", DbType.Int32, IdResponsable);

            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                while (dr.Read())
                {
                    PedidoDTO obj = new PedidoDTO();

                    obj.IdPedido = (int)dr["id_pedido"];

                    obj.IdProyecto = (int)dr["id_proyecto"];

                    obj.IdSede = (int)dr["id_sede"];

                    obj.IdSolicitante = (int)dr["id_solicitante"];

                    obj.IdResponsableProyecto = (int)dr["id_responsable_proyecto"];

                    if (dr["cod_moneda"] != System.DBNull.Value)
                        obj.CodMoneda = (string)dr["cod_moneda"];

                    if (dr["numero_pedido"] != System.DBNull.Value)
                        obj.NumeroPedido = (string)dr["numero_pedido"];

                    if (dr["fecha_pedido"] != System.DBNull.Value)
                        obj.FechaPedido = (DateTime)dr["fecha_pedido"];

                    if (dr["descripcion"] != System.DBNull.Value)
                        obj.Descripcion = (string)dr["descripcion"];

                    if (dr["observaciones"] != System.DBNull.Value)
                        obj.Observaciones = (string)dr["observaciones"];

                    if (dr["estado"] != System.DBNull.Value)
                        obj.Estado = (string)dr["estado"];

                    if (dr["fecha_aprobacion"] != System.DBNull.Value)
                        obj.FechaAprobacion = (DateTime)dr["fecha_aprobacion"];

                    if (dr["estado_control"] != System.DBNull.Value)
                        obj.EstadoControl = (string)dr["estado_control"];

                    if (dr["cancelado"] != System.DBNull.Value)
                        obj.Cancelado = (string)dr["cancelado"];

                    if (dr["fecha_cancelacion"] != System.DBNull.Value)
                        obj.FechaCancelacion = (DateTime)dr["fecha_cancelacion"];

                    if (dr["id_usuario_cancelacion"] != System.DBNull.Value)
                        obj.IdUsuarioCancelacion = (int)dr["id_usuario_cancelacion"];

                    if (dr["codigo_presupuesto"] != System.DBNull.Value)
                        obj.CodigoPresupuesto = (string)dr["codigo_presupuesto"];

                    if (dr["fecha_creacion"] != System.DBNull.Value)
                        obj.FechaCreacion = (DateTime)dr["fecha_creacion"];

                    if (dr["id_usuario_creacion"] != System.DBNull.Value)
                        obj.IdUsuarioCreacion = (int)dr["id_usuario_creacion"];

                    if (dr["fecha_modificacion"] != System.DBNull.Value)
                        obj.FechaModificacion = (DateTime)dr["fecha_modificacion"];

                    if (dr["id_usuario_modificacion"] != System.DBNull.Value)
                        obj.IdUsuarioModificacion = (int)dr["id_usuario_modificacion"];

                    if (dr["nombre_proyecto"] != System.DBNull.Value)
                        obj.NombreProyecto = (string)dr["nombre_proyecto"];

                    if (dr["nombre_sede"] != System.DBNull.Value)
                        obj.NombreSede = (string)dr["nombre_sede"];

                    if (dr["nombre_estado"] != System.DBNull.Value)
                        obj.NombreEstado = (string)dr["nombre_estado"];

                    if (dr["nombre_moneda"] != System.DBNull.Value) obj.NombreMoneda = (string)dr["nombre_moneda"];
                    if (dr["nombre_solicitante"] != System.DBNull.Value) obj.NombreSolicitante = (string)dr["nombre_solicitante"];
                    if (dr["nombre_tipo_pedido"] != System.DBNull.Value) obj.NombreTipoPedido = (string)dr["nombre_tipo_pedido"];

                    if (dr["nombre_estado_control"] != System.DBNull.Value) obj.NombreEstadoControl = (string)dr["nombre_estado_control"];

                    Lista.Add(obj);
                }
            }
            return Lista;
        }

        public List<PedidoDTO> ListarPorAprobacionLogistica()
        {
            List<PedidoDTO> Lista = new List<PedidoDTO>();
            Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
            DbCommand dbCommand = db.GetStoredProcCommand(C_LISTAR_POR_APROBACION_LOGISTICA);

            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                while (dr.Read())
                {
                    PedidoDTO obj = new PedidoDTO();

                    obj.IdPedido = (int)dr["id_pedido"];

                    obj.IdProyecto = (int)dr["id_proyecto"];

                    obj.IdSede = (int)dr["id_sede"];

                    obj.IdSolicitante = (int)dr["id_solicitante"];

                    obj.IdResponsableProyecto = (int)dr["id_responsable_proyecto"];

                    if (dr["numero_pedido"] != System.DBNull.Value)
                        obj.NumeroPedido = (string)dr["numero_pedido"];

                    if (dr["fecha_pedido"] != System.DBNull.Value)
                        obj.FechaPedido = (DateTime)dr["fecha_pedido"];

                    if (dr["descripcion"] != System.DBNull.Value)
                        obj.Descripcion = (string)dr["descripcion"];

                    if (dr["observaciones"] != System.DBNull.Value)
                        obj.Observaciones = (string)dr["observaciones"];

                    if (dr["estado"] != System.DBNull.Value)
                        obj.Estado = (string)dr["estado"];

                    if (dr["fecha_aprobacion"] != System.DBNull.Value)
                        obj.FechaAprobacion = (DateTime)dr["fecha_aprobacion"];

                    if (dr["estado_control"] != System.DBNull.Value)
                        obj.EstadoControl = (string)dr["estado_control"];

                    if (dr["cancelado"] != System.DBNull.Value)
                        obj.Cancelado = (string)dr["cancelado"];

                    if (dr["fecha_cancelacion"] != System.DBNull.Value)
                        obj.FechaCancelacion = (DateTime)dr["fecha_cancelacion"];

                    if (dr["id_usuario_cancelacion"] != System.DBNull.Value)
                        obj.IdUsuarioCancelacion = (int)dr["id_usuario_cancelacion"];

                    if (dr["codigo_presupuesto"] != System.DBNull.Value)
                        obj.CodigoPresupuesto = (string)dr["codigo_presupuesto"];

                    if (dr["fecha_creacion"] != System.DBNull.Value)
                        obj.FechaCreacion = (DateTime)dr["fecha_creacion"];

                    if (dr["id_usuario_creacion"] != System.DBNull.Value)
                        obj.IdUsuarioCreacion = (int)dr["id_usuario_creacion"];

                    if (dr["fecha_modificacion"] != System.DBNull.Value)
                        obj.FechaModificacion = (DateTime)dr["fecha_modificacion"];

                    if (dr["id_usuario_modificacion"] != System.DBNull.Value)
                        obj.IdUsuarioModificacion = (int)dr["id_usuario_modificacion"];

                    if (dr["nombre_proyecto"] != System.DBNull.Value)
                        obj.NombreProyecto = (string)dr["nombre_proyecto"];

                    if (dr["nombre_sede"] != System.DBNull.Value)
                        obj.NombreSede = (string)dr["nombre_sede"];

                    if (dr["nombre_estado"] != System.DBNull.Value)
                        obj.NombreEstado = (string)dr["nombre_estado"];

                    if (dr["cod_moneda"] != System.DBNull.Value) obj.CodMoneda = (string)dr["cod_moneda"];
                    if (dr["nombre_moneda"] != System.DBNull.Value) obj.NombreMoneda = (string)dr["nombre_moneda"];
                    if (dr["nombre_solicitante"] != System.DBNull.Value) obj.NombreSolicitante = (string)dr["nombre_solicitante"];
                    if (dr["nombre_tipo_pedido"] != System.DBNull.Value) obj.NombreTipoPedido = (string)dr["nombre_tipo_pedido"];
                    if (dr["nombre_estado_control"] != System.DBNull.Value) obj.NombreEstadoControl = (string)dr["nombre_estado_control"];

                    Lista.Add(obj);
                }
            }
            return Lista;
        }

        public List<PedidoDTO> ListarPorDespachoInventario()
        {
            List<PedidoDTO> Lista = new List<PedidoDTO>();
            Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
            DbCommand dbCommand = db.GetStoredProcCommand(C_LISTAR_PEDIDOS_POR_DESPACHAR);

            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                while (dr.Read())
                {
                    PedidoDTO obj = new PedidoDTO();

                    obj.IdPedido = (int)dr["id_pedido"];

                    obj.IdProyecto = (int)dr["id_proyecto"];

                    obj.IdSede = (int)dr["id_sede"];

                    obj.IdSolicitante = (int)dr["id_solicitante"];

                    obj.IdResponsableProyecto = (int)dr["id_responsable_proyecto"];

                    if (dr["numero_pedido"] != System.DBNull.Value)
                        obj.NumeroPedido = (string)dr["numero_pedido"];

                    if (dr["fecha_pedido"] != System.DBNull.Value)
                        obj.FechaPedido = (DateTime)dr["fecha_pedido"];

                    if (dr["descripcion"] != System.DBNull.Value)
                        obj.Descripcion = (string)dr["descripcion"];

                    if (dr["observaciones"] != System.DBNull.Value)
                        obj.Observaciones = (string)dr["observaciones"];

                    if (dr["estado"] != System.DBNull.Value)
                        obj.Estado = (string)dr["estado"];

                    if (dr["fecha_aprobacion"] != System.DBNull.Value)
                        obj.FechaAprobacion = (DateTime)dr["fecha_aprobacion"];

                    if (dr["estado_control"] != System.DBNull.Value)
                        obj.EstadoControl = (string)dr["estado_control"];

                    if (dr["cancelado"] != System.DBNull.Value)
                        obj.Cancelado = (string)dr["cancelado"];

                    if (dr["fecha_cancelacion"] != System.DBNull.Value)
                        obj.FechaCancelacion = (DateTime)dr["fecha_cancelacion"];

                    if (dr["id_usuario_cancelacion"] != System.DBNull.Value)
                        obj.IdUsuarioCancelacion = (int)dr["id_usuario_cancelacion"];

                    if (dr["codigo_presupuesto"] != System.DBNull.Value)
                        obj.CodigoPresupuesto = (string)dr["codigo_presupuesto"];

                    if (dr["fecha_creacion"] != System.DBNull.Value)
                        obj.FechaCreacion = (DateTime)dr["fecha_creacion"];

                    if (dr["id_usuario_creacion"] != System.DBNull.Value)
                        obj.IdUsuarioCreacion = (int)dr["id_usuario_creacion"];

                    if (dr["fecha_modificacion"] != System.DBNull.Value)
                        obj.FechaModificacion = (DateTime)dr["fecha_modificacion"];

                    if (dr["id_usuario_modificacion"] != System.DBNull.Value)
                        obj.IdUsuarioModificacion = (int)dr["id_usuario_modificacion"];

                    if (dr["nombre_proyecto"] != System.DBNull.Value)
                        obj.NombreProyecto = (string)dr["nombre_proyecto"];

                    if (dr["nombre_sede"] != System.DBNull.Value)
                        obj.NombreSede = (string)dr["nombre_sede"];

                    if (dr["nombre_estado"] != System.DBNull.Value)
                        obj.NombreEstado = (string)dr["nombre_estado"];

                    if (dr["nombre_tipo_pedido"] != System.DBNull.Value) obj.NombreTipoPedido = (string)dr["nombre_tipo_pedido"];

                    Lista.Add(obj);
                }
            }
            return Lista;
        }

        public List<PedidoDTO> ListarPedidosPorCotizar()
        {
            List<PedidoDTO> Lista = new List<PedidoDTO>();
            Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
            DbCommand dbCommand = db.GetStoredProcCommand(C_LISTAR_PEDIDOS_POR_COTIZAR);

            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                while (dr.Read())
                {
                    PedidoDTO obj = new PedidoDTO();

                    obj.IdPedido = (int)dr["id_pedido"];

                    obj.IdProyecto = (int)dr["id_proyecto"];

                    obj.IdSede = (int)dr["id_sede"];

                    obj.IdSolicitante = (int)dr["id_solicitante"];

                    obj.IdResponsableProyecto = (int)dr["id_responsable_proyecto"];

                    if (dr["cod_moneda"] != System.DBNull.Value)
                        obj.CodMoneda = (string)dr["cod_moneda"];

                    if (dr["numero_pedido"] != System.DBNull.Value)
                        obj.NumeroPedido = (string)dr["numero_pedido"];

                    if (dr["fecha_pedido"] != System.DBNull.Value)
                        obj.FechaPedido = (DateTime)dr["fecha_pedido"];

                    if (dr["descripcion"] != System.DBNull.Value)
                        obj.Descripcion = (string)dr["descripcion"];

                    if (dr["observaciones"] != System.DBNull.Value)
                        obj.Observaciones = (string)dr["observaciones"];

                    if (dr["estado"] != System.DBNull.Value)
                        obj.Estado = (string)dr["estado"];

                    if (dr["fecha_aprobacion"] != System.DBNull.Value)
                        obj.FechaAprobacion = (DateTime)dr["fecha_aprobacion"];

                    if (dr["estado_control"] != System.DBNull.Value)
                        obj.EstadoControl = (string)dr["estado_control"];

                    if (dr["cancelado"] != System.DBNull.Value)
                        obj.Cancelado = (string)dr["cancelado"];

                    if (dr["fecha_cancelacion"] != System.DBNull.Value)
                        obj.FechaCancelacion = (DateTime)dr["fecha_cancelacion"];

                    if (dr["id_usuario_cancelacion"] != System.DBNull.Value)
                        obj.IdUsuarioCancelacion = (int)dr["id_usuario_cancelacion"];

                    if (dr["codigo_presupuesto"] != System.DBNull.Value)
                        obj.CodigoPresupuesto = (string)dr["codigo_presupuesto"];

                    if (dr["fecha_creacion"] != System.DBNull.Value)
                        obj.FechaCreacion = (DateTime)dr["fecha_creacion"];

                    if (dr["id_usuario_creacion"] != System.DBNull.Value)
                        obj.IdUsuarioCreacion = (int)dr["id_usuario_creacion"];

                    if (dr["fecha_modificacion"] != System.DBNull.Value)
                        obj.FechaModificacion = (DateTime)dr["fecha_modificacion"];

                    if (dr["id_usuario_modificacion"] != System.DBNull.Value)
                        obj.IdUsuarioModificacion = (int)dr["id_usuario_modificacion"];

                    if (dr["nombre_proyecto"] != System.DBNull.Value)
                        obj.NombreProyecto = (string)dr["nombre_proyecto"];

                    if (dr["nombre_sede"] != System.DBNull.Value)
                        obj.NombreSede = (string)dr["nombre_sede"];

                    if (dr["nombre_estado"] != System.DBNull.Value)
                        obj.NombreEstado = (string)dr["nombre_estado"];

                    if (dr["nombre_moneda"] != System.DBNull.Value)
                        obj.NombreMoneda = (string)dr["nombre_moneda"];

                    if (dr["nombre_solicitante"] != System.DBNull.Value)
                        obj.NombreSolicitante = (string)dr["nombre_solicitante"];

                    if (dr["nombre_tipo_pedido"] != System.DBNull.Value) obj.NombreTipoPedido = (string)dr["nombre_tipo_pedido"];
                    if (dr["nombre_estado_control"] != System.DBNull.Value) obj.NombreEstadoControl = (string)dr["nombre_estado_control"];

                    Lista.Add(obj);
                }
            }
            return Lista;
        }

        public List<PedidoDTO> ListarReporte(DateTime FechaInicial, DateTime FechaFinal, int IdSede, int IdProyecto)
        {
            List<PedidoDTO> Lista = new List<PedidoDTO>();
            Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
            DbCommand dbCommand = db.GetStoredProcCommand(C_LISTAR_REPORTE);
            db.AddInParameter(dbCommand, "@fecha_inicial", DbType.DateTime, FechaInicial);
            db.AddInParameter(dbCommand, "@fecha_final", DbType.DateTime, FechaFinal);
            db.AddInParameter(dbCommand, "@id_sede", DbType.Int32, IdSede);
            db.AddInParameter(dbCommand, "@id_proyecto", DbType.Int32, IdProyecto);

            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                while (dr.Read())
                {
                    PedidoDTO obj = new PedidoDTO();

                    obj.IdPedido = (int)dr["id_pedido"];

                    obj.IdProyecto = (int)dr["id_proyecto"];

                    obj.IdSede = (int)dr["id_sede"];

                    obj.IdSolicitante = (int)dr["id_solicitante"];

                    obj.IdResponsableProyecto = (int)dr["id_responsable_proyecto"];

                    if (dr["cod_moneda"] != System.DBNull.Value)
                        obj.CodMoneda = (string)dr["cod_moneda"];

                    if (dr["numero_pedido"] != System.DBNull.Value)
                        obj.NumeroPedido = (string)dr["numero_pedido"];

                    if (dr["fecha_pedido"] != System.DBNull.Value)
                        obj.FechaPedido = (DateTime)dr["fecha_pedido"];

                    if (dr["descripcion"] != System.DBNull.Value)
                        obj.Descripcion = (string)dr["descripcion"];

                    if (dr["observaciones"] != System.DBNull.Value)
                        obj.Observaciones = (string)dr["observaciones"];

                    if (dr["estado"] != System.DBNull.Value)
                        obj.Estado = (string)dr["estado"];

                    if (dr["fecha_aprobacion"] != System.DBNull.Value)
                        obj.FechaAprobacion = (DateTime)dr["fecha_aprobacion"];

                    if (dr["estado_control"] != System.DBNull.Value)
                        obj.EstadoControl = (string)dr["estado_control"];

                    if (dr["cancelado"] != System.DBNull.Value)
                        obj.Cancelado = (string)dr["cancelado"];

                    if (dr["fecha_cancelacion"] != System.DBNull.Value)
                        obj.FechaCancelacion = (DateTime)dr["fecha_cancelacion"];

                    if (dr["codigo_presupuesto"] != System.DBNull.Value)
                        obj.CodigoPresupuesto = (string)dr["codigo_presupuesto"];

                    if (dr["id_usuario_cancelacion"] != System.DBNull.Value)
                        obj.IdUsuarioCancelacion = (int)dr["id_usuario_cancelacion"];

                    if (dr["fecha_creacion"] != System.DBNull.Value)
                        obj.FechaCreacion = (DateTime)dr["fecha_creacion"];

                    if (dr["id_usuario_creacion"] != System.DBNull.Value)
                        obj.IdUsuarioCreacion = (int)dr["id_usuario_creacion"];

                    if (dr["fecha_modificacion"] != System.DBNull.Value)
                        obj.FechaModificacion = (DateTime)dr["fecha_modificacion"];

                    if (dr["id_usuario_modificacion"] != System.DBNull.Value)
                        obj.IdUsuarioModificacion = (int)dr["id_usuario_modificacion"];

                    if (dr["nombre_proyecto"] != System.DBNull.Value)
                        obj.NombreProyecto = (string)dr["nombre_proyecto"];

                    if (dr["nombre_sede"] != System.DBNull.Value)
                        obj.NombreSede = (string)dr["nombre_sede"];

                    if (dr["nombre_estado"] != System.DBNull.Value)
                        obj.NombreEstado = (string)dr["nombre_estado"];

                    if (dr["nombre_moneda"] != System.DBNull.Value)
                        obj.NombreMoneda = (string)dr["nombre_moneda"];

                    if (dr["nombre_solicitante"] != System.DBNull.Value)
                        obj.NombreSolicitante = (string)dr["nombre_solicitante"];

                    if (dr["nombre_tipo_pedido"] != System.DBNull.Value) obj.NombreTipoPedido = (string)dr["nombre_tipo_pedido"];

                    if (dr["orden_compra"] != System.DBNull.Value) obj.OrdenCompra = (string)dr["orden_compra"];

                    if (dr["nombre_estado_control"] != System.DBNull.Value) obj.NombreEstadoControl = (string)dr["nombre_estado_control"];

                    Lista.Add(obj);
                }
            }
            return Lista;
        }

        public int Agregar(PedidoDTO obj)
        {
            Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
            DbCommand dbCommand = db.GetStoredProcCommand(C_AGREGAR);
            db.AddInParameter(dbCommand, "@id_proyecto", DbType.Int32, obj.IdProyecto);
            db.AddInParameter(dbCommand, "@id_sede", DbType.Int32, obj.IdSede);
            db.AddInParameter(dbCommand, "@id_solicitante", DbType.Int32, obj.IdSolicitante);
            db.AddInParameter(dbCommand, "@id_responsable_proyecto", DbType.Int32, obj.IdResponsableProyecto);
            db.AddInParameter(dbCommand, "@id_tipo_pedido", DbType.Int32, obj.IdTipoPedido);
            db.AddInParameter(dbCommand, "@cod_moneda", DbType.String, obj.CodMoneda );
            db.AddInParameter(dbCommand, "@numero_pedido", DbType.String, obj.NumeroPedido);

            if (obj.FechaPedido.Year == 1)
                db.AddInParameter(dbCommand, "@fecha_pedido", DbType.DateTime, null);
            else
                db.AddInParameter(dbCommand, "@fecha_pedido", DbType.DateTime, obj.FechaPedido);
            
            db.AddInParameter(dbCommand, "@descripcion", DbType.String, obj.Descripcion);
            db.AddInParameter(dbCommand, "@observaciones", DbType.String, obj.Observaciones);
            db.AddInParameter(dbCommand, "@estado", DbType.String, obj.Estado);
            
            if (obj.FechaAprobacion.Year == 1)
                db.AddInParameter(dbCommand, "@fecha_aprobacion", DbType.DateTime, null);
            else
                db.AddInParameter(dbCommand, "@fecha_aprobacion", DbType.DateTime, obj.FechaAprobacion);

            db.AddInParameter(dbCommand, "@estado_control", DbType.String, obj.EstadoControl);

            db.AddInParameter(dbCommand, "@cancelado", DbType.String, obj.Cancelado);
            
            if (obj.FechaAprobacion.Year == 1)
                db.AddInParameter(dbCommand, "@fecha_cancelacion", DbType.DateTime, null);
            else
                db.AddInParameter(dbCommand, "@fecha_cancelacion", DbType.DateTime, obj.FechaCancelacion);

            db.AddInParameter(dbCommand, "@id_usuario_cancelacion", DbType.Int32, obj.IdUsuarioCancelacion);

            db.AddInParameter(dbCommand, "@codigo_presupuesto", DbType.String, obj.CodigoPresupuesto);

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

        public void Actualizar(PedidoDTO obj)
        {
            Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
            DbCommand dbCommand = db.GetStoredProcCommand(C_ACTUALIZAR);

            db.AddInParameter(dbCommand, "@id_pedido", DbType.Int32, obj.IdPedido );
            db.AddInParameter(dbCommand, "@id_proyecto", DbType.Int32, obj.IdProyecto);
            db.AddInParameter(dbCommand, "@id_sede", DbType.Int32, obj.IdSede);
            db.AddInParameter(dbCommand, "@id_solicitante", DbType.Int32, obj.IdSolicitante);
            db.AddInParameter(dbCommand, "@id_responsable_proyecto", DbType.Int32, obj.IdResponsableProyecto);
            db.AddInParameter(dbCommand, "@id_tipo_pedido", DbType.Int32, obj.IdTipoPedido);
            db.AddInParameter(dbCommand, "@cod_moneda", DbType.String, obj.CodMoneda);
            db.AddInParameter(dbCommand, "@numero_pedido", DbType.String, obj.NumeroPedido);

            if (obj.FechaPedido.Year == 1)
                db.AddInParameter(dbCommand, "@fecha_pedido", DbType.DateTime, null);
            else
                db.AddInParameter(dbCommand, "@fecha_pedido", DbType.DateTime, obj.FechaPedido);

            db.AddInParameter(dbCommand, "@descripcion", DbType.String, obj.Descripcion);
            db.AddInParameter(dbCommand, "@observaciones", DbType.String, obj.Observaciones);
            db.AddInParameter(dbCommand, "@estado", DbType.String, obj.Estado);

            if (obj.FechaAprobacion.Year == 1)
                db.AddInParameter(dbCommand, "@fecha_aprobacion", DbType.DateTime, null);
            else
                db.AddInParameter(dbCommand, "@fecha_aprobacion", DbType.DateTime, obj.FechaAprobacion);

            db.AddInParameter(dbCommand, "@estado_control", DbType.String, obj.EstadoControl);

            db.AddInParameter(dbCommand, "@cancelado", DbType.String, obj.Cancelado);

            if (obj.FechaCancelacion.Year == 1)
                db.AddInParameter(dbCommand, "@fecha_cancelacion", DbType.DateTime, null);
            else
                db.AddInParameter(dbCommand, "@fecha_cancelacion", DbType.DateTime, obj.FechaCancelacion);

            db.AddInParameter(dbCommand, "@id_usuario_cancelacion", DbType.Int32, obj.IdUsuarioCancelacion);

            db.AddInParameter(dbCommand, "@codigo_presupuesto", DbType.String, obj.CodigoPresupuesto);

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

        public void Eliminar(int IdPedido)
        {
            Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
            DbCommand dbCommand = db.GetStoredProcCommand(C_ELIMINAR);
            db.AddInParameter(dbCommand, "@id_pedido", DbType.Int32, IdPedido);
            db.ExecuteNonQuery(dbCommand);
        }

        public PedidoDTO ListarPorClave(int id)
        {
            PedidoDTO obj = null;
            Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
            DbCommand dbCommand = db.GetStoredProcCommand(C_LISTAR_POR_CLAVE);
            db.AddInParameter(dbCommand, "@id_pedido", DbType.Int32, id);

            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                if (dr.Read())
                {

                    obj = new PedidoDTO();
                    obj.IdPedido = (int)dr["id_pedido"];
                    obj.IdProyecto = (int)dr["id_proyecto"];
                    obj.IdSede = (int)dr["id_sede"];
                    obj.IdSolicitante = (int)dr["id_solicitante"];
                    obj.IdResponsableProyecto = (int)dr["id_responsable_proyecto"];
                    obj.IdTipoPedido = (int)dr["id_tipo_pedido"];

                    if (dr["cod_moneda"] != System.DBNull.Value)
                        obj.CodMoneda = (string)dr["cod_moneda"];

                    if (dr["numero_pedido"] != System.DBNull.Value)
                        obj.NumeroPedido = (string)dr["numero_pedido"];

                    if (dr["fecha_pedido"] != System.DBNull.Value)
                        obj.FechaPedido = (DateTime)dr["fecha_pedido"];
                                        
                    if (dr["descripcion"] != System.DBNull.Value)
                        obj.Descripcion = (string)dr["descripcion"];
                    
                    if (dr["observaciones"] != System.DBNull.Value)
                        obj.Observaciones = (string)dr["observaciones"];
                    
                    if (dr["estado"] != System.DBNull.Value)
                        obj.Estado = (string)dr["estado"];

                    if (dr["fecha_aprobacion"] != System.DBNull.Value)
                        obj.FechaAprobacion = (DateTime)dr["fecha_aprobacion"];

                    if (dr["estado_control"] != System.DBNull.Value)
                        obj.EstadoControl = (string)dr["estado_control"];
            
                    if (dr["cancelado"] != System.DBNull.Value)
                        obj.Cancelado = (string)dr["cancelado"];

                    if (dr["fecha_cancelacion"] != System.DBNull.Value)
                        obj.FechaCancelacion = (DateTime)dr["fecha_cancelacion"];

                    obj.IdUsuarioCancelacion = (int)dr["id_usuario_cancelacion"];

                    if (dr["codigo_presupuesto"] != System.DBNull.Value)
                        obj.CodigoPresupuesto = (string)dr["codigo_presupuesto"];

                    if (dr["fecha_creacion"] != System.DBNull.Value)
                        obj.FechaCreacion = (DateTime)dr["fecha_creacion"];
                    
                    obj.IdUsuarioCreacion = (int)dr["id_usuario_creacion"];

                    if (dr["fecha_modificacion"] != System.DBNull.Value)
                        obj.FechaModificacion = (DateTime)dr["fecha_modificacion"];

                    if (dr["id_usuario_modificacion"] != System.DBNull.Value)
                        obj.IdUsuarioModificacion = (int)dr["id_usuario_modificacion"];

                    if (dr["nombre_proyecto"] != System.DBNull.Value)
                        obj.NombreProyecto = (string)dr["nombre_proyecto"];

                    if (dr["nombre_sede"] != System.DBNull.Value)
                        obj.NombreSede = (string)dr["nombre_sede"];

                    if (dr["nombre_estado"] != System.DBNull.Value)
                        obj.NombreEstado = (string)dr["nombre_estado"];

                    if (dr["nombre_moneda"] != System.DBNull.Value)
                        obj.NombreMoneda = (string)dr["nombre_moneda"];

                    if (dr["nombre_solicitante"] != System.DBNull.Value)
                        obj.NombreSolicitante = (string)dr["nombre_solicitante"];

                    if (dr["nombre_tipo_pedido"] != System.DBNull.Value) obj.NombreTipoPedido = (string)dr["nombre_tipo_pedido"];
                    if (dr["nombre_estado_control"] != System.DBNull.Value) obj.NombreEstadoControl = (string)dr["nombre_estado_control"];

                }
            }

            return obj;
        }

        public PedidoDTO ListarPorUsuarioEstado(string Estado)
        {
            PedidoDTO obj = null;
            Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
            DbCommand dbCommand = db.GetStoredProcCommand(C_LISTAR_POR_ESTADO);
            db.AddInParameter(dbCommand, "@estado", DbType.String , Estado );

            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                if (dr.Read())
                {

                    obj = new PedidoDTO();
                    obj.IdPedido = (int)dr["id_pedido"];
                    obj.IdProyecto = (int)dr["id_proyecto"];
                    obj.IdSede = (int)dr["id_sede"];
                    obj.IdSolicitante = (int)dr["id_solicitante"];
                    obj.IdResponsableProyecto = (int)dr["id_responsable_proyecto"];
                    obj.IdTipoPedido  = (int)dr["id_tipo_pedido"];

                    if (dr["cod_moneda"] != System.DBNull.Value)
                        obj.CodMoneda = (string)dr["cod_moneda"];

                    if (dr["numero_pedido"] != System.DBNull.Value)
                        obj.NumeroPedido = (string)dr["numero_pedido"];

                    if (dr["fecha_pedido"] != System.DBNull.Value)
                        obj.FechaPedido = (DateTime)dr["fecha_pedido"];

                    if (dr["descripcion"] != System.DBNull.Value)
                        obj.Descripcion = (string)dr["descripcion"];

                    if (dr["observaciones"] != System.DBNull.Value)
                        obj.Observaciones = (string)dr["observaciones"];

                    if (dr["estado"] != System.DBNull.Value)
                        obj.Estado = (string)dr["estado"];

                    if (dr["fecha_aprobacion"] != System.DBNull.Value)
                        obj.FechaAprobacion = (DateTime)dr["fecha_aprobacion"];

                    if (dr["estado_control"] != System.DBNull.Value)
                        obj.EstadoControl = (string)dr["estado_control"];

                    if (dr["cancelado"] != System.DBNull.Value)
                        obj.Cancelado = (string)dr["cancelado"];

                    if (dr["fecha_cancelacion"] != System.DBNull.Value)
                        obj.FechaCancelacion = (DateTime)dr["fecha_cancelacion"];

                    obj.IdUsuarioCancelacion = (int)dr["id_usuario_cancelacion"];

                    if (dr["codigo_presupuesto"] != System.DBNull.Value)
                        obj.CodigoPresupuesto = (string)dr["codigo_presupuesto"];

                    if (dr["fecha_creacion"] != System.DBNull.Value)
                        obj.FechaCreacion = (DateTime)dr["fecha_creacion"];

                    obj.IdUsuarioCreacion = (int)dr["id_usuario_creacion"];

                    if (dr["fecha_modificacion"] != System.DBNull.Value)
                        obj.FechaModificacion = (DateTime)dr["fecha_modificacion"];

                    if (dr["id_usuario_modificacion"] != System.DBNull.Value)
                        obj.IdUsuarioModificacion = (int)dr["id_usuario_modificacion"];

                }
            }

            return obj;
        }

        public DataTable ListarPorSolicitante1(int IdSolicitante)
        {
            Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
            DbCommand dbCommand = db.GetStoredProcCommand(C_LISTAR_POR_SOLICITANTE);
            db.AddInParameter(dbCommand, "@id_solicitante", DbType.Int32, IdSolicitante);
            DataTable dt = new DataTable();
            dt = db.ExecuteDataSet(dbCommand).Tables[0];
            return dt;
        }
        public DataSet ListarReportePedidos(DateTime FechaInicial, DateTime FechaFinal, int IdSede, int IdProyecto, string Estado)
        {
            Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
            DbCommand dbCommand = db.GetStoredProcCommand(C_LISTAR_REPORTE1);
            db.AddInParameter(dbCommand, "@fecha_inicial", DbType.DateTime, FechaInicial);
            db.AddInParameter(dbCommand, "@fecha_final", DbType.DateTime, FechaFinal);
            db.AddInParameter(dbCommand, "@id_sede", DbType.Int32, IdSede);
            db.AddInParameter(dbCommand, "@id_proyecto", DbType.Int32, IdProyecto);
            db.AddInParameter(dbCommand, "@estado", DbType.String, Estado);
            DataSet ds = new DataSet();
            ds = db.ExecuteDataSet(dbCommand);
            return ds;
        }
        public List<PedidoDTO> ListarReportePorEstado(DateTime FechaInicial, DateTime FechaFinal, int IdSede, int IdProyecto, string Estado)
        {
            List<PedidoDTO> Lista = new List<PedidoDTO>();
            Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
            DbCommand dbCommand = db.GetStoredProcCommand(C_LISTAR_REPORTE1);
            db.AddInParameter(dbCommand, "@fecha_inicial", DbType.DateTime, FechaInicial);
            db.AddInParameter(dbCommand, "@fecha_final", DbType.DateTime, FechaFinal);
            db.AddInParameter(dbCommand, "@id_sede", DbType.Int32, IdSede);
            db.AddInParameter(dbCommand, "@id_proyecto", DbType.Int32, IdProyecto);
            db.AddInParameter(dbCommand, "@estado", DbType.String, Estado);
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                while (dr.Read())
                {
                    PedidoDTO obj = new PedidoDTO();

                    obj.IdPedido = (int)dr["id_pedido"];

                    obj.IdProyecto = (int)dr["id_proyecto"];

                    obj.IdSede = (int)dr["id_sede"];

                    obj.IdSolicitante = (int)dr["id_solicitante"];

                    obj.IdResponsableProyecto = (int)dr["id_responsable_proyecto"];

                    if (dr["cod_moneda"] != System.DBNull.Value)
                        obj.CodMoneda = (string)dr["cod_moneda"];

                    if (dr["numero_pedido"] != System.DBNull.Value)
                        obj.NumeroPedido = (string)dr["numero_pedido"];

                    if (dr["fecha_pedido"] != System.DBNull.Value)
                        obj.FechaPedido = (DateTime)dr["fecha_pedido"];

                    if (dr["descripcion"] != System.DBNull.Value)
                        obj.Descripcion = (string)dr["descripcion"];

                    if (dr["observaciones"] != System.DBNull.Value)
                        obj.Observaciones = (string)dr["observaciones"];

                    if (dr["estado"] != System.DBNull.Value)
                        obj.Estado = (string)dr["estado"];

                    if (dr["fecha_aprobacion"] != System.DBNull.Value)
                        obj.FechaAprobacion = (DateTime)dr["fecha_aprobacion"];

                    if (dr["estado_control"] != System.DBNull.Value)
                        obj.EstadoControl = (string)dr["estado_control"];

                    if (dr["cancelado"] != System.DBNull.Value)
                        obj.Cancelado = (string)dr["cancelado"];

                    if (dr["fecha_cancelacion"] != System.DBNull.Value)
                        obj.FechaCancelacion = (DateTime)dr["fecha_cancelacion"];

                    if (dr["codigo_presupuesto"] != System.DBNull.Value)
                        obj.CodigoPresupuesto = (string)dr["codigo_presupuesto"];

                    if (dr["id_usuario_cancelacion"] != System.DBNull.Value)
                        obj.IdUsuarioCancelacion = (int)dr["id_usuario_cancelacion"];

                    if (dr["fecha_creacion"] != System.DBNull.Value)
                        obj.FechaCreacion = (DateTime)dr["fecha_creacion"];

                    if (dr["id_usuario_creacion"] != System.DBNull.Value)
                        obj.IdUsuarioCreacion = (int)dr["id_usuario_creacion"];

                    if (dr["fecha_modificacion"] != System.DBNull.Value)
                        obj.FechaModificacion = (DateTime)dr["fecha_modificacion"];

                    if (dr["id_usuario_modificacion"] != System.DBNull.Value)
                        obj.IdUsuarioModificacion = (int)dr["id_usuario_modificacion"];

                    if (dr["nombre_proyecto"] != System.DBNull.Value)
                        obj.NombreProyecto = (string)dr["nombre_proyecto"];

                    if (dr["nombre_sede"] != System.DBNull.Value)
                        obj.NombreSede = (string)dr["nombre_sede"];

                    if (dr["nombre_estado"] != System.DBNull.Value)
                        obj.NombreEstado = (string)dr["nombre_estado"];

                    if (dr["nombre_moneda"] != System.DBNull.Value)
                        obj.NombreMoneda = (string)dr["nombre_moneda"];

                    if (dr["nombre_solicitante"] != System.DBNull.Value)
                        obj.NombreSolicitante = (string)dr["nombre_solicitante"];

                    if (dr["nombre_tipo_pedido"] != System.DBNull.Value) obj.NombreTipoPedido = (string)dr["nombre_tipo_pedido"];

                    if (dr["orden_compra"] != System.DBNull.Value) obj.OrdenCompra = (string)dr["orden_compra"];

                    if (dr["nombre_estado_control"] != System.DBNull.Value) obj.NombreEstadoControl = (string)dr["nombre_estado_control"];

                    Lista.Add(obj);
                }
            }
            return Lista;
        }

    }
}
