using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace myLovelyProject.Tests
{
    class OnlyVariablesBoolFunctionsTests
    {

        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// Correct Tests on expressions, which inclide varibales (type "bool" only) and functions.
        /// 
        /// in these tests:
        /// isCorrectTree = true
        /// testData != null
        /// testData stores information in correct format
        /// all functions are defined
        /// </summary>

        [Test]
        public void OneFunctionCorrectTest()
        {
            var testData = new VarAndFuncDictionary();

            var testTypesList = new List<String>();
            testTypesList.Add("bool");
            testData.AddFunction("identy", testTypesList, "bool", listIn => SpecialFunctionsForTest.BoolToString(Boolean.Parse(listIn[0])));

            testData.AddVariable("a", "bool", "true");
            testData.AddVariable("b", "bool", "false");

            string testExpression = "identy(a)";

            bool testAnswer = true;
            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(testData);

            Assert.AreEqual(testAnswer, Boolean.Parse(testVisitor.Visit(testTree).value));
        }

        [Test]
        public void OneFunctionNOTCorrectTest()
        {
            var testData = new VarAndFuncDictionary();

            var testTypesList = new List<String>();
            testTypesList.Add("bool");
            testData.AddFunction("identy", testTypesList, "bool", listIn => SpecialFunctionsForTest.BoolToString(Boolean.Parse(listIn[0])));

            testData.AddVariable("a", "bool", "true");
            testData.AddVariable("b", "bool", "false");

            string testExpression = "!identy(a)";

            bool testAnswer = false;
            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(testData);

            Assert.AreEqual(testAnswer, Boolean.Parse(testVisitor.Visit(testTree).value));
        }

        [Test]
        public void OneFunctionParenCorrectTest()
        {
            var testData = new VarAndFuncDictionary();

            var testTypesList = new List<String>();
            testTypesList.Add("bool");
            testData.AddFunction("identy", testTypesList, "bool", listIn => SpecialFunctionsForTest.BoolToString(Boolean.Parse(listIn[0])));

            testData.AddVariable("a", "bool", "true");
            testData.AddVariable("b", "bool", "false");

            string testExpression = "(identy(a))";

            bool testAnswer = true;
            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(testData);

            Assert.AreEqual(testAnswer, Boolean.Parse(testVisitor.Visit(testTree).value));
        }

        [Test]
        public void OneFunctionNOTParenCorrectTest()
        {
            var testData = new VarAndFuncDictionary();

            var testTypesList = new List<String>();
            testTypesList.Add("bool");
            testData.AddFunction("identy", testTypesList, "bool", listIn => SpecialFunctionsForTest.BoolToString(Boolean.Parse(listIn[0])));

            testData.AddVariable("a", "bool", "true");
            testData.AddVariable("b", "bool", "false");

            string testExpression = "!(identy(a))";

            bool testAnswer = false;
            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(testData);

            Assert.AreEqual(testAnswer, Boolean.Parse(testVisitor.Visit(testTree).value));
        }

        [Test]
        public void OneFunctionAndBoolCorrectTest()
        {
            var testData = new VarAndFuncDictionary();

            var testTypesList = new List<String>();
            testTypesList.Add("bool");
            testData.AddFunction("identy", testTypesList, "bool", listIn => SpecialFunctionsForTest.BoolToString(Boolean.Parse(listIn[0])));

            testData.AddVariable("a", "bool", "true");
            testData.AddVariable("b", "bool", "false");

            string testExpression = "identy(a) && false";

            bool testAnswer = false;
            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(testData);

            Assert.AreEqual(testAnswer, Boolean.Parse(testVisitor.Visit(testTree).value));
        }

        [Test]
        public void FunctionsExprOpExprCorrectTest()
        {
            var testData = new VarAndFuncDictionary();

            var testTypesList1 = new List<String>();
            testTypesList1.Add("bool");
            testData.AddFunction("identy", testTypesList1, "bool", listIn => SpecialFunctionsForTest.BoolToString(Boolean.Parse(listIn[0])));

            var testTypesList2 = new List<String>();
            testTypesList2.Add("bool");
            testData.AddFunction("iridenty", testTypesList2, "bool", listIn => SpecialFunctionsForTest.BoolToString(!Boolean.Parse(listIn[0])));

            testData.AddVariable("a", "bool", "true");
            testData.AddVariable("b", "bool", "true");

            string testExpression = "identy(a) && iridenty(b)";

            bool testAnswer = false;
            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(testData);

            Assert.AreEqual(testAnswer, Boolean.Parse(testVisitor.Visit(testTree).value));
        }

        [Test]
        public void FunctionsParenCorrectTest()
        {
            var testData = new VarAndFuncDictionary();

            var testTypesList1 = new List<String>();
            testTypesList1.Add("bool");
            testData.AddFunction("identy", testTypesList1, "bool", listIn => SpecialFunctionsForTest.BoolToString(Boolean.Parse(listIn[0])));

            var testTypesList2 = new List<String>();
            testTypesList2.Add("bool");
            testData.AddFunction("iridenty", testTypesList2, "bool", listIn => SpecialFunctionsForTest.BoolToString(!Boolean.Parse(listIn[0])));

            testData.AddVariable("a", "bool", "true");
            testData.AddVariable("b", "bool", "true");

            string testExpression = "identy(a) && (iridenty(a) || identy(b))";

            bool testAnswer = true;
            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(testData);

            Assert.AreEqual(testAnswer, Boolean.Parse(testVisitor.Visit(testTree).value));
        }

        [Test]
        public void OneFunctionNegativeParameterCorrectTest()
        {
            var testData = new VarAndFuncDictionary();

            var testTypesList1 = new List<String>();
            testTypesList1.Add("bool");
            testData.AddFunction("identy", testTypesList1, "bool", listIn => SpecialFunctionsForTest.BoolToString(Boolean.Parse(listIn[0])));

            testData.AddVariable("a", "bool", "true");
            testData.AddVariable("b", "bool", "false");

            string testExpression = "identy(! a)";

            bool testAnswer = false;
            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(testData);

            Assert.AreEqual(testAnswer, Boolean.Parse(testVisitor.Visit(testTree).value));
        }

        [Test]
        public void OneFunctionExpressionParameterCorrectTest()
        {
            var testData = new VarAndFuncDictionary();

            var testTypesList1 = new List<String>();
            testTypesList1.Add("bool");
            testData.AddFunction("identy", testTypesList1, "bool", listIn => SpecialFunctionsForTest.BoolToString(Boolean.Parse(listIn[0])));

            testData.AddVariable("a", "bool", "true");
            testData.AddVariable("b", "bool", "false");

            string testExpression = "identy(a && b)";

            bool testAnswer = false;
            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(testData);

            Assert.AreEqual(testAnswer, Boolean.Parse(testVisitor.Visit(testTree).value));
        }

        [Test]
        public void OneFunctionExpressionInParenParameterCorrectTest()
        {
            var testData = new VarAndFuncDictionary();

            var testTypesList1 = new List<String>();
            testTypesList1.Add("bool");
            testData.AddFunction("identy", testTypesList1, "bool", listIn => SpecialFunctionsForTest.BoolToString(Boolean.Parse(listIn[0])));

            testData.AddVariable("a", "bool", "true");
            testData.AddVariable("b", "bool", "false");

            string testExpression = "identy((b && a))";

            bool testAnswer = false;
            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(testData);

            Assert.AreEqual(testAnswer, Boolean.Parse(testVisitor.Visit(testTree).value));
        }

        [Test]
        public void OneFunctionExpressionInParenWithMinusParameterCorrectTest()
        {
            var testData = new VarAndFuncDictionary();

            var testTypesList1 = new List<String>();
            testTypesList1.Add("bool");
            testData.AddFunction("identy", testTypesList1, "bool", listIn => SpecialFunctionsForTest.BoolToString(Boolean.Parse(listIn[0])));

            testData.AddVariable("a", "bool", "true");
            testData.AddVariable("b", "bool", "false");

            string testExpression = "identy( ! (b && a))";

            bool testAnswer = true;
            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(testData);

            Assert.AreEqual(testAnswer, Boolean.Parse(testVisitor.Visit(testTree).value));
        }

        [Test]
        public void OneFunctionExpressionsParametersCorrectTest()
        {
            var testData = new VarAndFuncDictionary();

            var testTypesList1 = new List<String>();
            testTypesList1.Add("bool"); testTypesList1.Add("bool");
            testData.AddFunction("or", testTypesList1, "bool", listIn => SpecialFunctionsForTest.BoolToString(Boolean.Parse(listIn[0]) || Boolean.Parse(listIn[1])));

            testData.AddVariable("a", "bool", "true");
            testData.AddVariable("b", "bool", "false");
            testData.AddVariable("c", "bool", "false");
            testData.AddVariable("d", "bool", "false");

            string testExpression = "or(a || b, c && d)";

            bool testAnswer = true;
            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(testData);

            Assert.AreEqual(testAnswer, Boolean.Parse(testVisitor.Visit(testTree).value));
        }

        [Test]
        public void FunctionFunctionParameterCorrectTest()
        {
            var testData = new VarAndFuncDictionary();

            var testTypesList1 = new List<String>();
            testTypesList1.Add("bool");
            testData.AddFunction("identy", testTypesList1, "bool", listIn => SpecialFunctionsForTest.BoolToString(Boolean.Parse(listIn[0])));

            var testTypesList2 = new List<String>();
            testTypesList2.Add("bool"); testTypesList2.Add("bool");
            testData.AddFunction("or", testTypesList2, "bool", listIn => SpecialFunctionsForTest.BoolToString(Boolean.Parse(listIn[0]) || Boolean.Parse(listIn[1])));

            testData.AddVariable("a", "bool", "true");
            testData.AddVariable("b", "bool", "false");

            string testExpression = "identy(or(a, b))";

            bool testAnswer = true;
            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(testData);

            Assert.AreEqual(testAnswer, Boolean.Parse(testVisitor.Visit(testTree).value));
        }

        [Test]
        public void FunctionFunctionsParametersCorrectTest()
        {
            var testData = new VarAndFuncDictionary();

            var testTypesList1 = new List<String>();
            testTypesList1.Add("bool");
            testData.AddFunction("identy", testTypesList1, "bool", listIn => SpecialFunctionsForTest.BoolToString(Boolean.Parse(listIn[0])));

            var testTypesList2 = new List<String>();
            testTypesList2.Add("bool"); testTypesList2.Add("bool");
            testData.AddFunction("or", testTypesList2, "bool", listIn => SpecialFunctionsForTest.BoolToString(Boolean.Parse(listIn[0]) || Boolean.Parse(listIn[1])));

            testData.AddVariable("a", "bool", "true");
            testData.AddVariable("b", "bool", "false");

            string testExpression = "or(identy(b), identy(a))";

            bool testAnswer = true;
            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(testData);

            Assert.AreEqual(testAnswer, Boolean.Parse(testVisitor.Visit(testTree).value));
        }
    }
}
