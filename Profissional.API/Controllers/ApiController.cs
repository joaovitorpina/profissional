using Microsoft.AspNetCore.Mvc;
using Profissional.API.DTO;

namespace Profissional.API.Controllers;

public class ApiController : ControllerBase
{
    protected SucessResponse<T> Success<T>(T data)
    {
        return new SucessResponse<T>(data);
    }

    protected ErrorResponse<T> Error<T>(T error)
    {
        return new ErrorResponse<T>(error);
    }
}