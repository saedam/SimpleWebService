using MessagePack;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleWebService.Models.Entities
{
    [PrimaryKey("FactoryCode")]
    public class Factory
    {
        [Column("factoryCode")]
        public int? FactoryCode { get; set; }
        [Column("factoryName")]
        public string? FactoryName { get; set; }
    }
}
