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
  public class OrdenCompraNivelAprobacionDAO
  {

      const string C_LISTAR = "USP_OrdenCompraNivelAprobacion_Listar";
      const string C_ACTUALIZAR = "USP_OrdenCompraNivelAprobacion_Actualizar";
      const string C_AGREGAR = "USP_OrdenCompraNivelAprobacion_Agregar";
      const string C_ELIMINAR = "USP_OrdenCompraNivelAprobacion_Eliminar";

      public List<OrdenCompraNivelAprobacionDTO> Listar()
      {
          List<OrdenCompraNivelAprobacionDTO> Lista = new List<OrdenCompraNivelAprobacionDTO>();
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_LISTAR);
          using (IDataReader dr = db.ExecuteReader(dbCommand)) 
          {
              while (dr.Read())
              {
                  OrdenCompraNivelAprobacionDTO obj = new OrdenCompraNivelAprobacionDTO();

                  if (dr["id_nivel_aprobacion"] != System.DBNull.Value)
                      obj.IdNivelAprobacion = (int)dr["id_nivel_aprobacion"];

                  if (dr["nombre_nivel_aprobacion"] != System.DBNull.Value)
                      obj.NombreNivelAprobacion = (string)dr["nombre_nivel_aprobacion"];

                  if (dr["limite_inferior"] != System.DBNull.Value)
                      obj.LimiteInferior = (Decimal)dr["limite_inferior"];

                  if (dr["limite_superior"] != System.DBNull.Value)
                      obj.LimiteSuperior = (Decimal)dr["limite_superior"];

                  if (dr["id_usuario_aprobacion"] != System.DBNull.Value)
                      obj.IdUsuarioAprobacion = (int)dr["id_usuario_aprobacion"];

                  if (dr["cod_moneda"] != System.DBNull.Value)
                      obj.CodMoneda = (string)dr["cod_moneda"];

                  if (dr["estado"] != System.DBNull.Value)
                      obj.Estado = (string)dr["estado"];

                  Lista.Add(obj);
              }
          }
          return Lista;
      }

      public OrdenCompraNivelAprobacionDTO ListarPorClave(int IdNivelAprobacion)
      {
          OrdenCompraNivelAprobacionDTO obj = null;
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand("USP_OrdenCompraNivelAprobacion_ListarPorClave");
          db.AddInParameter(dbCommand, "@id_nivel_aprobacion", DbType.Int32, IdNivelAprobacion);

          using (IDataReader dr = db.ExecuteReader(dbCommand))
          {
              if (dr.Read())
              {
                  obj = new OrdenCompraNivelAprobacionDTO();

                  if (dr["id_nivel_aprobacion"] != System.DBNull.Value)
                      obj.IdNivelAprobacion = (int)dr["id_nivel_aprobacion"];

                  if (dr["nombre_nivel_aprobacion"] != System.DBNull.Value)
                      obj.NombreNivelAprobacion = (string)dr["nombre_nivel_aprobacion"];

                  if (dr["limite_inferior"] != System.DBNull.Value)
                      obj.LimiteInferior = (Decimal)dr["limite_inferior"];

                  if (dr["limite_superior"] != System.DBNull.Value)
                      obj.LimiteSuperior = (Decimal)dr["limite_superior"];

                  if (dr["id_usuario_aprobacion"] != System.DBNull.Value)
                      obj.IdUsuarioAprobacion = (int)dr["id_usuario_aprobacion"];

                  if (dr["cod_moneda"] != System.DBNull.Value)
                      obj.CodMoneda = (string)dr["cod_moneda"];

                  if (dr["estado"] != System.DBNull.Value)
                      obj.Estado = (string)dr["estado"];
           
              }
          }
          return obj;
      }
      
      public List<OrdenCompraNivelAprobacionDTO> ObtenerAprobadorOrdenCompra(Decimal Importe, string CodMoneda)
      {
          List<OrdenCompraNivelAprobacionDTO> Lista = new List<OrdenCompraNivelAprobacionDTO>();
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand("USP_OrdenCompraNivelAprobacion_ListarAprobador");
          db.AddInParameter(dbCommand, "@importe", DbType.Decimal, Importe);
          db.AddInParameter(dbCommand, "@cod_moneda", DbType.String, CodMoneda);

          using (IDataReader dr = db.ExecuteReader(dbCommand))
          {
              while (dr.Read())
              {
                  OrdenCompraNivelAprobacionDTO obj = new OrdenCompraNivelAprobacionDTO();

                  if (dr["id_nivel_aprobacion"] != System.DBNull.Value)
                      obj.IdNivelAprobacion = (int)dr["id_nivel_aprobacion"];

                  if (dr["nombre_nivel_aprobacion"] != System.DBNull.Value)
                      obj.NombreNivelAprobacion = (string)dr["nombre_nivel_aprobacion"];

                  if (dr["limite_inferior"] != System.DBNull.Value)
                      obj.LimiteInferior = (Decimal)dr["limite_inferior"];

                  if (dr["limite_superior"] != System.DBNull.Value)
                      obj.LimiteSuperior = (Decimal)dr["limite_superior"];

                  if (dr["id_usuario_aprobacion"] != System.DBNull.Value)
                      obj.IdUsuarioAprobacion = (int)dr["id_usuario_aprobacion"];

                  if (dr["cod_moneda"] != System.DBNull.Value)
                      obj.CodMoneda = (string)dr["cod_moneda"];

                  if (dr["estado"] != System.DBNull.Value)
                      obj.Estado = (string)dr["estado"];

                  Lista.Add(obj);

              }
          }
          return Lista;
      }
      
      public int Agregar(OrdenCompraNivelAprobacionDTO obj)
      {
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_AGREGAR);
          db.AddInParameter(dbCommand, "@id_nivel_aprobacion", DbType.Int32, obj.IdNivelAprobacion);
          db.AddInParameter(dbCommand, "@nombre_nivel_aprobacion", DbType.String, obj.NombreNivelAprobacion);
          db.AddInParameter(dbCommand, "@limite_inferior", DbType.Decimal, obj.LimiteInferior);
          db.AddInParameter(dbCommand, "@limite_superior", DbType.Decimal, obj.LimiteSuperior);
          db.AddInParameter(dbCommand, "@id_usuario_aprobacion", DbType.Int32, obj.IdUsuarioAprobacion);
          db.AddInParameter(dbCommand, "@cod_moneda", DbType.String, obj.CodMoneda);
          db.AddInParameter(dbCommand, "@estado", DbType.String, obj.Estado);
          int id = Convert.ToInt32(db.ExecuteScalar(dbCommand));
          return id;
      }

      public void Actualizar(OrdenCompraNivelAprobacionDTO obj)
      {
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_ACTUALIZAR);
          db.AddInParameter(dbCommand, "@id_nivel_aprobacion", DbType.Int32, obj.IdNivelAprobacion);
          db.AddInParameter(dbCommand, "@nombre_nivel_aprobacion", DbType.String, obj.NombreNivelAprobacion);
          db.AddInParameter(dbCommand, "@limite_inferior", DbType.Decimal, obj.LimiteInferior);
          db.AddInParameter(dbCommand, "@limite_superior", DbType.Decimal, obj.LimiteSuperior);
          db.AddInParameter(dbCommand, "@id_usuario_aprobacion", DbType.Int32, obj.IdUsuarioAprobacion);
          db.AddInParameter(dbCommand, "@cod_moneda", DbType.String, obj.CodMoneda);
          db.AddInParameter(dbCommand, "@estado", DbType.String, obj.Estado);
          db.ExecuteNonQuery(dbCommand);
      }

      public void Eliminar(int IdNivelAprobacion)
      {
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_ELIMINAR);
          db.AddInParameter(dbCommand, "@id_nivel_aprobacion", DbType.Int32, IdNivelAprobacion);
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
