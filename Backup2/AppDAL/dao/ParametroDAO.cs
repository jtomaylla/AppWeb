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
  public class ParametroDAO
  {

      const string C_LISTAR = "USP_Parametro_Listar";
      const string C_LISTAR_POR_CLAVE = "USP_Parametro_ListarPorClave";
      const string C_ACTUALIZAR = "USP_Parametro_Actualizar";
      const string C_AGREGAR = "USP_Parametro_Agregar";
      const string C_ELIMINAR = "USP_Parametro_Eliminar";

      public List<ParametroDTO> Listar()
      {
          List<ParametroDTO> Lista = new List<ParametroDTO>();
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_LISTAR);
          using (IDataReader dr = db.ExecuteReader(dbCommand)) 
          {
              while (dr.Read())
              {
                  ParametroDTO obj = new ParametroDTO();
                  if (dr["id_registro"] != System.DBNull.Value)
                      obj.IdRegistro = (int)dr["id_registro"];
                  if (dr["razon_social"] != System.DBNull.Value)
                      obj.RazonSocial = (string)dr["razon_social"];
                  if (dr["ruc"] != System.DBNull.Value)
                      obj.Ruc = (string)dr["ruc"];
                  if (dr["direccion"] != System.DBNull.Value)
                      obj.Direccion = (string)dr["direccion"];
                  if (dr["telefono1"] != System.DBNull.Value)
                      obj.Telefono1 = (string)dr["telefono1"];
                  if (dr["contacto"] != System.DBNull.Value)
                      obj.Contacto = (string)dr["contacto"];
                  if (dr["telefono_contacto"] != System.DBNull.Value)
                      obj.TelefonoContacto = (string)dr["telefono_contacto"];
                  if (dr["email_contacto"] != System.DBNull.Value)
                      obj.EmailContacto = (string)dr["email_contacto"];
                  if (dr["web_site"] != System.DBNull.Value)
                      obj.WebSite = (string)dr["web_site"];
                  if (dr["logo"] != System.DBNull.Value)
                      obj.Logo = (string)dr["logo"];

              }
          }
          return Lista;
      }

      public ParametroDTO ListarPorClave(int idParametro)
      {
          ParametroDTO obj = null;
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_LISTAR_POR_CLAVE);
          db.AddInParameter(dbCommand, "@id_registro", DbType.Int32, idParametro);
          using (IDataReader dr = db.ExecuteReader(dbCommand))
          {
              while (dr.Read())
              {
                  obj = new ParametroDTO();
                  if (dr["id_registro"] != System.DBNull.Value)
                      obj.IdRegistro = (int)dr["id_registro"];
                  if (dr["razon_social"] != System.DBNull.Value)
                      obj.RazonSocial = (string)dr["razon_social"];
                  else
                      obj.RazonSocial = "";
                  if (dr["ruc"] != System.DBNull.Value)
                      obj.Ruc = (string)dr["ruc"];
                  else
                      obj.Ruc = "";
                  
                  if (dr["direccion"] != System.DBNull.Value)
                      obj.Direccion = (string)dr["direccion"];
                  else
                      obj.Direccion = "";
                  
                  if (dr["telefono1"] != System.DBNull.Value)
                      obj.Telefono1 = (string)dr["telefono1"];
                  else
                      obj.Telefono1 = "";
                  if (dr["contacto"] != System.DBNull.Value)
                      obj.Contacto = (string)dr["contacto"];
                  else
                      obj.Contacto = "";
                  if (dr["telefono_contacto"] != System.DBNull.Value)
                      obj.TelefonoContacto = (string)dr["telefono_contacto"];
                  else
                      obj.TelefonoContacto = "";
                  
                  if (dr["email_contacto"] != System.DBNull.Value)
                      obj.EmailContacto = (string)dr["email_contacto"];
                  else
                      obj.EmailContacto = "";
                  
                  if (dr["web_site"] != System.DBNull.Value)
                      obj.WebSite = (string)dr["web_site"];
                  else
                      obj.WebSite = "";
                  
                  if (dr["logo"] != System.DBNull.Value)
                      obj.Logo = (string)dr["logo"];
                  else
                      obj.Logo = "";

                  if (dr["id_almacen"] != System.DBNull.Value)
                      obj.IdAlmacen = (int)dr["id_almacen"];


              }
          }
          return obj;
      }

      public int Agregar(ParametroDTO obj)
      {
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_AGREGAR);
          db.AddInParameter(dbCommand, "@id_registro", DbType.Int32, obj.IdRegistro);
          db.AddInParameter(dbCommand, "@razon_social", DbType.String, obj.RazonSocial);
          db.AddInParameter(dbCommand, "@ruc", DbType.String, obj.Ruc);
          db.AddInParameter(dbCommand, "@direccion", DbType.String, obj.Direccion);
          db.AddInParameter(dbCommand, "@telefono1", DbType.String, obj.Telefono1);
          db.AddInParameter(dbCommand, "@contacto", DbType.String, obj.Contacto);
          db.AddInParameter(dbCommand, "@telefono_contacto", DbType.String, obj.TelefonoContacto);
          db.AddInParameter(dbCommand, "@email_contacto", DbType.String, obj.EmailContacto);
          db.AddInParameter(dbCommand, "@web_site", DbType.String, obj.WebSite);
          db.AddInParameter(dbCommand, "@logo", DbType.String, obj.Logo);
          int id = db.ExecuteNonQuery(dbCommand);
          return id;
      }

      public void Actualizar(ParametroDTO obj)
      {
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_ACTUALIZAR);
          db.AddInParameter(dbCommand, "@id_registro", DbType.Int32, obj.IdRegistro);
          db.AddInParameter(dbCommand, "@razon_social", DbType.String, obj.RazonSocial);
          db.AddInParameter(dbCommand, "@ruc", DbType.String, obj.Ruc);
          db.AddInParameter(dbCommand, "@direccion", DbType.String, obj.Direccion);
          db.AddInParameter(dbCommand, "@telefono1", DbType.String, obj.Telefono1);
          db.AddInParameter(dbCommand, "@contacto", DbType.String, obj.Contacto);
          db.AddInParameter(dbCommand, "@telefono_contacto", DbType.String, obj.TelefonoContacto);
          db.AddInParameter(dbCommand, "@email_contacto", DbType.String, obj.EmailContacto);
          db.AddInParameter(dbCommand, "@web_site", DbType.String, obj.WebSite);
          db.AddInParameter(dbCommand, "@logo", DbType.String, obj.Logo);
          db.AddInParameter(dbCommand, "@id_almacen", DbType.Int32, obj.IdAlmacen);
          db.ExecuteNonQuery(dbCommand);
      }

      public void Eliminar(int IdRegistro)
      {
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_ELIMINAR);
          db.AddInParameter(dbCommand, "@id_registro", DbType.Int32, IdRegistro);
          db.ExecuteNonQuery(dbCommand);
      }
  }
}
