using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Konpairu.Model
{
    public static partial class Common
    {
        public static List<string> SplitExpression(string expression)
        {
            List<string> parts = new();
            string[] firstSplit = SymbolSplit().Split(expression);
            foreach (string split in firstSplit)
            {
                parts.AddRange(QuoteSplit().Split(split));
            }

            parts.RemoveAll(string.IsNullOrEmpty);

            return parts;
        }

        [GeneratedRegex("(?=;)|(?<=;)|(?<==)|(?==)")]
        private static partial Regex QuoteSplit();
        [GeneratedRegex("\\s+(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)")]
        private static partial Regex SymbolSplit();
    }
}
