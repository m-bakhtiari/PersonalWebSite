using Microsoft.EntityFrameworkCore;
using System.Linq;
using PersonalCV.Core.Entities;

namespace PersonalCV.Core.Context
{
    public class PersonalCVContext : DbContext
    {

        public PersonalCVContext(DbContextOptions<PersonalCVContext> options) : base(options)
        {

        }

        public DbSet<Skill> Skills { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<SiteInfo> SiteInfos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;

            base.OnModelCreating(modelBuilder);
        }
    }
}
