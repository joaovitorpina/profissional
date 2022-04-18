using Profissional.Infrastructure.Data.Models;
using Endereco = Profissional.Domain.Aggregates.Profissional.Endereco;
using TipoProfissional = Profissional.Domain.Aggregates.TipoProfissional.TipoProfissional;

namespace Profissional.Infrastructure.Data.Mappers;

public static class ProfissionalMapper
{
    public static Domain.Aggregates.Profissional.Profissional ToDomain(ProfissionalModel model)
    {
        return new Domain.Aggregates.Profissional.Profissional(model.Nome, model.UrlAmigavel, model.Sobre,
            new Endereco(model.Endereco.Logradouro, model.Endereco.Numero, model.Endereco.Bairro, model.Endereco.Cidade,
                model.Endereco.Estado, model.Endereco.Cep), new TipoProfissional(model.TipoProfissional.Descricao),
            model.UnidadeId,
            model.ImagemUrlPerfil, model.Conselho, model.NumeroIdentificacao, model.Telefone, model.Celular,
            model.Email, model.Site, model.Facebook, model.Instagram, model.Youtube, model.Linkedin, model.Recomendado,
            model.Status, model.Id, model.Tratamentos.Select(TratamentoMapper.ToDomain).ToHashSet(),
            model.Convenios.Select(ConvenioMapper.ToDomain).ToHashSet(),
            model.Midias.Select(MidiaMapper.ToDomain).ToList(),
            model.Especialidades.Select(EspecialidadeMapper.ToDomain).ToHashSet(),
            model.Whatsapps.Select(WhatsappMapper.ToDomain).ToHashSet());
    }


    public static ProfissionalModel ToModel(Domain.Aggregates.Profissional.Profissional domain)
    {
        var model = new ProfissionalModel(domain.Nome, domain.UrlAmigavel, domain.Sobre,
            new Models.Endereco(domain.Endereco.Cidade, domain.Endereco.Estado)
            {
                Bairro = domain.Endereco.Bairro, Cep = domain.Endereco.Cep, Logradouro = domain.Endereco.Logradouro,
                Numero = domain.Endereco.Numero, ProfissionalId = domain.Id
            }, new Models.TipoProfissional(domain.TipoProfissional.Descricao) { Id = domain.TipoProfissional.Id },
            domain.UnidadeId, domain.ImagemUrlPerfil, domain.Recomendado, domain.Status)
        {
            Celular = domain.Celular, Conselho = domain.Conselho, NumeroIdentificacao = domain.NumeroIdentificacao,
            Telefone = domain.Telefone, Email = domain.Email, Site = domain.Site, Facebook = domain.Facebook,
            Instagram = domain.Instagram, Youtube = domain.Youtube, Linkedin = domain.Linkedin
        };

        model.Tratamentos = domain.Tratamentos.Select(tratamento => TratamentoMapper.ToModel(tratamento, model))
            .ToList();
        model.Convenios = domain.Convenios.Select(convenio => ConvenioMapper.ToModel(convenio, model)).ToList();
        model.Midias = domain.Midias.Select(midia => MidiaMapper.ToModel(midia, model)).ToList();
        model.Especialidades = domain.Especialidades
            .Select(especialidade =>
                EspecialidadeMapper.ToModel(especialidade, TipoProfissionalMapper.ToModel(domain.TipoProfissional)))
            .ToList();
        model.Whatsapps = domain.Whatsapps.Select(whatsapp => WhatsappMapper.ToModel(whatsapp, model)).ToList();

        return model;
    }
}