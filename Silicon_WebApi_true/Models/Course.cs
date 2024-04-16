using Silicon_WebApi_true.Entities;

namespace Silicon_WebApi_true.Models;

public class Course
{
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

	public static implicit operator Course(CourseEntity courseEntity)
	{
		return new Course
		{
			Id = courseEntity.Id,
			Title = courseEntity.Title,
			OriginalPrice = courseEntity.OriginalPrice,
			DiscountPrice = courseEntity.DiscountPrice,
			Hours = courseEntity.Hours,
			IsBestseller = courseEntity.IsBestseller,
			LikesInNumbers = courseEntity.LikesInNumbers,
			LikesInPercent = courseEntity.LikesInPercent,
			Author = courseEntity.Author,
		};
	}

		

}
