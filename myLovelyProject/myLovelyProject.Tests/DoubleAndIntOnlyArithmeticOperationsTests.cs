using NUnit.Framework;
using System.Collections.Generic;
using Antlr4.Runtime.Misc;

namespace myLovelyProject.Tests
{
    class DoubleAndIntOnlyArithmeticOperationsTests
    {
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// Correct Tests on easy arythmetical expressions with double and int numbers
        /// without variables and functions.
        /// 
        /// In these tests:
        /// isCorrectTree = true
        /// testData = null (no hashTable!)
        /// </summary>
        /// 
        [Test]
        public void OneDoubleCorrectTest()
        {
            string testExpression = "3.14";
            double testAnswer = 3.14;
            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(null);

            Assert.IsTrue(SpecialFunctionsForTest.AreEqualDouble(testAnswer, testVisitor.Visit(testTree).value));
        }

        [Test]
        public void OneDoubleComparingWithIntCorrectTest()
        {
            string testExpression = "3.0";
            double testAnswer = 3;
            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(null);

            Assert.IsTrue(SpecialFunctionsForTest.AreEqualDouble(testAnswer, testVisitor.Visit(testTree).value));
        }

        [Test]
        public void DoublesDoublePlusIntCorrectTest()
        {
            string testExpression = "-3.14 + 2";
            double testAnswer = -1.14;
            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(null);

            Assert.IsTrue(SpecialFunctionsForTest.AreEqualDouble(testAnswer, testVisitor.Visit(testTree).value));
        }

        [Test]
        public void DoublesTwoSignsAfterDotComeToOneSignAfterSummCorrectTest()
        {
            string testExpression = "3.14 + 5.06";
            double testAnswer = 8.2;
            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(null);

            Assert.IsTrue(SpecialFunctionsForTest.AreEqualDouble(testAnswer, testVisitor.Visit(testTree).value));
        }

        [Test]
        public void DoublesTwoSignsAfterDotComeToOneNullAfterMinusCorrectTest()
        {
            string testExpression = "3.14 - 5.14";
            double testAnswer = -2.0;
            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(null);

            Assert.IsTrue(SpecialFunctionsForTest.AreEqualDouble(testAnswer, testVisitor.Visit(testTree).value));
        }

        [Test]
        public void DoublesOddNullsInTestExpressionCorrectTest()
        {
            string testExpression = "3.14000";
            double testAnswer = 3.14;
            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(null);

            Assert.IsTrue(SpecialFunctionsForTest.AreEqualDouble(testAnswer, testVisitor.Visit(testTree).value));
        }

        /// <summary>
        /// InCorrect Tests on incorrect doubles
        /// 
        /// In these tests:
        /// isCorrectTree = false
        /// </summary>
        /// 

        [Test]
        public void DoublesSpaceAfterDotCrushTest()
        {
            string testExpression = "3. 14";

            var testExpectedTokens = new List<string>();
            string[] expectedTokens = { "EOF", "", "RPAREN", "PLUS", "MINUS", "TIMES", "DIV", "AND", "OR", "BOOLEQ", "SEMI" };
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
        public void DoublesSpaceBeforeDotCrushTest()
        {
            string testExpression = "3 .14";

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
    }
}
