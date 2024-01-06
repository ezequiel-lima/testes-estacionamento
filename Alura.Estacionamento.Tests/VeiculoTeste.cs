using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace Alura.Estacionamento.Tests
{
    [ExcludeFromCodeCoverage]
    public class VeiculoTeste
    {
        [Fact]
        public void Testa_Veiculo_Acelerar()
        {
            //Arrange
            Veiculo veiculo = new Veiculo();
            
            //Act
            veiculo.Acelerar(10);

            //Assert
            Assert.Equal(100, veiculo.VelocidadeAtual);
        }

        [Fact]
        public void Testa_Veiculo_Freiar()
        {
            //Arrange
            Veiculo veiculo = new Veiculo { VelocidadeAtual = 150 };

            //Act
            veiculo.Frear(10);

            //Assert
            Assert.Equal(0, veiculo.VelocidadeAtual);
        }

        [Theory]
        [InlineData("André Silva", TipoVeiculo.Automovel, "Verde", "Fusca", "qwe-7894")]
        [InlineData("Raquel Miriam", TipoVeiculo.Automovel, "Vermelho", "Honda", "xvd-1598")]
        public void Testa_Ficha_De_Informacao_Veiculo(string proprietario, TipoVeiculo tipo, string cor, string modelo, string placa)
        {
            //Arrange
            Veiculo veiculo = new Veiculo { Proprietario = proprietario, Tipo = tipo, Cor = cor, Modelo = modelo, Placa = placa };

            //Act
            string dados = veiculo.ToString();

            //Assert
            Assert.Contains("Ficha do Veiculo:", dados);
        }

        [Theory]
        [InlineData("André Silva", TipoVeiculo.Automovel, "Verde", "Fusca", "q2e-7894")]
        [InlineData("Raquel Miriam", TipoVeiculo.Automovel, "Vermelho", "Honda", "x23-1598")]
        [InlineData("Stefany Fortuna", TipoVeiculo.Automovel, "Rosa", "Yamaha", "123-1598")]
        public void Testa_Se_Os_Tres_Primeiros_Caracteres_Da_Placa_Sao_Numeros_Deve_Retornar_Exception(string proprietario, TipoVeiculo tipo, string cor, string modelo, string placa)
        {
            // Act 
            var mensagem = Assert.Throws<FormatException>(() => new Veiculo { Proprietario = proprietario, Tipo = tipo, Cor = cor, Modelo = modelo, Placa = placa });

            // Assert
            Assert.Equal("Os 3 primeiros caracteres devem ser letras!", mensagem.Message);
        }

        [Fact]
        public void Construtor_Deve_Atribuir_Proprietario_Corretamente()
        {
            // Arrange
            string proprietario = "João Dutra";

            // Act 
            Veiculo veiculo = new Veiculo(proprietario);

            // Assert
            Assert.Equal(proprietario, veiculo.Proprietario);
        }

        [Theory]
        [InlineData("André Silva", TipoVeiculo.Automovel, "Verde", "Fusca", "qme-789")]
        [InlineData("Raquel Miriam", TipoVeiculo.Automovel, "Vermelho", "Honda", "xtp-15986")]
        [InlineData("Stefany Fortuna", TipoVeiculo.Automovel, "Rosa", "Yamaha", "cht-159832")]
        public void Checa_Se_O_Valor_Da_Placa_Possui_Exatamente_Oito_Caracteres_Deve_Retornar_Exception(string proprietario, TipoVeiculo tipo, string cor, string modelo, string placa)
        {
            // Act 
            var mensagem = Assert.Throws<FormatException>(() => new Veiculo { Proprietario = proprietario, Tipo = tipo, Cor = cor, Modelo = modelo, Placa = placa });

            // Assert
            Assert.Equal(" A placa deve possuir 8 caracteres", mensagem.Message);
        }
    }
}
