using NUnit.Framework;
using System.Collections.Generic;
using System;
using Antlr4.Runtime.Misc;

namespace myLovelyProject.Tests
{
    class OnlyVariablesBoolOnlyLogicOperationsTests
    {
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// Correct Tests on expressions, which inclide bools and variables (type "bool" only).
        /// 
        /// in these tests:
        /// isCorrectTree = true
        /// testData != null
        /// testData stores information in correct format
        /// all variables are defined
        /// </summary>

        [Test]
        public void OneVariableBoolTrueCorrectTest()
        {
            var testData = new VarAndFuncDictionary();

            testData.AddVariable("a", "bool", "true");
            testData.AddVariable("aa", "bool", "false");
            testData.AddVariable("A", "bool", "false");

            string testExpression = "a";
            bool testAnswer = true;

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);
            var testVisitor = new ParsingTreeVisitor(testData);
            Assert.AreEqual(testAnswer, Boolean.Parse(testVisitor.Visit(testTree).value));
        }

        [Test]
        public void OneVariableBoolFalseCorrectTest()
        {
            var testData = new VarAndFuncDictionary();

            testData.AddVariable("a", "bool", "true");
            testData.AddVariable("aa", "bool", "false");
            testData.AddVariable("A", "bool", "true");

            string testExpression = "aa";
            bool testAnswer = false;

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);
            var testVisitor = new ParsingTreeVisitor(testData);
            Assert.AreEqual(testAnswer, Boolean.Parse(testVisitor.Visit(testTree).value));
        }
        [Test]
        public void VariablesBoolTTDeterminationOfANDCorrectTest()
        {
            var testData = new VarAndFuncDictionary();

            testData.AddVariable("a", "bool", "true");
            testData.AddVariable("aa", "bool", "false");
            testData.AddVariable("b", "bool", "true");
            testData.AddVariable("A", "bool", "false");

            string testExpression = "a && b";
            bool testAnswer = true;

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);
            var testVisitor = new ParsingTreeVisitor(testData);
            Assert.AreEqual(testAnswer, Boolean.Parse(testVisitor.Visit(testTree).value));
        }


        [Test]
        public void VariablesBoolTFDeterminationOfANDCorrectTest()
        {
            var testData = new VarAndFuncDictionary();

            testData.AddVariable("a", "bool", "true");
            testData.AddVariable("aa", "bool", "false");
            testData.AddVariable("b", "bool", "true");
            testData.AddVariable("A", "bool", "false");

            string testExpression = "a && aa";
            bool testAnswer = false;

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);
            var testVisitor = new ParsingTreeVisitor(testData);
            Assert.AreEqual(testAnswer, Boolean.Parse(testVisitor.Visit(testTree).value));
        }

        [Test]
        public void VariablesBoolFFDeterminationOfANDCorrectTest()
        {
            var testData = new VarAndFuncDictionary();

            testData.AddVariable("a", "bool", "true");
            testData.AddVariable("aa", "bool", "false");
            testData.AddVariable("b", "bool", "true");
            testData.AddVariable("A", "bool", "false");

            string testExpression = "aa && A";
            bool testAnswer = false;

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);
            var testVisitor = new ParsingTreeVisitor(testData);
            Assert.AreEqual(testAnswer, Boolean.Parse(testVisitor.Visit(testTree).value));
        }

        [Test]
        public void VariablesBoolTTDeterminationOfORCorrectTest()
        {
            var testData = new VarAndFuncDictionary();

            testData.AddVariable("a", "bool", "true");
            testData.AddVariable("aa", "bool", "false");
            testData.AddVariable("b", "bool", "true");
            testData.AddVariable("A", "bool", "false");

            string testExpression = "a || b";
            bool testAnswer = true;

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);
            var testVisitor = new ParsingTreeVisitor(testData);
            Assert.AreEqual(testAnswer, Boolean.Parse(testVisitor.Visit(testTree).value));
        }

        [Test]
        public void VariablesBoolTFDeterminationOfORCorrectTest()
        {
            var testData = new VarAndFuncDictionary();

            testData.AddVariable("a", "bool", "true");
            testData.AddVariable("aa", "bool", "false");
            testData.AddVariable("b", "bool", "true");
            testData.AddVariable("A", "bool", "false");

            string testExpression = "A || b";
            bool testAnswer = true;

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);
            var testVisitor = new ParsingTreeVisitor(testData);
            Assert.AreEqual(testAnswer, Boolean.Parse(testVisitor.Visit(testTree).value));
        }

        [Test]
        public void VariablesBoolFFDeterminationOfORCorrectTest()
        {
            var testData = new VarAndFuncDictionary();

            testData.AddVariable("a", "bool", "true");
            testData.AddVariable("aa", "bool", "false");
            testData.AddVariable("b", "bool", "true");
            testData.AddVariable("A", "bool", "false");

            string testExpression = "aa || A";
            bool testAnswer = false;

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);
            var testVisitor = new ParsingTreeVisitor(testData);
            Assert.AreEqual(testAnswer, Boolean.Parse(testVisitor.Visit(testTree).value));
        }

        [Test]
        public void VariablesBoolAndBoolWithoutNOTCorrectTest()
        {
            var testData = new VarAndFuncDictionary();

            testData.AddVariable("a", "bool", "true");
            testData.AddVariable("aa", "bool", "false");
            testData.AddVariable("b", "bool", "true");
            testData.AddVariable("A", "bool", "false");

            string testExpression = "false || aa && true";
            bool testAnswer = false;

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);
            var testVisitor = new ParsingTreeVisitor(testData);
            Assert.AreEqual(testAnswer, Boolean.Parse(testVisitor.Visit(testTree).value));
        }

        [Test]
        public void VariablesBoolTwoOperationsWithoutNOTCorrectTest()
        {
            var testData = new VarAndFuncDictionary();

            testData.AddVariable("a", "bool", "true");
            testData.AddVariable("aa", "bool", "false");
            testData.AddVariable("b", "bool", "true");
            testData.AddVariable("A", "bool", "false");

            string testExpression = "aa || a && b";
            bool testAnswer = true;

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);
            var testVisitor = new ParsingTreeVisitor(testData);
            Assert.AreEqual(testAnswer, Boolean.Parse(testVisitor.Visit(testTree).value));
        }


        [Test]
        public void VariablesBoolWithParensCorrectTest()
        {
            var testData = new VarAndFuncDictionary();

            testData.AddVariable("a", "bool", "true");
            testData.AddVariable("aa", "bool", "false");
            testData.AddVariable("b", "bool", "true");
            testData.AddVariable("A", "bool", "false");

            string testExpression = "( aa || a ) && b";
            bool testAnswer = true;

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);
            var testVisitor = new ParsingTreeVisitor(testData);
            Assert.AreEqual(testAnswer, Boolean.Parse(testVisitor.Visit(testTree).value));
        }

        [Test]
        public void OneVariableBoolTrueWithNOTCorrectTest()
        {
            var testData = new VarAndFuncDictionary();

            testData.AddVariable("a", "bool", "true");
            testData.AddVariable("aa", "bool", "false");
            testData.AddVariable("b", "bool", "true");
            testData.AddVariable("A", "bool", "false");

            string testExpression = "!a";
            bool testAnswer = false;

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);
            var testVisitor = new ParsingTreeVisitor(testData);
            Assert.AreEqual(testAnswer, Boolean.Parse(testVisitor.Visit(testTree).value));
        }

        [Test]
        public void OneVariableBoolFalseWithNOTCorrectTest()
        {
            var testData = new VarAndFuncDictionary();

            testData.AddVariable("a", "bool", "true");
            testData.AddVariable("aa", "bool", "false");
            testData.AddVariable("b", "bool", "true");
            testData.AddVariable("A", "bool", "false");

            string testExpression = "! A";
            bool testAnswer = true;

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);
            var testVisitor = new ParsingTreeVisitor(testData);
            Assert.AreEqual(testAnswer, Boolean.Parse(testVisitor.Visit(testTree).value));
        }

        [Test]
        public void VariablesBoolWithNOTafterOperationCorrectTest()
        {
            var testData = new VarAndFuncDictionary();

            testData.AddVariable("a", "bool", "true");
            testData.AddVariable("aa", "bool", "false");
            testData.AddVariable("b", "bool", "true");
            testData.AddVariable("A", "bool", "false");

            string testExpression = "a && !b";
            bool testAnswer = false;

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);
            var testVisitor = new ParsingTreeVisitor(testData);
            Assert.AreEqual(testAnswer, Boolean.Parse(testVisitor.Visit(testTree).value));
        }

        [Test]
        public void VariablesBoolWithFewNOTafterOperationCorrectTest()
        {
            var testData = new VarAndFuncDictionary();

            testData.AddVariable("a", "bool", "true");
            testData.AddVariable("aa", "bool", "false");
            testData.AddVariable("b", "bool", "true");
            testData.AddVariable("A", "bool", "false");

            string testExpression = "a && ! !b";
            bool testAnswer = true;

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);
            var testVisitor = new ParsingTreeVisitor(testData);
            Assert.AreEqual(testAnswer, Boolean.Parse(testVisitor.Visit(testTree).value));
        }

        [Test]
        public void VariablesBoolTTDeterminationOfEQCorrectTest()
        {
            var testData = new VarAndFuncDictionary();

            testData.AddVariable("a", "bool", "true");
            testData.AddVariable("aa", "bool", "false");
            testData.AddVariable("b", "bool", "true");
            testData.AddVariable("A", "bool", "false");

            string testExpression = "a == b";
            bool testAnswer = true;

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);
            var testVisitor = new ParsingTreeVisitor(testData);
            Assert.AreEqual(testAnswer, Boolean.Parse(testVisitor.Visit(testTree).value));
        }

        [Test]
        public void VariablesBoolTFDeterminationOfEQCorrectTest()
        {
            var testData = new VarAndFuncDictionary();

            testData.AddVariable("a", "bool", "true");
            testData.AddVariable("aa", "bool", "false");
            testData.AddVariable("b", "bool", "true");
            testData.AddVariable("A", "bool", "false");

            string testExpression = "aa == a";
            bool testAnswer = false;

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);
            var testVisitor = new ParsingTreeVisitor(testData);
            Assert.AreEqual(testAnswer, Boolean.Parse(testVisitor.Visit(testTree).value));
        }

        [Test]
        public void BoolsFFDeterminationOfEQCorrectTest()
        {
            var testData = new VarAndFuncDictionary();

            testData.AddVariable("a", "bool", "true");
            testData.AddVariable("aa", "bool", "false");
            testData.AddVariable("b", "bool", "true");
            testData.AddVariable("A", "bool", "false");

            string testExpression = "aa == A";
            bool testAnswer = true;

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);
            var testVisitor = new ParsingTreeVisitor(testData);
            Assert.AreEqual(testAnswer, Boolean.Parse(testVisitor.Visit(testTree).value));
        }

        [Test]
        public void VariablesBoolWithEQCorrectTest()
        {
            var testData = new VarAndFuncDictionary();

            testData.AddVariable("a", "bool", "true");
            testData.AddVariable("aa", "bool", "false");
            testData.AddVariable("b", "bool", "true");
            testData.AddVariable("A", "bool", "false");

            string testExpression = "(a && !b) == (A && aa || a)";
            bool testAnswer = false;

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);
            var testVisitor = new ParsingTreeVisitor(testData);
            Assert.AreEqual(testAnswer, Boolean.Parse(testVisitor.Visit(testTree).value));
        }

        [Test]
        public void VariablesBoolWithEQCorrectPriorityOfOperationsCorrectTest()
        {
            var testData = new VarAndFuncDictionary();

            testData.AddVariable("a", "bool", "true");
            testData.AddVariable("aa", "bool", "false");
            testData.AddVariable("b", "bool", "true");
            testData.AddVariable("A", "bool", "false");

            string testExpression = "a && !b == A && aa || a";
            bool testAnswer = true;

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);
            var testVisitor = new ParsingTreeVisitor(testData);
            Assert.AreEqual(testAnswer, Boolean.Parse(testVisitor.Visit(testTree).value));
        }

        [Test]
        public void VariablesBoolNOTBeforeExpressionCorrectTest()
        {
            var testData = new VarAndFuncDictionary();

            testData.AddVariable("a", "bool", "true");
            testData.AddVariable("aa", "bool", "false");
            testData.AddVariable("b", "bool", "true");
            testData.AddVariable("A", "bool", "false");

            string testExpression = "! (a && aa || A)";
            bool testAnswer = true;

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);
            var testVisitor = new ParsingTreeVisitor(testData);
            Assert.AreEqual(testAnswer, Boolean.Parse(testVisitor.Visit(testTree).value));
        }

        [Test]
        public void VariablesBoolTwoNOTBeforeExpressionCorrectTest()
        {
            var testData = new VarAndFuncDictionary();

            testData.AddVariable("a", "bool", "true");
            testData.AddVariable("aa", "bool", "false");
            testData.AddVariable("b", "bool", "true");
            testData.AddVariable("A", "bool", "false");

            string testExpression = "! !(a && A || aa)";
            bool testAnswer = false;

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);
            var testVisitor = new ParsingTreeVisitor(testData);
            Assert.AreEqual(testAnswer, Boolean.Parse(testVisitor.Visit(testTree).value));
        }

        [Test]
        public void VariablesBoolNOTParenNOTParenCorrectTest()
        {
            var testData = new VarAndFuncDictionary();

            testData.AddVariable("a", "bool", "true");
            testData.AddVariable("aa", "bool", "false");
            testData.AddVariable("b", "bool", "true");
            testData.AddVariable("A", "bool", "false");

            string testExpression = "!(!(a))";
            bool testAnswer = true;

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);
            var testVisitor = new ParsingTreeVisitor(testData);
            Assert.AreEqual(testAnswer, Boolean.Parse(testVisitor.Visit(testTree).value));
        }

        [Test]
        public void VariablesBoolVarAndBoolCorrectTest()
        {
            var testData = new VarAndFuncDictionary();

            testData.AddVariable("a", "bool", "true");
            testData.AddVariable("aa", "bool", "false");

            string testExpression = "a == true";
            bool testAnswer = true;

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);
            var testVisitor = new ParsingTreeVisitor(testData);
            Assert.AreEqual(testAnswer, Boolean.Parse(testVisitor.Visit(testTree).value));
        }

        /// <summary>
        /// Incorrect Tests on expressions, which inclide bools and variables (type "bool" only).
        /// 
        /// In these tests:
        /// isCorrectTree = false
        /// testData! = null
        /// testData stores information in correct format
        /// all variables are defined
        /// </summary>

        [Test]
        public void VariablesBoolWithoutOperationsCrushTest()
        {
            var testData = new VarAndFuncDictionary();

            testData.AddVariable("a", "bool", "true");
            testData.AddVariable("aa", "bool", "false");
            testData.AddVariable("b", "bool", "true");
            testData.AddVariable("A", "bool", "false");

            string testExpression = "a aa";

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
        public void OneVariableBoolAndOperationCrushTest()
        {
            var testData = new VarAndFuncDictionary();

            testData.AddVariable("a", "bool", "true");
            testData.AddVariable("aa", "bool", "false");
            testData.AddVariable("b", "bool", "true");
            testData.AddVariable("A", "bool", "false");

            string testExpression = "aa &&";

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
        public void VariablesBoolIncorrectOrderCrushTest()
        {
            var testData = new VarAndFuncDictionary();

            testData.AddVariable("a", "bool", "true");
            testData.AddVariable("aa", "bool", "false");
            testData.AddVariable("b", "bool", "true");
            testData.AddVariable("A", "bool", "false");

            string testExpression = "a || aa b &&";

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
        public void VariablesBoolNoRightParenCrushTest()
        {
            var testData = new VarAndFuncDictionary();

            testData.AddVariable("a", "bool", "true");
            testData.AddVariable("aa", "bool", "false");
            testData.AddVariable("b", "bool", "true");
            testData.AddVariable("A", "bool", "false");

            string testExpression = "( aa && a ";

            var testExpectedTokens = new List<string>();
            string[] expectedTokens = { "EOF", "", "LPAREN", "RPAREN", "PLUS", "MINUS", "TIMES", "DIV", "AND", "OR", "BOOLEQ", "SEMI" };
            testExpectedTokens.AddRange(expectedTokens);

            (int line, int column) testErrorPosition = (1, 10);
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
        public void VariablesBoolNoLeftParenCrushTest()
        {
            var testData = new VarAndFuncDictionary();

            testData.AddVariable("a", "bool", "true");
            testData.AddVariable("aa", "bool", "false");
            testData.AddVariable("b", "bool", "true");
            testData.AddVariable("A", "bool", "false");

            string testExpression = " aa && a) ";

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
        public void VariablesBoolNOTBeforeParenAndNoRightParenCrushTest()
        {
            var testData = new VarAndFuncDictionary();

            testData.AddVariable("a", "bool", "true");
            testData.AddVariable("aa", "bool", "false");
            testData.AddVariable("b", "bool", "true");
            testData.AddVariable("A", "bool", "false");

            string testExpression = "! (aa || a";

            var testExpectedTokens = new List<string>();
            string[] expectedTokens = { "EOF", "", "LPAREN", "RPAREN", "PLUS", "MINUS", "TIMES", "DIV", "AND", "OR", "BOOLEQ", "SEMI" };
            testExpectedTokens.AddRange(expectedTokens);

            (int line, int column) testErrorPosition = (1, 10);
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
        public void VariablesBoolOperationBeforeParenCrushTest()
        {
            var testData = new VarAndFuncDictionary();

            testData.AddVariable("a", "bool", "true");
            testData.AddVariable("aa", "bool", "false");
            testData.AddVariable("b", "bool", "true");
            testData.AddVariable("A", "bool", "false");

            string testExpression = "|| (a && aa)";

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
        public void VariablesBoolNOTAndOperationBeforeParenCrushTest()
        {
            var testData = new VarAndFuncDictionary();

            testData.AddVariable("a", "bool", "true");
            testData.AddVariable("aa", "bool", "false");
            testData.AddVariable("b", "bool", "true");
            testData.AddVariable("A", "bool", "false");

            string testExpression = "! == (aa || b)";

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
        public void VariablesBoolTwoOperationsTogetherCrushTest()
        {
            var testData = new VarAndFuncDictionary();

            testData.AddVariable("a", "bool", "true");
            testData.AddVariable("aa", "bool", "false");
            testData.AddVariable("b", "bool", "true");
            testData.AddVariable("A", "bool", "false");

            string testExpression = "a || && aa";

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
        public void VariablesBoolNOTAndOperationTogetherCrushTest()
        {
            var testData = new VarAndFuncDictionary();

            testData.AddVariable("a", "bool", "true");
            testData.AddVariable("aa", "bool", "false");
            testData.AddVariable("b", "bool", "true");
            testData.AddVariable("A", "bool", "false");

            string testExpression = " aa ! || A";

            var testExpectedTokens = new List<string>();
            string[] expectedTokens = { "EOF", "", "LPAREN", "RPAREN", "PLUS", "MINUS", "TIMES", "DIV", "AND", "OR", "BOOLEQ", "SEMI" };
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
    }
}
