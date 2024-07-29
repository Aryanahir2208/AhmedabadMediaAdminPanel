using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AhmedabadMediaAdminPanel_User.Entity.DataModels;

[Table("DashBoard")]
public partial class DashBoard
{
    [Key]
    [Column("DashBoardID")]
    public int DashBoardId { get; set; }

    public DateOnly Date { get; set; }

    [Column(TypeName = "character varying")]
    public string Tithi { get; set; } = null!;

    [Column(TypeName = "character varying")]
    public string Rashi { get; set; } = null!;

    [Column(TypeName = "character varying")]
    public string Rutu { get; set; } = null!;

    [Column(TypeName = "character varying")]
    public string? SpecialDay { get; set; }

    public bool BankStatus { get; set; }

    [Column(TypeName = "character varying")]
    public string? Festival { get; set; }

    public TimeOnly Sunrise { get; set; }

    public TimeOnly Sunset { get; set; }

    [Column(TypeName = "character varying")]
    public string? Description { get; set; }

    [Precision(8, 2)]
    public decimal GoldRate { get; set; }

    [Precision(8, 2)]
    public decimal SilverRate { get; set; }

    [Precision(8, 2)]
    public decimal PetrolRate { get; set; }

    [Precision(8, 2)]
    public decimal DieselRate { get; set; }

    [Column("CNGRate")]
    [Precision(8, 2)]
    public decimal Cngrate { get; set; }

    [Column("LPGRate")]
    [Precision(8, 2)]
    public decimal Lpgrate { get; set; }

    [Column(TypeName = "bit(1)")]
    public BitArray IsActive { get; set; } = null!;

    [Column(TypeName = "timestamp without time zone")]
    public DateTime Created { get; set; }

    public int CreatedBy { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime? Modified { get; set; }

    public int? ModifiedBy { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("DashBoardCreatedByNavigations")]
    public virtual AspNetUser CreatedByNavigation { get; set; } = null!;

    [ForeignKey("ModifiedBy")]
    [InverseProperty("DashBoardModifiedByNavigations")]
    public virtual AspNetUser? ModifiedByNavigation { get; set; }
}
