using EksiSozluk.Api.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.Infrastructure.Persistence.Context
{
    public class EksiSozlukContext:DbContext
    {
        public const string DEFAULT_SCHEMA = "dbo";

        public EksiSozlukContext()
        {
            
        }
        public EksiSozlukContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<User> Users { get; set; }
        public DbSet<Entry> Entries { get; set; }
        public DbSet<EntryVote> EntryVotes { get; set; }
        public DbSet<EntryFavorite> EntryFavorites { get; set; }


        public DbSet<EntryCommentFavorite> EntryCommentFavorites { get; set; }
        public DbSet<EntryComment> EntryComments { get; set; }
        public DbSet<EntryCommentVote> EntryCommentVotes { get; set; }
        public DbSet<EmailConfirmation> EmailConfirmations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured )
            {
                var connStr = "server=DESKTOP-P1C58SB;initial catalog=EksiSozlukDb;integrated security=true";
                optionsBuilder.UseSqlServer(connStr, opt =>
                {
                    opt.EnableRetryOnFailure();
                });

            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public override int SaveChanges() // createdateyi otomatik olarak set edecek savachanges çalışamdan önce  OnBeforeSave();

        {
            OnBeforeSave();

            return base.SaveChanges();
        }
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSave();

            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            OnBeforeSave();

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            OnBeforeSave();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void OnBeforeSave()
        {
            // Bütün entitiyleri yakala ve bu eklenen entitilerin stati benim için eklenmişse bunları base entitiye çevir 
            var addedEntites = ChangeTracker.Entries().Where(i => i.State == EntityState.Added).Select(i=>(BaseEntity)i.Entity);
            PrepareAddedEntities(addedEntites);
        }
        private void PrepareAddedEntities(IEnumerable<BaseEntity>entities)  // foreach ile entitiler arası döndü. eklenmişler arasında döndü ve createdateyi now olarak işaretledik.
        {
            foreach (var entity in entities)
            {
                if(entity.CreatedDate==DateTime.MinValue)
                entity.CreatedDate = DateTime.Now;
            }
        }
    }
}
