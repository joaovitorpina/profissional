using MediatR;
using Profissionais.App.Commands;
using Profissionais.App.DTO;
using Profissionais.App.Ports;
using Profissional.Domain.Aggregates.Profissional;
using Profissional.Domain.Exceptions;

namespace Profissionais.App.CommandHandlers;

public class RemoverWhatsappCommandHandler : IRequestHandler<RemoverWhatsappCommand, List<WhatsappResponse>>
{
    public RemoverWhatsappCommandHandler(IProfissionalRepository profissionalRepository)
    {
        ProfissionalRepository = profissionalRepository;
    }

    private IProfissionalRepository ProfissionalRepository { get; }

    public async Task<List<WhatsappResponse>> Handle(RemoverWhatsappCommand request,
        CancellationToken cancellationToken)
    {
        var profissional = await ProfissionalRepository.BuscarPorId(request.ProfissionalId);

        if (profissional is null) throw new ProfissionalNaoEncontradoException();

        profissional.RemoverWhatsapp(new Whatsapp(request.Numero, request.Principal));
        profissional = await ProfissionalRepository.Alterar(profissional);

        return profissional.Whatsapps.Select(whatsapp => new WhatsappResponse(whatsapp.Numero, whatsapp.Principal))
            .ToList();
    }
}