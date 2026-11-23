using System;
using Xunit;
using Calc = CalculadoraDesconto.App.CalculadoraDesconto;

namespace CalculadoraDesconto.Tests;

public class CalculadoraDescontoTests
{
    [Theory]
    [InlineData(100, 10, 90)]
    [InlineData(200, 0, 200)]
    [InlineData(80, 100, 0)]
    public void Desconto_ValoresValidos(decimal preco, decimal percentual, decimal esperado)
    {
        var servico = new Calc();
        Assert.Equal(esperado, servico.Calcular(preco, percentual));
    }

    [Theory]
    [InlineData(-1, 10)]
    [InlineData(100, -5)]
    [InlineData(100, 110)]
    public void Desconto_ValoresInvalidos(decimal preco, decimal percentual)
    {
        var servico = new Calc();
        Assert.Throws<ArgumentOutOfRangeException>(() => servico.Calcular(preco, percentual));
    }
}