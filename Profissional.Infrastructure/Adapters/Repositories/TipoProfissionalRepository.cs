using Microsoft.EntityFrameworkCore;
using Profissionais.App.Ports;
using Profissional.Domain.Aggregates.TipoProfissional;
using Profissional.Infrastructure.Data;

namespace Profissional.Infrastructure.Adapters.Repositories;

public class TipoProfissionalRepository : ITipoProfissionalRepository
{
    public TipoProfissionalRepository(ProfissionalContext profissionalContext)
    {
        ProfissionalContext = profissionalContext;
    }

    private ProfissionalContext ProfissionalContext { get; }

    public async Task<TipoProfissional?> BuscarPorId(int id)
    {
        var tipoProfissional = await ProfissionalContext.TiposProfissional.Include(tp => tp.Especialidades)
            .FirstOrDefaultAsync(tp => tp.Id == id);

        return tipoProfissional;
    }

    public async Task<TipoProfissional> Salvar(TipoProfissional tipoProfissional)
    {
        ProfissionalContext.Update(tipoProfissional);
        await ProfissionalContext.SaveChangesAsync();

        return tipoProfissional;
    }
}