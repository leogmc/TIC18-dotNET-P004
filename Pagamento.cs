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
        public DateTime dateTime { get; set; } = DateTime.Now;

        public void RealizarPagamento(double valor)
        {
            
        }

    }

    public class CartaoDeCredito : Pagamento 
    {
        public string NumCartao { get; set;}

        public void RealizarPagamento(double valor) {
            
        }
    }

    public class TransfarenciaPix : Pagamento 
    {
        public string Chave { get; set;}

        public void RealizarPagamento(double valor) {
            
        }
    }

    public class EmDinheiro : Pagamento
    {
        public void RealizarPagamento(double valor) {
            
        }
    }
}