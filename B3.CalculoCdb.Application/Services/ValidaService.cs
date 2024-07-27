using B3.CalculoCdb.Application.Utils;

namespace B3.CalculoCdb.Application.Services
{
    public static class ValidaService
    {
        public static void Valida(double valorInvestido, int prazo)
        {
            if (valorInvestido <= 0)
            {
                throw new ArgumentException(MensagemErro.ValorInvestidoInvalido);
            }

            if (prazo <= 1)
            {
                throw new ArgumentException(MensagemErro.PrazoInvalido);
            }
        }
    }
}