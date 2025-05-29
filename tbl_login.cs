namespace EmployeeCertification_withoutMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Web;

    public partial class tbl_login
    {
        public int id { get; set; }
        [Required(ErrorMessage = "User name is required")]
        [StringLength(100)]

        public string uname { get; set; }
        [Required(ErrorMessage ="Password is required")]
        [StringLength(100)]

        public string pwd { get; set; }

    }
}
