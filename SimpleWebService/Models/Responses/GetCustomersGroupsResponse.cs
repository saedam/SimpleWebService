using SimpleWebService.Models.Entities;

namespace SimpleWebService.Models.Responses
{
    public class GetCustomersGroupsResponse
    {
        public IEnumerable<CustomersGroup>? CustomersGroups { get; set; }
    }

    public class CustomersGroup
    {
        public Group? Group { get; set; }

        public IEnumerable<string?>? CustomerIDs { get; set; }
    }
}
