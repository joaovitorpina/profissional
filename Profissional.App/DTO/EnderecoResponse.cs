namespace Profissionais.App.DTO;

public class EnderecoResponse
{
    public EnderecoResponse(string estado, string cidade, string? logradouro, string? bairro, long? cep)
    {
        Estado = estado;
        Cidade = cidade;
        Logradouro = logradouro;
        Bairro = bairro;
        Cep = cep;
    }

    public string Estado { get; set; }
    public string Cidade { get; set; }
    public string? Logradouro { get; set; }
    public string? Bairro { get; set; }
    public long? Cep { get; set; }
}