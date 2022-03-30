namespace Profissional.API.DTO;

public record SucessResponse<T>(T Data) : Response(true);