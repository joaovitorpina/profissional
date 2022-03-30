namespace Profissional.Infrastructure.Data.Models;

public class Especialidade
{
    private Especialidade()
    {
        Profissionais = new HashSet<Profissional>();
    }

    public Especialidade(string descricao, TipoProfissional tipoProfissional) : this()
    {
        Descricao = descricao;
        TipoProfissional = tipoProfissional;
    }

    public int Id { get; set; }
    public string Descricao { get; set; }
    public TipoProfissional TipoProfissional { get; set; }
    public ICollection<Profissional> Profissionais { get; set; }
}