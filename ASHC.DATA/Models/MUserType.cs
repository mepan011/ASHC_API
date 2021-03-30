using System;
using System.Collections.Generic;

#nullable disable

namespace ASHC.DATA.Models
{
    public partial class MUserType
    {
        public MUserType()
        {
            MServiceproviders = new HashSet<MServiceprovider>();
            MUsers = new HashSet<MUser>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Status { get; set; }
        public string Remarks { get; set; }

        public virtual ICollection<MServiceprovider> MServiceproviders { get; set; }
        public virtual ICollection<MUser> MUsers { get; set; }
    }
}
