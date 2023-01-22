using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DesafioNet.Models
{
    public class ConexaoDB
    {
        public static string connectDB { get; set; } = @"user=sa;password=YOUR_PASS;server=DESKTOP-UDFUOG7, 1046\SQLEXPRESS;database=DesafioNet;connection timeout=30;";
    }
}