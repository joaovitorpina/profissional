using Microsoft.EntityFrameworkCore;
using Profissionais.App.Ports;
using Profissional.Domain.Aggregates.TipoProfissional;
using Profissional.Infrastructure.Data;
using Profissional.Infrastructure.Data.Mappers;

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

        // return tipoProfissional is null ? null : TipoProfissionalMapper.ToDomain(tipoProfissional);
        return null;
    }

    public async Task<TipoProfissional> Salvar(TipoProfissional tipoProfissional)
    {
        ProfissionalContext.ChangeTracker.Clear();
        var model = TipoProfissionalMapper.ToModel(tipoProfissional);

        ProfissionalContext.Update(model);
        await ProfissionalContext.SaveChangesAsync();

        return TipoProfissionalMapper.ToDomain(model);
    }

    public async Task<Especialidade?> BuscarEspecialidadePorDescricao(string descricao, int tipoEspecialidadeId)
    {
        // var especialidade = await ProfissionalContext.Especialidades.FirstOrDefaultAsync(e =>
        // e.Descricao == descricao && e.TipoProfissional.Id == tipoEspecialidadeId);

        // return especialidade is null ? null : EspecialidadeMapper.ToDomain(especialidade);
        return null;
    }
}