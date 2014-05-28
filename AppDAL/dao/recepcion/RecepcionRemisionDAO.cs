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
  public class RecepcionRemisionDAO
  {

      const string C_LISTAR = "USP_RecepcionRemision_Listar";
      const string C_ACTUALIZAR = "USP_RecepcionRemision_Actualizar";
      const string C_AGREGAR = "USP_RecepcionRemision_Agregar";
      const string C_ELIMINAR = "USP_RecepcionRemision_Eliminar";

      public List<RecepcionRemisionDTO> Listar()
      {
          List<RecepcionRemisionDTO> Lista = new List<RecepcionRemisionDTO>();
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_LISTAR);
          using (IDataReader dr = db.ExecuteReader(dbCommand)) 
          {
              while (dr.Read())
              {
                  RecepcionRemisionDTO obj = new RecepcionRemisionDTO();
                  if (dr["id_recepcion_remision"] != System.DBNull.Value)
                      obj.IdRecepcionRemision = (int)dr["id_recepcion_remision"];
                  if (dr["numero_serie"] != System.DBNull.Value)
                      obj.NumeroSerie = (string)dr["numero_serie"];
                  if (dr["numero_corretativo_serie"] != System.DBNull.Value)
                      obj.NumeroCorretativoSerie = (int)dr["numero_corretativo_serie"];
                  if (dr["id_punto_partida"] != System.DBNull.Value)
                      obj.IdPuntoPartida = (int)dr["id_punto_partida"];
                  if (dr["id_punto_llegada"] != System.DBNull.Value)
                      obj.IdPuntoLlegada = (int)dr["id_punto_llegada"];
                  if (dr["fecha_emision"] != System.DBNull.Value)
                      obj.FechaEmision = (DateTime)dr["fecha_emision"];
                  if (dr["fecha_inicio_traslado"] != System.DBNull.Value)
                      obj.FechaInicioTraslado = (DateTime)dr["fecha_inicio_traslado"];
                  if (dr["destinatario"] != System.DBNull.Value)
                      obj.Destinatario = (string)dr["destinatario"];
                  if (dr["ruc_destinatario"] != System.DBNull.Value)
                      obj.RucDestinatario = (string)dr["ruc_destinatario"];
                  if (dr["transportista"] != System.DBNull.Value)
                      obj.Transportista = (string)dr["transportista"];
                  if (dr["ruc_transportista"] != System.DBNull.Value)
                      obj.RucTransportista = (string)dr["ruc_transportista"];
                  if (dr["marca_unidad_transporte"] != System.DBNull.Value)
                      obj.MarcaUnidadTransporte = (string)dr["marca_unidad_transporte"];
                  if (dr["numero_placa_trasporte"] != System.DBNull.Value)
                      obj.NumeroPlacaTrasporte = (string)dr["numero_placa_trasporte"];
                  if (dr["numero_licencia_conducir"] != System.DBNull.Value)
                      obj.NumeroLicenciaConducir = (string)dr["numero_licencia_conducir"];
                  if (dr["numero_certificado_inscripcion"] != System.DBNull.Value)
                      obj.NumeroCertificadoInscripcion = (string)dr["numero_certificado_inscripcion"];

                  if (dr["estado"] != System.DBNull.Value)
                      obj.Estado = (string)dr["estado"];

                  if (dr["id_recepcion"] != System.DBNull.Value)
                      obj.IdRecepcion = (int)dr["id_recepcion"];

                  if (dr["usuario_creacion"] != System.DBNull.Value)
                      obj.UsuarioCreacion = (string)dr["usuario_creacion"];

                  if (dr["fecha_creacion"] != System.DBNull.Value)
                      obj.FechaCreacion = (DateTime)dr["fecha_creacion"];

                  if (dr["usuario_modificacion"] != System.DBNull.Value)
                      obj.UsuarioModificacion = (string)dr["usuario_modificacion"];

                  if (dr["fecha_modificacion"] != System.DBNull.Value)
                      obj.FechaModificacion = (DateTime)dr["fecha_modificacion"];

                  Lista.Add(obj);
              }
          }
          return Lista;
      }

      public int Agregar(RecepcionRemisionDTO obj)
      {
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_AGREGAR);
          //db.AddInParameter(dbCommand, "@id_recepcion_remision", DbType.Int32, obj.IdRecepcionRemision);
          db.AddInParameter(dbCommand, "@numero_serie", DbType.String, obj.NumeroSerie);
          db.AddInParameter(dbCommand, "@numero_corretativo_serie", DbType.Int32, obj.NumeroCorretativoSerie);
          db.AddInParameter(dbCommand, "@id_punto_partida", DbType.Int32, obj.IdPuntoPartida);
          db.AddInParameter(dbCommand, "@id_punto_llegada", DbType.Int32, obj.IdPuntoLlegada);
          db.AddInParameter(dbCommand, "@fecha_emision", DbType.DateTime, obj.FechaEmision);
          db.AddInParameter(dbCommand, "@fecha_inicio_traslado", DbType.DateTime, obj.FechaInicioTraslado);
          db.AddInParameter(dbCommand, "@destinatario", DbType.String, obj.Destinatario);
          db.AddInParameter(dbCommand, "@ruc_destinatario", DbType.String, obj.RucDestinatario);
          db.AddInParameter(dbCommand, "@transportista", DbType.String, obj.Transportista);
          db.AddInParameter(dbCommand, "@ruc_transportista", DbType.String, obj.RucTransportista);
          db.AddInParameter(dbCommand, "@marca_unidad_transporte", DbType.String, obj.MarcaUnidadTransporte);
          db.AddInParameter(dbCommand, "@numero_placa_trasporte", DbType.String, obj.NumeroPlacaTrasporte);
          db.AddInParameter(dbCommand, "@numero_licencia_conducir", DbType.String, obj.NumeroLicenciaConducir);
          db.AddInParameter(dbCommand, "@numero_certificado_inscripcion", DbType.String, obj.NumeroCertificadoInscripcion);
          db.AddInParameter(dbCommand, "@estado", DbType.String, obj.Estado);
          db.AddInParameter(dbCommand, "@id_recepcion", DbType.Int32, obj.IdRecepcion);
          db.AddInParameter(dbCommand, "@usuario_creacion", DbType.String, obj.UsuarioCreacion);

          if (obj.FechaCreacion.Year == 1)
            db.AddInParameter(dbCommand, "@fecha_creacion", DbType.DateTime, null);
          else
              db.AddInParameter(dbCommand, "@fecha_creacion", DbType.DateTime, obj.FechaCreacion);

          db.AddInParameter(dbCommand, "@usuario_modificacion", DbType.String, obj.UsuarioModificacion);

          if (obj.FechaModificacion.Year == 1)
              db.AddInParameter(dbCommand, "@fecha_modificacion", DbType.DateTime, null);
          else
              db.AddInParameter(dbCommand, "@fecha_modificacion", DbType.DateTime, obj.FechaModificacion);

          int id = Convert.ToInt32(db.ExecuteScalar(dbCommand));
          return id;
      }

      public void Actualizar(RecepcionRemisionDTO obj)
      {
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_ACTUALIZAR);
          db.AddInParameter(dbCommand, "@id_recepcion_remision", DbType.Int32, obj.IdRecepcionRemision);
          db.AddInParameter(dbCommand, "@numero_serie", DbType.String, obj.NumeroSerie);
          db.AddInParameter(dbCommand, "@numero_corretativo_serie", DbType.Int32, obj.NumeroCorretativoSerie);
          db.AddInParameter(dbCommand, "@id_punto_partida", DbType.Int32, obj.IdPuntoPartida);
          db.AddInParameter(dbCommand, "@id_punto_llegada", DbType.Int32, obj.IdPuntoLlegada);
          db.AddInParameter(dbCommand, "@fecha_emision", DbType.DateTime, obj.FechaEmision);
          db.AddInParameter(dbCommand, "@fecha_inicio_traslado", DbType.DateTime, obj.FechaInicioTraslado);
          db.AddInParameter(dbCommand, "@destinatario", DbType.String, obj.Destinatario);
          db.AddInParameter(dbCommand, "@ruc_destinatario", DbType.String, obj.RucDestinatario);
          db.AddInParameter(dbCommand, "@transportista", DbType.String, obj.Transportista);
          db.AddInParameter(dbCommand, "@ruc_transportista", DbType.String, obj.RucTransportista);
          db.AddInParameter(dbCommand, "@marca_unidad_transporte", DbType.String, obj.MarcaUnidadTransporte);
          db.AddInParameter(dbCommand, "@numero_placa_trasporte", DbType.String, obj.NumeroPlacaTrasporte);
          db.AddInParameter(dbCommand, "@numero_licencia_conducir", DbType.String, obj.NumeroLicenciaConducir);
          db.AddInParameter(dbCommand, "@numero_certificado_inscripcion", DbType.String, obj.NumeroCertificadoInscripcion);
          db.AddInParameter(dbCommand, "@estado", DbType.String, obj.Estado);
          db.AddInParameter(dbCommand, "@id_recepcion", DbType.Int32, obj.IdRecepcion);
          db.AddInParameter(dbCommand, "@usuario_creacion", DbType.String, obj.UsuarioCreacion);
          db.AddInParameter(dbCommand, "@fecha_creacion", DbType.DateTime, obj.FechaCreacion);
          db.AddInParameter(dbCommand, "@usuario_modificacion", DbType.String, obj.UsuarioModificacion);
          db.AddInParameter(dbCommand, "@fecha_modificacion", DbType.DateTime, obj.FechaModificacion);
          db.ExecuteNonQuery(dbCommand);
      }

      public void Eliminar(int IdRecepcionRemision)
      {
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_ELIMINAR);
          db.AddInParameter(dbCommand, "@id_recepcion_remision", DbType.Int32, IdRecepcionRemision);
          db.ExecuteNonQuery(dbCommand);
      }
  }
}
