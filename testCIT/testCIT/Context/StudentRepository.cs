using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using testCIT.Entities;
using testCIT.Interfaces;

namespace testCIT.Context
{
    public class StudentRepository : IRepository<Student>, IDisposable
    {
        private static DbSet<Student> _items = null;

        static StudentRepository()
        {
            _items = ApiDbContext.Instance.Students;
        }

        public void Dispose()
        {

        }

        public IEnumerable<Student> ReadList()
        {
         //   _items.Include(p=> p.CurrentGroup.)
            return _items.Include("CurrentGroup.CurrentFaculty");
        }

        public void Create(Student item)
        {
            _items.Add(item);
        }

        public Student Read(int id)
        {
            return _items.Include("CurrentGroup.CurrentFaculty").FirstOrDefault(x => x.Id == id);
        }

        public void Update(Student item)
        {
            var firstOrDefault = _items.FirstOrDefault(x => x.Id == item.Id);
            if (firstOrDefault != null)
            {
                _items.Attach(firstOrDefault);
                Save();
            }
        }

        public void Delete(int id)
        {
            var firstOrDefault = _items.FirstOrDefault(x => x.Id == id);
            if (firstOrDefault != null)
            {
                _items.Remove(firstOrDefault);
                Save();
            }
        }

        public void Save()
        {
            ApiDbContext.Instance.SaveChanges();
        }
    }
}