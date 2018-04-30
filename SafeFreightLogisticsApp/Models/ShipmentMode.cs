using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SafeFreightLogisticsApp.Models
{
    public class ShipmentMode
    {
        [Key]
        public virtual int ShipmentId { get; set; }

        [DisplayName("Shipment Mode")]
        [Required(ErrorMessage = "Shipment Mode Description is required")]
        [MaxLength(150, ErrorMessage = "Shipment Mode Description must be 150 characters or less.")]
        public virtual string Description { get; set; }
    }
}