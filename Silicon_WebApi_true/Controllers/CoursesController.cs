using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Silicon_WebApi_true.Contexts;

namespace Silicon_WebApi_true.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CoursesController(DataContext context) : ControllerBase
	{
		private readonly DataContext _context = context;


		[HttpGet]
		public async Task<IActionResult> GetAll() => Ok(await _context.Courses.ToListAsync());


		[HttpGet("{id}")]
		public async Task<IActionResult> GetOne(int id)
		{
			var course = await _context.Courses.FirstOrDefaultAsync(x => x.Id == id);
			if (course != null)
			{
				return Ok(course);
			}
			return NotFound();
		} 
	}
}
