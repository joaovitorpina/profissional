namespace Profissional.Domain.Exceptions;

public class WhatsappPrincipalDuplicadoException : Exception
{
    public WhatsappPrincipalDuplicadoException() : base("Não pode existir mais de um whatsapp principal")
    {
    }
}