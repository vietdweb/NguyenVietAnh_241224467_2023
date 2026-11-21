using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace NguyenVietAnh_241224467_2023.Models;

public partial class HangHoa
{
    [Key]
    public int MaHang { get; set; }

    public int MaLoai { get; set; }
    [Required(ErrorMessage ="Ten hang ko dc de trong")]

    public string TenHang { get; set; } = null!;
    [Required(ErrorMessage = "Gia ko dc de trong")]
    [Range(100,5000,ErrorMessage ="Gia phai nam trong khoang 100 den 5000")]
    public decimal? Gia { get; set; }
    [Required(ErrorMessage = "Anh ko dc de trong")]
    [RegularExpression(@"^.*\.(jpg|png|gif|tiff)$",ErrorMessage ="Ten file anh phai co cac duoi jpg png gif tiff")]
    public string? Anh { get; set; }

    public virtual LoaiHang MaLoaiNavigation { get; set; } = null!;
}
