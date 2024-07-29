using System;
using System.Collections.Generic;
using AhmedabadMediaAdminPanel_User.Entity.DataModels;
using Microsoft.EntityFrameworkCore;

namespace AhmedabadMediaAdminPanel_User.Entity.DataContext;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<Aspnetrole> Aspnetroles { get; set; }

    public virtual DbSet<Aspnetuserrole> Aspnetuserroles { get; set; }

    public virtual DbSet<DashBoard> DashBoards { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<EventsAttachment> EventsAttachments { get; set; }

    public virtual DbSet<EventsSuggestion> EventsSuggestions { get; set; }

    public virtual DbSet<Job> Jobs { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<MetaSection> MetaSections { get; set; }

    public virtual DbSet<News> News { get; set; }

    public virtual DbSet<NewsAttachment> NewsAttachments { get; set; }

    public virtual DbSet<NewsSuggestion> NewsSuggestions { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Rolemenu> Rolemenus { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("User ID = postgres;Password=Aryan22;Server=localhost;Port=5432;Database=AhmedabadMedia;Integrated Security=true;Pooling=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("AspNetUser_pkey");
        });

        modelBuilder.Entity<Aspnetrole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("aspnetroles_pkey");
        });

        modelBuilder.Entity<Aspnetuserrole>(entity =>
        {
            entity.HasKey(e => e.Userid).HasName("aspnetuserroles_pkey");

            entity.Property(e => e.Userid).ValueGeneratedNever();

            entity.HasOne(d => d.User).WithOne(p => p.Aspnetuserrole)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("aspnetuserroles_userid_fkey");
        });

        modelBuilder.Entity<DashBoard>(entity =>
        {
            entity.HasKey(e => e.DashBoardId).HasName("DashBoard_pkey");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.DashBoardCreatedByNavigations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("DashBoard_CreatedBy_fkey");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.DashBoardModifiedByNavigations).HasConstraintName("DashBoard_ModifiedBy_fkey");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.EventId).HasName("Events_pkey");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.EventCreatedByNavigations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Events_CreatedBy_fkey");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.EventModifiedByNavigations).HasConstraintName("Events_ModifiedBy_fkey");
        });

        modelBuilder.Entity<EventsAttachment>(entity =>
        {
            entity.HasKey(e => e.EventsAttachmentsId).HasName("EventsAttachments_pkey");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.EventsAttachmentCreatedByNavigations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("EventsAttachments_CreatedBy_fkey");

            entity.HasOne(d => d.Event).WithMany(p => p.EventsAttachments).HasConstraintName("EventsAttachments_EventId_fkey");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.EventsAttachmentModifiedByNavigations).HasConstraintName("EventsAttachments_ModifiedBy_fkey");
        });

        modelBuilder.Entity<EventsSuggestion>(entity =>
        {
            entity.HasKey(e => e.EventsSuggestionsId).HasName("EventsSuggestions_pkey");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.EventsSuggestionCreatedByNavigations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("EventsSuggestions_CreatedBy_fkey");

            entity.HasOne(d => d.Event).WithMany(p => p.EventsSuggestions).HasConstraintName("EventsSuggestions_EventId_fkey");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.EventsSuggestionModifiedByNavigations).HasConstraintName("EventsSuggestions_ModifiedBy_fkey");
        });

        modelBuilder.Entity<Job>(entity =>
        {
            entity.HasKey(e => e.JobId).HasName("Jobs_pkey");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.JobCreatedByNavigations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Jobs_CreatedBy_fkey");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.JobModifiedByNavigations).HasConstraintName("Jobs_ModifiedBy_fkey");
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.Menuid).HasName("menu_pkey");
        });

        modelBuilder.Entity<MetaSection>(entity =>
        {
            entity.HasKey(e => e.MetaSectionId).HasName("MetaSection_pkey");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.MetaSectionCreatedByNavigations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("MetaSection_CreatedBy_fkey");

            entity.HasOne(d => d.Events).WithMany(p => p.MetaSections).HasConstraintName("MetaSection_EventsID_fkey");

            entity.HasOne(d => d.Jobs).WithMany(p => p.MetaSections).HasConstraintName("MetaSection_JobsID_fkey");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.MetaSectionModifiedByNavigations).HasConstraintName("MetaSection_ModifiedBy_fkey");

            entity.HasOne(d => d.News).WithMany(p => p.MetaSections).HasConstraintName("MetaSection_NewsID_fkey");
        });

        modelBuilder.Entity<News>(entity =>
        {
            entity.HasKey(e => e.NewsId).HasName("News_pkey");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.NewsCreatedByNavigations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("News_CreatedBy_fkey");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.NewsModifiedByNavigations).HasConstraintName("News_ModifiedBy_fkey");
        });

        modelBuilder.Entity<NewsAttachment>(entity =>
        {
            entity.HasKey(e => e.NewsAttachmentsId).HasName("NewsAttachments_pkey");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.NewsAttachmentCreatedByNavigations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("NewsAttachments_CreatedBy_fkey");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.NewsAttachmentModifiedByNavigations).HasConstraintName("NewsAttachments_ModifiedBy_fkey");

            entity.HasOne(d => d.News).WithMany(p => p.NewsAttachments).HasConstraintName("NewsAttachments_NewsId_fkey");
        });

        modelBuilder.Entity<NewsSuggestion>(entity =>
        {
            entity.HasKey(e => e.NewsSuggestionsId).HasName("NewsSuggestions_pkey");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.NewsSuggestionCreatedByNavigations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("NewsSuggestions_CreatedBy_fkey");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.NewsSuggestionModifiedByNavigations).HasConstraintName("NewsSuggestions_ModifiedBy_fkey");

            entity.HasOne(d => d.News).WithMany(p => p.NewsSuggestions).HasConstraintName("NewsSuggestions_NewsId_fkey");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Roleid).HasName("role_pkey");
        });

        modelBuilder.Entity<Rolemenu>(entity =>
        {
            entity.HasKey(e => e.Rolemenuid).HasName("rolemenu_pkey");

            entity.HasOne(d => d.Menu).WithMany(p => p.Rolemenus)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("rolemenu_menuid_fkey");

            entity.HasOne(d => d.Role).WithMany(p => p.Rolemenus)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("rolemenu_roleid_fkey");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("User_pkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
