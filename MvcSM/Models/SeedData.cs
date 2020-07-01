using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcSM.Data;
using System;
using System.Linq;

namespace MvcSM.Models
{
	public static class SeedData
	{
		public static void Initialize(IServiceProvider serviceProvider)
		{
			using (var context = new MvcSMContext(
					serviceProvider.GetRequiredService<
							DbContextOptions<MvcSMContext>>()))
			{
				// Look for any student
				if (context.Student.Any())
				{
						return;   // DB has been seeded
				}
				if(context.User.Any()){
					return; //user has been seeded
				}
				context.User.AddRange(
					new User {
						Username = "checkUser",
						Password = "checkUser"
					}
				);
				// context.Student.AddRange(
				// 		new Student
				// 		{
				// 				Name = "Cristiano Ronaldo",
				// 				DOB = DateTime.Parse("05/02/1985"),
				// 				Address = "Potugar",
				// 				Email = "cr7@email.com",
				// 				Major = "Football"
				// 		},
				// 		new Student
				// 		{
				// 				Name = "Lionel Messi",
				// 				DOB = DateTime.Parse("24/06/1987"),
				// 				Address = "Argentina",
				// 				Email = "m10@email.com",
				// 				Major = "Football"
				// 		},
				// 		new Student
				// 		{
				// 				Name = "Valentino Rossi",
				// 				DOB = DateTime.Parse("01/01/1980"),
				// 				Address = "Italia",
				// 				Email = "thedoctor@email.com",
				// 				Major = "Motorcycle road racing"
				// 		},
				// 		new Student
				// 		{
				// 				Name = "Nguyen Van A",
				// 				DOB = DateTime.Parse("01/01/1999"),
				// 				Address = "Viet Nam",
				// 				Email = "superVN@email.com",
				// 				Major = "Software Engineering"
				// 		}
							
				// 	);
					context.SaveChanges();
				}
		}
	}
}