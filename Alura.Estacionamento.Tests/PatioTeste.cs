﻿using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using Xunit;

namespace Alura.Estacionamento.Tests
{
    public class PatioTeste
    {
        private readonly Patio _estacionamento;

        public PatioTeste()
        {
            _estacionamento = new Patio();
        }

        [Theory]
        [InlineData("André Silva", TipoVeiculo.Automovel, "Verde", "Fusca", "qwe-7894")]
        [InlineData("Renata Barros", TipoVeiculo.Automovel, "Vermelho", "Fiesta", "jki-2165")]
        public void Valida_Faturamento_Com_Automovel(string proprietario, TipoVeiculo tipo, string cor, string modelo, string placa)
        {
            // Arrange
            Veiculo veiculo = new Veiculo { Proprietario = proprietario, Tipo = tipo, Cor = cor, Modelo = modelo, Placa = placa };
            _estacionamento.RegistrarEntradaVeiculo(veiculo);
            _estacionamento.RegistrarSaidaVeiculo(placa);

            // Act
            double faturamento = _estacionamento.TotalFaturado();

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
            Veiculo veiculo = new Veiculo { Proprietario = proprietario, Tipo = tipo, Cor = cor, Modelo = modelo, Placa = placa };
            _estacionamento.RegistrarEntradaVeiculo(veiculo);
            _estacionamento.RegistrarSaidaVeiculo(placa);

            // Act
            double faturamento = _estacionamento.TotalFaturado();

            // Assert
            Assert.Equal(1, faturamento);
        }

        [Theory]
        [InlineData("André Silva", TipoVeiculo.Automovel, "Verde", "Fusca", "qwe-7894")]
        [InlineData("Ingriddy Santos", TipoVeiculo.Motocicleta, "Vermelho", "Yamaha", "hgf-3695")]
        public void Localiza_Veiculo_No_Patio(string proprietario, TipoVeiculo tipo, string cor, string modelo, string placa)
        {
            // Arrange
            Veiculo veiculo = new Veiculo { Proprietario = proprietario, Tipo = tipo, Cor = cor, Modelo = modelo, Placa = placa };
            _estacionamento.RegistrarEntradaVeiculo(veiculo);

            // Act
            var carroEstacionado = _estacionamento.PesquisaVeiculo(placa);

            // Assert
            Assert.Equal(placa, carroEstacionado.Placa);
        }

        [Theory]
        [InlineData("André Silva", TipoVeiculo.Automovel, "Verde", "Fusca", "qwe-7894")]
        public void Alterar_Dados_Veiculo(string proprietario, TipoVeiculo tipo, string cor, string modelo, string placa)
        {
            // Arrange
            Veiculo veiculo = new Veiculo { Proprietario = proprietario, Tipo = tipo, Cor = cor, Modelo = modelo, Placa = placa };
            _estacionamento.RegistrarEntradaVeiculo(veiculo);
            Veiculo veiculoUpdate = new Veiculo { Proprietario = proprietario, Tipo = tipo, Cor = "Vermelho", Modelo = modelo, Placa = placa };

            // Act
            var carroAlterado = _estacionamento.AlterarDadosVeiculo(placa, veiculoUpdate);

            // Assert
            Assert.Equal(veiculoUpdate.Cor, carroAlterado.Cor);
        }
    }
}
