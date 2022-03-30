namespace Profissional.Domain.Exceptions;

public class ProfissionalNaoEncontradoException : Exception
{
    public ProfissionalNaoEncontradoException() : base("Profissional não foi encontrado")
    {
    }
}