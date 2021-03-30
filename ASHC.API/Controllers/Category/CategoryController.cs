using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASHC.DATA.Models;
using ASHC.REPOS.Interfaces.Category;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASHC.API.Controllers.Category
{
    [ApiController]
    [Route("api/Category")]
    public class CategoryController : ControllerBase
    {
        private readonly db_ashcContext _context;
        private readonly ICategory _icategory;

        public CategoryController(db_ashcContext context, ICategory icategory)
        {
            _context = context;
            _icategory = icategory;
        }

        [HttpGet]
        [Route("asyncGetAll")]
        public async Task<ActionResult<IEnumerable<MCategory>>> GetCategoryType()
        {
            return await _context.MCategories.ToListAsync();
        }

        [HttpGet]
        [Route("GetAll")]
        public ActionResult<IEnumerable<MCategory>> GetAllUser()
        {
            var result = _icategory.GetAll().ToList();
            return result;
        }

        [HttpGet]
        [Route("GetAllCategoryTypeBySP")]
        public ActionResult<IEnumerable<MCategory>> GetAllCategoryBySP()
        {
            var result = _icategory.GetAllBySP();
            return Ok(result);
        }


        // GET: api/CategoryType/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MCategory>> GetCategory(int id)
        {
            var _category = await _context.MCategories.FindAsync(id);

            if (_category == null)
            {
                return NotFound();
            }

            return _category;
        }

        // PUT: api/CategoryType/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoryType(int id, MCategory mCategory)
        {
            if (id != mCategory.Id)
            {
                return BadRequest();
            }

            _context.Entry(mCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool CategoryExists(int id)
        {
            return _context.MCategories.Any(e => e.Id == id);
        }

        // POST: api/Users
        [HttpPost]
        [Route("CreateCategory")]
        public async Task<ActionResult<MCategory>> PostCategoryType(MCategory mCategory)
        {
            _context.MCategories.Add(mCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategory", new { id = mCategory.Id }, mCategory);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MCategory>> DeleteCategoryType(int id)
        {
            var _mCategory = await _context.MCategories.FindAsync(id);
            if (_mCategory == null)
            {
                return NotFound();
            }

            _context.MCategories.Remove(_mCategory);
            await _context.SaveChangesAsync();

            return _mCategory;
        }
    }
}
