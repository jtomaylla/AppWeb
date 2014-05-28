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
    public class TablaDAO
    {
        const string C_LISTAR_MONEDA = "SELECT cod_moneda, nombre_moneda FROM MONEDA ORDER BY nombre_moneda";
        const string C_LISTAR_UNIDAD_MEDIDA = "SELECT cod_moneda, nombre_moneda FROM MONEDA ORDER BY nombre_moneda";
        const string C_LISTAR_PROYECTO = "SELECT cod_moneda, nombre_moneda FROM MONEDA ORDER BY nombre_moneda";

        const string C_LISTAR_TIPO_USUARIO_PROYECTO = "SELECT VALOR, DESCRIPCION  FROM TABLA_DETALLE WHERE ID_TABLA = 2 ORDER BY ORDEN";
        const string C_LISTAR_TIPO_PERSONA = "SELECT VALOR, DESCRIPCION  FROM TABLA_DETALLE WHERE ID_TABLA = 4 ORDER BY ORDEN";
        const string C_LISTAR_TIPO_PEDIDO = "SELECT ID_TIPO_PEDIDO, NOMBRE_TIPO_PEDIDO FROM TIPO_PEDIDO ORDER BY NOMBRE_TIPO_PEDIDO";

        

        public List<ValorDTO> ListarTipoPedido()
        {
            List<ValorDTO> Lista = new List<ValorDTO>();
            Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
            DbCommand dbCommand = db.GetSqlStringCommand(C_LISTAR_TIPO_PEDIDO);

            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                while (dr.Read())
                {
                    ValorDTO obj = new ValorDTO();

                    obj.Valor = ((int)dr["ID_TIPO_PEDIDO"]).ToString();

                    if (dr["NOMBRE_TIPO_PEDIDO"] != System.DBNull.Value)
                        obj.Descripcion = (string)dr["NOMBRE_TIPO_PEDIDO"];

                    Lista.Add(obj);
                }
            }

            return Lista;

        }



        public List<ValorDTO> ListarMoneda()
        {
            List<ValorDTO> Lista = new List<ValorDTO>();
            Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
            DbCommand dbCommand = db.GetSqlStringCommand(C_LISTAR_MONEDA);

            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                while (dr.Read())
                {
                    ValorDTO obj = new ValorDTO();

                    obj.Valor  = (string)dr["cod_moneda"];

                    if (dr["nombre_moneda"] != System.DBNull.Value)
                        obj.Descripcion  = (string)dr["nombre_moneda"];

                    Lista.Add(obj);
                }
            }
            
            return Lista;

        }

        public List<ValorDTO> ListarTipoUsuarioProyecto()
        {
            List<ValorDTO> Lista = new List<ValorDTO>();
            Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
            DbCommand dbCommand = db.GetSqlStringCommand(C_LISTAR_TIPO_USUARIO_PROYECTO);

            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                while (dr.Read())
                {
                    ValorDTO obj = new ValorDTO();

                    obj.Valor = (string)dr["valor"];

                    if (dr["descripcion"] != System.DBNull.Value)
                        obj.Descripcion = (string)dr["descripcion"];

                    Lista.Add(obj);
                }
            }

            return Lista;

        }

        public List<ValorDTO> ListarTipoPersona()
        {
            List<ValorDTO> Lista = new List<ValorDTO>();
            Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
            DbCommand dbCommand = db.GetSqlStringCommand(C_LISTAR_TIPO_PERSONA);

            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                while (dr.Read())
                {
                    ValorDTO obj = new ValorDTO();

                    obj.Valor = (string)dr["valor"];

                    if (dr["descripcion"] != System.DBNull.Value)
                        obj.Descripcion = (string)dr["descripcion"];

                    Lista.Add(obj);
                }
            }

            return Lista;

        }

    }
}
