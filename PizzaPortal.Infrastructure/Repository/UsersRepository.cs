using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PizzaPortal.Infrastructure.Context;


namespace PizzaPortal.Infrastructure.Repository
{
    public class UsersRepository : IUsersRepository
    {
        public async Task<IEnumerable<User>> GetAll()
        {
          return await _pizzaPortalContext.Users.ToListAsync();       
        }

    public async Task<User> GetById(long id)
    {
        var firstName = await _pizzaPortalContext.Users
            .Where(x => x.Id == id)
            .SingleOrDefaultAsync();
        /*await _pizzaPortalContext.Entry(firstName).Reference(x => x.FirstName).LoadAsync();
        var lastName = await _pizzaPortalContext.Users
            .Where(x => x.Id == id)
            .SingleOrDefaultAsync();
        await _pizzaPortalContext.Entry(lastName).Reference(x => x.LastName).LoadAsync();
        var email = await _pizzaPortalContext.Users
            .Where(x => x.Id == id)
            .SingleOrDefaultAsync();
        await _pizzaPortalContext.Entry(email).Reference(x => x.Email).LoadAsync();
        var phoneNumber = await _pizzaPortalContext.Users
            .Where(x => x.Id == id)
            .SingleOrDefaultAsync();
        await _pizzaPortalContext.Entry(phoneNumber).Reference(x => x.PhoneNumber).LoadAsync();
        var userName = await _pizzaPortalContext.Users
            .Where(x => x.Id == id)
            .SingleOrDefaultAsync();
        await _pizzaPortalContext.Entry(userName).Reference(x => x.Username).LoadAsync();
        var passwordHash = await _pizzaPortalContext.Users
            .Where(x => x.Id == id)
            .SingleOrDefaultAsync();
        await _pizzaPortalContext.Entry(passwordHash).Reference(x => x.PasswordHash).LoadAsync();
        var isAdmin = await _pizzaPortalContext.Users
            .Where(x => x.Id == id)
            .SingleOrDefaultAsync();
        await _pizzaPortalContext.Entry(isAdmin).Reference(x => x.IsAdmin.ToString()).LoadAsync();
        var address = await _pizzaPortalContext.Users
            .Where(x => x.Id == id)
            .SingleOrDefaultAsync();
        await _pizzaPortalContext.Entry(address).Reference(x => x.Address).LoadAsync();*/

        try
        {
            await _pizzaPortalContext.Entry(firstName).Reference(x => x.Address).LoadAsync();

        }
        catch (ArgumentException e)
        {
            return null;
        }
        
        return firstName;
    }

        public async Task Add(User pizza)
        {
            pizza.DateOfCreation = DateTime.Now;
            await _pizzaPortalContext.Users
                .Include(x => x.Address)
                .FirstAsync();
            await _pizzaPortalContext.Users.AddAsync(pizza);
            await _pizzaPortalContext.SaveChangesAsync();


        }

        public async Task Update(User entity)
        {
         var userToUpdate = await _pizzaPortalContext.Users
                .Include(x => x.Address)
                .SingleOrDefaultAsync(x => x.Id == entity.Id);
         if (userToUpdate != null)
         {
             userToUpdate.FirstName = entity.FirstName;
             userToUpdate.LastName = entity.LastName;
             userToUpdate.Email = entity.Email;
             userToUpdate.PhoneNumber = entity.PhoneNumber;
             userToUpdate.Username = entity.Username;
             userToUpdate.PasswordHash = entity.PasswordHash;
             userToUpdate.IsAdmin = entity.IsAdmin;
             userToUpdate.Address = entity.Address;
             userToUpdate.DateOfUpdate = DateTime.Now;
         }
        }

        public async Task Delete(long id)
        {
            var userToDelete = await _pizzaPortalContext.Users.SingleOrDefaultAsync(pizza => pizza.Id == id);
            if (userToDelete != null)
            {
                _pizzaPortalContext.Users.Remove(userToDelete);
            }
        }

        private readonly PizzaPortalContext _pizzaPortalContext;

        public UsersRepository(PizzaPortalContext pizzaPortalContext)
        {
            _pizzaPortalContext = pizzaPortalContext;
        }
    }
}