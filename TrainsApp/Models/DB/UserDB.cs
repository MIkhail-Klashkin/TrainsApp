using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrainsApp.Models
{
    public class UserDB
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Логин")]
        [Required(ErrorMessage = "Введите логин")]
        [MinLength(3, ErrorMessage = "Логин слишком короткий"), MaxLength(10, ErrorMessage = "Логин слишком длинный")]
        [RegularExpression(@"^(?=.*[A-Za-zА-Яа-я])[A-Za-zА-Яа-я\d_]{3,10}", ErrorMessage = "Логин некорректен")]
        public string Username { get; set; }
        [Display(Name = "Пароль")]
        [Required(ErrorMessage = "Введите пароль*")]
        [MinLength(6, ErrorMessage = "Пароль слишком короткий"), MaxLength(10, ErrorMessage = "Пароль слишком длинный")]
        [RegularExpression(@"^(?=.*[A-Za-zА-Яа-я])[A-Za-zА-Яа-я\d_]{6,10}", ErrorMessage = "Пароль некорректен")]
        public string Password { get; set; }
        [NotMapped]
        [Display(Name = "Подтвердите пароль")]
        [MinLength(6), MaxLength(10)]
        public string PasswordConfirm { get; set; }
        [Display(Name = "Поставьте галочку, если вы администратор)")]
        public bool Role { get; set; }
    }
}