using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetWebAPI.Models
{
    [Table("Contacts")]
    public class Contacts : BaseEntity
    {
        public string ContactType { get; set; }
        public string Contact { get; set; }    

        [ForeignKey("PersonId")]    
        public int PersonId { get; set; }
        public Person Person { get; set; }

    }
}