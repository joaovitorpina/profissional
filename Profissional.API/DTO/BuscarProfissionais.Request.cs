namespace Profissional.API.DTO;

public record BuscarProfissionaisRequest(int Pagina = 1, int Limite = 5, int? UnidadeId = null, string? Nome = null,
    int? TipoProfissionalId = null, int? EspecialidadeId = null);