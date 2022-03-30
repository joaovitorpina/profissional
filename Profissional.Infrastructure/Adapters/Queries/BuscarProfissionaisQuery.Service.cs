using Microsoft.EntityFrameworkCore;
using Profissionais.App.DTO;
using Profissionais.App.Ports;
using Profissionais.App.Queries;
using Profissional.Infrastructure.Data;

namespace Profissional.Infrastructure.Adapters.Queries;

public class BuscarProfissionaisQueryService : IBuscarProfissionaisQueryService
{
    public BuscarProfissionaisQueryService(ProfissionalContext profissionalContext)
    {
        ProfissionalContext = profissionalContext;
    }

    private ProfissionalContext ProfissionalContext { get; }


    public async Task<BuscarProfissionaisResponse> BuscarProfissionais(BuscarProfissionaisQuery query)
    {
        var totalProfissionais = await ContarProfissionaisAtivos();

        var dbQuery = ProfissionalContext.Profissionais.Where(profissional => profissional.Status).Take(query.Limite)
            .Skip((query.Pagina - 1) * query.Limite);

        if (query.Nome is not null) dbQuery = dbQuery.Where(profissional => profissional.Nome.Contains(query.Nome));

        if (query.UnidadeId is not null)
            dbQuery = dbQuery.Where(profissional => profissional.UnidadeId == query.UnidadeId);

        if (query.EspecialidadeId is not null)
            dbQuery = dbQuery.Where(profissional =>
                profissional.Especialidades.Any(especialidade => especialidade.Id == query.EspecialidadeId));

        if (query.TipoProfissionalId is not null)
            dbQuery = dbQuery.Where(profissional => profissional.TipoProfissional.Id == query.TipoProfissionalId);

        var profissionais = await dbQuery.Select(profissional => new ProfissionalResponse(profissional.Nome,
            profissional.UrlAmigavel, profissional.TipoProfissional.Descricao,
            profissional.Especialidades.Select(e => e.Descricao).ToArray(), profissional.Recomendado, "",
            profissional.UnidadeId,
            profissional.Whatsapps.FirstOrDefault(w => w.Principal).Numero, profissional.Email, profissional.Site,
            profissional.Facebook, profissional.Instagram, profissional.Youtube, profissional.Linkedin)).ToArrayAsync();

        return new BuscarProfissionaisResponse(profissionais, query.Pagina, profissionais.Length, totalProfissionais);
    }

    public async Task<int> ContarProfissionaisAtivos()
    {
        return await ProfissionalContext.Profissionais.CountAsync(profissional => profissional.Status);
    }
}