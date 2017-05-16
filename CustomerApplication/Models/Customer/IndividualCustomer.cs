using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerApplication.Models.Customer
{
    public class IndividualCustomer
    {
        public int CustomerId { get; set; }

        [Required]
        [RegularExpression("^[A-Z]{3,3}[0-9]{4,4}$")]
        public string CustomerCode { get; set; }

        [Required]
        [StringLength(80)]
        public string CustomerName { get; set; }

        [Required]
        public DateTime CustomerDob { get; set; }

        [Required]
        public decimal CustomerAmount { get; set; }
    }
}