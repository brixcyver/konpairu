using Konpairu.Model;
using System.Numerics;
using System.Text.RegularExpressions;

namespace Konpairu.Models;

public class LexicalAnalyzer
{
    private static List<string> dataTypes = new();
    private static List<string> tokens = new();
    private static List<string> identifiers = new();

    public static bool IsLexicallyCorrect(string expression)
    {
        InitializeDataTypes();

        List<string> lexemes = Common.SplitExpression(expression);

        foreach (string lexeme in lexemes)
        {
            string token = IdentifyToken(lexeme);
            tokens.Add(token);
        }

        foreach (string token in tokens)
        {
            if (!identifiers.Contains(token))
            {
                return false;
            }
        }

        return true;
    }

    public static void InitializeDataTypes()
    {
        dataTypes.Clear();
        identifiers.Clear();
        tokens.Clear();

        dataTypes.Add("int");
        dataTypes.Add("double");
        dataTypes.Add("char");
        dataTypes.Add("String");
        dataTypes.Add("boolean");
        dataTypes.Add("float");
        dataTypes.Add("long");
        dataTypes.Add("short");
        dataTypes.Add("byte");


        identifiers.Add("<identifier>");
        identifiers.Add("<data_type>");
        identifiers.Add("<assignment_operator>");
        identifiers.Add("<delimiter>");
        identifiers.Add("<value>");
    }

    private static string IdentifyToken(string lexeme)
    {
        var token = "";

        if (dataTypes.Contains(lexeme))
            token = "<data_type>";
        else if (lexeme.Equals("="))
            token = "<assignment_operator>";
        else if (lexeme.Equals(";"))
            token = "<delimiter>";
        else if (IsValue(lexeme))
            token = "<value>";
        else if (IsValidVariableName(lexeme))
            token = "<identifier>";

        return token;
    }

    public static bool IsValidVariableName(string variableName)
    {
        if (string.IsNullOrEmpty(variableName))
        {
            return false;
        }

        if (!char.IsLetter(variableName[0]) && variableName[0] != '_')
        {
            return false;
        }

        foreach (char character in variableName)
        {
            if (!char.IsLetterOrDigit(character) && character != '_')
            {
                return false;
            }
        }

        if (IsReservedKeyword(variableName))
        {
            return false;
        }

        if (variableName.StartsWith("__"))
        {
            return false;
        }

        return true;
    }

    private static bool IsReservedKeyword(string variableName)
    {
        string[] keywords = {
            "abstract", "assert", "boolean", "break", "byte", "case", "catch", "char", "class", "const",
            "continue", "default", "do", "double", "else", "enum", "extends", "final", "finally", "float",
            "for", "if", "implements", "import", "instanceof", "int", "interface", "long", "native", "new",
            "package", "private", "protected", "public", "return", "short", "static", "strictfp", "super",
            "switch", "synchronized", "this", "throw", "throws", "transient", "try", "void", "volatile", "while"
        };

        return Array.Exists(keywords, keyword => keyword.Equals(variableName));
    }

    private static bool IsValue(string lexeme)
    {
        if (lexeme[0] == '\"' && lexeme[lexeme.Length - 1] == '\"')
            return true;
        else if (lexeme.Length == 3 && lexeme[0] == '\'' && lexeme[2] == '\'')
            return true;
        else if (int.TryParse(lexeme, out _))
            return true;

        return false;
    }
}