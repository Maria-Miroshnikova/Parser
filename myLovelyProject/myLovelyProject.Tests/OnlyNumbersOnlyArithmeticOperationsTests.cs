using Antlr4.Runtime.Misc;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace myLovelyProject.Tests
{
    public class OnlyNumbersOnlyArithmeticOperationsTests
    {
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// Correct Tests on easy arythmetical expressions without variables and functions.
        /// 
        /// In these tests:
        /// isCorrectTree = true
        /// testData = null (no hashTable!)
        /// </summary>

        [Test]
        public void OneNumberCorrectTest()
        {
            string testExpression = "2";
            double testAnswer = 2;
            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(null);

            Assert.AreEqual(testAnswer, Double.Parse(testVisitor.Visit(testTree).value));
        }

        [Test]
        public void NumbersWithoutMinusCorrectTest()
        {
            string testExpression = "1 + 2 * 3";
            double testAnswer = 7;
            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(null);

            Assert.AreEqual(testAnswer, Double.Parse(testVisitor.Visit(testTree).value));
        }

        [Test]
        public void NumbersWithParensCorrectTest()
        {
            string testExpression = "2 + (1 * 3)";
            double testAnswer = 5;
            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(null);

            Assert.AreEqual(testAnswer, Double.Parse(testVisitor.Visit(testTree).value));
        }

        [Test]
        public void OneNumberWithMinusCorrectTest()
        {
            string testExpression = "-10";
            double testAnswer = -10;
            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(null);

            Assert.AreEqual(testAnswer, Double.Parse(testVisitor.Visit(testTree).value));
        }

        [Test]
        public void NumbersWithMinusBetweenNumbersCorrectTest()
        {
            string testExpression = "2 - 5";
            double testAnswer = -3;
            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(null);

            Assert.AreEqual(testAnswer, Double.Parse(testVisitor.Visit(testTree).value));
        }

        [Test]
        public void NumbersWithMinusBeforeNumberCorrectTest()
        {
            string testExpression = "-1 + ( 2 * 4 )";
            double testAnswer = 7;
            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(null);

            Assert.AreEqual(testAnswer, Double.Parse(testVisitor.Visit(testTree).value));
        }

        [Test]
        public void NumbersCorrectPriorityOfOperationsWithoutParensCorrectTest()
        {
            string testExpression = "48 / 2 + 4";
            double testAnswer = 28;
            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(null);

            Assert.AreEqual(testAnswer, Double.Parse(testVisitor.Visit(testTree).value));
        }

        [Test]
        public void NumbersCorrectPriorityOfOperationsWithParensCorrectTest()
        {
            string testExpression = "48 / ( 2 + 4 )";
            double testAnswer = 8;
            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(null);

            Assert.AreEqual(testAnswer, Double.Parse(testVisitor.Visit(testTree).value));
        }

        [Test]
        public void NumbersWithDufferentMinusesAndSpacesBetweenParensAndMinusesCorrectTest()
        {
            string testExpression = "- 6 - ( -10 / 5)";
            double testAnswer = -4;
            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(null);

            Assert.AreEqual(testAnswer, Double.Parse(testVisitor.Visit(testTree).value));
        }

        [Test]
        public void NumbersWithMinusAfterOperationCorrectTest()
        {
            string testExpression = "7 * -3";
            double testAnswer = -21;
            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(null);

            Assert.AreEqual(testAnswer, Double.Parse(testVisitor.Visit(testTree).value));
        }

        [Test]
        public void NumbersMinusBeforeWholeExpressionCorrectTest()
        {
            string testExpression = "-(3 * 4 + 5)";
            double testAnswer = -17;
            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(null);

            Assert.AreEqual(testAnswer, Double.Parse(testVisitor.Visit(testTree).value));
        }

        [Test]
        public void NumbersMinusParenMinusParenCorrectTest()
        {
            string testExpression = "-(-(3 * 4 + 5))";
            double testAnswer = 17;
            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(null);

            Assert.AreEqual(testAnswer, Double.Parse(testVisitor.Visit(testTree).value));
        }

        [Test]
        public void NumbersTwoMinusesBeforeWholeExpressionCorrectTest()
        {
            string testExpression = "-  -(3 * 4 + 5)";
            double testAnswer = 17;
            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(null);

            Assert.AreEqual(testAnswer, Double.Parse(testVisitor.Visit(testTree).value));
        }

        [Test]
        public void NumbersFewMinusesBeforeWholeExpressionCorrectTest()
        {
            string testExpression = "---(3 * 4 + 5)";
            double testAnswer = -17;
            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(null);

            Assert.AreEqual(testAnswer, Double.Parse(testVisitor.Visit(testTree).value));
        }

        [Test]
        public void NumbersFewMinusecAfterOperationCorrectTest()
        {
            string testExpression = " 1 + - - 64";
            double testAnswer = 65;
            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(null);

            Assert.AreEqual(testAnswer, Double.Parse(testVisitor.Visit(testTree).value));
        }

        /// <summary>
        /// Incorrect Tests on easy arythmetical expressions without variables and functions.
        /// 
        /// In these tests:
        /// isCorrectTree = false
        /// </summary>

        [Test]
        public void OnlyNumbersWithoutOperationsCrushTest()
        {
            string testExpression = "2 3";

            var testExpectedTokens = new List<string>();
            string[] expectedTokens = { "EOF", "", "RPAREN", "PLUS", "MINUS", "TIMES", "DIV", "AND", "OR", "BOOLEQ", "SEMI" };
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
        public void OnlyOneNumberAndOneOperationCrushTest()
        {
            string testExpression = " 10 +";

            var testExpectedTokens = new List<string>();
            string[] expectedTokens = { "TRUE", "FALSE", "NAMEIDENTIFIER", "INT", "DOUBLE", "LPAREN", "MINUS", "NOT" };
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
        public void NumbersIncorrectOrderCrushTest()
        {
            string testExpression = "1 + 2 3 * ";

            var testExpectedTokens = new List<string>();
            string[] expectedTokens = { "EOF", "", "RPAREN", "PLUS", "MINUS", "TIMES", "DIV", "AND", "OR", "BOOLEQ", "SEMI" };
            testExpectedTokens.AddRange(expectedTokens);

            (int line, int column) testErrorPosition = (1, 6);
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
        public void NumbersNoRightParenCrushTest()
        {
            string testExpression = "(1 + 5";

            var testExpectedTokens = new List<string>();
            string[] expectedTokens = { "EOF", "", "RPAREN", "PLUS", "MINUS", "TIMES", "DIV", "AND", "OR", "BOOLEQ", "SEMI" };
            testExpectedTokens.AddRange(expectedTokens);

            (int line, int column) testErrorPosition = (1, 6);
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
        public void NumbersNoLeftParenCrushTest()
        {
            string testExpression = "1 + 5 )";

            var testExpectedTokens = new List<string>();
            string[] expectedTokens = { "EOF", "", "RPAREN", "PLUS", "MINUS", "TIMES", "DIV", "AND", "OR", "BOOLEQ", "SEMI" };
            testExpectedTokens.AddRange(expectedTokens);

            (int line, int column) testErrorPosition = (1, 6);
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
        public void NumbersEmptyParenCrushTest()
        {
            string testExpression = "()";

            var testExpectedTokens = new List<string>();
            string[] expectedTokens = { "TRUE", "FALSE", "NAMEIDENTIFIER", "INT", "DOUBLE", "LPAREN", "MINUS", "NOT" };
            testExpectedTokens.AddRange(expectedTokens);

            (int line, int column) testErrorPosition = (1, 1);
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
        public void NumbersMinusBeforeParenAndNoRightParenCrushTest()
        {
            string testExpression = "- (3 - 5";

            var testExpectedTokens = new List<string>();
            string[] expectedTokens = { "EOF", "", "RPAREN", "PLUS", "MINUS", "TIMES", "DIV", "AND", "OR", "BOOLEQ", "SEMI" };
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
        public void NumbersOperationBeforeParenCrushTest()
        {
            string testExpression = "+ (3 - 5)";

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
        public void NumbersMinusAndOperationBeforeParenCrushTest()
        {
            string testExpression = "- + (3 - 5)";

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
        public void NumbersTwoOperationsTogetherCrushTest()
        {
            string testExpression = "1 + * 5";

            var testExpectedTokens = new List<string>();
            string[] expectedTokens = { "TRUE", "FALSE", "NAMEIDENTIFIER", "INT", "DOUBLE", "LPAREN", "MINUS", "NOT" };
            testExpectedTokens.AddRange(expectedTokens);

            (int line, int column) testErrorPosition = (1, 4);
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
        public void NumbersMinusAndPlusTogetherCrushTest()
        {
            string testExpression = " 1 - + 64";

            var testExpectedTokens = new List<string>();
            string[] expectedTokens = { "TRUE", "FALSE", "NAMEIDENTIFIER", "INT", "DOUBLE", "LPAREN", "MINUS", "NOT" };
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

        /// <summary>
        /// Exception Tests on easy arythmetical expressions without variables and functions WITH ZERO DIVISION.
        /// 
        /// In these tests:
        /// isCorrectTree = true
        /// testData = null (no hashTable!)
        /// expected DivideByZeroException
        /// </summary>

        [Test]
        public void NumbersShortZeroDivisionExceptionTest()
        {
            string testExpression = "-10 / 0";
            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(null);

            Assert.Throws<DivideByZeroException>(() => testVisitor.Visit(testTree));
        }

        [Test]
        public void NumbersLongZeroDivisionExceptionTest()
        {
            string testExpression = "-10 / ( 12 + 3 * - 4)";
            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(null);

            Assert.Throws<DivideByZeroException>(() => testVisitor.Visit(testTree));
        }
    }
}