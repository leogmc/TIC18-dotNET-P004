using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace atividadeAv
{
    public class Plano
    {
        public string Titulo { get; set; }
        public double Valor { get; set; }

        public Plano(string titulo, double valor)
        {
            Titulo = titulo;
            Valor = valor;
        }

    }

}
