namespace Profissional.Infrastructure.Data.Models;

public class Whatsapp
{
    private Whatsapp()
    {
    }

    public Whatsapp(ProfissionalModel profissionalModel, long numero, bool principal = false)
    {
        ProfissionalModel = profissionalModel;
        Numero = numero;
        Principal = principal;
    }

    public int ProfissionalId { get; set; }
    public ProfissionalModel ProfissionalModel { get; set; }
    public long Numero { get; set; }
    public bool Principal { get; set; }
}