using System;
using System.Collections.Generic;

#nullable disable

namespace ASHC.DATA.Models
{
    public partial class MCity
    {
        public MCity()
        {
            MServiceproviders = new HashSet<MServiceprovider>();
            MUserCcities = new HashSet<MUser>();
            MUserPcities = new HashSet<MUser>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int StateId { get; set; }
        public string Status { get; set; }

        public virtual ICollection<MServiceprovider> MServiceproviders { get; set; }
        public virtual ICollection<MUser> MUserCcities { get; set; }
        public virtual ICollection<MUser> MUserPcities { get; set; }
    }
}
