using Hakawy.Core.Identity;
using Hakawy.Repository.Data;
using Hakawy.Repository.Services.Interfaces;
using Hakawy.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace GraduationProject
{
	public class Program
	{
		public static void Main(string[] args)
		{
			#region ConfigreService
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			builder.Services.AddDbContext<HakawyDBContext>(options =>
			{
				options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
			});

			builder.Services.AddIdentity<AppUser, IdentityRole>()
							.AddEntityFrameworkStores<HakawyDBContext>()
							.AddDefaultTokenProviders();

			builder.Services.AddScoped<ITokenService, TokenService>();


			//builder.Services.Configure<ApiBehaviorOptions>(options =>
			//{
			//	options.InvalidModelStateResponseFactory
			//});

			#endregion
			var app = builder.Build();

			using var Scope = app.Services.CreateScope();

			var Services = Scope.ServiceProvider;

			var _Context = Services.GetRequiredService<HakawyDBContext>();
			// Ask CLR To Creating Object From HakawyDBContext

			var loggerFactory = Services.GetRequiredService<ILoggerFactory>();

			try
			{
				_Context.Database.MigrateAsync(); // Update  Database
			}
			catch (Exception ex)
			{
				var logger = loggerFactory.CreateLogger<Program>();
				logger.LogError(ex, "an error has been occured during appling migrations");
				
			}

			





			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthentication();
			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}
