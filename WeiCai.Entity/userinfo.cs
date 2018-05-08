namespace WeiCai.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("weicai.userinfo")]
    public partial class userinfo
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [StringLength(100)]
        public string UName { get; set; }

        [StringLength(500)]
        public string UPwd { get; set; }

        [StringLength(2000)]
        public string Remark { get; set; }

        [StringLength(2000)]
        public string Email { get; set; }

        [StringLength(2000)]
        public string Sort { get; set; }

        public int? DelFlag { get; set; }

        public DateTime? SubTime { get; set; }
    }
}
