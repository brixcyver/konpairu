using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Konpairu;
using FluentAssertions;
using Konpairu.Models;

namespace Konpairu.Tests.ModelTests
{
    public class LexicalAnalyzerTests
    {
        private readonly LexicalAnalyzer lexicalAnalyzer;

        public LexicalAnalyzerTests()
        {
            this.lexicalAnalyzer = new LexicalAnalyzer();
        }

        [Theory]
        [InlineData("boolean 3rror = true;", false)]
        [InlineData("for while if", false)]
        [InlineData(";a int 5=", true)]
        public void LexicalAnalyzer_IsLexicallyCorrect_ReturnsBool(string expression, bool expected)
        {
            var result = lexicalAnalyzer.IsLexicallyCorrect(expression);

            result.Should().Be(expected);
        }
    }
}
