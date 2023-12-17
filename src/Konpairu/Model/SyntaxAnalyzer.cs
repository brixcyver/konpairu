using Konpairu.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konpairu.Models;

public class SyntaxAnalyzer
{
    private static readonly List<string> dataTypes = new();
    private static readonly List<string> identifiers = new();
    private static readonly List<string> tokens = new();

    public static bool IsSyntacticallyCorrect(string expression)
    {
        InitializeDataTypes();

        string[] lexemes = Common.SplitExpression(expression).ToArray();

        foreach (string lexeme in lexemes)
        {
            tokens.Add(IdentifyToken(lexeme));
        }

        if (tokens[0] != "<data_type>") return false;
        if (tokens[1] != "<identifier>") return false;
        if (tokens[2] == "<delimiter>" && tokens.Count == 3) return true;

        if (tokens[2] != "<assignment_operator>") return false;
        if (tokens[3] != "<value>") return false;
        if (tokens[4] != "<delimiter>") return false;

        return true;
    }

    private static string IdentifyToken(string lexeme)
    {
        var token = "<identifier>";

        if (dataTypes.Contains(lexeme))
            token = "<data_type>";
        else if (lexeme.Equals("="))
            token = "<assignment_operator>";
        else if (lexeme.Equals(";"))
            token = "<delimiter>";
        else if (IsValue(lexeme))
            token = "<value>";

        return token;
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

    private static bool IsValue(string lexeme)
    {
        if (lexeme == "true" || lexeme == "false") return true;

        if (lexeme[0] == '\"' && lexeme[^1] == '\"')
            return true;
        else if (lexeme.Length == 3 && lexeme[0] == '\'' && lexeme[2] == '\'')
            return true;
        else if (int.TryParse(lexeme, out _))
            return true;

        return false;
    }
}