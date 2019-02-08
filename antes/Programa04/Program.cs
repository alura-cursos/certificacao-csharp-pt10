using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Programa04
{
    //Gerar código em tempo de execução usando expressões CodeDom e lambda

    class Program
    {
        static void Main(string[] args)
        {
            //TAREFA: Utilizar código C# para gerar código C#,
            //          produzindo a classe Funcionario:

            //para mais informações:
            //https://docs.microsoft.com/pt-br/dotnet/framework/reflection-and-codedom/using-the-codedom

            /*
            namespace RecursosHumanos
            {
                using system;
                public class Funcionario
                {
                    public string nome;
                    public decimal salario;
                    public Funcionario(string nome, decimal salario)
                    {
                    }
                }
            }
            */

            //Tarefa 1: criar uma unidade de compilação
            CodeCompileUnit unit = new CodeCompileUnit();

            //Tarefa 2: criar o namespace RecursosHumanos
            CodeNamespace codeNamespace = new CodeNamespace("RecursosHumanos");

            //Tarefa 2.1: importar o namespace System
            CodeNamespaceImport import = new CodeNamespaceImport("System");
            codeNamespace.Imports.Add(import);

            //Tarefa 2.2: criar a classe Funcionario
            CodeTypeDeclaration funcionario = new CodeTypeDeclaration("Funcionario");

            //Tarefa 2.3: criar o campo nome
            CodeMemberField nome = new CodeMemberField(typeof(string), "nome");
            nome.Attributes = MemberAttributes.Public;
            funcionario.Members.Add(nome);

            //Tarefa 2.4: criar o campo salário
            CodeMemberField salario = new CodeMemberField(typeof(decimal), "salario");
            salario.Attributes = MemberAttributes.Public;
            funcionario.Members.Add(salario);


            //Tarefa 2.5: criar o construtor da classe
            CodeConstructor construtor = new CodeConstructor();
            construtor.Attributes = MemberAttributes.Public;

            CodeParameterDeclarationExpression paramNome =
                new CodeParameterDeclarationExpression(typeof(string), "nome");
            construtor.Parameters.Add(paramNome);

            CodeParameterDeclarationExpression paramSalario =
                new CodeParameterDeclarationExpression(typeof(decimal), "salario");
            construtor.Parameters.Add(paramSalario);

            funcionario.Members.Add(construtor);


            codeNamespace.Types.Add(funcionario);
            unit.Namespaces.Add(codeNamespace);

            //Tarefa 3: cria o provedor de modelo de código
            CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");

            //Tarefa 4: gerar código e salva o arquivo
            using (var streamWriter = new StreamWriter("Funcionario.cs"))
            {
                provider.GenerateCodeFromCompileUnit(unit, streamWriter,
                    new CodeGeneratorOptions());
            }

        }
    }
}
