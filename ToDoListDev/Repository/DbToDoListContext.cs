using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ToDoListDev.Models;
using Task = ToDoListDev.Models.Task;

namespace ToDoListDev.Repository;

public partial class DbToDoListContext : DbContext
{
    public DbToDoListContext()
    {
        Database.EnsureCreated();
    }

    public DbToDoListContext(DbContextOptions<DbToDoListContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Task> Tasks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        optionsBuilder.UseSqlite("DataSource=db_to_do_list.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Task>(entity =>
        {
            entity.ToTable("Task");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
