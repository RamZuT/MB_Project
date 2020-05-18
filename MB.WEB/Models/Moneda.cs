using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MB.WEB.Models;

namespace MB.WEB.Models
{
    public class Moneda
    {
        public int iIdMoneda { get; set; }
        public string vCodMoneda { get; set; }
        public string vMoneda { get; set; }
        public Moneda objMoneda { get; set; }
    }
}