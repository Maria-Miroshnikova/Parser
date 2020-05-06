using NUnit.Framework;
using System.Collections.Generic;
using System;
using Antlr4.Runtime.Misc;

namespace myLovelyProject.Tests
{
    public class OnlyVariablesIntOnlyArithmeticOperationsTests
    {
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// Correct Tests on expressions, which inclide numbers and variables (type "int" only).
        /// 
        /// in these tests:
        /// isCorrectTree = true
        /// testData != null
        /// testData stores information in correct format
        /// all variables are defined
        /// </summary>

        [Test]
        public void OneVariableIntCorrectTest()
        {
            var testData = new VarAndFuncDictionary();

            testData.AddVariable("a", "int", "2");
            testData.AddVariable("aa", "int", "7");
            testData.AddVariable("A", "int", "5");

            string testExpression = "a";
            int testAnswer = 2;

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);
            var testVisitor = new ParsingTreeVisitor(testData);
            Assert.AreEqual(testAnswer, Double.Parse(testVisitor.Visit(testTree).value));
        }

        [Test]
        public void VariablesIntWithoutMinusCorrectTest()
        {
            var testData = new VarAndFuncDictionary();

            testData.AddVariable("a", "int", "1");
            testData.AddVariable("aa", "int", "7");
            testData.AddVariable("b", "int", "2");
            testData.AddVariable("A", "int", "3");

            string testExpression = "a + b * A";
            int testAnswer = 7;

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);
            var testVisitor = new ParsingTreeVisitor(testData);
            Assert.AreEqual(testAnswer, Double.Parse(testVisitor.Visit(testTree).value));
        }

        public void VariablesIntAndNumberWithoutMinusCorrectTest()
        {
            var testData = new VarAndFuncDictionary();

            testData.AddVariable("a", "int", "1");
            testData.AddVariable("aa", "int", "7");
            testData.AddVariable("b", "int", "2");
            testData.AddVariable("A", "int", "3");

            string testExpression = "a + 2 * A";
            int testAnswer = 7;

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);
            var testVisitor = new ParsingTreeVisitor(testData);
            Assert.AreEqual(testAnswer, Double.Parse(testVisitor.Visit(testTree).value));
        }

        [Test]
        public void VariablesIntWithParensCorrectTest()
        {
            var testData = new VarAndFuncDictionary();

            testData.AddVariable("a", "int", "2");
            testData.AddVariable("aa", "int", "7");
            testData.AddVariable("b", "int", "1");
            testData.AddVariable("A", "int", "3");

            string testExpression = "a + ( b * A )";
            int testAnswer = 5;

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);
            var testVisitor = new ParsingTreeVisitor(testData);
            Assert.AreEqual(testAnswer, Double.Parse(testVisitor.Visit(testTree).value));
        }

        [Test]
        public void OnlyOneVariableIntIntWithMinusCorrectTest()
        {
            var testData = new VarAndFuncDictionary();

            testData.AddVariable("a", "int", "4");
            testData.AddVariable("aa", "int", "10");
            testData.AddVariable("A", "int", "5");

            string testExpression = "-aa";
            int testAnswer = -10;

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);
            var testVisitor = new ParsingTreeVisitor(testData);
            Assert.AreEqual(testAnswer, Double.Parse(testVisitor.Visit(testTree).value));
        }

        [Test]
        public void VariablesIntWithMinusBetweenNumbersCorrectTest()
        {
            var testData = new VarAndFuncDictionary();

            testData.AddVariable("a", "int", "5");
            testData.AddVariable("aa", "int", "10");
            testData.AddVariable("A", "int", "2");

            string testExpression = "A - a";
            int testAnswer = -3;

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);
            var testVisitor = new ParsingTreeVisitor(testData);
            Assert.AreEqual(testAnswer, Double.Parse(testVisitor.Visit(testTree).value));
        }

        [Test]
        public void VariablesIntWithMinusBeforeNumberCorrectTest()
        {
            var testData = new VarAndFuncDictionary();

            testData.AddVariable("a", "int", "4");
            testData.AddVariable("index", "int", "1");
            testData.AddVariable("index1", "int", "2");
            testData.AddVariable("indexa", "int", "1000");

            string testExpression = "-index + (index1 * a)";
            int testAnswer = 7;

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);
            var testVisitor = new ParsingTreeVisitor(testData);
            Assert.AreEqual(testAnswer, Double.Parse(testVisitor.Visit(testTree).value));
        }

        [Test]
        public void VariablesIntCorrectPriorityOfOperationsWithoutParensCorrectTest()
        {
            var testData = new VarAndFuncDictionary();

            testData.AddVariable("a", "int", "2");
            testData.AddVariable("aa", "int", "48");
            testData.AddVariable("b", "int", "1");
            testData.AddVariable("A", "int", "4");

            string testExpression = "aa / a + A";
            int testAnswer = 28;

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);
            var testVisitor = new ParsingTreeVisitor(testData);
            Assert.AreEqual(testAnswer, Double.Parse(testVisitor.Visit(testTree).value));
        }

        [Test]
        public void VariablesIntCorrectPriorityOfOperationsWithParensCorrectTest()
        {
            var testData = new VarAndFuncDictionary();

            testData.AddVariable("a", "int", "2");
            testData.AddVariable("aa", "int", "48");
            testData.AddVariable("b", "int", "1");
            testData.AddVariable("A", "int", "4");

            string testExpression = "aa / ( a + A)";
            int testAnswer = 8;

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);
            var testVisitor = new ParsingTreeVisitor(testData);
            Assert.AreEqual(testAnswer, Double.Parse(testVisitor.Visit(testTree).value));
        }

        [Test]
        public void VariablesIntWithDufferentMinusesAndSpacesBetweenParensAndMinusesCorrectTest()
        {
            var testData = new VarAndFuncDictionary();

            testData.AddVariable("a", "int", "5");
            testData.AddVariable("aa", "int", "48");
            testData.AddVariable("b", "int", "6");
            testData.AddVariable("A", "int", "10");

            string testExpression = "-b -( - A / a)";
            int testAnswer = -4;

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);
            var testVisitor = new ParsingTreeVisitor(testData);
            Assert.AreEqual(testAnswer, Double.Parse(testVisitor.Visit(testTree).value));
        }

        [Test]
        public void VariablesIntWithMinusAfterOperationCorrectTest()
        {
            var testData = new VarAndFuncDictionary();

            testData.AddVariable("a", "int", "7");
            testData.AddVariable("aa", "int", "3");
            testData.AddVariable("b", "int", "6");
            testData.AddVariable("A", "int", "10");

            string testExpression = "aa * -a";
            int testAnswer = -21;

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);
            var testVisitor = new ParsingTreeVisitor(testData);
            Assert.AreEqual(testAnswer, Double.Parse(testVisitor.Visit(testTree).value));
        }

        [Test]
        public void VaribablesIntMinusBeforeWholeExpressionCorrectTest()
        {
            var testData = new VarAndFuncDictionary();

            testData.AddVariable("a", "int", "3");
            testData.AddVariable("a2", "int", "4");
            testData.AddVariable("b", "int", "-64");
            testData.AddVariable("A", "int", "5");

            string testExpression = "-(a * a2 + A)";
            int testAnswer = -17;

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);
            var testVisitor = new ParsingTreeVisitor(testData);
            Assert.AreEqual(testAnswer, Double.Parse(testVisitor.Visit(testTree).value));
        }

        [Test]
        public void VaribablesIntTwoMinusesBeforeWholeExpressionCorrectTest()
        {
            var testData = new VarAndFuncDictionary();

            testData.AddVariable("a", "int", "3");
            testData.AddVariable("a2", "int", "4");
            testData.AddVariable("b", "int", "-64");
            testData.AddVariable("A", "int", "5");

            string testExpression = "- -(a * a2 + A)";
            int testAnswer = 17;

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);
            var testVisitor = new ParsingTreeVisitor(testData);
            Assert.AreEqual(testAnswer, Double.Parse(testVisitor.Visit(testTree).value));
        }

        [Test]
        public void VaribablesIntFewMinusesBeforeWholeExpressionCorrectTest()
        {
            var testData = new VarAndFuncDictionary();

            testData.AddVariable("a", "int", "3");
            testData.AddVariable("a2", "int", "4");
            testData.AddVariable("b", "int", "-64");
            testData.AddVariable("A", "int", "5");

            string testExpression = "---(a * a2 + A)";
            int testAnswer = -17;

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);
            var testVisitor = new ParsingTreeVisitor(testData);
            Assert.AreEqual(testAnswer, Double.Parse(testVisitor.Visit(testTree).value));
        }

        [Test]
        public void VaribablesIntMinusParenMinusParenCorrectTest()
        {
            var testData = new VarAndFuncDictionary();

            testData.AddVariable("a", "int", "3");
            testData.AddVariable("a2", "int", "4");
            testData.AddVariable("b", "int", "-64");
            testData.AddVariable("A", "int", "5");

            string testExpression = "-(-(a * a2 + A))";
            int testAnswer = 17;

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);
            var testVisitor = new ParsingTreeVisitor(testData);
            Assert.AreEqual(testAnswer, Double.Parse(testVisitor.Visit(testTree).value));
        }

        [Test]
        public void VariablesIntFewMinusecAfterOperationCorrectTest()
        {
            var testData = new VarAndFuncDictionary();

            testData.AddVariable("a", "int", "7");
            testData.AddVariable("aa", "int", "1");
            testData.AddVariable("b", "int", "64");
            testData.AddVariable("A", "int", "10");

            string testExpression = "aa + - - b";
            int testAnswer = 65;

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);
            var testVisitor = new ParsingTreeVisitor(testData);
            Assert.AreEqual(testAnswer, Double.Parse(testVisitor.Visit(testTree).value));
        }

        [Test]
        public void VariablesIntFewMinusecAfterOperationWithNegativeVariableCorrectTest()
        {
            var testData = new VarAndFuncDictionary();

            testData.AddVariable("a", "int", "7");
            testData.AddVariable("aa", "int", "-1");
            testData.AddVariable("b", "int", "-64");
            testData.AddVariable("A", "int", "10");

            string testExpression = "aa + - - b";
            int testAnswer = -65;

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);
            var testVisitor = new ParsingTreeVisitor(testData);
            Assert.AreEqual(testAnswer, Double.Parse(testVisitor.Visit(testTree).value));
        }

        [Test]
        public void VariablesIntVarAndIntCorrectTest()
        {
            var testData = new VarAndFuncDictionary();

            testData.AddVariable("a", "int", "7");
            testData.AddVariable("aa", "int", "-1");

            string testExpression = "aa + 10";
            int testAnswer = 9;

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);
            var testVisitor = new ParsingTreeVisitor(testData);
            Assert.AreEqual(testAnswer, Double.Parse(testVisitor.Visit(testTree).value));
        }

        /// <summary>
        /// Incorrect Tests on expressions, which inclide numbers and variables (type "int" only).
        /// 
        /// in these tests:
        /// isCorrectTree = false
        /// testData != null
        /// testData stores information in correct format
        /// all variables are defined
        /// </summary>

        [Test]
        public void VariablesIntWithoutOperationsCrushTest()
        {
            var testData = new VarAndFuncDictionary();

            testData.AddVariable("a", "int", "7");
            testData.AddVariable("aa", "int", "-1");
            testData.AddVariable("b", "int", "-64");
            testData.AddVariable("A", "int", "10");

            string testExpression = "aa b";

            var testExpectedTokens = new List<string>();
            string[] expectedTokens = { "EOF", "", "LPAREN", "RPAREN", "PLUS", "MINUS", "TIMES", "DIV", "AND", "OR", "BOOLEQ", "SEMI" };
            testExpectedTokens.AddRange(expectedTokens);

            (int line, int column) testErrorPosition = (1, 3);
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
        public void VariablesIntAndNumbersWithoutOperationsCrushTest()
        {
            var testData = new VarAndFuncDictionary();

            testData.AddVariable("a", "int", "7");
            testData.AddVariable("a2", "int", "-1");
            testData.AddVariable("b", "int", "-64");
            testData.AddVariable("A", "int", "10");

            string testExpression = "a 2";

            var testExpectedTokens = new List<string>();
            string[] expectedTokens = { "EOF", "", "LPAREN", "RPAREN", "PLUS", "MINUS", "TIMES", "DIV", "AND", "OR", "BOOLEQ", "SEMI" };
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
        public void VariableIntAndOneOperationCrushTest()
        {
            var testData = new VarAndFuncDictionary();

            testData.AddVariable("a", "int", "7");
            testData.AddVariable("a2", "int", "-1");
            testData.AddVariable("b", "int", "-64");
            testData.AddVariable("A", "int", "10");

            string testExpression = "aa *";

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
        public void VariablesIntIncorrectOrderCrushTest()
        {
            var testData = new VarAndFuncDictionary();

            testData.AddVariable("a", "int", "7");
            testData.AddVariable("a2", "int", "-1");
            testData.AddVariable("b", "int", "-64");
            testData.AddVariable("A", "int", "10");

            string testExpression = "aa + a2 a *";

            var testExpectedTokens = new List<string>();
            string[] expectedTokens = { "EOF", "", "LPAREN", "RPAREN", "PLUS", "MINUS", "TIMES", "DIV", "AND", "OR", "BOOLEQ", "SEMI" };
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
        public void VariablesIntNoRightParenCrushTest()
        {
            var testData = new VarAndFuncDictionary();

            testData.AddVariable("a", "int", "7");
            testData.AddVariable("a2", "int", "-1");
            testData.AddVariable("b", "int", "-64");
            testData.AddVariable("A", "int", "10");

            string testExpression = "(a + a2";

            var testExpectedTokens = new List<string>();
            string[] expectedTokens = { "EOF", "", "LPAREN", "RPAREN", "PLUS", "MINUS", "TIMES", "DIV", "AND", "OR", "BOOLEQ", "SEMI" };
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

        [Test]
        public void VariablesIntNoLeftParenCrushTest()
        {
            var testData = new VarAndFuncDictionary();

            testData.AddVariable("a", "int", "7");
            testData.AddVariable("a2", "int", "-1");
            testData.AddVariable("b", "int", "-64");
            testData.AddVariable("A", "int", "10");

            string testExpression = "a + a2 )";

            var testExpectedTokens = new List<string>();
            string[] expectedTokens = { "EOF", "", "LPAREN", "RPAREN", "PLUS", "MINUS", "TIMES", "DIV", "AND", "OR", "BOOLEQ", "SEMI" };
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

        [Test]
        public void VariablesIntMinusBeforeParenAndNoRightParenCrushTest()
        {
            var testData = new VarAndFuncDictionary();

            testData.AddVariable("a", "int", "5");
            testData.AddVariable("a2", "int", "-1");
            testData.AddVariable("b", "int", "3");
            testData.AddVariable("A", "int", "10");

            string testExpression = "- (b - a2";

            var testExpectedTokens = new List<string>();
            string[] expectedTokens = { "EOF", "", "LPAREN", "RPAREN", "PLUS", "MINUS", "TIMES", "DIV", "AND", "OR", "BOOLEQ", "SEMI" };
            testExpectedTokens.AddRange(expectedTokens);

            (int line, int column) testErrorPosition = (1, 9);
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
        public void VariablesIntOperationBeforeParenCrushTest()
        {
            var testData = new VarAndFuncDictionary();

            testData.AddVariable("a", "int", "5");
            testData.AddVariable("a2", "int", "-1");
            testData.AddVariable("b", "int", "3");
            testData.AddVariable("A", "int", "10");

            string testExpression = "+ (b - a2)";

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
        public void VariablesIntMinusAndOperationBeforeParenCrushTest()
        {
            var testData = new VarAndFuncDictionary();

            testData.AddVariable("a", "int", "5");
            testData.AddVariable("a2", "int", "-1");
            testData.AddVariable("b", "int", "3");
            testData.AddVariable("A", "int", "10");

            string testExpression = "- + (b - a2)";

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
        public void VariablesIntTwoOperationsTogetherCrushTest()
        {
            var testData = new VarAndFuncDictionary();

            testData.AddVariable("a", "int", "7");
            testData.AddVariable("a2", "int", "-1");
            testData.AddVariable("b", "int", "-64");
            testData.AddVariable("A", "int", "10");

            string testExpression = "a + / a2";

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
        public void VariablesIntMinusAndPlusTogetherCrushTest()
        {
            var testData = new VarAndFuncDictionary();

            testData.AddVariable("a", "int", "7");
            testData.AddVariable("a2", "int", "-1");
            testData.AddVariable("b", "int", "-64");
            testData.AddVariable("A", "int", "10");

            string testExpression = "a - + a2";

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

        /// <summary>
        /// Exception Tests on expressions, which inclide numbers and variables (type "int" only) WITH ZERO DIVISION.
        /// 
        /// in these tests:
        /// isCorrectTree = true
        /// testData != null
        /// testData stores information in correct format
        /// all variables are defined
        /// 
        /// expected DivideByZeroException
        /// </summary>

        [Test]
        public void VariablesIntZeroDivisionZeroNumberExceptionTest()
        {
            var testData = new VarAndFuncDictionary();

            testData.AddVariable("a", "int", "4");
            testData.AddVariable("aa", "int", "7");
            testData.AddVariable("A", "int", "5");

            string testExpression = "a - aa / 0";

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);
            var testVisitor = new ParsingTreeVisitor(testData);
            Assert.Throws<DivideByZeroException>(() => testVisitor.Visit(testTree));
        }

        [Test]
        public void VariablesIntZeroDivisionZeroVariableExceptionTest()
        {
            var testData = new VarAndFuncDictionary();

            testData.AddVariable("a", "int", "4");
            testData.AddVariable("aa", "int", "7");
            testData.AddVariable("A", "int", "0");

            string testExpression = "a - aa / A";

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);
            var testVisitor = new ParsingTreeVisitor(testData);
            Assert.Throws<DivideByZeroException>(() => testVisitor.Visit(testTree));
        }

        [Test]
        public void VariablesIntZeroDivisionZeroResultInDenominatorExceptionTest()
        {
            var testData = new VarAndFuncDictionary();

            testData.AddVariable("a", "int", "3");
            testData.AddVariable("aa", "int", "5");
            testData.AddVariable("A", "int", "15");

            string testExpression = "42 / (A - a * aa)";

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);
            var testVisitor = new ParsingTreeVisitor(testData);
            Assert.Throws<DivideByZeroException>(() => testVisitor.Visit(testTree));
        }
    }
}