namespace Profissional.Domain.Exceptions;

public class EntidadePersistidaException : Exception
{
    public EntidadePersistidaException() : base("A entidade ja tem um id, ela ja foi persistida no banco.")
    {
    }
}