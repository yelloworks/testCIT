using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace testCIT.Entities
{
    [Serializable]
    [JsonObject]
    [Table("dbo.Groups")]
    public class Group: EntityWithId
    {
        public string Name { get; set; }

        public int FacultyId { get; set; }

        public Faculty CurrentFaculty { get; set; }
        [JsonIgnore]
        public ICollection<Student> Students { get; set; }
    }
}