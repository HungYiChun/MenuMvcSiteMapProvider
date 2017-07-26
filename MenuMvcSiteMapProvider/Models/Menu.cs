namespace MenuMvcSiteMapProvider.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Menu")]
    public partial class Menu
    {
        public int Id { get; set; }

        [Required]
        [StringLength(128)]
        public string MenuName { get; set; }

        [StringLength(128)]
        public string Area { get; set; }

        [StringLength(128)]
        public string Controller { get; set; }

        [StringLength(128)]
        public string Action { get; set; }

        [StringLength(128)]
        public string Url { get; set; }

        public int? ParentMenuId { get; set; }

        public int? State { get; set; }

        [StringLength(128)]
        public string RouteValues { get; set; }

        public int? OrderSerial { get; set; }

        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }
    }
}
