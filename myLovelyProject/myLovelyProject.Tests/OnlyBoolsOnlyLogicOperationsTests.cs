using System;
using NUnit.Framework;
using Antlr4.Runtime.Misc;
using System.Collections.Generic;

namespace myLovelyProject.Tests
{
    class OnlyBoolsOnlyLogicOperationsTests
    {
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// Correct Tests on easy logical expressions without variables and functions.
        /// 
        /// In these tests:
        /// isCorrectTree = true
        /// testData = null (no hashTable!)
        /// </summary>
        
        [Test]
        public void OneBoolTrueCorrectTest()
        {
            string testExpression = "true";
            bool testAnswer = true;
            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(null);
            Assert.AreEqual(testAnswer, Boolean.Parse(testVisitor.Visit(testTree).value));
        }

        [Test]
        public void OneBoolFalseCorrectTest()
        {
            string testExpression = "false";
            bool testAnswer = false;
            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(null);
            Assert.AreEqual(testAnswer, Boolean.Parse(testVisitor.Visit(testTree).value));
        }

        [Test]
        public void BoolsTTDeterminationOfANDCorrectTest()
        {
            string testExpression = "true && true";
            bool testAnswer = true;
            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(null);
            Assert.AreEqual(testAnswer, Boolean.Parse(testVisitor.Visit(testTree).value));
        }

        [Test]
        public void BoolsTFDeterminationOfANDCorrectTest()
        {
            string testExpression = "true && false";
            bool testAnswer = false;
            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(null);
            Assert.AreEqual(testAnswer, Boolean.Parse(testVisitor.Visit(testTree).value));
        }

        [Test]
        public void BoolsFFDeterminationOfANDCorrectTest()
        {
            string testExpression = "false && false";
            bool testAnswer = false;
            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(null);
            Assert.AreEqual(testAnswer, Boolean.Parse(testVisitor.Visit(testTree).value));
        }

        [Test]
        public void BoolsTTDeterminationOfORCorrectTest()
        {
            string testExpression = "true || true";
            bool testAnswer = true;
            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(null);
            Assert.AreEqual(testAnswer, Boolean.Parse(testVisitor.Visit(testTree).value));
        }

        [Test]
        public void BoolsTFDeterminationOfORCorrectTest()
        {
            string testExpression = "false || true";
            bool testAnswer = true;
            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(null);
            Assert.AreEqual(testAnswer, Boolean.Parse(testVisitor.Visit(testTree).value));
        }

        [Test]
        public void BoolsFFDeterminationOfORCorrectTest()
        {
            string testExpression = "false || false";
            bool testAnswer = false;
            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(null);
            Assert.AreEqual(testAnswer, Boolean.Parse(testVisitor.Visit(testTree).value));
        }

        [Test]
        public void BoolsTwoOperationsWithoutNOTCorrectTest()
        {
            string testExpression = "false || true && true";
            bool testAnswer = true;
            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(null);
            Assert.AreEqual(testAnswer, Boolean.Parse(testVisitor.Visit(testTree).value));
        }

        [Test]
        public void BoolsWithParensCorrectTest()
        {
            string testExpression = "( false || true ) && true";
            bool testAnswer = true;
            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(null);
            Assert.AreEqual(testAnswer, Boolean.Parse(testVisitor.Visit(testTree).value));
        }

        [Test]
        public void OneBoolTrueWithNOTCorrectTest()
        {
            string testExpression = "!true";
            bool testAnswer = false;
            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(null);
            Assert.AreEqual(testAnswer, Boolean.Parse(testVisitor.Visit(testTree).value));
        }

        [Test]
        public void OneBoolFalseWithNOTCorrectTest()
        {
            string testExpression = "! false";
            bool testAnswer = true;
            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(null);
            Assert.AreEqual(testAnswer, Boolean.Parse(testVisitor.Visit(testTree).value));
        }

        [Test]
        public void BoolsWithNOTafterOperationCorrectTest()
        {
            string testExpression = "true && !true";
            bool testAnswer = false;
            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(null);
            Assert.AreEqual(testAnswer, Boolean.Parse(testVisitor.Visit(testTree).value));
        }

        [Test]
        public void BoolsWithFewNOTafterOperationCorrectTest()
        {
            string testExpression = "true && ! !true";
            bool testAnswer = true;
            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(null);
            Assert.AreEqual(testAnswer, Boolean.Parse(testVisitor.Visit(testTree).value));
        }

        [Test]
        public void BoolsTTDeterminationOfEQCorrectTest()
        {
            string testExpression = "true == true";
            bool testAnswer = true;
            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(null);
            Assert.AreEqual(testAnswer, Boolean.Parse(testVisitor.Visit(testTree).value));
        }

        [Test]
        public void BoolsTFDeterminationOfEQCorrectTest()
        {
            string testExpression = "false == true";
            bool testAnswer = false;
            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(null);
            Assert.AreEqual(testAnswer, Boolean.Parse(testVisitor.Visit(testTree).value));
        }

        [Test]
        public void BoolsFFDeterminationOfEQCorrectTest()
        {
            string testExpression = "false == false";
            bool testAnswer = true;
            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(null);
            Assert.AreEqual(testAnswer, Boolean.Parse(testVisitor.Visit(testTree).value));
        }

        [Test]
        public void BoolsWithEQCorrectTest()
        {
            string testExpression = "(true && !true) == (false && false || true)";
            bool testAnswer = false;
            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(null);
            Assert.AreEqual(testAnswer, Boolean.Parse(testVisitor.Visit(testTree).value));
        }

        [Test]
        public void BoolsWithEQCorrectPriorityOfOperationsCorrectTest()
        {
            string testExpression = "true && !true == false && false || true";
            bool testAnswer = true;
            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(null);
            Assert.AreEqual(testAnswer, Boolean.Parse(testVisitor.Visit(testTree).value));
        }

        [Test]
        public void BoolsNOTBeforeExpressionCorrectTest()
        {
            string testExpression = "! (true && false || false)";
            bool testAnswer = true;
            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(null);
            Assert.AreEqual(testAnswer, Boolean.Parse(testVisitor.Visit(testTree).value));
        }

        [Test]
        public void BoolsTwoNOTBeforeExpressionCorrectTest()
        {
            string testExpression = "! !(true && false || false)";
            bool testAnswer = false;
            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(null);
            Assert.AreEqual(testAnswer, Boolean.Parse(testVisitor.Visit(testTree).value));
        }

        [Test]
        public void BoolsNOTParenNOTParenCorrectTest()
        {
            string testExpression = "!(!(true))";
            bool testAnswer = true;
            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(null);
            Assert.AreEqual(testAnswer, Boolean.Parse(testVisitor.Visit(testTree).value));
        }

        /// <summary>
        /// Incorrect Tests on easy logical expressions without variables and functions.
        /// 
        /// In these tests:
        /// isCorrectTree = false
        /// testData = null (no hashTable!)
        /// </summary>

        [Test]
        public void OnlyBoolsWithoutOperationsCrushTest()
        {
            string testExpression = "true false";

            var testExpectedTokens = new List<string>();
            string[] expectedTokens = { "EOF", "", "RPAREN", "PLUS", "MINUS", "TIMES", "DIV", "AND", "OR", "BOOLEQ", "SEMI" };
            testExpectedTokens.AddRange(expectedTokens);

            (int line, int column) testErrorPosition = (1, 5);
            string testErrorMessage = SpecialFunctions.makeErrorMessage(testErrorPosition.line, testErrorPosition.column, testExpectedTokens);

            try
            {
                (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);
            }
            catch (ParseCanceledException error)
            {
                Assert.AreEqual(testErrorMessage, error.Message);
            }
        }

        [Test]
        public void OnlyBoolAndOperationCrushTest()
        {
            string testExpression = "false &&";

            var testExpectedTokens = new List<string>();
            string[] expectedTokens = { "TRUE", "FALSE", "NAMEIDENTIFIER", "INT", "DOUBLE", "LPAREN", "MINUS", "NOT" };
            testExpectedTokens.AddRange(expectedTokens);

            (int line, int column) testErrorPosition = (1, 8);
            string testErrorMessage = SpecialFunctions.makeErrorMessage(testErrorPosition.line, testErrorPosition.column, testExpectedTokens);

            try
            {
                (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);
            }
            catch (ParseCanceledException error)
            {
                Assert.AreEqual(testErrorMessage, error.Message);
            }
        }

        [Test]
        public void BoolsIncorrectOrderCrushTest()
        {
            string testExpression = "true || false true && ";

            var testExpectedTokens = new List<string>();
            string[] expectedTokens = { "EOF", "", "RPAREN", "PLUS", "MINUS", "TIMES", "DIV", "AND", "OR", "BOOLEQ", "SEMI" };
            testExpectedTokens.AddRange(expectedTokens);

            (int line, int column) testErrorPosition = (1, 14);
            string testErrorMessage = SpecialFunctions.makeErrorMessage(testErrorPosition.line, testErrorPosition.column, testExpectedTokens);

            try
            {
                (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);
            }
            catch (ParseCanceledException error)
            {
                Assert.AreEqual(testErrorMessage, error.Message);
            }
        }

        [Test]
        public void BoolsNoRightParenCrushTest()
        {
            string testExpression = "( false && true ";

            var testExpectedTokens = new List<string>();
            string[] expectedTokens = { "EOF", "", "RPAREN", "PLUS", "MINUS", "TIMES", "DIV", "AND", "OR", "BOOLEQ", "SEMI" };
            testExpectedTokens.AddRange(expectedTokens);

            (int line, int column) testErrorPosition = (1, 16);
            string testErrorMessage = SpecialFunctions.makeErrorMessage(testErrorPosition.line, testErrorPosition.column, testExpectedTokens);

            try
            {
                (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);
            }
            catch (ParseCanceledException error)
            {
                Assert.AreEqual(testErrorMessage, error.Message);
            }
        }

        [Test]
        public void BoolsNoLeftParenCrushTest()
        {
            string testExpression = " false && true ) ";

            var testExpectedTokens = new List<string>();
            string[] expectedTokens = { "EOF", "", "RPAREN", "PLUS", "MINUS", "TIMES", "DIV", "AND", "OR", "BOOLEQ", "SEMI" };
            testExpectedTokens.AddRange(expectedTokens);

            (int line, int column) testErrorPosition = (1, 15);
            string testErrorMessage = SpecialFunctions.makeErrorMessage(testErrorPosition.line, testErrorPosition.column, testExpectedTokens);

            try
            {
                (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);
            }
            catch (ParseCanceledException error)
            {
                Assert.AreEqual(testErrorMessage, error.Message);
            }
        }

        [Test]
        public void BoolsNOTBeforeParenAndNoRightParenCrushTest()
        {
            string testExpression = "! (false || true";

            var testExpectedTokens = new List<string>();
            string[] expectedTokens = { "EOF", "", "RPAREN", "PLUS", "MINUS", "TIMES", "DIV", "AND", "OR", "BOOLEQ", "SEMI" };
            testExpectedTokens.AddRange(expectedTokens);

            (int line, int column) testErrorPosition = (1, 16);
            string testErrorMessage = SpecialFunctions.makeErrorMessage(testErrorPosition.line, testErrorPosition.column, testExpectedTokens);

            try
            {
                (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);
            }
            catch (ParseCanceledException error)
            {
                Assert.AreEqual(testErrorMessage, error.Message);
            }
        }

        [Test]
        public void BoolsOperationBeforeParenCrushTest()
        {
            string testExpression = "|| (true && false)";

            var testExpectedTokens = new List<string>();
            string[] expectedTokens = { "TRUE", "FALSE", "NAMEIDENTIFIER", "INT", "DOUBLE", "LPAREN", "MINUS", "NOT" };
            testExpectedTokens.AddRange(expectedTokens);

            (int line, int column) testErrorPosition = (1, 0);
            string testErrorMessage = SpecialFunctions.makeErrorMessage(testErrorPosition.line, testErrorPosition.column, testExpectedTokens);

            try
            {
                (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);
            }
            catch (ParseCanceledException error)
            {
                Assert.AreEqual(testErrorMessage, error.Message);
            }
        }

        [Test]
        public void BoolsNOTAndOperationBeforeParenCrushTest()
        {
            string testExpression = "! == (false || true)";

            var testExpectedTokens = new List<string>();
            string[] expectedTokens = { "TRUE", "FALSE", "NAMEIDENTIFIER", "INT", "DOUBLE", "LPAREN", "MINUS", "NOT" };
            testExpectedTokens.AddRange(expectedTokens);

            (int line, int column) testErrorPosition = (1, 2);
            string testErrorMessage = SpecialFunctions.makeErrorMessage(testErrorPosition.line, testErrorPosition.column, testExpectedTokens);

            try
            {
                (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);
            }
            catch (ParseCanceledException error)
            {
                Assert.AreEqual(testErrorMessage, error.Message);
            }
        }

        [Test]
        public void BoolsTwoOperationsTogetherCrushTest()
        {
            string testExpression = "true || && false";

            var testExpectedTokens = new List<string>();
            string[] expectedTokens = { "TRUE", "FALSE", "NAMEIDENTIFIER", "INT", "DOUBLE", "LPAREN", "MINUS", "NOT" };
            testExpectedTokens.AddRange(expectedTokens);

            (int line, int column) testErrorPosition = (1, 8);
            string testErrorMessage = SpecialFunctions.makeErrorMessage(testErrorPosition.line, testErrorPosition.column, testExpectedTokens);

            try
            {
                (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);
            }
            catch (ParseCanceledException error)
            {
                Assert.AreEqual(testErrorMessage, error.Message);
            }
        }

        [Test]
        public void BoolsNOTAndOperationTogetherCrushTest()
        {
            string testExpression = " false ! || false";

            var testExpectedTokens = new List<string>();
            string[] expectedTokens = { "EOF", "", "RPAREN", "PLUS", "MINUS", "TIMES", "DIV", "AND", "OR", "BOOLEQ", "SEMI" };
            testExpectedTokens.AddRange(expectedTokens);

            (int line, int column) testErrorPosition = (1, 7);
            string testErrorMessage = SpecialFunctions.makeErrorMessage(testErrorPosition.line, testErrorPosition.column, testExpectedTokens);

            try
            {
                (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);
            }
            catch (ParseCanceledException error)
            {
                Assert.AreEqual(testErrorMessage, error.Message);
            }
        }
    }
}
