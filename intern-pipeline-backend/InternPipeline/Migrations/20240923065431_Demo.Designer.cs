﻿// <auto-generated />
using System;
using InternPipeline.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InternPipeline.Migrations
{
    [DbContext(typeof(InternPipelineContext))]
    [Migration("20240923065431_Demo")]
    partial class Demo
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("InternPipeline.Models.Jd", b =>
                {
                    b.Property<int>("JdId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("jd_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("JdId"));

                    b.Property<string>("JdText")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("jd_text");

                    b.Property<string>("JdTitle")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("jd_title");

                    b.HasKey("JdId")
                        .HasName("PK__JD__36903D523DA0531D");

                    b.ToTable("JD", (string)null);
                });

            modelBuilder.Entity("InternPipeline.Models.Subject", b =>
                {
                    b.Property<int>("SubjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("subject_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubjectId"));

                    b.Property<string>("SubjectName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("subject_name");

                    b.Property<int?>("TaskId")
                        .HasColumnType("int")
                        .HasColumnName("task_id");

                    b.HasKey("SubjectId")
                        .HasName("PK__Subject__5004F660390E5C32");

                    b.HasIndex("TaskId");

                    b.ToTable("Subject", (string)null);
                });

            modelBuilder.Entity("InternPipeline.Models.Task", b =>
                {
                    b.Property<int>("TaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("task_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TaskId"));

                    b.Property<int?>("TaskDesc")
                        .HasColumnType("int")
                        .HasColumnName("task_desc");

                    b.Property<string>("TaskName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("task_name");

                    b.HasKey("TaskId")
                        .HasName("PK__Task__0492148D8E76A02C");

                    b.HasIndex("TaskDesc");

                    b.ToTable("Task", (string)null);
                });

            modelBuilder.Entity("InternPipeline.Models.Topic", b =>
                {
                    b.Property<int>("TopicId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("topic_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TopicId"));

                    b.Property<int?>("SubjectId")
                        .HasColumnType("int")
                        .HasColumnName("subject_id");

                    b.Property<string>("TopicName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("topic_name");

                    b.HasKey("TopicId")
                        .HasName("PK__Topic__D5DAA3E96AAD713E");

                    b.HasIndex("SubjectId");

                    b.ToTable("Topic", (string)null);
                });

            modelBuilder.Entity("InternPipeline.Models.Tst", b =>
                {
                    b.Property<string>("Test")
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .HasColumnName("test")
                        .IsFixedLength();

                    b.ToTable("tst", (string)null);
                });

            modelBuilder.Entity("InternPipeline.Models.Subject", b =>
                {
                    b.HasOne("InternPipeline.Models.Task", "Task")
                        .WithMany("Subjects")
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_Subject_Task");

                    b.Navigation("Task");
                });

            modelBuilder.Entity("InternPipeline.Models.Task", b =>
                {
                    b.HasOne("InternPipeline.Models.Jd", "TaskDescNavigation")
                        .WithMany("Tasks")
                        .HasForeignKey("TaskDesc")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_Task_JD");

                    b.Navigation("TaskDescNavigation");
                });

            modelBuilder.Entity("InternPipeline.Models.Topic", b =>
                {
                    b.HasOne("InternPipeline.Models.Subject", "Subject")
                        .WithMany("Topics")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_Topic_Subject");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("InternPipeline.Models.Jd", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("InternPipeline.Models.Subject", b =>
                {
                    b.Navigation("Topics");
                });

            modelBuilder.Entity("InternPipeline.Models.Task", b =>
                {
                    b.Navigation("Subjects");
                });
#pragma warning restore 612, 618
        }
    }
}
