﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Products.Models
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Product> Products { get; set; }

        public AppDbContext (DbContextOptions<AppDbContext> options) : base(options)
        {

        }


    }
}
