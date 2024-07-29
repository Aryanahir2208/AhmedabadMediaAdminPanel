using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AhmedabadMediaAdminPanel_User.Entity.DataModels;

public partial class EventsSuggestion
{
    [Key]
    [Column("EventsSuggestionsID")]
    public int EventsSuggestionsId { get; set; }

    public int? EventId { get; set; }

    public int Sequence { get; set; }

    [Column(TypeName = "character varying")]
    public string? Description { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime Created { get; set; }

    public int CreatedBy { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime? Modified { get; set; }

    public int? ModifiedBy { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("EventsSuggestionCreatedByNavigations")]
    public virtual AspNetUser CreatedByNavigation { get; set; } = null!;

    [ForeignKey("EventId")]
    [InverseProperty("EventsSuggestions")]
    public virtual Event? Event { get; set; }

    [ForeignKey("ModifiedBy")]
    [InverseProperty("EventsSuggestionModifiedByNavigations")]
    public virtual AspNetUser? ModifiedByNavigation { get; set; }
}
