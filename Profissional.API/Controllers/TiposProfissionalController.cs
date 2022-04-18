using MediatR;
using Microsoft.AspNetCore.Mvc;
using Profissionais.App.Commands;
using Profissionais.App.DTO;
using Profissionais.App.Queries;
using Profissional.API.DTO;

namespace Profissional.API.Controllers;

[ApiController]
[Route("tipos-profissional")]
public class TiposProfissionalController : ApiController
{
    public TiposProfissionalController(IMediator mediator)
    {
        Mediator = mediator;
    }

    private IMediator Mediator { get; }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK,
        Type = typeof(SucessResponse<List<BuscarTiposProfissionalResponse>>))]
    public async Task<IActionResult> Buscar()
    {
        try
        {
            var response = await Mediator.Send(new BuscarTiposProfissionalQuery());

            return Ok(Success(response));
        }
        catch (Exception e)
        {
            return BadRequest(Error(e.Message));
        }
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK,
        Type = typeof(SucessResponse<SalvarTipoProfissionalResponse>))]
    public async Task<IActionResult> Salvar([FromBody] SalvarTipoProfissionalRequest request)
    {
        try
        {
            var response =
                await Mediator.Send(
                    new SalvarTipoProfissionalCommand(request.Id, request.Descricao, request.Especialidades));

            return Ok(Success(response));
        }
        catch (Exception e)
        {
            return BadRequest(Error(e.Message));
        }
    }
}