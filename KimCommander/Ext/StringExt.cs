using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KimCommander {
    public static class StringExt {
        public static bool Constains(this string source, string toCheck) {
            return ((source.Length - source.Replace(toCheck, string.Empty).Length) / toCheck.Length) > 0;
        }
    }
}
