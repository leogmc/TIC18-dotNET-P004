using atividadeAv;
using System.Globalization;

namespace atividadeAv
{
    public class Program
    {

        static void Main(string[] args)
        {
            Academia academia = new Academia();
            RunMenu(academia);
        
            // academia.RelatorioTreinadoresIntevaloIdades(40, 60);
            // academia.RelatorioClientesIntevaloIdades(23, 50);
            // academia.RelatorioClientesIMCMaior(21);
            // academia.RelatorioClientesOrdemAlfabetica();
            // academia.RelatorioClientesOrdemIdade();
            // academia.RelatorioAniversariantesDoMes(10);
            // academia.RelatorioTreinosOrdemCrescenteQtdVencimento();
           // academia.RelatorioTreinadoresOrdemDecrescente();
        
        }

        public static void RunMenu(Academia academia)
        {
            string choice;
            do
            {
                Console.WriteLine("==== Menu ====");
                Console.WriteLine("1. Incluir Treinador, Cliente, Exercicios, treinos, avaliacao treino");
                Console.WriteLine("2. Adicionar Treinador");
                Console.WriteLine("3. Adicionar Cliente");
                Console.WriteLine("4. Criar Exercicio");
                Console.WriteLine("5. Montar Treino");
                Console.WriteLine("6. Executar Treino");
                Console.WriteLine("7. Avaliar Treino");
                Console.WriteLine("8. Menu de Relatórios");
                Console.WriteLine("0. Sair");
                Console.WriteLine("=============");

                Console.Write("Escolha uma opção: ");
                choice = Console.ReadLine();
                try
                {
                    switch (choice)
                    {
                        
                        case "1":
                            academia.AdicionaAlgunsClientes();
                            academia.AdicionaAlgunsTreinadores();
                            academia.AdicionaAlgunsExercicios();
                            academia.AdicionaAlgunsTreinos();
                            break;
                        case "2":
                            academia.AdicionaTreinadores();
                            break;
                        case "3":
                            academia.AdicionaCliente();
                            break;
                        case "4":
                            academia.CriarExercicio();
                            break;
                        case "5":
                            academia.MontarTreino();
                            break;
                        case "6":
                            academia.ExecutarTreino();
                            break;
                        case "7":
                            academia.AvaliarTreino();
                            break;
                        case "8":
                            runMenuDeRelatorios(academia);
                            break;
                        case "0":
                            Console.WriteLine("Saindo do programa...");
                            break;
                        default:
                            Console.WriteLine("Opção inválida. Tente novamente.");
                            break;
                    }
                }
                catch (Exception e) 
                {
                    Console.WriteLine("Erro: " + e.Message);
                }

            } while (choice != "0");
        }

    public static void runMenuDeRelatorios(Academia academia)
        {
            string choice;
            do
            {
                Console.WriteLine("==== Menu de Relatórios ====");
                Console.WriteLine("1. Relatório de Treinadores por Intervalo de Idades");
                Console.WriteLine("2. Relatório de Clientes por Intervalo de Idades");
                Console.WriteLine("3. Relatório de Clientes com IMC Maior");
                Console.WriteLine("4. Relatório de Clientes em Ordem Alfabética");
                Console.WriteLine("5. Relatório de Clientes em Ordem de Idade");
                Console.WriteLine("6. Relatório de Aniversariantes do Mês");
                Console.WriteLine("7. Treinos em ordem crescente (pela quantidade de dias até o vencimento)");
                Console.WriteLine("8. Treinadores em ordem decrescente (com base nas notas dos treinos)");
                Console.WriteLine("9. Treinos com base em um objetivo");
                Console.WriteLine("10. Top 10 exercícios");
                Console.WriteLine("0. Voltar para o menu principal");
                Console.WriteLine("============================");
                Console.Write("Escolha uma opção: ");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Informe a idade mínima: ");
                        int idadeMinTreinador;
                        if (!int.TryParse(Console.ReadLine(), out idadeMinTreinador))
                            throw new FormatException("Idade deve ser um número inteiro.");
                        Console.Write("Informe a idade máxima: ");
                        int idadeMaxTreinador;
                        if (!int.TryParse(Console.ReadLine(), out idadeMaxTreinador))
                            throw new FormatException("Idade deve ser um número inteiro.");
                        academia.RelatorioTreinadoresIntevaloIdades(idadeMinTreinador, idadeMaxTreinador);
                        break;


                    case "2":
                        Console.Write("Informe a idade mínima: ");
                        int idadeMinCliente;
                        if (!int.TryParse(Console.ReadLine(), out idadeMinCliente))
                            throw new FormatException("Idade deve ser um número inteiro.");
                        Console.Write("Informe a idade máxima: ");
                        int idadeMaxCliente;
                        if (!int.TryParse(Console.ReadLine(), out idadeMaxCliente))
                            throw new FormatException("Idade deve ser um número inteiro.");
                        academia.RelatorioClientesIntevaloIdades(idadeMinCliente, idadeMaxCliente);
                        break;


                    case "3":
                        Console.Write("Informe o valor mínimo do IMC: ");
                        int imcMin;
                        if (!int.TryParse(Console.ReadLine(), out imcMin))
                            throw new FormatException("IMC deve ser um número inteiro.");
                        academia.RelatorioClientesIMCMaior(imcMin);
                        break;


                    case "4":
                        academia.RelatorioClientesOrdemAlfabetica();
                        break;


                    case "5":
                        academia.RelatorioClientesOrdemIdade();
                        break;


                    case "6":
                        Console.Write("Informe o número do mês: ");
                        int mes;
                        if (!int.TryParse(Console.ReadLine(), out mes))
                            throw new FormatException("Mês deve ser um número inteiro.");
                            academia.RelatorioAniversariantesDoMes(mes);
                        break;

                    case "7":
                        academia.RelatorioTreinosOrdemCrescenteQtdVencimento();
                        break;

                    case "8":
                        //academia.RelatorioTreinadoresOrdemDecrescente();
                        academia.RelatorioTreinadoresOrdemDecrescente();
                        break;

                    case "9":
                        //Precisa tratar entradas vazias
                        System.Console.WriteLine("Insira o objetivo do treino:");
                        string palavraChave = Console.ReadLine();
                        academia.RelatorioTreinosPorPalavraChave(palavraChave);
                        break;

                    case "10":
                        academia.RelatorioTop10ExerciciosMaisUtilizados();
                        break;
   
                    case "0":
                        Console.WriteLine("Voltando para o menu principal...");
                        return;

                    default:
                        Console.WriteLine("Opcão inválida. Tente novamente.");
                        break;
                }
            } while (choice != "0");
        }

    }
  
}


