namespace Profissional.Infrastructure.Data.Models;

public class Tratamento
{
    private Tratamento()
    {
    }

    public Tratamento(ProfissionalModel profissionalModel, string descricao)
    {
        ProfissionalModel = profissionalModel;
        Descricao = descricao;
    }


    public int ProfissionalId { get; set; }
    public ProfissionalModel ProfissionalModel { get; set; }
    public string Descricao { get; set; }
}