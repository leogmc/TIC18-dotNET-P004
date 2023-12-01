using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Win32.SafeHandles;

namespace atividadeAv
{
    public class Pessoa
    { 
        private DateTime _dtNascimento;
        public string Nome { get; set; }
        public DateTime DtNascimento { 
            get { return _dtNascimento; }
            set {
                _dtNascimento = value;
                var quantosAnos = DateTime.Today.Year - DtNascimento.Year;
                if (DtNascimento.Date.DayOfYear >= DateTime.Now.DayOfYear){
                    quantosAnos--;
                }
                Idade = quantosAnos;
            } 
        }
        public int Idade {get;  set;}
       
    }
    public class Treinador : Pessoa{
        private string _cpf;
        public string CPF { 
            get { return _cpf; }
            set { 
                if (value.Length == 11)
                {
                    _cpf = value; 
                }
                else{
                    throw new ArgumentException("CPF precisa ter 11 digitos.");
                }
                
            }
        }
        public string CREF { get; set; }
    }
    public class Cliente : Pessoa{
        
        public List<ClienteTreino> TreinosAssociados { get; set; }

        private string _cpf;
        private double _altura;
        private double _peso;
        public string CPF { 
            get { return _cpf; }
            set { 
                if (value.Length == 11)
                {
                    _cpf = value; 
                }
                else{
                    throw new ArgumentException("CPF precisa ter 11 digitos.");
                }
                
            }
        }
        
        public double Altura { 
            get { return _altura; }
            set { 
                if (value <= 0)
                {
                    throw new ArgumentException("Altura deve ser maior que 0.");
                }
                _altura = value;
            }
        }

        public double Peso { 
            get { return _peso; }
            set { 
                if (value <= 0)
                {
                    throw new ArgumentException("Peso deve ser maior que 0.");
                }
                _peso = value;   
            }
        }
        public Cliente(){
            TreinosAssociados = new List<ClienteTreino>();
        }
        
    }
}