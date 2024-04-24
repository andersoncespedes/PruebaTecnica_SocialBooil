using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entity;
public class Departamento : BaseEntity
{
    public string NombreDepartamento { get; set; }
    public string NombreDivision {get; set;}
    public Division Division { get; set;}
    public string NombreLocalidad {get; set;}
    public Localidad Localidad  { get; set;}
}