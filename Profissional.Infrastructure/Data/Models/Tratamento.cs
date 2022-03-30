namespace Profissional.Infrastructure.Data.Models;

public class Tratamento
{
    private Tratamento()
    {
    }

    public Tratamento(Profissional profissional, string descricao)
    {
        Profissional = profissional;
        Descricao = descricao;
    }


    public int ProfissionalId { get; set; }
    public Profissional Profissional { get; set; }
    public string Descricao { get; set; }
}