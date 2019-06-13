using PizzaPortal.Contract.PizzaTemplatesDto;
using PizzaPortal.Infrastructure;

namespace PizzaPortal.Core.Services.Mappers
{
    public static class UserMapper
    {
        public static UsersDto MapDtoToUsers(User users)
        {
            return new UsersDto()
            {
                FirstName = users.FirstName,
                LastName = users.LastName,
                Email = users.Email,
                PhoneNumber = users.PhoneNumber,
                Username = users.Username,
                City = users.Address.City,
                Street = users.Address.Street,
                ZipCode = users.Address.ZipCode,
                Country = users.Address.Country,
                Id = users.Id
            };
        }

        public static User MapUserToDto(UsersDto user)
        {
            return new User()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Username = user.Username,
                Id = user.Id.GetValueOrDefault(),
                Address = new Address()
                {
                    City = user.City,
                    Street = user.Street,
                    ZipCode = user.ZipCode,
                    Country = user.Country,
                }

            };
        }
    }
}