using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MvcSM.Data;
using Microsoft.EntityFrameworkCore;
namespace MvcSM
{
	public class Startup
	{
		
		public Startup(IConfiguration configuration, IWebHostEnvironment env)
		{
			Environment = env;
			Configuration = configuration;
			
			
		}
		public IWebHostEnvironment Environment { get; }
		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  
		{
			services.AddControllersWithViews();
		//	services.AddControllersWithViews();
			services.AddDbContext<MvcSMContext>(options => { options.UseSqlite($"Data Source={Environment.ContentRootPath}/MvcSM.db"); });
			// Add framework services.
            services.AddMvc();
			
			// services.AddDistributedRedisCache(options =>
			// {
			// 	options.Configuration = "localhost";
			// 	options.InstanceName = "master";
			// });
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
				if (env.IsDevelopment())
				{
						app.UseDeveloperExceptionPage();
				}
				else
				{
						app.UseExceptionHandler("/Home/Error");
						// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
						app.UseHsts();
				}
				app.UseHttpsRedirection();
				app.UseStaticFiles();

				app.UseRouting();

				app.UseAuthorization();

				app.UseEndpoints(endpoints =>
				{
					endpoints.MapControllerRoute(
						name: "default",
						pattern: "{controller=Home}/{action=Login}/{id?}");
					endpoints.MapControllerRoute(
						name: "default2",
						pattern: "{controller=Home}/{action=Index}/{id?}");
					endpoints.MapControllerRoute(
					name: "login",
					pattern: "{controller=User}/{action=Login}/{id?}");
				});
		}
	}
}
