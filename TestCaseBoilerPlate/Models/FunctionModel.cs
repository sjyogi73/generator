using System.Collections.Generic;

namespace TestCaseBoilerplate.Models
{
    public class FunctionModel
    {
        public bool IsModule { get; set; }
        public string ClassName { get; set; }
        public string FunctioName { get; set; }
        public List<Parameter> Parameters { get; set; }
        public string ReturnType { get; set; }
        public string AccessSpecifier { get; set; }
        public bool IsGeneric { get; set; }

        public List<List<string>> TestCasePositive { get; set; } = new List<List<string>>();

        public List<List<string>> TestCaseNegative { get; set; } = new List<List<string>>();

        public string GetInstance()
        {
            return IsModule ? ClassName : $"(New {ClassName}())";
        }
    }
}
