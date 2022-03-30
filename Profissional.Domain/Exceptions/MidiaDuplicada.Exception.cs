namespace Profissional.Domain.Exceptions;

public class MidiaDuplicadaException : Exception
{
    public MidiaDuplicadaException() : base("Já existe uma midia igual para esse profissional")
    {
    }
}