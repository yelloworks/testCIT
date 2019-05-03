using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using testCIT.Entities;

namespace testCIT.Context
{
    public class ApiDbContext : DbContext
    {
        private static ApiDbContext _context = null;

        static ApiDbContext()
        {
            _context = new ApiDbContext();
        }
        private ApiDbContext() :base ("DefaultConnection") { }

        public static ApiDbContext Instance => _context;

        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasRequired(p => p.CurrentGroup).WithMany(p => p.Students)
                .HasForeignKey(p => p.GroupId);
            modelBuilder.Entity<Group>().HasRequired(p => p.CurrentFaculty).WithMany(p => p.Groups)
                .HasForeignKey(p => p.FacultyId);
            

            base.OnModelCreating(modelBuilder);
        }
    }
}