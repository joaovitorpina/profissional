namespace Profissionais.App.DTO;

public record SalvarTipoProfissionalEspecialidadeResponse(int Id, string Descricao);

public record SalvarTipoProfissionalResponse(int Id, string Descricao,
    List<SalvarTipoProfissionalEspecialidadeResponse> Especialidades);