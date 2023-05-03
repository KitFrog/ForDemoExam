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
    internal class EventRep : IEventRep
    {
        private readonly DataContext _context;

        public EventRep(DataContext context)
            => this._context = context;

        public IQueryable<Event> Events => _context.Events;

        public Task DeleteAsync(Event iditem) => Task.Run(() =>
        {
            if (_context.Events.Contains(iditem))
            {
                _context.Events.Remove(iditem);
                _context.SaveChanges();
            }
        });
        

        public async Task<Event> GetItemByIdAsync(int id)
        {
            return await _context.Events.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task UpdateAsync(Event item)
        {
            var old = await _context.Events.FindAsync(item.Id);
            if (old != null)
            {
                _context.Events.Remove(old);
            }
            _context.Events.Add(item);
            await _context.SaveChangesAsync();
        }
    }
}
