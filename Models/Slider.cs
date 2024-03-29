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

    public partial class Slider
    {
        public int SliderId { get; set; }
        [StringLength(50, ErrorMessage = "50 karakterden uzun olamaz")]
        public string SliderUrl { get; set; }
        [StringLength(20, ErrorMessage = "20 karakterden uzun olamaz")]
        public string SliderAd { get; set; }
        [StringLength(30, ErrorMessage = "30 karakterden uzun olamaz")]
        public string SliderKisa { get; set; }
        public Nullable<int> SliderNo { get; set; }
        public Nullable<int> FilmID { get; set; }
    
        public virtual Filmler Filmler { get; set; }
    }
}
