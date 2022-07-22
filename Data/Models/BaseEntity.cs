using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrianTech008Api.Data.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }

        public DateTime PostedOn { get; set; } 

        [ForeignKey("User")]
        public string PostedBy { get; set; }
        public DateTime LastUpdatedOn { get; set; } = DateTime.Now;

        [ForeignKey("User")]
        public string LastUpdatedBy { get; set; }
    }
}
