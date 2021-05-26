using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    [Table("Participant")]
    public class Participant
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CourseId { get; set; }
    
    }
}