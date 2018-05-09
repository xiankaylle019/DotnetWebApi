using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetWebAPI.Models
{
    [Table("Person")]
    public class Person : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        
        public virtual ICollection<Contacts> Contacts { get; set; }
    }
}