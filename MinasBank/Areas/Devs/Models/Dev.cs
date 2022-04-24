using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinasBank.Areas.Devs.Models
{
    public class Dev
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [MaxLength(15, ErrorMessage = "Nome deve ter no máx. 30 caracteres")]
        [MinLength(3, ErrorMessage = "Nome deve ter no mín. 3 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [MaxLength(30, ErrorMessage = "Sobrenome deve ter no máx. 30 caracteres")]
        [MinLength(3, ErrorMessage = "Sobrenome deve ter no mín. 3 caracteres")]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; }

        [DataType(DataType.Date)]
        public DateTime Nascimento { get; set; }

        public string FotoUrl { get; set; }

        [NotMapped]
        public IFormFile Foto { get; set; }

        public string GitHub { get; set; }

        public string Linkedin { get; set; }

        public string TextAbout { get; set; }
    }
}
