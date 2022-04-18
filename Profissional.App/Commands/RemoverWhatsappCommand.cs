using MediatR;
using Profissionais.App.DTO;

namespace Profissionais.App.Commands;

public class RemoverWhatsappCommand : IRequest<List<WhatsappResponse>>
{
    public RemoverWhatsappCommand(int profissionalId, long numero, bool principal)
    {
        ProfissionalId = profissionalId;
        Numero = numero;
        Principal = principal;
    }

    public int ProfissionalId { get; }
    public long Numero { get; }
    public bool Principal { get; }
}