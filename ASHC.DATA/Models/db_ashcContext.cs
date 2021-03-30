using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ASHC.DATA.Models
{
    public partial class db_ashcContext : DbContext
    {
        public db_ashcContext()
        {
        }

        public db_ashcContext(DbContextOptions<db_ashcContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Exception> Exceptions { get; set; }
        public virtual DbSet<MCategory> MCategories { get; set; }
        public virtual DbSet<MCategoryType> MCategoryTypes { get; set; }
        public virtual DbSet<MCity> MCities { get; set; }
        public virtual DbSet<MCountry> MCountries { get; set; }
        public virtual DbSet<MNationality> MNationalities { get; set; }
        public virtual DbSet<MServiceprovider> MServiceproviders { get; set; }
        public virtual DbSet<MState> MStates { get; set; }
        public virtual DbSet<MUser> MUsers { get; set; }
        public virtual DbSet<MUserType> MUserTypes { get; set; }
        public virtual DbSet<SurveyDetail> SurveyDetails { get; set; }
        public virtual DbSet<UserCardDetail> UserCardDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                // optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=db_ashc;Trusted_Connection=True;Integrated     Security=True;MultipleActiveResultSets=True;");
                optionsBuilder.UseSqlServer("Server=103.21.58.78;Database=pankaj11;User Id=pankaj11;password=#iv6yP10;Trusted_Connection=False;MultipleActiveResultSets=true");
            }
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{

        //    optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=MYDB;Integrated     Security=True;MultipleActiveResultSets=True;");

        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Exception>(entity =>
            {
                entity.ToTable("exception");

                entity.Property(e => e.ExDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Ex_date");

                entity.Property(e => e.ExDesc)
                    .HasMaxLength(1024)
                    .IsUnicode(false)
                    .HasColumnName("Ex_Desc");

                entity.Property(e => e.ExSource)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Ex_source");

                entity.Property(e => e.FromStatement)
                    .HasMaxLength(1024)
                    .IsUnicode(false)
                    .HasColumnName("From_Statement");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<MCategory>(entity =>
            {
                entity.ToTable("m_Category");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Remarks)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.CategoryType)
                    .WithMany(p => p.MCategories)
                    .HasForeignKey(d => d.CategoryTypeId)
                    .HasConstraintName("FK__m_Categor__Categ__7C4F7684");
            });

            modelBuilder.Entity<MCategoryType>(entity =>
            {
                entity.ToTable("m_CategoryType");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Remarks)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<MCity>(entity =>
            {
                entity.ToTable("m_city");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.StateId).HasColumnName("state_id");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("status")
                    .HasDefaultValueSql("('A')")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<MCountry>(entity =>
            {
                entity.ToTable("m_country");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Phonecode).HasColumnName("phonecode");

                entity.Property(e => e.Sortname)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("sortname");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('A')")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<MNationality>(entity =>
            {
                entity.ToTable("m_Nationality");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Remarks)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<MServiceprovider>(entity =>
            {
                entity.ToTable("m_Serviceprovider");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CoOrdinatorContactNo)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CoOrdinatorEmail)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CoOrdinatorName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DirectorContactNo)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DirectorEmail)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DirectorName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Dlno)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EmergencyServices)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.EventDate).HasColumnType("datetime");

                entity.Property(e => e.Gstno)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.HeaderMediaCarousel)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.HeaderMediaCarouselPath)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.HeaderMediaImage)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.HeaderMediaImagePath)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.HeaderMediaVideo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.HeaderMediaVideoPath)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.HomeService)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.IpAddress)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Latitudes)
                    .HasColumnType("decimal(8, 6)")
                    .HasColumnName("latitudes");

                entity.Property(e => e.Longitudes)
                    .HasColumnType("decimal(9, 6)")
                    .HasColumnName("longitudes");

                entity.Property(e => e.MobileNo)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MobileNo2)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Notes)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.OwnerContactNo)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.OwnerEmail)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.OwnerName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNo)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RegistrationNo)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Remarks)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ServiceHours)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SidebarWidgetsBookingForm)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SidebarWidgetsEventCounter)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SocialsFaceBook)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SocialsInstagram)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SocialsTwitter)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SocialsWhatsApp)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.Vatno)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Videourl)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.WidgetsGalleryThumbnails)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.WidgetsGalleryThumbnailsPath)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.WidgetsPromoVideo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.WidgetsPromoVideoPtah)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.WidgetsSlider)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.WidgetsSliderPtah)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.MServiceproviders)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__m_Service__Categ__7D439ABD");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.MServiceproviders)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK__m_Service__CityI__7E37BEF6");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.MServiceproviders)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK__m_Service__Count__7F2BE32F");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.MServiceproviders)
                    .HasForeignKey(d => d.StateId)
                    .HasConstraintName("FK__m_Service__State__00200768");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.MServiceproviders)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__m_Service__UserI__01142BA1");

                entity.HasOne(d => d.UserType)
                    .WithMany(p => p.MServiceproviders)
                    .HasForeignKey(d => d.UserTypeId)
                    .HasConstraintName("FK__m_Service__UserT__02084FDA");
            });

            modelBuilder.Entity<MState>(entity =>
            {
                entity.ToTable("m_state");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CountryId)
                    .HasColumnName("country_id")
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('A')")
                    .IsFixedLength(true);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.MStates)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_m_state_m_country");
            });

            modelBuilder.Entity<MUser>(entity =>
            {
                entity.ToTable("m_user");

                entity.Property(e => e.AmobileNo)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Caddress)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Dob).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EmailNotificationActive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.GstNo)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.LastLogin).HasColumnType("datetime");

                entity.Property(e => e.LastName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MobileNo)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Paddress)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Remarks)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SmsNotificationActive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.UserImage)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Ccity)
                    .WithMany(p => p.MUserCcities)
                    .HasForeignKey(d => d.CcityId)
                    .HasConstraintName("FK__m_user__CcityId__03F0984C");

                entity.HasOne(d => d.Ccountry)
                    .WithMany(p => p.MUserCcountries)
                    .HasForeignKey(d => d.CcountryId)
                    .HasConstraintName("FK__m_user__Ccountry__04E4BC85");

                entity.HasOne(d => d.Cstate)
                    .WithMany(p => p.MUserCstates)
                    .HasForeignKey(d => d.CstateId)
                    .HasConstraintName("FK__m_user__CstateId__05D8E0BE");

                entity.HasOne(d => d.Nationality)
                    .WithMany(p => p.MUsers)
                    .HasForeignKey(d => d.NationalityId)
                    .HasConstraintName("FK__m_user__National__06CD04F7");

                entity.HasOne(d => d.Pcity)
                    .WithMany(p => p.MUserPcities)
                    .HasForeignKey(d => d.PcityId)
                    .HasConstraintName("FK__m_user__PcityId__07C12930");

                entity.HasOne(d => d.Pcountry)
                    .WithMany(p => p.MUserPcountries)
                    .HasForeignKey(d => d.PcountryId)
                    .HasConstraintName("FK__m_user__Pcountry__08B54D69");

                entity.HasOne(d => d.Pstate)
                    .WithMany(p => p.MUserPstates)
                    .HasForeignKey(d => d.PstateId)
                    .HasConstraintName("FK__m_user__PstateId__09A971A2");

                entity.HasOne(d => d.UserType)
                    .WithMany(p => p.MUsers)
                    .HasForeignKey(d => d.UserTypeId)
                    .HasConstraintName("FK__m_user__UserType__0A9D95DB");
            });

            modelBuilder.Entity<MUserType>(entity =>
            {
                entity.ToTable("m_userType");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Remarks)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<SurveyDetail>(entity =>
            {
                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.AreYouWantToBeOnDigitalPlatform)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Are_you_want_to_be_on_digital_platform")
                    .IsFixedLength(true);

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DiagnosticCentre)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Diagnostic_Centre")
                    .IsFixedLength(true);

                entity.Property(e => e.EstablishmentYear).HasColumnName("Establishment_Year");

                entity.Property(e => e.HomeDeliveryService)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Home_Delivery_Service")
                    .IsFixedLength(true);

                entity.Property(e => e.HomeServices)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Home_Services")
                    .IsFixedLength(true);

                entity.Property(e => e.IpAddress)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MedicalStore)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Medical_Store")
                    .IsFixedLength(true);

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.OwnerContactNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Owner_ContactNo");

                entity.Property(e => e.OwnerMail)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Owner_Mail");

                entity.Property(e => e.OwnerName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Owner_Name");

                entity.Property(e => e.Pathology)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.RegNo)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Reg_no");

                entity.Property(e => e.Remarks)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Rmp)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("RMP")
                    .IsFixedLength(true);

                entity.Property(e => e.ServiceTiming)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Service_Timing");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<UserCardDetail>(entity =>
            {
                entity.ToTable("userCardDetails");

                entity.Property(e => e.CardHoldeName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CardIssueDate).HasColumnType("datetime");

                entity.Property(e => e.CardNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CardValidityYear)
                    .HasColumnType("datetime")
                    .HasColumnName("CardValidity_Year");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IpAddress)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Remarks)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserCardDetails)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__userCardD__UserI__0B91BA14");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
