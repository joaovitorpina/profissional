using MediatR;
using Microsoft.AspNetCore.Mvc;
using Profissionais.App.Commands;
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

    [HttpPost("/admin")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SucessResponse<CriarProfissionalResponse>))]
    public async Task<IActionResult> Criar([FromBody] CriarProfissionalRequest request)
    {
        try
        {
            var response = await Mediator.Send(new CriarProfissionalCommand(request.Nome, request.UrlAmigavel,
                request.Sobre,
                new CriarProfissionalEndereco(request.Endereco.Logradouro, request.Endereco.Numero,
                    request.Endereco.Bairro,
                    request.Endereco.Cidade, request.Endereco.Estado, request.Endereco.Cep), request.TipoProfissionalId,
                request.UnidadeId, request.ImagemUrlPerfil, request.Conselho, request.NumeroIdentificacao,
                request.Telefone,
                request.Celular, request.Email, request.Site, request.Facebook, request.Instagram, request.Youtube,
                request.Linkedin, request.Recomendado, request.Status, request.Especialidades));

            return Ok(Success(response));
        }
        catch (Exception e)
        {
            return BadRequest(Error(e.Message));
        }
    }

    [HttpPut("/admin")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SucessResponse<AlterarProfissionalResponse>))]
    public async Task<IActionResult> Alterar([FromBody] AlterarProfissionalRequest request)
    {
        try
        {
            var response = await Mediator.Send(new AlterarProfissionalCommand(request.Id, request.Nome,
                request.UrlAmigavel,
                request.Sobre,
                new AlterarProfissionalEndereco(request.Endereco.Logradouro, request.Endereco.Numero,
                    request.Endereco.Bairro,
                    request.Endereco.Cidade, request.Endereco.Estado, request.Endereco.Cep), request.TipoProfissionalId,
                request.UnidadeId, request.ImagemUrlPerfil, request.Conselho, request.NumeroIdentificacao,
                request.Telefone,
                request.Celular, request.Email, request.Site, request.Facebook, request.Instagram, request.Youtube,
                request.Linkedin, request.Recomendado, request.Status, request.Especialidades));

            return Ok(Success(response));
        }
        catch (Exception e)
        {
            return BadRequest(Error(e.Message));
        }
    }

    [HttpDelete("/admin/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SucessResponse<dynamic>))]
    public async Task<IActionResult> Remover(int id)
    {
        try
        {
            await Mediator.Send(new RemoverProfissionalCommand(id));

            return Ok(Success(new { Message = "Profissional removido!" }));
        }
        catch (Exception e)
        {
            return BadRequest(Error(e.Message));
        }
    }

    [HttpPost("/admin/{id}/tratamentos")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SucessResponse<List<string>>))]
    public async Task<IActionResult> AdicionarTratamento(int id, [FromBody] string descricao)
    {
        try
        {
            var response = await Mediator.Send(new AdicionarTratamentoCommand(id, descricao));

            return Ok(Success(response));
        }
        catch (Exception e)
        {
            return BadRequest(Error(e.Message));
        }
    }

    [HttpDelete("/admin/{id}/tratamentos")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SucessResponse<List<string>>))]
    public async Task<IActionResult> RemoverTratamento(int id, [FromBody] string descricao)
    {
        try
        {
            var response = await Mediator.Send(new RemoverTratamentoCommand(id, descricao));

            return Ok(Success(response));
        }
        catch (Exception e)
        {
            return BadRequest(Error(e.Message));
        }
    }

    [HttpPost("/admin/{id}/convenios")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SucessResponse<List<string>>))]
    public async Task<IActionResult> AdicionarConvenio(int id, [FromBody] string descricao)
    {
        try
        {
            var response = await Mediator.Send(new AdicionarConvenioCommand(id, descricao));

            return Ok(Success(response));
        }
        catch (Exception e)
        {
            return BadRequest(Error(e.Message));
        }
    }

    [HttpDelete("/admin/{id}/convenios")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SucessResponse<List<string>>))]
    public async Task<IActionResult> RemoverConvenio(int id, [FromBody] string descricao)
    {
        try
        {
            var response = await Mediator.Send(new RemoverConvenioCommand(id, descricao));

            return Ok(Success(response));
        }
        catch (Exception e)
        {
            return BadRequest(Error(e.Message));
        }
    }

    [HttpPost("/admin/{id}/whatsapps")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SucessResponse<List<WhatsappResponse>>))]
    public async Task<IActionResult> AdicionarWhatsapp(int id, [FromBody] WhatsappRequest request)
    {
        try
        {
            var response = await Mediator.Send(new AdicionarWhatsappCommand(id, request.Numero, request.Principal));

            return Ok(Success(response));
        }
        catch (Exception e)
        {
            return BadRequest(Error(e.Message));
        }
    }

    [HttpDelete("/admin/{id}/whatsapps")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SucessResponse<List<WhatsappResponse>>))]
    public async Task<IActionResult> RemoverWhatsapp(int id, [FromBody] WhatsappRequest request)
    {
        try
        {
            var response = await Mediator.Send(new RemoverWhatsappCommand(id, request.Numero, request.Principal));

            return Ok(Success(response));
        }
        catch (Exception e)
        {
            return BadRequest(Error(e.Message));
        }
    }


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