using Profissional.Infrastructure.Data.Models;

namespace Profissional.Infrastructure.Data.Mappers;

public static class TratamentoMapper
{
    public static string ToDomain(Tratamento model)
    {
        return model.Descricao;
    }

    public static Tratamento ToModel(string descricao, ProfissionalModel profissionalModel)
    {
        return new Tratamento(profissionalModel, descricao);
    }
}