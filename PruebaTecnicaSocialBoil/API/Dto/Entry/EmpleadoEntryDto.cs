using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dto.Entry;
public class EmpleadoEntryDto
{
    public string Nombre { get; set; }
    public string Correo { get; set; }
    public double Salario { get; set; }
    public string CargoNombre { get; set; }
}