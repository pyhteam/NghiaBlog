namespace NghiaBlog.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    [Table("tintuc")]
    public partial class tintuc
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [StringLength(150)]
        [Required]
        [DisplayName("Tiêu đề")]
        public string tieude { get; set; }

        [StringLength(250)]
        [Required]
        [DisplayName("Tóm tắt")]
        public string tomtat { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        [DisplayName("Nội dung")]
        [AllowHtml]
        public string noidung { get; set; }

        [StringLength(150)]
        [Required]
        [DisplayName("Hình ảnh")]
        public string img { get; set; }

        [DisplayName("Ngày tạo")]
        public DateTime? ngaytao { get; set; }
    }
}
