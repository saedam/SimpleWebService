using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleWebService.Models.Entities
{
    [PrimaryKey("GroupCode")]
    public class Group
    {
        [Column("groupCode")]
        public int GroupCode { get; set; }
        [Column("groupName")]
        public string? GroupName { get; set; }

    }
}
