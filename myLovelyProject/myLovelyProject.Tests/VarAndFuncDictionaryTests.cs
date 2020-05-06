using System;
using System.Collections.Generic;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace myLovelyProject.Tests
{
    class VarAndFuncDictionaryTests
    {
        /// <summary>
        /// Correct Tests on expressions, which include functions Max, Min, Sqrt, Abs.
        /// 
        /// in these tests:
        /// isCorrectTree = true
        /// testData ?= null
        /// testData stores information in correct format
        /// all functions are defined
        /// </summary>
        
        [Test]
        public void MaxDefinitionCorrectTest()
        {
            string testExpression = "Max(5, 5.01)";
            double testAnswer = 5.01;

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);
            var testVisitor = new ParsingTreeVisitor();
            Assert.IsTrue(SpecialFunctionsForTest.AreEqualDouble(testAnswer, testVisitor.Visit(testTree).value));
        }

        [Test]
        public void MinDefinitionCorrectTest()
        {
            string testExpression = "Min(5, 5.01)";
            double testAnswer = 5;

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);
            var testVisitor = new ParsingTreeVisitor();
            Assert.IsTrue(SpecialFunctionsForTest.AreEqualDouble(testAnswer, testVisitor.Visit(testTree).value));
        }

        [Test]
        public void SqrtDefinitionCorrectTest()
        {
            string testExpression = "Sqrt(25)";
            double testAnswer = 5;

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);
            var testVisitor = new ParsingTreeVisitor();
            Assert.IsTrue(SpecialFunctionsForTest.AreEqualDouble(testAnswer, testVisitor.Visit(testTree).value));
        }

        [Test]
        public void AbsDefinitionCorrectTest()
        {
            string testExpression = "Abs(25.09)";
            double testAnswer = 25.09;

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);
            var testVisitor = new ParsingTreeVisitor();
            Assert.IsTrue(SpecialFunctionsForTest.AreEqualDouble(testAnswer, testVisitor.Visit(testTree).value));
        }

        /// <summary>
        /// Exception Tests on expressions, which include functions Max, Min, Sqrt, Abs.
        /// Wrong functions names.
        /// 
        /// in these tests:
        /// isCorrectTree = true
        /// testData ?= null
        /// testData stores information in correct format
        /// all functions are defined
        /// 
        /// expected KeyNotFoundException
        /// </summary>
         
        [Test]
        public void MaxWrongNameExceptionTest()
        {
            string testExpression = "max(4, 5)";

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor();
            Assert.Throws<KeyNotFoundException>(() => testVisitor.Visit(testTree));
        }

        [Test]
        public void MinWrongNameExceptionTest()
        {
            string testExpression = "min(4, 5)";

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor();
            Assert.Throws<KeyNotFoundException>(() => testVisitor.Visit(testTree));
        }

        [Test]
        public void SqrtWrongNameExceptionTest()
        {
            string testExpression = "sqrt(4)";

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(null);
            Assert.Throws<KeyNotFoundException>(() => testVisitor.Visit(testTree));
        }

        [Test]
        public void AbsWrongNameExceptionTest()
        {
            string testExpression = "abs(-5)";

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor();
            Assert.Throws<KeyNotFoundException>(() => testVisitor.Visit(testTree));
        }

        /// <summary>
        /// Exception Tests on expressions, which include undefined variables
        /// having the same names with functions Max, Min, Sqrt, Abs.
        /// 
        /// in these tests:
        /// isCorrectTree = true
        /// testData ?= null
        /// testData stores information in correct format
        /// all functions and variables are defined
        /// 
        /// expected KeyNotFoundException
        /// </summary>

        [Test]
        public void MaxVariableNameUndefinedExceptionTest()
        {
            string testExpression = "Max + 5";

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor();
            Assert.Throws<KeyNotFoundException>(() => testVisitor.Visit(testTree));
        }

        [Test]
        public void MinVariableNameUndefinedExceptionTest()
        {
            string testExpression = "Min + 5";

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor();
            Assert.Throws<KeyNotFoundException>(() => testVisitor.Visit(testTree));
        }

        [Test]
        public void SqrtVariableNameUndefinedExceptionTest()
        {
            string testExpression = "Sqrt + 5";

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor();
            Assert.Throws<KeyNotFoundException>(() => testVisitor.Visit(testTree));
        }

        [Test]
        public void AbsVariableNameUndefinedExceptionTest()
        {
            string testExpression = "Abs + 5";

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor();
            Assert.Throws<KeyNotFoundException>(() => testVisitor.Visit(testTree));
        }

        /// <summary>
        /// Exception Tests on variables and functions
        /// having the same names with functions Max, Min, Sqrt, Abs.
        /// 
        /// in these tests:
        /// isCorrectTree = true
        /// testData ?= null
        /// testData stores information in correct format
        /// all functions and variables are defined
        /// 
        /// expected ArgumentException
        /// </summary>

        [Test]
        public void MaxVariableNameExceptionTest()
        {
            var testData = new VarAndFuncDictionary();

            Assert.Throws<ArgumentException>(() => testData.AddVariable("Max", "int", "4"));
        }

        [Test]
        public void MinVariableNameExceptionTest()
        {
            var testData = new VarAndFuncDictionary();

            Assert.Throws<ArgumentException>(() => testData.AddVariable("Min", "int", "4"));
        }

        [Test]
        public void SqrtVariableNameExceptionTest()
        {
            var testData = new VarAndFuncDictionary();

            Assert.Throws<ArgumentException>(() => testData.AddVariable("Sqrt", "int", "4"));
        }

        [Test]
        public void AbsVariableNameExceptionTest()
        {
            var testData = new VarAndFuncDictionary();

            Assert.Throws<ArgumentException>(() => testData.AddVariable("Abs", "int", "4"));
        }

        [Test]
        public void MaxFunctionTheSameNameExceptionTest()
        {
            var testData = new VarAndFuncDictionary();

            Assert.Throws<ArgumentException>(() => testData.AddFunction("Max", null, null, null));
        }

        [Test]
        public void MinFunctionTheSameNameExceptionTest()
        {
            var testData = new VarAndFuncDictionary();

            Assert.Throws<ArgumentException>(() => testData.AddFunction("Min", null, null, null));
        }

        [Test]
        public void SqrtFunctionTheSameNameExceptionTest()
        {
            var testData = new VarAndFuncDictionary();

            Assert.Throws<ArgumentException>(() => testData.AddFunction("Sqrt", null, null, null));
        }

        [Test]
        public void AbsFunctionTheSameNameExceptionTest()
        {
            var testData = new VarAndFuncDictionary();

            Assert.Throws<ArgumentException>(() => testData.AddFunction("Abs", null, null, null));
        }

        /// <summary>
        /// Exception Tests on variables and functions having the same names.
        /// 
        /// in these tests:
        /// isCorrectTree = true
        /// testData ?= null
        /// testData stores information in correct format
        /// all functions and variables are defined
        /// 
        /// expected ArgumentException
        /// </summary>

        [Test]
        public void FunctionTheSameNameWithVariableExceptionTest()
        {
            var testData = new VarAndFuncDictionary();

            testData.AddVariable("aaa", "int", "4");

            Assert.Throws<ArgumentException>(() => testData.AddFunction("aaa", null, null, null));
        }

        [Test]
        public void VariableTheSameNameWithFunctionExceptionTest()
        {
            var testData = new VarAndFuncDictionary();

            testData.AddFunction("aaa", null, null, null);

            Assert.Throws<ArgumentException>(() => testData.AddVariable("aaa", "int", "4"));
        }

        /// <summary>
        /// Exception Tests on expressions, which inclide undefined variables and functions.
        /// 
        /// in these tests:
        /// isCorrectTree = true
        /// testData ?= null
        /// testData stores information in correct format
        /// not all variables and functions are defined
        /// 
        /// expected KeyNotFoundException
        /// </summary>

        [Test]
        public void VariablesNullHashTableExceptionTest()
        {
            string testExpression = "a * 4";

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor();
            Assert.Throws<KeyNotFoundException>(() => testVisitor.Visit(testTree));
        }

        [Test]
        public void VariablesUndefinedVariablesShortExceptionTest()
        {
            var testData = new VarAndFuncDictionary();

            testData.AddVariable("a", "int", "4");
            testData.AddVariable("b", "int", "5");

            string testExpression = "c";

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);
            var testVisitor = new ParsingTreeVisitor(testData);
            Assert.Throws<KeyNotFoundException>(() => testVisitor.Visit(testTree));
        }

        [Test]
        public void VariablesUndefinedVariablesLongExceptionTest()
        {
            var testData = new VarAndFuncDictionary();

            testData.AddVariable("a", "int", "4");
            testData.AddVariable("b", "int", "5");

            string testExpression = "a - b / c";

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);
            var testVisitor = new ParsingTreeVisitor(testData);
            Assert.Throws<KeyNotFoundException>(() => testVisitor.Visit(testTree));
        }

        [Test]
        public void FunctionsUndefinedFunctionsShortExceptionTest()
        {
            var testData = new VarAndFuncDictionary();

            var testTypesList1 = new List<String>();
            testTypesList1.Add("bool");
            testData.AddFunction("identity", testTypesList1, "bool", listIn => SpecialFunctionsForTest.BoolToString(Boolean.Parse(listIn[0])));

            string testExpression = "identiti(true)";

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);
            var testVisitor = new ParsingTreeVisitor(testData);
            Assert.Throws<KeyNotFoundException>(() => testVisitor.Visit(testTree));
        }
    }
}
