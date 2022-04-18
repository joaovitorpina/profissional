using Microsoft.EntityFrameworkCore;
using Profissionais.App.Ports;
using Profissional.Domain.Aggregates.TipoProfissional;
using Profissional.Infrastructure.Data;
using Profissional.Infrastructure.Data.Mappers;

namespace Profissional.Infrastructure.Adapters.Repositories;

public class ProfissionalRepository : IProfissionalRepository
{
    public ProfissionalRepository(ProfissionalContext profissionalContext)
    {
        ProfissionalContext = profissionalContext;
    }

    private ProfissionalContext ProfissionalContext { get; }

    public async Task<Domain.Aggregates.Profissional.Profissional> Criar(
        Domain.Aggregates.Profissional.Profissional profissional)
    {
        var model = ProfissionalMapper.ToModel(profissional);

        ProfissionalContext.Profissionais.Add(model);

        await ProfissionalContext.SaveChangesAsync();

        return ProfissionalMapper.ToDomain(model);
    }

    public async Task<Domain.Aggregates.Profissional.Profissional> Alterar(
        Domain.Aggregates.Profissional.Profissional profissional)
    {
        var model = ProfissionalMapper.ToModel(profissional);

        ProfissionalContext.Profissionais.Update(model);

        await ProfissionalContext.SaveChangesAsync();

        return ProfissionalMapper.ToDomain(model);
    }

    public async Task Remover(Domain.Aggregates.Profissional.Profissional profissional)
    {
        var model = ProfissionalMapper.ToModel(profissional);

        ProfissionalContext.Profissionais.Remove(model);
        await ProfissionalContext.SaveChangesAsync();
    }

    public async Task<Domain.Aggregates.Profissional.Profissional?> BuscarPorId(int id)
    {
        var profissional =
            await ProfissionalContext.Profissionais.FirstOrDefaultAsync(profissional => profissional.Id == id);

        return profissional is null ? null : ProfissionalMapper.ToDomain(profissional);
    }

    public async Task<TipoProfissional?> BuscarTipoProfissional(int id)
    {
        var tipoProfissional =
            await ProfissionalContext.TiposProfissional.FirstOrDefaultAsync(tipoProfissional =>
                tipoProfissional.Id == id);

        return tipoProfissional is null ? null : TipoProfissionalMapper.ToDomain(tipoProfissional);
    }

    public async Task<Especialidade?> BuscarEspecialidade(int id)
    {
        var especialidade =
            await ProfissionalContext.Especialidades.FirstOrDefaultAsync(especialidade => especialidade.Id == id);

        return especialidade is null ? null : EspecialidadeMapper.ToDomain(especialidade);
    }
}