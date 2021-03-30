using System;
using System.Collections.Generic;

#nullable disable

namespace ASHC.DATA.Models
{
    public partial class SurveyDetail
    {
        public int Id { get; set; }
        public string MedicalStore { get; set; }
        public string Pathology { get; set; }
        public string DiagnosticCentre { get; set; }
        public string Rmp { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string RegNo { get; set; }
        public int? EstablishmentYear { get; set; }
        public string OwnerName { get; set; }
        public string OwnerContactNo { get; set; }
        public string OwnerMail { get; set; }
        public string ServiceTiming { get; set; }
        public string HomeDeliveryService { get; set; }
        public string HomeServices { get; set; }
        public string AreYouWantToBeOnDigitalPlatform { get; set; }
        public int? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string IpAddress { get; set; }
        public string Status { get; set; }
        public string Remarks { get; set; }
    }
}
