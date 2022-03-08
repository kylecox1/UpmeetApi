using System.ComponentModel.DataAnnotations;

namespace UpmeetApi.Models
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Event Start Time")]
        public DateTime EventTime { get; set; }

        [StringLength(50)]
        [Display(Name = "Event Name")]
        public string EventName { get; set; }

        [StringLength(50)]
        [Display(Name = "Location")]
        public string Location { get; set; }

        [Display(Name = "Length in Minutes")]
        public int EventMinutes { get; set; }

        [StringLength(500)]
        [Display(Name = "Event Description")]
        public string Description { get; set; }
    }
}
