using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using testCIT.Entities;
using testCIT.Interfaces;

namespace testCIT.Context
{
    public class FacultyRepository: IRepository<Faculty>, IDisposable
    {
        private static DbSet<Faculty> _items = null;

        static FacultyRepository()
        {
            _items = ApiDbContext.Instance.Faculties;
        }

        public void Dispose()
        {

        }

        public IEnumerable<Faculty> ReadList()
        {
            return _items;
        }

        public void Create(Faculty item)
        {
            _items.Add(item);
        }

        public Faculty Read(int id)
        {
            return _items.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Faculty item)
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