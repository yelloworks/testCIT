using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using testCIT.Entities;
using testCIT.Interfaces;

namespace testCIT.Context
{
    public class GroupRepository : IRepository<Group>, IDisposable
    {
        private static DbSet<Group> _items = null;

        static GroupRepository()
        {
            _items = ApiDbContext.Instance.Groups;
        }

        public void Dispose()
        {

        }

        public IEnumerable<Group> ReadList()
        {
            return _items;
        }

        public void Create(Group item)
        {
            _items.Add(item);
        }

        public Group Read(int id)
        {
            return _items.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Group item)
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