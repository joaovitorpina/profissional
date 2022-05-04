using Profissional.Domain.Aggregates.Midias;
using Profissional.Domain.Aggregates.TipoProfissional;
using Profissional.Domain.Events;
using Profissional.Domain.Exceptions;
using Profissional.Domain.SeedWork;

namespace Profissional.Domain.Aggregates.Profissional;

public class Profissional : Entity, IAggregateRoot
{
    private readonly HashSet<Convenio> _convenios;
    private readonly HashSet<Especialidade> _especialidades;
    private readonly List<MidiaAbstract> _midias;
    private readonly HashSet<Tratamento> _tratamentos;
    private readonly HashSet<Whatsapp> _whatsapps;

    protected Profissional()
    {
        _convenios = new HashSet<Convenio>();
        _especialidades = new HashSet<Especialidade>();
        _midias = new List<MidiaAbstract>();
        _tratamentos = new HashSet<Tratamento>();
        _whatsapps = new HashSet<Whatsapp>();
    }

    public Profissional(string nome, string urlAmigavel, string sobre, int unidadeId, string imagemUrlPerfil,
        string? conselho = null,
        string? numeroIdentificacao = null, long? telefone = default, long? celular = default, string? email = null,
        string? site = null, string? facebook = null, string? instagram = null, string? youtube = null,
        string? linkedin = null, bool recomendado = false, bool status = true, int id = default) : this()
    {
        Nome = nome;
        UrlAmigavel = urlAmigavel;
        Sobre = sobre;
        UnidadeId = unidadeId;
        ImagemUrlPerfil = imagemUrlPerfil;
        Conselho = conselho;
        NumeroIdentificacao = numeroIdentificacao;
        Telefone = telefone;
        Celular = celular;
        Email = email;
        Site = site;
        Facebook = facebook;
        Instagram = instagram;
        Youtube = youtube;
        Linkedin = linkedin;
        Recomendado = recomendado;
        Status = status;
    }

    public string Nome { get; private set; }
    public string UrlAmigavel { get; private set; }
    public string Sobre { get; private set; }
    public Endereco Endereco { get; private set; }
    public TipoProfissional.TipoProfissional TipoProfissional { get; private set; }
    public int UnidadeId { get; private set; }
    public string ImagemUrlPerfil { get; private set; }
    public string? Conselho { get; private set; }
    public string? NumeroIdentificacao { get; private set; }
    public long? Telefone { get; private set; }
    public long? Celular { get; private set; }
    public string? Email { get; private set; }
    public string? Site { get; private set; }
    public string? Facebook { get; private set; }
    public string? Instagram { get; private set; }
    public string? Youtube { get; private set; }
    public string? Linkedin { get; private set; }
    public bool Recomendado { get; private set; }
    public bool Status { get; private set; }

    public IReadOnlySet<Tratamento> Tratamentos => _tratamentos;
    public IReadOnlySet<Convenio> Convenios => _convenios;
    public IReadOnlyList<MidiaAbstract> Midias => _midias;
    public IReadOnlySet<Especialidade> Especialidades => _especialidades;
    public IReadOnlySet<Whatsapp> Whatsapps => _whatsapps;

    public void MudarEndereco(Endereco endereco)
    {
        Endereco = endereco;
    }

    public void MudarTipoProfissional(TipoProfissional.TipoProfissional tipoProfissional)
    {
        TipoProfissional = tipoProfissional;
        _especialidades.Clear();
    }

    public void MudarNome(string nome)
    {
        Nome = nome;
    }

    public void MudarUrlAmigavel(string urlAmigavel)
    {
        UrlAmigavel = urlAmigavel;
    }

    public void MudarSobre(string sobre)
    {
        Sobre = sobre;
    }

    public void MudarUnidadeId(int unidadeId)
    {
        UnidadeId = unidadeId;
    }

    public void MudarImagemUrlPerfil(string imagemUrlPerfil)
    {
        ImagemUrlPerfil = imagemUrlPerfil;
    }

    public void MudarConselho(string? conselho)
    {
        Conselho = conselho;
    }

    public void MudarNumeroIdentificacao(string? numeroIdentificacao)
    {
        NumeroIdentificacao = numeroIdentificacao;
    }

    public void MudarTelefone(long? telefone)
    {
        Telefone = telefone;
    }

    public void MudarCelular(long? celular)
    {
        Celular = celular;
    }

    public void MudarEmail(string? email)
    {
        Email = email;
    }

    public void MudarSite(string? site)
    {
        Site = site;
    }

    public void MudarFacebook(string? facebook)
    {
        Facebook = facebook;
    }

    public void MudarInstagram(string? instagram)
    {
        Instagram = instagram;
    }

    public void MudarYoutube(string? youtube)
    {
        Youtube = youtube;
    }

    public void MudarLinkedin(string? linkedin)
    {
        Linkedin = linkedin;
    }

    public void MudarRecomendado(bool recomendado)
    {
        Recomendado = recomendado;
    }

    public void MudarStatus(bool status)
    {
        Status = status;
    }

    public void AdicionarTratamento(Tratamento tratamento)
    {
        _tratamentos.Add(tratamento);
    }

    public void RemoverTratamento(Tratamento tratamento)
    {
        _tratamentos.Remove(tratamento);
    }

    public void AdicionarConvenio(Convenio convenio)
    {
        _convenios.Add(convenio);
    }

    public void RemoverConvenio(Convenio convenio)
    {
        _convenios.Remove(convenio);
    }

    public void AdicionarMidia(MidiaAbstract midia)
    {
        if (_midias.Any(midia.Equals)) throw new MidiaDuplicadaException();

        _midias.Add(midia);
    }

    public void RemoverMidia(MidiaAbstract midia)
    {
        _midias.Remove(midia);
        AddDomainEvent(new MidiaRemovidaEvent(midia));
    }

    public void AdicionarEspecialidade(Especialidade especialidade)
    {
        if (!TipoProfissional.Especialidades.Contains(especialidade)) throw new EspecialidadeNaoPertenceException();

        _especialidades.Add(especialidade);
    }

    public void RemoverEspecialidade(Especialidade especialidade)
    {
        _especialidades.Remove(especialidade);
    }

    public void AdicionarWhatsapp(Whatsapp whatsapp)
    {
        if (whatsapp.Principal && _whatsapps.Any(wh => wh.Principal)) throw new WhatsappPrincipalDuplicadoException();

        _whatsapps.Add(whatsapp);
    }

    public void RemoverWhatsapp(Whatsapp whatsapp)
    {
        if (whatsapp.Principal && !_whatsapps.Any(wh => wh.Principal && wh.Numero != whatsapp.Numero))
            throw new WhatsappPrincipalNaoExisteException();

        _whatsapps.Remove(whatsapp);
    }

    public void AtualizarWhatsappPrincipal(Whatsapp whatsappPrincipal)
    {
        _whatsapps.RemoveWhere(wh => wh.Principal);
        _whatsapps.Add(whatsappPrincipal);
    }
}