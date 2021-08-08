using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using PersonalCV.Core.Consts;
using PersonalCV.Core.Entities;
using PersonalCV.Core.Enums;

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
        public DbSet<TemplateGroup> TemplateGroups { get; set; }
        public DbSet<Template> Templates { get; set; }
        public DbSet<HostPlan> HostPlans { get; set; }
        public DbSet<SkillDetail> SkillDetails { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;

            modelBuilder.Entity<SiteInfo>().HasData(new List<SiteInfo>()
            {
                new SiteInfo()
                {
                    Id = 1,Key = GeneralEnums.GeneralEnum.Username, Value = Const.Username,
                },
                new SiteInfo()
                {
                    Id = 2,Key = GeneralEnums.GeneralEnum.Password, Value = Const.Password,
                }
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
