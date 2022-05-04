using MediatR;
using Profissionais.App.Commands;
using Profissionais.App.DTO;
using Profissionais.App.Exceptions;
using Profissionais.App.Ports;
using Profissional.Domain.Aggregates.Profissional;

namespace Profissionais.App.CommandHandlers;

public class CriarProfissionalCommandHandler : IRequestHandler<CriarProfissionalCommand, CriarProfissionalResponse>
{
    public CriarProfissionalCommandHandler(IProfissionalRepository profissionalRepository)
    {
        ProfissionalRepository = profissionalRepository;
    }

    private IProfissionalRepository ProfissionalRepository { get; }

    public async Task<CriarProfissionalResponse> Handle(CriarProfissionalCommand request,
        CancellationToken cancellationToken)
    {
        var tipoProfissional = await ProfissionalRepository.BuscarTipoProfissionalPorId(request.TipoProfissionalId);

        if (tipoProfissional is null) throw new TipoProfissionalNaoEncontradoException();

        var profissional = new Profissional.Domain.Aggregates.Profissional.Profissional(request.Nome,
            request.UrlAmigavel, request.Sobre,
            request.UnidadeId, request.ImagemUrlPerfil, request.Conselho, request.NumeroIdentificacao, request.Telefone,
            request.Celular, request.Email, request.Site, request.Facebook, request.Instagram, request.Youtube,
            request.Linkedin, request.Recomendado, request.Status);

        profissional.MudarEndereco(new Endereco(request.Endereco.Logradouro, request.Endereco.Numero,
            request.Endereco.Bairro,
            request.Endereco.Cidade, request.Endereco.Estado, request.Endereco.Cep));

        profissional.MudarTipoProfissional(tipoProfissional);

        foreach (var requestEspecialidade in request.Especialidades)
        {
            var especialidade = await ProfissionalRepository.BuscarEspecialidadePorId(requestEspecialidade);

            if (especialidade is null) throw new EspecialidadeNaoEncontradaException(requestEspecialidade);

            profissional.AdicionarEspecialidade(especialidade);
        }

        var profissionalCriado = await ProfissionalRepository.Criar(profissional);

        return new CriarProfissionalResponse
        {
            Id = profissionalCriado.Id,
            Nome = profissionalCriado.Nome,
            UrlAmigavel = profissionalCriado.UrlAmigavel,
            Sobre = profissionalCriado.Sobre,
            Endereco = new EnderecoResponse(profissionalCriado.Endereco.Estado, profissionalCriado.Endereco.Cidade,
                profissionalCriado.Endereco.Logradouro, profissionalCriado.Endereco.Bairro,
                profissionalCriado.Endereco.Cep),
            TipoProfissionalId = profissionalCriado.TipoProfissional.Id,
            UnidadeId = profissionalCriado.UnidadeId,
            ImagemUrlPerfil = profissionalCriado.ImagemUrlPerfil,
            Conselho = profissionalCriado.Conselho,
            NumeroIdentificacao = profissionalCriado.NumeroIdentificacao,
            Telefone = profissionalCriado.Telefone,
            Celular = profissionalCriado.Celular,
            Email = profissionalCriado.Email,
            Site = profissionalCriado.Site,
            Facebook = profissionalCriado.Facebook,
            Instagram = profissionalCriado.Instagram,
            Youtube = profissionalCriado.Youtube,
            Linkedin = profissionalCriado.Linkedin,
            Recomendado = profissionalCriado.Recomendado,
            Status = profissionalCriado.Status,
            Especialidades = profissionalCriado.Especialidades.Select(especialidade => especialidade.Id).ToList()
        };
    }
}