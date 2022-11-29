using System;
using System.ComponentModel.DataAnnotations;


namespace Nhom13.Models;
public class Nhanvien {
    [Key]
    [Display( Name = "Mã NV")]
    public string? MaNV { get; set;}
    [Display( Name = "Tên")]
    public string? TenNV { get; set;}
    [Display( Name = "Ngày sinh")]

     [DataType(DataType.Date)]
    public DateTime NgaysinhNV {get; set;}
    [Display( Name = "Số điện thoại")]
    public string? SdtNV { get; set;}
    [Display( Name = "Địa chỉ")]
    public string? DiachiNV { get; set;}
    [Display( Name = "Email")]
    public string? EmailNV { get; set;}


}