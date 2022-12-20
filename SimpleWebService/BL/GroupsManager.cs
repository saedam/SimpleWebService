using SimpleWebService.DAL;
using SimpleWebService.Models.DbModels;
using SimpleWebService.Models.Entities;
using SimpleWebService.Models.Responses;

namespace SimpleWebService.BL
{
    public class GroupsManager
    {
        private SimpleDBContext _context;
        private GroupsDAL groupsDAL;
        public GroupsManager(SimpleDBContext dbContext)
        {
            this._context = dbContext;
            this.groupsDAL = new GroupsDAL(dbContext);
        }

        public GetCustomersGroupsResponse GetCustomersGroups()
        {
            //convert set of records to groups of customers, groups are by groupCode and groupName
            //make sure all groups are mentioned in the response, including ones with no customers are linked
            return new GetCustomersGroupsResponse()
            {
                CustomersGroups = groupsDAL.GetCustomersGroups()
                .GroupBy(record => new Group() { GroupCode = record.GroupCode, GroupName = record.GroupName })
                .Select(grouping => new CustomersGroup()
                {
                    Group = grouping.Key,
                    CustomerIDs = grouping.FirstOrDefault()?.CustomerId == null ? null :
                    grouping.Select(record => record.CustomerId)
                })
            };

        }


    }

    public class EmptyGrouping<TKey, TElement> : List<TElement>, IGrouping<TKey, TElement>
    {
        public TKey Key { get; }
        public EmptyGrouping(TKey key) : base()
        {
            Key = key;
        }
    }
}
