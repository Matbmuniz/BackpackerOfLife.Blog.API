using BackpackerOfLife.Blog.API.Model;
using Microsoft.EntityFrameworkCore;

namespace BackpackerOfLife.Blog.API.Context
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options) { }

        public DbSet<Content> Contents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Content>().HasData(
                new Content
                {
                    Id = 1,
                    Likes = 1,
                    Views = 1,
                    Title = "Bem Vindos",
                    Description = "Hoje inicio esse site para seguir o compartilhamento sobre áreas onde tenho " +
                       "interesse, com focos em Programação e Viagens... Sim, assuntos um pouco distantes," +
                       " mas que tenho uma grande vontade de compartilhar além de treinar novas tecnologias com esse site/blog.",
                    InitialDate = DateTime.Now,
                    IsActive = true
                }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
