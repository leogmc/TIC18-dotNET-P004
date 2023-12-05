using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace atividadeAv
{
    public class Pagamento : IPagavel
    {
        public string Descricao { get; set; }
        public double ValorBruto { get; set; }
        public double Desconto { get; set; } = 0;
        public DateTime DateTime { get; set; } = DateTime.Now;

        public void RealizarPagamento(double valor)
        {
            // Implementação específica do pagamento
            Console.WriteLine($"Realizando pagamento no valor de {valor}");
        }
    }

    public class CartaoDeCredito : Pagamento
    {
        public string NumCartao { get; set; }

        public new void RealizarPagamento(double valor)
        {
            Console.WriteLine("Numero do cartão: ");
            NumCartao = Console.ReadLine();

            Console.WriteLine($"O valor de {valor} foi pago com cartão de crédito.");
        }
    }

    public class TransfarenciaPix : Pagamento
    {
        public new void RealizarPagamento(double valor)
        {
            Console.WriteLine("Chave Pix: ");
            string chavePix = Console.ReadLine();

            Console.WriteLine($"O valor de {valor} foi pago com Pix: {chavePix}");
        }
    }

    public class EmDinheiro : Pagamento
    {
        public new void RealizarPagamento(double valor)
        {
            Console.WriteLine($"O valor de {valor} foi pago em dinheiro.");
        }
    }
}
