using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace atividadeAv
{
    public class Exercicio
    {
        public string GrupoMuscular { get; set; }
        public int Series { get; set; }
        public int Repeticoes { get; set; }
        public int TempoIntervaloSegundos { get; set; }
        
        // Construtor que aceita os parâmetros durante a criação do objeto
        public Exercicio(string grupoMuscular, int series, int repeticoes, int tempoIntervaloSegundos)
        {
            GrupoMuscular = grupoMuscular;
            Series = series;
            Repeticoes = repeticoes;
            TempoIntervaloSegundos = tempoIntervaloSegundos;
        }
    }
}