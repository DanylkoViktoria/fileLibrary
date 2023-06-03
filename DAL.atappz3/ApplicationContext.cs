using DAL;
using Microsoft.EntityFrameworkCore;

internal class ApplicationContext: DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options): base((DbContextOptions)options)
    {
        Database.EnsureCreated();
    }
    public DbSet<Source> Sources { get; set; }
    public DbSet<Storage> Storages { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Source>(entity => entity.HasOne(x => x.Storage).WithMany().HasForeignKey(x => x.StorageId).OnDelete(DeleteBehavior.Cascade));
    }
}
