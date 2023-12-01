using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;

namespace atividadeAv
{
    public class Academia
    {
        public static List<Treinador> AdicionaTreinadores()
        {
            List<Treinador> treinadores = new List<Treinador>();
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


            return treinadores;
        }

        public static List<Cliente> AdicionaCliente()
        {
            List<Cliente> clientes = new List<Cliente>();
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

            return clientes;

        }
        public static List<Exercicio> AdicionaExercicio()
        {
            List<Exercicio> exercicios = new List<Exercicio>();
            //Incluindo alguns exercicios
            //GrupoMuscular, Series, Repeticoes, TempoIntervaloSegundos
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
            
            return exercicios;
        }
        public static List<Treino> AdicionaTreinos(List<Treinador> treinadores, List<Cliente> clientes, List<Exercicio> exercicios)
        {
            List<Treino> treinos = new List<Treino>();

            //Inclusao do Treino 1 e todo o vinculo
            Treino treino1 = new Treino("Musculação", "Hipertrofia", treinadores[0]);

            // Adiciona exercícios ao treino
            treino1.AdicionarExercicio(exercicios[0]);
            treino1.AdicionarExercicio(exercicios[1]);
            // ... adicione mais exercícios conforme necessário

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

             //Inclusao do Treino 2 e todo o vinculo
            Treino treino2 = new Treino("Cardio", "Emagrecimento", treinadores[1]);

            // Adiciona exercícios ao treino
            treino2.AdicionarExercicio(exercicios[5]);
            treino2.AdicionarExercicio(exercicios[6]);
            treino2.AdicionarExercicio(exercicios[7]);
            treino2.AdicionarExercicio(exercicios[8]);
            

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

            // Adicione o treino à lista de treinos
            treinos.Add(treino2);

           

            return treinos;
        }
    }
}