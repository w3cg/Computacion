﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEN.HELPERS
{
    public class CenControlError
    {
        public string Tipo { get; set; }
        public string Codigo { get; set; }
        public string Mensaje { get; set; }
        public object Cuerpo { get; set; }
    }
}
