using AhmedabadMediaAdminPanel_User.Entity.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhmedabadMediaAdminPanel_User.Entity.Models
{
    public class UserDetails
    {
        public int? UserId { get; set; }
        public int AspNetUserId { get; set; }

        [Column(TypeName = "character varying")]
        [Required(ErrorMessage = "Please Enter First Name")]
        public string FirstName { get; set; } = null!;

        [Column(TypeName = "character varying")]
        public string? LastName { get; set; }

        [Column(TypeName = "character varying")]
        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Invalid email address")]
        public string? Email { get; set; } = null!;

        [Required(ErrorMessage = "Please Select Role")]
        [DisplayName("RoleId")]
        public int RoleId { get; set; }

        public short? Status { get; set; }

        [Column(TypeName = "timestamp without time zone")]
        [Required(ErrorMessage = "Birthdate is required")]
        public DateTime? BirthDate { get; set; }

        [Column(TypeName = "character varying")]
        public string? ContactNo { get; set; }

        [Column(TypeName = "character varying")]
        [Required(ErrorMessage = "Address is required")]
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

        public string? Rolename { get; set; }

    }
}
