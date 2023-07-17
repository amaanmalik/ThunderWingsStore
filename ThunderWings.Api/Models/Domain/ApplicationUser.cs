using System.ComponentModel.DataAnnotations;

namespace ThunderWings.Api.Models.Domain
{
    public class ApplicationUser
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string? StreetAddress { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PostalCode { get; set; }
    }
}
