using Profissional.Infrastructure.Data.Models.Midias;

namespace Profissional.Infrastructure.Data.Models;

public class ProfissionalModel
{
    private ProfissionalModel()
    {
        Especialidades = new HashSet<Especialidade>();
        Midias = new HashSet<MidiaAbstract>();
        Tratamentos = new HashSet<Tratamento>();
        Convenios = new HashSet<Convenio>();
        Whatsapps = new HashSet<Whatsapp>();
    }

    public ProfissionalModel(string nome, string urlAmigavel, string sobre, Endereco endereco,
        TipoProfissional tipoProfissional, int unidadeId, string imagemUrlPerfil, bool recomendado = false,
        bool status = true) : this()
    {
        Nome = nome;
        UrlAmigavel = urlAmigavel;
        Sobre = sobre;
        Recomendado = recomendado;
        Status = status;
        Endereco = endereco;
        TipoProfissional = tipoProfissional;
        UnidadeId = unidadeId;
        ImagemUrlPerfil = imagemUrlPerfil;
    }

    public int Id { get; set; }
    public string Nome { get; set; }
    public string UrlAmigavel { get; set; }
    public string Sobre { get; set; }
    public int UnidadeId { get; set; }
    public string ImagemUrlPerfil { get; set; }
    public string? Conselho { get; set; }
    public string? NumeroIdentificacao { get; set; }
    public long? Telefone { get; set; }
    public long? Celular { get; set; }
    public string? Email { get; set; }
    public string? Site { get; set; }
    public string? Facebook { get; set; }
    public string? Instagram { get; set; }
    public string? Youtube { get; set; }
    public string? Linkedin { get; set; }
    public bool Recomendado { get; set; }
    public bool Status { get; set; }

    public Endereco Endereco { get; set; }
    public TipoProfissional TipoProfissional { get; set; }

    public ICollection<Especialidade> Especialidades { get; set; }
    public ICollection<MidiaAbstract> Midias { get; set; }
    public ICollection<Tratamento> Tratamentos { get; set; }
    public ICollection<Convenio> Convenios { get; set; }
    public ICollection<Whatsapp> Whatsapps { get; set; }
}