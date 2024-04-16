using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Silicon_WebApi_true.Models;
using Silicon_WebApi_true.Dtos;

namespace Silicon_WebApi_true.Entities;

public class CourseEntity
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int Id { get; set; }
	public string Title { get; set; } = null!;
	public string? ImageName { get; set; }
	public string? Author { get; set; }
	public bool IsBestseller { get; set; }
	public int Hours { get; set; }
	public decimal OriginalPrice { get; set; }
	public decimal DiscountPrice { get; set; }
	public decimal LikesInPercent { get; set; }
	public decimal LikesInNumbers { get; set; }


}
