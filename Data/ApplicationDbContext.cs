using Bookify.Web.Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bookify.Web.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base(option)
        {
            
        }



		protected override void OnModelCreating(ModelBuilder builder)
		{

			base.OnModelCreating(builder);
		}


        public DbSet<Category> Categories { get; set; }


    }
}
