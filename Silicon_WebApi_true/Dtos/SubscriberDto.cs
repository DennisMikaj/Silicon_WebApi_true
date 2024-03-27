using System.ComponentModel.DataAnnotations;

namespace Silicon_WebApi_true.Dtos;

public class SubscriberDto
{
	[Required(ErrorMessage = "A valid email address is required")]
	[RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Invalid email format")]
	[EmailAddress]
	public string? Email { get; set; }
}
