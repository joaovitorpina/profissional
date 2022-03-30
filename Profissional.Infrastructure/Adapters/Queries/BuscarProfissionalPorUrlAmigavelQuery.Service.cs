using Microsoft.EntityFrameworkCore;
using Profissionais.App.DTO;
using Profissionais.App.Ports;
using Profissional.Infrastructure.Data;

namespace Profissional.Infrastructure.Adapters.Queries;

public class BuscarProfissionalPorUrlAmigavelQueryService : IBuscarProfissionalPorUrlAmigavelQueryService
{
    public BuscarProfissionalPorUrlAmigavelQueryService(ProfissionalContext profissionalContext)
    {
        ProfissionalContext = profissionalContext;
    }

    private ProfissionalContext ProfissionalContext { get; }

    public async Task<BuscarProfissionalPorUrlAmigavelResponse?> BuscarProfissionalPorUrlAmigavel(string urlAmigavel)
    {
        var result = await ProfissionalContext.Profissionais
            .Where(profissional => profissional.UrlAmigavel == urlAmigavel).Select(profissional =>
                new BuscarProfissionalPorUrlAmigavelResponse(profissional.Id, profissional.Nome, "",
                    new EnderecoResponse(profissional.Endereco.Estado, profissional.Endereco.Cidade,
                        profissional.Endereco.Logradouro, profissional.Endereco.Bairro, profissional.Endereco.Cep),
                    profissional.TipoProfissional.Descricao,
                    profissional.Especialidades.Select(e => e.Descricao).ToArray(), profissional.Conselho,
                    profissional.NumeroIdentificacao, profissional.Celular, profissional.Telefone,
                    profissional.Facebook, profissional.Instagram, profissional.Email, profissional.Site,
                    profissional.Sobre)).SingleOrDefaultAsync();

        return result;
    }
}