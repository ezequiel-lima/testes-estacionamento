using Alura.Estacionamento.Modelos;
using Xunit;

namespace Alura.Estacionamento.Tests
{
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
    }
}
