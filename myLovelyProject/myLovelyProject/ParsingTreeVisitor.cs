
namespace myLovelyProject
{
    using System;
    using Antlr4.Runtime.Misc;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Reflection.Metadata;
    using System.Reflection;
    using myLovelyProject.Tests;

    /// <summary>
    /// This class presents visitor, which goes around AST and returns value and type of stored expression.
    /// Acceptable types: double, int, bool.
    /// Data about functions and variables is storing in VarAndFuncDictionary.
    /// </summary>
    public class ParsingTreeVisitor : arithmeticBaseVisitor<(string value, string type)>
    {
        /// <summary>
        /// Dictionary with data about functions and variables.
        /// Base functions: Max, Min, Sqrt, Abs.
        /// </summary>
        private VarAndFuncDictionary givenVariablesAndFunctions; 

        public ParsingTreeVisitor(VarAndFuncDictionary dictionary = null)
        {
            if (dictionary != null)
            {
                this.givenVariablesAndFunctions = dictionary;
            }
            else
            {
                this.givenVariablesAndFunctions = new VarAndFuncDictionary();
            }
        }

        /// <summary>
        /// Method for visiting atom.
        /// </summary>
        /// <param name="context"></param>
        public override (string value, string type) VisitAtom([NotNull] arithmeticParser.AtomContext context)
        {
            if (context.GetChild(0) is arithmeticParser.NumberContext)
            {
                return VisitNumber(context.number());
            }
            else if (context.GetChild(0) is arithmeticParser.BoolContext)
            {
                return VisitBool(context.@bool());
            }
            else
            {
                return VisitIdentifier(context.identifier());
            }
        }

        /// <summary>
        /// Method for visiting number (both of double and int)
        /// </summary>
        /// <param name="context"></param>
        public override (string value, string type) VisitNumber([NotNull] arithmeticParser.NumberContext context)
        {
            var text = context.GetText();

            string type;
            if (context.GetChild(0) is arithmeticParser.IntContext)
            {
                type = "int";
            }
            else
            {
                type = "double";
            }

            return (text, type);
        }

        /// <summary>
        /// Method for visiting bool (both of true and false)
        /// </summary>
        /// <param name="context"></param>
        public override (string value, string type) VisitBool([NotNull] arithmeticParser.BoolContext context)
        {
            var text = context.GetText();
            return (text, "bool");
        }

        /// <summary>
        /// Method for visiting identifire.
        /// </summary>
        /// <param name="context"></param>
        public override (string value, string type) VisitIdentifier([NotNull] arithmeticParser.IdentifierContext context)
        {
            if (givenVariablesAndFunctions == null)
            {
                throw new ArgumentNullException();
            }

            string nameOfIdentifire = context.nameIdentifier().GetText();
            if (!givenVariablesAndFunctions.ContainsKey(nameOfIdentifire))
            {
                throw new KeyNotFoundException();
            }

            var typeOfIdentifire = context.typeIdentifier().GetChild(0);

            if (typeOfIdentifire is arithmeticParser.FunctionContext)
            {
                return VisitFunction(context.nameIdentifier(), context.typeIdentifier().function());
            }
            else
            {
                return VisitVariable(context.nameIdentifier());
            }
        }

        /// <summary>
        /// Method for visiting variable.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public (string value, string type) VisitVariable([NotNull] arithmeticParser.NameIdentifierContext context)
        {
            string variableName = context.GetText();

            IData variableDataFromTable = new DataVariable();
            givenVariablesAndFunctions.TryGetValue(variableName, out variableDataFromTable);

            if (!(variableDataFromTable is DataVariable))
            {
                // переменная имеет такое же имя, как базовая функция, и об этом переменной не внесли данных
                throw new KeyNotFoundException();
            }

            DataVariable dataFromTable = (DataVariable)variableDataFromTable;

            // проверка адекватности типа переменной
            if (((dataFromTable.Type) != "bool") && ((dataFromTable.Type) != "int") && ((dataFromTable.Type) != "double"))
            {
                // неизвестный тип
                throw new ArgumentOutOfRangeException();
            }

            return (dataFromTable.Value, dataFromTable.Type);
        }

        /// <summary>
        /// Method for visiting functions
        /// </summary>
        /// <param name="nameContext"></param>
        /// <param name="functionContext"></param>
        public (string value, string type) VisitFunction([NotNull] arithmeticParser.NameIdentifierContext nameContext, [NotNull] arithmeticParser.FunctionContext functionContext)
        {
            string functionName = nameContext.GetText();

            IData functionDataFromTable = new DataFunction();
            givenVariablesAndFunctions.TryGetValue(functionName, out functionDataFromTable);

            DataFunction dataFromTable = (DataFunction)functionDataFromTable;

            // проверка адекватности типа выходных параметров
            if (((dataFromTable.TypeOutParameters) != "bool") && ((dataFromTable.TypeOutParameters) != "int") && ((dataFromTable.TypeOutParameters) != "double"))
            {
                // неизвестный тип
                throw new ArgumentOutOfRangeException();
            }

            // проверка типов входных параметров
            int indexOfInParameter = 1;
            var parametersOfFunction = new List<string>();

            int countOfInParameters = (functionContext.ChildCount - 1) / 2;
            if ((countOfInParameters != 0) && (dataFromTable.TypesInParameters == null))
            {
                // по таблице функция обязана принимать аргументы, а в выражении функция от пустых скобок
                throw new ArgumentOutOfRangeException();
            }

            if (dataFromTable.TypesInParameters != null)
            {
                if (countOfInParameters != dataFromTable.TypesInParameters.Count)
                {
                    // не совпадают количества параметров
                    throw new ArgumentOutOfRangeException();
                }

                for (int i = 0; i < dataFromTable.TypesInParameters.Count; ++i)
                {
                    var currentParameter = functionContext.GetChild(indexOfInParameter);
                    var (valueOfParameterExpression, typeOfInParameter) = VisitExpression((arithmeticParser.ExpressionContext)currentParameter);

                    if (((dataFromTable.TypesInParameters[i] != "double") || ((typeOfInParameter != "int") && (typeOfInParameter != "double"))) && (dataFromTable.TypesInParameters[i] != typeOfInParameter))
                    {
                        // неправильные входные аргументы
                        throw new ArgumentOutOfRangeException();
                    }

                    parametersOfFunction.Add(valueOfParameterExpression);
                    indexOfInParameter += 2; // потому что ( expr , expr , ... expr )
                }
            }

            // вычисление значения
            var resultOfFunctionCall = dataFromTable.FunctionRealization(parametersOfFunction);

            // проверка типа выходного параметра: ожидается корректность табличных данных!

            return (resultOfFunctionCall.Replace(',', '.'), dataFromTable.TypeOutParameters);
        }

        /// <summary>
        /// Method for visiting expression
        /// </summary>
        /// <param name="context"></param>
        public override (string value, string type) VisitExpression(arithmeticParser.ExpressionContext context)
        {
            string type;

            var first = context.GetChild(0);
            var isExprOpExpr = first.GetType() == typeof(arithmeticParser.ExpressionContext);
            var isLparen = first.GetText() == "(";

            var hasLparen = false;
            for (int i = 0; i < context.ChildCount; ++i)
            {
                if (context.GetChild(i).GetText() == "(")
                {
                    hasLparen = true;
                    break;
                }
            }
            var isNegativeLparenExpr = (context.op != null) && hasLparen;
            
            if (isExprOpExpr)
            {
                var (left, typeLeft) = VisitExpression((arithmeticParser.ExpressionContext)context.left);
                var (right, typeRight) = VisitExpression((arithmeticParser.ExpressionContext)context.right);
                var op = context.op ?? throw new Exception();

                if ((typeLeft == "bool") && (typeRight == "bool"))
                {
                    type = "bool";

                    bool leftBool = left == "true";
                    bool rightBool = right == "true";
                    switch (op.Text)
                    {
                        case "&&":
                            return (SpecialFunctions.BoolToString(leftBool && rightBool), type);
                        case "||":
                            return (SpecialFunctions.BoolToString(leftBool || rightBool), type);
                        case "==":
                            return (SpecialFunctions.BoolToString(leftBool == rightBool), type);
                        default:
                            throw new InvalidOperationException();
                    }
                }

                else if (((typeLeft == "int") || (typeLeft == "double")) && ((typeRight == "int") || (typeRight == "double")))
                {
                    double leftDouble = Double.Parse(left, CultureInfo.InvariantCulture);
                    double rightDouble = Double.Parse(right, CultureInfo.InvariantCulture);

                    if ((typeRight == "int") && (typeLeft == "int"))
                    {
                        type = "int";
                    }
                    else
                    {
                        type = "double";
                    }

                    switch (op.Text)
                    {
                        case "+":
                            return ((leftDouble + rightDouble).ToString().Replace(',','.'), type);
                        case "-":
                            return ((leftDouble - rightDouble).ToString().Replace(',', '.'), type);
                        case "/":
                            if (rightDouble == 0)
                            {
                                throw new DivideByZeroException();
                            }
                            return ((leftDouble / rightDouble).ToString().Replace(',', '.'), type);
                        case "*":
                            return ((leftDouble * rightDouble).ToString().Replace(',', '.'), type);
                        default:
                            throw new InvalidOperationException();
                    }
                }

                else
                {
                    throw new InvalidOperationException();
                }
                
            }
            else if (isLparen)
            {
                return VisitExpression((arithmeticParser.ExpressionContext)context.evalue);
            }
            else if (isNegativeLparenExpr)
            {
                var (result, typeLocal) = VisitExpression((arithmeticParser.ExpressionContext)context.evalue);

                type = typeLocal;

                return (HandleNegativeSign(context, result), type);
            }
            else
            {
                var (result, typeLocal) = VisitAtom((arithmeticParser.AtomContext)context.avalue);

                type = typeLocal;

                return (HandleNegativeSign(context, result), type);
            }
        }

        /// <summary>
        /// Works with MINUS before number and NOT before bool
        /// </summary>
        /// <param name="context"></param>
        /// <param name="v"></param>
        private string HandleNegativeSign(arithmeticParser.ExpressionContext context, string v)
        {
            if ((v == "true") || (v == "false"))
            {
                var vBool = v == "true";

                int k = 0;
                if (context.GetChild(k).GetText() == "-")
                {
                    throw new InvalidOperationException();
                }

                while (context.GetChild(k).GetText() == "!")
                {                                           
                    vBool = !vBool;
                    ++k;
                }

                if (context.GetChild(k).GetText() == "-")
                {
                    throw new InvalidOperationException();
                }

                return SpecialFunctions.BoolToString(vBool);
            }
            else
            {

                var vDouble = Double.Parse(v, CultureInfo.InvariantCulture);
                int i = 0;
                if (context.GetChild(i).GetText() == "!")
                {
                    throw new InvalidOperationException();
                }

                while (context.GetChild(i).GetText() == "-")
                {                                           
                    vDouble = -vDouble;
                    ++i;
                }

                if (context.GetChild(i).GetText() == "!")
                {
                    throw new InvalidOperationException();
                }

                return vDouble.ToString().Replace(',', '.');
            }
        }

        /// <summary>
        /// Method for visiting file
        /// </summary>
        /// <param name="context"></param>
        public override (string value, string type) VisitFile(arithmeticParser.FileContext context)
        {
            // перебирает все выражения из файла, разделенные двоеточием
            for (int i = 0; i < context.ChildCount; ++i)
            {
                var c = context.GetChild(i);
                if (c as arithmeticParser.ExpressionContext != null)
                {
                    var v = Visit(c);

                    // возвращает значение единственного выражения!!
                    return (v);
                }
            }
            // непонятно
            return (null, null);
        }
    }
}
