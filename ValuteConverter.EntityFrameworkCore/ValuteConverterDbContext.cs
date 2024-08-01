using Microsoft.EntityFrameworkCore;
using ValuteConverter.Domain.Models;

namespace ValuteConverter.EntityFrameworkCore;

public class ValuteConverterDbContext : DbContext
{
    public DbSet<Currency> Currencies { get; set; }
    public DbSet<CurrencyCourse> CurrencyCourses { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public ValuteConverterDbContext(DbContextOptions options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Currency>(a =>
        {
            a.ToTable("Currencies", "CurrencyDB");
            a.Property(x => x.Code).IsRequired().HasMaxLength(120);
            a.Property(x => x.Name).IsRequired().HasMaxLength(120);
            a.Property(x => x.NameLatin).IsRequired().HasMaxLength(120);
            a.Property(x => x.CreationDate).IsRequired();
        });
        modelBuilder.Entity<CurrencyCourse>(a =>
        {
            a.ToTable("CurrencyCourses", "CurrencyDB");
            a.HasOne(x => x.Currency).WithOne().HasForeignKey<CurrencyCourse>(x => x.CurrencyId);
        });
        modelBuilder.Entity<Client>(a =>
        {
            a.ToTable("Clients", "CurrencyDB");
            a.Property(x => x.FirstName).IsRequired().HasMaxLength(120);
            a.Property(x => x.LastName).IsRequired().HasMaxLength(120);
            a.Property(x => x.PersonalNumber).IsRequired().HasMaxLength(11);
            a.Property(x => x.RecomendatorPersonalNumber).IsRequired().HasMaxLength(11);
            a.Property(x => x.CreationDate).IsRequired();
        });
        modelBuilder.Entity<Transaction>(a =>
        {
            a.ToTable("Transactions", "CurrencyDB");
            a.Property(x => x.CreationDate).IsRequired();
            a.HasOne(x => x.ToSellCurrency).WithMany().HasForeignKey(x => x.ToSellCurrencyId);
            a.HasOne(x => x.ToBuyCurrency).WithMany().HasForeignKey(x => x.ToBuyCurrencyId);
        });
        base.OnModelCreating(modelBuilder);
    }
}
