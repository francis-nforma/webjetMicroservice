using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using userService.Database.Entities;
using userService.Database.Repository;

namespace userService.Database.DataManager
{
    public class UserDataManager : IDataRepository<User>
    {
        readonly DatabaseContext _databaseContext;
        public UserDataManager(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<User> Add(User user)
        {
            _databaseContext.Users.Add(user);
            await _databaseContext.SaveChangesAsync();
            return user;
        }

        public async Task Delete(int id)
        {
            var userToDelete = await _databaseContext.Users.FindAsync(id);
            _databaseContext.Remove(userToDelete);
            await _databaseContext.SaveChangesAsync();
        }

        public async Task<User> Get(int id)
        {
            var user = await _databaseContext.Users.FindAsync(id);

            if (user == null)
            {
                return null;
            }
            return user;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _databaseContext.Users.ToListAsync();
        }

        public async Task Update(User user)
        {
            _databaseContext.Entry(user).State = EntityState.Modified;
            await _databaseContext.SaveChangesAsync();
        }
    }
}
