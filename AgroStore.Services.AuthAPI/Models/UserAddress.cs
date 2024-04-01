

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgroStore.Services.AuthAPI.Models
{
    public class UserAddress
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }  // Foreign key to link to the user table
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        // Additional properties as needed

        // Navigation property to represent the relationship with the user
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
    }
}
