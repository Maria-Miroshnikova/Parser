using System;
using NUnit.Framework;

namespace myLovelyProject.Tests
{
    class NumbersAndBoolsOnlyOperationsMixTests
    {
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// Exception Tests on easy expressions with numbers and logic operations.
        /// 
        /// In these tests:
        /// isCorrectTree = true
        /// testData = null (no hashTable!)
        /// expected exception InvalidOperationException
        /// </summary>
        /// 

        [Test]
        public void NumbersLogicOperationsANDExceptionTest()
        {
            var testExpression = "2 && 5";
            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(null);

            Assert.Throws<InvalidOperationException>(() => testVisitor.Visit(testTree));
        }

        [Test]
        public void NumbersLogicOperationsORExceptionTest()
        {
            var testExpression = "2 || 5";
            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(null);

            Assert.Throws<InvalidOperationException>(() => testVisitor.Visit(testTree));
        }

        [Test]
        public void NumbersLogicOperationsEQExceptionTest()
        {
            var testExpression = "2 == 2";
            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(null);

            Assert.Throws<InvalidOperationException>(() => testVisitor.Visit(testTree));
        }

        [Test]
        public void NumbersLogicOperationsNOTExceptionTest()
        {
            var testExpression = "! 2";
            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(null);

            Assert.Throws<InvalidOperationException>(() => testVisitor.Visit(testTree));
        }

        [Test]
        public void NumbersLogicOperationsTwoNOTExceptionTest()
        {
            var testExpression = "! !2";
            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(null);

            Assert.Throws<InvalidOperationException>(() => testVisitor.Visit(testTree));
        }

        /// <summary>
        /// Exception Tests on easy expressions with bools and arithmetic operations.
        /// 
        /// In these tests:
        /// isCorrectTree = true
        /// testData = null (no hashTable!)
        /// expected exception InvalidOperationException
        /// </summary>
        /// 

        [Test]
        public void BoolsArithmeticOperationsPLUSExceptionTest()
        {
            var testExpression = "true + false";
            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(null);

            Assert.Throws<InvalidOperationException>(() => testVisitor.Visit(testTree));
        }

        [Test]
        public void BoolsArithmeticOperationsMINUSExceptionTest()
        {
            var testExpression = "true - false";
            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(null);

            Assert.Throws<InvalidOperationException>(() => testVisitor.Visit(testTree));
        }

        [Test]
        public void BoolsArithmeticOperationsTIMESExceptionTest()
        {
            var testExpression = "true * false";
            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(null);

            Assert.Throws<InvalidOperationException>(() => testVisitor.Visit(testTree));
        }

        [Test]
        public void BoolsArithmeticOperationsDIVExceptionTest()
        {
            var testExpression = "true / false";
            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(null);

            Assert.Throws<InvalidOperationException>(() => testVisitor.Visit(testTree));
        }

        [Test]
        public void BoolsArithmeticOperationsMINUSBeforeExceptionTest()
        {
            var testExpression = "- false";
            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(null);

            Assert.Throws<InvalidOperationException>(() => testVisitor.Visit(testTree));
        }

        [Test]
        public void BoolsArithmeticOperationsTwoMINUSBeforeExceptionTest()
        {
            var testExpression = "-- false";
            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(null);

            Assert.Throws<InvalidOperationException>(() => testVisitor.Visit(testTree));
        }

        /// <summary>
        /// Exception Tests on easy expressions with numbers and mix operations.
        /// 
        /// In these tests:
        /// isCorrectTree = true
        /// testData = null (no hashTable!)
        /// expected exception InvalidOperationException
        /// </summary>

        [Test]
        public void NumbersMixOperationsTwoDifferentTypesOfOperationsExceptionTest()
        {
            var testExpression = "2 + 4 && 0";
            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(null);

            Assert.Throws<InvalidOperationException>(() => testVisitor.Visit(testTree));
        }

        [Test]
        public void NumbersMixOperationsExpOpExpExceptionTest()
        {
            var testExpression = "(2 + 4) == (1 + 5)";
            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(null);

            Assert.Throws<InvalidOperationException>(() => testVisitor.Visit(testTree));
        }

        [Test]
        public void NumbersMixOperationsNOTExpExceptionTest()
        {
            var testExpression = "! (2 + 4)";
            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(null);

            Assert.Throws<InvalidOperationException>(() => testVisitor.Visit(testTree));
        }

        [Test]
        public void NumbersMixOperationsMINUSAndNOTExpExceptionTest()
        {
            var testExpression = " ! - (2 + 4)";
            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(null);

            Assert.Throws<InvalidOperationException>(() => testVisitor.Visit(testTree));
        }

        /// <summary>
        /// Exception Tests on easy expressions with bools and mix operations.
        /// 
        /// In these tests:
        /// isCorrectTree = true
        /// testData = null (no hashTable!)
        /// expected exception InvalidOperationException
        /// </summary>

        [Test]
        public void BoolsMixOperationsTwoDifferentTypesOfOperationsExceptionTest()
        {
            var testExpression = "true && false + true";
            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(null);

            Assert.Throws<InvalidOperationException>(() => testVisitor.Visit(testTree));
        }

        [Test]
        public void BoolsMixOperationsExpOpExpExceptionTest()
        {
            var testExpression = "(true && false) * (true || true)";
            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(null);

            Assert.Throws<InvalidOperationException>(() => testVisitor.Visit(testTree));
        }

        [Test]
        public void BoolsMixOperationsMINUSExpExceptionTest()
        {
            var testExpression = "- (true && false)";
            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(null);

            Assert.Throws<InvalidOperationException>(() => testVisitor.Visit(testTree));
        }

        [Test]
        public void BoolsMixOperationsMINUSAndNOTExpExceptionTest()
        {
            var testExpression = " - ! (true && false)";
            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(null);

            Assert.Throws<InvalidOperationException>(() => testVisitor.Visit(testTree));
        }

        /// <summary>
        /// Exception Tests on easy expressions with mix of numbers and bools and mix operations.
        /// 
        /// In these tests:
        /// isCorrectTree = true
        /// testData = null (no hashTable!)
        /// expected exception InvalidOperationException
        /// </summary>

        [Test]
        public void MixNumbersAndBoolsLogicOperationsExceptionTest()
        {
            var testExpression = " true && 5";
            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(null);

            Assert.Throws<InvalidOperationException>(() => testVisitor.Visit(testTree));
        }

        [Test]
        public void MixNumbersAndBoolsArithmeticOperationsExceptionTest()
        {
            var testExpression = " 5 * false";
            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(null);

            Assert.Throws<InvalidOperationException>(() => testVisitor.Visit(testTree));
        }

        [Test]
        public void MixNumbersAndBoolsMixOperationsExceptionTest()
        {
            var testExpression = "false && true * 5";
            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(null);

            Assert.Throws<InvalidOperationException>(() => testVisitor.Visit(testTree));
        }

        [Test]
        public void MixNumbersAndBoolsMixOperationsNOTExceptionTest()
        {
            var testExpression = "5 * !false";
            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(null);

            Assert.Throws<InvalidOperationException>(() => testVisitor.Visit(testTree));
        }

        [Test]
        public void MixNumbersAndBoolsMixOperationsMINUSExceptionTest()
        {
            var testExpression = "false && -5";
            (var testTree, var isCorrectTree) = SpecialFunctionsForTest.MakeTreeAndCheck(testExpression);

            Assert.IsTrue(isCorrectTree);

            var testVisitor = new ParsingTreeVisitor(null);

            Assert.Throws<InvalidOperationException>(() => testVisitor.Visit(testTree));
        }
    }
}
