using System;
using System.Collections.Generic;

#nullable disable

namespace ASHC.DATA.Models
{
    public partial class MCountry
    {
        public MCountry()
        {
            MServiceproviders = new HashSet<MServiceprovider>();
            MStates = new HashSet<MState>();
            MUserCcountries = new HashSet<MUser>();
            MUserPcountries = new HashSet<MUser>();
        }

        public int Id { get; set; }
        public string Sortname { get; set; }
        public string Name { get; set; }
        public int Phonecode { get; set; }
        public string Status { get; set; }

        public virtual ICollection<MServiceprovider> MServiceproviders { get; set; }
        public virtual ICollection<MState> MStates { get; set; }
        public virtual ICollection<MUser> MUserCcountries { get; set; }
        public virtual ICollection<MUser> MUserPcountries { get; set; }
    }
}
