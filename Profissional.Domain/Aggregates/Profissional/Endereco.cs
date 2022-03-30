using Profissional.Domain.SeedWork;

namespace Profissional.Domain.Aggregates.Profissional;

public class Endereco : ValueObject
{
    public string? Logradouro { get; private set; }
    public string? Numero { get; private set; }
    public string? Bairro { get; private set; }
    public string Cidade { get; private set; }
    public string Estado { get; private set; }
    public long? Cep { get; private set; }


    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Logradouro;
        yield return Numero;
        yield return Bairro;
        yield return Cidade;
        yield return Estado;
        yield return Cep;
    }
}