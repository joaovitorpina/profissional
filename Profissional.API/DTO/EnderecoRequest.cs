using System.ComponentModel.DataAnnotations;

namespace Profissional.API.DTO;

public class EnderecoRequest
{
    public string? Logradouro { get; set; }
    public string? Numero { get; set; }
    public string? Bairro { get; set; }
    public string Cidade { get; set; }
    public string Estado { get; set; }

    [Range(0, 99999999, ErrorMessage = "cep deve ter no maximo 8 digitos")]
    public long? Cep { get; set; }
}