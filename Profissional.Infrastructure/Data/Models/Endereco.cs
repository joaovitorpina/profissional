using System.ComponentModel.DataAnnotations;

namespace Profissional.Infrastructure.Data.Models;

public class Endereco
{
    private Endereco()
    {
    }

    public Endereco(Profissional profissional, string cidade, string estado) : this()
    {
        Profissional = profissional;
        Cidade = cidade;
        Estado = estado;
    }

    [Key] public int ProfissionalId { get; set; }

    public Profissional Profissional { get; set; }
    public string? Logradouro { get; set; }
    public string? Numero { get; set; }
    public string? Bairro { get; set; }
    public string Cidade { get; set; }
    public string Estado { get; set; }
    public long? Cep { get; set; }
}