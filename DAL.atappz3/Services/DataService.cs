using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ServiceAbstract;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;

namespace DAL
{
    public class DataService<T> : IDataAccessService<T> where T : class, IModel, new()
    {
        private readonly ApplicationContext _context;
        public DataService()
        {
            var conncetionString = JsonDocument.Parse(new StreamReader("connection.json").ReadToEnd()).RootElement.GetProperty("ConnectionStrings").GetProperty("NpgSqlConnection").GetString();
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            optionsBuilder.UseNpgsql(conncetionString);
            _context = new ApplicationContext(optionsBuilder.Options);
        }
        public void Add(T entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            T source = _context.Set<T>().FirstOrDefault(x => x.Id == entity.Id);
            _context.Remove(source);
            _context.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().AsEnumerable();
        }

        public T GetById(int id)
        {
            T source = _context.Set<T>().FirstOrDefault(x => x.Id == id);
            return source;
        }

        public void Update(T entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }

        //public List<Source> GetByField(string search)
        //{
        //    search = search.ToLower();
        //    var Query = _context.Sources.Include(x => x.Storage).AsQueryable();
        //    if (!string.IsNullOrEmpty(search))
        //    {
        //        Query = Query.Where(x => x.FileName.ToLower().Contains(search) || x.Name.ToLower().Contains(search) || x.Storage.Name.ToLower().Contains(search));
        //    }
        //    List<Source> sources = Query.ToList();
        //    return sources;
        //}
    }
}