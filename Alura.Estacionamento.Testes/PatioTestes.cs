using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using Xunit;

namespace Alura.Estacionamento.Testes
{
    public class PatioTestes
    {
        [Fact]
        public void ValidaFaturamento()
        {
            //arrange
            var estacionamento = new Patio();
            var veiculo = new Veiculo
            {
                Proprietario = "Allan",
                Tipo = TipoVeiculo.Automovel,
                Cor = "Verde",
                Modelo = "Fusca",
                Placa = "ABC-9999"
            };

            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            //act
            double faturamento = estacionamento.TotalFaturado();

            //assert
            Assert.Equal(2, faturamento);
        }

        [Theory]
        [InlineData("Allan", "ABC-9999", "preto", "celta")]
        [InlineData("Kimberlly", "DEF-9999", "branco", "civic")]
        [InlineData("Nome", "GHI-9999", "prata", "sandero")]
        public void ValidaFaturamentosComVariosVeiculos(string proprietario,string placa, string cor, string modelo)
        {
            //arrange
            Patio estacionamento = new Patio();
            var veiculo = new Veiculo
            {
                Proprietario = proprietario,
                Tipo = TipoVeiculo.Automovel,
                Cor = cor,
                Modelo = modelo,
                Placa = placa
            };

            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            //act
            double faturamento = estacionamento.TotalFaturado();

            //assert
            Assert.Equal(2, faturamento);
        }
    }
}
