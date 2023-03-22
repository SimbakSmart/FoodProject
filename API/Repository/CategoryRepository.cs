using API.Data;
using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Repository
{
    public class CategoryRepository : IGenericRepository<Category>
    {
        private readonly DbFoodContext _context;

        public CategoryRepository(DbFoodContext context)
        {
            _context = context;
        }
        public async Task<int> CountAsync()
        {
           return  await _context.Categories.CountAsync();
        }

        public async Task<Category> CreatedAsync(Category t)
        {
            await _context.Categories.AddAsync(t); 
            await _context.SaveChangesAsync();
            return t;
        }

        public async Task<Category> DeletedAsync(int? id)
        {

            var result = await _context.Categories.FindAsync(id);

            if (result == null) 
                throw new NullReferenceException("Category Not Found");

           _context.Categories.Remove(result);
          await  _context.SaveChangesAsync();
              
            return result;
        }

        public async Task<Category> EditAsync(Category t, int? id)
        {
            var result = await _context.Categories.FindAsync(id);

            if (result != null)
            {

                result.Name = t.Name;
                if (!string.IsNullOrEmpty(t.ImageUrl))
                {
                    result.ImageUrl = t.ImageUrl;
                }
                _context.Update(result);
                await _context.SaveChangesAsync();

                return result;
            }

            throw new NullReferenceException("Category Not Found");

        }

        public async Task<Category> GetByIdAsync(int id)
        {
            var result = await _context.Categories.FindAsync(id);

            if (result == null) 
                throw new NullReferenceException("Category Not Found");

            return result;
        }

        public async Task<IReadOnlyList<Category>> ListAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }
    }
}
