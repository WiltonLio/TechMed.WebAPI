namespace TechMed.WebAPI;

public class Medico
{
    public int Id { get; set; }
    public DateOnly Data { get; set; }

    public int CRM { get; set; }
    public string? Nome { get; set; }
}
