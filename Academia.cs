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
        List<Exercicio> exercicios;

        public Academia()
        {
            treinadores = new List<Treinador>(); //Academia.AdicionaTreinadores();
            clientes = new List<Cliente>(); //Academia.AdicionaCliente();
            treinos = new List<Treino>();
            exercicios = new List<Exercicio>();
        }
        static DateTime ObterDataNascimento()
        {
            Console.Write("Digite sua data de nascimento (DD/MM/YYYY): ");
            string dataNascimentoInput = Console.ReadLine();

            if (DateTime.TryParseExact(dataNascimentoInput, "dd/MM/yyyy", null, DateTimeStyles.None, out DateTime dataNascimento))
            {
                return dataNascimento;
            }
            else
            {
                throw new FormatException("Formato de data inválido. Use o formato DD/MM/YYYY.");
            }
        }
        public void AdicionaTreinadores()
        {
            Console.WriteLine("==== Adicionar Treinador ====");
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            if (String.IsNullOrEmpty(nome))
            {
                System.Console.WriteLine("O campo nome não pode ser vazio.");
                return;
            }

            Console.Write("CPF: ");
            string cpf = Console.ReadLine();
            if (String.IsNullOrEmpty(cpf) || cpf.Length != 11)
            {
                System.Console.WriteLine("O CPF deve ter 11 dígitos.");
                return;
            }

            if (SeTreinadorExisteCPF(cpf))
            {
                Console.WriteLine($"Existe Treinador com o CPF: {cpf}.");
                return;
            }
            Console.Write("CREF: ");
            string cref = Console.ReadLine();
            if (String.IsNullOrEmpty(cref))
            {
                System.Console.WriteLine("O campo CREF não pode ser vazio.");
                return;
            }
            if (SeTreinadorExisteCREF(cref))
            {
                Console.WriteLine($"Existe Treinador com o CREF: {cref}.");
                return;
            }

            //Vai ser utilizado no do-while para pegar uma data valida
            bool entradaValida;

            do
            {
                try
                {
                    DateTime dataNascimento = ObterDataNascimento();

                    entradaValida = true;
                    // Criar treinador como um novo objeto
                    Treinador novoTreinador = new Treinador();
                    novoTreinador.CPF = cpf;
                    novoTreinador.CREF = cref;
                    novoTreinador.DtNascimento = dataNascimento;
                    novoTreinador.Nome = nome;

                    treinadores.Add(novoTreinador);
                    Console.WriteLine("Treinador adicionado com sucesso!");
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"Erro de formato: {ex.Message}");
                    entradaValida = false; // Se ocorreu uma exceção, a entrada não é válida
                }
            } while (!entradaValida);
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
        // Verificar se treinador já está na lista pelo CPF ou pelo CREF
        public bool SeTreinadorExisteCPF(string cpf)
        {
            foreach (var treinador in treinadores)
            {
                if (treinador.CPF == cpf)
                {
                    return true;
                }
            }
            return false;
        }
        public bool SeTreinadorExisteCREF(string cref)
        {
            foreach (var treinador in treinadores)
            {
                if (treinador.CREF == cref)
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
            if (String.IsNullOrEmpty(nome))
            {
                System.Console.WriteLine("O campo nome não pode ser vazio.");
                return;
            }

            Console.Write("CPF: ");
            string cpf = Console.ReadLine();
            if (String.IsNullOrEmpty(cpf) || cpf.Length != 11)
            {
                System.Console.WriteLine("O CPF deve ter 11 dígitos.");
                return;
            }

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


            //Vai ser utilizado no do-while para pegar uma data valida
            bool entradaValida;

            do
            {
                try
                {
                    DateTime dataNascimento = ObterDataNascimento();

                    entradaValida = true;

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
                catch (FormatException ex)
                {
                    Console.WriteLine($"Erro de formato: {ex.Message}");
                    entradaValida = false; // Se ocorreu uma exceção, a entrada não é válida
                }
            } while (!entradaValida);

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
        public void CriarExercicio()
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

            var novoExercicio = new Exercicio(grupoMuscular, series, repeticoes, tempoIntervaloSegundos);
            Console.WriteLine("Exercício criado com sucesso.");
            exercicios.Add(novoExercicio);
            
        }
        public Exercicio CriarERetornaExercicio()
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

            var novoExercicio = new Exercicio(grupoMuscular, series, repeticoes, tempoIntervaloSegundos);
            Console.WriteLine("Exercício criado com sucesso.");
            exercicios.Add(novoExercicio);
            return novoExercicio;

        }
        public Exercicio SelecionarExercicioExistente()
        {
            Console.WriteLine("==== Selecionar Exercício Existente ====");
            Console.WriteLine("Lista de Exercícios Disponíveis:");

            for (int i = 0; i < exercicios.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {exercicios[i].GrupoMuscular}");
            }

            Console.Write("Digite o número do exercício desejado: ");
            int escolha = Convert.ToInt32(Console.ReadLine()) - 1;

            if (escolha >= 0 && escolha < exercicios.Count)
            {
                return exercicios[escolha];
            }
            else
            {
                Console.WriteLine("Opção inválida. Exercício não encontrado.");
                return null;
            }
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
            string opcao;

            do
            {
                Console.WriteLine("Pressione 'N' para criar um novo exercício, 'E' para selecionar um exercício existente ou qualquer outra tecla para cancelar.");
                opcao = Console.ReadLine();

                Exercicio novoExercicio;

                if (opcao.ToUpper() == "N")
                {
                    novoExercicio = CriarERetornaExercicio();
                }
                else if (opcao.ToUpper() == "E")
                {
                    novoExercicio = SelecionarExercicioExistente();
                }
                else
                {
                    break; // Sai do loop se a opção for diferente de 'N' ou 'E'
                }

                if (novoExercicio != null)
                {
                    novoTreino.AdicionarExercicio(novoExercicio);
                    Console.WriteLine("Exercício adicionado ao treino.");
                }
            } while (opcao.ToUpper() == "N" || opcao.ToUpper() == "E");

            treinos.Add(novoTreino);

        }
        public void AdicionaExercicioAoTreino(Treino treino, List<Exercicio> listaExerciciosEscolhidos)
        {
            foreach (var exercicio in listaExerciciosEscolhidos)
            {
                treino.AdicionarExercicio(exercicio);
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
                if (int.TryParse(Console.ReadLine(), out avaliacao))
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

        public void AdicionaTreinos()
        {
            //Inclusao do Treino 1 e todo o vinculo
            Treino treino1 = new Treino("Musculação", "Hipertrofia", treinadores[0]);

            List<Exercicio> listaExerc = new List<Exercicio>();
            listaExerc.Add(exercicios[0]);
            listaExerc.Add(exercicios[1]);
            listaExerc.Add(exercicios[2]);
            listaExerc.Add(exercicios[3]);

            // Adiciona exercícios ao treino
            AdicionaExercicioAoTreino(treino1, listaExerc);

            // Associa clientes ao treino
            try
            {
                treino1.AssociarCliente(clientes[0], DateTime.Now, 30);
                treino1.AssociarCliente(clientes[1], DateTime.Now, 30);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Erro ao associar cliente: {ex.Message}");
            }
            // Avalia o treino pelo cliente associado
            treino1.AvaliarTreino(clientes[0], 9);
            treino1.AvaliarTreino(clientes[1], 8);

            //Inclusao do Treino 2 e todo o vinculo
            Treino treino2 = new Treino("Cardio", "Emagrecimento", treinadores[1]);


            List<Exercicio> listaExerc2 = new List<Exercicio>();
            listaExerc2.Add(exercicios[0]);
            listaExerc2.Add(exercicios[5]);
            listaExerc2.Add(exercicios[6]);
            listaExerc2.Add(exercicios[7]);
            listaExerc2.Add(exercicios[8]);

            // Adiciona exercícios ao treino
            AdicionaExercicioAoTreino(treino2, listaExerc2);

            // Associa clientes ao treino
            try
            {
                treino2.AssociarCliente(clientes[2], DateTime.Now, 30);
                treino2.AssociarCliente(clientes[3], DateTime.Now, 30);
                treino2.AssociarCliente(clientes[4], DateTime.Now, 30);

            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Erro ao associar cliente: {ex.Message}");
            }
            // Avalia o treino pelo cliente associado
            treino2.AvaliarTreino(clientes[2], 10);
            treino2.AvaliarTreino(clientes[3], 9);
            treino2.AvaliarTreino(clientes[4], 9);

            // Adicione o treino à lista de treinos
            treinos.Add(treino2);

        }


        //Relatório (1)
        public void RelatorioTreinadoresIntevaloIdades(int idadeMin, int idadeMax)
        {
            System.Console.WriteLine($"1. Treinadores com idade entre {idadeMin} e {idadeMax} anos");
            System.Console.WriteLine("--------------------------------------");
            var treinadoresIdade = treinadores.Where(t => t.Idade >= idadeMin && t.Idade <= idadeMax);

            foreach (var treinador in treinadoresIdade)
            {
                Console.WriteLine($"Treinador: Nome: {treinador.Nome}, Idade: {treinador.Idade}");
            }
            Console.WriteLine("");
        }

        //Relatório (2)
        public void RelatorioClientesIntevaloIdades(int idadeMin, int idadeMax)
        {
            System.Console.WriteLine($"2. Clientes com idade entre {idadeMin} e {idadeMax} anos");
            System.Console.WriteLine("--------------------------------------");
            var clientesIdade = clientes.Where(t => t.Idade >= idadeMin && t.Idade <= idadeMax);

            foreach (var cliente in clientesIdade)
            {
                Console.WriteLine($"Cliente: Nome: {cliente.Nome}, Idade: {cliente.Idade}");
            }
            Console.WriteLine("");

        }

        //Relatório (3)
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

        //Relatório (4)
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

        //Relatório (5)
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

        //Relatório (6)
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

        //Relatório (7)
        public void RelatorioTreinosOrdemCrescenteQtdVencimento()
        {
            Console.WriteLine("8. Treinos em ordem crescente pela quantidade de dias até o vencimento");
            Console.WriteLine("--------------------------------------");

            var treinosOrdenados = treinos
                .OrderBy(treino =>
                {
                    var clienteTreino = treino.ClientesAssociados.FirstOrDefault();

                    if (clienteTreino != null)
                    {
                        var diasRestantes = (clienteTreino.DataInicio.AddDays(clienteTreino.VencimentoDias) - DateTime.Now).Days;
                        return diasRestantes;
                    }

                    return int.MaxValue;
                });

            foreach (var treino in treinosOrdenados)
            {
                var clienteTreino = treino.ClientesAssociados.FirstOrDefault();
                var diasRestantes = clienteTreino != null
                    ? (clienteTreino.DataInicio.AddDays(clienteTreino.VencimentoDias) - DateTime.Now).Days
                    : int.MaxValue;

                Console.WriteLine($"Treino: Tipo: {treino.Tipo}, Objetivo: {treino.Objetivo}, Dias até o vencimento: {diasRestantes}");
            }

            Console.WriteLine("");
        }

        //Relatório (8) - REQUER CORREÇAO!!!
        // public void RelatorioTreinadoresOrdemDecrescente()
        // {
        //     System.Console.WriteLine("7. Treinadores em ordem decrescente da média de notas dos seus treinos");
        //     System.Console.WriteLine("--------------------------------------");

        //     var treinadoresOrdenados = treinadores
        //         .Select(treinador =>
        //         {
        //             var notas = treinador.ClientesAssociados
        //                 .SelectMany(clienteTreino => clienteTreino.Treino.ClientesAvaliacao)
        //                 .Where(avaliacao => avaliacao.Item1.TreinosAssociados.Any(ct => ct.Treino == clienteTreino.Treino))
        //                 .Select(avaliacao => avaliacao.Item2);

        //             var media = notas.Any() ? notas.Average() : 0;

        //             return new
        //             {
        //                 Treinador = treinador,
        //                 MediaNotas = media
        //             };
        //         })
        //     .OrderByDescending(treinador => treinador.MediaNotas);

        //     foreach (var item in treinadoresOrdenados)
        //     {
        //         Console.WriteLine($"Treinador: {item.Treinador.Nome}, Média de Notas: {item.MediaNotas}");
        //     }

        //     Console.WriteLine("");
        // }

        //Relatório (9)
        public void RelatorioTreinosPorPalavraChave(string palavraChave)
        {
            System.Console.WriteLine($"9.Treinos com objetivo contendo a palavra-chave '{palavraChave}'");
            System.Console.WriteLine("--------------------------------------");

            var treinosComPalavraChave = treinos.Where(t => t.Objetivo.Contains(palavraChave));

            foreach (var treino in treinosComPalavraChave)
            {
                Console.WriteLine($"Treino: {treino.Tipo}, Objetivo: {treino.Objetivo}");
            }
            Console.WriteLine("");
        }

        //Relatório (10)
        public void RelatorioTop10ExerciciosMaisUtilizados()
        {
            System.Console.WriteLine("10.Top 10 exercícios mais utilizados nos treinos");
            System.Console.WriteLine("--------------------------------------");

            var exerciciosUtilizados = treinos.SelectMany(t => t.ListaExercicios)
                    .GroupBy(e => e.GrupoMuscular)
                    .Select(g => new { NomeExercicio = g.Key, Quantidade = g.Count() })
                    .OrderByDescending(g => g.Quantidade)
                    .Take(10);

            foreach (var exercicio in exerciciosUtilizados)
            {
                Console.WriteLine($"Exercício: {exercicio.NomeExercicio}, Quantidade: {exercicio.Quantidade}");
            }
            Console.WriteLine("");
        }

    }
}
