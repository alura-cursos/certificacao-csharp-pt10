//#define RELATORIO_DETALHADO
#define RELATORIO_RESUMIDO
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Programa03
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
            ListagemResumida();
            ListagemDetalhada();
            Console.WriteLine();
        }

        [Conditional("RELATORIO_DETALHADO"), Conditional("RELATORIO_RESUMIDO")]
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

            Attribute a = Attribute.GetCustomAttribute(typeof(Venda), typeof(FormatoDetalhadoAttribute));
            FormatoDetalhadoAttribute formatoDetalhado = (FormatoDetalhadoAttribute)a;

            foreach (var venda in vendas)
            {
                //Console.WriteLine("{0}  {1}  {2}  {3}  {4}  {5}  {6}  {7}"
                Console.WriteLine(formatoDetalhado.Formato
                            , venda.Data, venda.Produto, venda.Preco, venda.TipoPagamento, venda.Nome, venda.Cidade, venda.Estado, venda.Pais);
            }
        }

        [Conditional("RELATORIO_RESUMIDO")]
        void ListagemResumida()
        {
            Console.WriteLine("Data          Produto         Preco       TipoPagamento   ");
            Console.WriteLine("==========================================================");

            Attribute a = Attribute.GetCustomAttribute(typeof(Venda), typeof(FormatoResumidoAttribute));
            FormatoResumidoAttribute formatoReduzido = (FormatoResumidoAttribute)a;

            foreach (var venda in vendas)
            {
                //Console.WriteLine("{0}  {1}  {2}  {3}"
                Console.WriteLine(formatoReduzido.Formato
                    , venda.Data, venda.Produto, venda.Preco, venda.TipoPagamento);
            }
        }
    }
}
