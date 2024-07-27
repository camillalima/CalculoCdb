using B3.CalculoCdb.Domain.Interfaces;
using B3.CalculoCdb.Domain.Models;
using B3.CalculoCdb.Domain.Utils;

namespace B3.CalculoCdb.Domain.Services
{
    public class CalculoCdbService : ICalculoCdbService
    {
        public CalculoCdbViewModel CalculaCdb(double valorInvestido, int prazo)
        {
            var valorBruto = CalcularValorBruto(valorInvestido, prazo);

            var valorLiquido = CalcularValorLiquido(valorBruto, valorInvestido, prazo);

            return new CalculoCdbViewModel { ValorBruto = valorBruto, ValorLiquido = valorLiquido };
        }

        private static double CalcularValorLiquido(double valorBruto, double valorInvestido, int prazo)
        {
            var imposto = CalcularImposto(valorBruto, valorInvestido, prazo);

            return valorBruto - imposto;
        }

        private static double CalcularImposto(double valorBruto, double valorInvestido, int prazo)
        {
            var rendimento = valorBruto - valorInvestido;

            var aliquota = GetAliquota(prazo);

            return rendimento * aliquota;
        }

        private static double GetAliquota(int prazo)
        {
            return prazo switch
            {
                <= 6 => Aliquota.SeisMeses,
                <= 12 => Aliquota.DozeMeses,
                <= 24 => Aliquota.VinteEQuatroMeses,
                _ => Aliquota.AcimaVinteEQuatroMeses
            };
        }

        private static double CalcularValorBruto(double valorInvestido, int prazo)
        {
            var valorBruto = valorInvestido;

            for (var i = 0; i < prazo; i++) valorBruto = CalculoCdb(valorBruto);

            return valorBruto;
        }

        private static double CalculoCdb(double valorBruto)
        {
            return valorBruto * (1 + (Taxa.CDI * Taxa.Banco));
        }
    }
}