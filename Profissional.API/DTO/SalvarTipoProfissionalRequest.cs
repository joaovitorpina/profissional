namespace Profissional.API.DTO;

public record SalvarTipoProfissionalRequest(int? Id, string Descricao, List<string> Especialidades);