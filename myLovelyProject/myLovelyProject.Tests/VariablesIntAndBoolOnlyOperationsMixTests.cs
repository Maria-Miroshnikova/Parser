using System;
using System.Collections.Generic;
using System.Threading.Tasks.Sources;
using NUnit.Framework;

namespace myLovelyProject.Tests
{
    class VariablesIntAndBoolOnlyOperationsMixTests
    {
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// Exception Tests on expressions, which inclide numbers and variables (type "int" only)
        /// and logic operations.
        /// 
        /// in these tests:
        /// isCorrectTree = true
        /// testData != null
        /// testData stores information in correct format
        /// all variables are defined
        /// 
        /// expected exception InvalidOperationException
        /// </summary>

        [Test]
        public void VariablesIntLogicOperationsANDExceptionTest()
        {
            var testData = new VarAndFuncDictionary();

            testData.AddVariable("a", "int", "2");
            testData.AddVariable("b", "int", "5");

            string testExpression = "a && b";

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);
            var testVisitor = new ParsingTreeVisitor(testData);
            Assert.Throws<InvalidOperationException>(() => testVisitor.Visit(testTree));
        }

        [Test]
        public void VariablesIngLogicOperationsORExceptionTest()
        {
            var testData = new VarAndFuncDictionary();

            testData.AddVariable("a", "int", "2");
            testData.AddVariable("b", "int", "5");

            string testExpression = "a || b";

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);
            var testVisitor = new ParsingTreeVisitor(testData);
            Assert.Throws<InvalidOperationException>(() => testVisitor.Visit(testTree));
        }

        [Test]
        public void VariablesIntLogicOperationsEQExceptionTest()
        {
            var testData = new VarAndFuncDictionary();

            testData.AddVariable("a", "int", "2");
            testData.AddVariable("b", "int", "2");

            string testExpression = "a == b";

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);
            var testVisitor = new ParsingTreeVisitor(testData);
            Assert.Throws<InvalidOperationException>(() => testVisitor.Visit(testTree));
        }

        [Test]
        public void VariablesIntLogicOperationsNOTExceptionTest()
        {
            var testData = new VarAndFuncDictionary();

            testData.AddVariable("a", "int", "2");
            testData.AddVariable("b", "int", "5");

            string testExpression = "!a";

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);
            var testVisitor = new ParsingTreeVisitor(testData);
            Assert.Throws<InvalidOperationException>(() => testVisitor.Visit(testTree));
        }

        [Test]
        public void VariablesIntLogicOperationsTwoNOTExceptionTest()
        {
            var testData = new VarAndFuncDictionary();

            testData.AddVariable("a", "int", "2");
            testData.AddVariable("b", "int", "5");

            string testExpression = "! ! a";

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);
            var testVisitor = new ParsingTreeVisitor(testData);
            Assert.Throws<InvalidOperationException>(() => testVisitor.Visit(testTree));
        }

        /// <summary>
        /// Exception Tests on expressions, which inclide bools and variables (type "bool" only)
        /// and arithmetic operations.
        /// 
        /// in these tests:
        /// isCorrectTree = true
        /// testData != null
        /// testData stores information in correct format
        /// all variables are defined
        /// 
        /// expected exception InvalidOperationException
        /// </summary>

        [Test]
        public void VariablesBoolArithmeticOperationsPLUSExceptionTest()
        {
            var testData = new VarAndFuncDictionary();

            testData.AddVariable("a", "bool", "true");
            testData.AddVariable("b", "bool", "false");

            string testExpression = "a + b";

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);
            var testVisitor = new ParsingTreeVisitor(testData);
            Assert.Throws<InvalidOperationException>(() => testVisitor.Visit(testTree));
        }

        [Test]
        public void VariablesBoolArithmeticOperationsMINUSExceptionTest()
        {
            var testData = new VarAndFuncDictionary();

            testData.AddVariable("a", "bool", "true");
            testData.AddVariable("b", "bool", "false");

            string testExpression = "a - b";

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);
            var testVisitor = new ParsingTreeVisitor(testData);
            Assert.Throws<InvalidOperationException>(() => testVisitor.Visit(testTree));
        }

        [Test]
        public void VariablesBoolArithmeticOperationsTIMESExceptionTest()
        {
            var testData = new VarAndFuncDictionary();

            testData.AddVariable("a", "bool", "true");
            testData.AddVariable("b", "bool", "false");

            string testExpression = "a * b";

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);
            var testVisitor = new ParsingTreeVisitor(testData);
            Assert.Throws<InvalidOperationException>(() => testVisitor.Visit(testTree));
        }

        [Test]
        public void VariablesBoolArithmeticOperationsDIVExceptionTest()
        {
            var testData = new VarAndFuncDictionary();

            testData.AddVariable("a", "bool", "true");
            testData.AddVariable("b", "bool", "false");

            string testExpression = "a / b";

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);
            var testVisitor = new ParsingTreeVisitor(testData);
            Assert.Throws<InvalidOperationException>(() => testVisitor.Visit(testTree));
        }

        [Test]
        public void VariablesBoolArithmeticOperationsMINUSBeforeExceptionTest()
        {
            var testData = new VarAndFuncDictionary();

            testData.AddVariable("a", "bool", "true");
            testData.AddVariable("b", "bool", "false");

            string testExpression = "- b";

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);
            var testVisitor = new ParsingTreeVisitor(testData);
            Assert.Throws<InvalidOperationException>(() => testVisitor.Visit(testTree));
        }

        [Test]
        public void VariablesBoolArithmeticOperationsTwoMINUSBeforeExceptionTest()
        {
            var testData = new VarAndFuncDictionary();

            testData.AddVariable("a", "bool", "true");
            testData.AddVariable("b", "bool", "false");

            string testExpression = "-- b";

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);
            var testVisitor = new ParsingTreeVisitor(testData);
            Assert.Throws<InvalidOperationException>(() => testVisitor.Visit(testTree));
        }

        /// <summary>
        /// Exception Tests on expressions, which inclide numbers and variables (type "int" only)
        /// and mix operations.
        /// 
        /// in these tests:
        /// isCorrectTree = true
        /// testData != null
        /// testData stores information in correct format
        /// all variables are defined
        /// 
        /// expected exception InvalidOperationException
        /// </summary>

        [Test]
        public void VariablesIntMixOperationsTwoDifferentTypesOfOperationsExceptionTest()
        {
            var testData = new VarAndFuncDictionary();

            testData.AddVariable("a", "int", "2");
            testData.AddVariable("b", "int", "4");
            testData.AddVariable("c", "int", "0");

            string testExpression = "a + b && c";

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);
            var testVisitor = new ParsingTreeVisitor(testData);
            Assert.Throws<InvalidOperationException>(() => testVisitor.Visit(testTree));
        }

        [Test]
        public void VariablesIntMixOperationsExpOpExpExceptionTest()
        {
            var testData = new VarAndFuncDictionary();

            testData.AddVariable("a", "int", "2");
            testData.AddVariable("b", "int", "4");
            testData.AddVariable("c", "int", "1");
            testData.AddVariable("d", "int", "5");

            string testExpression = "(a + b) == (c + d)";

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);
            var testVisitor = new ParsingTreeVisitor(testData);
            Assert.Throws<InvalidOperationException>(() => testVisitor.Visit(testTree));
        }

        [Test]
        public void VariablesIntMixOperationsNOTExpExceptionTest()
        {
            var testData = new VarAndFuncDictionary();

            testData.AddVariable("a", "int", "2");
            testData.AddVariable("b", "int", "4");

            string testExpression = "! (a + b)";

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);
            var testVisitor = new ParsingTreeVisitor(testData);
            Assert.Throws<InvalidOperationException>(() => testVisitor.Visit(testTree));
        }

        [Test]
        public void VariablesIntMixOperationsMINUSAndNOTExpExceptionTest()
        {
            var testData = new VarAndFuncDictionary();

            testData.AddVariable("a", "int", "2");
            testData.AddVariable("b", "int", "4");

            string testExpression = "- ! (a + b)";

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);
            var testVisitor = new ParsingTreeVisitor(testData);
            Assert.Throws<InvalidOperationException>(() => testVisitor.Visit(testTree));
        }

        /// <summary>
        /// Exception Tests on expressions, which inclide bools and variables (type "bool" only)
        /// and mix operations.
        /// 
        /// in these tests:
        /// isCorrectTree = true
        /// testData != null
        /// testData stores information in correct format
        /// all variables are defined
        /// 
        /// expected exception InvalidOperationException
        /// </summary>

        [Test]
        public void VariablesBoolMixOperationsTwoDifferentTypesOfOperationsExceptionTest()
        {
            var testData = new VarAndFuncDictionary();

            testData.AddVariable("a", "bool", "true");
            testData.AddVariable("b", "bool", "false");
            testData.AddVariable("d", "bool", "true");

            string testExpression = "a && b + d";

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);
            var testVisitor = new ParsingTreeVisitor(testData);
            Assert.Throws<InvalidOperationException>(() => testVisitor.Visit(testTree));
        }

        [Test]
        public void VariablesBoolMixOperationsExpOpExpExceptionTest()
        {
            var testData = new VarAndFuncDictionary();

            testData.AddVariable("a", "bool", "true");
            testData.AddVariable("b", "bool", "false");
            testData.AddVariable("c", "bool", "true");
            testData.AddVariable("d", "bool", "true");

            string testExpression = "(a && b) * (true || true)";

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);
            var testVisitor = new ParsingTreeVisitor(testData);
            Assert.Throws<InvalidOperationException>(() => testVisitor.Visit(testTree));
        }

        [Test]
        public void VariablesBoolMixOperationsMINUSExpExceptionTest()
        {
            var testData = new VarAndFuncDictionary();

            testData.AddVariable("a", "bool", "true");
            testData.AddVariable("b", "bool", "false");

            string testExpression = "- (a && b)";

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);
            var testVisitor = new ParsingTreeVisitor(testData);
            Assert.Throws<InvalidOperationException>(() => testVisitor.Visit(testTree));
        }

        [Test]
        public void VariablesBoolMixOperationsMINUSAndNOTExpExceptionTest()
        {
            var testData = new VarAndFuncDictionary();

            testData.AddVariable("a", "bool", "true");
            testData.AddVariable("b", "bool", "false");

            string testExpression = "! - (a && b)";

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);
            var testVisitor = new ParsingTreeVisitor(testData);
            Assert.Throws<InvalidOperationException>(() => testVisitor.Visit(testTree));
        }

        /// <summary>
        /// Exception Tests on easy expressions with mix of numbers and bools
        /// and variables (types "bool" and "int" only and mix operations).
        /// 
        /// In these tests:
        /// isCorrectTree = true
        /// testData != null
        /// testData stores information in correct format
        /// all variables are defined
        /// 
        /// expected exception InvalidOperationException
        /// </summary>
        /// 

        [Test]
        public void VariablesMixNumbersAndBoolsLogicOperationsExceptionTest()
        {
            var testData = new VarAndFuncDictionary();

            testData.AddVariable("var", "bool", "true");
            testData.AddVariable("num", "int", "5");

            string testExpression = " var && num";

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);
            var testVisitor = new ParsingTreeVisitor(testData);
            Assert.Throws<InvalidOperationException>(() => testVisitor.Visit(testTree));
        }

        [Test]
        public void VariablesMixNumbersAndBoolsArithmeticOperationsExceptionTest()
        {
            var testData = new VarAndFuncDictionary();

            testData.AddVariable("var", "bool", "false");
            testData.AddVariable("num", "int", "5");

            string testExpression = " num * var";

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);
            var testVisitor = new ParsingTreeVisitor(testData);
            Assert.Throws<InvalidOperationException>(() => testVisitor.Visit(testTree));
        }

        [Test]
        public void VariablesMixNumbersAndBoolsMixOperationsExceptionTest()
        {
            var testData = new VarAndFuncDictionary();

            testData.AddVariable("var1", "bool", "false");
            testData.AddVariable("var2", "bool", "true");
            testData.AddVariable("num", "int", "5");

            string testExpression = " var1 && var2 * num";

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);
            var testVisitor = new ParsingTreeVisitor(testData);
            Assert.Throws<InvalidOperationException>(() => testVisitor.Visit(testTree));
        }

        [Test]
        public void VariablesMixNumbersAndBoolsMixOperationsNOTExceptionTest()
        {
            var testData = new VarAndFuncDictionary();

            testData.AddVariable("var", "bool", "false");
            testData.AddVariable("num", "int", "5");

            string testExpression = " num * !var";

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);
            var testVisitor = new ParsingTreeVisitor(testData);
            Assert.Throws<InvalidOperationException>(() => testVisitor.Visit(testTree));
        }

        [Test]
        public void VariablesMixNumbersAndBoolsMixOperationsMINUSExceptionTest()
        {
            var testData = new VarAndFuncDictionary();

            testData.AddVariable("var", "bool", "false");
            testData.AddVariable("num", "int", "5");

            string testExpression = " var && -num";

            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);
            var testVisitor = new ParsingTreeVisitor(testData);
            Assert.Throws<InvalidOperationException>(() => testVisitor.Visit(testTree));
        }
    }
}
