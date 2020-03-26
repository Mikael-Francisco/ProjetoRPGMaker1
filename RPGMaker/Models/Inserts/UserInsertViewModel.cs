using DTO;
using DTO.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RPGMaker.Models.Inserts
{
    public class UserInsertViewModel
    {
        [DisplayName("Nome")]
        [Required(ErrorMessage = "O nome deve ser informado")]
        [StringLength(maximumLength: 50, MinimumLength = 2, ErrorMessage = "O nome deve conter 2 e 50 caracteres")]
        public string Name { get; set; }
        [DisplayName("Email")]
        [Required(ErrorMessage = "O email deve ser informado")]
        [StringLength(maximumLength: 100, MinimumLength = 2, ErrorMessage = "O email deve conter 2 e 100 caracteres")]
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }
        public List<Character> Character { get; set; }
    }
}
