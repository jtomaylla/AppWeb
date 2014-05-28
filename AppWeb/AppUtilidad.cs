using System;
using System.Data;
using System.Configuration;
using System.Globalization;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;

/// <summary>
/// Descripción breve de AppUtilidad
/// </summary>
/// 
namespace pe.com.rbtec.web
{
    public static class AppUtilidad
    {
        private static CultureInfo m_cultureInfo = new CultureInfo(pe.com.rbtec.web.AppConfig.AppCultureInfo());

        public static string numberToText(string num)
        {
            string res, dec = "";
            Int64 entero;
            int decimales;
            double nro;

            try
            {
                nro = Convert.ToDouble(num);
            }
            catch
            {
                return "";
            }

            entero = Convert.ToInt64(Math.Truncate(nro));
            decimales = Convert.ToInt32(Math.Round((nro - entero) * 100, 2));

            if (decimales > 0)
            {
                dec = " CON " + decimales.ToString() + "/100";
            }

            res = toText(Convert.ToDouble(entero)) + dec;

            return res;

        }

        private static string toText(double value)
        {

            string Num2Text = "";
            value = Math.Truncate(value);

            if (value == 0) Num2Text = "CERO";
            else if (value == 1) Num2Text = "UNO";
            else if (value == 2) Num2Text = "DOS";
            else if (value == 3) Num2Text = "TRES";
            else if (value == 4) Num2Text = "CUATRO";
            else if (value == 5) Num2Text = "CINCO";
            else if (value == 6) Num2Text = "SEIS";
            else if (value == 7) Num2Text = "SIETE";
            else if (value == 8) Num2Text = "OCHO";
            else if (value == 9) Num2Text = "NUEVE";
            else if (value == 10) Num2Text = "DIEZ";
            else if (value == 11) Num2Text = "ONCE";
            else if (value == 12) Num2Text = "DOCE";
            else if (value == 13) Num2Text = "TRECE";
            else if (value == 14) Num2Text = "CATORCE";
            else if (value == 15) Num2Text = "QUINCE";
            else if (value < 20) Num2Text = "DIECI" + toText(value - 10);
            else if (value == 20) Num2Text = "VEINTE";
            else if (value < 30) Num2Text = "VEINTI" + toText(value - 20);
            else if (value == 30) Num2Text = "TREINTA";
            else if (value == 40) Num2Text = "CUARENTA";
            else if (value == 50) Num2Text = "CINCUENTA";
            else if (value == 60) Num2Text = "SESENTA";
            else if (value == 70) Num2Text = "SETENTA";
            else if (value == 80) Num2Text = "OCHENTA";
            else if (value == 90) Num2Text = "NOVENTA";
            else if (value < 100) Num2Text = toText(Math.Truncate(value / 10) * 10) + " Y " + toText(value % 10);
            else if (value == 100) Num2Text = "CIEN";
            else if (value < 200) Num2Text = "CIENTO " + toText(value - 100);
            else if ((value == 200) || (value == 300) || (value == 400) || (value == 600) || (value == 800)) Num2Text = toText(Math.Truncate(value / 100)) + "CIENTOS";
            else if (value == 500) Num2Text = "QUINIENTOS";

            else if (value == 700) Num2Text = "SETECIENTOS";

            else if (value == 900) Num2Text = "NOVECIENTOS";

            else if (value < 1000) Num2Text = toText(Math.Truncate(value / 100) * 100) + " " + toText(value % 100);

            else if (value == 1000) Num2Text = "MIL";

            else if (value < 2000) Num2Text = "MIL " + toText(value % 1000);

            else if (value < 1000000)
            {

                Num2Text = toText(Math.Truncate(value / 1000)) + " MIL";

                if ((value % 1000) > 0) Num2Text = Num2Text + " " + toText(value % 1000);

            }

            else if (value == 1000000) Num2Text = "UN MILLON";

            else if (value < 2000000) Num2Text = "UN MILLON " + toText(value % 1000000);

            else if (value < 1000000000000)
            {

                Num2Text = toText(Math.Truncate(value / 1000000)) + " MILLONES ";

                if ((value - Math.Truncate(value / 1000000) * 1000000) > 0) Num2Text = Num2Text + " " + toText(value - Math.Truncate(value / 1000000) * 1000000);

            }

            else if (value == 1000000000000) Num2Text = "UN BILLON";

            else if (value < 2000000000000) Num2Text = "UN BILLON " + toText(value - Math.Truncate(value / 1000000000000) * 1000000000000);

            else
            {

                Num2Text = toText(Math.Truncate(value / 1000000000000)) + " BILLONES";

                if ((value - Math.Truncate(value / 1000000000000) * 1000000000000) > 0) Num2Text = Num2Text + " " + toText(value - Math.Truncate(value / 1000000000000) * 1000000000000);

            }

            return Num2Text;

        }

        public static string dateTimeToString(DateTime dtDate, string strFormato)
        {
            string strFecha = "";

            if (dtDate != null)
            {
                if (strFormato.ToUpper() == "DD/MM/YYYY")
                    strFecha = dtDate.Day.ToString().PadLeft(2, '0') + "/" + dtDate.Month.ToString().PadLeft(2, '0') + "/" + dtDate.Year.ToString();
            }

            return strFecha;

            //System.IFormatProvider MiFp = new System.Globalization.CultureInfo("es-PE", false);
            //return dtDate.ToString(strFormato, MiFp);
        }

        public static string formatSqlDateTime(string strDate, string strFormato)
        {
            if (strDate.Trim() == "")
            {
                return "";
            }

            if (strDate != null)
            {
                //DD/MM/YYYY
                if (strFormato.ToUpper() == "DD/MM/YYYY")
                    return strDate.Substring(6, 4) + strDate.Substring(3, 2) + strDate.Substring(0, 2);
                else
                    return "";
            }
            else
            {
                return "";
            }

        }

        public static DateTime stringToDateTime(string strDate, string strFormato)
        {
            if (strDate.Trim() == "")
            {
                System.DateTime date1 = new System.DateTime(1900, 1, 1);
                return date1;
            }

            if (strDate != null)
            {
                //DD/MM/YYYY
                if (strFormato.ToUpper() == "DD/MM/YYYY")
                {
                    int dia = int.Parse(strDate.Substring(0, 2));
                    int mes = int.Parse(strDate.Substring(3, 2));
                    int anio = int.Parse(strDate.Substring(6, 4));

                    System.DateTime date1 = new System.DateTime(anio, mes, dia);
                    return date1;
                }
                else
                {
                    System.DateTime date1 = new System.DateTime(1900, 1, 1);
                    return date1;
                }
            }
            else
            {
                System.DateTime date1 = new System.DateTime(1900, 1, 1);
                return date1;
            }

            //System.IFormatProvider MiFp = new System.Globalization.CultureInfo("es-PE", false);
            //return DateTime.ParseExact(strDate, strFormato, MiFp);

        }

        public static string floatToStringSinDecimales(float fValor)
        {
            m_cultureInfo.NumberFormat.CurrencyDecimalDigits = 0;
            m_cultureInfo.NumberFormat.NumberDecimalDigits = 0;
            return fValor.ToString("N", m_cultureInfo.NumberFormat);
        }

        public static string QuitarPuntoMiles(string strCadena)
        {
            strCadena = strCadena.Replace(".", "");
            return strCadena;
        }

        //Valido solo en CHILE
        public static string formatRUT(string strCadena)
        {
            string str = strCadena.Trim();
            try
            {
                if (str.Trim().Length > 1)
                {
                    string strDigito = str.Trim().Substring(str.Length - 1, 1);
                    string strNumero = str.Trim().Substring(0, str.Length - 1);
                    double dblRut;

                    if (Double.TryParse(strNumero, out dblRut))
                    {
                        return (String.Format("{0:N0}", dblRut)).Replace(',', '.') + "-" + strDigito;
                    }
                    else
                        return strNumero + "-" + strDigito;
                }
                else
                {
                    return str;
                }

            }
            catch (Exception err)
            {
                return str;
            }

        }

        public static string formatError(string strCadena)
        {
            return "<UL><LI>" + strCadena + "</UL>";
        }

        public static string readString(object objValue)
        {
            string strValue = "";

            if (objValue != System.DBNull.Value)
                strValue = Convert.ToString(objValue);

            return strValue;

        }

        public static float readFloat(object objValue)
        {
            float fltValue = 0;

            if (objValue != System.DBNull.Value)
            {
                if (float.TryParse(objValue.ToString(), out fltValue))
                {
                    return fltValue;
                }
            }
            return fltValue;
        }

        public static Decimal readDecimal(object objValue)
        {
            decimal decValue = 0;
            if (objValue != System.DBNull.Value)
                decValue = Convert.ToDecimal(objValue);

            return decValue;
        }

        public static double readDouble(object objValue)
        {
            Double dblValue = 0;
            if (objValue != System.DBNull.Value)
                dblValue = Convert.ToDouble(objValue);

            return dblValue;
        }

        public static Int32 readInt32(object objValue)
        {
            Int32 intValue = 0;

            if (objValue != System.DBNull.Value)
                intValue = Convert.ToInt32(objValue);

            return intValue;
        }

        public static Int64 readInt64(object objValue)
        {
            Int64 intValue = 0;

            if (objValue != System.DBNull.Value)
                intValue = Convert.ToInt64(objValue);

            return intValue;
        }

        public static string readDateTimeToString(object objValue)
        {
            DateTime dtValue;
            string strValue = "";

            if (objValue != System.DBNull.Value)
            {
                dtValue = Convert.ToDateTime(objValue);
                strValue = dateTimeToString(dtValue, "dd/MM/yyyy");
            }
            return strValue;
        }

        public static string readDatetimeToString(object objValue, string formato)
        {
            DateTime dtValue;
            string strValue = "";

            if (objValue != System.DBNull.Value)
            {
                dtValue = Convert.ToDateTime(objValue);
                strValue = dateTimeToString(dtValue, formato);
            }
            return strValue;
        }

        public static void CreateCSVFile(DataTable dt, string strFilePath, bool bCabecera)
        {
            #region Export Grid to CSV

            // Create the CSV file to which grid data will be exported.
            StreamWriter sw = new StreamWriter(strFilePath, false);
            // First we will write the headers.

            //DataTable dt = m_dsProducts.Tables[0];
            int iColCount = dt.Columns.Count;

            if (bCabecera)
            {
                for (int i = 0; i < iColCount; i++)
                {
                    sw.Write(dt.Columns[i]);
                    if (i < iColCount - 1)
                    {
                        sw.Write(";");
                    }
                }
                sw.Write(sw.NewLine);
            }

            // Now write all the rows.

            foreach (DataRow dr in dt.Rows)
            {
                for (int i = 0; i < iColCount; i++)
                {
                    if (!Convert.IsDBNull(dr[i]))
                    {
                        sw.Write(dr[i].ToString());
                    }

                    if (i < iColCount - 1)
                    {
                        sw.Write(";");
                    }

                }
                sw.Write(sw.NewLine);
            }
            sw.Close();

            #endregion
        }

    }

}
