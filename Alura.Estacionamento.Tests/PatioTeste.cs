using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using Xunit;

namespace Alura.Estacionamento.Tests
{
    public class PatioTeste
    {
        [Theory]
        [InlineData("André Silva", TipoVeiculo.Automovel, "Verde", "Fusca", "qwe-7894")]
        [InlineData("Renata Barros", TipoVeiculo.Automovel, "Vermelho", "Fiesta", "jki-2165")]
        public void Valida_Faturamento_Com_Automovel(string proprietario, TipoVeiculo tipo, string cor, string modelo, string placa)
        {
            // Arrange
            Patio estacionamento = new Patio();
            Veiculo veiculo = new Veiculo { Proprietario = proprietario, Tipo = tipo, Cor = cor, Modelo = modelo, Placa = placa };
            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(placa);

            // Act
            double faturamento = estacionamento.TotalFaturado();

            // Assert
            Assert.Equal(2, faturamento);
        }

        [Theory]
        [InlineData("Primila Lima", TipoVeiculo.Motocicleta, "Rosa", "Honda", "vbn-5951")]
        [InlineData("Ingriddy Santos", TipoVeiculo.Motocicleta, "Vermelho", "Yamaha", "hgf-3695")]
        [InlineData("Kimberly Stefani", TipoVeiculo.Motocicleta, "Amarelo", "Yamaha", "cxz-1425")]
        public void Valida_Faturamento_Com_Motocicleta(string proprietario, TipoVeiculo tipo, string cor, string modelo, string placa)
        {
            // Arrange
            Patio estacionamento = new Patio();
            Veiculo veiculo = new Veiculo { Proprietario = proprietario, Tipo = tipo, Cor = cor, Modelo = modelo, Placa = placa };
            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(placa);

            // Act
            double faturamento = estacionamento.TotalFaturado();

            // Assert
            Assert.Equal(1, faturamento);
        }
    }
}
