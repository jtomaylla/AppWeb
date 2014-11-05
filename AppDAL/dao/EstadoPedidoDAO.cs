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
  public class EstadoPedidoDAO
  {

      const string C_LISTAR = "USP_EstadoPedido_Listar";
      const string C_ACTUALIZAR = "USP_EstadoPedido_Actualizar";
      const string C_AGREGAR = "USP_EstadoPedido_Agregar";
      const string C_ELIMINAR = "USP_EstadoPedido_Eliminar";
      const string C_LISTAR_POR_TIPO = "SELECT tipo_estado,estado,nombre_estado " + 
                                       "FROM ESTADO_PEDIDO " +
                                       "WHERE tipo_estado='CONTROL' ORDER BY estado";

      public List<EstadoPedidoDTO> Listar()
      {
          List<EstadoPedidoDTO> Lista = new List<EstadoPedidoDTO>();
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          //DbCommand dbCommand = db.GetStoredProcCommand(C_LISTAR);
          DbCommand dbCommand = db.GetSqlStringCommand(C_LISTAR);
          using (IDataReader dr = db.ExecuteReader(dbCommand)) 
          {
              while (dr.Read())
              {
                  EstadoPedidoDTO obj = new EstadoPedidoDTO();
                  if (dr["tipo_estado"] != System.DBNull.Value)
                      obj.TipoEstado = (string)dr["tipo_estado"];
                  if (dr["nombre_estado"] != System.DBNull.Value)
                      obj.NombreEstado = (string)dr["nombre_estado"];
                  if (dr["estado"] != System.DBNull.Value)
                      obj.Estado = (string)dr["estado"];
                  Lista.Add(obj); 
              }
          }
          return Lista;
      }

      public int Agregar(EstadoPedidoDTO obj)
      {
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_AGREGAR);
          db.AddInParameter(dbCommand, "@nombre_estado", DbType.String, obj.NombreEstado);
          db.AddInParameter(dbCommand, "@estado", DbType.String, obj.Estado);
          int id = Convert.ToInt32 ( db.ExecuteScalar(dbCommand));
          return id;
      }

      public void Actualizar(EstadoPedidoDTO obj)
      {
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_ACTUALIZAR);
          db.AddInParameter(dbCommand, "@tipo_estado", DbType.Int32, obj.TipoEstado);
          db.AddInParameter(dbCommand, "@nombre_estado", DbType.String, obj.NombreEstado);
          db.AddInParameter(dbCommand, "@estado", DbType.String, obj.Estado);
          db.ExecuteNonQuery(dbCommand);
      }

      public void Eliminar(int IdSede)
      {
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_ELIMINAR);
          db.AddInParameter(dbCommand, "@tipo_estado", DbType.Int32, IdSede);
          db.ExecuteNonQuery(dbCommand);
      }

      public List<EstadoPedidoDTO> ListarPorTipo()
      {
          EstadoPedidoDTO obj = null;
          List<EstadoPedidoDTO> Lista = new List<EstadoPedidoDTO>();
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetSqlStringCommand(C_LISTAR_POR_TIPO);
          using (IDataReader dr = db.ExecuteReader(dbCommand))
          {
              while (dr.Read())
              {
 
                    obj = new EstadoPedidoDTO();
                    if (dr["tipo_estado"] != System.DBNull.Value) obj.TipoEstado = (string)dr["tipo_estado"];
                    if (dr["nombre_estado"] != System.DBNull.Value) obj.NombreEstado = (string)dr["nombre_estado"];
                    if (dr["estado"] != System.DBNull.Value) obj.Estado = (string)dr["estado"];
                    Lista.Add(obj);
              }
          }
          return Lista;
      }

  }
}

