using System;
using System.Collections.Generic;

#nullable disable

namespace ASHC.DATA.Models
{
    public partial class MState
    {
        public MState()
        {
            MServiceproviders = new HashSet<MServiceprovider>();
            MUserCstates = new HashSet<MUser>();
            MUserPstates = new HashSet<MUser>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        public string Status { get; set; }

        public virtual MCountry Country { get; set; }
        public virtual ICollection<MServiceprovider> MServiceproviders { get; set; }
        public virtual ICollection<MUser> MUserCstates { get; set; }
        public virtual ICollection<MUser> MUserPstates { get; set; }
    }
}
