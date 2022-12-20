using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleWebService.Models.Entities
{
    [PrimaryKey("FactoryCode", "GroupCode", "CustomerId")]
    public class FactoriesToCustomer
    {
        [Column("factoryCode")]
        public int FactoryCode { get; set; }
        [Column("groupCode")]
        public int GroupCode { get; set; }
        [Column("customerId")]
        public string? CustomerId { get; set; }

    }
}
