using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AhmedabadMediaAdminPanel_User.Entity.DataModels;

[Table("MetaSection")]
public partial class MetaSection
{
    [Key]
    [Column("MetaSectionID")]
    public int MetaSectionId { get; set; }

    [Column("NewsID")]
    public int? NewsId { get; set; }

    [Column("EventsID")]
    public int? EventsId { get; set; }

    [Column("JobsID")]
    public int? JobsId { get; set; }

    [Column(TypeName = "character varying")]
    public string Title { get; set; } = null!;

    [Column(TypeName = "character varying")]
    public string MetaDescription { get; set; } = null!;

    [Column(TypeName = "character varying")]
    public string Image { get; set; } = null!;

    [Column(TypeName = "character varying")]
    public string Keywords { get; set; } = null!;

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
    [InverseProperty("MetaSectionCreatedByNavigations")]
    public virtual AspNetUser CreatedByNavigation { get; set; } = null!;

    [ForeignKey("EventsId")]
    [InverseProperty("MetaSections")]
    public virtual Event? Events { get; set; }

    [ForeignKey("JobsId")]
    [InverseProperty("MetaSections")]
    public virtual Job? Jobs { get; set; }

    [ForeignKey("ModifiedBy")]
    [InverseProperty("MetaSectionModifiedByNavigations")]
    public virtual AspNetUser? ModifiedByNavigation { get; set; }

    [ForeignKey("NewsId")]
    [InverseProperty("MetaSections")]
    public virtual News? News { get; set; }
}
