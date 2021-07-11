namespace NghiaBlog.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("account")]
    public partial class account
    {
       
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        [DisplayName("Tên tài khoản")]
        public string username { get; set; }

        [Required]
        [DisplayName("Mật khẩu")]
        public string password { get; set; }

        [Required]
        [DisplayName("Tên hiện thị")]
        public string displayname { get; set; }

        [DisplayName("Ngày tạo")]
        public DateTime? create_at { get; set; }
    }
}
