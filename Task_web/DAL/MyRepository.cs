using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_web.Models;

namespace Task_web.DAL
{

    public interface IMyRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetById(Guid id);
        void AddEntity(T entity);
        void DeleteEntity(T entity);
        void SaveEntity();
    }

    public class MyRepository : IMyRepository<TestModel>
    {
        readonly MyContext _myContext;

        public MyRepository(MyContext context)
        {
            _myContext = context;
        }

        public IEnumerable<TestModel> GetAll()
        {
            return _myContext.Tests.ToList();
        }
               
        public TestModel GetById(Guid id)
        {
            return _myContext.Tests.Find(id);
        }
        public void AddEntity(TestModel entity)
        {
            _myContext.Tests.Add(entity);
        }
        public void DeleteEntity(TestModel entity)
        {
            _myContext.Tests.Remove(entity);
        }
        public void SaveEntity()
        {
            _myContext.SaveChanges();
        }


    }
}
