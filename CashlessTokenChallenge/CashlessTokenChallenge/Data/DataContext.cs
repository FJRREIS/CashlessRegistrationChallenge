using CashlessTokenChallenge.Models;
using Microsoft.EntityFrameworkCore;

namespace CashlessTokenChallenge.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Card> Cards { get; set; }

        public DbSet<Token> Tokens { get; set; }
    }
}
