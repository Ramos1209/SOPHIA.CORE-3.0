﻿namespace SOPHIA_WebApiCore.Identidade
{
    public class AppSetting
    {
        public string Secret { get; set; }
        public int ExpiracaoHoras { get; set; }
        public string Emissor { get; set; }
        public string ValidoEm { get; set; }

    }
}
