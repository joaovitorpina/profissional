using Profissional.Infrastructure.Data.Models;

namespace Profissional.Infrastructure.Data.Mappers;

public static class ConvenioMapper
{
    public static string ToDomain(Convenio model)
    {
        return model.Descricao;
    }

    public static Convenio ToModel(string descricao, ProfissionalModel profissional)
    {
        return new Convenio(profissional, descricao);
    }
}