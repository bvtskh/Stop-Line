namespace SMT.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ConfigContext : DbContext
    {
        static string connection = "data source=172.28.10.17;initial catalog=SMT;persist security info=True;user id=sa;password=umc@2019;MultipleActiveResultSets=True;App=EntityFramework";
        public ConfigContext()
            : base(connection)
        {
        }

        public virtual DbSet<FeederAlarm> FeederAlarms { get; set; }
        public virtual DbSet<LineSetting> LineSettings { get; set; }
        public virtual DbSet<MachineIOT> MachineIOTs { get; set; }
        public virtual DbSet<Tokusai_Item> TokusaiItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
