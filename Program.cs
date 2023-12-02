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
                    case "0":
                        Console.WriteLine("Voltando para o menu principal...");
                        return;
                    default:
                        Console.WriteLine("Opcão inválida. Tente novamente.");
                        break;
                }
            } while (choice != "0");
        }

        public static void RunMenu(Academia academia)
        {
            string choice;
            do
            {
                Console.WriteLine("==== Menu ====");
                Console.WriteLine("1. Adicionar Treinador");
                Console.WriteLine("2. Adicionar Cliente");
                Console.WriteLine("3. Montar Treino");
                Console.WriteLine("4. Executar Treino");
                Console.WriteLine("5. Avaliar Treino");
                Console.WriteLine("6. Menu de Relatórios");
                Console.WriteLine("0. Sair");
                Console.WriteLine("=============");

                Console.Write("Escolha uma opção: ");
                choice = Console.ReadLine();
                try
                {
                    switch (choice)
                    {
                        case "1":
                            academia.AdicionaTreinador();
                            break;
                        case "2":
                            academia.AdicionaCliente();
                            break;
                        case "3":
                            academia.MontarTreino();
                            break;
                        case "4":
                            academia.ExecutarTreino();
                            break;
                        case "5":
                            academia.AvaliarTreino();
                            break;
                        case "6":
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
    }
}
