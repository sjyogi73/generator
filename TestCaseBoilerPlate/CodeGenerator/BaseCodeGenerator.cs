using System.Collections.Generic;
using TestCaseBoilerplate.Models;

namespace TestCaseBoilerplate.CodeGenerator
{
    public abstract class BaseCodeGenerator
    {
        public abstract string GetClassString(string className, List<FunctionModel> functionsModels, bool publicFunc = true, bool privateFunc = false);
    }
}
