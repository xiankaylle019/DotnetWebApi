using System;
using System.ComponentModel.DataAnnotations;

namespace DotNetWebAPI.Models
{
    public abstract class BaseEntity
    {
        private DateTime currentDate;
        public BaseEntity() => currentDate = DateTime.Now;
        
        [Key]
        public int Id { get; set; }    

        // //c# 6
        // public DateTime CreatedAt { get; set; } = DateTime.Now;

        //c#7 expression bodied properties        
        public DateTime CreatedAt { get => currentDate; set => currentDate = value ;}

        public Nullable<DateTime> UpdatedAt { get; set; }

    }
}