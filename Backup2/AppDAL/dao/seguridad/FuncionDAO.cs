using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;
using pe.com.seg.dal.dto;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace pe.com.seg.dal.dao
{
    public class FuncionDAO
    {

        const string C_BUSCAR_POR_CLAVE = "USP_Funcion_BuscarPorClave";
        const string C_LISTAR = "USP_Funcion_Listar";
        const string C_ACTUALIZAR = "USP_Funcion_Actualizar";
        const string C_AGREGAR = "USP_Funcion_Agregar";
        const string C_ELIMINAR = "USP_Funcion_Eliminar";

        public FuncionDTO ListarPorClave(int id)
        {
            FuncionDTO obj = new FuncionDTO();
            Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
            DbCommand dbCommand = db.GetStoredProcCommand(C_BUSCAR_POR_CLAVE);
            db.AddInParameter(dbCommand, "@id_funcion", DbType.Int32, id);

            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                if (dr.Read())
                {
                    obj.IdFuncion = (int)dr["id_funcion"];

                    if (dr["nombre_funcion"] != System.DBNull.Value)
                        obj.NombreFuncion = (string)dr["nombre_funcion"];

                    if (dr["funcion"] != System.DBNull.Value)
                        obj.Funcion = (string)dr["funcion"];

                    if (dr["estado"] != System.DBNull.Value)
                        obj.Estado = (string)dr["estado"];

                }
            }
            return obj;
        }


        public List<FuncionDTO> Listar()
        {
            List<FuncionDTO> Lista = new List<FuncionDTO>();
            Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
            DbCommand dbCommand = db.GetStoredProcCommand(C_LISTAR);

            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                while (dr.Read())
                {
                    FuncionDTO obj = new FuncionDTO();

                    obj.IdFuncion = (int)dr["id_funcion"];

                    if (dr["nombre_funcion"] != System.DBNull.Value)
                        obj.NombreFuncion = (string)dr["nombre_funcion"];

                    if (dr["funcion"] != System.DBNull.Value)
                        obj.Funcion = (string)dr["funcion"];

                    if (dr["estado"] != System.DBNull.Value)
                        obj.Estado = (string)dr["estado"];

                    Lista.Add(obj);
                }
            }


            return Lista;

        }

        public int Agregar(FuncionDTO obj)
        {
            Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
            DbCommand dbCommand = db.GetStoredProcCommand(C_AGREGAR);
            db.AddInParameter(dbCommand, "@nombre_funcion", DbType.String, obj.NombreFuncion);
            db.AddInParameter(dbCommand, "@funcion", DbType.String, obj.Funcion);
            db.AddInParameter(dbCommand, "@estado", DbType.String, obj.Estado);

            db.ExecuteNonQuery(dbCommand);

            dbCommand = db.GetSqlStringCommand("SELECT MAX(id_funcion) FROM SEG_FUNCION");

            int Id = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return Id;


        }

        public void Actualizar(FuncionDTO obj)
        {
            Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
            DbCommand dbCommand = db.GetStoredProcCommand(C_ACTUALIZAR);
            db.AddInParameter(dbCommand, "@id_funcion", DbType.Int32 , obj.IdFuncion);
            db.AddInParameter(dbCommand, "@nombre_funcion", DbType.String, obj.NombreFuncion);
            db.AddInParameter(dbCommand, "@funcion", DbType.String, obj.Funcion);
            db.AddInParameter(dbCommand, "@estado", DbType.String, obj.Estado);
            db.ExecuteNonQuery(dbCommand);
            
        }

        public void Eliminar(int IdFuncion)
        {
            Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
            DbCommand dbCommand = db.GetStoredProcCommand(C_ELIMINAR);
            db.AddInParameter(dbCommand, "@id_funcion", DbType.Int32, IdFuncion);
            db.ExecuteNonQuery(dbCommand);
        }


        public List<FuncionDTO> ListarNoEnPerfil(int IdPerfil)
        {
            List<FuncionDTO> Lista = new List<FuncionDTO>();
            Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
            DbCommand dbCommand = db.GetStoredProcCommand("USP_Funcion_ListarNoEnPerfil");

            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                while (dr.Read())
                {
                    FuncionDTO obj = new FuncionDTO();

                    obj.IdFuncion = (int)dr["id_funcion"];

                    if (dr["nombre_funcion"] != System.DBNull.Value)
                        obj.NombreFuncion = (string)dr["nombre_funcion"];

                    if (dr["funcion"] != System.DBNull.Value)
                        obj.Funcion = (string)dr["funcion"];

                    if (dr["estado"] != System.DBNull.Value)
                        obj.Estado = (string)dr["estado"];

                    Lista.Add(obj);
                }
            }


            return Lista;

        }


    }

}
