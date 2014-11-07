using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pe.com.rbtec.web
{
    public class AppConstantes
    {
        static public int ID_PARAMETRO = 1;

        static public string TXT_BACKCOLOR_INACTIVO = "#E9E9E9";

        static public int TIPO_PEDIDO_COMPRA = 1;
        static public int TIPO_PEDIDO_INTERNO = 2;
        static public int TIPO_PEDIDO_SERVICIO = 3;

        static public int TIPO_ORDEN_COMPRA_ARTICULO = 1;
        static public int TIPO_ORDEN_COMPRA_SERVICIO = 2;

        static public string MONEDA_SOL = "SOL";
        static public string MONEDA_USD = "USD";
        static public string MONEDA_EUR = "EUR";

        //Mesajes
        static public string MSG_ELIMINAR_REGISTRO = "Requiere Ud. Eliminar el Registro?";

        //Estado del Pedido
        /*static public string ESTADO_PEDIDO_BORRADOR = "0";
        static public string ESTADO_PEDIDO_APROBACION_RESPONSABLE = "1";
        static public string ESTADO_PEDIDO_APROBACION_LOGISTICA = "2";
        static public string ESTADO_PEDIDO_APROBADO = "3";
        static public string ESTADO_PEDIDO_CANCELADO = "4";
        static public string ESTADO_PEDIDO_RECHAZADO = "5";
        */
        static public string ESTADO_PEDIDO_BORRADOR_NOMBRE = "Borrador";

        //Estado de aprobacion del Pedido
        static public string PEDIDO_ESTADO_APROBACION_BORRADOR = "0";
        static public string PEDIDO_ESTADO_APROBACION_EN_APROBACION_RESPONSABLE = "1";
        static public string PEDIDO_ESTADO_APROBACION_EN_APROBACION_LOGISTICA = "2";
        static public string PEDIDO_ESTADO_APROBACION_APROBADO = "3";
        static public string PEDIDO_ESTADO_APROBACION_RECHAZADO = "4";

        //Estado de control del Pedido
        static public string PEDIDO_ESTADO_CONTROL_BORRADOR = "0";
        static public string PEDIDO_ESTADO_CONTROL_COTIZACION_PENDIENTE = "1";
        static public string PEDIDO_ESTADO_CONTROL_COTIZADO = "2";
        static public string PEDIDO_ESTADO_CONTROL_EN_APROBACION_OC = "3";
        static public string PEDIDO_ESTADO_CONTROL_OC_APROBADA = "4";
        static public string PEDIDO_ESTADO_CONTROL_OC_PENDIENTE_ENVIO_PROVEEDOR = "5";
        static public string PEDIDO_ESTADO_CONTROL_OC_ENVIADO_PROVEEDOR = "6";
        static public string PEDIDO_ESTADO_CONTROL_OC_CON_RECEPCION = "7";
        static public string PEDIDO_ESTADO_CONTROL_OC_CON_DESPACHO = "8";
        static public string PEDIDO_ESTADO_CONTROL_CERRADO = "9";
        static public string PEDIDO_ESTADO_EN_DESPACHO = "10";
        static public string PEDIDO_ESTADO_DESPACHADO = "11";
        static public string PEDIDO_ESTADO_CONTROL_COTIZADO_PARCIALMENTE = "13";

        //Transaccion de Inv
        static public string TRXINV_INGRESO_RECEPCION_OC = "2";
        
        //Estado de Aprobacion de OC
        static public string ESTADO_APROBACION_OC_ENPROCESO = "1";
        static public string ESTADO_APROBACION_OC_APROBADO = "2";
        static public string ESTADO_APROBACION_OC_RECHAZADO = "3";

        //Estado de Control de OC
        static public string ESTADO_CONTROL_OC_ACTIVO = "1";
        static public string ESTADO_CONTROL_OC_ANULADO = "2";
        static public string ESTADO_CONTROL_OC_CERRADO = "3";
        static public string ESTADO_CONTROL_OC_CERRADO_PARA_RECEPCION = "4";
        static public string ESTADO_CONTROL_OC_CERRADO_PARA_FACTURACION = "5";

        //
        static public string FLAG_SI = "S";
        static public string FLAG_NO = "N";
        
        //Estado de Recepcion de OC
        static public string ESTADO_RECEPCION_INGRESO_OC = "1";
        static public string ESTADO_RECEPCION_INVENTARIO_OC = "2";
        static public string ESTADO_RECEPCION_DESPACHO_OC = "3";

        static public string MONEDA_DEFECTO = "SOL";
        static public int SEDE_PUNTO_PARTIDA_DEFECTO = 2;


    }
}
