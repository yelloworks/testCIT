using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using testCIT.Entities;

namespace testCIT.Context
{
    public class DbInitialiizer : DropCreateDatabaseAlways<ApiDbContext>
    {
        protected override void Seed(ApiDbContext context)
        {
            var faculty = new List<Faculty>
            {
                new Faculty {Name = "Faculty1"},
                new Faculty {Name = "Faculty2"}
            };

            context.Faculties.AddRange(faculty);
            context.SaveChanges();

            var groups = new List<Group>
            {
                new Group {Name = "Group1", FacultyId = 1},
                new Group {Name = "Group2", FacultyId = 1},
                new Group {Name = "Group3", FacultyId = 2},

            };

            context.Groups.AddRange(groups);
            context.SaveChanges();


            var students = new List<Student>
            {
                new Student {Name = "Stud1", GroupId = 1},
                new Student {Name = "Stud2", GroupId = 2},
                new Student {Name = "Stud3", GroupId = 3},

            };

            context.Students.AddRange(students);
            context.SaveChanges();


            base.Seed(context);
        }
    }
}