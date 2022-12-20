using SimpleWebService.Models.Entities;

namespace SimpleWebService.Models.Requests
{
    public class AddCustomerRequest
    {
        public Customer? Customer { get; set; }
        public int GroupCode { get; set; }
        public int FactoryCode { get; set; }
    }
}
