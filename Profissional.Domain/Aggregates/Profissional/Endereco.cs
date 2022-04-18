using Profissional.Domain.SeedWork;

namespace Profissional.Domain.Aggregates.Profissional;

public class Endereco : ValueObject
{
    public Endereco(string? logradouro, string? numero, string? bairro, string cidade, string estado, long? cep)
    {
        Logradouro = logradouro;
        Numero = numero;
        Bairro = bairro;
        Cidade = cidade;
        Estado = estado;
        Cep = cep;
    }

    public string? Logradouro { get; }
    public string? Numero { get; }
    public string? Bairro { get; }
    public string Cidade { get; }
    public string Estado { get; }
    public long? Cep { get; }


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