//#define RELATORIO_RESUMIDO
#define RELATORIO_DETALHADO

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Programa01
{
    interface IRelatorio
    {
        string Nome { get; set; }
        void Imprimir();
    }

    class Relatorio : IRelatorio
    {
        public string Nome { get; set; }
        readonly IList<Venda> vendas;

        public Relatorio(string nome)
        {
            this.Nome = nome;
            vendas = JsonConvert.DeserializeObject<List<Venda>>(File.ReadAllText("Vendas.json"));
        }

        public void Imprimir()
        {
            Cabecalho();
//#if RELATORIO_RESUMIDO
            ListagemResumida();
//#endif
//#if RELATORIO_DETALHADO
            ListagemDetalhada();
//#endif
            Console.WriteLine();
        }

        [Conditional("RELATORIO_RESUMIDO"),
            Conditional("RELATORIO_DETALHADO")]
        void Cabecalho()
        {
            Console.WriteLine(this.Nome);
            Console.WriteLine("=============================");
        }

        [Conditional("RELATORIO_DETALHADO")]
        void ListagemDetalhada()
        {
            Console.WriteLine("Data          Produto         Preco       TipoPagamento Nome                  Cidade                Região                Pais");
            Console.WriteLine("==========================================================================================================================================");

            foreach (var venda in vendas)
            {
                Console.WriteLine("{0}  {1}  {2}  {3}  {4}  {5}  {6}  {7}"
                            , venda.Data, venda.Produto, venda.Preco, venda.TipoPagamento, venda.Nome, venda.Cidade, venda.Estado, venda.Pais);
            }
            Console.WriteLine();
        }

        [Conditional("RELATORIO_RESUMIDO")]
        void ListagemResumida()
        {
            Console.WriteLine("Data          Produto         Preco       TipoPagamento   ");
            Console.WriteLine("==========================================================");

            
            foreach (var venda in vendas)
            {
                Console.WriteLine("{0}  {1}  {2}  {3}"
                    , venda.Data, venda.Produto, venda.Preco, venda.TipoPagamento);
            }
            Console.WriteLine();
        }
    }
}
