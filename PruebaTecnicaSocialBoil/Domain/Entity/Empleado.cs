
namespace Domain.Entity;
public class Empleado : BaseEntity
{
    public Persona Persona { get; set; }
    public double Salario {get; set;}
    public int IdCargoFK {get; set;}
    public Cargo Cargo {get; set;}
}