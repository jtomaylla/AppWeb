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
  public class FormaPagoDAO
  {

      const string C_LISTAR = "USP_FormaPago_Listar";
      const string C_ACTUALIZAR = "USP_FormaPago_Actualizar";
      const string C_AGREGAR = "USP_FormaPago_Agregar";
      const string C_ELIMINAR = "USP_FormaPago_Eliminar";
      const string C_LISTAR_POR_CLAVE = "USP_FormaPago_ListarPorClave";

      public List<FormaPagoDTO> Listar()
      {
          List<FormaPagoDTO> Lista = new List<FormaPagoDTO>();
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_LISTAR);
          using (IDataReader dr = db.ExecuteReader(dbCommand)) 
          {
              while (dr.Read())
              {
                  FormaPagoDTO obj = new FormaPagoDTO();

                  if (dr["id_forma_pago"] != System.DBNull.Value)
                      obj.IdFormaPago = (int)dr["id_forma_pago"];

                  if (dr["nombre_forma_pago"] != System.DBNull.Value)
                      obj.NombreFormaPago = (string)dr["nombre_forma_pago"];

                  if (dr["dias"] != System.DBNull.Value)
                      obj.Dias = (int)dr["dias"];


                  Lista.Add(obj);
              }
          }
          return Lista;
      }

      public FormaPagoDTO ListarPorClave(int IdFormaPago)
      {
          FormaPagoDTO obj = null;
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_LISTAR_POR_CLAVE);
          db.AddInParameter(dbCommand, "@id_forma_pago", DbType.Int32, IdFormaPago);

          using (IDataReader dr = db.ExecuteReader(dbCommand))
          {
              if (dr.Read())
              {
                  obj = new FormaPagoDTO();
                  if (dr["id_forma_pago"] != System.DBNull.Value) obj.IdFormaPago = (int)dr["id_forma_pago"];
                  if (dr["nombre_forma_pago"] != System.DBNull.Value) obj.NombreFormaPago = (string)dr["nombre_forma_pago"];
                  if (dr["dias"] != System.DBNull.Value) obj.Dias = (int)dr["dias"];
              }
          }
          return obj;
      }

      public int Agregar(FormaPagoDTO obj)
      {
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_AGREGAR);
          db.AddInParameter(dbCommand, "@id_forma_pago", DbType.Int32, obj.IdFormaPago);
          db.AddInParameter(dbCommand, "@nombre_forma_pago", DbType.String, obj.NombreFormaPago);
          db.AddInParameter(dbCommand, "@dias", DbType.Int32, obj.Dias);
          int id = Convert.ToInt32(db.ExecuteScalar(dbCommand));
          return id;
      }

      public void Actualizar(FormaPagoDTO obj)
      {
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_ACTUALIZAR);
          db.AddInParameter(dbCommand, "@id_forma_pago", DbType.Int32, obj.IdFormaPago);
          db.AddInParameter(dbCommand, "@nombre_forma_pago", DbType.String, obj.NombreFormaPago);
          db.AddInParameter(dbCommand, "@dias", DbType.Int32, obj.Dias);
          db.ExecuteNonQuery(dbCommand);
      }

      public void Eliminar(int IdFormaPago)
      {
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_ELIMINAR);
          db.AddInParameter(dbCommand, "@id_forma_pago", DbType.Int32, IdFormaPago);
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
