namespace Silicon_WebApi_true.Dtos;

public class CourseDto
{
	public string Title { get; set; } = null!;
	public string? ImageName { get; set; }
	public string? Author { get; set; }
	public bool IsBestseller { get; set; } = false;
	public int Hours { get; set; }
	public decimal OriginalPrice { get; set; }
	public decimal DiscountPrice { get; set; }
	public decimal LikesInPercent { get; set; }
	public decimal LikesInNumbers { get; set; }
}
