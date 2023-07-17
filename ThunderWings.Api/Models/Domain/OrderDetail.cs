using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ThunderWings.Api.Models.Domain
{
    public class OrderDetail
    {
        public int Id { get; set; }
        [Required]
        public int OrderHeaderId { get; set; }
        [ForeignKey("OrderHeaderId")]
        [ValidateNever]
        public OrderHeader OrderHeader { get; set; }

        [Required]
        public int AircraftId { get; set; }
        [ForeignKey("AircraftId")]
        [ValidateNever]
        public Aircraft Aircraft { get; set; }

        public int Count { get; set; }
        public double Price { get; set; }
    }
}
