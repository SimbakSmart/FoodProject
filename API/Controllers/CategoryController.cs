
using API.Dtos.Request;
using API.Entities;
using API.Interfaces;
using API.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace API.Controllers
{
    
    public class CategoryController : BasicApiController
    {
        private readonly IGenericRepository<Category> _context;

        public CategoryController(IGenericRepository<Category> context)
        {
            _context = context;
        }

        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<Category>> AddAsync([FromForm] CategoryRequestDto request)
        {
            var category = new Category
            {
                Name = request.Name,
                ImageUrl = "NoImage.png"
            };

          category = await _context.CreatedAsync(category);


            
            //var category = _mapper.Map<Category>(categoryRequestDto);
            //category.ImageUrl = categoryRequestDto.File == null ? GlobalVariablesHelper.IMAGE_NAME
            //                                                       : $"{Guid.NewGuid().ToString()}.jpg";

            //var result = await _categoryRepository.CreateAsync(category);

            //if (result == null) return BadRequest();

            //if (categoryRequestDto.File != null && result != null)
            //    await _file.AddImageAsync(categoryRequestDto.File, category.ImageUrl);


            return Ok(category);
        }
    }
}
