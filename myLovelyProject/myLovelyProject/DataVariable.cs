
namespace myLovelyProject
{
    /// <summary>
    /// This class presents the variable-element of dictionary, storing data about functions and variables
    /// </summary>
    public class DataVariable : IData
    {
        private string name;
        private string type;
        private string value;

        public string Name => name;
        public string Type => type;
        public string Value => value;

        public DataVariable(string nameOfVariable = null, string typeOfVariable = null, string valueOfVariable = null)
        {
            this.name = nameOfVariable;
            this.type = typeOfVariable;
            this.value = valueOfVariable;
        }
    }
}
