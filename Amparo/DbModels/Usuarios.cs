using Amparo.Aplicacao.Interfaces;

namespace Amparo.Aplicacao.DbModels
{
    public class Usuarios : IModel
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Username { get; set; }
        public string Senha { get; set; }
    }
}
