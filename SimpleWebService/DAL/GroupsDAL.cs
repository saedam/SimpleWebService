using Microsoft.EntityFrameworkCore;
using SimpleWebService.Models.DbModels;
using System.Runtime.CompilerServices;

namespace SimpleWebService.DAL
{
    public class GroupsDAL
    {
       

        private SimpleDBContext _context;
        public GroupsDAL(SimpleDBContext dbContext)
        {
            this._context = dbContext;
        }


        public IEnumerable<GroupCustomerRecord> GetCustomersGroups()
        {
            //var aa = this._context.Database.SqlQuery<GroupCustomerRecord>($"{SQL_GetCustomersGroups}");
            //var bb = aa.ToList();
           return this._context.GroupCustomerRecords.FromSql($"select G.[groupCode], G.[groupName], FC.[customerId] from dbo.[Groups] G left join dbo.[FactoriesToCustomer] FC on FC.[groupCode] = G.[groupCode]");
           
        }
    }
   
}
