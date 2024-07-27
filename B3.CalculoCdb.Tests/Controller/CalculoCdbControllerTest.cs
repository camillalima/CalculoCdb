using B3.CalculoCdb.Api.Controllers;
using B3.CalculoCdb.Application.Utils;
using B3.CalculoCdb.Domain.Interfaces;
using B3.CalculoCdb.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace B3.CalculoCdb.Tests.Controller
{
    public class CalculoCdbControllerTest
    {
        private readonly Mock<ICalculoCdbService> _calculoCdbService;
        private readonly CalculoCdbController _controller;

        public CalculoCdbControllerTest()
        {
            _calculoCdbService = new Mock<ICalculoCdbService>();
            _controller = new CalculoCdbController(_calculoCdbService.Object);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(-1, 0)]
        public void GetCalculoCdb_ValorInvestidoInvalido_RetornaBadRequest(double valorInvestido, int prazo)
        {
            var result = _controller.GetCalculoCdb(valorInvestido, prazo);

            Assert.IsType<BadRequestObjectResult>(result);

            Assert.Equal(MensagemErro.ValorInvestidoInvalido, ((BadRequestObjectResult)result).Value);

            _calculoCdbService.Verify(service => service.CalculaCdb(valorInvestido, prazo), Times.Never);
        }

        [Theory]
        [InlineData(10, -1)]
        [InlineData(10, 0)]
        [InlineData(10, 1)]
        public void GetCalculoCdb_PrazoInvalido_RetornaBadRequest(double valorInvestido, int prazo)
        {
            var result = _controller.GetCalculoCdb(valorInvestido, prazo);

            Assert.IsType<BadRequestObjectResult>(result);

            Assert.Equal(MensagemErro.PrazoInvalido, ((BadRequestObjectResult)result).Value);

            _calculoCdbService.Verify(service => service.CalculaCdb(valorInvestido, prazo), Times.Never);
        }

        [Fact]
        public void GetCalculoCdb_ValorInvestidoEPrazoValidos_RetornaOk()
        {
            var valorInvestido = 10;
            var prazo = 2;

            _calculoCdbService
                .Setup(service => service.CalculaCdb(valorInvestido, prazo))
                .Returns(new CalculoCdbViewModel());

            var result = _controller.GetCalculoCdb(valorInvestido, prazo);

            Assert.IsType<OkObjectResult>(result);

            _calculoCdbService.Verify(service => service.CalculaCdb(valorInvestido, prazo), Times.Once);
        }
    }
}