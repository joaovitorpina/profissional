namespace Profissional.Infrastructure.Data.Models;

public class Convenio
{
    private Convenio()
    {
    }

    public Convenio(Profissional profissional, string descricao) : this()
    {
        Profissional = profissional;
        Descricao = descricao;
    }

    public int ProfissionalId { get; set; }
    public Profissional Profissional { get; set; }
    public string Descricao { get; set; }
}