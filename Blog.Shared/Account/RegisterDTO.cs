using System.ComponentModel.DataAnnotations;

namespace Blog.Shared.Account
{
    public class RegisterDTO
    {
        [Required(ErrorMessage = ".نام کاربری نباید خالی باشد")]
        [DataType(DataType.Text)]
        [RegularExpression("([a-zA-Z0-9_-]+)",
        ErrorMessage = " نام کاربری معتبر نیست. فقط می تواند" +
        ".حاوی حروف، شماره، خط فاصله و زیرخط باشد")] 
        [MaxLength(30, ErrorMessage = ".نام کاربری باید بین 3 تا 30 کارکتر باشد")]
        [MinLength(3, ErrorMessage = ".نام کاربری باید بین 3 تا 30 کارکتر باشد")]
        [Display(Name = "نام کاربری")]
        public string UserName { get; set; }

        public string Avatar { get; set; }

        [Required(ErrorMessage = ".ایمیل نباید خالی باشد")]
        [EmailAddress(ErrorMessage = ".ایمیل نا معتبر است")]
        [Display(Name = "ایمیل")]
        public string Email { get; set; }

        [Required(ErrorMessage = ".پسورد نباید خالی باشد")]
        [StringLength(100, ErrorMessage = ".پسورد باید حداقل {2} و حداکثر {1} کارکتر باشد", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "تایید پسورد")]
        [Compare("Password", ErrorMessage = ".پسورد یکی نمی باشد")]
        public string ConfirmPassword { get; set; }
    }
}
