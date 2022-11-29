using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Nhom13.Models;
public class Nhaphang {
    [Key]
    public string? IDNH { get; set;}
    
    public string? TenSP { get; set;}
    [ForeignKey("TenSP")]
    [Display( Name = "Sản phẩm")]
    public Sanpham? Sanpham { get; set;}
    
    [Display( Name = "Số lượng")]
    public string? SoluongSP {get; set;}
   
    public string? TenNCC { get; set;}
    [ForeignKey("TenNCC")]
     [Display( Name = "Nhà cung cấp")]
    public Nhacungcap? Nhacungcap { get; set;}
    
    public string? TenNV { get; set;}
    [ForeignKey("TenNV")]

    [Display( Name = "Nhân viên")]
    public Nhanvien? Nhanvien { get; set;}
    
    [DataType(DataType.Date)]
    [Display( Name = "Ngày nhập")]
    public DateTime NgaynhapSP {get; set;}

}