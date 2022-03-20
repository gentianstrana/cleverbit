using Cleverbit.CodingTask.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cleverbit.CodingTask.Data
{
    public class CodingTaskContext : DbContext
    {
        public CodingTaskContext(DbContextOptions<CodingTaskContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Match> Matches { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable(nameof(User));
            BuildMatchModel(modelBuilder.Entity<Match>());

        }

        private void BuildMatchModel(EntityTypeBuilder<Match> entityTypeBuilder)
        {
            entityTypeBuilder
                .HasKey(mch => mch.Id);

            entityTypeBuilder
                .Property(mch => mch.Id)
                .ValueGeneratedOnAdd();


            entityTypeBuilder
                .HasOne(mch => mch.PlayerOne)
                .WithMany(usr => usr.MatchesAsPlayerOne)
                .HasPrincipalKey(usr => usr.Id)
                .HasForeignKey(mch => mch.PlayerOneId)
                .OnDelete(DeleteBehavior.Restrict);

            entityTypeBuilder
                .HasOne(mch => mch.PlayerTwo)
                .WithMany(usr => usr.MatchesAsPlayerTwo)
                .HasPrincipalKey(usr => usr.Id)
                .HasForeignKey(mch => mch.PlayerTwoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
