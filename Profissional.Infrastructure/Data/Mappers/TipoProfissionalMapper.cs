using Profissional.Infrastructure.Data.Models;

namespace Profissional.Infrastructure.Data.Mappers;

public static class TipoProfissionalMapper
{
    // public static TipoProfissional ToDomain(Models.TipoProfissional model)
    // {
    //     return new TipoProfissional(model.Descricao,
    //         model.Especialidades.Select(EspecialidadeMapper.ToDomain).ToHashSet(), model.Id);
    // }

    public static TipoProfissional ToModel(Domain.Aggregates.TipoProfissional.TipoProfissional domain)
    {
        var model = new TipoProfissional(domain.Descricao)
        {
            Id = domain.Id
        };

        model.Especialidades = domain.Especialidades
            .Select(especialidade => EspecialidadeMapper.ToModel(especialidade, model)).ToList();

        return model;
    }
}