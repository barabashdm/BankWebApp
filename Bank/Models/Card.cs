using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Bank.Models
{
    public class Card
    {
        public int CardId { get; set; }
        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        public ApplicationUser ApplicationUser { get; set; }
        [Display(Name = "Номер карты")]
        public string CardNumber { get; set; }
        [Display(Name = "Дата оформления")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime ReceivingDate { get; set; }
        [Display(Name = "Дата окончания действия")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime ValidUntil { get; set; }
        [Display(Name = "Валюта")]
        public string Currency { get; set; }
        [Display(Name = "Счёт")]
        public decimal Balance { get; set; }

    }
}