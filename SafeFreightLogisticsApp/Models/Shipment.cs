using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SafeFreightLogisticsApp.Models
{
    public class Shipment
    {
        [Key]
        public virtual int ShipmentId { get; set; }

        [DisplayName("Tracking Number")]
        [Required(ErrorMessage = "Tracking Number is required")]
        [MaxLength(20, ErrorMessage = "Tracking Number must be 20 characters or less.")]
        public virtual string TrackingNumber { get; set; }

        [DisplayName("Shipper's Name")]
        [MaxLength(200, ErrorMessage = "Shipper's Name must be 200 characters or less.")]
        public virtual string ShipperName { get; set; }

        [DisplayName("Shipper's Address")]
        [MaxLength(500, ErrorMessage = "Shipper's Address must be 500 characters or less.")]
        public virtual string ShipperAddress { get; set; }

        [DisplayName("Shipper's Phone")]
        [MaxLength(20, ErrorMessage = "Shipper's Phone must be 20 characters or less.")]
        public virtual string ShipperPhone { get; set; }

        [DisplayName("Shipper's Email")]
        [MaxLength(250, ErrorMessage = "Shipper's Email must be 250 characters or less.")]
        [EmailAddress(ErrorMessage = "Shipper's Email must be a valid email address")]
        public virtual string ShipperEmail { get; set; }

        [DisplayName("Receiver's Name")]
        [MaxLength(200, ErrorMessage = "Receiver's Name must be 200 characters or less.")]
        public virtual string ReceiverName { get; set; }

        [DisplayName("Receiver's Address")]
        [MaxLength(500, ErrorMessage = "Receiver's Address must be 500 characters or less.")]
        public virtual string ReceiverAddress { get; set; }

        [DisplayName("Receiver's Phone")]
        [MaxLength(20, ErrorMessage = "Receiver's Phone must be 20 characters or less.")]
        public virtual string ReceiverPhone { get; set; }

        [DisplayName("Receiver's Email")]
        [MaxLength(250, ErrorMessage = "Receiver's Email must be 250 characters or less.")]
        [EmailAddress(ErrorMessage = "Receiver's Email must be a valid email address")]
        public virtual string ReceiverEmail { get; set; }

        [MaxLength(500, ErrorMessage = "Status must be 500 characters or less.")]
        public virtual string Status { get; set; }

        [DisplayName("Package Origin")]
        [MaxLength(100, ErrorMessage = "Package Origin must be 100 characters or less.")]
        public virtual string PackageOrigin { get; set; }

        [DisplayName("Package Destination")]
        [MaxLength(100, ErrorMessage = "Package Destination must be 100 characters or less.")]
        public virtual string PackageDestination { get; set; }

        [DisplayName("Carrier Reference Number")]
        [MaxLength(100, ErrorMessage = "Carrier Reference Number must be 100 characters or less.")]
        public virtual string CarrierRefNumber { get; set; }

        [MaxLength(700, ErrorMessage = "Comments must be 700 characters or less.")]
        public virtual string Comments { get; set; }

        [MaxLength(300, ErrorMessage = "Product must be 300 characters or less.")]
        public virtual string Product { get; set; }

        //[RegularExpression("^[0-9]*$", ErrorMessage = "Quantity must be a number.")]
        public virtual int? Quantity { get; set; }

        [DisplayName("Pickup Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public virtual DateTime? PickupDate { get; set; }

        [DisplayName("Pickup Time")]
        [MaxLength(20, ErrorMessage = "Pickup Time must be 20 characters or less.")]
        public virtual string PickupTime { get; set; }

        [DisplayName("Expected Delivery Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public virtual DateTime? ExpectedDeliveryDate { get; set; }

        [MaxLength(20, ErrorMessage = "Weight must be 20 characters or less.")]
        public virtual string Weight { get; set; }

        [DisplayName("Payment Mode")]
        [MaxLength(100, ErrorMessage = "Payment Mode must be 100 characters or less.")]
        public virtual string PaymentMode { get; set; }

        [DisplayName("Shipment Mode")]
        [MaxLength(150, ErrorMessage = "Shipment Mode must be 150 characters or less.")]
        public virtual string ShipmentMode { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public virtual DateTime? CreatedDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public virtual DateTime? LastModifiedDate { get; set; }
    }
}