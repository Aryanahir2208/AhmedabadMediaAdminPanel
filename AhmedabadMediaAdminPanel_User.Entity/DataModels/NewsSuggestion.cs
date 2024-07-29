using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AhmedabadMediaAdminPanel_User.Entity.DataModels;

public partial class NewsSuggestion
{
    [Key]
    [Column("NewsSuggestionsID")]
    public int NewsSuggestionsId { get; set; }

    public int? NewsId { get; set; }

    public int? Sequence { get; set; }

    [Column(TypeName = "character varying")]
    public string? Description { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime Created { get; set; }

    public int CreatedBy { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime? Modified { get; set; }

    public int? ModifiedBy { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("NewsSuggestionCreatedByNavigations")]
    public virtual AspNetUser CreatedByNavigation { get; set; } = null!;

    [ForeignKey("ModifiedBy")]
    [InverseProperty("NewsSuggestionModifiedByNavigations")]
    public virtual AspNetUser? ModifiedByNavigation { get; set; }

    [ForeignKey("NewsId")]
    [InverseProperty("NewsSuggestions")]
    public virtual News? News { get; set; }
}
