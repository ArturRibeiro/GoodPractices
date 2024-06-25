namespace Specification.Unit.Testing.Sorts.Fakers;

public class Vaga
{
    public List<Totalizador> Totalizadores = new();
    
    public int CalcularTotalDoMes() =>
        this.Totalizadores
            .GroupBy(t => new { t.Data.Year, t.Data.Month })
            .Select(g => g.Sum(t => t.TotalDia))
            .FirstOrDefault();
}