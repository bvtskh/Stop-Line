namespace SMT.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public  class PDAInfo_Ver2
    {
        public long Id { get; set; }

        [StringLength(5)]
        public string Line { get; set; }

        [StringLength(20)]
        public string Model { get; set; }

        [StringLength(15)]
        public string WO { get; set; }

        public int? PlanWO { get; set; }

        public DateTime? TimePDA { get; set; }

        [StringLength(100)]
        public string MaterialOrderId { get; set; }

        [StringLength(50)]
        public string CodePatternPrint { get; set; }

        [StringLength(50)]
        public string MaThanhQuet { get; set; }
    }
}
