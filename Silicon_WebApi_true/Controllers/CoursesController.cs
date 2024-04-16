using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Silicon_WebApi_true.Contexts;
using Silicon_WebApi_true.Dtos;
using Silicon_WebApi_true.Entities;
using Silicon_WebApi_true.Models;

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

		[HttpPost]
		public async Task<IActionResult> CreateOne(CourseDto model)
		{
			if (ModelState.IsValid)
			{
				var courseEntity = new CourseEntity
				{
					Title = model.Title,
					OriginalPrice = model.OriginalPrice,
					DiscountPrice = model.DiscountPrice,
					Hours = model.Hours,
					IsBestseller = model.IsBestseller,
					LikesInNumbers = model.LikesInNumbers,
					LikesInPercent = model.LikesInPercent,
					Author = model.Author,
				};

				_context.Courses.Add(courseEntity);
				await _context.SaveChangesAsync();


				return Created("", (Course)courseEntity);
			}
			return BadRequest();
		}

	}
}
