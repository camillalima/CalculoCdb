using B3.CalculoCdb.Application.Services;
using B3.CalculoCdb.Application.Utils;

namespace B3.CalculoCdb.Tests.Services
{
    public class ValidaServiceTest
    {
        [Theory]
        [InlineData(0, 0)]
        [InlineData(-1, 0)]
        public void ValidaValorInvestidoThrowsException(double valorInvestido, int prazo)
        {
            var result = Record.Exception(() => ValidaService.Valida(valorInvestido, prazo));

            Assert.IsType<ArgumentException>(result);
            Assert.Equal(MensagemErro.ValorInvestidoInvalido, result.Message);
        }

        [Theory]
        [InlineData(99.3, -1)]
        [InlineData(100, 0)]
        [InlineData(100.56, 1)]
        public void ValidaPrazoThrowsException(double valorInvestido, int prazo)
        {
            var result = Record.Exception(() => ValidaService.Valida(valorInvestido, prazo));

            Assert.IsType<ArgumentException>(result);
            Assert.Equal(MensagemErro.PrazoInvalido, result.Message);
        }

        [Theory]
        [InlineData(99.3, 2)]
        [InlineData(100, 6)]
        [InlineData(100.56, 30)]
        public void ValidaValoresValidos(double valorInvestido, int prazo)
        {
            var result = Record.Exception(() => ValidaService.Valida(valorInvestido, prazo));

            Assert.Null(result);
        }
    }
}