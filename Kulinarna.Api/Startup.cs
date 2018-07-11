using AutoMapper;
using Kulinarna.Repository;
using Kulinarna.Repository.Interfaces;
using Kulinarna.Services.Interfaces;
using Kulinarna.Services.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace Kulinarna.Api
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddCors(options => options.AddDefaultPolicy(config => config.WithOrigins("http://localhost:3000", "https://aplikacjakulinarna.azurewebsites.net", "http://aplikacjakulinarna.azurewebsites.net")
				.AllowAnyHeader()
				.AllowAnyMethod()
				.AllowCredentials()));
			services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
			services.AddTransient<IRecipeService, RecipeService>();
			services.AddTransient<IIngredientService, IngredientService>();
			services.AddTransient<IUserService, UserService>();
			services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
			services.AddDefaultIdentity<IdentityUser>()
				.AddEntityFrameworkStores<ApplicationDbContext>()
				.AddDefaultTokenProviders();
			services.Configure<IdentityOptions>(options =>
				{
					options.Password.RequireDigit = false;
					options.Password.RequireNonAlphanumeric = false;
					options.Password.RequireUppercase = false;
					options.Lockout.AllowedForNewUsers = false;
				});
			services.ConfigureApplicationCookie(options => {
				options.Events.OnRedirectToLogin = context =>
				{
					context.Response.StatusCode = 401;
					return Task.CompletedTask;
				};
				options.Cookie.SecurePolicy = Microsoft.AspNetCore.Http.CookieSecurePolicy.SameAsRequest;
				options.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.None;
				});

			services.AddAutoMapper();
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, UserManager<IdentityUser> userManager)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseHsts();
			}
			app.UseCors(builder => builder.WithOrigins("http://localhost:3000", "https://aplikacjakulinarna.azurewebsites.net", "http://aplikacjakulinarna.azurewebsites.net")
				.AllowAnyHeader()
				.AllowAnyMethod()
				.AllowCredentials());
			app.UseAuthentication();
			app.UseHttpsRedirection();
			app.UseMvc();
			IdentitySeed.SeedUser(userManager);
		}
	}
}
