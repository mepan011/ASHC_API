using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASHC.DATA.Models;
using Microsoft.AspNetCore.Mvc;
using ASHC.REPOS.Interfaces.CategoryType;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASHC.API.Controllers.CategoryType
{
    [ApiController]
    [Route("api/CategoryType")]
    public class CategoryTypeController : ControllerBase
    {
        private readonly db_ashcContext _context;
        private readonly ICategoryType _icategoryType;

        public CategoryTypeController(db_ashcContext context, ICategoryType icategoryType)
        {
            _context = context;
            _icategoryType = icategoryType;
        }

        [HttpGet]
        [Route("asyncGetAll")]
        public async Task<ActionResult<IEnumerable<MCategoryType>>> GetCategoryType()
        {
            return await _context.MCategoryTypes.ToListAsync();
        }

        [HttpGet]
        [Route("GetAll")]
        public ActionResult<IEnumerable<MCategoryType>> GetAllUser()
        {
            var result = _icategoryType.GetAll().ToList();
            return result;
        }

        [HttpGet]
        [Route("GetAllCategoryTypeBySP")]
        public ActionResult<IEnumerable<MCategoryType>> GetAllCategoryTypeBySP()
        {
            var result = _icategoryType.GetAllBySP();
            return Ok(result);
        }


        // GET: api/CategoryType/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MCategoryType>> GetCategoryType(int id)
        {
            var _categoryType = await _context.MCategoryTypes.FindAsync(id);

            if (_categoryType == null)
            {
                return NotFound();
            }

            return _categoryType;
        }

        // PUT: api/CategoryType/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoryType(int id, MCategoryType mCategoryType)
        {
            if (id != mCategoryType.Id)
            {
                return BadRequest();
            }

            _context.Entry(mCategoryType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryTypeExists(id))
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

        private bool CategoryTypeExists(int id)
        {
            return _context.MCategoryTypes.Any(e => e.Id == id);
        }

        // POST: api/Users
        [HttpPost]
        [Route("CreateCategoryType")]
        public async Task<ActionResult<MCategoryType>> PostCategoryType(MCategoryType mCategoryType)
        {
            _context.MCategoryTypes.Add(mCategoryType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategoryType", new { id = mCategoryType.Id }, mCategoryType);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MCategoryType>> DeleteCategoryType(int id)
        {
            var _mCategoryType = await _context.MCategoryTypes.FindAsync(id);
            if (_mCategoryType == null)
            {
                return NotFound();
            }

            _context.MCategoryTypes.Remove(_mCategoryType);
            await _context.SaveChangesAsync();

            return _mCategoryType;
        }
    }
}
