using System;
using System.ComponentModel.DataAnnotations;

namespace SMT.DAL
{
    public partial class tb_Feeder
    {
        [Key]
        [StringLength(50)]
        public string FeederNo { get; set; }

        [StringLength(150)]
        public string FeederName { get; set; }

        [StringLength(50)]
        public string Vendor { get; set; }

        [StringLength(50)]
        public string Size { get; set; }

        public DateTime DatePlan { get; set; }

        [StringLength(150)]
        public string Status_TT { get; set; }

        [StringLength(500)]
        public string Remark { get; set; }

        public int? Maxdayuse { get; set; }
    }
}
