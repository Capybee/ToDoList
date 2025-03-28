﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ToDoListDev.Models;
using Task = ToDoListDev.Models.Task;

namespace ToDoListDev.Repository;

public partial class DbToDoListContext : DbContext
{
    public DbToDoListContext()
    {
    }

    public DbToDoListContext(DbContextOptions<DbToDoListContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Task> Tasks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("DataSource=E:\\\\Development\\\\ToDoList\\\\ToDoList\\\\ToDoListDev\\\\Repository\\\\db_to_do_list.db");

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
