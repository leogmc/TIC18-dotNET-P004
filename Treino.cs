using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace atividadeAv
{
    public class Treino
    {
        public string Tipo { get; set; }
        public string Objetivo { get; set; }
        public List<Exercicio> ListaExercicios { get; set; }
        public int DuracaoEstimadaMinutos { get; set; }
        public Treinador TreinadorResponsavel { get; set; }
        public List<(Cliente, int)> ClientesAvaliacao { get; set; }
        public List<ClienteTreino> ClientesAssociados { get; set; }
        public Treino(string tipo, string objetivo, Treinador treinador)
        {
            Tipo = tipo;
            Objetivo = objetivo;
            TreinadorResponsavel = treinador;
            ListaExercicios = new List<Exercicio>();
            ClientesAvaliacao = new List<(Cliente, int)>();
            ClientesAssociados = new List<ClienteTreino>();
        }
        public void AdicionarExercicio(Exercicio exercicio)
        {
            if (ListaExercicios.Count < 10)
            {
                ListaExercicios.Add(exercicio);
            }
            else
            {
                throw new InvalidOperationException("Um treino pode conter no máximo 10 exercícios.");
            }
        }
        public void AssociarCliente(Cliente cliente, DateTime dataInicio, int vencimentoDias)
        {
            if (ClientesAssociados.Count(c => c.Cliente == cliente) < 2)
            {
                ClienteTreino associacao = new ClienteTreino
                {
                    Cliente = cliente,
                    Treino = this,
                    DataInicio = dataInicio,
                    VencimentoDias = vencimentoDias
                };

                ClientesAssociados.Add(associacao);
                cliente.TreinosAssociados.Add(associacao);
            }
            else
            {
                throw new InvalidOperationException("Um cliente pode estar associado a no máximo 2 treinos.");
            }
        }
        public void DesassociarCliente(Cliente cliente)
        {
            ClienteTreino associacao = ClientesAssociados.FirstOrDefault(c => c.Cliente == cliente);

            if (associacao != null)
            {
                ClientesAssociados.Remove(associacao);
                cliente.TreinosAssociados.Remove(associacao);
            }
        }
        public void AvaliarTreino(Cliente cliente, int pontuacao)
        {
            // Verifica se o cliente está associado ao treino
            if (ClientesAssociados.Any(c => c.Cliente == cliente))
            {
                // Verifica se o cliente já avaliou o treino
                var avaliacaoExistente = ClientesAvaliacao.FirstOrDefault(a => a.Item1 == cliente);

                if (avaliacaoExistente == default)
                {
                    // Adiciona a avaliação do cliente
                    ClientesAvaliacao.Add((cliente, pontuacao));
                    Console.WriteLine($"Treino avaliado com sucesso por {cliente.Nome}.");
                }
                else
                {
                    Console.WriteLine($"{cliente.Nome} já avaliou este treino.");
                }
            }
            else
            {
                Console.WriteLine($"{cliente.Nome} não está associado a este treino.");
            }
        }
    }
}