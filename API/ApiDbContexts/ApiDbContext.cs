using Microsoft.EntityFrameworkCore;
using System;
using API.Models;

namespace API.Data
{
    public class ApplicationDbContext : DbContext
    {
        // DbSet pour chaque entité (table)
        public DbSet<User> Users { get; set; }
        public DbSet<Password> Passwords { get; set; }
        public DbSet<Vault> Vaults { get; set; }
        public DbSet<ConnectionLog> ConnectionLogs { get; set; }
        public DbSet<EncryptionKey> EncryptionKeys { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // Configuration des entités dans la base de données
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuration de l'entité User
            modelBuilder.Entity<User>()
                .HasKey(u => u.UserId);
                
            modelBuilder.Entity<User>()
                .Property(u => u.UserName)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(u => u.PasswordHash)
                .HasColumnType("VARBINARY(64)")
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(u => u.Salt)
                .HasColumnType("VARBINARY(32)")
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(u => u.CreatedAt)
                .HasDefaultValueSql("GETDATE()");

            // Configuration de l'entité Password
            modelBuilder.Entity<Password>()
                .HasKey(p => p.PasswordId);
            
            modelBuilder.Entity<Password>()
                .HasOne(p => p.User)
                .WithMany(u => u.Passwords)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Password>()
                .Property(p => p.EncryptedPassword)
                .IsRequired();

            modelBuilder.Entity<Password>()
                .Property(p => p.Salt)
                .IsRequired();

            // Configuration de l'entité Vault
            modelBuilder.Entity<Vault>()
                .HasKey(v => v.VaultId);
                
            modelBuilder.Entity<Vault>()
                .Property(v => v.VaultName)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Vault>()
                .HasOne(v => v.User)
                .WithMany(u => u.Vaults)
                .HasForeignKey(v => v.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configuration de l'entité ConnectionLog
            modelBuilder.Entity<ConnectionLog>()
                .HasKey(c => c.LogId);

            modelBuilder.Entity<ConnectionLog>()
                .Property(c => c.ConnectionDate)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<ConnectionLog>()
                .HasOne(c => c.User)
                .WithMany(u => u.ConnectionLogs)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configuration de l'entité EncryptionKey
            modelBuilder.Entity<EncryptionKey>()
                .HasKey(e => e.KeyId);

            modelBuilder.Entity<EncryptionKey>()
                .Property(e => e.EncryptedKey)
                .IsRequired();

            modelBuilder.Entity<EncryptionKey>()
                .Property(e => e.Salt)
                .IsRequired();

            // Configuration des relations
            // Par exemple, si vous avez des relations entre Vault et EncryptionKey, vous pouvez les définir ici

            // Configuration d'index unique ou autres contraintes si nécessaire
            modelBuilder.Entity<User>()
                .HasIndex(u => u.UserName)
                .IsUnique();

            modelBuilder.Entity<Password>()
                .HasIndex(p => p.PasswordId)
                .IsUnique();

            modelBuilder.Entity<Vault>()
                .HasIndex(v => v.VaultName)
                .IsUnique();
        }
    }
}
