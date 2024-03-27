using Microsoft.EntityFrameworkCore;
using Silicon_WebApi_true.Entities;
using System.Collections.Generic;

namespace Silicon_WebApi_true.Contexts
{
	public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
	{
		public DbSet<SubscriberEntity> Subscribers { get; set; }
		public DbSet<CourseEntity> Courses { get; set; }
	}

}
