using System;
using System.Collections.Generic;

#nullable disable

namespace ASHC.DATA.Models
{
    public partial class UserCardDetail
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string CardHoldeName { get; set; }
        public string CardNumber { get; set; }
        public DateTime? CardValidityYear { get; set; }
        public DateTime? CardIssueDate { get; set; }
        public int? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string IpAddress { get; set; }
        public string Status { get; set; }
        public string Remarks { get; set; }

        public virtual MUser User { get; set; }
    }
}
