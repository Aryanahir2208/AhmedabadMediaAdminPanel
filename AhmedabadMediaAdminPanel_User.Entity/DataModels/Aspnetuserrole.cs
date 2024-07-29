using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AhmedabadMediaAdminPanel_User.Entity.DataModels;

[Table("aspnetuserroles")]
public partial class Aspnetuserrole
{
    [Key]
    [Column("userid")]
    public int Userid { get; set; }

    [Column("roleid")]
    [StringLength(128)]
    public string Roleid { get; set; } = null!;

    [ForeignKey("Userid")]
    [InverseProperty("Aspnetuserrole")]
    public virtual AspNetUser User { get; set; } = null!;
}
