using System;
using System.Collections.Generic;

#nullable disable

namespace ASHC.DATA.Models
{
    public partial class MCategoryType
    {
        public MCategoryType()
        {
            MCategories = new HashSet<MCategory>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Status { get; set; }
        public string Remarks { get; set; }

        public virtual ICollection<MCategory> MCategories { get; set; }
    }
}
