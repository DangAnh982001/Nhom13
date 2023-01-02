using System.ComponentModel.DataAnnotations;

namespace Nhom13.Models;
public class Login
{
    [Key]
    public int userId { get; set; }

    [Required(ErrorMessage = "Yêu cầu nhập username!")]
    public string? username { get; set; }



    [Display(Name = "Mật khẩu")]
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Yêu cầu nhập mật khẩu!")]
    public string? password { get; set; }
}