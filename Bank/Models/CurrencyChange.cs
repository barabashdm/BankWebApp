using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Bank.Models
{
    static public class CurrencyChange
    {
        static public readonly decimal USDtoRUB = (decimal)68.8865;
        static public readonly decimal EURtoRUB = (decimal)78.5237;
        static public readonly decimal CNYtoRUB = (decimal)10.0092;
        static public readonly decimal EURtoUSD = (decimal)1.14098;
    }
}