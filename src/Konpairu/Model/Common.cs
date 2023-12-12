using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Konpairu.Model
{
    public static class Common
    {
        public static List<string> SplitExpression(string expression)
        {
            List<string> parts = new();
            string[] firstSplit = Regex.Split(expression, "\\s+(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");
            foreach (string split in firstSplit)
            {
                parts.AddRange(Regex.Split(split, "(?=;)|(?<=;)|(?<==)|(?==)"));
            }

            parts.RemoveAll(string.IsNullOrEmpty);

            return parts;
        }
    }
}
