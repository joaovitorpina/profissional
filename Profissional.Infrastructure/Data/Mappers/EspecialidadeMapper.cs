using Profissional.Domain.Aggregates.TipoProfissional;
using TipoProfissional = Profissional.Infrastructure.Data.Models.TipoProfissional;

namespace Profissional.Infrastructure.Data.Mappers;

public static class EspecialidadeMapper
{
    public static Especialidade ToDomain(Models.Especialidade model)
    {
        return new Especialidade(model.Descricao, model.Id);
    }

    public static Models.Especialidade ToModel(Especialidade domain, TipoProfissional tipoProfissional)
    {
        return new Models.Especialidade(domain.Descricao, tipoProfissional) { Id = domain.Id };
    }
}