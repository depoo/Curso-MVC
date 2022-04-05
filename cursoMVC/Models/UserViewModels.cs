using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace cursoMVC.Models
{
    public class UserViewModels
    {
        public int id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage ="Debe tener almenos 1 Caracter", MinimumLength =1)]
        [Display(Name = "Correo Electronico")]
        public string Email { get; set; }
    }

    public class EditViewModels
    {
        public int id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Debe tener almenos 1 Caracter", MinimumLength = 1)]
        [Display(Name = "Correo Electronico")]
        public string Email { get; set; }
    }
}