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
        public ResponseResult()
        {
            Erros = new ResponseErrorMessagens();
        }
        public string Title { get; set; }
        public string Status { get; set; }

        public ResponseErrorMessagens Erros { get; set; }
    }

    public class ResponseErrorMessagens
    {
        public ResponseErrorMessagens()
        {
            Mensagens = new List<string>();
        }
        public List<string> Mensagens { get; set; }
    }
}
