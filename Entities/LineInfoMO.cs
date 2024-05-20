namespace SMT.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LineInfoMO")]
    public partial class LineInfoMO
    {
        public long LineInfoMOId { get; set; }

        [StringLength(50)]
        public string LineCode { get; set; }

        [StringLength(50)]
        public string ModelCode { get; set; }

        public int? AmountTarget { get; set; }

        public int? AmountPrediction { get; set; } = 0;

        public int? AmountActual { get; set; } = 0;

        public DateTime? TimeStart { get; set; }

        public DateTime? CreateDate { get; set; }

        public int? CtrlStatus { get; set; } = 2;

        [StringLength(500)]
        public string Description { get; set; } = "";

        public int? ProgramId { get; set; } = 0;

        [StringLength(50)]
        public string ProductId { get; set; }

        public DateTime? UpdateTime { get; set; }

        public long? IdObjUpdate { get; set; } = 0;
        public string MaterialOrderId { get; set; }
    }
}
