using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WalletAPI.Models;

namespace WalletAPI.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }

        public DbSet <Wallet> Wallets {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Wallet>()
            .HasData(new Wallet[]
            {
                new Wallet{Id= 1,Holder="NATIQ",Balance=3000},
                new Wallet{Id= 2,Holder="TAREQ",Balance=4000},
                new Wallet{ Id= 3,Holder="SARMED",Balance=1000}
            });
        }
    }
}