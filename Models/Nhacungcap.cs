using System.ComponentModel.DataAnnotations;
namespace Nhom13.Models;
public class Nhacungcap {
    [Key]
    [Display( Name = "Mã NCC")]
    public string? MaNCC { get; set; }
    [Display(Name = "Tên Nhà cung cấp")]
    public string? TenNCC { get; set; }
    [Display(Name = "Số điện thoại")]
    public string? SdtNCC { get; set; }
    [Display(Name = "Địa chỉ")]
    public string? DiachiNCC { get; set; }
    
    [Display(Name = "Email")]
    [EmailAddress(ErrorMessage = "Email.?")]
    public string? EmailNCC { get; set; }
}