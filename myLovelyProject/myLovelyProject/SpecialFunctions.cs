using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace myLovelyProject.Tests
{
    public class SpecialFunctions
    {
        /// <summary>
        /// This method returns tree, made from expression, and bool, which indicates correctness of tree
        /// </summary>
        public static (arithmeticParser.FileContext, bool) MakeTreeAndCheck(string input)
        {
            var str = new AntlrInputStream(input);
            var lexer = new arithmeticLexer(str);
            var tokens = new CommonTokenStream(lexer);
            var parser = new arithmeticParser(tokens);
            var listener = new ErrorListener<IToken>(parser, lexer, tokens);
            parser.AddErrorListener(listener);
            var tree = parser.file(); 
            var IsCorrectTree = !listener.had_error;

           // Error(tree, tokens);

            return (tree, IsCorrectTree);
        }

        /// <summary>
        /// This method replaces .ToString() for bools because .ToSting() retunrs "True" and "False",
        /// while visitor works with "true" and "false".
        /// </summary>
        public static string BoolToString(bool data)
        {
            if (data)
            {
                return "true";
            }
            else
            {
                return "false";
            }
        }

        public static bool AreEqualDouble(double expected, string testResult)
        {
            double eps = 1E-10;
            double doubleResult = Double.Parse(testResult, CultureInfo.InvariantCulture);
            return Math.Abs(expected - doubleResult) < eps;
        }

        public static string makeErrorMessage(int line, int column, List<string> expectedTokens)
        {
            var message = "Parse error line/col " + line + "/" + column
                                                      + ", expecting " + String.Join(", ", expectedTokens);
            return message;
        }
    }

}
