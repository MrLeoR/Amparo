using Amparo.Aplicacao.Models;
using SqlKata.Compilers;
using SqlKata.Execution;
using System;
using System.Data.SqlClient;

namespace Amparo.Aplicacao.Repositorios
{
    public class UnitOfWork : IDisposable
    {
        private readonly SqlConnection connection;

        public UnitOfWork(Ambiente ambiente)
        {
            connection = new SqlConnection(ambiente.ConnectionString);
            var compiler = new SqlServerCompiler();
            QueryFactory = new QueryFactory(connection, compiler);
        }

        public QueryFactory QueryFactory { get; }

        public void Dispose()
        {
            QueryFactory.Dispose();
        }
    }
}
