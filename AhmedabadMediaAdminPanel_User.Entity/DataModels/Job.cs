using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AhmedabadMediaAdminPanel_User.Entity.DataModels;

public partial class Job
{
    [Key]
    [Column("JobID")]
    public int JobId { get; set; }

    [Column(TypeName = "character varying")]
    public string JobCode { get; set; } = null!;

    [Column(TypeName = "character varying")]
    public string Title { get; set; } = null!;

    [Column(TypeName = "character varying")]
    public string Company { get; set; } = null!;

    [Column(TypeName = "character varying")]
    public string? Avatar { get; set; }

    [Column(TypeName = "character varying")]
    public string Location { get; set; } = null!;

    [Column(TypeName = "character varying")]
    public string? JobDescription { get; set; }

    [Column(TypeName = "character varying")]
    public string Qualification { get; set; } = null!;

    public decimal Experience { get; set; }

    public int Vacancy { get; set; }

    [Column(TypeName = "character varying")]
    public string? Details { get; set; }

    [Column(TypeName = "character varying")]
    public string ContactNumber { get; set; } = null!;

    [Column(TypeName = "character varying")]
    public string Email { get; set; } = null!;

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
    [InverseProperty("JobCreatedByNavigations")]
    public virtual AspNetUser CreatedByNavigation { get; set; } = null!;

    [InverseProperty("Jobs")]
    public virtual ICollection<MetaSection> MetaSections { get; set; } = new List<MetaSection>();

    [ForeignKey("ModifiedBy")]
    [InverseProperty("JobModifiedByNavigations")]
    public virtual AspNetUser? ModifiedByNavigation { get; set; }
}
