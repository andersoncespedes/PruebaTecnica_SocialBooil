using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entity;
    public class Localidad
    {
        public string Nombre { get; set; }
        public ICollection<Departamento> Departamentos { get; set; }

    }