using System;
using System.Collections.Generic;
using System.IO;
using TestCaseBoilerplate.CodeGenerator;
using TestCaseBoilerplate.CodeGenerator.VB.Net;
using TestCaseBoilerplate.Models;

namespace TestCaseBoilerplate
{
    public sealed class Executor
    {
        public List<FunctionModel> FunctionModels;

        public OutputConfig OutputConfig;

        private readonly BaseCodeGenerator CodeGenerator;

        public Executor(List<FunctionModel> functionModels, OutputConfig outputConfig)
        {
            FunctionModels = functionModels;
            OutputConfig = outputConfig;
            CodeGenerator = outputConfig.Language == "Basic" ? new VBCodeGenerator() : null;
        }
        
        public bool Execute()
        {
            try
            {
                if (!File.Exists(OutputConfig.OutputFileFullName)) File.Create(OutputConfig.OutputFileFullName).Close();
                File.WriteAllText(OutputConfig.OutputFileFullName, CodeGenerator.GetClassString(Path.GetFileNameWithoutExtension(OutputConfig.OutputFileFullName), FunctionModels, OutputConfig.AllPublic, OutputConfig.AllPrivate)); ;
            }
            catch
            {
                return false;
            }
            return true;
        }

        public string GetVBClass()
        {
            return "";
        }

        public string GetVBString()
        {
            return "";
        }
    }
}
