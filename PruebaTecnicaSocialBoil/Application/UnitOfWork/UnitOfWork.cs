using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Repository;
using Domain.Interface;
using Persistence.Data;

namespace Application.UnitOfWork;
public class UnitOfWork : IUnitOfWork, IDisposable
{
    private ICargo _cargo;
    private IContrato _contrato;
    private IDepartamento _departamento;
    private IEmpleado _empleado;
    private IPersona _persona;
    private IUsuario _usuario;
    private readonly APIContext _context;
    public UnitOfWork(APIContext context){
        _context = context;
    }
    public ICargo Cargos
    {
        get
        {
            _cargo ??= new CargoRepository(_context);
            return _cargo;
        }
    }

    public IContrato Contratos
    {
        get
        {
            _contrato ??= new ContratoRepository(_context);
            return _contrato;
        }
    }

    public IDepartamento Departamentos
    {
        get
        {
            _departamento ??= new DepartamentoRepository(_context);
            return _departamento;
        }
    }
    public IEmpleado Empleados 
    {
        get
        {
            _empleado ??= new EmpleadoRepository(_context);
            return _empleado;
        }
    }

    public IPersona Personas
    {
        get
        {
            _persona ??= new PersonaRepository(_context);
            return _persona;
        }
    }

    public IUsuario Usuarios 
    {
        get
        {
            _usuario ??= new UsuarioRepository(_context);
            return _usuario;
        }
    }
    
    public void Dispose()
    {
        _context.Dispose();
    }

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync(); 
    }
}