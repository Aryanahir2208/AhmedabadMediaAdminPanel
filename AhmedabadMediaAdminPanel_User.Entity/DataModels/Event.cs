using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AhmedabadMediaAdminPanel_User.Entity.DataModels;

public partial class Event
{
    [Key]
    [Column("EventID")]
    public int EventId { get; set; }

    [Column(TypeName = "character varying")]
    public string EventCode { get; set; } = null!;

    [Column(TypeName = "character varying")]
    public string? Thumbnail { get; set; }

    [Column(TypeName = "character varying")]
    public string? ThumbnailDescription { get; set; }

    [Column(TypeName = "character varying")]
    public string? EventDescription { get; set; }

    [Column(TypeName = "character varying")]
    public string Location { get; set; } = null!;

    public DateOnly Date { get; set; }

    public TimeOnly TimeFrom { get; set; }

    public TimeOnly TimeTo { get; set; }

    public bool IsFree { get; set; }

    [Column(TypeName = "character varying")]
    public string ContactNumber { get; set; } = null!;

    [Column(TypeName = "character varying")]
    public string TicketLink { get; set; } = null!;

    [Column(TypeName = "character varying")]
    public string? WhatsappNumber { get; set; }

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
    [InverseProperty("EventCreatedByNavigations")]
    public virtual AspNetUser CreatedByNavigation { get; set; } = null!;

    [InverseProperty("Event")]
    public virtual ICollection<EventsAttachment> EventsAttachments { get; set; } = new List<EventsAttachment>();

    [InverseProperty("Event")]
    public virtual ICollection<EventsSuggestion> EventsSuggestions { get; set; } = new List<EventsSuggestion>();

    [InverseProperty("Events")]
    public virtual ICollection<MetaSection> MetaSections { get; set; } = new List<MetaSection>();

    [ForeignKey("ModifiedBy")]
    [InverseProperty("EventModifiedByNavigations")]
    public virtual AspNetUser? ModifiedByNavigation { get; set; }
}
