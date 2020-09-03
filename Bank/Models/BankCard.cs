using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Bank.Models
{
    public class BankCard
    {
        [Key]
        public int CardId { get; set; }
        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        public ApplicationUser ApplicationUser { get; set; }
        [Display(Name = "Номер карты")]
        public string CardNumber { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Дата выдачи")]
        public DateTime ReceivingDate { get; set; }
        [Display(Name = "Дата окончания действия")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ValidUntil { get; set; }
        [Display(Name = "Валюта")]
        public string Currency { get; set; }
        [Display(Name = "Счёт")]
        //[DataType(DataType.Currency)]
        //[DisplayFormat(DataFormatString = "{0:C0}")]
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal Balance { get; set; }

        public override string ToString()
        {
            return CardNumber;
        }
    }
}