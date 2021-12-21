using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Core
{
    public class CommonHelper
    {
        public static string GetStartPath()
        {
            return Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;
        }

        public static string GetDbPath()
        {
            return System.IO.Path.Combine(GetStartPath(), "Database", "study.db");
        }
    }
}
