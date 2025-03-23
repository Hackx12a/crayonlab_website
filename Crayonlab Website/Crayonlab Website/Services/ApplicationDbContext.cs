using Microsoft.EntityFrameworkCore;
using Crayonlab.Models;

namespace Crayonlab.Services
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
		}

		public required DbSet<Designs> Designs { get; set; } // Ensure this is 'Designs'
        public required DbSet<BasketballJersey> BasketballJerseys { get; set; }
        public required DbSet<Longsleeve> Longsleeves { get; set; }
        public required DbSet<Soccerjersey> Soccerjerseys { get; set; }
        public required DbSet<Account> Accounts { get; set; }
    }
}
