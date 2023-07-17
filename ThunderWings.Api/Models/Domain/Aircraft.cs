using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ThunderWings.Api.Models.Domain
{
    public class Aircraft
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string Country { get; set; }
        public string Role { get; set; }
        public int TopSpeed { get; set; }
        public decimal Price { get; set; }
    }
}
