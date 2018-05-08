namespace WeiCai.Entity
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class OAEntities : DbContext
    {
        public OAEntities()
            : base("name=MyDataContext")
        {
        }

        public virtual DbSet<userinfo> userinfoes { get; set; }
    }
}
