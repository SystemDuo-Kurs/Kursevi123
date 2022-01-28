using Kursevi.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Kursevi.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Kurs> Kursevi { get; set; }
        public DbSet<Polaznik> Polaznici { get; set; }
        public DbSet<Predavac> Predavaci { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Predavac>().HasKey(x => x.Id);
            builder.Entity<Polaznik>().HasKey(x => x.Id);
            builder.Entity<Kurs>().HasKey(x => x.Id);
            builder.Entity<DoW>().HasKey(x => x.Id);

            builder.Entity<Kurs>().HasOne(k => k.Predavac)
                .WithMany(p => p.Courses);
            builder.Entity<Kurs>().HasMany(k => k.Polazniks)
                .WithMany(p => p.Courses);

            builder.Entity<Kurs>().Ignore(k => k.StartingTime);
            builder.Entity<Kurs>().Ignore(k => k.StartingDate);
            builder.Entity<Kurs>().Ignore(k => k.EndingDate);

            builder.Entity<DoW>().HasData
                (
                    new DoW[]
                    {
                        new DoW{Id=1, DayOfWeek=DayOfWeek.Monday},
                        new DoW{Id=2, DayOfWeek=DayOfWeek.Tuesday},
                        new DoW{Id=3, DayOfWeek=DayOfWeek.Wednesday},
                        new DoW{Id=4, DayOfWeek=DayOfWeek.Thursday},
                        new DoW{Id=5, DayOfWeek=DayOfWeek.Friday},
                        new DoW{Id=6, DayOfWeek=DayOfWeek.Saturday},
                        new DoW{Id=7, DayOfWeek=DayOfWeek.Sunday}
                    }
                );
            builder.Entity<Predavac>().HasData
                (
                    new Predavac[]
                    {
                        new Predavac{Id=-1, Name="Asd", Surname="Qwe", Email="a@a.a"},
                        new Predavac{Id=-2, Name="Qwe", Surname="Rty", Email="b@b.b"},
                        new Predavac{Id=-3, Name="Zxc", Surname="Vbn", Email="c@c.c"},
                        new Predavac{Id=-4, Name="Uio", Surname="Op", Email="d@d.d"},
                        new Predavac{Id=-5, Name="Hjk", Surname="Kl", Email="e@e.e"}
                    }
                );
        }
    }
}