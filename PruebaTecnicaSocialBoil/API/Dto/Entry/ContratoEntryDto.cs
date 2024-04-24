

namespace API.Dto.Entry;
    public class ContratoEntryDto
    {
        public DateTime FechaAlta { get; set; }
        public DateTime FechaBaja { get; set; }
        public string Servicio { get; set; }
        public double Monto { get; set; }
    }