namespace Profissional.API.DTO;

public record ErrorResponse<T>(T Error) : Response(false);