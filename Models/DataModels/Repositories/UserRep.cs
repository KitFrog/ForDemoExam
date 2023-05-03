using DataModels.Entities;
using DataModels.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Repositories
{
    internal class UserRep : IUserRep
    {
        private readonly DataContext _context;

        public UserRep(DataContext context)
            => this._context = context;

        public IQueryable<User> Users => _context.Users;

        public Task DeleteAsync(User iditem) => Task.Run(() =>
        {
            if (_context.Users.Contains(iditem))
            {
                _context.Users.Remove(iditem);
                _context.SaveChanges();
            }
        });

        public async Task<User> GetItemByIdAsync(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task UpdateAsync(User item)
        {
            var old = await _context.Users.FindAsync(item.Id);
            if (old != null)
            {
                _context.Users.Remove(old);
            }
            _context.Users.Add(item);
            await _context.SaveChangesAsync();
        }
    }
}
