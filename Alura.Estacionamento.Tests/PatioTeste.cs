using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using Xunit;

namespace Alura.Estacionamento.Tests
{
    public class PatioTeste
    {
        [Fact]
        public void Valida_Faturamento()
        {
            // Arrange
            Patio estacionamento = new Patio();
            Veiculo veiculo = new Veiculo { Proprietario = "André Silva", Tipo = TipoVeiculo.Automovel, Cor = "Verde", Modelo = "Fusca", Placa = "qwe-7894" };           
            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo("qwe-7894");

            // Act
            double faturamento = estacionamento.TotalFaturado();

            // Assert
            Assert.Equal(2, faturamento);
        }
    }
}
