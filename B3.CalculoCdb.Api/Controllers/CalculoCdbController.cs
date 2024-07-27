using B3.CalculoCdb.Application.Services;
using B3.CalculoCdb.Domain.Interfaces;
using B3.CalculoCdb.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace B3.CalculoCdb.Api.Controllers
{
    [ApiController]
    [Route("api/calculo-cdb")]
    public class CalculoCdbController : ControllerBase
    {
        private readonly ICalculoCdbService _calculoCdbService;

        public CalculoCdbController(ICalculoCdbService calculoCdbService) => _calculoCdbService = calculoCdbService;

        /// <summary>
        /// Cálculo do CDB
        /// </summary>
        /// <param name="valorInvestido">Valor do investimento</param>
        /// <param name="prazo">Prazo em meses</param>
        /// <response code="200">Success</response>
        /// <response code="400">BadRequest</response>
        [HttpGet]
        [ProducesResponseType<CalculoCdbViewModel>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetCalculoCdb(double valorInvestido, int prazo)
        {
            try
            {
                ValidaService.Valida(valorInvestido, prazo);

                CalculoCdbViewModel response = _calculoCdbService.CalculaCdb(valorInvestido, prazo);

                return Ok(response);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}