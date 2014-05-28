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
  public class DespachoLineaDAO
  {

      const string C_LISTAR = "USP_DespachoLinea_Listar";
      const string C_LISTAR_POR_DESPACHO = "USP_DespachoLinea_ListarPorDespacho";
      const string C_ACTUALIZAR = "USP_DespachoLinea_Actualizar";
      const string C_AGREGAR = "USP_DespachoLinea_Agregar";
      const string C_ELIMINAR = "USP_DespachoLinea_Eliminar";

      public List<DespachoLineaDTO> ListarPorDespacho(int IdDespacho)
      {
          List<DespachoLineaDTO> Lista = new List<DespachoLineaDTO>();
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_LISTAR_POR_DESPACHO);
          db.AddInParameter(dbCommand, "@id_despacho", DbType.Int32, IdDespacho);

          using (IDataReader dr = db.ExecuteReader(dbCommand)) 
          {
              while (dr.Read())
              {
                  DespachoLineaDTO obj = new DespachoLineaDTO();
                  if (dr["id_despacho_linea"] != System.DBNull.Value)
                      obj.IdDespachoLinea = (int)dr["id_despacho_linea"];
                  if (dr["id_despacho"] != System.DBNull.Value)
                      obj.IdDespacho = (int)dr["id_despacho"];
                  if (dr["numero_linea"] != System.DBNull.Value)
                      obj.NumeroLinea = (int)dr["numero_linea"];
                  if (dr["id_articulo"] != System.DBNull.Value)
                      obj.IdArticulo = (int)dr["id_articulo"];
                  if (dr["id_origen"] != System.DBNull.Value)
                      obj.IdOrigen = (int)dr["id_origen"];
                  if (dr["id_origen_linea"] != System.DBNull.Value)
                      obj.IdOrigenLinea = (int)dr["id_origen_linea"];
                  if (dr["cantidad_despacho"] != System.DBNull.Value)
                      obj.CantidadDespacho = (Decimal)dr["cantidad_despacho"];
                  if (dr["precio_unitario"] != System.DBNull.Value)
                      obj.PrecioUnitario = (Decimal)dr["precio_unitario"];
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

      public int Agregar(DespachoLineaDTO obj)
      {
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_AGREGAR);
          db.AddInParameter(dbCommand, "@id_despacho_linea", DbType.Int32, obj.IdDespachoLinea);
          db.AddInParameter(dbCommand, "@id_despacho", DbType.Int32, obj.IdDespacho);
          db.AddInParameter(dbCommand, "@numero_linea", DbType.Int32, obj.NumeroLinea);
          db.AddInParameter(dbCommand, "@id_articulo", DbType.Int32, obj.IdArticulo);
          db.AddInParameter(dbCommand, "@id_origen", DbType.Int32, obj.IdOrigen);
          db.AddInParameter(dbCommand, "@id_origen_linea", DbType.Int32, obj.IdOrigenLinea);
          db.AddInParameter(dbCommand, "@cantidad_despacho", DbType.Decimal, obj.CantidadDespacho);
          db.AddInParameter(dbCommand, "@precio_unitario", DbType.Decimal, obj.PrecioUnitario);
          db.AddInParameter(dbCommand, "@id_usuario_creacion", DbType.Int32, obj.IdUsuarioCreacion);
          db.AddInParameter(dbCommand, "@fecha_creacion", DbType.DateTime, obj.FechaCreacion);
          db.AddInParameter(dbCommand, "@id_usuario_modificacion", DbType.Int32, obj.IdUsuarioModificacion);
          db.AddInParameter(dbCommand, "@fecha_modificacion", DbType.DateTime, obj.FechaModificacion);
          int id = Convert.ToInt32(db.ExecuteScalar(dbCommand));
          return id;
      }

      public void Actualizar(DespachoLineaDTO obj)
      {
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_ACTUALIZAR);
          db.AddInParameter(dbCommand, "@id_despacho_linea", DbType.Int32, obj.IdDespachoLinea);
          db.AddInParameter(dbCommand, "@id_despacho", DbType.Int32, obj.IdDespacho);
          db.AddInParameter(dbCommand, "@numero_linea", DbType.Int32, obj.NumeroLinea);
          db.AddInParameter(dbCommand, "@id_articulo", DbType.Int32, obj.IdArticulo);
          db.AddInParameter(dbCommand, "@id_origen", DbType.Int32, obj.IdOrigen);
          db.AddInParameter(dbCommand, "@id_origen_linea", DbType.Int32, obj.IdOrigenLinea);
          db.AddInParameter(dbCommand, "@cantidad_despacho", DbType.Decimal, obj.CantidadDespacho);
          db.AddInParameter(dbCommand, "@precio_unitario", DbType.Decimal, obj.PrecioUnitario);
          db.AddInParameter(dbCommand, "@id_usuario_creacion", DbType.Int32, obj.IdUsuarioCreacion);
          db.AddInParameter(dbCommand, "@fecha_creacion", DbType.DateTime, obj.FechaCreacion);
          db.AddInParameter(dbCommand, "@id_usuario_modificacion", DbType.Int32, obj.IdUsuarioModificacion);
          db.AddInParameter(dbCommand, "@fecha_modificacion", DbType.DateTime, obj.FechaModificacion);
          db.ExecuteNonQuery(dbCommand);
      }

      public void Eliminar(int IdDespachoLinea)
      {
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_ELIMINAR);
          db.AddInParameter(dbCommand, "@id_despacho_linea", DbType.Int32, IdDespachoLinea);
          db.ExecuteNonQuery(dbCommand);
      }
  }
}
