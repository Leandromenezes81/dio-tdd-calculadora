namespace DIO.Calculadora.Tests;

public class CalculadoraTest
{
    public static Calculadora ConstruirCalculadora()
    {
        return new Calculadora();
    }

    [Theory]
    [InlineData(1, 2, 3)]
    public void Somar_ValoresPontoFlutuante_RetornaPontoFlutuante(double x, double y, double resultado)
    {
        // Arrange
        Calculadora calculadora = ConstruirCalculadora();

        // Act
        double resultadoSoma = calculadora.Somar(x, y);

        // Assert
        Assert.Equal(resultado, resultadoSoma);
    }

    [Theory]
    [InlineData(3, 2, 1)]
    public void Subtrair_ValoresPontoFlutuante_RetornaPontoFlutuante(double x, double y, double resultado)
    {
        // Arrange
        Calculadora calculadora = ConstruirCalculadora();

        // Act
        double resultadoSubtracao = calculadora.Subtrair(x, y);

        // Assert
        Assert.Equal(resultado, resultadoSubtracao);
    }

    [Theory]
    [InlineData(3, 2, 6)]
    public void Multiplicar_ValoresPontoFlutuante_RetornaPontoFlutuante(double x, double y, double resultado)
    {
        // Arrange
        Calculadora calculadora = ConstruirCalculadora();

        // Act
        double resultadoMultiplicacao = calculadora.Multiplicar(x, y);

        // Assert
        Assert.Equal(resultado, resultadoMultiplicacao);
    }

    [Theory]
    [InlineData(6, 2, 3)]
    public void Dividir_ValoresPontoFlutuante_RetornaPontoFlutuante(double x, double y, double resultado)
    {
        // Arrange
        Calculadora calculadora = ConstruirCalculadora();

        // Act
        double resultadoDivisao = calculadora.Dividir(x, y);

        // Assert
        Assert.Equal(resultado, resultadoDivisao);
    }

    [Fact]
    public void Dividir_ValoresPontoFlutuanteEZero_RetornaInfinity()
    {
        // Arrange
        Calculadora calculadora = ConstruirCalculadora();

        // Act
        double resultadoDivisao = calculadora.Dividir(10, 0);

        // Assert
        Assert.Equal(double.PositiveInfinity, resultadoDivisao);
    }

    [Theory]
    [InlineData(1, 2, 3)]
    public void AdicionarHistorico_Operacao_AdicionaStringFormatadaAoHistorico(double x, double y, double resultado)
    {
        // Arrange
        Calculadora calculadora = ConstruirCalculadora();
        resultado = calculadora.Somar(x, y);
        string operacao = nameof(calculadora.Somar);
        DateTime dateTime = DateTime.Now;
        string data = dateTime.ToString("dd/MM/yyyy");
        List<string> historico = new();

        // Act
        calculadora.AdicionarHistorico(operacao, x, y, resultado, data);
        historico = calculadora.ExibirHistorico();

        // Assert
        Assert.Equal($"Operação -> {operacao}({x}, {y}) = {resultado} - Data: {data}", historico[0]);
    }

    [Theory]
    [InlineData(1, 2, 3)]
    public void ExibirResultadoOperacao_RetornaStringFormatada(double x, double y, double resultado)
    {
        // Arrange
        Calculadora calculadora = ConstruirCalculadora();
        resultado = calculadora.Somar(x, y);
        string operacao = nameof(calculadora.Somar);
        DateTime dateTime = DateTime.Now;
        string data = dateTime.ToString("dd/MM/yyyy");

        // Act
        string exibirResultadoOPeracao = calculadora.ExibirResultadoOperacao(operacao, x, y, resultado);

        Assert.Equal($"Operação -> {operacao}({x}, {y}) = {resultado} - Data: {data}", exibirResultadoOPeracao);
    }


    [Fact]
    public void ExibirHistorico_Operacoes_RetornaTresUltimasOperacoes()
    {
        // Arrange
        Calculadora calculadora = ConstruirCalculadora();
        calculadora.Somar(3, 2);
        calculadora.Subtrair(5, 3);
        calculadora.Multiplicar(3, 15);
        // Act
        List<string> listaHistorico = calculadora.ExibirHistorico();

        // Assert
        Assert.IsType<List<string>>(listaHistorico);
        Assert.Equal(3, listaHistorico.Count);
    }

    [Fact]
    public void ColetarValores_EntradaValida_RetornaTuplaComValores()
    {
        // Arrange
        Calculadora calculadora = ConstruirCalculadora();
        Console.SetIn(new StringReader("Inputs"));

        // Act
        Tuple<double, double> resultado = calculadora.ColetarValores();

        // Assert
        Assert.IsType<Tuple<double, double>>(resultado);
    }
}