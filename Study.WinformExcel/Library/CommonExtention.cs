using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.WinformExcel.Library
{
    public static class CommonExtention
    {
        public static bool IsNull(this string str)
        {
            return string.IsNullOrEmpty(str);
        }

        public static string IsNull(this string str, string str2)
        {
            if (string.IsNullOrEmpty(str) == true)
            {
                return str2;
            }
            else
            {
                return str;
            }
        }

        public static string ToString(this DateTime? dateTime, string format)
        {
            if (dateTime.HasValue == true)
            {
                return dateTime.Value.ToString(format);
            }
            else
            {
                return null;
            }
        }

        public static string ToDefaultString(this DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-dd");
        }

        public static string ToDefaultString(this DateTime? dateTime)
        {
            if (dateTime.HasValue == true)
            {
                return dateTime.Value.ToString("yyyy-MM-dd");
            }
            else
            {
                return null;
            }
        }
    }
}
