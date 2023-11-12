// See https://aka.ms/new-console-template for more information
using DIO.Calculadora;

Calculadora calculadora = new();
Tuple<double, double> valores;
double resultado;
string mostrarResultado;
List<string> historico;

while (true)
{
    Console.WriteLine("Calculadora - DIO");
    Console.WriteLine();
    Console.WriteLine("Digite a operação: ");
    Console.WriteLine("1 - Soma");
    Console.WriteLine("2 - Subtração");
    Console.WriteLine("3 - Multiplicação");
    Console.WriteLine("4 - Divisão");
    Console.WriteLine("5 - Histórico");
    Console.WriteLine("6 - Encerrar");

    string? operacaoCalculadora = Console.ReadLine();
    Console.WriteLine();

    switch (operacaoCalculadora)
    {
        case "1":
            valores = calculadora.ColetarValores();
            resultado = calculadora.Somar(valores.Item1, valores.Item2);
            mostrarResultado = calculadora.ExibirResultadoOperacao(nameof(calculadora.Somar), valores.Item1, valores.Item2, resultado);
            Console.WriteLine(mostrarResultado);
            break;

        case "2":
            valores = calculadora.ColetarValores();
            resultado = calculadora.Subtrair(valores.Item1, valores.Item2);
            mostrarResultado = calculadora.ExibirResultadoOperacao(nameof(calculadora.Subtrair), valores.Item1, valores.Item2, resultado);
            Console.WriteLine(mostrarResultado);
            break;

        case "3":
            valores = calculadora.ColetarValores();
            resultado = calculadora.Multiplicar(valores.Item1, valores.Item2);
            mostrarResultado = calculadora.ExibirResultadoOperacao(nameof(calculadora.Multiplicar), valores.Item1, valores.Item2, resultado);
            Console.WriteLine(mostrarResultado);
            break;

        case "4":
            valores = calculadora.ColetarValores();
            resultado = calculadora.Dividir(valores.Item1, valores.Item2);
            mostrarResultado = calculadora.ExibirResultadoOperacao(nameof(calculadora.Dividir), valores.Item1, valores.Item2, resultado);
            Console.WriteLine(mostrarResultado);
            break;

        case "5":
            historico = calculadora.ExibirHistorico();
            foreach (var operacao in historico)
            {
                Console.WriteLine(operacao);
            }
            Console.WriteLine();
            break;

        case "6":
            Environment.Exit(0);
            break;
    }
}