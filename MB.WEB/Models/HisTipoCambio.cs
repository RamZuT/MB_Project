﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MB.WEB.Models
{
    public class HisTipoCambio
    {
        public int iIdTipoCambio { get; set; }
        public double vDecimal { get; set; }
        public DateTime dFecha { get; set; }
        public int iIdMoneda { get; set; }
    }
}