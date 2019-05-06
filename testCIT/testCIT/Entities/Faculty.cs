using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace testCIT.Entities
{
    [Serializable]
    [JsonObject]
    [Table("dbo.Faculties")]
    public class Faculty : EntityWithId
    {
        public string Name { get; set; }

        [JsonIgnore]
        public ICollection<Group> Groups { get; set; }
    }
}