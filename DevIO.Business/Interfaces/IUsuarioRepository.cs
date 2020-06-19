using DevIO.Business.Model;
using System.Threading.Tasks;

namespace DevIO.Business.Interfaces
{
    public interface IUsuarioRepository 
    {
        Task<Usuario> ObterUsuarioPorID(string Id);
        Task Adicionar(Usuario entity);
        //Task<Usuario> ObterPorId(Guid id);
        //Task<List<Usuario>> ObterTodos();
        //Task Atualizar(Usuario entity);
        //Task Remover(Guid id);
        //Task<int> SaveChanges();

    }
}
