using System.Net.Http;

namespace PizzaPortal.Contract.PizzaTemplatesDto
{
    public class UsersDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Username { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public long? Id { get; set; }
    }
}