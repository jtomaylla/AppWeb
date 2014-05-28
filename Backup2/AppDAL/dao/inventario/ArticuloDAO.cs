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
  public class ArticuloDAO
  {

      const string C_LISTAR = "USP_Articulo_Listar";
      const string C_ACTUALIZAR = "USP_Articulo_Actualizar";
      const string C_AGREGAR = "USP_Articulo_Agregar";
      const string C_ELIMINAR = "USP_Articulo_Eliminar";
      const string C_LISTAR_POR_CLAVE = "USP_Articulo_ListarPorClave";
      const string C_LISTAR_BUSQUEDA = "USP_Articulo_Busqueda";
      const string C_LISTAR_BUSQUEDA_POR_PROYECTO = "USP_Articulo_BusquedaPorProyecto";
      const string C_STOCK = "SELECT dbo.FND_ObtenerStockArticulo(@id_articulo, @id_proyecto)";

      public List<ArticuloDTO> Listar()
      {
          List<ArticuloDTO> Lista = new List<ArticuloDTO>();
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_LISTAR);
          using (IDataReader dr = db.ExecuteReader(dbCommand)) 
          {
              while (dr.Read())
              {
                  ArticuloDTO obj = new ArticuloDTO();
                  if (dr["id_articulo"] != System.DBNull.Value)
                      obj.IdArticulo = (int)dr["id_articulo"];
                  if (dr["codigo_articulo"] != System.DBNull.Value)
                      obj.CodigoArticulo = (string)dr["codigo_articulo"];
                  if (dr["id_unidad_medida"] != System.DBNull.Value)
                      obj.IdUnidadMedida = (int)dr["id_unidad_medida"];
                  if (dr["descripcion"] != System.DBNull.Value)
                      obj.Descripcion = (string)dr["descripcion"];
                  if (dr["codigo"] != System.DBNull.Value)
                      obj.Codigo = (string)dr["codigo"];
                  if (dr["id_clase"] != System.DBNull.Value)
                      obj.IdClase = (int)dr["id_clase"];
                  if (dr["id_familia"] != System.DBNull.Value)
                      obj.IdFamilia = (int)dr["id_familia"];
                  if (dr["id_proyecto"] != System.DBNull.Value)
                      obj.IdProyecto = (int)dr["id_proyecto"];
                  if (dr["ultimo_precio_oc"] != System.DBNull.Value)
                      obj.UltimoPrecioOc = (Decimal)dr["ultimo_precio_oc"];
                  if (dr["codigo_original"] != System.DBNull.Value)
                      obj.CodigoOriginal = (string)dr["codigo_original"];
                  if (dr["tiempo_util_meses"] != System.DBNull.Value)
                      obj.TiempoUtilMeses = (int)dr["tiempo_util_meses"];
                  if (dr["modelo"] != System.DBNull.Value)
                      obj.Modelo = (string)dr["modelo"];
                  if (dr["marca"] != System.DBNull.Value)
                      obj.Marca = (string)dr["marca"];
                  if (dr["estado"] != System.DBNull.Value)
                      obj.Estado = (string)dr["estado"];
                  if (dr["fecha_creacion"] != System.DBNull.Value)
                      obj.FechaCreacion = (DateTime)dr["fecha_creacion"];
                  if (dr["id_usuario_creacion"] != System.DBNull.Value)
                      obj.IdUsuarioCreacion = (int)dr["id_usuario_creacion"];
                  if (dr["fecha_modificacion"] != System.DBNull.Value)
                      obj.FechaModificacion = (DateTime)dr["fecha_modificacion"];
                  if (dr["id_usuario_modificacion"] != System.DBNull.Value)
                      obj.IdUsuarioModificacion = (int)dr["id_usuario_modificacion"];

                  if (dr["nombre_unidad_medida"] != System.DBNull.Value)
                      obj.NombreUnidadMedida = (string)dr["nombre_unidad_medida"];

                  if (dr["nombre_proyecto"] != System.DBNull.Value)
                      obj.NombreProyecto = (string)dr["nombre_proyecto"];

                  if (dr["nombre_clase"] != System.DBNull.Value)
                      obj.NombreClase = (string)dr["nombre_clase"];

                  if (dr["observaciones"] != System.DBNull.Value)
                      obj.Observaciones = (string)dr["observaciones"];

				   Lista.Add(obj);

              }
          }
          return Lista;
      }

	  public ArticuloDTO ListarPorClave(int IdArticulo)
      {
          List<ArticuloDTO> Lista = new List<ArticuloDTO>();
          ArticuloDTO obj = null;
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_LISTAR_POR_CLAVE);
          db.AddInParameter(dbCommand, "@id_articulo", DbType.Int32, IdArticulo);

          using (IDataReader dr = db.ExecuteReader(dbCommand)) 
          {
              if (dr.Read())
              {
                  obj = new ArticuloDTO();

                  if (dr["id_articulo"] != System.DBNull.Value)
                      obj.IdArticulo = (int)dr["id_articulo"];
                  if (dr["codigo_articulo"] != System.DBNull.Value)
                      obj.CodigoArticulo = (string)dr["codigo_articulo"];
                  if (dr["id_unidad_medida"] != System.DBNull.Value)
                      obj.IdUnidadMedida = (int)dr["id_unidad_medida"];
                  if (dr["descripcion"] != System.DBNull.Value)
                      obj.Descripcion = (string)dr["descripcion"];
                  if (dr["codigo"] != System.DBNull.Value)
                      obj.Codigo = (string)dr["codigo"];
                  if (dr["id_clase"] != System.DBNull.Value)
                      obj.IdClase = (int)dr["id_clase"];
                  if (dr["id_familia"] != System.DBNull.Value)
                      obj.IdFamilia = (int)dr["id_familia"];
                  if (dr["id_proyecto"] != System.DBNull.Value)
                      obj.IdProyecto = (int)dr["id_proyecto"];
                  if (dr["ultimo_precio_oc"] != System.DBNull.Value)
                      obj.UltimoPrecioOc = (Decimal)dr["ultimo_precio_oc"];
                  if (dr["codigo_original"] != System.DBNull.Value)
                      obj.CodigoOriginal = (string)dr["codigo_original"];
                  if (dr["tiempo_util_meses"] != System.DBNull.Value)
                      obj.TiempoUtilMeses = (int)dr["tiempo_util_meses"];
                  if (dr["modelo"] != System.DBNull.Value)
                      obj.Modelo = (string)dr["modelo"];
                  if (dr["marca"] != System.DBNull.Value)
                      obj.Marca = (string)dr["marca"];
                  if (dr["estado"] != System.DBNull.Value)
                      obj.Estado = (string)dr["estado"];
                  if (dr["fecha_creacion"] != System.DBNull.Value)
                      obj.FechaCreacion = (DateTime)dr["fecha_creacion"];
                  if (dr["id_usuario_creacion"] != System.DBNull.Value)
                      obj.IdUsuarioCreacion = (int)dr["id_usuario_creacion"];
                  if (dr["fecha_modificacion"] != System.DBNull.Value)
                      obj.FechaModificacion = (DateTime)dr["fecha_modificacion"];
                  if (dr["id_usuario_modificacion"] != System.DBNull.Value)
                      obj.IdUsuarioModificacion = (int)dr["id_usuario_modificacion"];

                  if (dr["nombre_unidad_medida"] != System.DBNull.Value)
                      obj.NombreUnidadMedida = (string)dr["nombre_unidad_medida"];

                  if (dr["serie"] != System.DBNull.Value)
                      obj.Serie = (string)dr["serie"];

                  if (dr["lote"] != System.DBNull.Value)
                      obj.Lote = (string)dr["lote"];

                  if (dr["fecha_vencimiento"] != System.DBNull.Value)
                      obj.FechaVencimiento = (DateTime)dr["fecha_vencimiento"];

                  if (dr["observaciones"] != System.DBNull.Value)
                      obj.Observaciones = (string)dr["observaciones"];


                  if (dr["observaciones_almacenamiento"] != System.DBNull.Value)
                      obj.ObservacionesAlmacenamiento = (string)dr["observaciones_almacenamiento"];

              }
          }
          return obj;
      }

      public List<ArticuloDTO> ListarBusquedaPorProyecto(string strDescripcion, int IdProyecto)
      {
          List<ArticuloDTO> Lista = new List<ArticuloDTO>();
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_LISTAR_BUSQUEDA_POR_PROYECTO);
          db.AddInParameter(dbCommand, "@descripcion", DbType.String, strDescripcion);
          db.AddInParameter(dbCommand, "@id_proyecto", DbType.Int32, IdProyecto);

          using (IDataReader dr = db.ExecuteReader(dbCommand))
          {
              while (dr.Read())
              {
                  ArticuloDTO obj = new ArticuloDTO();

                  if (dr["id_articulo"] != System.DBNull.Value)
                      obj.IdArticulo = (int)dr["id_articulo"];
                  if (dr["codigo_articulo"] != System.DBNull.Value)
                      obj.CodigoArticulo = (string)dr["codigo_articulo"];
                  if (dr["id_unidad_medida"] != System.DBNull.Value)
                      obj.IdUnidadMedida = (int)dr["id_unidad_medida"];
                  if (dr["descripcion"] != System.DBNull.Value)
                      obj.Descripcion = (string)dr["descripcion"];
                  if (dr["codigo"] != System.DBNull.Value)
                      obj.Codigo = (string)dr["codigo"];
                  if (dr["id_clase"] != System.DBNull.Value)
                      obj.IdClase = (int)dr["id_clase"];
                  if (dr["id_familia"] != System.DBNull.Value)
                      obj.IdFamilia = (int)dr["id_familia"];
                  if (dr["id_proyecto"] != System.DBNull.Value)
                      obj.IdProyecto = (int)dr["id_proyecto"];
                  if (dr["ultimo_precio_oc"] != System.DBNull.Value)
                      obj.UltimoPrecioOc = (Decimal)dr["ultimo_precio_oc"];
                  if (dr["codigo_original"] != System.DBNull.Value)
                      obj.CodigoOriginal = (string)dr["codigo_original"];
                  if (dr["tiempo_util_meses"] != System.DBNull.Value)
                      obj.TiempoUtilMeses = (int)dr["tiempo_util_meses"];
                  if (dr["modelo"] != System.DBNull.Value)
                      obj.Modelo = (string)dr["modelo"];
                  if (dr["marca"] != System.DBNull.Value)
                      obj.Marca = (string)dr["marca"];
                  if (dr["estado"] != System.DBNull.Value)
                      obj.Estado = (string)dr["estado"];
                  if (dr["fecha_creacion"] != System.DBNull.Value)
                      obj.FechaCreacion = (DateTime)dr["fecha_creacion"];
                  if (dr["id_usuario_creacion"] != System.DBNull.Value)
                      obj.IdUsuarioCreacion = (int)dr["id_usuario_creacion"];
                  if (dr["fecha_modificacion"] != System.DBNull.Value)
                      obj.FechaModificacion = (DateTime)dr["fecha_modificacion"];
                  if (dr["id_usuario_modificacion"] != System.DBNull.Value)
                      obj.IdUsuarioModificacion = (int)dr["id_usuario_modificacion"];

                  if (dr["nombre_unidad_medida"] != System.DBNull.Value)
                      obj.NombreUnidadMedida = (string)dr["nombre_unidad_medida"];


                  Lista.Add(obj);
              }
          }
          return Lista;
      }
      
      public List<ArticuloDTO> ListarBusqueda(string strCodArticulo, string strDescripcion)
      {
          List<ArticuloDTO> Lista = new List<ArticuloDTO>();
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_LISTAR_BUSQUEDA);
          db.AddInParameter(dbCommand, "@descripcion", DbType.String, strDescripcion);
          using (IDataReader dr = db.ExecuteReader(dbCommand))
          {
              while (dr.Read())
              {
                  ArticuloDTO obj = new ArticuloDTO();

                  if (dr["id_articulo"] != System.DBNull.Value)
                      obj.IdArticulo = (int)dr["id_articulo"];
                  if (dr["codigo_articulo"] != System.DBNull.Value)
                      obj.CodigoArticulo = (string)dr["codigo_articulo"];
                  if (dr["id_unidad_medida"] != System.DBNull.Value)
                      obj.IdUnidadMedida = (int)dr["id_unidad_medida"];
                  if (dr["descripcion"] != System.DBNull.Value)
                      obj.Descripcion = (string)dr["descripcion"];
                  if (dr["codigo"] != System.DBNull.Value)
                      obj.Codigo = (string)dr["codigo"];
                  if (dr["id_clase"] != System.DBNull.Value)
                      obj.IdClase = (int)dr["id_clase"];
                  if (dr["id_familia"] != System.DBNull.Value)
                      obj.IdFamilia = (int)dr["id_familia"];
                  if (dr["id_proyecto"] != System.DBNull.Value)
                      obj.IdProyecto = (int)dr["id_proyecto"];
                  if (dr["ultimo_precio_oc"] != System.DBNull.Value)
                      obj.UltimoPrecioOc = (Decimal)dr["ultimo_precio_oc"];
                  if (dr["codigo_original"] != System.DBNull.Value)
                      obj.CodigoOriginal = (string)dr["codigo_original"];
                  if (dr["tiempo_util_meses"] != System.DBNull.Value)
                      obj.TiempoUtilMeses = (int)dr["tiempo_util_meses"];
                  if (dr["modelo"] != System.DBNull.Value)
                      obj.Modelo = (string)dr["modelo"];
                  if (dr["marca"] != System.DBNull.Value)
                      obj.Marca = (string)dr["marca"];
                  if (dr["estado"] != System.DBNull.Value)
                      obj.Estado = (string)dr["estado"];
                  if (dr["fecha_creacion"] != System.DBNull.Value)
                      obj.FechaCreacion = (DateTime)dr["fecha_creacion"];
                  if (dr["id_usuario_creacion"] != System.DBNull.Value)
                      obj.IdUsuarioCreacion = (int)dr["id_usuario_creacion"];
                  if (dr["fecha_modificacion"] != System.DBNull.Value)
                      obj.FechaModificacion = (DateTime)dr["fecha_modificacion"];
                  if (dr["id_usuario_modificacion"] != System.DBNull.Value)
                      obj.IdUsuarioModificacion = (int)dr["id_usuario_modificacion"];

                  if (dr["nombre_unidad_medida"] != System.DBNull.Value)
                      obj.NombreUnidadMedida = (string)dr["nombre_unidad_medida"];

                  
                  Lista.Add(obj);
              }
          }
          return Lista;
      }

      public int Agregar(ArticuloDTO obj)
      {
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_AGREGAR);
          //db.AddInParameter(dbCommand, "@id_articulo", DbType.Int32, obj.IdArticulo);
          db.AddInParameter(dbCommand, "@codigo_articulo", DbType.String, obj.CodigoArticulo);
          db.AddInParameter(dbCommand, "@id_unidad_medida", DbType.Int32, obj.IdUnidadMedida);
          db.AddInParameter(dbCommand, "@descripcion", DbType.String, obj.Descripcion);
          db.AddInParameter(dbCommand, "@codigo", DbType.String, obj.Codigo);
          db.AddInParameter(dbCommand, "@id_clase", DbType.Int32, obj.IdClase);
          db.AddInParameter(dbCommand, "@id_familia", DbType.Int32, obj.IdFamilia);
          db.AddInParameter(dbCommand, "@id_proyecto", DbType.Int32, obj.IdProyecto);
          db.AddInParameter(dbCommand, "@ultimo_precio_oc", DbType.Decimal, obj.UltimoPrecioOc);
          db.AddInParameter(dbCommand, "@codigo_original", DbType.String, obj.CodigoOriginal);
          db.AddInParameter(dbCommand, "@tiempo_util_meses", DbType.Int32, obj.TiempoUtilMeses);
          db.AddInParameter(dbCommand, "@modelo", DbType.String, obj.Modelo);
          db.AddInParameter(dbCommand, "@marca", DbType.String, obj.Marca);
          db.AddInParameter(dbCommand, "@estado", DbType.String, obj.Estado);

          db.AddInParameter(dbCommand, "@serie", DbType.String, obj.Serie);
          db.AddInParameter(dbCommand, "@lote", DbType.String, obj.Lote);

          if (obj.FechaVencimiento.Year == 1)
              db.AddInParameter(dbCommand, "@fecha_vencimiento", DbType.DateTime, null);
          else
              db.AddInParameter(dbCommand, "@fecha_vencimiento", DbType.DateTime, obj.FechaVencimiento);

          db.AddInParameter(dbCommand, "@observaciones", DbType.String, obj.Observaciones);
          db.AddInParameter(dbCommand, "@observaciones_almacenamiento", DbType.String, obj.ObservacionesAlmacenamiento);

          db.AddInParameter(dbCommand, "@id_usuario_creacion", DbType.Int32, obj.IdUsuarioCreacion);

          
          int id = Convert.ToInt32(db.ExecuteScalar(dbCommand));
          return id;
      }

      public void Actualizar(ArticuloDTO obj)
      {
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_ACTUALIZAR);
          db.AddInParameter(dbCommand, "@id_articulo", DbType.Int32, obj.IdArticulo);
          db.AddInParameter(dbCommand, "@codigo_articulo", DbType.String, obj.CodigoArticulo);
          db.AddInParameter(dbCommand, "@id_unidad_medida", DbType.Int32, obj.IdUnidadMedida);
          db.AddInParameter(dbCommand, "@descripcion", DbType.String, obj.Descripcion);
          db.AddInParameter(dbCommand, "@codigo", DbType.String, obj.Codigo);
          db.AddInParameter(dbCommand, "@id_clase", DbType.Int32, obj.IdClase);
          db.AddInParameter(dbCommand, "@id_familia", DbType.Int32, obj.IdFamilia);
          db.AddInParameter(dbCommand, "@id_proyecto", DbType.Int32, obj.IdProyecto);
          db.AddInParameter(dbCommand, "@ultimo_precio_oc", DbType.Decimal, obj.UltimoPrecioOc);
          db.AddInParameter(dbCommand, "@codigo_original", DbType.String, obj.CodigoOriginal);
          db.AddInParameter(dbCommand, "@tiempo_util_meses", DbType.Int32, obj.TiempoUtilMeses);
          db.AddInParameter(dbCommand, "@modelo", DbType.String, obj.Modelo);
          db.AddInParameter(dbCommand, "@marca", DbType.String, obj.Marca);
          db.AddInParameter(dbCommand, "@estado", DbType.String, obj.Estado);

          db.AddInParameter(dbCommand, "@serie", DbType.String, obj.Serie);
          db.AddInParameter(dbCommand, "@lote", DbType.String, obj.Lote);

          if (obj.FechaVencimiento.Year == 1)
              db.AddInParameter(dbCommand, "@fecha_vencimiento", DbType.DateTime, null);
          else
              db.AddInParameter(dbCommand, "@fecha_vencimiento", DbType.DateTime, obj.FechaVencimiento);

          db.AddInParameter(dbCommand, "@observaciones", DbType.String, obj.Observaciones);
          db.AddInParameter(dbCommand, "@observaciones_almacenamiento", DbType.String, obj.ObservacionesAlmacenamiento);

          db.AddInParameter(dbCommand, "@id_usuario_modificacion", DbType.Int32, obj.IdUsuarioModificacion);


          db.ExecuteNonQuery(dbCommand);
      }

      public void Eliminar(int IdArticulo)
      {
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_ELIMINAR);
          db.AddInParameter(dbCommand, "@id_articulo", DbType.Int32, IdArticulo);
          db.ExecuteNonQuery(dbCommand);
      }

      public Decimal Stock(int IdArticulo, int IdProyecto) 
      {
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetSqlStringCommand(C_STOCK);
          db.AddInParameter(dbCommand, "@id_articulo", DbType.Int32, IdArticulo);
          db.AddInParameter(dbCommand, "@id_proyecto", DbType.Int32, IdProyecto);
          Decimal r = Convert.ToDecimal(db.ExecuteScalar(dbCommand));
          return r;
      }  
  
  }
}
