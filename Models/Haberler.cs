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

    public partial class Haberler
    {
        public int HaberID { get; set; }
        [StringLength(50, ErrorMessage = "50 karakterden uzun olamaz")]
        public string HaberImg { get; set; }
        [StringLength(100, ErrorMessage = "100 karakterden uzun olamaz")]
        public string HaberBaslik { get; set; }
        [StringLength(200, ErrorMessage = "200 karakterden uzun olamaz")]
        public string HaberKisa { get; set; }
        public string HaberText { get; set; }
    }
}