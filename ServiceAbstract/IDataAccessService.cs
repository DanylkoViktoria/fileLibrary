using System;
using System.Collections.Generic;

namespace ServiceAbstract
{
    public interface IDataAccessService<T> where T : class, IModel, new()
    {
        public void Add(T entity);
        public void Delete(T entity);
        public void Update(T entity);
        public T GetById(int id);
        public IEnumerable<T> GetAll();

    }
}
