using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Silicon_WebApi_true.Contexts;
using Silicon_WebApi_true.Dtos;
using Silicon_WebApi_true.Entities;

namespace Silicon_WebApi_true.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SubscriberController(DataContext context) : ControllerBase
{
	private readonly DataContext _context = context;

	#region CREATE
	[HttpPost]
	public async Task<IActionResult> Create(string email)
	{
		//var email = subscriberDto.Email;

		if (string.IsNullOrEmpty(email))
		{
			ModelState.AddModelError("Email", "Email is required");
			return BadRequest(ModelState);
		}

		if (!ModelState.IsValid)
		{
			return BadRequest(ModelState);
		}

		if (!await _context.Subscribers.AnyAsync(x => x.Email == email))
			{
				try
				{
					var subscriberEntity = new SubscriberEntity { Email = email };
					_context.Subscribers.Add(subscriberEntity);
					await _context.SaveChangesAsync();
					return Created("", null);
				}
				catch
				{
					return Problem("Unable to create subscription");
				}
			}
			return Conflict("The email address is already subscribed");
		
	}
	#endregion


	#region READ
	[HttpGet]
	public async Task<IActionResult> GetAll()
	{
		var subscribers = await _context.Subscribers.ToListAsync();
		if (subscribers.Count != 0)
		{
			return Ok(subscribers);
		}

		return NotFound();
	}

	[HttpGet("{id}")]
	public async Task<IActionResult> GetOne(int id)
	{
		var subscriber = await _context.Subscribers.FirstOrDefaultAsync(x => x.Id == id);
		if (subscriber != null)
		{
			return Ok(subscriber);
		}
		return NotFound();
	}
	#endregion


	#region UPDATE 
	[HttpPut("{id}")]
	public async Task<IActionResult> UpdateOne(int id, string email)
	{
		var subscriber = await _context.Subscribers.FirstOrDefaultAsync(x => x.Id == id);
		if (subscriber != null)
		{
			subscriber.Email = email;
			_context.Subscribers.Update(subscriber);
			await _context.SaveChangesAsync();

			return Ok(subscriber);
		}
		return NotFound();
	}
	#endregion


	#region DELETE
	[HttpDelete("{id}")]
	public async Task<IActionResult> DeleteOne(int id)
	{
		var subscriber = await _context.Subscribers.FirstOrDefaultAsync(x => x.Id == id);
		if (subscriber != null)
		{
			_context.Subscribers.Remove(subscriber);
			await _context.SaveChangesAsync();

			return Ok();
		}
		return NotFound();
	}
	#endregion
}
