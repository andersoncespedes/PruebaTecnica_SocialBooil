using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entity;
    public class Persona : BaseEntity
    {
        public int ? IdUsuario { get; set; }
        public Usuario Usuario  { get; set; }
        public int ? IdEmpledado { get; set;}
        public Empleado Empleado { get; set; }
        public string Nombre { get; set; }
        public string Correo {get; set;}
    }