using Konpairu.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Konpairu.Models;

public class SemanticAnalyzer
{
    public bool IsSemanticallyCorrect(string expression)
    {
        string[] lexemes = Common.SplitExpression(expression).ToArray();

        if (lexemes.Length == 3) { return true; }

        string dataType = lexemes[0];
        string value = lexemes[3];

        #region Data Type Checking
        switch (dataType)
        {
            case "String":
                if (value[0] != '\"' || value[^1] != '\"')
                    return false;
                break;
            case "char":
                if (value.Length != 3 || value[0] != '\"' || value[2] != '\"')
                {
                    try
                    {
                        long num = long.Parse(value);
                        if (num < 0)
                            return false;
                    }
                    catch (FormatException)
                    {
                        return false;
                    }
                }
                break;
            case "byte":
                try
                {
                    byte.Parse(value);
                }
                catch (FormatException)
                {
                    return false;
                }
                break;
            case "short":
                try
                {
                    short.Parse(value);
                }
                catch (FormatException)
                {
                    return false;
                }
                break;
            case "int":
                try
                {
                    int.Parse(value);
                }
                catch (FormatException)
                {
                    return false;
                }
                break;
            case "long":
                try
                {
                    long.Parse(value);
                }
                catch (FormatException)
                {
                    return false;
                }
                break;
            case "float":
                try
                {
                    float.Parse(value);
                }
                catch (FormatException)
                {
                    return false;
                }
                break;
            case "double":
                try
                {
                    double.Parse(value);
                }
                catch (FormatException)
                {
                    return false;
                }
                break;
            case "boolean":
                if (!value.Equals("true") && !value.Equals("false"))
                {
                    return false;
                }
                break;
            default: return false;
        }
        #endregion

        return true;
    }
}