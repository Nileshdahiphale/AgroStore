﻿using AgroStore.Services.ShoppingCartAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AgroStore.Services.ShoppingCartAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<CartHeader> CartHeaders { get; set; }
        public DbSet<CartDetails> CartDetails { get; set; }
     
    }
}
