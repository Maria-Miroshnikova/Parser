using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace myLovelyProject.Tests
{
    class OnlyNumbersFunctionsTests
    {
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// Correct Tests on expressions, which inclide numbers and functions.
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
            testTypesList.Add("int"); testTypesList.Add("int");
            testData.AddFunction("summ", testTypesList, "int", listIn => (Double.Parse(listIn[0]) + Double.Parse(listIn[1])).ToString());

            string testExpression = "summ(4, 6)";

            double testAnswer = 10;
            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(testData);

            Assert.AreEqual(testAnswer, Double.Parse(testVisitor.Visit(testTree).value));
        }

        [Test]
        public void OneFunctionMinusCorrectTest()
        {
            var testData = new VarAndFuncDictionary();

            var testTypesList = new List<String>();
            testTypesList.Add("int"); testTypesList.Add("int");
            testData.AddFunction("summ", testTypesList, "int", listIn => (Double.Parse(listIn[0]) + Double.Parse(listIn[1])).ToString());

            string testExpression = "-summ(4, 6)";

            double testAnswer = -10;
            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(testData);

            Assert.AreEqual(testAnswer, Double.Parse(testVisitor.Visit(testTree).value));
        }

        [Test]
        public void OneFunctionParenCorrectTest()
        {
            var testData = new VarAndFuncDictionary();

            var testTypesList = new List<String>();
            testTypesList.Add("int"); testTypesList.Add("int");
            testData.AddFunction("summ", testTypesList, "int", listIn => (Double.Parse(listIn[0]) + Double.Parse(listIn[1])).ToString());

            string testExpression = "(summ(4, 6))";

            double testAnswer = 10;
            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(testData);

            Assert.AreEqual(testAnswer, Double.Parse(testVisitor.Visit(testTree).value));
        }

        [Test]
        public void OneFunctionMinusParenCorrectTest()
        {
            var testData = new VarAndFuncDictionary();

            var testTypesList = new List<String>();
            testTypesList.Add("int"); testTypesList.Add("int");
            testData.AddFunction("summ", testTypesList, "int", listIn => (Double.Parse(listIn[0]) + Double.Parse(listIn[1])).ToString());

            string testExpression = "-(summ(4, 6))";

            double testAnswer = -10;
            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(testData);

            Assert.AreEqual(testAnswer, Double.Parse(testVisitor.Visit(testTree).value));
        }

        [Test]
        public void NumberAndOneFunctionCorrectTest()
        {
            var testData = new VarAndFuncDictionary();

            var testTypesList = new List<String>();
            testTypesList.Add("int"); testTypesList.Add("int");
            testData.AddFunction("summ", testTypesList, "int", listIn => (Double.Parse(listIn[0]) + Double.Parse(listIn[1])).ToString());

            string testExpression = "summ(4, 6) + 3";

            double testAnswer = 13;
            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(testData);

            Assert.AreEqual(testAnswer, Double.Parse(testVisitor.Visit(testTree).value));
        }

        [Test]
        public void FunctionsExprOpExprCorrectTest()
        {
            var testData = new VarAndFuncDictionary();

            var testTypesList1 = new List<String>();
            testTypesList1.Add("int"); testTypesList1.Add("int");
            testData.AddFunction("summ", testTypesList1, "int", listIn => (Double.Parse(listIn[0]) + Double.Parse(listIn[1])).ToString());

            var testTypesList2 = new List<String>();
            testTypesList2.Add("int");
            testData.AddFunction("times10", testTypesList2, "int", listIn => (Double.Parse(listIn[0]) * 10).ToString());

            string testExpression = "summ(4, 36) / times10(2)";

            double testAnswer = 2;
            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(testData);

            Assert.AreEqual(testAnswer, Double.Parse(testVisitor.Visit(testTree).value));
        }

        [Test]
        public void FunctionsParenCorrectTest()
        {
            var testData = new VarAndFuncDictionary();

            var testTypesList1 = new List<String>();
            testTypesList1.Add("int"); testTypesList1.Add("int");
            testData.AddFunction("summ", testTypesList1, "int", listIn => (Double.Parse(listIn[0]) + Double.Parse(listIn[1])).ToString());

            var testTypesList2 = new List<String>();
            testTypesList2.Add("int");
            testData.AddFunction("times10", testTypesList2, "int", listIn => (Double.Parse(listIn[0]) * 10).ToString());

            string testExpression = "summ(4, 3) * (times10(1) - 4)";

            double testAnswer = 42;
            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(testData);

            Assert.AreEqual(testAnswer, Double.Parse(testVisitor.Visit(testTree).value));
        }

        [Test]
        public void OneFunctionNoParametersCorrectTest()
        {
            var testData = new VarAndFuncDictionary();

            testData.AddFunction("return10", null, "int", list => "10");

            string testExpression = "return10()";

            double testAnswer = 10;
            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(testData);

            Assert.AreEqual(testAnswer, Double.Parse(testVisitor.Visit(testTree).value));
        }

        [Test]
        public void OneFunctionNegativeParameterCorrectTest()
        {
            var testData = new VarAndFuncDictionary();

            var testTypesList = new List<String>();
            testTypesList.Add("int");
            testData.AddFunction("negative", testTypesList, "int", listIn => (-Double.Parse(listIn[0])).ToString());

            string testExpression = "negative(-5)";

            double testAnswer = 5;
            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(testData);

            Assert.AreEqual(testAnswer, Double.Parse(testVisitor.Visit(testTree).value));
        }

        [Test]
        public void OneFunctionExpressionParameterCorrectTest()
        {
            var testData = new VarAndFuncDictionary();

            var testTypesList = new List<String>();
            testTypesList.Add("int");
            testData.AddFunction("negative", testTypesList, "int", listIn => (-Double.Parse(listIn[0])).ToString());

            string testExpression = "negative(5 + 3)";

            double testAnswer = -8;
            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(testData);

            Assert.AreEqual(testAnswer, Double.Parse(testVisitor.Visit(testTree).value));
        }

        [Test]
        public void OneFunctionExpressionInParenParameterCorrectTest()
        {
            var testData = new VarAndFuncDictionary();

            var testTypesList = new List<String>();
            testTypesList.Add("int");
            testData.AddFunction("negative", testTypesList, "int", listIn => (-Double.Parse(listIn[0])).ToString());

            string testExpression = "negative((5 + 3))";

            double testAnswer = -8;
            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(testData);

            Assert.AreEqual(testAnswer, Double.Parse(testVisitor.Visit(testTree).value));
        }

        [Test]
        public void OneFunctionExpressionInParenWithMinusParameterCorrectTest()
        {
            var testData = new VarAndFuncDictionary();

            var testTypesList = new List<String>();
            testTypesList.Add("int");
            testData.AddFunction("negative", testTypesList, "int", listIn => (-Double.Parse(listIn[0])).ToString());

            string testExpression = "negative(-(5 + 3))";

            double testAnswer = 8;
            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(testData);

            Assert.AreEqual(testAnswer, Double.Parse(testVisitor.Visit(testTree).value));
        }

        [Test]
        public void OneFunctionExpressionsParametersCorrectTest()
        {
            var testData = new VarAndFuncDictionary();

            var testTypesList = new List<String>();
            testTypesList.Add("int"); testTypesList.Add("int");
            testData.AddFunction("summ", testTypesList, "int", listIn => (Double.Parse(listIn[0]) + Double.Parse(listIn[1])).ToString());

            string testExpression = "summ(2 * 4, 16 / 4)";

            double testAnswer = 12;
            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(testData);

            Assert.AreEqual(testAnswer, Double.Parse(testVisitor.Visit(testTree).value));
        }

        [Test]
        public void FunctionsFunctionParameterCorrectTest()
        {
            var testData = new VarAndFuncDictionary();

            var testTypesList = new List<String>();
            testTypesList.Add("int");
            testData.AddFunction("negative", testTypesList, "int", listIn => (-Double.Parse(listIn[0])).ToString());

            string testExpression = "negative(negative(5))";

            double testAnswer = 5;
            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(testData);

            Assert.AreEqual(testAnswer, Double.Parse(testVisitor.Visit(testTree).value));
        }

        [Test]
        public void FunctionsFunctionsParametersCorrectTest()
        {
            var testData = new VarAndFuncDictionary();

            var testTypesList1 = new List<String>();
            testTypesList1.Add("int");
            testData.AddFunction("negative", testTypesList1, "int", listIn => (-Double.Parse(listIn[0])).ToString());

            var testTypesList2 = new List<String>();
            testTypesList2.Add("int"); testTypesList2.Add("int");
            testData.AddFunction("summ", testTypesList2, "int", listIn => (Double.Parse(listIn[0]) + Double.Parse(listIn[1])).ToString());


            string testExpression = "summ(negative(5), negative(-3))";

            double testAnswer = -2;
            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(testData);

            Assert.AreEqual(testAnswer, Double.Parse(testVisitor.Visit(testTree).value));
        }
    }
}
