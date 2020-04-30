using System;
using System.Collections.Generic;
using NUnit.Framework;
using System.Globalization;
using NUnit.Framework.Internal;

namespace myLovelyProject.Tests
{
    class TypeFunctionParameterTests
    {
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// Correct Tests on expressions, which include functions with correct types of parameters:
        /// expected double but got int.
        /// 
        /// in these tests:
        /// isCorrectTree = true
        /// testData != null
        /// testData stores information in correct format
        /// all functions are defined
        /// </summary>

        [Test]
        public void FunctionParamDoubleButIntCorrectTest()
        {
            var testData = new VarAndFuncDictionary();

            var testTypesList = new List<String>();
            testTypesList.Add("double"); testTypesList.Add("double");
            testData.AddFunction("summ", testTypesList, "double", listIn => (Double.Parse(listIn[0], CultureInfo.InvariantCulture) + Double.Parse(listIn[1], CultureInfo.InvariantCulture)).ToString());

            string testExpression = "summ(4, 5.1)";

            double testAnswer = 9.1;
            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(testData);

            Assert.IsTrue(SpecialFunctionsForTest.AreEqualDouble(testAnswer, testVisitor.Visit(testTree).value));
        }

        [Test]
        public void FunctionParamDoubleButIntExpressionCorrectTest()
        {
            var testData = new VarAndFuncDictionary();

            var testTypesList = new List<String>();
            testTypesList.Add("double"); testTypesList.Add("double");
            testData.AddFunction("summ", testTypesList, "double", listIn => (Double.Parse(listIn[0], CultureInfo.InvariantCulture) + Double.Parse(listIn[1], CultureInfo.InvariantCulture)).ToString());

            string testExpression = "summ(4 + 3, 5.1)";

            double testAnswer = 12.1;
            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(testData);

            Assert.IsTrue(SpecialFunctionsForTest.AreEqualDouble(testAnswer, testVisitor.Visit(testTree).value));
        }

        [Test]
        public void FunctionParamDoubleButIntFunctionCorrectTest()
        {
            var testData = new VarAndFuncDictionary();

            var testTypesList1 = new List<String>();
            testTypesList1.Add("int");
            testData.AddFunction("negative", testTypesList1, "int", listIn => (-Double.Parse(listIn[0])).ToString());

            var testTypesList2 = new List<String>();
            testTypesList2.Add("double"); testTypesList2.Add("double");
            testData.AddFunction("summ", testTypesList2, "double", listIn => (Double.Parse(listIn[0], CultureInfo.InvariantCulture) + Double.Parse(listIn[1], CultureInfo.InvariantCulture)).ToString());

            string testExpression = "summ(4.4, negative(6))";

            double testAnswer = -1.6;
            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(testData);

            Assert.IsTrue(SpecialFunctionsForTest.AreEqualDouble(testAnswer, testVisitor.Visit(testTree).value));
        }

        [Test]
        public void FunctionParamDoubleButIntVariableCorrectTest()
        {
            var testData = new VarAndFuncDictionary();

            var testTypesList = new List<String>();
            testTypesList.Add("double"); testTypesList.Add("double");
            testData.AddFunction("summ", testTypesList, "double", listIn => (Double.Parse(listIn[0], CultureInfo.InvariantCulture) + Double.Parse(listIn[1], CultureInfo.InvariantCulture)).ToString());

            testData.AddVariable("a", "int", "5");

            string testExpression = "summ(a, 5.09)";

            double testAnswer = 10.09;
            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(testData);

            Assert.IsTrue(SpecialFunctionsForTest.AreEqualDouble(testAnswer, testVisitor.Visit(testTree).value));
        }

        /// <summary>
        /// Exception Tests on expressions, which inclide functions with wrong types of parameters:
        /// expected int but got double.
        /// 
        /// in these tests:
        /// isCorrectTree = true
        /// testData != null
        /// testData stores information in correct format
        /// all functions are defined
        /// incorrect types of parameters in function call in expression
        /// 
        /// expected exception ArgumentOutOfRangeException
        /// </summary>

        [Test]
        public void FunctionWrongParamIntButDoubleExceptionTest()
        {
            var testData = new VarAndFuncDictionary();

            var testTypesList = new List<String>();
            testTypesList.Add("int");
            testData.AddFunction("negative", testTypesList, "int", listIn => (-Double.Parse(listIn[0])).ToString());

            string testExpression = "negative(5.3)";

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(testData);

            Assert.Throws<ArgumentOutOfRangeException>(() => testVisitor.Visit(testTree));
        }

        [Test]
        public void FunctionWrongParamIntButDoubleZeroExceptionTest()
        {
            var testData = new VarAndFuncDictionary();

            var testTypesList = new List<String>();
            testTypesList.Add("int");
            testData.AddFunction("negative", testTypesList, "int", listIn => (-Double.Parse(listIn[0])).ToString());

            string testExpression = "negative(5.0)";

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(testData);

            Assert.Throws<ArgumentOutOfRangeException>(() => testVisitor.Visit(testTree));
        }

        [Test]
        public void FunctionWrongOneParamIntButDoubleExceptionTest()
        {
            var testData = new VarAndFuncDictionary();

            var testTypesList = new List<String>();
            testTypesList.Add("int"); testTypesList.Add("int");
            testData.AddFunction("summ", testTypesList, "int", listIn => (Double.Parse(listIn[0]) + Double.Parse(listIn[1])).ToString());

            string testExpression = "summ(5, 5.3)";

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(testData);

            Assert.Throws<ArgumentOutOfRangeException>(() => testVisitor.Visit(testTree));
        }

        [Test]
        public void FunctionWrongParamIntButDoubleExprZeroExceptionTest()
        {
            var testData = new VarAndFuncDictionary();

            var testTypesList = new List<String>();
            testTypesList.Add("int"); testTypesList.Add("int");
            testData.AddFunction("summ", testTypesList, "int", listIn => (Double.Parse(listIn[0]) + Double.Parse(listIn[1])).ToString());

            string testExpression = "summ(5, 2 + 5.0)";

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(testData);

            Assert.Throws<ArgumentOutOfRangeException>(() => testVisitor.Visit(testTree));
        }

        [Test]
        public void FunctionWrongParamIntButDoubleFuncExceptionTest()
        {
            var testData = new VarAndFuncDictionary();

            var testTypesList1 = new List<String>();
            testTypesList1.Add("int"); testTypesList1.Add("int");
            testData.AddFunction("summ", testTypesList1, "int", listIn => (Double.Parse(listIn[0]) + Double.Parse(listIn[1])).ToString());

            var testTypesList2 = new List<String>();
            testTypesList2.Add("double");
            testData.AddFunction("negative", testTypesList2, "double", listIn => (-Double.Parse(listIn[0], CultureInfo.InvariantCulture)).ToString());

            string testExpression = "summ(5, negative(1.2))";

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(testData);

            Assert.Throws<ArgumentOutOfRangeException>(() => testVisitor.Visit(testTree));
        }

        [Test]
        public void FunctionWrongParamIntButDoubleVariableExceptionTest()
        {
            var testData = new VarAndFuncDictionary();

            var testTypesList = new List<String>();
            testTypesList.Add("int"); testTypesList.Add("int");
            testData.AddFunction("summ", testTypesList, "int", listIn => (Double.Parse(listIn[0]) + Double.Parse(listIn[1])).ToString());

            testData.AddVariable("a", "double", "5.1");

            string testExpression = "summ(5, a)";

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(testData);

            Assert.Throws<ArgumentOutOfRangeException>(() => testVisitor.Visit(testTree));
        }

        [Test]
        public void FunctionWrongParamIntButDoubleVariableLooksLikeIntExceptionTest()
        {
            var testData = new VarAndFuncDictionary();

            var testTypesList = new List<String>();
            testTypesList.Add("int"); testTypesList.Add("int");
            testData.AddFunction("summ", testTypesList, "int", listIn => (Double.Parse(listIn[0]) + Double.Parse(listIn[1])).ToString());

            testData.AddVariable("a", "double", "6");

            string testExpression = "summ(5, a)";

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(testData);

            Assert.Throws<ArgumentOutOfRangeException>(() => testVisitor.Visit(testTree));
        }

        /// <summary>
        /// Exception Tests on expressions, which inclide functions with wrong types of parameters:
        /// expected int but got bool.
        /// 
        /// in these tests:
        /// isCorrectTree = true
        /// testData != null
        /// testData stores information in correct format
        /// all functions are defined
        /// incorrect types of parameters in function call in expression
        /// 
        /// expected exception ArgumentOutOfRangeException
        /// </summary>

        [Test]
        public void FunctionWrongParamIntButBoolExceptionTest()
        {
            var testData = new VarAndFuncDictionary();

            var testTypesList = new List<String>();
            testTypesList.Add("int");
            testData.AddFunction("identity", testTypesList, "int", listIn => (Double.Parse(listIn[0])).ToString());

            string testExpression = "identity(true)";

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(testData);

            Assert.Throws<ArgumentOutOfRangeException>(() => testVisitor.Visit(testTree));
        }

        [Test]
        public void FunctionWrongOneParamIntButBoolExceptionTest()
        {
            var testData = new VarAndFuncDictionary();

            var testTypesList = new List<String>();
            testTypesList.Add("int"); testTypesList.Add("int");
            testData.AddFunction("summ", testTypesList, "int", listIn => (Double.Parse(listIn[0]) + Double.Parse(listIn[1])).ToString());

            string testExpression = "summ(5, false)";

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(testData);

            Assert.Throws<ArgumentOutOfRangeException>(() => testVisitor.Visit(testTree));
        }

        [Test]
        public void FunctionWrongOneParamIntButBoolExprExceptionTest()
        {
            var testData = new VarAndFuncDictionary();

            var testTypesList = new List<String>();
            testTypesList.Add("int"); testTypesList.Add("int");
            testData.AddFunction("summ", testTypesList, "int", listIn => (Double.Parse(listIn[0]) + Double.Parse(listIn[1])).ToString());

            string testExpression = "summ(5, false == true && false)";

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(testData);

            Assert.Throws<ArgumentOutOfRangeException>(() => testVisitor.Visit(testTree));
        }

        [Test]
        public void FunctionWrongOneParamIntButBoolFunctionExceptionTest()
        {
            var testData = new VarAndFuncDictionary();

            var testTypesList1 = new List<String>();
            testTypesList1.Add("int"); testTypesList1.Add("int");
            testData.AddFunction("summ", testTypesList1, "int", listIn => (Double.Parse(listIn[0]) + Double.Parse(listIn[1])).ToString());

            var testTypesList2 = new List<String>();
            testTypesList2.Add("dool");
            testData.AddFunction("identity", testTypesList2, "bool", listIn => SpecialFunctionsForTest.BoolToString(Boolean.Parse(listIn[0])));


            string testExpression = "summ(5, identity(true))";

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(testData);

            Assert.Throws<ArgumentOutOfRangeException>(() => testVisitor.Visit(testTree));
        }

        [Test]
        public void FunctionWrongOneParamIntButBoolVariableExceptionTest()
        {
            var testData = new VarAndFuncDictionary();

            var testTypesList = new List<String>();
            testTypesList.Add("int"); testTypesList.Add("int");
            testData.AddFunction("summ", testTypesList, "int", listIn => (Double.Parse(listIn[0]) + Double.Parse(listIn[1])).ToString());

            testData.AddVariable("a", "bool", "true");

            string testExpression = "summ(5, a)";

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(testData);

            Assert.Throws<ArgumentOutOfRangeException>(() => testVisitor.Visit(testTree));
        }

        /// <summary>
        /// Exception Tests on expressions, which inclide functions with wrong types of parameters:
        /// expected bool but got int.
        /// 
        /// in these tests:
        /// isCorrectTree = true
        /// testData != null
        /// testData stores information in correct format
        /// all functions are defined
        /// incorrect types of parameters in function call in expression
        /// 
        /// expected exception ArgumentOutOfRangeException
        /// </summary>

        [Test]
        public void FunctionWrongParamBoolButIntExceptionTest()
        {
            var testData = new VarAndFuncDictionary();

            var testTypesList = new List<String>();
            testTypesList.Add("bool");
            testData.AddFunction("identity", testTypesList, "bool", listIn => SpecialFunctionsForTest.BoolToString(Boolean.Parse(listIn[0])));

            string testExpression = "identity(1)";

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(testData);

            Assert.Throws<ArgumentOutOfRangeException>(() => testVisitor.Visit(testTree));
        }

        [Test]
        public void FunctionWrongOneParamBoolButIntExprExceptionTest()
        {
            var testData = new VarAndFuncDictionary();

            var testTypesList = new List<String>();
            testTypesList.Add("bool"); testTypesList.Add("bool");
            testData.AddFunction("or", testTypesList, "bool", listIn => SpecialFunctionsForTest.BoolToString(Boolean.Parse(listIn[0]) || Boolean.Parse(listIn[1])));

            string testExpression = "or(true, 1)";

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(testData);

            Assert.Throws<ArgumentOutOfRangeException>(() => testVisitor.Visit(testTree));
        }

        [Test]
        public void FunctionWrongParamBoolButIntExprExceptionTest()
        {
            var testData = new VarAndFuncDictionary();

            var testTypesList = new List<String>();
            testTypesList.Add("bool");
            testData.AddFunction("identity", testTypesList, "bool", listIn => SpecialFunctionsForTest.BoolToString(Boolean.Parse(listIn[0])));

            string testExpression = "identity(1 + 5)";

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(testData);

            Assert.Throws<ArgumentOutOfRangeException>(() => testVisitor.Visit(testTree));
        }

        [Test]
        public void FunctionWrongParamBoolButIntFuncExceptionTest()
        {
            var testData = new VarAndFuncDictionary();

            var testTypesList2 = new List<String>();
            testTypesList2.Add("bool");
            testData.AddFunction("identity", testTypesList2, "bool", listIn => SpecialFunctionsForTest.BoolToString(Boolean.Parse(listIn[0])));

            var testTypesList1 = new List<String>();
            testTypesList1.Add("int");
            testData.AddFunction("negative", testTypesList1, "int", listIn => (-Double.Parse(listIn[0])).ToString());

            string testExpression = "identity(negative(4))";

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(testData);

            Assert.Throws<ArgumentOutOfRangeException>(() => testVisitor.Visit(testTree));
        }

        [Test]
        public void FunctionWrongParamBoolButIntVariableExceptionTest()
        {
            var testData = new VarAndFuncDictionary();

            var testTypesList2 = new List<String>();
            testTypesList2.Add("bool");
            testData.AddFunction("identity", testTypesList2, "bool", listIn => SpecialFunctionsForTest.BoolToString(Boolean.Parse(listIn[0])));

            testData.AddVariable("a", "int", "5");

            string testExpression = "identity(a)";

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(testData);

            Assert.Throws<ArgumentOutOfRangeException>(() => testVisitor.Visit(testTree));
        }
    }
}
