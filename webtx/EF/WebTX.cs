namespace webtx.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class WebTX : DbContext
    {
        public WebTX()
            : base("name=WebTX2")
        {
        }

        public virtual DbSet<boxchat> boxchats { get; set; }
        public virtual DbSet<user> users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<boxchat>()
                .Property(e => e.status)
                .IsFixedLength();

            modelBuilder.Entity<user>()
                .Property(e => e.phone)
                .IsFixedLength();
        }
    }
}
