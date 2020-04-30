using System;
using System.Collections.Generic;
using NUnit.Framework;
using Antlr4.Runtime.Misc;

namespace myLovelyProject.Tests
{
    class FunctionCasesIndependentFromTypesTests
    {
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// InCorrect Tests on expressions, which inclide numbers and functions.
        /// 
        /// in these tests:
        /// isCorrectTree = false
        /// testData != null
        /// testData stores information in correct format
        /// all functions are defined
        /// </summary>

        [Test]
        public void FunctionNoParenCrushTest()
        {
            var testData = new VarAndFuncDictionary();

            var testTypesList1 = new List<String>();
            testTypesList1.Add("int");
            testData.AddFunction("negative", testTypesList1, "int", listIn => (-Double.Parse(listIn[0])).ToString());

            string testExpression = "negative(";

            var testExpectedTokens = new List<string>();
            string[] expectedTokens = { "TRUE", "FALSE", "NAMEIDENTIFIER", "INT", "DOUBLE", "LPAREN", "RPAREN", "MINUS", "NOT" };
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
        public void FunctionLeftParenInParensCrushTest()
        {
            var testData = new VarAndFuncDictionary();

            var testTypesList1 = new List<String>();
            testTypesList1.Add("int");
            testData.AddFunction("negative", testTypesList1, "int", listIn => (-Double.Parse(listIn[0])).ToString());

            string testExpression = "negative(()";

            var testExpectedTokens = new List<string>();
            string[] expectedTokens = { "TRUE", "FALSE", "NAMEIDENTIFIER", "INT", "DOUBLE", "LPAREN", "MINUS", "NOT" };
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
        public void FunctionNoParamsButCommaCrushTest()
        {
            var testData = new VarAndFuncDictionary();

            var testTypesList1 = new List<String>();
            testTypesList1.Add("int"); testTypesList1.Add("int");
            testData.AddFunction("summ", testTypesList1, "int", listIn => (Double.Parse(listIn[0]) + Double.Parse(listIn[1])).ToString());

            string testExpression = "summ(,)";

            var testExpectedTokens = new List<string>();
            string[] expectedTokens = { "TRUE", "FALSE", "NAMEIDENTIFIER", "INT", "DOUBLE", "LPAREN", "RPAREN", "MINUS", "NOT" };
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
        public void FunctionParamsNoRightParenCrushTest()
        {
            var testData = new VarAndFuncDictionary();

            var testTypesList1 = new List<String>();
            testTypesList1.Add("int"); testTypesList1.Add("int");
            testData.AddFunction("summ", testTypesList1, "int", listIn => (Double.Parse(listIn[0]) + Double.Parse(listIn[1])).ToString());

            string testExpression = "summ(7, 9";

            var testExpectedTokens = new List<string>();
            string[] expectedTokens = { "EOF", "", "RPAREN", "PLUS", "MINUS", "TIMES", "DIV", "AND", "OR", "BOOLEQ", "SEMI" };
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

        /// <summary>
        /// InCorrect Tests on expressions, which inclide numbers and functions.
        /// 
        /// in these tests:
        /// isCorrectTree = false
        /// testData != null
        /// testData stores information in correct format
        /// function has name the same with keywords 'true' and 'false'
        /// </summary>
        
        [Test]
        public void FunctionTrueNameCrushTest()
        {
            var testData = new VarAndFuncDictionary();

            var testTypesList1 = new List<String>();
            testTypesList1.Add("int");
            testData.AddFunction("true", testTypesList1, "int", listIn => (Double.Parse(listIn[0])).ToString());

            string testExpression = "true(5)";

            var testExpectedTokens = new List<string>();
            string[] expectedTokens = { "EOF", "", "RPAREN", "PLUS", "MINUS", "TIMES", "DIV", "AND", "OR", "BOOLEQ", "SEMI" };
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
        public void FunctionFalseNameCrushTest()
        {
            var testData = new VarAndFuncDictionary();

            var testTypesList1 = new List<String>();
            testTypesList1.Add("int");
            testData.AddFunction("false", testTypesList1, "int", listIn => (-Double.Parse(listIn[0])).ToString());

            string testExpression = "false(2)";

            var testExpectedTokens = new List<string>();
            string[] expectedTokens = { "EOF", "","RPAREN", "PLUS", "MINUS", "TIMES", "DIV", "AND", "OR", "BOOLEQ", "SEMI" };
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
        /// Exception Tests on expressions, which inclide numbers and functions.
        /// 
        /// in these tests:
        /// isCorrectTree = true
        /// testData != null
        /// testData stores information in correct format
        /// all functions are defined
        /// incorrect count of parameters in function call in expression
        /// 
        /// expected exception ArgumentOutOfRangeException
        /// </summary>

        [Test]
        public void OneFunctionNotEnoughParametersExceptionTest()
        {
            var testData = new VarAndFuncDictionary();

            var testTypesList = new List<String>();
            testTypesList.Add("int"); testTypesList.Add("int");
            testData.AddFunction("summ", testTypesList, "int", listIn => (Double.Parse(listIn[0]) + Double.Parse(listIn[1])).ToString());

            string testExpression = "summ(46)";

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(testData);

            Assert.Throws<ArgumentOutOfRangeException>(() => testVisitor.Visit(testTree));
        }

        [Test]
        public void OneFunctionNoParamNotEnoughExceptionTest()
        {
            var testData = new VarAndFuncDictionary();

            var testTypesList = new List<String>();
            testTypesList.Add("int"); testTypesList.Add("int");
            testData.AddFunction("summ", testTypesList, "int", listIn => (Double.Parse(listIn[0]) + Double.Parse(listIn[1])).ToString());

            string testExpression = "summ()";

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(testData);

            Assert.Throws<ArgumentOutOfRangeException>(() => testVisitor.Visit(testTree));
        }

        [Test]
        public void OneFunctionTooMuchParametersExceptionTest()
        {
            var testData = new VarAndFuncDictionary();

            var testTypesList = new List<String>();
            testTypesList.Add("int"); testTypesList.Add("int");
            testData.AddFunction("summ", testTypesList, "int", listIn => (Double.Parse(listIn[0]) + Double.Parse(listIn[1])).ToString());

            string testExpression = "summ(4, 6, 8)";

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(testData);

            Assert.Throws<ArgumentOutOfRangeException>(() => testVisitor.Visit(testTree));
        }

        [Test]
        public void OneFunctionTooMuchParametersNoParamFuncExceptionTest()
        {
            var testData = new VarAndFuncDictionary();

            testData.AddFunction("return10", null, "int", listIn => "10");

            string testExpression = "return10(8)";

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(testData);

            Assert.Throws<ArgumentOutOfRangeException>(() => testVisitor.Visit(testTree));
        }

        
    }
}
