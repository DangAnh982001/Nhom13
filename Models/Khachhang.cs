using System;
using System.ComponentModel.DataAnnotations;


namespace Nhom13.Models;
public class Khachhang {
    [Key]
    [Display( Name = "Mã KH")]
    public string? MaKH { get; set;}
    [Display( Name = "Tên")]
    public string? TenKH { get; set;}
    [Display( Name = "Ngày sinh")]

     [DataType(DataType.Date)]
    public DateTime NgaysinhKH {get; set;}
    [Display( Name = "Địa chỉ")]
    public string? DiachiKH { get; set;}
}