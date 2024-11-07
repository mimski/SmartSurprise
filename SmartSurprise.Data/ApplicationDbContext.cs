using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmartSurprise.Data.Entities;

namespace SmartSurprise.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Gift> Gifts => Set<Gift>();

    public DbSet<Vote> Votes => Set<Vote>();

    public DbSet<VotingProcess> VotingProcesses => Set<VotingProcess>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<VotingProcess>()
            .HasOne(vp => vp.BirthdayPerson)
            .WithMany(u => u.BirthdayVotingProcesses)
            .HasForeignKey(vp => vp.BirthdayPersonId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<VotingProcess>()
            .HasOne(vp => vp.Initiator)
            .WithMany(u => u.InitiatedVotingProcesses)
            .HasForeignKey(vp => vp.InitiatorId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Vote>()
            .HasOne(v => v.VotingProcess)
            .WithMany(vp => vp.Votes)
            .HasForeignKey(v => v.VotingProcessId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Vote>()
            .HasOne(v => v.Voter)
            .WithMany(u => u.Votes)
            .HasForeignKey(v => v.VoterId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Vote>()
            .HasOne(v => v.Gift)
            .WithMany()
            .HasForeignKey(v => v.GiftId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Gift>().HasData(
        new Gift { Id = 1, Name = "Wireless Earbuds", Description = "Bluetooth earbuds with noise cancellation." },
        new Gift { Id = 2, Name = "Smart Watch", Description = "Fitness tracking smartwatch with heart rate monitor." },
        new Gift { Id = 3, Name = "Gift Card", Description = "A $100 gift card for online shopping." },
        new Gift { Id = 4, Name = "Coffee Maker", Description = "Automatic espresso machine with grinder." },
        new Gift { Id = 5, Name = "Bluetooth Speaker", Description = "Portable Bluetooth speaker with high-quality sound." },
        new Gift { Id = 6, Name = "VR Headset", Description = "Virtual reality headset for immersive gaming experiences." },
        new Gift { Id = 7, Name = "Smartphone", Description = "Latest model smartphone with 128GB storage." },
        new Gift { Id = 8, Name = "Laptop Bag", Description = "Stylish and functional laptop bag with padded compartments." },
        new Gift { Id = 9, Name = "Electric Toothbrush", Description = "Advanced electric toothbrush with multiple cleaning modes." },
        new Gift { Id = 10, Name = "Portable Power Bank", Description = "High-capacity power bank for charging devices on the go." },
        new Gift { Id = 11, Name = "Digital Camera", Description = "Compact digital camera with 4K video recording capabilities." },
        new Gift { Id = 12, Name = "Headphones", Description = "Over-ear headphones with active noise cancellation for a better listening experience." });
    }
}
