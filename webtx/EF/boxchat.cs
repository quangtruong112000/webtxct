namespace webtx.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("boxchat")]
    public partial class boxchat
    {
        [Key]
        public long idmess { get; set; }

        public long? iduser { get; set; }

        public string noidung { get; set; }

        public DateTime? createddate { get; set; }

        [StringLength(10)]
        public string status { get; set; }

        public virtual user user { get; set; }
    }
}
