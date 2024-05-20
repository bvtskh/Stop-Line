namespace SMT.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MachineIOT")]
    public partial class MachineIOT
    {
        [Key]
        [StringLength(50)]
        public string MAC_ADDRESS { get; set; }

        [Required]
        [StringLength(50)]
        public string HOST_NAME { get; set; }

        [StringLength(50)]
        public string IP_ADDRESS { get; set; }

        [StringLength(50)]
        public string USER { get; set; }

        [StringLength(500)]
        public string LOCATION { get; set; }

        public DateTime? UPDATE_TIME { get; set; }

        public int SLEEP_TIME { get; set; }

        [StringLength(50)]
        public string VERSION { get; set; }

        [StringLength(50)]
        public string WINDOWS_EDITION { get; set; }

        public bool? IS_WINDOWS_ACTIVE { get; set; }

        public bool? IS_WINDOWS_64 { get; set; }
    }
}
