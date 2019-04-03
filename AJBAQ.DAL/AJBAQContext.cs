using System;
using AJBAQ.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AJBAQ.DAL
{
    public partial class AJBAQContext : DbContext
    {
        public AJBAQContext()
        {
        }

        public AJBAQContext(DbContextOptions<AJBAQContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Answer> Answer { get; set; }
        public virtual DbSet<Choice> Choice { get; set; }
        public virtual DbSet<Question> Question { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:pownstars.database.windows.net,1433;Initial Catalog=AJBAQ;Persist Security Info=False;User ID=pownstars;Password=?SEoKS^tB?pIt9pr;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Answer>(entity =>
            {
                entity.Property(e => e.AnswerId)
                    .HasColumnName("answer_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AnswerTime)
                    .HasColumnName("answer_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.ChoiceId).HasColumnName("choice_id");

                entity.Property(e => e.QuestionId).HasColumnName("question_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Choice)
                    .WithMany(p => p.Answer)
                    .HasForeignKey(d => d.ChoiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Answer_Choice");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.Answer)
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Answer_Question");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Answer)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Answer_User");
            });

            modelBuilder.Entity<Choice>(entity =>
            {
                entity.Property(e => e.ChoiceId).HasColumnName("choice_id");

                entity.Property(e => e.Body)
                    .IsRequired()
                    .HasColumnName("body")
                    .IsUnicode(false);

                entity.Property(e => e.IsRightChoice).HasColumnName("is_right_choice");

                entity.Property(e => e.QuestionId).HasColumnName("question_id");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.Choice)
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Choice_Question");
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.Property(e => e.QuestionId).HasColumnName("question_id");

                entity.Property(e => e.Body)
                    .IsRequired()
                    .HasColumnName("body")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .IsUnicode(false);

                entity.Property(e => e.Userpass)
                    .IsRequired()
                    .HasColumnName("userpass")
                    .IsUnicode(false);
            });
        }
    }
}
