using MediatR;
using Profissionais.App.DTO;

namespace Profissionais.App.Queries;

public class BuscarProfissionalPorIdQuery : IRequest<BuscarProfissionalPorIdResponse>
{
    public BuscarProfissionalPorIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; }
}