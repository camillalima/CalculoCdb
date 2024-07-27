using B3.CalculoCdb.Domain.Models;

namespace B3.CalculoCdb.Domain.Interfaces
{
    public interface ICalculoCdbService
    {
        CalculoCdbViewModel CalculaCdb(double valorInvestido, int prazo);
    }
}