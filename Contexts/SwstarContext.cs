using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Data.Contexts;
using Data.PgwConfiguration;
using Data.SwStarConfiguration;
using Microsoft.EntityFrameworkCore;

namespace Entities.SwStar;

public partial class SwstarContext : DbContext
{
    #region ctor
    public SwstarContext(DbContextOptions<SwstarContext> options) : base(options) { } 
    #endregion

    #region DBSet
    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<AccountType> AccountTypes { get; set; }

    public virtual DbSet<ApiCallHistory> ApiCallHistories { get; set; }

    public virtual DbSet<ApiInfo> ApiInfos { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Contract> Contracts { get; set; }

    public virtual DbSet<ContractStateType> ContractStateTypes { get; set; }

    public virtual DbSet<Cspinformation> Cspinformations { get; set; }

    public virtual DbSet<Csplicense> Csplicenses { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<CustomerInfo> CustomerInfos { get; set; }

    public virtual DbSet<CustomerType> CustomerTypes { get; set; }

    public virtual DbSet<Factor> Factors { get; set; }

    public virtual DbSet<IdentifyType> IdentifyTypes { get; set; }

    public virtual DbSet<InstallmentPayment> InstallmentPayments { get; set; }

    public virtual DbSet<Installment> Intallments { get; set; }

    public virtual DbSet<IntallmentState> IntallmentStates { get; set; }

    public virtual DbSet<IpwhiteList> IpwhiteLists { get; set; }

    public virtual DbSet<Merchant> Merchants { get; set; }

    public virtual DbSet<MerchantCategoryCode> MerchantCategoryCodes { get; set; }

    public virtual DbSet<PersonInformation> PersonInformations { get; set; }

    public virtual DbSet<PersonType> PersonTypes { get; set; }

    public virtual DbSet<ProcessCode> ProcessCodes { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductCategory> ProductCategories { get; set; }

    public virtual DbSet<Provider> Providers { get; set; }

    public virtual DbSet<ProviderRequest> ProviderRequests { get; set; }

    public virtual DbSet<Province> Provinces { get; set; }

    public virtual DbSet<ResultCode> ResultCodes { get; set; }

    public virtual DbSet<Settelment> Settelments { get; set; }

    public virtual DbSet<SubProcessCode> SubProcessCodes { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; } 
    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new AccountMap());
        modelBuilder.ApplyConfiguration(new AccountTypeMap());
        modelBuilder.ApplyConfiguration(new ApiCallHistoryMap());
        modelBuilder.ApplyConfiguration(new ApiInfoMap());
        modelBuilder.ApplyConfiguration(new CityMap());
        modelBuilder.ApplyConfiguration(new ContractMap());
        modelBuilder.ApplyConfiguration(new ContractStateTypeMap());
        modelBuilder.ApplyConfiguration(new CspinformationMap());
        modelBuilder.ApplyConfiguration(new CsplicenseMap());
        modelBuilder.ApplyConfiguration(new CustomerMap());
        modelBuilder.ApplyConfiguration(new CustomerInfoMap());
        modelBuilder.ApplyConfiguration(new CustomerTypeMap());
        modelBuilder.ApplyConfiguration(new FactorMap());
        modelBuilder.ApplyConfiguration(new IdentifyTypeMap());
        modelBuilder.ApplyConfiguration(new InstallmentPaymentMap());
        modelBuilder.ApplyConfiguration(new InstallmentMap());
        modelBuilder.ApplyConfiguration(new IntallmentStateMap());
        modelBuilder.ApplyConfiguration(new IpwhiteListMap());
        modelBuilder.ApplyConfiguration(new MerchantMap());
        modelBuilder.ApplyConfiguration(new MerchantCategoryCodeMap());
        modelBuilder.ApplyConfiguration(new PersonInformationMap());
        modelBuilder.ApplyConfiguration(new PersonTypeMap());
        modelBuilder.ApplyConfiguration(new ProcessCodeMap());
        modelBuilder.ApplyConfiguration(new ProductMap());
        modelBuilder.ApplyConfiguration(new ProductCategoryMap());
        modelBuilder.ApplyConfiguration(new ProviderMap());
        modelBuilder.ApplyConfiguration(new ProviderRequestMap());
        modelBuilder.ApplyConfiguration(new ProvinceMap());
        modelBuilder.ApplyConfiguration(new ResultCodeMap());
        modelBuilder.ApplyConfiguration(new SettelmentMap());
        modelBuilder.ApplyConfiguration(new SubProcessCodeMap());
        modelBuilder.ApplyConfiguration(new TransactionMap());

        //OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
