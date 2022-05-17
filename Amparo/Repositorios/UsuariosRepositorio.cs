using Amparo.Aplicacao.DbModels;
using Amparo.Aplicacao.Interfaces;
using System.Linq;

namespace Amparo.Aplicacao.Repositorios
{
    public class UsuariosRepositorio : IRepository
    {
        private Repositorio repositorio;

        public UsuariosRepositorio(Repositorio repositorio)
            => this.repositorio = repositorio;

        public Usuarios FindByUsuarioAndSenha(string username, string senha)
            => repositorio.Get<Usuarios>(query => query.Where(new { username, senha })).FirstOrDefault();
    }
}
