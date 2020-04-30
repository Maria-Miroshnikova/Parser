using System.Collections.Generic;

namespace myLovelyProject
{
    /// <summary>
    /// This delegate presents realization of function
    /// </summary>
    public delegate string givenFunction(List<string> parameters);

    /// <summary>
    /// This class presents the function-element of dictionary, storing data about functions and variables
    /// </summary>
    public class DataFunction : IData
    {
        private string name;
        private List<string> typesInParameters;
        private string typeOutParameters;
        private givenFunction functionRealization;

        public string Name => name;
        public List<string> TypesInParameters => typesInParameters;
        public string TypeOutParameters => typeOutParameters;
        public givenFunction FunctionRealization => functionRealization;

        public DataFunction(string nameOfFunction = null, List<string> typesIn = null,
                            string typeOut = null, givenFunction function = null)
        {
            this.name = nameOfFunction;
            this.typesInParameters = typesIn;
            this.typeOutParameters = typeOut;
            this.functionRealization = function;
        }

    }
}
