﻿using LORHAPI_API.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LORHAPI_API.Data
{
    public class Db_Context : DbContext
    {
        public Db_Context(DbContextOptions<Db_Context> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Insertion> Insertions { get; set; }
<<<<<<< HEAD
        public DbSet<Organization> Organizations { get; set; }

=======
>>>>>>> 2faeddd (MAJ)

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Insertion>().ToTable("Insertion");
<<<<<<< HEAD
            modelBuilder.Entity<Organization>().ToTable("Organization");
=======
>>>>>>> 2faeddd (MAJ)
        }
    }
}
