using FluentAssertions;
using Konpairu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konpairu.Tests.ModelTests
{
    public class SemanticAnalyzerTests
    {
        private readonly SemanticAnalyzer semanticAnalyzer;

        public SemanticAnalyzerTests()
        {
            this.semanticAnalyzer = new SemanticAnalyzer();
        }

        [Theory]
        [InlineData("String a = 5;", false)]
        [InlineData("int a = \"Hello\";", false)]
        [InlineData("boolean isSemanticallyCorrect = true;", true)]
        public void SemanticAnalyzer_IsSemanticallyCorrect_ReturnsBool(string expression, bool expected)
        {
            var result = semanticAnalyzer.IsSemanticallyCorrect(expression);

            result.Should().Be(expected);
        }
    }
}