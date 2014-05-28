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
  public class DespachoDAO
  {

      const string C_LISTAR = "USP_Despacho_Listar";
      const string C_ACTUALIZAR = "USP_Despacho_Actualizar";
      const string C_AGREGAR = "USP_Despacho_Agregar";
      const string C_ELIMINAR = "USP_Despacho_Eliminar";

      public List<DespachoDTO> Listar()
      {
          List<DespachoDTO> Lista = new List<DespachoDTO>();
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_LISTAR);
          using (IDataReader dr = db.ExecuteReader(dbCommand)) 
          {
              while (dr.Read())
              {
                  DespachoDTO obj = new DespachoDTO();
                  if (dr["id_despacho"] != System.DBNull.Value)
                      obj.IdDespacho = (int)dr["id_despacho"];
                  if (dr["tipo_origen"] != System.DBNull.Value)
                      obj.TipoOrigen = (string)dr["tipo_origen"];
                  if (dr["id_origen"] != System.DBNull.Value)
                      obj.IdOrigen = (int)dr["id_origen"];
                  if (dr["fecha_despacho"] != System.DBNull.Value)
                      obj.FechaDespacho = (DateTime)dr["fecha_despacho"];
                  if (dr["observaciones"] != System.DBNull.Value)
                      obj.Observaciones = (string)dr["observaciones"];
                  if (dr["estado"] != System.DBNull.Value)
                      obj.Estado = (string)dr["estado"];
                  if (dr["id_guia_remision"] != System.DBNull.Value)
                      obj.IdGuiaRemision = (int)dr["id_guia_remision"];
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

      public List<DespachoDTO> ListarPendienteGuia()
      {
          List<DespachoDTO> Lista = new List<DespachoDTO>();
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand("USP_Despacho_ListarPendienteGuia");
          using (IDataReader dr = db.ExecuteReader(dbCommand))
          {
              while (dr.Read())
              {
                  DespachoDTO obj = new DespachoDTO();
                  if (dr["id_despacho"] != System.DBNull.Value)
                      obj.IdDespacho = (int)dr["id_despacho"];
                  if (dr["tipo_origen"] != System.DBNull.Value)
                      obj.TipoOrigen = (string)dr["tipo_origen"];
                  if (dr["id_origen"] != System.DBNull.Value)
                      obj.IdOrigen = (int)dr["id_origen"];
                  if (dr["fecha_despacho"] != System.DBNull.Value)
                      obj.FechaDespacho = (DateTime)dr["fecha_despacho"];
                  if (dr["observaciones"] != System.DBNull.Value)
                      obj.Observaciones = (string)dr["observaciones"];
                  if (dr["estado"] != System.DBNull.Value)
                      obj.Estado = (string)dr["estado"];
                  if (dr["id_guia_remision"] != System.DBNull.Value)
                      obj.IdGuiaRemision = (int)dr["id_guia_remision"];
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

      public DespachoDTO ListarPorClave(int IdDespacho)
      {
          DespachoDTO obj = null;
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand("USP_Despacho_ListarPorClave");
          db.AddInParameter(dbCommand, "@id_despacho", DbType.Int32, IdDespacho);

          using (IDataReader dr = db.ExecuteReader(dbCommand))
          {
              while (dr.Read())
              {
                  obj = new DespachoDTO();
                  if (dr["id_despacho"] != System.DBNull.Value)
                      obj.IdDespacho = (int)dr["id_despacho"];
                  if (dr["tipo_origen"] != System.DBNull.Value)
                      obj.TipoOrigen = (string)dr["tipo_origen"];
                  if (dr["id_origen"] != System.DBNull.Value)
                      obj.IdOrigen = (int)dr["id_origen"];
                  if (dr["fecha_despacho"] != System.DBNull.Value)
                      obj.FechaDespacho = (DateTime)dr["fecha_despacho"];
                  if (dr["observaciones"] != System.DBNull.Value)
                      obj.Observaciones = (string)dr["observaciones"];
                  if (dr["estado"] != System.DBNull.Value)
                      obj.Estado = (string)dr["estado"];
                  if (dr["id_guia_remision"] != System.DBNull.Value)
                      obj.IdGuiaRemision = (int)dr["id_guia_remision"];
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
          return obj;
      }

      public int Agregar(DespachoDTO obj)
      {
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_AGREGAR);

          db.AddInParameter(dbCommand, "@tipo_origen", DbType.String, obj.TipoOrigen);
          db.AddInParameter(dbCommand, "@id_origen", DbType.Int32, obj.IdOrigen);
          db.AddInParameter(dbCommand, "@fecha_despacho", DbType.DateTime, obj.FechaDespacho);
          db.AddInParameter(dbCommand, "@observaciones", DbType.String, obj.Observaciones);
          db.AddInParameter(dbCommand, "@estado", DbType.String, obj.Estado);
          db.AddInParameter(dbCommand, "@id_guia_remision", DbType.Int32, obj.IdGuiaRemision);
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

          int id = Convert.ToInt32(db.ExecuteScalar(dbCommand));

          return id;
      }

      public void Actualizar(DespachoDTO obj)
      {
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_ACTUALIZAR);
          db.AddInParameter(dbCommand, "@id_despacho", DbType.Int32, obj.IdDespacho);
          db.AddInParameter(dbCommand, "@tipo_origen", DbType.String, obj.TipoOrigen);
          db.AddInParameter(dbCommand, "@id_origen", DbType.Int32, obj.IdOrigen);
          db.AddInParameter(dbCommand, "@fecha_despacho", DbType.DateTime, GetFechaValida(obj.FechaDespacho));
          db.AddInParameter(dbCommand, "@observaciones", DbType.String, obj.Observaciones);
          db.AddInParameter(dbCommand, "@estado", DbType.String, obj.Estado);
          db.AddInParameter(dbCommand, "@id_guia_remision", DbType.Int32, obj.IdGuiaRemision);
          db.AddInParameter(dbCommand, "@id_usuario_creacion", DbType.Int32, obj.IdUsuarioCreacion);
          db.AddInParameter(dbCommand, "@fecha_creacion", DbType.DateTime, GetFechaValida(obj.FechaCreacion));
          db.AddInParameter(dbCommand, "@id_usuario_modificacion", DbType.Int32, obj.IdUsuarioModificacion);
          db.AddInParameter(dbCommand, "@fecha_modificacion", DbType.DateTime, GetFechaValida(obj.FechaModificacion));
          db.ExecuteNonQuery(dbCommand);
      }

      public void Eliminar(int IdDespacho)
      {
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_ELIMINAR);
          db.AddInParameter(dbCommand, "@id_despacho", DbType.Int32, IdDespacho);
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
