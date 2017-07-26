namespace MenuMvcSiteMapProvider.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Account")]
    public partial class Account
    {
        public int Id { get; set; }

        [Required]
        [StringLength(128)]
        public string Username { get; set; }

        [Required]
        [StringLength(128)]
        public string Password { get; set; }

        [Required]
        [StringLength(128)]
        public string Role { get; set; }
    }
}
