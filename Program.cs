using atividadeAv;
using System.Globalization;

CultureInfo.CurrentCulture = CultureInfo.CreateSpecificCulture("pt-BR");
List<Treinador> treinadores = Academia.AdicionaTreinadores();
List<Cliente> clientes = Academia.AdicionaCliente();
List<Exercicio> exercicios = Academia.AdicionaExercicio();
//List<Treino> treinos = Academia.AdicionaTreinos(treinadores, clientes, exercicios);
// . Treinadores com idade entre dois valores
// 2. Clientes com idade entre dois valores
// 3. Clientes com IMC (peso/altura*altura) maior que um valor informado,
// em ordem crescente
// 4. Clientes em ordem alfabética
System.Console.WriteLine("1. Treinadores com idade entre 40 e 60 anos");
System.Console.WriteLine("--------------------------------------");
var treinadoresMais40 = treinadores.Where(t => t.Idade >= 40 && t.Idade <= 60);

foreach (var treinador in treinadoresMais40)
{
    Console.WriteLine($"Treinador: Nome: {treinador.Nome}, Idade: {treinador.Idade}");
}
Console.WriteLine("");

System.Console.WriteLine("2. Clientes com idade entre 23 e 50 anos");
System.Console.WriteLine("--------------------------------------");
var clientesMais23 = clientes.Where(t => t.Idade >= 23 && t.Idade <= 50);

foreach (var cliente in clientesMais23)
{
    Console.WriteLine($"Cliente: Nome: {cliente.Nome}, Idade: {cliente.Idade}");
}
Console.WriteLine("");

System.Console.WriteLine("3. Clientes com IMC (peso/altura*altura) maior que 20");
System.Console.WriteLine("--------------------------------------");

var clientesMaisIMC = clientes.Where(t => (t.Peso / (t.Altura * t.Altura)) >= 20);

foreach (var cliente in clientesMaisIMC)
{
    Console.WriteLine($"Nome: {cliente.Nome}, IMC: {cliente.Peso / (cliente.Altura * cliente.Altura)}");
}
Console.WriteLine("");

System.Console.WriteLine("4. Clientes em ordem alfabética");
System.Console.WriteLine("--------------------------------------");
var clientesOrdem = clientes.OrderBy(c => c.Nome);
foreach (var cliente in clientesOrdem)
{
    Console.WriteLine($"Nome: {cliente.Nome}, Idade: {cliente.Idade}");
}
Console.WriteLine("");

System.Console.WriteLine("5. Clientes em ordem idade");
System.Console.WriteLine("--------------------------------------");
var clientesOrdemIdade = clientes.OrderBy(c => c.Idade);
foreach (var cliente in clientesOrdemIdade)
{
    Console.WriteLine($"Nome: {cliente.Nome}, Idade: {cliente.Idade}");
}
Console.WriteLine("");

System.Console.WriteLine("6. Treinadores e clientes aniversariantes do mês 2");
System.Console.WriteLine("--------------------------------------");
List<Pessoa> pessoas = new List<Pessoa>();
pessoas.AddRange(treinadores);
pessoas.AddRange(clientes);

var aniversariantes = pessoas.Where(p => p.DtNascimento.Month == 2);
foreach (var pessoa in aniversariantes)
{
    Console.WriteLine($"Nome: {pessoa.Nome}, Data de Nascimento: {pessoa.DtNascimento}, Idade: {pessoa.Idade}");
}