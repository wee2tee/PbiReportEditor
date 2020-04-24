using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PbiReportEditor.Misc
{
    public class ThaiStringComparerOrdinal : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            //return string.CompareOrdinal(x, y);
            return string.Compare(x, y, StringComparison.Ordinal);
        }
    }
}
