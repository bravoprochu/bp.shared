﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bp.shared.DTO
{
    public class ConfigurationDTO
    {
        public ConfigurationConnectionStringsDTO ConnectionStrings { get; set; }
        public ConfigurationTokenDTO Tokens { get; set; }
    }

    public class ConfigurationConnectionStringsDTO
    {
        public string Ident { get; set; }
        public string Dane { get; set; }
    }

    public class ConfigurationTokenDTO
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
    }

    public class CreationInfo
    {
        public string CreatedBy { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public string ModifyBy { get; set; }
        public DateTime? ModifyDateTime { get; set; }
    }



}
