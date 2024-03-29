//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SinemaBilgi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Filmler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Filmler()
        {
            this.Slider = new HashSet<Slider>();
        }
    
        public int FilmID { get; set; }
        [StringLength(35, ErrorMessage = "35 karakterden uzun olamaz")]
        public string FilmAd { get; set; }
        [StringLength(50, ErrorMessage = "50 karakterden uzun olamaz")]
        public string FilmImg { get; set; }
        [StringLength(150, ErrorMessage = "150 karakterden uzun olamaz")]
        public string FragmanUrl { get; set; }
        [StringLength(10, ErrorMessage = "10 karakterden uzun olamaz")]
        public string FilmKategori { get; set; }
        [StringLength(50, ErrorMessage = "50 karakterden uzun olamaz")]
        public string Yapimi { get; set; }
        [StringLength(50, ErrorMessage = "50 karakterden uzun olamaz")]
        public string Turu { get; set; }
        [StringLength(20, ErrorMessage = "Sadece say�sal de�erler")]
        public string Suresi { get; set; }
        [StringLength(50, ErrorMessage = "50 karakterden uzun olamaz")]
        public string Yonetmeni { get; set; }
        public string Oyuncular { get; set; }
        [StringLength(50, ErrorMessage = "50 karakterden uzun olamaz")]
        public string Senaryo { get; set; }
        [StringLength(50, ErrorMessage = "50 karakterden uzun olamaz")]
        public string Yapimci { get; set; }
        public Nullable<int> Puan { get; set; }
        public string Ozeti { get; set; }
        [StringLength(20, ErrorMessage = "20 karakterden uzun olamaz")]
        public string VizyonTarihi { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Slider> Slider { get; set; }
    }
}
