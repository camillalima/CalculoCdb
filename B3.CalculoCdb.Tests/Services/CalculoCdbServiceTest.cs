using B3.CalculoCdb.Domain.Services;

namespace B3.CalculoCdb.Tests.Services
{
    public class CalculoCdbServiceTest
    {
        private readonly CalculoCdbService _service;

        public CalculoCdbServiceTest()
        {
            _service = new CalculoCdbService();
        }

        [Theory]
        [InlineData(100.59, 6, 106.60)]
        [InlineData(100.59, 12, 112.97)]
        [InlineData(100.59, 24, 126.88)]
        [InlineData(100.59, 50, 163.16)]
        public void CalculaCdb_ValidaValorBruto(double valorInvestido, int prazo, double valorBrutoEsperado)
        {
            var result = _service.CalculaCdb(valorInvestido, prazo);

            Assert.Equal(valorBrutoEsperado, result.ValorBruto);
        }

        [Theory]
        [InlineData(100.59, 6, 105.25)]
        [InlineData(100.59, 12, 110.49)]
        [InlineData(100.59, 24, 122.28)]
        [InlineData(100.59, 50, 153.77)]
        public void CalculaCdb_ValidaValorLiquido(double valorInvestido, int prazo, double valorLiquidoEsperado)
        {
            var result = _service.CalculaCdb(valorInvestido, prazo);

            Assert.Equal(valorLiquidoEsperado, result.ValorLiquido);
        }
    }
}