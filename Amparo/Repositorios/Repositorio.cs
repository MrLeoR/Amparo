using Amparo.Aplicacao.Interfaces;
using SqlKata;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Amparo.Aplicacao.Repositorios
{
    public class Repositorio : IRepository
    {
        private readonly UnitOfWork unitOfWork;

        public Repositorio(UnitOfWork unitOfWork)
            => this.unitOfWork = unitOfWork;

        protected Query BuildQuery()
            => unitOfWork.QueryFactory.Query();

        public T Insert<T>(T entity) where T : IModel
        {
            var table = typeof(T).Name;

            var query = BuildQuery().From(table);

            entity.Id = query.InsertGetId<long>(entity);

            return entity;
        }

        public void Update<T>(T entity) where T : IModel
        {
            var table = typeof(T).Name;

            var query = BuildQuery().From(table);

            entity.Id = query.Update(entity);
        }

        public T Get<T>(long id)
        {
            var table = typeof(T).Name;

            var query = BuildQuery().From(table)
                .Where("Id", id);

            return query.FirstOrDefault<T>();
        }

        public IEnumerable<T> Get<T>(Action<Query> handleQuery = null)
        {
            var table = typeof(T).Name;

            var query = BuildQuery().From(table);

            if (handleQuery != null)
                handleQuery.Invoke(query);

            return query.Get<T>();
        }

        public void Delete<T>(long id)
        {
            var table = typeof(T).Name;

            var query = BuildQuery().From(table)
                .Where("Id", id);

            query.Delete();
        }
    }
}
