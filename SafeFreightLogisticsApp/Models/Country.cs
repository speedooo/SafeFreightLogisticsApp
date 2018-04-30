using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SafeFreightLogisticsApp.Models
{
    public class Country
    {
        [Key]
        public virtual int CountryId { get; set; }

        [DisplayName("Country Name")]
        [Required(ErrorMessage = "Country Name is required")]
        [MaxLength(150, ErrorMessage = "Country Name must be 150 characters or less.")]
        public virtual string Name { get; set; }
    }
}