using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ThunderWings.Api.Models.Domain
{
    public class ShoppingCart
    {
        public int Id { get; set; }       

        public int AircraftId { get; set; }
        [ForeignKey("AircraftId")]
        [ValidateNever]
        public Aircraft Aircraft { get; set; }
        public int Count { get; set; }

        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        [ValidateNever]
        public ApplicationUser ApplicationUser { get; set; }

        [NotMapped]
        public double Price { get; set; }
    }
}
