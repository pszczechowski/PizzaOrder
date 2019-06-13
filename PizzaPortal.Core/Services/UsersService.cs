using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaPortal.Contract.PizzaTemplatesDto;
using PizzaPortal.Core.Services.Mappers;
using PizzaPortal.Infrastructure;
using PizzaPortal.Infrastructure.Repository;

namespace PizzaPortal.Core.Services
{
    public interface IUsersService : IService<UsersDto>
    {

    }

    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _iUsersRepository;
        
        public UsersService(IUsersRepository iUsersRepository)
        {
            _iUsersRepository = iUsersRepository;
        }

        public async Task<IEnumerable<UsersDto>> GetAll()
        {
            var users = await _iUsersRepository.GetAll();
            return users
                .Select(UserMapper.MapDtoToUsers)
                .ToList();
        }

        public async Task<UsersDto> GetById(long id)
        {
            var users = await _iUsersRepository.GetById(id);
            return UserMapper.MapDtoToUsers(users);
        }

        public async Task Add(UsersDto pizza)
        {
            await _iUsersRepository.Add(UserMapper.MapUserToDto(pizza));
        }

        public async Task Update(UsersDto entity)
        {
            await _iUsersRepository.Update(UserMapper.MapUserToDto(entity));
        }

        public async Task Delete(long id)
        {
            await _iUsersRepository.Delete(id);
        }
    }
}