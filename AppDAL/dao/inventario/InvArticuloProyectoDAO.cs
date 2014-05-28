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
  public class InvArticuloProyectoDAO
  {

      const string C_LISTAR_POR_PROYECTO = "USP_InvArticuloProyecto_ListarPorProyecto";
      const string C_ACTUALIZAR = "USP_InvArticuloProyecto_Actualizar";
      const string C_AGREGAR = "USP_InvArticuloProyecto_Agregar";
      const string C_ELIMINAR = "USP_InvArticuloProyecto_Eliminar";

      public List<InvArticuloProyectoDTO> Listar(int IdArticulo)
      {
          List<InvArticuloProyectoDTO> Lista = new List<InvArticuloProyectoDTO>();
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_LISTAR_POR_PROYECTO);
          db.AddInParameter(dbCommand, "@id_articulo", DbType.Int32, IdArticulo);

          using (IDataReader dr = db.ExecuteReader(dbCommand)) 
          {
              while (dr.Read())
              {
                  InvArticuloProyectoDTO obj = new InvArticuloProyectoDTO();

                  if (dr["id_articulo"] != System.DBNull.Value)
                      obj.IdArticulo = (int)dr["id_articulo"];

                  if (dr["id_proyecto"] != System.DBNull.Value)
                      obj.IdProyecto = (int)dr["id_proyecto"];

                  if (dr["stock"] != System.DBNull.Value)
                      obj.Stock = (Decimal)dr["stock"];

                  if (dr["nombre_proyecto"] != System.DBNull.Value)
                      obj.NombreProyecto = (string)dr["nombre_proyecto"];

                  Lista.Add(obj);
              }
          }
          return Lista;
      }

      public int Agregar(InvArticuloProyectoDTO obj)
      {
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_AGREGAR);
          db.AddInParameter(dbCommand, "@id_articulo", DbType.Int32, obj.IdArticulo);
          db.AddInParameter(dbCommand, "@id_proyecto", DbType.Int32, obj.IdProyecto);
          db.AddInParameter(dbCommand, "@stock", DbType.Decimal, obj.Stock);
          int id = Convert.ToInt32(db.ExecuteScalar(dbCommand));
          return id;
      }

      public void Actualizar(InvArticuloProyectoDTO obj)
      {
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_ACTUALIZAR);
          db.AddInParameter(dbCommand, "@id_articulo", DbType.Int32, obj.IdArticulo);
          db.AddInParameter(dbCommand, "@id_proyecto", DbType.Int32, obj.IdProyecto);
          db.AddInParameter(dbCommand, "@stock", DbType.Decimal, obj.Stock);
          db.ExecuteNonQuery(dbCommand);
      }

      public void Eliminar(int IdArticulo, int IdProyecto)
      {
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_ELIMINAR);
          db.AddInParameter(dbCommand, "@id_articulo", DbType.Int32, IdArticulo);
          db.AddInParameter(dbCommand, "@id_proyecto", DbType.Int32, IdProyecto);
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
