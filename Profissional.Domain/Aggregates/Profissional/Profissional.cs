using Profissional.Domain.Aggregates.Midias;
using Profissional.Domain.Aggregates.TipoProfissional;
using Profissional.Domain.Events;
using Profissional.Domain.Exceptions;
using Profissional.Domain.SeedWork;

namespace Profissional.Domain.Aggregates.Profissional;

public class Profissional : Entity, IAggregateRoot
{
    private readonly HashSet<string> _convenios;
    private readonly HashSet<Especialidade> _especialidades;
    private readonly List<MidiaAbstract> _midias;
    private readonly HashSet<string> _tratamentos;
    private readonly HashSet<Whatsapp> _whatsapps;

    public Profissional(string nome, string urlAmigavel, string sobre, Endereco endereco,
        TipoProfissional.TipoProfissional tipoProfissional, int unidadeId, string imagemUrlPerfil,
        string? conselho = null,
        string? numeroIdentificacao = null, long? telefone = default, long? celular = default, string? email = null,
        string? site = null, string? facebook = null, string? instagram = null, string? youtube = null,
        string? linkedin = null, bool recomendado = false, bool status = true, int? id = null,
        HashSet<string>? tratamentos = null,
        HashSet<string>? convenios = null, List<MidiaAbstract>? midias = null,
        HashSet<Especialidade>? especialidades = null, HashSet<Whatsapp>? whatsapps = null) : base(id)
    {
        Nome = nome;
        UrlAmigavel = urlAmigavel;
        Sobre = sobre;
        Endereco = endereco;
        TipoProfissional = tipoProfissional;
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
        _tratamentos = tratamentos ?? new HashSet<string>();
        _convenios = convenios ?? new HashSet<string>();
        _midias = midias ?? new List<MidiaAbstract>();
        _especialidades = especialidades ?? new HashSet<Especialidade>();
        _whatsapps = whatsapps ?? new HashSet<Whatsapp>();
    }

    public string Nome { get; }
    public string UrlAmigavel { get; }
    public string Sobre { get; }
    public Endereco Endereco { get; }
    public TipoProfissional.TipoProfissional TipoProfissional { get; }
    public int UnidadeId { get; }
    public string ImagemUrlPerfil { get; }
    public string? Conselho { get; }
    public string? NumeroIdentificacao { get; }
    public long? Telefone { get; }
    public long? Celular { get; }
    public string? Email { get; }
    public string? Site { get; }
    public string? Facebook { get; }
    public string? Instagram { get; }
    public string? Youtube { get; }
    public string? Linkedin { get; }
    public bool Recomendado { get; }
    public bool Status { get; }

    public IReadOnlySet<string> Tratamentos => _tratamentos;
    public IReadOnlySet<string> Convenios => _convenios;
    public IReadOnlyList<MidiaAbstract> Midias => _midias;
    public IReadOnlySet<Especialidade> Especialidades => _especialidades;
    public IReadOnlySet<Whatsapp> Whatsapps => _whatsapps;

    public void AdicionarTratamento(string tratamento)
    {
        _tratamentos.Add(tratamento);
    }

    public void RemoverTratamento(string tratamento)
    {
        _tratamentos.Remove(tratamento);
    }

    public void AdicionarConvenio(string convenio)
    {
        _convenios.Add(convenio);
    }

    public void RemoverConvenio(string convenio)
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