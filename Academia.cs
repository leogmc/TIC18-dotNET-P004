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
        List<Plano> planos;

        public void IncluirPlano(Plano plano){
            planos.Add(plano);
        }

        public Academia()
        {
            treinadores = new List<Treinador>(); //Academia.AdicionaTreinadores();
            clientes = new List<Cliente>(); //Academia.AdicionaCliente();
            treinos = new List<Treino>();
            exercicios = new List<Exercicio>();
            planos = new List<Plano>();
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

            //Coloca o treino na lista de treinos
            treinador.AdicionarTreino(novoTreino);
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
        #region INclusao de alguns dados

        public void AdicionaAlgunsTreinadores()
        {
            try
            {
                //Treinador 1
                Treinador t1 = new Treinador();
                t1.Nome = "Luiz Gustavo";
                t1.DtNascimento = new DateTime(1979, 6, 8);
                t1.CPF = "12345678901";
                t1.CREF = "123456";
                foreach (var instrutor in treinadores)
                {
                    if (instrutor.CPF == t1.CPF)
                    {
                        throw new Exception($"Ops. O CPF: {t1.CPF} já existe na base.");
                    }
                    else if (instrutor.CREF == t1.CREF)
                    {
                        throw new Exception($"Ops. O CREF: {t1.CREF} já existe na base.");
                    }
                }

                treinadores.Add(t1);
            }
            catch (System.ArgumentException ex1) { System.Console.WriteLine($"Erro no argumento {ex1.Message}"); }
            catch (System.Exception ex) { System.Console.WriteLine($"Nao foi possivel incluir treinador {ex.Message}"); }

            try
            {

                //Treinador 2
                Treinador t2 = new Treinador();
                t2.Nome = "Roberta Lima";
                t2.DtNascimento = new DateTime(1988, 8, 8);
                t2.CPF = "02345678901";
                t2.CREF = "133456";
                foreach (var instrutor in treinadores)
                {
                    if (instrutor.CPF == t2.CPF)
                    {
                        throw new Exception($"Ops. O CPF: {t2.CPF} já existe na base.");
                    }
                    else if (instrutor.CREF == t2.CREF)
                    {
                        throw new Exception($"Ops. O CREF: {t2.CREF} já existe na base.");
                    }
                }
                treinadores.Add(t2);
            }
            catch (System.ArgumentException ex1) { System.Console.WriteLine($"Erro no argumento {ex1.Message}"); }
            catch (System.Exception ex) { System.Console.WriteLine($"Nao foi possivel incluir treinador {ex.Message}"); }


            try
            {
                //Treinador 3
                Treinador t3 = new Treinador();
                t3.Nome = "Matheus Santos";
                t3.DtNascimento = new DateTime(1977, 4, 18);
                t3.CPF = "02145678901";
                t3.CREF = "1333356";
                foreach (var instrutor in treinadores)
                {
                    if (instrutor.CPF == t3.CPF)
                    {
                        throw new Exception($"Ops. O CPF: {t3.CPF} já existe na base.");
                    }
                    else if (instrutor.CREF == t3.CREF)
                    {
                        throw new Exception($"Ops. O CREF: {t3.CREF} já existe na base.");
                    }
                }
                treinadores.Add(t3);
            }
            catch (System.ArgumentException ex1) { System.Console.WriteLine($"Erro no argumento {ex1.Message}"); }
            catch (System.Exception ex) { System.Console.WriteLine($"Nao foi possivel incluir treinador {ex.Message}"); }



            try
            {
                //Treinador 4
                Treinador t4 = new Treinador();
                t4.Nome = "Juliana Pereira";
                t4.DtNascimento = new DateTime(2001, 4, 18);
                t4.CPF = "02015678901";
                t4.CREF = "1334356";
                foreach (var instrutor in treinadores)
                {
                    if (instrutor.CPF == t4.CPF)
                    {
                        throw new Exception($"Ops. O CPF: {t4.CPF} já existe na base.");
                    }
                    else if (instrutor.CREF == t4.CREF)
                    {
                        throw new Exception($"Ops. O CREF: {t4.CREF} já existe na base.");
                    }
                }
                treinadores.Add(t4);
            }
            catch (System.ArgumentException ex1) { System.Console.WriteLine($"Erro no argumento {ex1.Message}"); }
            catch (System.Exception ex) { System.Console.WriteLine($"Nao foi possivel incluir treinador {ex.Message}"); }

        }
        public void AdicionaAlgunsClientes()
        {
            try
            {
                //Cliente 1
                Cliente t1 = new Cliente();
                t1.Nome = "Luiza Guerra";
                t1.DtNascimento = new DateTime(2001, 4, 20);
                t1.CPF = "12345678901";
                t1.Altura = 1.66;
                t1.Peso = 72.9;
                foreach (var cliente in clientes)
                {
                    if (cliente.CPF == t1.CPF)
                    {
                        throw new Exception($"Ops. O CPF: {t1.CPF} já existe na base.");
                    }
                }
                clientes.Add(t1);
            }
            catch (System.ArgumentException ex1) { System.Console.WriteLine($"Erro no argumento {ex1.Message}"); }
            catch (System.Exception ex) { System.Console.WriteLine($"Nao foi possivel incluir cliente {ex.Message}"); }

            try
            {
                //Cliente 2
                Cliente t2 = new Cliente();
                t2.Nome = "Roberto Leal";
                t2.DtNascimento = new DateTime(2002, 10, 20);
                t2.CPF = "02345678901";
                t2.Altura = 1.88;
                t2.Peso = 80;
                foreach (var cliente in clientes)
                {
                    if (cliente.CPF == t2.CPF)
                    {
                        throw new Exception($"Ops. O CPF: {t2.CPF} já existe na base.");
                    }
                }
                clientes.Add(t2);
            }
            catch (System.ArgumentException ex1) { System.Console.WriteLine($"Erro no argumento {ex1.Message}"); }
            catch (System.Exception ex) { System.Console.WriteLine($"Nao foi possivel incluir cliente {ex.Message}"); }


            try
            {
                //Cliente 3
                Cliente t3 = new Cliente();
                t3.Nome = "Maria Antunes";
                t3.DtNascimento = new DateTime(1999, 10, 29);
                t3.CPF = "02145678901";
                t3.Altura = 1.50;
                t3.Peso = 55;
                foreach (var cliente in clientes)
                {
                    if (cliente.CPF == t3.CPF)
                    {
                        throw new Exception($"Ops. O CPF: {t3.CPF} já existe na base.");
                    }
                }
                clientes.Add(t3);
            }
            catch (System.ArgumentException ex1) { System.Console.WriteLine($"Erro no argumento {ex1.Message}"); }
            catch (System.Exception ex) { System.Console.WriteLine($"Nao foi possivel incluir cliente {ex.Message}"); }



            try
            {
                //Cliente 4
                Cliente t4 = new Cliente();
                t4.Nome = "Julio Pereira";
                t4.DtNascimento = new DateTime(2000, 1, 29);
                t4.CPF = "02015678901";
                t4.Altura = 1.67;
                t4.Peso = 99;
                foreach (var cliente in clientes)
                {
                    if (cliente.CPF == t4.CPF)
                    {
                        throw new Exception($"Ops. O CPF: {t4.CPF} já existe na base.");
                    }
                }
                clientes.Add(t4);
            }
            catch (System.ArgumentException ex1) { System.Console.WriteLine($"Erro no argumento {ex1.Message}"); }
            catch (System.Exception ex) { System.Console.WriteLine($"Nao foi possivel incluir cliente {ex.Message}"); }



            try
            {
                //Cliente 5
                Cliente t5 = new Cliente();
                t5.Nome = "Leonardo Pereira";
                t5.DtNascimento = new DateTime(1981, 2, 21);
                t5.CPF = "02015678991";
                t5.Altura = 1.99;
                t5.Peso = 78;
                foreach (var cliente in clientes)
                {
                    if (cliente.CPF == t5.CPF)
                    {
                        throw new Exception($"Ops. O CPF: {t5.CPF} já existe na base.");
                    }
                }
                clientes.Add(t5);
            }
            catch (System.ArgumentException ex1) { System.Console.WriteLine($"Erro no argumento {ex1.Message}"); }
            catch (System.Exception ex) { System.Console.WriteLine($"Nao foi possivel incluir cliente {ex.Message}"); }



            try
            {
                //Cliente 6
                Cliente t6 = new Cliente();
                t6.Nome = "Eduardo Campos";
                t6.DtNascimento = new DateTime(1980, 2, 23);
                t6.CPF = "02015676901";
                t6.Altura = 1.97;
                t6.Peso = 79;
                foreach (var cliente in clientes)
                {
                    if (cliente.CPF == t6.CPF)
                    {
                        throw new Exception($"Ops. O CPF: {t6.CPF} já existe na base.");
                    }
                }
                clientes.Add(t6);
            }
            catch (System.ArgumentException ex1) { System.Console.WriteLine($"Erro no argumento {ex1.Message}"); }
            catch (System.Exception ex) { System.Console.WriteLine($"Nao foi possivel incluir cliente {ex.Message}"); }
            
            try
            {
                //Cliente 7
                Cliente t = new Cliente();
                t.Nome = "Estrela Reis";
                t.DtNascimento = new DateTime(1980, 2, 23);
                t.CPF = "02015676991";
                t.Altura = 1.68;
                t.Peso = 79;
                foreach (var cliente in clientes)
                {
                    if (cliente.CPF == t.CPF)
                    {
                        throw new Exception($"Ops. O CPF: {t.CPF} já existe na base.");
                    }
                }
                clientes.Add(t);
            }
            catch (System.ArgumentException ex1) { System.Console.WriteLine($"Erro no argumento {ex1.Message}"); }
            catch (System.Exception ex) { System.Console.WriteLine($"Nao foi possivel incluir cliente {ex.Message}"); }
            try
            {
                //Cliente 8
                Cliente t = new Cliente();
                t.Nome = "Gael Pires";
                t.DtNascimento = new DateTime(1980, 2, 23);
                t.CPF = "02015996901";
                t.Altura = 1.50;
                t.Peso = 80;
                foreach (var cliente in clientes)
                {
                    if (cliente.CPF == t.CPF)
                    {
                        throw new Exception($"Ops. O CPF: {t.CPF} já existe na base.");
                    }
                }
                clientes.Add(t);
            }
            catch (System.ArgumentException ex1) { System.Console.WriteLine($"Erro no argumento {ex1.Message}"); }
            catch (System.Exception ex) { System.Console.WriteLine($"Nao foi possivel incluir cliente {ex.Message}"); }

        }
        public void AdicionaAlgunsExercicios()
        {
            Exercicio e1 = new Exercicio("Peito", 15, 4, 30);
            exercicios.Add(e1);

            Exercicio e2 = new Exercicio("Costas", 12, 8, 45);
            exercicios.Add(e2);

            Exercicio e3 = new Exercicio("Pernas", 20, 5, 60);
            exercicios.Add(e3);

            Exercicio e4 = new Exercicio("Ombros", 18, 6, 40);
            exercicios.Add(e4);

            Exercicio e5 = new Exercicio("Bíceps", 15, 10, 30);
            exercicios.Add(e5);

            Exercicio e6 = new Exercicio("Tríceps", 16, 8, 45);
            exercicios.Add(e6);

            Exercicio e7 = new Exercicio("Abdominais", 25, 15, 30);
            exercicios.Add(e7);

            Exercicio e8 = new Exercicio("Pular corda", 30, 10, 60);
            exercicios.Add(e8);

            Exercicio e9 = new Exercicio("Glúteos", 15, 15, 45);
            exercicios.Add(e9);
        }
        public void AdicionaAlgunsTreinos()
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
                treino1.AssociarCliente(clientes[2], DateTime.Now, 30);
                treino1.AssociarCliente(clientes[3], DateTime.Now, 30);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Erro ao associar cliente: {ex.Message}");
            }
            // Avalia o treino pelo cliente associado
            treino1.AvaliarTreino(clientes[0], 9);
            treino1.AvaliarTreino(clientes[1], 8);
            treino1.AvaliarTreino(clientes[2], 7);
            treino1.AvaliarTreino(clientes[3], 8);
            //Adiciona o treino1 a lista de treinos do treinador[0]
            treinadores[0].AdicionarTreino(treino1);

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

            //Adiciona o treino1 a lista de treinos do treinador[0]
            treinadores[1].AdicionarTreino(treino2);

            // Adicione o treino à lista de treinos
            treinos.Add(treino2);
            
            //Inclusao do Treino 2 e todo o vinculo
            Treino treino3 = new Treino("Meu Cardio", "Emagrecimento", treinadores[2]);


            List<Exercicio> listaExerc3 = new List<Exercicio>();
            listaExerc3.Add(exercicios[0]);
            listaExerc3.Add(exercicios[1]);
            listaExerc3.Add(exercicios[2]);
            listaExerc3.Add(exercicios[3]);
            listaExerc3.Add(exercicios[4]);

            // Adiciona exercícios ao treino
            AdicionaExercicioAoTreino(treino3, listaExerc3);

            // Associa clientes ao treino
            try
            {
                treino3.AssociarCliente(clientes[5], DateTime.Now, 30);
                treino3.AssociarCliente(clientes[6], DateTime.Now, 30);
                treino3.AssociarCliente(clientes[7], DateTime.Now, 30);

            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Erro ao associar cliente: {ex.Message}");
            }
            // Avalia o treino pelo cliente associado
            treino3.AvaliarTreino(clientes[5], 10);
            treino3.AvaliarTreino(clientes[6], 9);
            treino3.AvaliarTreino(clientes[7], 9);

            //Adiciona o treino1 a lista de treinos do treinador[0]
            treinadores[2].AdicionarTreino(treino3);

            // Adicione o treino à lista de treinos
            treinos.Add(treino3);

        }
        #endregion


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
            Console.WriteLine("7. Treinos em ordem crescente pela quantidade de dias até o vencimento");
            Console.WriteLine("--------------------------------------");

           var treinosOrdenados = treinos
            .OrderBy(treino => treino.ClientesAssociados.Min(c => (c.VencimentoDias - (DateTime.Now - c.DataInicio).Days)));

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
        public void RelatorioTreinadoresOrdemDecrescente()
        {
            System.Console.WriteLine("8. Treinadores em ordem decrescente da média de notas dos seus treinos");
            System.Console.WriteLine("--------------------------------------");

            var treinadoresOrdenados = treinadores
                .Select(treinador =>
                {
                    var treinos = treinador.Treinos;
                    var mediaNotas = treinos.Any() ? treinos.Average(treino => treino.MediaNotas) : 0;

                    return new
                    {
                        Treinador = treinador,
                        MediaNotas = mediaNotas
                    };
                })
                .OrderByDescending(treinador => treinador.MediaNotas);

            foreach (var item in treinadoresOrdenados)
            {
                Console.WriteLine($"Treinador: {item.Treinador.Nome}, Média de Notas: {item.MediaNotas}");
            }

            Console.WriteLine("");
        }
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