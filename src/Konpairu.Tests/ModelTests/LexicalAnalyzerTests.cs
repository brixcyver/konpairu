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
        private LexicalAnalyzer lexicalAnalyzer;

        public LexicalAnalyzerTests()
        {
            this.lexicalAnalyzer = new LexicalAnalyzer();
        }

        [Theory]
        [InlineData(";a int 5=", true)]
        [InlineData("for while if", false)]
        public void LexicalAnalyzer_IsLexicallyCorrect_ReturnsBool(string expression, bool expected)
        {
            var result = lexicalAnalyzer.IsLexicallyCorrect(expression);

            result.Should().Be(expected);
        }
    }
}
