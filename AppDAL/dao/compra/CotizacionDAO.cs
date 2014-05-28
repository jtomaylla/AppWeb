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
  public class CotizacionDAO
  {

      const string C_LISTAR = "USP_Cotizacion_Listar";
      const string C_ACTUALIZAR = "USP_Cotizacion_Actualizar";
      const string C_AGREGAR = "USP_Cotizacion_Agregar";
      const string C_ELIMINAR = "USP_Cotizacion_Eliminar";

      const string C_LISTAR_POR_CLAVE = "USP_Cotizacion_ListarPorClave";
      const string C_GENERAR = "USP_Cotizacion_Generar";
      const string C_LISTAR_EN_PROCESO = "USP_Cotizacion_ListarEnProceso";

      public List<CotizacionDTO> Listar()
      {
          List<CotizacionDTO> Lista = new List<CotizacionDTO>();
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_LISTAR);
          using (IDataReader dr = db.ExecuteReader(dbCommand)) 
          {
              while (dr.Read())
              {
                  CotizacionDTO obj = new CotizacionDTO();
                  if (dr["id_cotizacion"] != System.DBNull.Value)
                      obj.IdCotizacion = (int)dr["id_cotizacion"];
                  if (dr["id_pedido"] != System.DBNull.Value)
                      obj.IdPedido = (int)dr["id_pedido"];
                  if (dr["fecha_cotizacion"] != System.DBNull.Value)
                      obj.FechaCotizacion = (DateTime)dr["fecha_cotizacion"];
                  if (dr["descripcion_cotizacion"] != System.DBNull.Value)
                      obj.DescripcionCotizacion = (string)dr["descripcion_cotizacion"];
                  if (dr["cod_moneda"] != System.DBNull.Value)
                      obj.CodMoneda = (string)dr["cod_moneda"];
                  if (dr["estado"] != System.DBNull.Value)
                      obj.Estado = (string)dr["estado"];
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
          return Lista;
      }

      public List<CotizacionDTO> ListarEnProceso()
      {
          List<CotizacionDTO> Lista = new List<CotizacionDTO>();
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_LISTAR_EN_PROCESO);
          using (IDataReader dr = db.ExecuteReader(dbCommand)) 
          {
              while (dr.Read())
              {
                  CotizacionDTO obj = new CotizacionDTO();
                  if (dr["id_cotizacion"] != System.DBNull.Value)
                      obj.IdCotizacion = (int)dr["id_cotizacion"];
                  if (dr["id_pedido"] != System.DBNull.Value)
                      obj.IdPedido = (int)dr["id_pedido"];
                  if (dr["fecha_cotizacion"] != System.DBNull.Value)
                      obj.FechaCotizacion = (DateTime)dr["fecha_cotizacion"];
                  if (dr["descripcion_cotizacion"] != System.DBNull.Value)
                      obj.DescripcionCotizacion = (string)dr["descripcion_cotizacion"];
                  if (dr["cod_moneda"] != System.DBNull.Value)
                      obj.CodMoneda = (string)dr["cod_moneda"];
                  if (dr["estado"] != System.DBNull.Value)
                      obj.Estado = (string)dr["estado"];
                  if (dr["id_usuario_creacion"] != System.DBNull.Value)
                      obj.IdUsuarioCreacion = (int)dr["id_usuario_creacion"];
                  if (dr["fecha_creacion"] != System.DBNull.Value)
                      obj.FechaCreacion = (DateTime)dr["fecha_creacion"];
                  if (dr["id_usuario_modificacion"] != System.DBNull.Value)
                      obj.IdUsuarioModificacion = (int)dr["id_usuario_modificacion"];
                  if (dr["fecha_modificacion"] != System.DBNull.Value)
                      obj.FechaModificacion = (DateTime)dr["fecha_modificacion"];

                  if (dr["nombre_moneda"] != System.DBNull.Value)
                      obj.NombreMoneda = (string)dr["nombre_moneda"];

                  if (dr["nombre_estado"] != System.DBNull.Value)
                      obj.NombreEstado = (string)dr["nombre_estado"];

                  if (dr["nombre_usuario_solicitante"] != System.DBNull.Value)
                      obj.NombreUsuarioSolicitante = (string)dr["nombre_usuario_solicitante"];

                  if (dr["nombre_proyecto"] != System.DBNull.Value)
                      obj.NombreProyecto = (string)dr["nombre_proyecto"];

                  if (dr["nombre_sede"] != System.DBNull.Value)
                      obj.NombreSede = (string)dr["nombre_sede"];

                  Lista.Add(obj);
              }
          }
          return Lista;
      }

      public CotizacionDTO ListarPorClave(int IdCotizacion)
      {
          CotizacionDTO obj = null;
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_LISTAR_POR_CLAVE);
          db.AddInParameter(dbCommand, "@id_cotizacion", DbType.Int32, IdCotizacion);
          using (IDataReader dr = db.ExecuteReader(dbCommand))
          {
              if (dr.Read())
              {
                  obj = new CotizacionDTO();
                  if (dr["id_cotizacion"] != System.DBNull.Value)
                      obj.IdCotizacion = (int)dr["id_cotizacion"];
                  if (dr["id_pedido"] != System.DBNull.Value)
                      obj.IdPedido = (int)dr["id_pedido"];
                  if (dr["fecha_cotizacion"] != System.DBNull.Value)
                      obj.FechaCotizacion = (DateTime)dr["fecha_cotizacion"];
                  if (dr["descripcion_cotizacion"] != System.DBNull.Value)
                      obj.DescripcionCotizacion = (string)dr["descripcion_cotizacion"];
                  if (dr["cod_moneda"] != System.DBNull.Value)
                      obj.CodMoneda = (string)dr["cod_moneda"];
                  if (dr["estado"] != System.DBNull.Value)
                      obj.Estado = (string)dr["estado"];
                  if (dr["id_usuario_creacion"] != System.DBNull.Value)
                      obj.IdUsuarioCreacion = (int)dr["id_usuario_creacion"];
                  if (dr["fecha_creacion"] != System.DBNull.Value)
                      obj.FechaCreacion = (DateTime)dr["fecha_creacion"];
                  if (dr["id_usuario_modificacion"] != System.DBNull.Value)
                      obj.IdUsuarioModificacion = (int)dr["id_usuario_modificacion"];
                  if (dr["fecha_modificacion"] != System.DBNull.Value)
                      obj.FechaModificacion = (DateTime)dr["fecha_modificacion"];

                  if (dr["nombre_moneda"] != System.DBNull.Value)
                      obj.NombreMoneda = (string)dr["nombre_moneda"];

                  if (dr["nombre_estado"] != System.DBNull.Value)
                      obj.NombreEstado = (string)dr["nombre_estado"];

                  if (dr["nombre_usuario_solicitante"] != System.DBNull.Value)
                      obj.NombreUsuarioSolicitante = (string)dr["nombre_usuario_solicitante"];

              }
          }
          return obj;
      }

      public int Agregar(CotizacionDTO obj)
      {
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_AGREGAR);
          db.AddInParameter(dbCommand, "@id_cotizacion", DbType.Int32, obj.IdCotizacion);
          db.AddInParameter(dbCommand, "@id_pedido", DbType.Int32, obj.IdPedido);
          db.AddInParameter(dbCommand, "@fecha_cotizacion", DbType.DateTime, obj.FechaCotizacion);
          db.AddInParameter(dbCommand, "@descripcion_cotizacion", DbType.String, obj.DescripcionCotizacion);
          db.AddInParameter(dbCommand, "@cod_moneda", DbType.String, obj.CodMoneda);
          db.AddInParameter(dbCommand, "@estado", DbType.String, obj.Estado);
          db.AddInParameter(dbCommand, "@id_usuario_creacion", DbType.Int32, obj.IdUsuarioCreacion);
          db.AddInParameter(dbCommand, "@fecha_creacion", DbType.DateTime, obj.FechaCreacion);
          db.AddInParameter(dbCommand, "@id_usuario_modificacion", DbType.Int32, obj.IdUsuarioModificacion);
          db.AddInParameter(dbCommand, "@fecha_modificacion", DbType.DateTime, obj.FechaModificacion);
          int id = db.ExecuteNonQuery(dbCommand);
          return id;
      }

      public void Actualizar(CotizacionDTO obj)
      {
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_ACTUALIZAR);
          db.AddInParameter(dbCommand, "@id_cotizacion", DbType.Int32, obj.IdCotizacion);
          db.AddInParameter(dbCommand, "@id_pedido", DbType.Int32, obj.IdPedido);
          db.AddInParameter(dbCommand, "@fecha_cotizacion", DbType.DateTime, GetFechaValida(obj.FechaCotizacion));
          db.AddInParameter(dbCommand, "@descripcion_cotizacion", DbType.String, obj.DescripcionCotizacion);
          db.AddInParameter(dbCommand, "@cod_moneda", DbType.String, obj.CodMoneda);
          db.AddInParameter(dbCommand, "@estado", DbType.String, obj.Estado);
          db.AddInParameter(dbCommand, "@id_usuario_creacion", DbType.Int32, obj.IdUsuarioCreacion);
          db.AddInParameter(dbCommand, "@fecha_creacion", DbType.DateTime, GetFechaValida(obj.FechaCreacion));
          db.AddInParameter(dbCommand, "@id_usuario_modificacion", DbType.Int32, obj.IdUsuarioModificacion);
          db.AddInParameter(dbCommand, "@fecha_modificacion", DbType.DateTime, GetFechaValida(obj.FechaModificacion));
          db.ExecuteNonQuery(dbCommand);
      }

      public void Eliminar(int IdCotizacion)
      {
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_ELIMINAR);
          db.AddInParameter(dbCommand, "@id_cotizacion", DbType.Int32, IdCotizacion);
          db.ExecuteNonQuery(dbCommand);
      }

      public int Generar(int IdPedido, int IdUsuarioCreacion)
      {
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_GENERAR);
          db.AddInParameter(dbCommand, "@id_pedido", DbType.Int32, IdPedido);
          db.AddInParameter(dbCommand, "@id_usuario_creacion", DbType.Int32, IdUsuarioCreacion);
          int id = Convert.ToInt32(db.ExecuteScalar(dbCommand));
          return id;
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
