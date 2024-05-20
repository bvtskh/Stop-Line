namespace SMT.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FeederAlarm")]
    public partial class FeederAlarm
    {
        [Key]
        [StringLength(50)]
        public string FEEDER_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string LINE_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string MACHINE_SETTING { get; set; }

        [Required]
        [StringLength(50)]
        public string MACHINE_ID { get; set; }

        public int MACHINE_SLOT { get; set; }

        [Column(TypeName = "date")]
        public DateTime EX_DATE { get; set; }

        public int STATE { get; set; }

        [Required]
        [StringLength(50)]
        public string ABOUT { get; set; }
    }
}
