using System;
using System.Collections.Generic;
using System.Linq;
using TestCaseBoilerplate.Models;

namespace TestCaseBoilerplate.CodeGenerator.VB.Net
{
    public sealed class VBCodeGenerator : BaseCodeGenerator
    {
        public override string GetClassString(string className, List<FunctionModel> functionsModels, bool publicFunc = true, bool privateFunc = false)
        {
            string classString = $"Imports System{Environment.NewLine}Imports System.Reflection{Environment.NewLine}Imports Microsoft.VisualStudio.TestTools.UnitTesting{Environment.NewLine}Imports Multicare.MHS.DataAccess.MHSDal{Environment.NewLine}{Environment.NewLine}<TestClass()>{Environment.NewLine}Public Class {className}IntegrationTests{Environment.NewLine}";
            classString += "\tPublic Sub New()" + Environment.NewLine;
            classString += "\t\t'Setting up the database Connection settings" + Environment.NewLine;
            classString += "\t\tMulticare.MHS.Platform.AplcFunctions.GAPP_EMPRESA = \"TESTEUT\" ' RGS_LerEmpresa()" + Environment.NewLine;
            classString += "\t\tPMS_CONECTAR()" + Environment.NewLine;
            classString += "\tEnd Sub" + Environment.NewLine + Environment.NewLine;
            var filteredFunc = functionsModels.FindAll(e => (e.AccessSpecifier == Constants.PublicSpecifier && publicFunc) || (e.AccessSpecifier == Constants.PrivateSpecifier && privateFunc));
            foreach (FunctionModel func in filteredFunc) classString += GetFunctionTests(className, func);
            classString += "End Class";
            return classString;
        }

        private string GetFunctionString(string className, FunctionModel functionsModel)
        {
            string functionString = "\t<DataTestMethod()>" + Environment.NewLine;
            if (functionsModel.Parameters.Count != 0)
            {
                functionString += $"\t<DataRow({string.Join(", ", functionsModel.Parameters.Select(e => GetDummyData(e)))})>" + Environment.NewLine;
                foreach (var data in functionsModel.TestCasePositive)
                    functionString += $"\t<DataRow({string.Join(", ", data)})>" + Environment.NewLine;
            }
            functionString += GetFunctionDefinition(functionsModel, "Void") + Environment.NewLine;
            if (functionsModel.IsModule)
            {
                bool isAdded = false;
                for (int i = 0; i < functionsModel.Parameters.Count; i++)
                {
                    if (IsKnowDataType(functionsModel.Parameters[i].DataType)) continue;
                    if (!isAdded)
                    {
                        functionString += $"\t\t'Arrange" + Environment.NewLine;
                        isAdded = true;
                    }
                    functionString += $"\t\tDim {functionsModel.Parameters[i].ParameterName} As New {functionsModel.Parameters[i].DataType}" + Environment.NewLine;
                    functionString += $"\t\t{functionsModel.Parameters[i].ParameterName}.Text =  CT_{functionsModel.Parameters[i].ParameterName}" + Environment.NewLine;
                }
                functionString += $"\t\t'Act" + Environment.NewLine;
                functionString += $"\t\t{functionsModel.ClassName}.{functionsModel.FunctioName}({string.Join(", ", functionsModel.Parameters.Select(e => e.ParameterName))})" + Environment.NewLine;
            }
            else
            {
                functionString += $"\t\t'Arrange" + Environment.NewLine;
                functionString += $"\t\tDim result As New {functionsModel.ClassName}" + Environment.NewLine;
                for (int i = 0; i < functionsModel.Parameters.Count; i++)
                {
                    if (IsKnowDataType(functionsModel.Parameters[i].DataType)) continue;
                    functionString += $"\t\tDim {functionsModel.Parameters[i].ParameterName} As New {functionsModel.Parameters[i].DataType}" + Environment.NewLine;
                    functionString += $"\t\t{functionsModel.Parameters[i].ParameterName}.Text =  CT_{functionsModel.Parameters[i].ParameterName}" + Environment.NewLine;
                }
                functionString += $"\t\t'Act" + Environment.NewLine;
                functionString += $"\t\tresult.{functionsModel.FunctioName}({string.Join(", ", functionsModel.Parameters.Select(e => e.ParameterName))})" + Environment.NewLine;
            }
            functionString += $"\t\t'Assert" + Environment.NewLine;
            functionString += $"\t\tAssert.AreEqual(1,1)" + Environment.NewLine;
            functionString += $"\tEnd Sub";
            return functionString + Environment.NewLine;
        }

        private string GetFunctionString(string className, FunctionModel functionsModel, string returnVal, string value, bool isEqualCompare = false, String customData = "")
        {
            string functionString = "\t<DataTestMethod()>" + Environment.NewLine;
            if (functionsModel.Parameters.Count != 0)
            {
                functionString += $"\t<DataRow({string.Join(", ", functionsModel.Parameters.Select(e => GetDummyData(e)))})>" + Environment.NewLine;
                foreach(var data in (!isEqualCompare ? functionsModel.TestCasePositive : functionsModel.TestCaseNegative))
                    functionString += $"\t<DataRow({GetData(functionsModel.Parameters, data)}>" + Environment.NewLine;
            }
            functionString += GetFunctionDefinition(functionsModel, returnVal) + Environment.NewLine;
            functionString += $"\t\t'Arrange" + Environment.NewLine;
            functionString += $"\t\tDim result As {functionsModel.ReturnType}" + Environment.NewLine;
            for(int i = 0; i < functionsModel.Parameters.Count; i++)
            {
                if (IsKnowDataType(functionsModel.Parameters[i].DataType)) continue;
                functionString += $"\t\tDim {functionsModel.Parameters[i].ParameterName} As New {functionsModel.Parameters[i].DataType}" + Environment.NewLine;
                functionString += $"\t\t{functionsModel.Parameters[i].ParameterName}.Text =  CT_{functionsModel.Parameters[i].ParameterName}" + Environment.NewLine;
            }
            functionString += $"\t\t'Act" + Environment.NewLine;
            functionString += $"\t\tresult = {functionsModel.GetInstance()}.{functionsModel.FunctioName}({string.Join(", ", functionsModel.Parameters.Select(e => e.ParameterName))})" + Environment.NewLine;
            functionString += $"\t\t'Assert" + Environment.NewLine;
            string comparer = functionsModel.ReturnType == "String" ? "Trim(result)" : (!IsKnowDataType(functionsModel.ReturnType) ? "0" : "result");
            functionString += $"\t\tAssert.{(isEqualCompare || (!IsKnowDataType(functionsModel.ReturnType)) ? "AreEqual": "AreNotEqual")}({comparer}, {value})" + Environment.NewLine;
            functionString += $"\tEnd Sub";
            return functionString + Environment.NewLine;
        }

        private static bool IsKnowDataType(string type)
        {
            switch(type.ToLower())
            {
                case "string":
                case "boolean":
                case "int16":
                case "short":
                case "int64":
                case "double":
                case "int32":
                case "integer":
                    return true;
                default:
                    return false;
                
            }
        }

        private string GetData(List<Parameter> paramData, List<string> data)
        {
            string dt = "";
            for(int i = 0; i < paramData.Count;i++)
            {
                string dataString = data.Count > i ? data[i] : null;
                switch (paramData[i].DataType.ToLower())
                {
                    case "boolean":
                        dt += dataString ?? "False";
                        break;
                    case "string":
                        dt += dataString != null ? $"\"{dataString}\"" : "\"\"";
                        break;
                    case "int16":
                    case "short":
                        dt += dataString != null ? $"CType({dataString}, Int16)" : "CType(0, Int16)";
                        break;
                    case "int64":
                    case "double":
                        dt += dataString != null ? $"CType({dataString}, Int64)" : "CType(0, Int64)";
                        break;
                    case "int32":
                    case "integer":
                        dt += dataString != null ? dataString : "0";
                        break;
                    default:
                        break;
                }
                dt += ", ";
            }
            return dt.Remove(dt.Length - 2, 2);
        }

        private string GetFunctionTests(string className, FunctionModel functionsModel)
        {
            string passValue = functionsModel.ReturnType, failValue;
            string cutomData = "";
            switch (functionsModel.ReturnType.ToLower())
            {
                case Constants.VoidType:
                    return GetFunctionString(className, functionsModel);
                case "boolean":
                    passValue = "True";
                    failValue = "False";
                    break;
                case "string":
                    failValue = $"String.Empty";
                    break;
                case "int16":
                case "short":
                    cutomData = "0";
                    failValue = "CType(0, Int16)";
                    break;
                case "int64":
                case "double":
                    cutomData = "0";
                    failValue = "CType(0, Int64)";
                    break;
                case "int32":
                case "integer":
                    failValue = "0";
                    break;
                default:
                    passValue = "1";
                    failValue = $"0";
                    break;
            }
            return GetFunctionString(className, functionsModel, passValue, failValue, customData : cutomData) + Environment.NewLine + GetFunctionString(className, functionsModel, cutomData != "" ? cutomData: failValue, failValue, true, customData: cutomData) + Environment.NewLine;
        }

        private string GetFunctionDefinition(FunctionModel functionsModel, string returnVal)
        {
            return $"\tPublic Sub {functionsModel.FunctioName}_send_{string.Join("_", functionsModel.Parameters.Select(e => e.ParameterName))}_return_{returnVal.Replace('.', '_')}({string.Join(", ", functionsModel.Parameters.Select((e, i) => GetVarDeclaration(e, i)))})";
        }
        private string GetVarDeclaration(Parameter parameter, int index)
        {
            if(!IsKnowDataType(parameter.DataType)) return $"ByVal CT_{parameter.ParameterName} As string"; 
            return $"ByVal {parameter.ParameterName} As {parameter.DataType}";
        }

        private string GetDummyData(Parameter parameter)
        {
            switch(parameter.DataType.ToLower())
            {
                case "string":
                    return "\"\"";
                case "int64":
                case "Double":
                    return "CType(0, Int64)";
                case "int16":
                case "short":
                    return "CType(0, Int16)";
                case "int32":
                case "integer":
                    return "0";
                case "boolean":
                    return "False";
                default:
                    return "\"\"";
            }
        }

    }
}
