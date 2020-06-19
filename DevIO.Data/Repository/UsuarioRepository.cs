using DevIO.Business.Interfaces;
using DevIO.Business.Model;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace DevIO.Data.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly MeuDbContext _context;

        public UsuarioRepository(MeuDbContext context)
        {
            _context = context;
        }


        public async Task Adicionar(Usuario entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
        }


        public async Task<Usuario> ObterUsuarioPorID(string Id)
        {

            return null;
       //     return await _context.Usuario.AsNoTracking().FirstOrDefaultAsync(f => f.Id == Id);

        }



    }
}
