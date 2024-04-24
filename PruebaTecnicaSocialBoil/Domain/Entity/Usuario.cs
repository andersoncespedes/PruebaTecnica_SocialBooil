
namespace Domain.Entity;
public class Usuario  : BaseEntity
{
    public Persona Persona { get; set; }
    public string Password { get; set; }
}