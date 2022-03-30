namespace Profissional.Infrastructure.Data.Models;

public class TipoProfissional
{
    private TipoProfissional()
    {
        Especialidades = new HashSet<Especialidade>();
    }

    public TipoProfissional(string descricao) : this()
    {
        Descricao = descricao;
    }

    public int Id { get; set; }
    public string Descricao { get; set; }
    public ICollection<Especialidade> Especialidades { get; set; }
}