using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AhmedabadMediaAdminPanel_User.Entity.DataModels;

public partial class NewsAttachment
{
    [Key]
    [Column("NewsAttachmentsID")]
    public int NewsAttachmentsId { get; set; }

    public int? NewsId { get; set; }

    [Column(TypeName = "character varying")]
    public string? Name { get; set; }

    [Column(TypeName = "character varying")]
    public string? Image { get; set; }

    [Column(TypeName = "character varying")]
    public string? ImageDescription { get; set; }

    [Column(TypeName = "character varying")]
    public string? Description { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime Created { get; set; }

    public int CreatedBy { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime? Modified { get; set; }

    public int? ModifiedBy { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("NewsAttachmentCreatedByNavigations")]
    public virtual AspNetUser CreatedByNavigation { get; set; } = null!;

    [ForeignKey("ModifiedBy")]
    [InverseProperty("NewsAttachmentModifiedByNavigations")]
    public virtual AspNetUser? ModifiedByNavigation { get; set; }

    [ForeignKey("NewsId")]
    [InverseProperty("NewsAttachments")]
    public virtual News? News { get; set; }
}
