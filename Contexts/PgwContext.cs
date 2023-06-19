using Data.PgwConfiguration;
using Entities.PgwEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Contexts
{
    public class PgwContext: DbContext
    {
        #region DbSet
        public virtual DbSet<_Merchant> Merchant { get; set; }
        
        #endregion
        public PgwContext(DbContextOptions<PgwContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new _MerchantMap());
            
        }
    }
}
