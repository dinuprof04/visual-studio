using System.ComponentModel.DataAnnotations;

namespace CarInsurance.Models
{
    public class Insuree
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required, EmailAddress]
        public string EmailAddress { get; set; }

        public int Age { get; set; }

        public int CarYear { get; set; }

        public string CarMake { get; set; }

        public string CarModel { get; set; }

        public int SpeedingTickets { get; set; }

        public bool DUI { get; set; }

        public bool FullCoverage { get; set; }

        // User should NOT type this - we calculate it
        public decimal Quote { get; set; }
    }
}
