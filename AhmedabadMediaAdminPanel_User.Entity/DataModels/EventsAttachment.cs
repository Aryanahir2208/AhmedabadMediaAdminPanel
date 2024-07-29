using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AhmedabadMediaAdminPanel_User.Entity.DataModels;

public partial class EventsAttachment
{
    [Key]
    [Column("EventsAttachmentsID")]
    public int EventsAttachmentsId { get; set; }

    public int? EventId { get; set; }

    [Column(TypeName = "character varying")]
    public string ArtistName { get; set; } = null!;

    [Column(TypeName = "character varying")]
    public string? ArtistImage { get; set; }

    [Column(TypeName = "character varying")]
    public string? Description { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime Created { get; set; }

    public int CreatedBy { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime? Modified { get; set; }

    public int? ModifiedBy { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("EventsAttachmentCreatedByNavigations")]
    public virtual AspNetUser CreatedByNavigation { get; set; } = null!;

    [ForeignKey("EventId")]
    [InverseProperty("EventsAttachments")]
    public virtual Event? Event { get; set; }

    [ForeignKey("ModifiedBy")]
    [InverseProperty("EventsAttachmentModifiedByNavigations")]
    public virtual AspNetUser? ModifiedByNavigation { get; set; }
}
