using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AhmedabadMediaAdminPanel_User.Entity.DataModels;

[Table("AspNetUser")]
public partial class AspNetUser
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column(TypeName = "character varying")]
    public string UserName { get; set; } = null!;

    [Column(TypeName = "character varying")]
    public string Password { get; set; } = null!;

    [Column(TypeName = "character varying")]
    public string? Email { get; set; }

    [Column(TypeName = "character varying")]
    public string? PhoneNumber { get; set; }

    [Column(TypeName = "character varying")]
    public string? Description { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime Created { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime? Modified { get; set; }

    [InverseProperty("User")]
    public virtual Aspnetuserrole? Aspnetuserrole { get; set; }

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<DashBoard> DashBoardCreatedByNavigations { get; set; } = new List<DashBoard>();

    [InverseProperty("ModifiedByNavigation")]
    public virtual ICollection<DashBoard> DashBoardModifiedByNavigations { get; set; } = new List<DashBoard>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<Event> EventCreatedByNavigations { get; set; } = new List<Event>();

    [InverseProperty("ModifiedByNavigation")]
    public virtual ICollection<Event> EventModifiedByNavigations { get; set; } = new List<Event>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<EventsAttachment> EventsAttachmentCreatedByNavigations { get; set; } = new List<EventsAttachment>();

    [InverseProperty("ModifiedByNavigation")]
    public virtual ICollection<EventsAttachment> EventsAttachmentModifiedByNavigations { get; set; } = new List<EventsAttachment>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<EventsSuggestion> EventsSuggestionCreatedByNavigations { get; set; } = new List<EventsSuggestion>();

    [InverseProperty("ModifiedByNavigation")]
    public virtual ICollection<EventsSuggestion> EventsSuggestionModifiedByNavigations { get; set; } = new List<EventsSuggestion>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<Job> JobCreatedByNavigations { get; set; } = new List<Job>();

    [InverseProperty("ModifiedByNavigation")]
    public virtual ICollection<Job> JobModifiedByNavigations { get; set; } = new List<Job>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<MetaSection> MetaSectionCreatedByNavigations { get; set; } = new List<MetaSection>();

    [InverseProperty("ModifiedByNavigation")]
    public virtual ICollection<MetaSection> MetaSectionModifiedByNavigations { get; set; } = new List<MetaSection>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<NewsAttachment> NewsAttachmentCreatedByNavigations { get; set; } = new List<NewsAttachment>();

    [InverseProperty("ModifiedByNavigation")]
    public virtual ICollection<NewsAttachment> NewsAttachmentModifiedByNavigations { get; set; } = new List<NewsAttachment>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<News> NewsCreatedByNavigations { get; set; } = new List<News>();

    [InverseProperty("ModifiedByNavigation")]
    public virtual ICollection<News> NewsModifiedByNavigations { get; set; } = new List<News>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<NewsSuggestion> NewsSuggestionCreatedByNavigations { get; set; } = new List<NewsSuggestion>();

    [InverseProperty("ModifiedByNavigation")]
    public virtual ICollection<NewsSuggestion> NewsSuggestionModifiedByNavigations { get; set; } = new List<NewsSuggestion>();
}
