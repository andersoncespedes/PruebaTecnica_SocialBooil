using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entity;
using Domain.Interface;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository;
public class UsuarioRepository : GenericRepository<Usuario>, IUsuario
{
    public UsuarioRepository(APIContext context) : base(context)
    {
    }
    public override async Task<Usuario> GetAsync(int id)
    {
        return await _context.Usuarios.Include(e => e.Persona).Where(e => e.Id == id).FirstOrDefaultAsync();
    }
}