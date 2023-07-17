using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ThunderWings.Api.Models.Domain
{
    public class OrderHeader
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        [ValidateNever]
        public ApplicationUser ApplicationUser { get; set; }

        public DateTime? OrderDate { get; set; } = DateTime.Now;
        public DateTime? ShippingDate { get; set; } = DateTime.Now.AddDays(7);
        public double OrderTotal { get; set; }

        public string? OrderStatus { get; set; }
                
        public string? PhoneNumber { get; set; }
        
        public string? StreetAddress { get; set; }
        
        public string? City { get; set; }
        
        public string? State { get; set; }
       
        public string? PostalCode { get; set; }
        
        public string? Name { get; set; }
    }
}
