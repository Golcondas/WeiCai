namespace WeiCai.Entity
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class OAEntities : DbContext
    {
        public OAEntities()
            : base("name=OAEntities")
        {
        }

        public virtual DbSet<userinfo> userinfoes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<userinfo>()
                .Property(e => e.UName)
                .IsUnicode(false);

            modelBuilder.Entity<userinfo>()
                .Property(e => e.UPwd)
                .IsUnicode(false);

            modelBuilder.Entity<userinfo>()
                .Property(e => e.Remark)
                .IsUnicode(false);

            modelBuilder.Entity<userinfo>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<userinfo>()
                .Property(e => e.Sort)
                .IsUnicode(false);
        }
    }
}
