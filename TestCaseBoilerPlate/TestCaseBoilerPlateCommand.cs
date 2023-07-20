using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using EnvDTE80;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using TestCaseBoilerplate.Forms;
using TestCaseBoilerplate.Models;
using System.Linq;
using Task = System.Threading.Tasks.Task;
using System.Windows.Forms;
using Microsoft.CodeAnalysis.VisualBasic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.CSharp;

namespace TestCaseBoilerplate
{
    /// <summary>
    /// Command handler
    /// </summary>
    public sealed class TestCaseBoilerPlateCommand
    {
        /// <summary>
        /// Command ID.
        /// </summary>
        public const int CommandId = 0x0100;

        /// <summary>
        /// Command menu group (command set GUID).
        /// </summary>
        public static readonly Guid CommandSet = new Guid("d23cce83-5a90-453a-89c8-4b22f5d23c76");

        /// <summary>
        /// VS Package that provides this command, not null.
        /// </summary>
        private readonly AsyncPackage package;

        /// <summary>
        /// Initializes a new instance of the <see cref="TestCaseBoilerPlateCommand"/> class.
        /// Adds our command handlers for menu (commands must exist in the command table file)
        /// </summary>
        /// <param name="package">Owner package, not null.</param>
        /// <param name="commandService">Command service to add command to, not null.</param>
        private TestCaseBoilerPlateCommand(AsyncPackage package, OleMenuCommandService commandService)
        {
            this.package = package ?? throw new ArgumentNullException(nameof(package));
            commandService = commandService ?? throw new ArgumentNullException(nameof(commandService));

            var menuCommandID = new CommandID(CommandSet, CommandId);
            var menuItem = new MenuCommand(this.Execute, menuCommandID);
            commandService.AddCommand(menuItem);
        }

        /// <summary>
        /// Gets the instance of the command.
        /// </summary>
        public static TestCaseBoilerPlateCommand Instance
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the service provider from the owner package.
        /// </summary>
        private Microsoft.VisualStudio.Shell.IAsyncServiceProvider ServiceProvider
        {
            get
            {
                return this.package;
            }
        }

        /// <summary>
        /// Initializes the singleton instance of the command.
        /// </summary>
        /// <param name="package">Owner package, not null.</param>
        public static async Task InitializeAsync(AsyncPackage package)
        {
            // Switch to the main thread - the call to AddCommand in TestCaseBoilerPlateCommand's constructor requires
            // the UI thread.
            await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync(package.DisposalToken);

            OleMenuCommandService commandService = await package.GetServiceAsync((typeof(IMenuCommandService))) as OleMenuCommandService;
            Instance = new TestCaseBoilerPlateCommand(package, commandService);
        }

        /// <summary>
        /// This function is the callback used to execute the command when the menu item is clicked.
        /// See the constructor to see how the menu item is associated with this function using
        /// OleMenuCommandService service and MenuCommand class.
        /// </summary>
        /// <param name="sender">Event sender.</param>
        /// <param name="e">Event args.</param>
        private async void Execute(object sender, EventArgs e)
        {
            await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync();

            DTE2 dte = await ServiceProvider.GetServiceAsync(typeof(SDTE)).ConfigureAwait(true) as DTE2;
            List<FunctionModel> functionModels = AnalyzeClassFile(dte.ActiveDocument.FullName, dte.ActiveDocument.Language);

            SelectedFunctionDetails selectedFunctionDetails = new SelectedFunctionDetails();
            selectedFunctionDetails.OnSaveClicked += (s, args) =>
            {

                OutputConfig outputConfig = selectedFunctionDetails.outputConfig;
                outputConfig.Language = dte.ActiveDocument.Language;
                bool executionResult = new Executor(functionModels, outputConfig).Execute();
                MessageBox.Show("Test Generated Successfully");
            };
            selectedFunctionDetails.ShowDialog(functionModels);
        }

        public static List<FunctionModel> AnalyzeVBClassFile(string fileFullName)
        {
            SyntaxTree tree = VisualBasicSyntaxTree.ParseText(GetFile(fileFullName));
            List<FunctionModel> functionModelList = new List<FunctionModel>();
            try
            {
                 var methods2 = tree.GetRoot().DescendantNodes().OfType<MethodStatementSyntax>();
                var methods3 = tree.GetRoot().DescendantNodes().OfType<ClassDeclarationSyntax>();

                Microsoft.CodeAnalysis.VisualBasic.Syntax.CompilationUnitSyntax root = tree.GetCompilationUnitRoot();
                var mem = root.Members;
                if (mem.First() is NamespaceBlockSyntax nameSpaceBlock)
                {
                    mem = nameSpaceBlock.Members;
                }
                // Iterate over the members and identify class declarations
                foreach (SyntaxNode member in mem)
                {
                    if (member is TypeBlockSyntax classBlock)
                    {
                        string className = classBlock.BlockStatement.Identifier.Text;
                        bool isModule = member is ModuleBlockSyntax;
                        // Iterate over the members of the class and identify function declarations
                        foreach (SyntaxNode classMember in classBlock.Members)
                        {
                            if (classMember is MethodBlockSyntax methodBlock)
                            {
                                try
                                {
                                    string accessSpecifier = methodBlock.SubOrFunctionStatement.Modifiers.ToString();

                                    // Retrieve the function name
                                    string methodName = methodBlock.SubOrFunctionStatement.Identifier.Text;

                                    // Retrieve the parameter list
                                    Microsoft.CodeAnalysis.VisualBasic.Syntax.ParameterListSyntax parameterList = methodBlock.SubOrFunctionStatement.ParameterList;
                                    List<string> parameters = new List<string>();
                                    List<Parameter> paramters = new List<Parameter>();
                                    foreach (Microsoft.CodeAnalysis.VisualBasic.Syntax.ParameterSyntax item in parameterList.Parameters)
                                    {
                                        var dataType = item.AsClause.Type.ToString();
                                        var paramName = item.Identifier.ToString();
                                        if (dataType != null && paramName != null)
                                        {
                                            paramters.Add(new Parameter() { DataType = dataType, ParameterName = paramName.Replace("()", "") });
                                        }
                                    }
                                    bool isGeneric = methodBlock.SubOrFunctionStatement.TypeParameterList != null;

                                    // Retrieve the return type
                                    Microsoft.CodeAnalysis.VisualBasic.Syntax.TypeSyntax returnType = methodBlock.SubOrFunctionStatement.AsClause?.Type;
                                    FunctionModel funcModel = new FunctionModel()
                                    {
                                        IsModule = isModule,
                                        ClassName = className,
                                        IsGeneric = isGeneric,
                                        AccessSpecifier = accessSpecifier.ToLower(),
                                        FunctioName = methodName,
                                        ReturnType = returnType?.ToString() ?? "Void",
                                        Parameters = paramters
                                    };
                                    funcModel.ReturnType = funcModel.IsGeneric ? "Object" : funcModel.ReturnType;
                                    functionModelList.Add(funcModel);
                                }
                                catch (Exception e)
                                {

                                }
                            }
                        }
                    }
                }

                //var methods = tree.GetRoot().DescendantNodes().OfType<MethodStatementSyntax>();
                //foreach (var node in methods)
                //{
                //    List<Parameter> paramters = new List<Parameter>();
                //    foreach (var item in node.ParameterList.Parameters)
                //    {
                //        var dataType = item.AsClause.Type.ToString();
                //        var paramName = item.Identifier.ToString();
                //        if (dataType != null && paramName != null)
                //        {
                //            paramters.Add(new Parameter() { DataType = dataType, ParameterName = paramName.Replace("()", "") });
                //        }
                //    }
                //    FunctionModel funcModel = new FunctionModel()
                //    {
                //        IsGeneric = node.ToFullString().Contains("(Of"),
                //        AccessSpecifier = GetAccessSpecifier(node.Modifiers.ToString()),
                //        FunctioName = node.Identifier.ValueText,
                //        ReturnType = node.AsClause == null ? Constants.VoidType : node.AsClause.Type.ToString(),
                //        Parameters = paramters
                //    };
                //    funcModel.ReturnType = funcModel.IsGeneric ? "Object" : funcModel.ReturnType;
                //    functionModelList.Add(funcModel);
                //}
            }
            catch (Exception e)
            {

            }
            return functionModelList;
        }


        public static List<FunctionModel> AnalyzeCSharpClassFile(string fileFullName)
        {
            SyntaxTree tree = CSharpSyntaxTree.ParseText(GetFile(fileFullName));

            List<FunctionModel> functionModelList = new List<FunctionModel>();

            IEnumerable<MethodDeclarationSyntax> methods = tree.GetRoot().DescendantNodes().OfType<MethodDeclarationSyntax>();
            foreach (var node in methods)
            {
                List<Parameter> paramters = new List<Parameter>();
                foreach (var item in node.ParameterList.Parameters)
                {
                    string dataType = item.Type.GetText().ToString();
                    var paramName = item.Identifier.ValueText;
                    if (dataType != null && paramName != null)
                    {
                        paramters.Add(new Parameter() { DataType = dataType, ParameterName = paramName });
                    }
                }

                functionModelList.Add(
                    new FunctionModel()
                    {
                        AccessSpecifier = GetAccessSpecifier(node.Modifiers.ToString()),
                        FunctioName = node.Identifier.ValueText,
                        ReturnType = node.ReturnType.GetText().ToString(),
                        Parameters = paramters
                    }
                    );
            }
            return functionModelList;
        }

        public static List<FunctionModel> AnalyzeClassFile(string fileFullName, string lanaguage)
        {
            return lanaguage == Constants.CSharpLanguage ? AnalyzeCSharpClassFile(fileFullName) : AnalyzeVBClassFile(fileFullName);
        }

        public static string GetFile(string fileFullName)
        {
            return File.ReadAllText(fileFullName);
        }

        public static string GetAccessSpecifier(string modifier)
        {
            if (modifier.ToLower().Contains(Constants.PublicSpecifier)) return Constants.PublicSpecifier;
            else if (modifier.ToLower().Contains(Constants.ProtectedSpecifier)) return Constants.ProtectedSpecifier;
            //else if (modifier.ToLower().Contains(Constants.PrivateSpecifier))
            return Constants.PrivateSpecifier;
        }

        public static void RedirectAssembly(string shortName, Version targetVersion, string publicKeyToken)
        {
            //ResolveEventHandler handler = null;

            //handler = (sender, args) => {
            //    // Use latest strong name & version when trying to load SDK assemblies
            //    var requestedAssembly = new AssemblyName(args.Name);
            //    if (requestedAssembly.Name != shortName)
            //        return null;

            //    requestedAssembly.Version = targetVersion;
            //    requestedAssembly.SetPublicKeyToken(new AssemblyName("x, PublicKeyToken=" + publicKeyToken).GetPublicKeyToken());
            //    requestedAssembly.CultureInfo = CultureInfo.InvariantCulture;

            //    AppDomain.CurrentDomain.AssemblyResolve -= handler;

            //    return Assembly.Load(requestedAssembly);
            //};
            //AppDomain.CurrentDomain.AssemblyResolve += handler;
        }
    }
}
