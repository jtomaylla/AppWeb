/*
* RBTEC
* Creado por: Antonio Anampa
* Fecha: 15/01/2014
*/
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
  public class OrdenCompraAprobadorDAO
  {

      const string C_LISTAR = "USP_OrdenCompraAprobador_Listar";
      const string C_LISTAR_POR_ORDEN_COMPRA = "USP_OrdenCompraAprobador_ListarPorOrdenCompra";
      const string C_ACTUALIZAR = "USP_OrdenCompraAprobador_Actualizar";
      const string C_AGREGAR = "USP_OrdenCompraAprobador_Agregar";
      const string C_ELIMINAR = "USP_OrdenCompraAprobador_Eliminar";

      public List<OrdenCompraAprobadorDTO> Listar()
      {
          List<OrdenCompraAprobadorDTO> Lista = new List<OrdenCompraAprobadorDTO>();
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_LISTAR);
          using (IDataReader dr = db.ExecuteReader(dbCommand)) 
          {
              while (dr.Read())
              {
                  OrdenCompraAprobadorDTO obj = new OrdenCompraAprobadorDTO();

                  if (dr["id_orden_compra"] != System.DBNull.Value)
                      obj.IdOrdenCompra = (int)dr["id_orden_compra"];

                  if (dr["id_usuario_aprobacion"] != System.DBNull.Value)
                      obj.IdUsuarioAprobacion = (int)dr["id_usuario_aprobacion"];

                  if (dr["fecha_aprobacion"] != System.DBNull.Value)
                      obj.FechaAprobacion = (DateTime)dr["fecha_aprobacion"];


                  Lista.Add(obj);
              }
          }
          return Lista;
      }

      public List<OrdenCompraAprobadorDTO> ListarPorOrdenCompra(int IdOrdenCompra)
      {
          List<OrdenCompraAprobadorDTO> Lista = new List<OrdenCompraAprobadorDTO>();
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_LISTAR_POR_ORDEN_COMPRA);
          db.AddInParameter(dbCommand, "@id_orden_compra", DbType.Int32, IdOrdenCompra);

          using (IDataReader dr = db.ExecuteReader(dbCommand))
          {
              while (dr.Read())
              {
                  OrdenCompraAprobadorDTO obj = new OrdenCompraAprobadorDTO();

                  if (dr["id_orden_compra"] != System.DBNull.Value)
                      obj.IdOrdenCompra = (int)dr["id_orden_compra"];

                  if (dr["id_usuario_aprobacion"] != System.DBNull.Value)
                      obj.IdUsuarioAprobacion = (int)dr["id_usuario_aprobacion"];

                  if (dr["fecha_aprobacion"] != System.DBNull.Value)
                      obj.FechaAprobacion = (DateTime)dr["fecha_aprobacion"];
                  
                  Lista.Add(obj);
              }
          }
          return Lista;
      }

      public void Agregar(OrdenCompraAprobadorDTO obj)
      {
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_AGREGAR);
          db.AddInParameter(dbCommand, "@id_orden_compra", DbType.Int32, obj.IdOrdenCompra);
          db.AddInParameter(dbCommand, "@id_usuario_aprobacion", DbType.Int32, obj.IdUsuarioAprobacion);
          db.AddInParameter(dbCommand, "@fecha_aprobacion", DbType.DateTime, GetFechaValida( obj.FechaAprobacion) );
          db.ExecuteNonQuery(dbCommand);
      }

      public void Actualizar(OrdenCompraAprobadorDTO obj)
      {
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_ACTUALIZAR);
          db.AddInParameter(dbCommand, "@id_orden_compra", DbType.Int32, obj.IdOrdenCompra);
          db.AddInParameter(dbCommand, "@id_usuario_aprobacion", DbType.Int32, obj.IdUsuarioAprobacion);
          db.AddInParameter(dbCommand, "@fecha_aprobacion", DbType.DateTime, GetFechaValida(obj.FechaAprobacion) );
          db.ExecuteNonQuery(dbCommand);
      }

      public void Eliminar(int IdOrdenCompra)
      {
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_ELIMINAR);
          db.AddInParameter(dbCommand, "@id_orden_compra", DbType.Int32, IdOrdenCompra);
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
