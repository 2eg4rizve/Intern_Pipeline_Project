using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace InternPipeline.Models;

public partial class InternPipelineContext : DbContext
{
    private readonly IConfiguration _configuration;
    public InternPipelineContext()
    {
    }

    public InternPipelineContext(DbContextOptions<InternPipelineContext> options, IConfiguration configuration)
        : base(options)
    {
        _configuration = configuration;
    }

    public virtual DbSet<Jd> Jds { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<Task> Tasks { get; set; }

    public virtual DbSet<Topic> Topics { get; set; }

    public virtual DbSet<Tst> Tsts { get; set; }


    public virtual DbSet<BlogModel> BlogTable { get; set; }
    

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            string? connectionString = _configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Jd>(entity =>
        {
            entity.HasKey(e => e.JdId).HasName("PK__JD__36903D523DA0531D");

            entity.ToTable("JD");

            entity.Property(e => e.JdId).HasColumnName("jd_id");
            entity.Property(e => e.JdText)
                .HasMaxLength(200)
                .HasColumnName("jd_text");
            entity.Property(e => e.JdTitle)
                .HasMaxLength(100)
                .HasColumnName("jd_title");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.SubjectId).HasName("PK__Subject__5004F660390E5C32");

            entity.ToTable("Subject");

            entity.Property(e => e.SubjectId).HasColumnName("subject_id");
            entity.Property(e => e.SubjectName)
                .HasMaxLength(100)
                .HasColumnName("subject_name");
            entity.Property(e => e.TaskId).HasColumnName("task_id");

            entity.HasOne(d => d.Task).WithMany(p => p.Subjects)
                .HasForeignKey(d => d.TaskId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Subject_Task");
        });

        modelBuilder.Entity<Task>(entity =>
        {
            entity.HasKey(e => e.TaskId).HasName("PK__Task__0492148D8E76A02C");

            entity.ToTable("Task");

            entity.Property(e => e.TaskId).HasColumnName("task_id");
            entity.Property(e => e.TaskDesc).HasColumnName("task_desc");
            entity.Property(e => e.TaskName)
                .HasMaxLength(100)
                .HasColumnName("task_name");

            entity.HasOne(d => d.TaskDescNavigation).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.TaskDesc)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Task_JD");
        });

        //modelBuilder.Entity<Topic>(entity =>
        //{
        //    entity.HasKey(e => e.TopicId).HasName("PK__Topic__D5DAA3E96AAD713E");

        //    entity.ToTable("Topic");

        //    entity.Property(e => e.TopicId).HasColumnName("topic_id");
        //    entity.Property(e => e.SubjectId).HasColumnName("subject_id");
        //    entity.Property(e => e.TopicName)
        //        .HasMaxLength(100)
        //        .HasColumnName("topic_name");

        //    entity.HasOne(d => d.Subject).WithMany(p => p.Topics)
        //        .HasForeignKey(d => d.SubjectId)
        //        .OnDelete(DeleteBehavior.Cascade)
        //        .HasConstraintName("FK_Topic_Subject");
        //});

        modelBuilder.Entity<Tst>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tst");

            entity.Property(e => e.Test)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("test");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
