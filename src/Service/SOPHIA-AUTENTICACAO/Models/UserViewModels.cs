using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SOPHIA_AUTENTICACAO.Models
{
    public class UsuarioRegistro
    {
        //[Required(ErrorMessage = "O Campo é {0} obrigatório")]
        //public string Nome { get; set; }
        //[Required(ErrorMessage = "O Campo é {0} obrigatório")]
        //public string Cpf { get; set; }

        [Required(ErrorMessage = "O Campo é {0} obrigatório")]
        [EmailAddress(ErrorMessage = "O campo {0} esta no formato errado! ")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O Campo é {0} obrigatório")]
        [StringLength(50, ErrorMessage = "O campo {0} precisa ter 2 e 1 caracteres", MinimumLength = 6)]
        public string Senha { get; set; }
        [Compare("Senha", ErrorMessage = "As senhas nao conferem")]
        public string ConfirmaSenha { get; set; }
    }

    public class UsuarioLogin
    {
        [Required(ErrorMessage = "O Campo é {0} obrigatório")]
        [EmailAddress(ErrorMessage = "O campo {0} esta no formato errado! ")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O Campo é {0} obrigatório")]
        [StringLength(50, ErrorMessage = "O campo {0} precisa ter 2 e 1 caracteres", MinimumLength = 6)]
        public string Senha { get; set; }
    }

    public class UsuarioRespostaLogin
    {
        public string AccessToken { get; set; }
        public double ExpiresIn { get; set; }
        public UsuarioToken UsuarioToken { get; set; }
    }

    public class UsuarioToken
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public IEnumerable<UsuarioClain> Clains { get; set; }
    }

    public class UsuarioClain
    {
        public string Value { get; set; }
        public string Types { get; set; }

    }
}
