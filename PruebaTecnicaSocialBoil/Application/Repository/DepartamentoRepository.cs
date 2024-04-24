using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entity;
using Domain.Interface;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository;
public class DepartamentoRepository : GenericRepository<Departamento>, IDepartamento
{
    public DepartamentoRepository(APIContext context) : base(context)
    {
    }
     public override async Task<Departamento> GetAsync(int id)
    {
        return await _context.Departamentos.Include(e => e.Localidad).Include(e => e.Division).Where(e => e.Id == id).FirstOrDefaultAsync();
    }
}