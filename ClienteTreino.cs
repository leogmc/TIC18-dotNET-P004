using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace atividadeAv  
{
    public class ClienteTreino
    {
        public Cliente Cliente { get; set; }
        public Treino Treino { get; set; }
        public DateTime DataInicio { get; set; }
        public int VencimentoDias { get; set; }
    }
}