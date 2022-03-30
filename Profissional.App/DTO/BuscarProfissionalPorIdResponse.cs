namespace Profissionais.App.DTO;

public class BuscarProfissionalPorIdResponse
{
    public BuscarProfissionalPorIdResponse(int id, string nome, string imagemPerfilUrl,
        EnderecoResponse endereco, string tipo, string[] especialidades, string? conselho, string? numeroIdentificacao,
        long? celular, long? telefone, string? facebook, string? instagram, string? email, string? site, string? sobre)
    {
        Id = id;
        Nome = nome;
        ImagemPerfilUrl = imagemPerfilUrl;
        Endereco = endereco;
        Tipo = tipo;
        Especialidades = especialidades;
        Conselho = conselho;
        NumeroIdentificacao = numeroIdentificacao;
        Celular = celular;
        Telefone = telefone;
        Facebook = facebook;
        Instagram = instagram;
        Email = email;
        Site = site;
        Sobre = sobre;
    }

    public int Id { get; }
    public string Nome { get; }
    public string ImagemPerfilUrl { get; }
    public EnderecoResponse Endereco { get; }
    public string Tipo { get; }
    public string[] Especialidades { get; }
    public string? Conselho { get; }
    public string? NumeroIdentificacao { get; }
    public long? Celular { get; }
    public long? Telefone { get; }
    public string? Facebook { get; }
    public string? Instagram { get; }
    public string? Email { get; }
    public string? Site { get; }
    public string? Sobre { get; }
}