using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SummerCamp
{
    [Table("schedules")]
    public class Schedule
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [ForeignKey("Camper")]
        [Column("camper_id")]
        public int CamperId { get; set; }

        [ForeignKey("Activity")]
        [Column("activity_id")]
        public int ActivityId { get; set; }

        [Column("time")]
        public string Time { get; set; }

        public Camper Camper { get; set; }
        public Activity Activity { get; set; }
    }
}