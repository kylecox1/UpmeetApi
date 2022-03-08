using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UpmeetApi.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [StringLength(50)]
        [Display(Name = "User Name")]
        public string UserName { get; set; }
    }
}
