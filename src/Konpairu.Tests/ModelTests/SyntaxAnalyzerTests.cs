using FluentAssertions;
using Konpairu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konpairu.Tests.ModelTests
{
    public class SyntaxAnalyzerTests
    {
        private readonly SyntaxAnalyzer syntaxAnalyzer;

        public SyntaxAnalyzerTests()
        {
            syntaxAnalyzer = new SyntaxAnalyzer();
        }

        [Theory]
        [InlineData("false =; a boolean", false)]
        [InlineData("int b = \"bravo\";", true)]
        [InlineData("String a = 5;", true)]
        public void SyntaxAnalyzer_IsSyntacticallyCorrect_ReturnsBool(string expression, bool expected)
        {
            var result = syntaxAnalyzer.IsSyntacticallyCorrect(expression);

            result.Should().Be(expected);
        }
    }
}
