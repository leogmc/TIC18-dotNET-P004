using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace 
{
    public class Treino
    {
        public string Tipo { get; set; }
        
        public string Objetivo { get; set; }
        public List<Exercicio> ListaExercicios { get; set; }
        public int DuracaoEstimadaMinutos { get; set; }
        public DateTime DataInicio { get; set; }
        public int VencimentoDias { get; set; }
        public Treinador TreinadorResponsavel { get; set; }
        public List<(Cliente, int)> ClientesAvaliacao { get; set; }
    }
}