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
    internal class MessageRep : IMessageRep
    {
        private readonly DataContext _context;

        public MessageRep(DataContext context)
            => this._context = context;

        public IQueryable<Message> Messages => throw new NotImplementedException();

        public Task DeleteAsync(Message iditem) => Task.Run(() =>
        {
            if (_context.Messages.Contains(iditem))
            {
                _context.Messages.Remove(iditem);
                _context.SaveChanges();
            }
        });

        public async Task<Message> GetItemByIdAsync(int id)
        {
            return await _context.Messages.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task UpdateAsync(Message item)
        {
            var old = await _context.Messages.FindAsync(item.Id);
            if (old != null)
            {
                _context.Messages.Remove(old);
            }
            _context.Messages.Add(item);
            await _context.SaveChangesAsync();
        }
    }
}
