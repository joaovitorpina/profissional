namespace Profissionais.App.Exceptions;

public class EspecialidadeNaoEncontradaException : Exception
{
    public EspecialidadeNaoEncontradaException(int id) : base($"A especialidade de ID {id} não foi encontrada")
    {
    }
}