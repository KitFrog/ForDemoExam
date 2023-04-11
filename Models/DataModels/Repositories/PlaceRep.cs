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
    internal class PlaceRep : IPlaceRep
    {
        private readonly DataContext _context;

        public PlaceRep(DataContext context)
            => this._context = context;

        public IQueryable<Place> Places => throw new NotImplementedException();

        public Task DeleteAsync(Place iditem) => Task.Run(() =>
        {
            if (_context.Places.Contains(iditem))
            {
                _context.Places.Remove(iditem);
                _context.SaveChanges();
            }
        });

        public async Task<Place> GetItemByIdAsync(int id)
        {
            return await _context.Places.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task UpdateAsync(Place item)
        {
            var old = await _context.Places.FindAsync(item.Id);
            if (old != null)
            {
                _context.Places.Remove(old);
            }
            _context.Places.Add(item);
            await _context.SaveChangesAsync();
        }
    }
}
