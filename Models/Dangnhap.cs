using System.ComponentModel.DataAnnotations;

namespace Nhom13.Models;
public class Dangnhap
{
    [Key]
    public int UserID { get; set; }

    [Required(ErrorMessage = "Hãy nhập tài khoán của bạn ")]
    public string userName { get; set; }

    [Display(Name = "Mật khẩu ")]
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Hãy nhập mật khẩu của bạn ")]
    public string Password { get; set; }
}