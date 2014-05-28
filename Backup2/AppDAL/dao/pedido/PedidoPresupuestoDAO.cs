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
  public class PedidoPresupuestoDAO
  {

      const string C_LISTAR = "USP_PedidoPresupuesto_Listar";
      const string C_ACTUALIZAR = "USP_PedidoPresupuesto_Actualizar";
      const string C_AGREGAR = "USP_PedidoPresupuesto_Agregar";
      const string C_ELIMINAR = "USP_PedidoPresupuesto_Eliminar";

      public List<PedidoPresupuestoDTO> Listar(int IdPedido)
      {
          List<PedidoPresupuestoDTO> Lista = new List<PedidoPresupuestoDTO>();
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_LISTAR);
          db.AddInParameter(dbCommand, "@id_pedido", DbType.Int32, IdPedido);

          using (IDataReader dr = db.ExecuteReader(dbCommand)) 
          {
              while (dr.Read())
              {
                  PedidoPresupuestoDTO obj = new PedidoPresupuestoDTO();
                  if (dr["id_pedido_presupuesto"] != System.DBNull.Value)
                      obj.IdPedidoPresupuesto = (int)dr["id_pedido_presupuesto"];
                  if (dr["id_pedido"] != System.DBNull.Value)
                      obj.IdPedido = (int)dr["id_pedido"];
                  if (dr["codigo_presupuesto"] != System.DBNull.Value)
                      obj.CodigoPresupuesto = (string)dr["codigo_presupuesto"];
                  if (dr["descripcion"] != System.DBNull.Value)
                      obj.Descripcion = (string)dr["descripcion"];

                  Lista.Add(obj);
              }
          }
          return Lista;
      }

      public int Agregar(PedidoPresupuestoDTO obj)
      {
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_AGREGAR);
          db.AddInParameter(dbCommand, "@id_pedido", DbType.Int32, obj.IdPedido);
          db.AddInParameter(dbCommand, "@codigo_presupuesto", DbType.String, obj.CodigoPresupuesto);
          db.AddInParameter(dbCommand, "@descripcion", DbType.String, obj.Descripcion);
          int id = Convert.ToInt32(db.ExecuteScalar(dbCommand));
          return id;
      }

      public void Actualizar(PedidoPresupuestoDTO obj)
      {
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_ACTUALIZAR);
          db.AddInParameter(dbCommand, "@id_pedido_presupuesto", DbType.Int32, obj.IdPedidoPresupuesto);
          db.AddInParameter(dbCommand, "@id_pedido", DbType.Int32, obj.IdPedido);
          db.AddInParameter(dbCommand, "@codigo_presupuesto", DbType.String, obj.CodigoPresupuesto);
          db.AddInParameter(dbCommand, "@descripcion", DbType.String, obj.Descripcion);
          db.ExecuteNonQuery(dbCommand);
      }

      public void Eliminar(int IdPedidoPresupuesto)
      {
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_ELIMINAR);
          db.AddInParameter(dbCommand, "@id_pedido_presupuesto", DbType.Int32, IdPedidoPresupuesto);
          db.ExecuteNonQuery(dbCommand);
      }
  }
}
