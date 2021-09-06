namespace webtx.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("user")]
    public partial class user
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public user()
        {
            boxchats = new HashSet<boxchat>();
        }

        [Key]
        public long iduser { get; set; }

        [StringLength(50)]
        public string username { get; set; }

        [StringLength(50)]
        public string password { get; set; }

        public string avatar { get; set; }

        public long? xu { get; set; }

        public DateTime? createddate { get; set; }

        [StringLength(50)]
        public string gmail { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        [StringLength(10)]
        public string phone { get; set; }

        public int? status { get; set; }

        [StringLength(50)]
        public string credential { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<boxchat> boxchats { get; set; }
    }
}
