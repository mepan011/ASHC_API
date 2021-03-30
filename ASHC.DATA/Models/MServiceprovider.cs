using System;
using System.Collections.Generic;

#nullable disable

namespace ASHC.DATA.Models
{
    public partial class MServiceprovider
    {
        public int Id { get; set; }
        public int? CategoryId { get; set; }
        public int? UserTypeId { get; set; }
        public int? UserId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal? Longitudes { get; set; }
        public decimal? Latitudes { get; set; }
        public int? CityId { get; set; }
        public int? StateId { get; set; }
        public int? CountryId { get; set; }
        public int? ZipCode { get; set; }
        public string MobileNo { get; set; }
        public string MobileNo2 { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public string RegistrationNo { get; set; }
        public string Gstno { get; set; }
        public string Vatno { get; set; }
        public string Dlno { get; set; }
        public string CoOrdinatorName { get; set; }
        public string CoOrdinatorContactNo { get; set; }
        public string CoOrdinatorEmail { get; set; }
        public string OwnerName { get; set; }
        public string OwnerContactNo { get; set; }
        public string OwnerEmail { get; set; }
        public string DirectorName { get; set; }
        public string DirectorContactNo { get; set; }
        public string DirectorEmail { get; set; }
        public int? EstablishmentYear { get; set; }
        public string HomeService { get; set; }
        public string EmergencyServices { get; set; }
        public string Notes { get; set; }
        public string HeaderMediaImage { get; set; }
        public string HeaderMediaImagePath { get; set; }
        public string HeaderMediaCarousel { get; set; }
        public string HeaderMediaCarouselPath { get; set; }
        public string HeaderMediaVideo { get; set; }
        public string HeaderMediaVideoPath { get; set; }
        public string WidgetsPromoVideo { get; set; }
        public string WidgetsPromoVideoPtah { get; set; }
        public string WidgetsGalleryThumbnails { get; set; }
        public string WidgetsGalleryThumbnailsPath { get; set; }
        public string WidgetsSlider { get; set; }
        public string WidgetsSliderPtah { get; set; }
        public string Videourl { get; set; }
        public string SidebarWidgetsBookingForm { get; set; }
        public string SidebarWidgetsEventCounter { get; set; }
        public DateTime? EventDate { get; set; }
        public string ServiceHours { get; set; }
        public string SocialsFaceBook { get; set; }
        public string SocialsTwitter { get; set; }
        public string SocialsWhatsApp { get; set; }
        public string SocialsInstagram { get; set; }
        public int? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string IpAddress { get; set; }
        public string Status { get; set; }
        public string Remarks { get; set; }

        public virtual MCategory Category { get; set; }
        public virtual MCity City { get; set; }
        public virtual MCountry Country { get; set; }
        public virtual MState State { get; set; }
        public virtual MUser User { get; set; }
        public virtual MUserType UserType { get; set; }
    }
}
