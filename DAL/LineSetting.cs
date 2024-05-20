namespace SMT.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LineSetting")]
    public partial class LineSetting
    {
        [Key]
        [StringLength(4)]
        public string LINE_ID { get; set; }

        public bool IS_CHECK_RELOAD { get; set; }

        public bool IS_CHECK_FEEDER { get; set; }

        public bool IS_CONFIRM_TOKUSAI { get; set; }

        public int FEEDER_DAY_USE { get; set; }

        public DateTime UPDATE_TIME { get; set; }

        [Required]
        [StringLength(100)]
        public string UPDATER { get; set; }
        public bool IS_CHECK_VERIFY { get; set; }
    }
}
