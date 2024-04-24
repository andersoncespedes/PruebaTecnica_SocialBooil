using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interface;
    public interface IUnitOfWork
    {
        ICargo Cargos { get; }
        IContrato Contratos { get; }
        IDepartamento Departamentos { get; }
        IEmpleado Empleados { get; }
        IPersona Personas { get; }
        IUsuario Usuarios { get; }
        Task<int> SaveAsync();
    }