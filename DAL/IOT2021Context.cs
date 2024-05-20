namespace SMT.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class IOT2021Context : DbContext
    {
        static string connection = "data source=172.28.6.96;initial catalog=IOT2021;user id=sa;password=umc@123;MultipleActiveResultSets=True;App=EntityFramework";
        public IOT2021Context()
            : base(connection)
        {
        }

        public virtual DbSet<PDAInfo_Ver2> PDAInfo_Ver2 { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PDAInfo_Ver2>()
                .Property(e => e.Line)
                .IsUnicode(false);

            modelBuilder.Entity<PDAInfo_Ver2>()
                .Property(e => e.Model)
                .IsUnicode(false);

            modelBuilder.Entity<PDAInfo_Ver2>()
                .Property(e => e.WO)
                .IsUnicode(false);

            modelBuilder.Entity<PDAInfo_Ver2>()
                .Property(e => e.MaterialOrderId)
                .IsUnicode(false);

            modelBuilder.Entity<PDAInfo_Ver2>()
                .Property(e => e.CodePatternPrint)
                .IsUnicode(false);
        }
    }
}
