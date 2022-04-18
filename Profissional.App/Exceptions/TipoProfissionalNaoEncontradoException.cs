namespace Profissionais.App.Exceptions;

public class TipoProfissionalNaoEncontradoException : Exception
{
    public TipoProfissionalNaoEncontradoException() : base("Tipo do profissional não foi encontrado")
    {
    }
}