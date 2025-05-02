using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SummerCamp
{
    [Table("campers")]
    public class Camper
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("full_name")]
        public string FullName { get; set; }

        [Column("age")]
        public int Age { get; set; }

        [MaxLength(50)]
        [Column("cabin")]
        public string Cabin { get; set; }

        public CamperContacts Contacts { get; set; }
        public List<Schedule> Schedules { get; set; } = new();
    }

    [Owned]
    public class CamperContacts
    {
        [MaxLength(20)]
        [Column("phone")]
        public string Phone { get; set; }

        [MaxLength(100)]
        [Column("email")]
        public string Email { get; set; }
    }
}
