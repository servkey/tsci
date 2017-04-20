using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;
using System.CodeDom;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
namespace Codigo.Util
{

    class GeneracionCodigo
    {
        public const string Path = @".\Domain\";
        public const string PathACT = @".\Actors\";
        public Operaciones.ActivityModel.Base E { get; set; }

        public List<CodeCompileUnit> Units { get; set; }
        private CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");
        private CodeDomProvider providerService = CodeDomProvider.CreateProvider("CSharp");

        private CodeCompileUnit targetUnit;
        private CodeTypeDeclaration targetClass;
        
        public GeneracionCodigo()
        {
            Units = new List<CodeCompileUnit>();
            bool exists = System.IO.Directory.Exists(Path);

            if (!exists)
            {
                System.IO.Directory.CreateDirectory(Path);
                System.IO.Directory.CreateDirectory(Path + PathACT);
            }
        }
        public string GetSpace(Operaciones.ActivityModel.Base element)
        {
            string space = String.Empty;
            if (element is Operaciones.ActivityModel.Actor)
            {
                space = ".Actors";
            }
            return space;
        }

        public void Generar(Operaciones.ActivityModel.Base element)
        {
            E = element;
            string classname = element.Name;
            string outputFileName = "{0}.cs";
            string namespaceTmp = "{0}";
            outputFileName = String.Format(outputFileName, classname);

            string space = "DomainActivityModel";
            space += GetSpace(element); // ".Actors";

            outputFileName = Path + PathACT + outputFileName;
            

            targetUnit = new CodeCompileUnit();
            namespaceTmp = space;
            CodeNamespace samples = new CodeNamespace(namespaceTmp);
            samples.Imports.Add(new CodeNamespaceImport("System"));
            samples.Imports.Add(new CodeNamespaceImport("System.Collections.Generic"));
            samples.Imports.Add(new CodeNamespaceImport("System.Linq"));
            samples.Imports.Add(new CodeNamespaceImport("System.Runtime.Serialization"));
            samples.Imports.Add(new CodeNamespaceImport("System.ServiceModel"));
            samples.Imports.Add(new CodeNamespaceImport("System.Text"));


            targetClass = new CodeTypeDeclaration(classname);
            targetClass.IsClass = true;
            targetClass.TypeAttributes = TypeAttributes.Public | TypeAttributes.Sealed;
            samples.Types.Add(targetClass);
            targetUnit.Namespaces.Add(samples);


            AddAtributos(element);
            AddPropiedades(element);
            AddMetodo(element);
            //AddConstructor(element);
            Units.Add(targetUnit);
            GenerateCSharpCode(outputFileName, targetUnit);
        }

        public void AddMetodo(Operaciones.ActivityModel.Base element)
        {
            // Declaring a ToString method
            CodeMemberMethod toStringMethod = new CodeMemberMethod();

            toStringMethod.Attributes =
                MemberAttributes.Public | MemberAttributes.Override;
            toStringMethod.Name = "ToString";
            toStringMethod.ReturnType =
                new CodeTypeReference(typeof(System.String));

            List<CodeExpression> expresiones = new List<CodeExpression>();
            string formateo = String.Empty;
            int index = 0;

            foreach (Operaciones.ActivityModel.Util.Variable i in element.Attributes)
            {
                CodeFieldReferenceExpression itmp = new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), i.Name);
                formateo += " " + i.Name + " = {" + String.Format("{0}", index++) + "}, ";
                expresiones.Add(itmp);
            }

            // Declarando sentencia de retorno para ToString.
            CodeMethodReturnStatement returnStatement = new CodeMethodReturnStatement();

            // Regresar representación 
            string formattedOutput = "El objeto : " + Environment.NewLine +
                formateo;

            CodeMethodInvokeExpression cme  = new CodeMethodInvokeExpression(new CodeTypeReferenceExpression("System.String"), "Format", new CodePrimitiveExpression(formattedOutput));
            
            foreach (CodeExpression ce in expresiones)
            {
                cme.Parameters.Add(ce);
            }
            returnStatement.Expression = cme;
            toStringMethod.Statements.Add(returnStatement);
            targetClass.Members.Add(toStringMethod);
        }

        public void AddAtributos(Operaciones.ActivityModel.Base element)
        {

            foreach (Operaciones.ActivityModel.Util.Variable i in element.Attributes)
            {
                // Declaración de atributos
                CodeMemberField atributo = new CodeMemberField();

                atributo.Attributes = MemberAttributes.Private;
                atributo.Name = i.Name;

                atributo.Type = new CodeTypeReference(i.Tipo);

                atributo.Comments.Add(new CodeCommentStatement(
                    String.Format("Atributo {0} de {1}.", i.Name, element.Name)));
                targetClass.Members.Add(atributo);

            }
        }

        public void AddPropiedades(Operaciones.ActivityModel.Base element)
        {
            foreach (Operaciones.ActivityModel.Util.Variable i in element.Attributes)
            {

                // Declarando propiedades.
                CodeMemberProperty propiedad = new CodeMemberProperty();
                propiedad.Attributes =
                    MemberAttributes.Public | MemberAttributes.Final;
                
                propiedad.Name = i.Name.First().ToString().ToUpper() + i.Name.Substring(1);
                propiedad.HasGet = true;
                propiedad.Type = new CodeTypeReference(i.Tipo);
                propiedad.Comments.Add(new CodeCommentStatement(
                    String.Format("Propiedad {0}.", i.Name)));
                propiedad.GetStatements.Add(new CodeMethodReturnStatement(
                    new CodeFieldReferenceExpression(
                    new CodeThisReferenceExpression(), i.Name)));

                propiedad.SetStatements.Add(new CodeAssignStatement(
                    new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), i.Name),
                    new CodePropertySetValueReferenceExpression()));

                targetClass.Members.Add(propiedad);
            }
        }

        public void GenerateCSharpCode(string fileName, CodeCompileUnit targetUnit)
        {
            CodeGeneratorOptions options = new CodeGeneratorOptions();
            options.BracingStyle = "C";
            using (StreamWriter sourceWriter = new StreamWriter(fileName))
            {
                provider.GenerateCodeFromCompileUnit(
                    targetUnit, sourceWriter, options);
            }
        }
  

        public void Compilar()
        {
            CompilerParameters p = new CompilerParameters
            {
                GenerateInMemory = true,
                GenerateExecutable = false
            };

            p.ReferencedAssemblies.AddRange(new string[]{
                "System.dll",
                "Microsoft.CSharp.dll",
                "System.Core.dll",
                "System.Data.dll",
                "System.Runtime.Serialization.dll",
                "System.ServiceModel.dll",
                "System.Xml.dll",
                "System.Xml.Linq.dll",
            });
            p.OutputAssembly = String.Format(@".\DomainActivityModel.dll");
            //p.ReferencedAssemblies.Add(String.Format("{0}.exe", classname));

            CompilerResults results = provider.CompileAssemblyFromDom(p, Units.ToArray());

            String errorText = "";
            foreach (CompilerError compilerError in results.Errors)
                errorText += compilerError + "\n";
        }



    }
}