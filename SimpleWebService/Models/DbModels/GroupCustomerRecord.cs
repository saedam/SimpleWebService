using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleWebService.Models.DbModels
{
    [Keyless]
    public class GroupCustomerRecord
    {
        [Column("groupCode")]
        public int GroupCode { get; set; }
        [Column("groupName")]
        public string? GroupName { get; set; }
        [Column("customerId")]
        public string? CustomerId { get; set; }

    }
}
