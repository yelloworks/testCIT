using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace testCIT.Entities
{
    [Serializable]
    [JsonObject]
    [Table("dbo.Students")]
    public class Student : EntityWithId
    {
        public string Name { get; set; }
        public int GroupId { get; set; }
        
        public Group CurrentGroup { get; set; }
      
    }
}