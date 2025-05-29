namespace EmployeeCertification_withoutMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_employee
    {
        public int id { get; set; }

        [StringLength(1000)]
        public string emp_name { get; set; }

        public int? age { get; set; }

        [StringLength(100)]

        public string emp_id { get; set; }

        public string designation { get; set; }


        public string certification { get; set; }


    }
}
