using System;
using System.Collections.Generic;

#nullable disable

namespace ASHC.DATA.Models
{
    public partial class MCategory
    {
        public MCategory()
        {
            MServiceproviders = new HashSet<MServiceprovider>();
        }

        public int Id { get; set; }
        public int? CategoryTypeId { get; set; }
        public string Name { get; set; }
        public int? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Status { get; set; }
        public string Remarks { get; set; }

        public virtual MCategoryType CategoryType { get; set; }
        public virtual ICollection<MServiceprovider> MServiceproviders { get; set; }
    }
}
