namespace DIO.Calculadora;

public class Calculadora
{
    private readonly List<string> _historico;
    private readonly DateTime dateTime;
    private readonly string _data;

    public Calculadora()
    {
        _historico = new();
        dateTime = DateTime.Now;
        _data = dateTime.ToString("dd/MM/yyyy");
    }

    public double Somar(double x, double y)
    {
        double resultado = x + y;

        AdicionarHistorico(nameof(Somar), x, y, resultado, _data);

        return resultado;
    }

    public double Subtrair(double x, double y)
    {
        double resultado = x - y;

        AdicionarHistorico(nameof(Subtrair), x, y, resultado, _data);

        return resultado;
    }

    public double Multiplicar(double x, double y)
    {
        double resultado = x * y;

        AdicionarHistorico(nameof(Multiplicar), x, y, resultado, _data);

        return resultado;
    }

    public double Dividir(double x, double y)
    {
        double resultado = x / y;

        AdicionarHistorico(nameof(Dividir), x, y, resultado, _data);

        return resultado;
    }

    public void AdicionarHistorico(string operacao, double x, double y, double resultado, string data)
    {
        _historico.Insert(0, $"Operação -> {operacao}({x}, {y}) = {resultado} - Data: {data}");
    }

    public string ExibirResultadoOperacao(string operacao, double x, double y, double resultado)
    {
        return $"Operação -> {operacao}({x}, {y}) = {resultado} - Data: {_data}";
    }

    public List<string> ExibirHistorico()
    {
        if (_historico.Count > 3)
        {
            _historico.RemoveRange(3, _historico.Count - 3);
        }

        return _historico;
    }

    public Tuple<double, double> ColetarValores()
    {
        Console.Write("Informe o primeiro valor: ");
        _ = double.TryParse(Console.ReadLine(), out var valor1);
        Console.Write("Informe o segundo valor: ");
        _ = double.TryParse(Console.ReadLine(), out var valor2);

        Tuple<double, double> resultado = new(valor1, valor2);

        return resultado;
    }
}
