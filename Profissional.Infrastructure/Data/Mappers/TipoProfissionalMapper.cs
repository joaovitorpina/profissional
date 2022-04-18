using Profissional.Domain.Aggregates.TipoProfissional;

namespace Profissional.Infrastructure.Data.Mappers;

public static class TipoProfissionalMapper
{
    public static TipoProfissional ToDomain(Models.TipoProfissional model)
    {
        return new TipoProfissional(model.Descricao,
            model.Especialidades.Select(EspecialidadeMapper.ToDomain).ToHashSet(), model.Id);
    }

    public static Models.TipoProfissional ToModel(TipoProfissional domain)
    {
        var model = new Models.TipoProfissional(domain.Descricao)
        {
            Id = domain.Id
        };

        model.Especialidades = domain.Especialidades
            .Select(especialidade => EspecialidadeMapper.ToModel(especialidade, model)).ToList();

        return model;
    }
}