﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desconecta.Repository.Models
{
    public class tabUsuariosResponsaveis
    {
        [Key]
        public int id { get; set; }
        public string userName { get; set; }
        public string senhaHash { get; set; }
        public string nomeCompleto { get; set; }
        public string email { get; set; }
    }
}
