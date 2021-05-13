using System;
using System.Text.RegularExpressions;

namespace Cleverbit.CodingTask.Utilities
{
    public static class ObjectExtensions
    {
 

        public static DateTime AddHoraIni(this DateTime Value)
        {

            return Value.AddHours(00).AddMinutes(00).AddSeconds(00);
        }

        public static DateTime AddHoraFim(this DateTime Value)
        {

            return Value.AddHours(23).AddMinutes(59).AddSeconds(59);
        }

        public static string ToOracleString(this string Value)
        {
            if (String.IsNullOrEmpty(Value))
            {
                return "NULL";
            }
            else
            {
                return "'" + Value.Replace("'", "''") + "'";
            }
        }

        public static string ToOracleString(this char Value)
        {
            if (Char.IsControl(Value) || Char.IsWhiteSpace(Value))
            {
                return "NULL";
            }
            else
            {

                return "'" + Value + "'";
            }
        }

        public static string ToOracleNumber(this decimal Value)
        {
            return Value.ToString().Replace(",", ".");
        }

        public static string ToOracleNumber(this float Value)
        {
            return Value.ToString().Replace(",", ".");
        }

        public static string ToOracleNumber(this double Value)
        {
            return Value.ToString().Replace(",", ".");
        }

        public static string ToOracleDate(this DateTime? Value)
        {
            if (Value == null)
            {
                return "NULL";
            }
            else
            {
                return "TO_DaTE('" + Value.Value.ToString("dd/MM/yyyy") + "','DD/MM/YYYY') ";
            }
        }

        public static string ToOracleDate(this DateTime Value)
        {

            return "TO_DATE('" + Value.ToString("dd/MM/yyyy") + "','DD/MM/YYYY')";
        }

        public static int TryParseInt(this object Value)
        {
            int result = 0;
            int.TryParse(Value.ToString(), out result);
            return result;
        }

        public static short TryParseShort(this object Value)
        {
            short result = 0;
            short.TryParse(Value.ToString(), out result);
            return result;
        }

        public static ushort TryParseUShort(this object value)
        {
            ushort result = 0;
            ushort.TryParse(value.ToString(), out result);
            return result;
        }
        public static byte TryParseByte(this object Value)
        {
            byte result = 0;
            byte.TryParse(Value.ToString(), out result);
            return result;
        }

        public static long TryParseLong(this object Value)
        {
            long result = 0;
            if (Value != null)
                long.TryParse(Value.ToString(), out result);
            return result;
        }

        public static float TryParseFloat(this object Value)
        {
            float result = 0.0f;
            float.TryParse(Value.ToString(), out result);
            return result;
        }

        public static double TryParseDouble(this object Value)
        {
            double result = 0.0;
            double.TryParse(Value.ToString(), out result);
            return result;
        }

        public static DateTime? TryParseDate(this string Value)
        {
            DateTime result = DateTime.MinValue;
            DateTime.TryParse(Value, out result);
            return result != DateTime.MinValue ? result : new Nullable<DateTime>();
        }
        public static decimal TryParseDecimal(this string Value)
        {
            decimal result = 0;
            decimal.TryParse(Value, out result);
            return result;
        }

        public static char TryParseChar(this object Value)
        {

            char result = ' ';
            char.TryParse(Value.ToString().Substring(0, 1), out result);

            return result;
        }

        public static bool StringValidate(this string Value, string pattern)
        {

            return Regex.IsMatch(Value, pattern);
        }

        public static double RoundDown(this double value, int digits)
        {
            long factor = (long)Math.Pow(10, digits);

            return Math.Truncate(value * factor) / factor;
        }

        public static float RoundDown(this float value, int digits)
        {
            long factor = (long)Math.Pow(10, digits);

            string o = Convert.ToString(value * factor);

            return (float)Math.Truncate(float.Parse(o)) / factor;
        }
    }
}
