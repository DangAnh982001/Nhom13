using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nhom13.Models;
public class Hoadon
{
    [Key]
    [Display(Name = "Mã HD")]
    public string? MaHD { get; set; }
    
    public string? TenKH { get; set; }
    [ForeignKey("TenKH")]
    [Display(Name = "Tên khách hàng")]
    public Khachhang? Khachhang { get; set; }
    
    public string? TenSP { get; set; }
    [ForeignKey("TenSP")]
    [Display(Name = "Sản phẩm")]
    public Sanpham? Sanpham { get; set; }
    
    [Display(Name = " Số lượng ")]
    public int SoluongHD { get; set; }
    
    [DataType(DataType.Date)]
    [Display(Name = " Ngày bán ")]
    public DateTime Ngayban { get; set; }


}