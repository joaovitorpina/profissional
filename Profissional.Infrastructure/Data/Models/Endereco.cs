namespace Profissional.Infrastructure.Data.Models;

public class Endereco
{
    private Endereco()
    {
    }

    public Endereco(string cidade, string estado) : this()
    {
        Cidade = cidade;
        Estado = estado;
    }

    public int ProfissionalId { get; set; }

    public ProfissionalModel ProfissionalModel { get; set; }
    public string? Logradouro { get; set; }
    public string? Numero { get; set; }
    public string? Bairro { get; set; }
    public string Cidade { get; set; }
    public string Estado { get; set; }
    public long? Cep { get; set; }
}