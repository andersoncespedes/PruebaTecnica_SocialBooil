using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dto.Entry;
public class UsuarioEntryDto
{
    public string Nombre { get; set; }
    public string Correo { get; set; }
    public string Password { get; set; }
}