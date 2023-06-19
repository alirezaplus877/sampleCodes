using Data.ShaparakInAppPurchaseConfiguration;
using Entities.ShaparakInAppPurchaseEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Contexts
{
    public class ShaparakInAppPurchaseContext: DbContext
    {
        #region DbSet
        public virtual DbSet<MerchantInquiry> MerchantInquiries { get; set; }
        public virtual DbSet<Purchase> Purchases { get; set; }
        public virtual DbSet<SettlementInformation> SettlementInformations { get; set; }
        public virtual DbSet<Test> Test { get; set; }
        #endregion
        public ShaparakInAppPurchaseContext(DbContextOptions<ShaparakInAppPurchaseContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new MerchantInquiryMap());
            modelBuilder.ApplyConfiguration(new PurchaseMap());
            modelBuilder.ApplyConfiguration(new SettlementInformationMap());
            modelBuilder.ApplyConfiguration(new TestMap());
        }
    }
}
