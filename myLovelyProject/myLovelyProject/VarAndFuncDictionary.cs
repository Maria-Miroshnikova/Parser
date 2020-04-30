using System;
using System.Collections.Generic;
using System.Globalization;

namespace myLovelyProject
{
    /// <summary>
    /// This class presents dictionary, storing data about functions and variables.
    /// Key: name of item - so there is no functions and variables with the same names;
    /// Value: data about item;
    /// Base items: functions Max, Min, Sqrt, Abs.
    /// </summary>
    public class VarAndFuncDictionary
    {
        private Dictionary<string, IData> varAndFuncDictionary;

        /// <summary>
        /// Base functions, which don`t require definition from outside.
        /// </summary>
        private givenFunction Max;
        private givenFunction Min;
        private givenFunction Sqrt;
        private givenFunction Abs;

        public VarAndFuncDictionary()
        {
            this.varAndFuncDictionary = new Dictionary<string, IData>();

            this.Max = list => (Math.Max(Double.Parse(list[0], CultureInfo.InvariantCulture), Double.Parse(list[1], CultureInfo.InvariantCulture))).ToString();
            var listInTypesMax = new List<string>();
            listInTypesMax.Add("double"); listInTypesMax.Add("double");
            this.AddFunction("Max", listInTypesMax, "double", this.Max);

            this.Min = list => (Math.Min(Double.Parse(list[0], CultureInfo.InvariantCulture), Double.Parse(list[1], CultureInfo.InvariantCulture))).ToString();
            var listInTypesMin = new List<string>();
            listInTypesMin.Add("double"); listInTypesMin.Add("double");
            this.AddFunction("Min", listInTypesMin, "double", this.Min);

            this.Sqrt = list => (Math.Sqrt(Double.Parse(list[0], CultureInfo.InvariantCulture))).ToString();
            var listInTypeSqrt = new List<string>();
            listInTypeSqrt.Add("double");
            this.AddFunction("Sqrt", listInTypeSqrt, "double", this.Sqrt);

            this.Abs = list => (Math.Abs(Double.Parse(list[0], CultureInfo.InvariantCulture))).ToString();
            var listInTypeAbs = new List<string>();
            listInTypeAbs.Add("double");
            this.AddFunction("Abs", listInTypeAbs, "double", this.Abs);
        }

        /// <summary>
        /// Method, which adds variable-element to the dictionary.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <param name="value"></param>
        public void AddVariable(string name, string type, string value)
        {
            var newVariable = new DataVariable(name, type, value);
            varAndFuncDictionary.Add(newVariable.Name, newVariable);
        }

        /// <summary>
        /// Method, which adds function-element to the dictionary.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="typesInParam"></param>
        /// <param name="typeOutParam"></param>
        /// <param name="funcRealization"></param>
        public void AddFunction(string name, List<string> typesInParam, string typeOutParam, givenFunction funcRealization)
        {
            var newFunction = new DataFunction(name, typesInParam, typeOutParam, funcRealization);
            varAndFuncDictionary.Add(newFunction.Name, newFunction);
        }

        /// <summary>
        /// Method, which answers if dictionary contains element with given name.
        /// </summary>
        /// <param name="name"></param>
        public bool ContainsKey(string name)
        {
            return varAndFuncDictionary.ContainsKey(name);
        }

        /// <summary>
        /// Method, which tries get data about element with given name from dictionary.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public bool TryGetValue(string name, out IData value)
        {
            return varAndFuncDictionary.TryGetValue(name, out value);
        }
    }
}
