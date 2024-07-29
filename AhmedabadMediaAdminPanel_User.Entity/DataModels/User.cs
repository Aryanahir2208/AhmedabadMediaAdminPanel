using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AhmedabadMediaAdminPanel_User.Entity.DataModels;

[Table("User")]
public partial class User
{
    [Key]
    public int UserId { get; set; }

    public int AspNetUserId { get; set; }

    [Column(TypeName = "character varying")]
    public string FirstName { get; set; } = null!;

    [Column(TypeName = "character varying")]
    public string? LastName { get; set; }

    [Column(TypeName = "character varying")]
    public string Email { get; set; } = null!;

    public int RoleId { get; set; }

    public short? Status { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime? BirthDate { get; set; }

    [Column(TypeName = "character varying")]
    public string? ContactNo { get; set; }

    [Column(TypeName = "character varying")]
    public string? Address { get; set; }

    [Column(TypeName = "character varying")]
    public string? City { get; set; }

    [Column(TypeName = "character varying")]
    public string? State { get; set; }

    [Column(TypeName = "character varying")]
    public string? Description { get; set; }

    public int CreatedBy { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime? ModifiedDate { get; set; }
}
