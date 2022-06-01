using cake_booking.DAL.Entities;
using cake_booking.DAL.Interfaces;
using cake_booking.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cake_booking.DAL.Repositories
{
    public class CakeRepository : ICakeRepository
    {
        private readonly AppDbContext _context;

        public CakeRepository(AppDbContext context)
        {
            _context = context;
        }
        // C R U D
        public async Task Create(CakeModel cakeModel)
        {
            var cake = new Cake
            {
                Name = cakeModel.Name,
                Description = cakeModel.Description,
                Price = cakeModel.Price,
            };

            await _context.Cakes.AddAsync(cake);
            await _context.SaveChangesAsync();
        }

        public async Task<List<CakeModel>> GetAll()
        {
            var cakes = await(await GetAllQuery()).ToListAsync();
            var list = new List<CakeModel>();
            foreach (var cake in cakes)
            {
                CakeModel cakeModel = new CakeModel
                {
                    Name = cake.Name,
                    Description = cake.Description,
                    Price = cake.Price
                };
                list.Add(cakeModel);
            }

            return list;
        }
        public async Task<IQueryable<Cake>> GetAllQuery()
        {
            var query = _context.Cakes.AsQueryable();
            return query;
        }

        public async Task<CakeModel> GetById(int id)
        {
            Cake cake = await _context.Cakes.FindAsync(id);
            CakeModel cakeModel = new CakeModel
            {
                Name = cake.Name,
                Description = cake.Description,
                Price = cake.Price
            };
            return cakeModel;
        }

        public async Task Update(int id, CakeModel cakeModel)
        {
            Cake cake = await _context.Cakes.FindAsync(id);

            cake.Name = cakeModel.Name;
            cake.Description= cakeModel.Description;
            cake.Price = cakeModel.Price;

            _context.Cakes.Update(cake);

            await _context.SaveChangesAsync(); 
        }
        public async Task Delete(int id)
        {
            Cake cake = await _context.Cakes.FindAsync(id);

            _context.Cakes.Remove(cake);

            await _context.SaveChangesAsync();
        }
    }
}
