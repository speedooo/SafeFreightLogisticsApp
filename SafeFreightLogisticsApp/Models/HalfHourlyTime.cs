using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SafeFreightLogisticsApp.Models
{
    public class HalfHourlyTime
    {
        [Key]
        public virtual int HalfHourlyTimeId { get; set; }

        [DisplayName("Pickup Time")]
        [Required(ErrorMessage = "Pickup Time is required")]
        [MaxLength(20, ErrorMessage = "Pickup Time must be 20 characters or less.")]
        public virtual string TimePeriod { get; set; }
    }
}