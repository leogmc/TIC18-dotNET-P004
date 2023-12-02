using System;
using System.Collections.Generic;
using System.Linq;

class Treino
{
    public int Id { get; set; }
    public string Objetivo { get; set; }
}

class Program
{
    static void Main()
    {
        List<Treino> treinos = new List<Treino>
        {
            new Treino { Id = 1, Objetivo = "Emagrecimento e Resistência" },
            new Treino { Id = 2, Objetivo = "Força e Condicionamento" },
            new Treino { Id = 3, Objetivo = "Emagrecimento" },
            new Treino { Id = 4, Objetivo = "Flexibilidade" },
        };

        string palavraChave = "Emagrecimento";

        var treinosComPalavraChave = BuscarTreinosPorPalavraChave(treinos, palavraChave);

        foreach (var treino in treinosComPalavraChave)
        {
            Console.WriteLine($"Treino ID: {treino.Id}, Objetivo: {treino.Objetivo}");
        }
    }

    static IEnumerable<Treino> BuscarTreinosPorPalavraChave(List<Treino> treinos, string palavraChave)
    {
        return treinos.Where(t => t.Objetivo.Contains(palavraChave));
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

class Exercicio
{
    public int Id { get; set; }
    public string Nome { get; set; }
}

class ExercicioQuantidade
{
    public string Nome { get; set; }
    public int Quantidade { get; set; }
}

class Treino
{
    public int Id { get; set; }
    public List<Exercicio> Exercicios { get; set; }
}

class Program
{
    static void Main()
    {
        List<Exercicio> exercicios = new List<Exercicio>
        {
            new Exercicio { Id = 1, Nome = "Agachamento" },
            new Exercicio { Id = 2, Nome = "Supino" },
            new Exercicio { Id = 3, Nome = "Corrida" },
        
        };

        List<Treino> treinos = new List<Treino>
        {
            new Treino { Id = 1, Exercicios = new List<Exercicio> { exercicios[0], exercicios[1], exercicios[2] } },
            new Treino { Id = 2, Exercicios = new List<Exercicio> { exercicios[0], exercicios[1] } },
            new Treino { Id = 3, Exercicios = new List<Exercicio> { exercicios[0], exercicios[2] } },
        
        };

        var exerciciosUtilizados = ObterTopExerciciosUtilizados(treinos);

        foreach (var exercicio in exerciciosUtilizados)
        {
            Console.WriteLine($"Exercício: {exercicio.Nome}, Utilizado {exercicio.Quantidade} vezes");
        }
    }

    static IEnumerable<ExercicioQuantidade> ObterTopExerciciosUtilizados(List<Treino> treinos)
    {
        return treinos.SelectMany(t => t.Exercicios)
                      .GroupBy(e => e.Nome)
                      .Select(group => new ExercicioQuantidade { Nome = group.Key, Quantidade = group.Count() })
                      .OrderByDescending(e => e.Quantidade)
                      .Take(10);
    }
}



/*public void RelatorioTreinosPorPalavraChave(string palavraChave)
{
    System.Console.WriteLine($"9.Treinos com objetivo contendo a palavra-chave '{palavraChave}'");
    System.Console.WriteLine("--------------------------------------");

    var treinosComPalavraChave = treinos.Where(t => t.Objetivo.Contains(palavraChave));

    foreach (var treino in treinosComPalavraChave)
    {
        Console.WriteLine($"Treino: {treino.Nome}, Objetivo: {treino.Objetivo}");
    }
    Console.WriteLine("");
}
public void RelatorioTop10ExerciciosMaisUtilizados()
{
    System.Console.WriteLine("10.Top 10 exercícios mais utilizados nos treinos");
    System.Console.WriteLine("--------------------------------------");

    var exerciciosUtilizados = treinos.SelectMany(t => t.Exercicios)
            .GroupBy(e => e.Nome)
            .Select(g => new { NomeExercicio = g.Key, Quantidade = g.Count() })
            .OrderByDescending(g => g.Quantidade)
            .Take(10);

    foreach (var exercicio in exerciciosUtilizados)
    {
        Console.WriteLine($"Exercício: {exercicio.NomeExercicio}, Quantidade: {exercicio.Quantidade}");
    }
    Console.WriteLine("");
}
*/