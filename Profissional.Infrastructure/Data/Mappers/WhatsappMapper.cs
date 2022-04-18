using Profissional.Infrastructure.Data.Models;
using Whatsapp = Profissional.Domain.Aggregates.Profissional.Whatsapp;

namespace Profissional.Infrastructure.Data.Mappers;

public static class WhatsappMapper
{
    public static Whatsapp ToDomain(Models.Whatsapp model)
    {
        return new Whatsapp(model.Numero, model.Principal);
    }

    public static Models.Whatsapp ToModel(Whatsapp domain, ProfissionalModel profissionalModel)
    {
        return new Models.Whatsapp(profissionalModel, domain.Numero, domain.Principal);
    }
}