namespace Profissional.Infrastructure.Data.Models;

public class Convenio
{
    private Convenio()
    {
    }

    public Convenio(ProfissionalModel profissionalModel, string descricao) : this()
    {
        ProfissionalModel = profissionalModel;
        Descricao = descricao;
    }

    public int ProfissionalId { get; set; }
    public ProfissionalModel ProfissionalModel { get; set; }
    public string Descricao { get; set; }
}