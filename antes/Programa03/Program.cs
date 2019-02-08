//#define RELATORIO_DETALHADO
#define RELATORIO_RESUMIDO
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Programa03
{
    //Usar reflection
    class Program
    {
        static void Main(string[] args)
        {
            Relatorio relatorio = new Relatorio("Relatório de Vendas");
            relatorio.Imprimir();

            Console.WriteLine();
            if (Attribute.IsDefined(typeof(Venda), typeof(SerializableAttribute)))
            {
                Console.WriteLine("A classe Venda DEFINE o atributo Serializable");
            }
            else
            {
                Console.WriteLine("A classe Venda NÃO DEFINE o atributo Serializable");
            }
            Console.WriteLine();

            //TAREFA 1: 
            Console.WriteLine("OBTENDO O TIPO DO RELATÓRIO");
            Console.WriteLine("===========================");




            //TAREFA 2: 
            Console.WriteLine();
            Console.WriteLine("OBTENDO OS MEMBROS DO RELATÓRIO");
            Console.WriteLine("===============================");




            //TAREFA 3: 
            Console.WriteLine();
            Console.WriteLine("MODIFICANDO NOME VIA REFLECTION");
            Console.WriteLine("===============================");




            //TAREFA 4: 
            Console.WriteLine();
            Console.WriteLine("TIPOS DO ASSEMBLY");
            Console.WriteLine("QUE IMPLEMENTAM A INTERFACE IRelatorio");
            Console.WriteLine("======================================");




            //TAREFA 5: 
            Console.WriteLine();
            Console.WriteLine("USANDO LINQ PARA VER TIPOS DO ASSEMBLY");
            Console.WriteLine("QUE IMPLEMENTAM A INTERFACE IRelatorio");
            Console.WriteLine("======================================");

            Console.ReadLine();
        }
    }
}
