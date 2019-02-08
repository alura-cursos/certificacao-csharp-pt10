using System;

namespace Programa01
{
    //Criar e aplicar atributos
    class Program
    {
        static void Main(string[] args)
        {
            Relatorio relatorio = new Relatorio("Relatório de Vendas");
            relatorio.Imprimir();

            //TAREFA 1: Imprimir relatório detalhado OU resumido de acordo com a compilação

            //TAREFA 2: Verificar se a classe Venda define o atributo [Serializable]

            if (Attribute.IsDefined(typeof(Venda), typeof(SerializableAttribute)))
            {
                Console.WriteLine("A classe Venda DEFINE o atributo Serializable");
            }
            else
            {
                Console.WriteLine("A classe Venda NÃO DEFINE o atributo Serializable");
            }

            //TAREFA 3: Impedir a serialização do campo nome do comprador

            //TAREFA 4: Definir na classe Venda os formatos de impressão detalhada e resumida

            Console.ReadLine();
        }
    }
}
