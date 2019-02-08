using System;

namespace Programa04._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<float, float> metade = quo => quo / 2;
            Console.WriteLine("Metade de 9 é {0}", metade(9));

            //TAREFA: Recriar a Função acima, 
            //porém usando árvore de expressões LINQ

            Console.ReadLine();
        }
    }
}