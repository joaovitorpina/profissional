using Profissional.Domain.SeedWork;

namespace Profissional.Domain.Aggregates.Profissional;

public class Tratamento : ValueObject
{
    public Tratamento(string descricao)
    {
        Descricao = descricao;
    }

    public string Descricao { get; }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Descricao;
    }
}