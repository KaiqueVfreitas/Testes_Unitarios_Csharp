using CalculadoraTestesUnitarios;
using System;
using Xunit;

namespace TestCalculadora
{
    public class TesteCalculadora
    {
        [Fact]
        public void TesteSomar()
        {
            Assert.Equal(20, Calculadora.Somar(10, 10));
        }
        [Fact]
        public void TesteSubtrair()
        {
            Assert.Equal(0, Calculadora.Subtrair(10, 10));
        }
        [Fact]
        public void TesteMultiplicacao()
        {
            Assert.Equal(100, Calculadora.Multiplicacao(10, 10));
        }
        [Fact]
        public void TesteDivisao()
        {
            Assert.Equal(1, Calculadora.Divisao(10, 10));
        }
    }
}
