using System;
using System.Collections.Generic;

namespace Examen_V2.Data
{
    public interface IDataRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetById(Guid id);
        void Add(T entity);
        void Update(T entity);
        void Delete(Guid id);
    }

    public class DataRepository<T> : IDataRepository<T> where T : class
    {
        private List<T> _data = new List<T>();

        public IEnumerable<T> GetAll()
        {
            return _data;
        }

        public T GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Add(T entity)
        {
            _data.Add(entity);
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }

    public class AutorService
    {
        private readonly IDataRepository<Autor> _autorRepository;

        public AutorService(IDataRepository<Autor> autorRepository)
        {
            _autorRepository = autorRepository;
        }

        public IEnumerable<Autor> GetAllAuthors()
        {
            return _autorRepository.GetAll();
        }

        public Autor GetAuthorById(Guid id)
        {
            return _autorRepository.GetById(id);
        }

        public void CreateAuthor(Autor autor)
        {
            _autorRepository.Add(autor);
        }

        public void UpdateAuthor(Autor autor)
        {
            _autorRepository.Update(autor);
        }

        public void DeleteAuthor(Guid id)
        {
            _autorRepository.Delete(id);
        }
    }

    public class Autor
    {
        public Guid Id { get; set; }
        public string? Nume { get; set; }
    }
}
