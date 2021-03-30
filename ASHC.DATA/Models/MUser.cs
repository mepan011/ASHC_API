using System;
using System.Collections.Generic;

#nullable disable

namespace ASHC.DATA.Models
{
    public partial class MUser
    {
        public MUser()
        {
            MServiceproviders = new HashSet<MServiceprovider>();
            UserCardDetails = new HashSet<UserCardDetail>();
        }

        public int Id { get; set; }
        public int? UserTypeId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string AmobileNo { get; set; }
        public DateTime? Dob { get; set; }
        public string Gender { get; set; }
        public int? NationalityId { get; set; }
        public string Caddress { get; set; }
        public int? CcityId { get; set; }
        public int? CstateId { get; set; }
        public int? CcountryId { get; set; }
        public int? CzipCode { get; set; }
        public string Paddress { get; set; }
        public int? PcityId { get; set; }
        public int? PstateId { get; set; }
        public int? PcountryId { get; set; }
        public int? PzipCode { get; set; }
        public string GstNo { get; set; }
        public string UserImage { get; set; }
        public string SmsNotificationActive { get; set; }
        public string EmailNotificationActive { get; set; }
        public DateTime? LastLogin { get; set; }
        public int? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Status { get; set; }
        public string Remarks { get; set; }

        public virtual MCity Ccity { get; set; }
        public virtual MCountry Ccountry { get; set; }
        public virtual MState Cstate { get; set; }
        public virtual MNationality Nationality { get; set; }
        public virtual MCity Pcity { get; set; }
        public virtual MCountry Pcountry { get; set; }
        public virtual MState Pstate { get; set; }
        public virtual MUserType UserType { get; set; }
        public virtual ICollection<MServiceprovider> MServiceproviders { get; set; }
        public virtual ICollection<UserCardDetail> UserCardDetails { get; set; }
    }
}
