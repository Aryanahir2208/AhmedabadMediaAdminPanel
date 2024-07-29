using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AhmedabadMediaAdminPanel_User.Entity.DataModels;

public partial class News
{
    [Key]
    [Column("NewsID")]
    public int NewsId { get; set; }

    [Column(TypeName = "character varying")]
    public string? ShortDescription { get; set; }

    [Column(TypeName = "character varying")]
    public string? NewsDescription { get; set; }

    public DateOnly? ScheduleDate { get; set; }

    public TimeOnly? ScheduleTime { get; set; }

    public bool IsActive { get; set; }

    [Column(TypeName = "character varying")]
    public string? Description { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime Created { get; set; }

    public int CreatedBy { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime? Modified { get; set; }

    public int? ModifiedBy { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("NewsCreatedByNavigations")]
    public virtual AspNetUser CreatedByNavigation { get; set; } = null!;

    [InverseProperty("News")]
    public virtual ICollection<MetaSection> MetaSections { get; set; } = new List<MetaSection>();

    [ForeignKey("ModifiedBy")]
    [InverseProperty("NewsModifiedByNavigations")]
    public virtual AspNetUser? ModifiedByNavigation { get; set; }

    [InverseProperty("News")]
    public virtual ICollection<NewsAttachment> NewsAttachments { get; set; } = new List<NewsAttachment>();

    [InverseProperty("News")]
    public virtual ICollection<NewsSuggestion> NewsSuggestions { get; set; } = new List<NewsSuggestion>();
}
