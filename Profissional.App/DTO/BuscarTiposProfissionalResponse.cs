namespace Profissionais.App.DTO;

public record BuscarTiposProfissionalEspecialidadeResponse(int Id, string Descricao);

public record BuscarTiposProfissionalResponse(int Id, string Descricao,
    List<BuscarTiposProfissionalEspecialidadeResponse> Especialidades);