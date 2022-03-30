namespace Profissional.Infrastructure.Data.Models;

public class Whatsapp
{
    private Whatsapp()
    {
    }

    public Whatsapp(Profissional profissional, long numero, bool principal = false)
    {
        Profissional = profissional;
        Numero = numero;
        Principal = principal;
    }

    public int ProfissionalId { get; set; }
    public Profissional Profissional { get; set; }
    public long Numero { get; set; }
    public bool Principal { get; set; }
}