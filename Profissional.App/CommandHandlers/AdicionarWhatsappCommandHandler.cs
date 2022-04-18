using MediatR;
using Profissionais.App.Commands;
using Profissionais.App.DTO;
using Profissionais.App.Ports;
using Profissional.Domain.Aggregates.Profissional;
using Profissional.Domain.Exceptions;

namespace Profissionais.App.CommandHandlers;

public class AdicionarWhatsappCommandHandler : IRequestHandler<AdicionarWhatsappCommand, List<WhatsappResponse>>
{
    public AdicionarWhatsappCommandHandler(IProfissionalRepository profissionalRepository)
    {
        ProfissionalRepository = profissionalRepository;
    }

    private IProfissionalRepository ProfissionalRepository { get; }

    public async Task<List<WhatsappResponse>> Handle(AdicionarWhatsappCommand request,
        CancellationToken cancellationToken)
    {
        var profissional = await ProfissionalRepository.BuscarPorId(request.ProfissionalId);

        if (profissional is null) throw new ProfissionalNaoEncontradoException();

        profissional.AdicionarWhatsapp(new Whatsapp(request.Numero, request.Principal));
        profissional = await ProfissionalRepository.Alterar(profissional);

        return profissional.Whatsapps.Select(whatsapp => new WhatsappResponse(whatsapp.Numero, whatsapp.Principal))
            .ToList();
    }
}