using MediatR;
using Microsoft.AspNetCore.Mvc;
using Profissionais.App.DTO;
using Profissionais.App.Queries;
using Profissional.API.DTO;

namespace Profissional.API.Controllers;

[ApiController]
public class ProfissionalController : ApiController
{
    public ProfissionalController(IMediator mediator)
    {
        Mediator = mediator;
    }

    private IMediator Mediator { get; }

    [HttpGet("/site")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SucessResponse<BuscarProfissionaisResponse>))]
    public async Task<IActionResult> BuscarProfissionais([FromQuery] BuscarProfissionaisRequest request)
    {
        var response = await Mediator.Send(new BuscarProfissionaisQuery
        {
            Pagina = request.Pagina,
            Limite = request.Limite,
            UnidadeId = request.UnidadeId,
            Nome = request.Nome,
            TipoProfissionalId = request.TipoProfissionalId,
            EspecialidadeId = request.EspecialidadeId
        });

        return Ok(Success(response));
    }

    [HttpGet("/site/{urlAmigavel}")]
    [ProducesResponseType(StatusCodes.Status200OK,
        Type = typeof(SucessResponse<BuscarProfissionalPorUrlAmigavelResponse>))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse<string>))]
    public async Task<IActionResult> BuscarProfissionalPorUrlAmigavel(
        string urlAmigavel)
    {
        try
        {
            var response = await Mediator.Send(new BuscarProfissionalPorUrlAmigavelQuery(urlAmigavel));
            return Ok(Success(response));
        }
        catch (Exception e)
        {
            return NotFound(Error(e.Message));
        }
    }

    [HttpGet("/admin/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SucessResponse<BuscarProfissionalPorIdResponse>))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse<string>))]
    public async Task<IActionResult> BuscarProfissionalPorId(int id)
    {
        try
        {
            var response = await Mediator.Send(new BuscarProfissionalPorIdQuery(id));
            return Ok(Success(response));
        }
        catch (Exception e)
        {
            return NotFound(Error(e.Message));
        }
    }
}