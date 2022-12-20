using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleWebService.Models.Entities
{
    [PrimaryKey("CustomerId")]
    public class Customer
    {
        [Column("customerId")]
        public string? CustomerId { get; set; }
        [Column("name")]
        public string? Name { get; set; }
        [Column("address")]
        public string? Address { get; set; }
        [Column("phone")]
        public string? Phone { get; set; }
    }


}
