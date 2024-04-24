using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dto.Output;
public class EmpleadoDto
{
    public string Nombre { get; set; }
    public string Correo { get; set; }
    public string Cargo { get; set; }
    public double Salario { get; set; }
}