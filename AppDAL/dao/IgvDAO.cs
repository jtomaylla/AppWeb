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
  public class IgvDAO
  {

      const string C_LISTAR = "USP_Igv_Listar";
      const string C_ACTUALIZAR = "USP_Igv_Actualizar";
      const string C_AGREGAR = "USP_Igv_Agregar";
      const string C_ELIMINAR = "USP_Igv_Eliminar";
      const string C_LISTAR_POR_CLAVE = "USP_Igv_ListarPorClave";
      const string C_LISTAR_IGV_VIGENTE = "select IGV from dbo.IGV where FECHA_INICIO <= GETDATE() and (FECHA_FIN>= GETDATE() or FECHA_FIN is null)";
      const string C_LISTAR_IGV_VIGENTE_FECHA = "select IGV from dbo.IGV where FECHA_INICIO <= @fecha and (FECHA_FIN>= @fecha or FECHA_FIN is null)";
      
      public List<IgvDTO> Listar()
      {
          List<IgvDTO> Lista = new List<IgvDTO>();
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_LISTAR);
          using (IDataReader dr = db.ExecuteReader(dbCommand)) 
          {
              while (dr.Read())
              {
                  IgvDTO obj = new IgvDTO();
                  if (dr["id_registro"] != System.DBNull.Value)
                      obj.IdRegistro = (int)dr["id_registro"];
                  if (dr["igv"] != System.DBNull.Value)
                      obj.Igv = (Decimal)dr["igv"];
                  if (dr["descripcion"] != System.DBNull.Value)
                      obj.Descripcion = (string)dr["descripcion"];
                  if (dr["fecha_inicio"] != System.DBNull.Value)
                      obj.FechaInicio = (DateTime)dr["fecha_inicio"];
                  if (dr["fecha_fin"] != System.DBNull.Value)
                      obj.FechaFin = (DateTime)dr["fecha_fin"];

                  Lista.Add(obj);
              }
          }
          return Lista;
      }

      public IgvDTO ListarPorClave(int IdRegistro)
      {
          IgvDTO obj = null;
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_LISTAR_POR_CLAVE);
          db.AddInParameter(dbCommand, "@id_registro", DbType.Int32, IdRegistro);

          using (IDataReader dr = db.ExecuteReader(dbCommand))
          {
              if (dr.Read())
              {
                  obj = new IgvDTO();
                  if (dr["id_registro"] != System.DBNull.Value)
                      obj.IdRegistro = (int)dr["id_registro"];
                  if (dr["igv"] != System.DBNull.Value)
                      obj.Igv = (Decimal)dr["igv"];
                  if (dr["descripcion"] != System.DBNull.Value)
                      obj.Descripcion = (string)dr["descripcion"];
                  if (dr["fecha_inicio"] != System.DBNull.Value)
                      obj.FechaInicio = (DateTime)dr["fecha_inicio"];
                  if (dr["fecha_fin"] != System.DBNull.Value)
                      obj.FechaFin = (DateTime)dr["fecha_fin"];


              }
          }
          return obj;
      }


      public int Agregar(IgvDTO obj)
      {
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_AGREGAR);
          db.AddInParameter(dbCommand, "@igv", DbType.Decimal, obj.Igv);
          db.AddInParameter(dbCommand, "@descripcion", DbType.String, obj.Descripcion);

          if (obj.FechaInicio.Year == 1)
              db.AddInParameter(dbCommand, "@fecha_inicio", DbType.DateTime, null);
          else
              db.AddInParameter(dbCommand, "@fecha_inicio", DbType.DateTime, obj.FechaInicio);

          if (obj.FechaFin.Year == 1)
              db.AddInParameter(dbCommand, "@fecha_fin", DbType.DateTime, null);
          else
              db.AddInParameter(dbCommand, "@fecha_fin", DbType.DateTime, obj.FechaFin);
          
          int id = Convert.ToInt32(db.ExecuteScalar(dbCommand));
          
          return id;
      }

      public void Actualizar(IgvDTO obj)
      {
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_ACTUALIZAR);
          db.AddInParameter(dbCommand, "@id_registro", DbType.Int32, obj.IdRegistro);
          db.AddInParameter(dbCommand, "@igv", DbType.Decimal, obj.Igv);
          db.AddInParameter(dbCommand, "@descripcion", DbType.String, obj.Descripcion);

          if (obj.FechaInicio.Year == 1)
              db.AddInParameter(dbCommand, "@fecha_inicio", DbType.DateTime, null);
          else
              db.AddInParameter(dbCommand, "@fecha_inicio", DbType.DateTime, obj.FechaInicio);

          if (obj.FechaFin.Year == 1)
              db.AddInParameter(dbCommand, "@fecha_fin", DbType.DateTime, null);
          else
              db.AddInParameter(dbCommand, "@fecha_fin", DbType.DateTime, obj.FechaFin);
          
          db.ExecuteNonQuery(dbCommand);
      }

      public void Eliminar(int IdRegistro)
      {
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_ELIMINAR);
          db.AddInParameter(dbCommand, "@id_registro", DbType.Int32, IdRegistro);
          db.ExecuteNonQuery(dbCommand);
      }

      public IgvDTO ListarIGVVigente()
      {
          IgvDTO obj = null;
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetSqlStringCommand(C_LISTAR_IGV_VIGENTE);
          using (IDataReader dr = db.ExecuteReader(dbCommand))
          {
              while (dr.Read())
              {
                  obj = new IgvDTO();
                  obj.Igv = (decimal)dr["igv"];

              }
          }

          return obj;
      }

      public IgvDTO ListarIGVVigente(DateTime dtmFecha)
      {
          IgvDTO obj = null;
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetSqlStringCommand(C_LISTAR_IGV_VIGENTE_FECHA);
          string strFecha = dtmFecha.ToShortTimeString();
          db.AddInParameter(dbCommand, "@fecha", DbType.DateTime, dtmFecha);
          using (IDataReader dr = db.ExecuteReader(dbCommand))
          {
              while (dr.Read())
              {
                  obj = new IgvDTO();
                  obj.Igv = (decimal)dr["igv"];

              }
          }

          return obj;
      }
  }
}
