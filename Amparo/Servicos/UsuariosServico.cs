using Amparo.Aplicacao.DbModels;
using Amparo.Aplicacao.DTO;
using Amparo.Aplicacao.Exceptions;
using Amparo.Aplicacao.Interfaces;
using Amparo.Aplicacao.Models;
using Amparo.Aplicacao.Repositorios;

namespace Amparo.Aplicacao.Servicos
{
    public class UsuariosServico : IService
    {
        private UsuariosRepositorio repositorio;

        public UsuariosServico(UsuariosRepositorio repositorio)
            => this.repositorio = repositorio;

        public Usuarios Autenticar(Credencial credencial)
        {
            using var critpo = new Criptografia();
            credencial.Senha = critpo.GetHash(credencial.Senha);

            var usuario = repositorio.FindByUsuarioAndSenha(credencial.Username, credencial.Senha);

            if (usuario == null)
                throw new LoginException("Usuario Não Encontrado");

            return usuario;
        }
    }
}
