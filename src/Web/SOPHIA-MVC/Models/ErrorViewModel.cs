using System;
using System.Collections.Generic;

namespace SOPHIA_MVC.Models
{
    public class ErrorViewModel
    {

        public int ErroCode { get; set; }
        public string Titulo { get; set; }
        public string Mensagem { get; set; }
    }

    public class ResponseResult
    {
        public string Title { get; set; }
        public string Status { get; set; }

        public ResponseErrorMessagens Erros { get; set; }
    }

    public class ResponseErrorMessagens
    {
        public List<string> Mensagens { get; set; }
    }
}
