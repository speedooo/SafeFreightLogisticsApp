using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SafeFreightLogisticsApp.Models
{
    public class PaymentMode
    {
        [Key]
        public virtual int PaymentModeId { get; set; }

        [DisplayName("Payment Mode")]
        [Required(ErrorMessage = "Payment Mode Name is required")]
        [MaxLength(100, ErrorMessage = "Payment Mode must be 100 characters or less.")]
        public virtual string Name { get; set; }
    }
}