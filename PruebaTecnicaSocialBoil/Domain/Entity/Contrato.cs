

namespace Domain.Entity;
public class Contrato : BaseEntity
{
    public DateTime FechaAlta { get; set; }
    public DateTime FechaBaja { get; set; }
    public string Servicio {get; set;}
    public double Monto {get; set;}

}