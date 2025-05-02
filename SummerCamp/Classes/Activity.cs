using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SummerCamp
{
    [Table("activities")]
    public class Activity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("name")]
        public string Name { get; set; }

        [MaxLength(100)]
        [Column("location")]
        public string Location { get; set; }

        [Column("duration")]
        public int Duration { get; set; }

        public ActivityInstructor Instructor { get; set; }
    }

    [Owned]
    public class ActivityInstructor
    {
        [MaxLength(100)]
        [Column("instructor_name")]
        public string Name { get; set; }

        [MaxLength(20)]
        [Column("instructor_phone")]
        public string Phone { get; set; }
    }
}