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
  public class GuiaRemisionDAO
  {

      const string C_LISTAR = "USP_GuiaRemision_Listar";
      const string C_ACTUALIZAR = "USP_GuiaRemision_Actualizar";
      const string C_AGREGAR = "USP_GuiaRemision_Agregar";
      const string C_ELIMINAR = "USP_GuiaRemision_Eliminar";
      const string C_GUIA_REMISION_LISTAR_PENDIENTE_IMPRESION = "USP_GuiaRemision_ListarPendienteImpresion";

      const string C_LISTAR_POR_CLAVE = "USP_GuiaRemision_ListarPorClave";

      public List<GuiaRemisionDTO> Listar()
      {
          List<GuiaRemisionDTO> Lista = new List<GuiaRemisionDTO>();
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_LISTAR);
          using (IDataReader dr = db.ExecuteReader(dbCommand)) 
          {
              while (dr.Read())
              {
                  GuiaRemisionDTO obj = new GuiaRemisionDTO();
                  if (dr["id_guia_remision"] != System.DBNull.Value)
                      obj.IdGuiaRemision = (int)dr["id_guia_remision"];

                  if (dr["id_punto_partida"] != System.DBNull.Value)
                      obj.IdPuntoPartida = (int)dr["id_punto_partida"];
                  
                  if (dr["id_punto_llegada"] != System.DBNull.Value)
                      obj.IdPuntoLlegada = (int)dr["id_punto_llegada"];
                  
                  if (dr["fecha_emision"] != System.DBNull.Value)
                      obj.FechaEmision = (DateTime)dr["fecha_emision"];
                  
                  if (dr["fecha_inicio_traslado"] != System.DBNull.Value)
                      obj.FechaInicioTraslado = (DateTime)dr["fecha_inicio_traslado"];
                  
                  if (dr["razon_social_destinatario"] != System.DBNull.Value)
                      obj.RazonSocialDestinatario = (string)dr["razon_social_destinatario"];
                  
                  if (dr["ruc_destinatario"] != System.DBNull.Value)
                      obj.RucDestinatario = (string)dr["ruc_destinatario"];
                  
                  if (dr["razon_social_transportista"] != System.DBNull.Value)
                      obj.RazonSocialTransportista = (string)dr["razon_social_transportista"];
                  
                  if (dr["ruc_transportista"] != System.DBNull.Value)
                      obj.RucTransportista = (string)dr["ruc_transportista"];
                  
                  if (dr["marca"] != System.DBNull.Value)
                      obj.Marca = (string)dr["marca"];
                  
                  if (dr["placa"] != System.DBNull.Value)
                      obj.Placa = (string)dr["placa"];
                  
                  if (dr["certificado"] != System.DBNull.Value)
                      obj.Certificado = (string)dr["certificado"];
                  
                  if (dr["licencia"] != System.DBNull.Value)
                      obj.Licencia = (string)dr["licencia"];
                  
                  if (dr["numero_comprobante_pago"] != System.DBNull.Value)
                      obj.NumeroComprobantePago = (string)dr["numero_comprobante_pago"];
                  
                  if (dr["serie"] != System.DBNull.Value)
                      obj.Serie = (string)dr["serie"];
                  
                  if (dr["numero"] != System.DBNull.Value)
                      obj.Numero = (string)dr["numero"];
                  
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

      public GuiaRemisionDTO ListarPorClave(int IdGuiaRemision)
      {
          GuiaRemisionDTO obj =  null;
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_LISTAR_POR_CLAVE);
          db.AddInParameter(dbCommand, "@id_guia_remision", DbType.Int32, IdGuiaRemision);

          using (IDataReader dr = db.ExecuteReader(dbCommand))
          {
              while (dr.Read())
              {
                  obj = new GuiaRemisionDTO();

                  if (dr["id_guia_remision"] != System.DBNull.Value)
                      obj.IdGuiaRemision = (int)dr["id_guia_remision"];

                  if (dr["id_punto_partida"] != System.DBNull.Value)
                      obj.IdPuntoPartida = (int)dr["id_punto_partida"];

                  if (dr["id_punto_llegada"] != System.DBNull.Value)
                      obj.IdPuntoLlegada = (int)dr["id_punto_llegada"];

                  if (dr["fecha_emision"] != System.DBNull.Value)
                      obj.FechaEmision = (DateTime)dr["fecha_emision"];

                  if (dr["fecha_inicio_traslado"] != System.DBNull.Value)
                      obj.FechaInicioTraslado = (DateTime)dr["fecha_inicio_traslado"];

                  if (dr["razon_social_destinatario"] != System.DBNull.Value)
                      obj.RazonSocialDestinatario = (string)dr["razon_social_destinatario"];

                  if (dr["ruc_destinatario"] != System.DBNull.Value)
                      obj.RucDestinatario = (string)dr["ruc_destinatario"];

                  if (dr["razon_social_transportista"] != System.DBNull.Value)
                      obj.RazonSocialTransportista = (string)dr["razon_social_transportista"];

                  if (dr["ruc_transportista"] != System.DBNull.Value)
                      obj.RucTransportista = (string)dr["ruc_transportista"];

                  if (dr["marca"] != System.DBNull.Value)
                      obj.Marca = (string)dr["marca"];

                  if (dr["placa"] != System.DBNull.Value)
                      obj.Placa = (string)dr["placa"];

                  if (dr["certificado"] != System.DBNull.Value)
                      obj.Certificado = (string)dr["certificado"];

                  if (dr["licencia"] != System.DBNull.Value)
                      obj.Licencia = (string)dr["licencia"];

                  if (dr["numero_comprobante_pago"] != System.DBNull.Value)
                      obj.NumeroComprobantePago = (string)dr["numero_comprobante_pago"];

                  if (dr["serie"] != System.DBNull.Value)
                      obj.Serie = (string)dr["serie"];

                  if (dr["numero"] != System.DBNull.Value)
                      obj.Numero = (string)dr["numero"];

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

      public int Agregar(GuiaRemisionDTO obj)
      {
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_AGREGAR);

          db.AddInParameter(dbCommand, "@id_punto_partida", DbType.Int32, obj.IdPuntoPartida);
          db.AddInParameter(dbCommand, "@id_punto_llegada", DbType.Int32, obj.IdPuntoLlegada);

          if (obj.FechaEmision.Year == 1)
                db.AddInParameter(dbCommand, "@fecha_emision", DbType.DateTime, null);
          else
                db.AddInParameter(dbCommand, "@fecha_emision", DbType.DateTime, obj.FechaEmision);

          if (obj.FechaInicioTraslado.Year == 1)
                db.AddInParameter(dbCommand, "@fecha_inicio_traslado", DbType.DateTime, null);
          else
              db.AddInParameter(dbCommand, "@fecha_inicio_traslado", DbType.DateTime, obj.FechaInicioTraslado);
          
          db.AddInParameter(dbCommand, "@razon_social_destinatario", DbType.String, obj.RazonSocialDestinatario);
          db.AddInParameter(dbCommand, "@ruc_destinatario", DbType.String, obj.RucDestinatario);
          db.AddInParameter(dbCommand, "@razon_social_transportista", DbType.String, obj.RazonSocialTransportista);
          db.AddInParameter(dbCommand, "@ruc_transportista", DbType.String, obj.RucTransportista);
          db.AddInParameter(dbCommand, "@marca", DbType.String, obj.Marca);
          db.AddInParameter(dbCommand, "@placa", DbType.String, obj.Placa);
          db.AddInParameter(dbCommand, "@certificado", DbType.String, obj.Certificado);
          db.AddInParameter(dbCommand, "@licencia", DbType.String, obj.Licencia);
          db.AddInParameter(dbCommand, "@numero_comprobante_pago", DbType.String, obj.NumeroComprobantePago);
          db.AddInParameter(dbCommand, "@serie", DbType.String, obj.Serie);
          db.AddInParameter(dbCommand, "@numero", DbType.String, obj.Numero);
          db.AddInParameter(dbCommand, "@impreso", DbType.String, obj.Impreso);
          if (obj.FechaImpresion.Year == 1)
              db.AddInParameter(dbCommand, "@fecha_impresion", DbType.DateTime, null);
          else
              db.AddInParameter(dbCommand, "@fecha_impresion", DbType.DateTime, obj.FechaImpresion);

          db.AddInParameter(dbCommand, "@id_usuario_creacion", DbType.Int32, obj.IdUsuarioCreacion);

          db.AddInParameter(dbCommand, "@id_despacho", DbType.Int32, obj.IdDespacho);
          
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

      public void Actualizar(GuiaRemisionDTO obj)
      {
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_ACTUALIZAR);

          db.AddInParameter(dbCommand, "@id_guia_remision", DbType.Int32, obj.IdGuiaRemision);
          db.AddInParameter(dbCommand, "@id_punto_partida", DbType.Int32, obj.IdPuntoPartida);
          db.AddInParameter(dbCommand, "@id_punto_llegada", DbType.Int32, obj.IdPuntoLlegada);

          if (obj.FechaEmision.Year == 1)
              db.AddInParameter(dbCommand, "@fecha_emision", DbType.DateTime, null);
          else
              db.AddInParameter(dbCommand, "@fecha_emision", DbType.DateTime, obj.FechaEmision);

          if (obj.FechaInicioTraslado.Year == 1)
              db.AddInParameter(dbCommand, "@fecha_inicio_traslado", DbType.DateTime, null);
          else
              db.AddInParameter(dbCommand, "@fecha_inicio_traslado", DbType.DateTime, obj.FechaInicioTraslado);

          db.AddInParameter(dbCommand, "@razon_social_destinatario", DbType.String, obj.RazonSocialDestinatario);
          db.AddInParameter(dbCommand, "@ruc_destinatario", DbType.String, obj.RucDestinatario);
          db.AddInParameter(dbCommand, "@razon_social_transportista", DbType.String, obj.RazonSocialTransportista);
          db.AddInParameter(dbCommand, "@ruc_transportista", DbType.String, obj.RucTransportista);
          db.AddInParameter(dbCommand, "@marca", DbType.String, obj.Marca);
          db.AddInParameter(dbCommand, "@placa", DbType.String, obj.Placa);
          db.AddInParameter(dbCommand, "@certificado", DbType.String, obj.Certificado);
          db.AddInParameter(dbCommand, "@licencia", DbType.String, obj.Licencia);
          db.AddInParameter(dbCommand, "@numero_comprobante_pago", DbType.String, obj.NumeroComprobantePago);
          db.AddInParameter(dbCommand, "@serie", DbType.String, obj.Serie);
          db.AddInParameter(dbCommand, "@numero", DbType.String, obj.Numero);
          db.AddInParameter(dbCommand, "@impreso", DbType.String, obj.Impreso);
          
          if (obj.FechaImpresion.Year == 1)
                db.AddInParameter(dbCommand, "@fecha_impresion", DbType.DateTime, null);
          else
              db.AddInParameter(dbCommand, "@fecha_impresion", DbType.DateTime, obj.FechaImpresion);

          db.AddInParameter(dbCommand, "@id_despacho", DbType.Int32, obj.IdDespacho);
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
      
      public void Eliminar(int IdGuiaRemision)
      {
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_ELIMINAR);
          db.AddInParameter(dbCommand, "@id_guia_remision", DbType.Int32, IdGuiaRemision);
          db.ExecuteNonQuery(dbCommand);
      }

      public DataTable ListarGuiaRemisionPendienteImpresion()
      {
          DataSet ds = new DataSet();
          DataTable dt = new DataTable();

          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_GUIA_REMISION_LISTAR_PENDIENTE_IMPRESION);
          ds = db.ExecuteDataSet(dbCommand);

          dt = ds.Tables[0];
          if (dt != null)
              return dt;
          else
              return null;

      }
  }
}
