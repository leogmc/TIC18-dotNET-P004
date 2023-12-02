using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;

namespace atividadeAv
{
    public class Academia
    {

        List<Treinador> treinadores;
        List<Cliente> clientes;
        List<Treino> treinos;

        public Academia()
        {
            treinadores = new List<Treinador>(); //Academia.AdicionaTreinadores();
            clientes = new List<Cliente>(); //Academia.AdicionaCliente();
            treinos = new List<Treino>();
        }

        public void AdicionaTreinador()
        {
            Console.WriteLine("==== Adicionar Treinador ====");
            Console.Write("Nome: ");
            string nome = Console.ReadLine();

            Console.Write("CPF: ");
            string cpf = Console.ReadLine();

            Console.Write("CREF: ");
            string cref = Console.ReadLine();

            if (SeTreinadorExiste(cpf, cref))
            {
                Console.WriteLine("Treinador existente. Tente novamente.");
                return;
            }

            Console.Write("Ano de nascimento: ");
            int ano;
            if (!int.TryParse(Console.ReadLine(), out ano))
            {
                throw new FormatException("Digite um valor numérico inteiro para o ano.");
            }
            Console.Write("Mês de nascimento: ");
            int mes;
            if (!int.TryParse(Console.ReadLine(), out mes))
            {
                throw new FormatException("Digite um valor numérico inteiro para o mês.");
            }
            Console.Write("Dia de nascimento: ");
            int dia;
            if (!int.TryParse(Console.ReadLine(), out dia))
            {
                throw new FormatException("Digite um valor numérico inteiro para o dia.");
            }

            // Validar o DateTime que vai ser criado
            DateTime dataNascimento;
            if (!DateTime.TryParse($"{ano}-{mes}-{dia}", out dataNascimento))
            {
                throw new FormatException("Data de nascimento inválida.");
            }

            // Criar treinador como um novo objeto
            Treinador novoTreinador = new Treinador();
            novoTreinador.CPF = cpf;
            novoTreinador.CREF = cref;
            novoTreinador.DtNascimento = dataNascimento;
            novoTreinador.Nome = nome;

            treinadores.Add(novoTreinador);
            Console.WriteLine("Treinador adicionado com sucesso!");
        }

        // Verificar se treinador já está na lista pelo CPF ou pelo CREF
        public bool SeTreinadorExiste(string cpf, string cref)
        {
            foreach (var treinador in treinadores)
            {
                if (treinador.CPF == cpf || treinador.CREF == cref)
                {
                    return true;
                }
            }
            return false;
        }

        public void AdicionaCliente()
        {
            Console.WriteLine("==== Adicionar Cliente ====");
            Console.Write("Nome: ");
            string nome = Console.ReadLine();

            Console.Write("CPF: ");
            string cpf = Console.ReadLine();

            if (SeClienteExiste(cpf))
            {
                Console.WriteLine("Cliente existente. Tente novamente.");
                return;
            }

            Console.Write("Altura: ");
            double altura;
            if (!double.TryParse(Console.ReadLine(), out altura))
            {
                throw new FormatException("Digite um valor numérico para a altura.");
            }

            Console.Write("Peso: ");
            double peso;
            if (!double.TryParse(Console.ReadLine(), out peso))
            {
                throw new FormatException("Digite um valor numérico para o peso.");
            }

            Console.Write("Ano de nascimento: ");
            int ano;
            if (!int.TryParse(Console.ReadLine(), out ano))
            {
                throw new FormatException("Digite um valor numérico inteiro para o ano.");
            }
            Console.Write("Mês de nascimento: ");
            int mes;
            if (!int.TryParse(Console.ReadLine(), out mes))
            {
                throw new FormatException("Digite um valor numérico inteiro para o mês.");
            }
            Console.Write("Dia de nascimento: ");
            int dia;
            if (!int.TryParse(Console.ReadLine(), out dia))
            {
                throw new FormatException("Digite um valor numérico inteiro para o dia.");
            }

            // Validar o DateTime que vai ser criado
            DateTime dataNascimento;
            if (!DateTime.TryParse($"{ano}-{mes}-{dia}", out dataNascimento))
            {
                throw new FormatException("Data de nascimento inválida.");
            }

            // Criar cliente como um novo objeto
            Cliente novoCliente = new Cliente();
            novoCliente.CPF = cpf;
            novoCliente.DtNascimento = dataNascimento;
            novoCliente.Altura = altura;
            novoCliente.Peso = peso;
            novoCliente.Nome = nome;

            clientes.Add(novoCliente);
            Console.WriteLine("Cliente adicionado com sucesso!");
        }

        public bool SeClienteExiste(string cpf)
        {
            foreach (var cliente in clientes)
            {
                if (cliente.CPF == cpf)
                {
                    return true;
                }
            }
            return false;
        }

        public Exercicio CriarExercicio()
        {
            Console.WriteLine("==== Criar Exercício ====");
            Console.Write("Grupo muscular: ");
            string grupoMuscular = Console.ReadLine();

            Console.Write("Séries: ");
            int series;
            if (!int.TryParse(Console.ReadLine(), out series))
            {
                throw new FormatException("Séries deve ser um número inteiro.");
            }

            Console.Write("Repetições: ");
            int repeticoes;
            if (!int.TryParse(Console.ReadLine(), out repeticoes))
            {
                throw new FormatException("Repetições deve ser um número inteiro.");
            }

            Console.Write("Tempo de intervalo em segundos: ");
            int tempoIntervaloSegundos;
            if (!int.TryParse(Console.ReadLine(), out tempoIntervaloSegundos))
            {
                throw new FormatException("Tempo de intervalo em segundos deve ser um número inteiro.");
            }

            var novoExercio = new Exercicio(grupoMuscular, series, repeticoes, tempoIntervaloSegundos);
            return novoExercio;
            Console.WriteLine("Exercício criado com sucesso.");
        }

        public void MontarTreino()
        {
            Console.WriteLine("==== Criar Treino ====");
            Console.Write("Tipo do treino: ");
            string tipoTreino = Console.ReadLine();

            Console.Write("Objetivo do treino: ");
            string objetivoTreino = Console.ReadLine();

            Treinador treinador = retornarTreinadorPeloCPF();

            Treino novoTreino = new Treino(tipoTreino, objetivoTreino, treinador);

            Console.WriteLine("==== Adicionar Exercícios ao Treino ====");
            Console.WriteLine("Pressione 'S' para adicionar exercícios ou qualquer outra tecla para sair.");

            string adicionarExercicio = Console.ReadLine();
            while (adicionarExercicio.ToUpper() == "S")
            {
                Exercicio novoExercicio = CriarExercicio();
                novoTreino.AdicionarExercicio(novoExercicio);

                Console.WriteLine("Exercício adicionado ao treino.");

                Console.WriteLine("Pressione 'S' para adicionar mais exercícios ou qualquer outra tecla para sair.");
                adicionarExercicio = Console.ReadLine();
            }

            treinos.Add(novoTreino);
            Console.WriteLine("Treino criado com sucesso!");
        }

        public void ExecutarTreino()
        {
            Console.WriteLine("==== Executar Treino ====");
            Cliente cliente = retornarClientePeloCPF();

            Console.WriteLine("Lista de treinos disponíveis:");
            for (int i = 0; i < treinos.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {treinos[i].Tipo} - {treinos[i].Objetivo}");
            }

            Console.Write("Digite um ou mais números dos respectivos treinos que vão ser associados ao cliente (separados por vírgula): ");
            string treinosSelecionados = Console.ReadLine();
            string[] numerosSelecionados = treinosSelecionados.Split(',');

            foreach (string numeroDoTreino in numerosSelecionados)
            {
                int index;
                if (int.TryParse(numeroDoTreino.Trim(), out index) && index >= 1 && index <= treinos.Count)
                {
                    Treino treinoSelecionado = treinos[index - 1];

                    Console.Write($"Digite quantos dias faltam para o treino '{treinoSelecionado.Tipo}' vencer: ");
                    int vencimentoDias = int.Parse(Console.ReadLine());

                    Console.Write($"Digite a data de início do treino '{treinoSelecionado.Tipo}' (formato dd/mm/yyyy): ");
                    DateTime dataDeInicio = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);

                    treinoSelecionado.AssociarCliente(cliente, dataDeInicio, vencimentoDias);
                    Console.WriteLine("Treino associado com sucesso!");
                }
                else
                {
                    throw new ArgumentException($"Número de treino inválido: {numeroDoTreino}");
                }
            }
        }

        public void AvaliarTreino()
        {
            Console.WriteLine("==== Avaliar Treino ====");
            Cliente cliente = retornarClientePeloCPF();

            Console.WriteLine("Lista de treinos do cliente:");
            for (int i = 0; i < cliente.TreinosAssociados.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {cliente.TreinosAssociados[i].Treino.Tipo} - {cliente.TreinosAssociados[i].Treino.Objetivo}");
            }

            Console.Write("Digite o número do treino que vai ser avaliado: ");
            string treinoSelecionado = Console.ReadLine();

            int index;
            if (int.TryParse(treinoSelecionado, out index) && index >= 1 && index <= cliente.TreinosAssociados.Count)
            {
                Treino treino = cliente.TreinosAssociados[index - 1].Treino;

                Console.Write("Digite sua avaliação (0-10): ");
                int avaliacao;
                if(int.TryParse(Console.ReadLine(), out avaliacao))
                    treino.AvaliarTreino(cliente, avaliacao);
                else
                    throw new FormatException("Insira um número inteiro válido para a avaliação do treino.");
            }
        }

        public Cliente retornarClientePeloCPF()
        {
            Console.Write("CPF do cliente: ");
            string cpfDoCliente = Console.ReadLine();

            foreach (var cliente in clientes)
            {
                if (cliente.CPF == cpfDoCliente)
                {
                    return cliente;
                }
            }
            throw new ArgumentException("Cliente não encontrado.");
        }

        public Treinador retornarTreinadorPeloCPF()
        {
            Console.Write("CPF do treinador: ");
            string cpfDoTreinador = Console.ReadLine();

            foreach (var treinador in treinadores)
            {
                if (treinador.CPF == cpfDoTreinador)
                {
                    return treinador;
                }
            }
            throw new ArgumentException("Treinador não encontrado.");
        }

        public void RelatorioTreinadoresIntevaloIdades(int idadeMin, int idadeMax)
        {
            System.Console.WriteLine($"1. Treinadores com idade entre {idadeMin} e {idadeMax} anos");
            System.Console.WriteLine("--------------------------------------");
            var treinadoresMais40 = treinadores.Where(t => t.Idade >= 40 && t.Idade <= 60);

            foreach (var treinador in treinadoresMais40)
            {
                Console.WriteLine($"Treinador: Nome: {treinador.Nome}, Idade: {treinador.Idade}");
            }
            Console.WriteLine("");
        }

        public void RelatorioClientesIntevaloIdades(int idadeMin, int idadeMax)
        {
            System.Console.WriteLine($"2. Clientes com idade entre {idadeMin} e {idadeMax} anos");
            System.Console.WriteLine("--------------------------------------");
            var clientesMais23 = clientes.Where(t => t.Idade >= idadeMin && t.Idade <= idadeMin);

            foreach (var cliente in clientesMais23)
            {
                Console.WriteLine($"Cliente: Nome: {cliente.Nome}, Idade: {cliente.Idade}");
            }
            Console.WriteLine("");

        }


        public void RelatorioClientesIMCMaior(int num)
        {
            System.Console.WriteLine($"3. Clientes com IMC (peso/altura*altura) maior que {num}");
            System.Console.WriteLine("--------------------------------------");

            var clientesMaisIMC = clientes.Where(t => (t.Peso / (t.Altura * t.Altura)) >= num);

            foreach (var cliente in clientesMaisIMC)
            {
                Console.WriteLine($"Nome: {cliente.Nome}, IMC: {cliente.Peso / (cliente.Altura * cliente.Altura)}");
            }
            Console.WriteLine("");
        }
        public void RelatorioClientesOrdemAlfabetica()
        {

            System.Console.WriteLine("4. Clientes em ordem alfabética");
            System.Console.WriteLine("--------------------------------------");
            var clientesOrdem = clientes.OrderBy(c => c.Nome);
            foreach (var cliente in clientesOrdem)
            {
                Console.WriteLine($"Nome: {cliente.Nome}, Idade: {cliente.Idade}");
            }
            Console.WriteLine("");
        }


        public void RelatorioClientesOrdemIdade()
        {
            System.Console.WriteLine("5. Clientes em ordem idade");
            System.Console.WriteLine("--------------------------------------");
            var clientesOrdemIdade = clientes.OrderBy(c => c.Idade);
            foreach (var cliente in clientesOrdemIdade)
            {
                Console.WriteLine($"Nome: {cliente.Nome}, Idade: {cliente.Idade}");
            }
            Console.WriteLine("");
        }
        public void RelatorioAniversariantesDoMes(int mes)
        {
            System.Console.WriteLine($"6. Treinadores e clientes aniversariantes do mês {mes}");
            System.Console.WriteLine("--------------------------------------");
            List<Pessoa> pessoas = new List<Pessoa>();
            pessoas.AddRange(treinadores);
            pessoas.AddRange(clientes);

            var aniversariantes = pessoas.Where(p => p.DtNascimento.Month == mes);
            foreach (var pessoa in aniversariantes)
            {
                Console.WriteLine($"Nome: {pessoa.Nome}, Data de Nascimento: {pessoa.DtNascimento.ToShortDateString()}, Idade: {pessoa.Idade}");
            }
        }
    }
}